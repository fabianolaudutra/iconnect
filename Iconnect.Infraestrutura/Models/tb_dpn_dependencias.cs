using Iconnect.Infraestrutura.Enums;
using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_dpn_dependencias
    {
        public tb_dpn_dependencias()
        {
            tb_res_registroSalao = new HashSet<tb_res_registroSalao>();
        }

        public int dpn_n_codigo { get; set; }
        public int? dpn_cli_n_codigo { get; set; }
        public string dpn_c_nome { get; set; }
        public string dpn_c_bloco { get; set; }
        public string dpn_c_apto { get; set; }
        public int? dpn_n_limitePessoas { get; set; }
        public string dpn_c_termosUso { get; set; }
        public EnumDependenciaPeriodo dpn_n_reservaPeriodo { get; set; }
        public string dpn_c_periodoManha { get; set; }
        public string dpn_c_periodoTarde { get; set; }
        public string dpn_c_periodoNoite { get; set; }
        public string dpn_c_periodoPorHorario { get; set; }
        public DateTime? dpn_d_modificacao { get; set; }
        public int? dpn_ard_n_codigo { get; set; }
        public string dpn_c_tipoTermoUso { get; set; }
        public int? dpn_ftd_n_codigo { get; set; }
        public string dpn_c_descricao { get; set; }
        public Guid dpn_c_unique { get; set; }
        public DateTime dpn_d_atualizado { get; set; }
        public DateTime dpn_d_inclusao { get; set; }
        public bool? dpn_b_autoLiberar { get; set; }
        public bool? dpn_b_ativoInativo { get; set; }
        public bool? dpn_b_permitirReservarPeriodo { get; set; }

        public virtual tb_ard_arquivoDependencias dpn_ard_n_codigoNavigation { get; set; }
        public virtual tb_cli_cliente dpn_cli_n_codigoNavigation { get; set; }
        public virtual tb_ftd_fotoDependencia dpn_ftd_n_codigoNavigation { get; set; }
        public virtual ICollection<tb_res_registroSalao> tb_res_registroSalao { get; set; }
    }
}
