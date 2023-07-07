using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class RegistroSalaoViewModel
    {
        public string res_n_codigo { get; set; }
        public string res_mor_n_codigo { get; set; }
        public string res_dpn_n_codigo { get; set; }
        public string res_d_dataSolicitacao { get; set; }
        public string res_c_periodo { get; set; }
        public string res_c_status { get; set; }
        public string res_c_observacao { get; set; }
        public Guid res_c_unique { get; set; }
        public DateTime res_d_atualizado { get; set; }
        public DateTime res_d_inclusao { get; set; }
        public string codigo_cliente { get; set; }
        public string nomeMorador { get; set; }
        public string nomeCliente { get; set; }
        public string nomeDependencia { get; set; }
        public string statusDescricao { get; set; }
        public DateTime? data_solicitacao { get; set; }
        public string res_n_inUsuarioId { get; set; }
        public int cli_tcl_n_codigo { get; set; }

        #region botões
        public string aprovar { get; set; }
        public string reprovar { get; set; }
        public string excluir { get; set; }
        public string editar { get; set; }
        public string cancelar { get; set; }
        #endregion                        
    }
}
