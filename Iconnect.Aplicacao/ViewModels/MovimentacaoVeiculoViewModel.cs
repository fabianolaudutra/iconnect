using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class MovimentacaoVeiculoViewModel
    {
        public string mve_n_codigo { get; set; }
        public string mve_fro_n_codigo { get; set; }
        public string mve_mor_n_codigo { get; set; }
        public string mve_c_fluxo { get; set; }
        public string mve_n_quilometragem { get; set; }
        public string mve_d_dataRegistro { get; set; }
        public string mve_c_usuarioLogado { get; set; }
        public bool mve_b_registroAutomatico { get; set; }
        public DateTime? mve_d_modificacao { get; set; }
        public Guid mve_c_unique { get; set; }
        public DateTime mve_d_atualizado { get; set; }
        public DateTime mve_d_inclusao { get; set; }
        public string Morador { get; set; }
        public string Fluxo { get; set; }
        public string cli_n_codigo { get; set; }
        public string tipo_relatorio { get; set; }
        public string tipo_agrupamento { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string Editavel { get; set; }
    }
}
