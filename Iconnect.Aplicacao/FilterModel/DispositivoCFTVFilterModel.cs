using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class DispositivoCFTVFilterModel : Paginacao
    {
        public string ddv_n_codigo_filter { get; set; }
        public string ddv_cli_n_codigo_filter { get; set; }
        public string ddv_c_nome_filter { get; set; }
        public string ddv_fab_n_codigo_filter { get; set; }
        public string ddv_mod_n_codigo_filter { get; set; }
        public string ddv_n_canais_filter { get; set; }
        public string ddv_c_ip_filter { get; set; }
        public string ddv_c_portaServico_filter { get; set; }
        public string ddv_c_portaHTTP_filter { get; set; }
        public string ddv_c_usuario_filter { get; set; }
    }
}
