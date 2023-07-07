using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class PessoasRecintoViewModel
    {
        public string CODIGO { get; set; }
        public string NOME { get; set; }
        public string DATA { get; set; }
        public string DATA_AUX { get; set; }
        public string TELEFONE { get; set; }
        public string LOCALIZACAO { get; set; }
        public string TIPO { get; set; }
        public string CODCLIENTE { get; set; }
        public string IN_OUT { get; set; }
        public string DATA_SAIDA_MANUAL { get; set; }
        public string PERFIL { get; set; }
        public string PSE_D_HORARIOFIM { get; set; }
        public string pse_b_panicotratado { get; set; }
        public string CODIGOEMPRESA { get; set; }
        public string GEROU_ATENDIMENTO { get; set; }
        public string NOMECLIENTE { get; set; }
        public string dispararPanico { get; set; }
        public string buscaSimples { get; set; }
        public DateTime data_entrada { get; set; }
        public string operTemp { get; set; }
        public bool? abertura { get; set; }
        public string LOCALIZACAONOME { get; set; }

    }
}