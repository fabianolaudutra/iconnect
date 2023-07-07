using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.IO;

namespace Iconnect.Bucket
{
    public static class ManageFile
    {
        private static GoogleCredential Credential { get; set; }

        private static void Auth()
        {
            try
            {
                if (Credential == null)
                {
                    string path = $"{AppDomain.CurrentDomain.BaseDirectory}iconnect-cloud-198200-02c06ffb7d64.json";

                    using (var file = File.OpenRead(path))
                    {
                        Credential = GoogleCredential.FromStream(file);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Problemas ao criar uma credencial.");
            }
        }

        public static string UploadFile(Stream arquivo, string objectName, string tipoArquivo, string bucketName = "portal-iconnect-imagens")
        {
            Auth();

            if (Credential != null)
            {
                var nome = $"{objectName}.{tipoArquivo}";

                var storage = StorageClient.Create(Credential);
                var data = storage.UploadObject(bucketName, nome, tipoArquivo, arquivo);

                if (data != null)
                {
                    return $"https://storage.googleapis.com/{bucketName}/{nome}";
                }
                else
                {
                    throw new Exception("Retorno inválido.");
                }
            }
            else
            {
                throw new Exception("Nenhuma credencial encontrada.");
            }
        }

        public static void DeleteFile(string objectName, string tipoArquivo, string bucketName = "portal-iconnect-imagens")
        {
            Auth();

            if (Credential != null)
            {
                var nome = $"{objectName}.{tipoArquivo}";

                var storage = StorageClient.Create(Credential);
                storage.DeleteObject(bucketName, nome);
            }
            else
            {
                throw new Exception("Nenhuma credencial encontrada.");
            }
        }

        public static string UpdateFile(Stream arquivo, string newObjectName, string oldObjectName, string tipoArquivo, string bucketName = "portal-iconnect-imagens")
        {
            Auth();

            if (Credential != null)
            {
                var storage = StorageClient.Create(Credential);

                var nome = $"{oldObjectName}.{tipoArquivo}";
                var old_obj = storage.GetObject(bucketName, nome);

                if (old_obj == null)
                {
                    throw new Exception("Arquivo não encontrado para atualizar.");
                }

                DeleteFile(oldObjectName, tipoArquivo, bucketName);

                var ret = UploadFile(arquivo, newObjectName, tipoArquivo);

                return ret;
            }
            else
            {
                throw new Exception("Nenhuma credencial encontrada.");
            }
        }
    }
}
