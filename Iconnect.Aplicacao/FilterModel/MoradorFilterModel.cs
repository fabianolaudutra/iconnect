using Iconnect.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.FilterModel
{
    public class MoradorFilterModel : Paginacao
    {
        public string mor_cli_n_codigo_filter { get; set; }
        public string mor_c_nome_filter { get; set; }
        public string mor_c_cpf_filter { get; set; }
        public string mor_c_rg_filter { get; set; }
        public string mor_c_telefonePermitido_filter { get; set; }
        public string[] idsClientes_filter { get; set; }
        public List<DocumentoMoradorViewModel> listDocumentos { get; set; }
        public string mor_c_blocoQuadra_filter { get; set; }
        public string mor_c_loteApto_filter { get; set; }
    }
}