using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class AtendimentoViewModel
    {
        public string ate_n_codigo { get; set; }
        public string ate_cli_n_codigo { get; set; }
        public string ate_tpa_n_codigo { get; set; }
        public string ate_c_status { get; set; }
        public string ate_ope_n_preferencial { get; set; }
        public string ate_d_data { get; set; }
        public string ate_c_descricao { get; set; }
        public string ate_d_dataFinalizacao { get; set; }
        public string ate_d_modificacao { get; set; }
        public string ate_c_identificacaoVOIP { get; set; }
        public string ate_b_voipAbandonada { get; set; }
        public string ate_c_from { get; set; }
        public string ate_c_ramalAtendeu { get; set; }
        public string ate_b_LimparEvento { get; set; }
        public string ate_pec_n_codigo { get; set; }
        public string ate_c_unique { get; set; }
        public string ate_d_atualizado { get; set; }
        public string ate_d_inclusao { get; set; }
        public string totalEmAtt { get; set; }
        public string totalAguardAtt { get; set; }
        public string totalCliOn { get; set; }
        public string totalCliOff { get; set; }
        public string ate_panico_tratado { get; set; }

        public List<ClienteViewModel> lstEmAtt { get; set; }
        public List<ClienteViewModel> lstAguardAtt { get; set; }
    }
}
