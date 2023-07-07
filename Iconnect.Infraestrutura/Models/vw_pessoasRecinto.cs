using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_pessoasRecinto
    {
        public int CODIGO { get; set; }
        public string NOME { get; set; }
        public DateTime? DATA { get; set; }
        public string TELEFONE { get; set; }
        public string LOCALIZACAO { get; set; }
        public string TIPO { get; set; }
        public int? CODCLIENTE { get; set; }
        public bool IN_OUT { get; set; }
        public DateTime? DATA_SAIDA_MANUAL { get; set; }
        public string PERFIL { get; set; }
        public string PSE_D_HORARIOFIM { get; set; }
        public bool? pse_b_panicotratado { get; set; }
        public int? CODIGOEMPRESA { get; set; }
        public bool GEROU_ATENDIMENTO { get; set; }
        public string NOMECLIENTE { get; set; }
    }
}
