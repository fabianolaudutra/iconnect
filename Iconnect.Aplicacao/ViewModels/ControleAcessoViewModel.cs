using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class ControleAcessoViewModel
    {
        public string cac_n_codigo { get; set; }
        public string cac_mor_n_codigo { get; set; }
        public string cac_c_descricao { get; set; }
        public string cac_c_numeroCartao { get; set; }
        public string cac_b_ativo { get; set; }
        public string cac_b_panico { get; set; }
        public string cac_c_tipo { get; set; }
        public string cac_c_tipoAcesso { get; set; }
        public string cac_c_senha { get; set; }
        public string cac_vis_n_codigo { get; set; }
        public string cac_pse_n_codigo { get; set; }
        public string cac_c_numeroChave { get; set; }
        public string cac_usu_n_codigo { get; set; }
        public string cac_d_modificacao { get; set; }
        public string cac_c_unique { get; set; }
        public string cac_d_atualizado { get; set; }
        public string cac_d_inclusao { get; set; }
        public string cac_c_biometria { get; set; }
        public string valor_acesso { get; set; }
        public string origem { get; set; }

        //Id Solicitação Biometrica
        public string bio_n_codigo { get; set; }

        //Id controle acesso antigo
        public IList<int> cacOld { get; set; }
    }
}