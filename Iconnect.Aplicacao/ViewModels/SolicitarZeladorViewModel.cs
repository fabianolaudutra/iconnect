using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class SolicitarZeladorViewModel
    {
        public string soz_n_codigo { get; set; }
        public string soz_c_descricao { get; set; }
        public string soz_mor_n_codigo { get; set; }
        public string soz_n_fila { get; set; }
        public string soz_c_status { get; set; }
        public string soz_d_dataSolicitacao { get; set; }
        public string soz_c_resposta { get; set; }
        public string soz_d_modificacao { get; set; }
        public string soz_c_unique { get; set; }
        public string soz_d_atualizado { get; set; }
        public string soz_d_inclusao { get; set; }
        public string soz_fap_n_codigo { get; set; }
        public DateTime dateOrder { get; set; }
        public string NomeMorador { get; set; }
        public string NomeCliente { get; set; }
    }
}