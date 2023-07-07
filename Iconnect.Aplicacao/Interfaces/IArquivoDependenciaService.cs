using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IArquivoDependenciaService
    {
        public string uploadArquivo(string id, string nome, byte[] imageByte);
        public byte[] GetFoto(int id);
        public bool DeletarArquivo(int id);
        public byte[] GetArquivo(int id);
        public byte[] GetImg(int id);
    }
}
