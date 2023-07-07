using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Iconnect.Infraestrutura.Models
{
    public partial class tb_aba_agendaBackupAutomatico
    {
        [Key]
        public int aba_n_codigo { get; set; }
        public int aba_cli_n_codigo { get; set; }
        public bool? aba_b_ativo { get; set; }
        public string aba_c_frequencia { get; set; }
        public int? aba_n_diaSemana { get; set; }
        public int aba_n_horario { get; set; }
        public string aba_c_usuario { get; set; }
        public DateTime aba_d_modificao { get; set; }
        public Guid aba_c_unique { get; set; }
        public DateTime aba_d_atualizado { get; set; }
        public DateTime aba_d_inclusao { get; set; }

        public virtual tb_cli_cliente tb_cli_cliente { get; set; }
    }
}
