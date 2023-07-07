using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.FilterModel
{
    public class ZoneamentoClienteFilterModel : Paginacao
    {
        public string zoc_n_codigo_filter { get; set; }
        public string zoc_eqc_n_codigo_filter { get; set; }
        public string zoc_c_nomePonto_filter { get; set; }
        public string zoc_c_zona_filter { get; set; }
        public string zoc_c_tipoSensor_filter { get; set; }
        public string zoc_n_temporizadorDisparo_filter { get; set; }
        public string zoc_cla_n_codigo { get; set; }
        public string zoc_cli_n_codigo_filter { get; set; }
    }
}
