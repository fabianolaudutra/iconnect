using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using IConnect.ViaCEP;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class CepService : ICepService
    {
        private readonly IconnectCoreContext _context;

        public CepService(IconnectCoreContext context)
        {
            _context = context;
        }

        public CepVielModel BuscaCep(string cep)
        {
            CepVielModel ret = new CepVielModel();
            cep = cep.Replace("-", "").Replace(".", "");

            try
            {
                var objRet = Search.ByZipCode(cep);

                string sigreEstado = objRet.UF;
                string nomeCidade = RemoverAcentos(objRet.Cidade);

                var estado = (from u in _context.tb_est_estado
                              where u.est_c_sigla == sigreEstado
                              select new tb_est_estado() { est_n_codigo = u.est_n_codigo }).FirstOrDefault();

                var cidade = (from u in _context.tb_cid_cidade
                              where u.cid_c_nome == nomeCidade && u.cid_est_n_codigo == estado.est_n_codigo
                              select new tb_cid_cidade() { cid_n_codigo = u.cid_n_codigo }).FirstOrDefault();

                ret.rua = objRet.Logradouro.ToUpper();
                ret.bairro = objRet.Bairro.ToUpper();
                ret.cidade = cidade.cid_n_codigo.ToString().ToUpper();
                ret.estado = estado.est_n_codigo.ToString().ToUpper();

                if (objRet != null)
                {
                    ret.retorno = "existe";
                    return ret;
                }
                else
                {
                    ret.retorno = "Naoexiste";
                    return ret;
                }

            }
            catch (Exception)
            {
                ret.retorno = "error";
                return ret;
            }
        }

        public string RemoverAcentos(string texto)
        {
            texto = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < texto.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(texto[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(texto[k]);
                }
            }
            return sb.ToString();
        }

    }
}
