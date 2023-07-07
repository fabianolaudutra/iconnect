using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class AgenteComercialFilterModel : Paginacao
    {
        public string buscaSimples_filter { get; set; }
        public string age_n_codigo_filter { get; set; }
        public string age_c_nome_filter { get; set; }
        public string age_c_rg_filter { get; set; }
        public string age_c_email_filter { get; set; }
        public string age_c_celular_filter { get; set; }
        public string age_ace_n_codigo_filter { get; set; }
        public string idsAgenteComercial_filter { get; set; }
    }
}
