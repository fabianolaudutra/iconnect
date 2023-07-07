using System;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Models
{
    public partial class vw_relatorio_pessoa
    {
        public string cli_c_nomeFantasia { get; set; }
        public int CODIGO { get; set; }
        public bool STATUS { get; set; }
        public string NOME { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime? DATA { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string RAMAL { get; set; }
        public string TIPO { get; set; }
        public int? CODCLIENTE { get; set; }
        public int? CODIGOEMPRESA { get; set; }
        public string LOCALIZACAO { get; set; }
        public string PERFIL { get; set; }
    }
}
