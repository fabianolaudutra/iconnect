using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class GrupoFamiliarViewModel
    {
        public string grf_n_codigo { get; set; }
        public string grf_c_status { get; set; }
        public string grf_c_tipo { get; set; }
        public string grf_c_nomeResponsavel { get; set; }
        public string grf_c_rg { get; set; }
        public string grf_c_cpf { get; set; }
        public string grf_c_telefone { get; set; }
        public string grf_c_email { get; set; }
        public string grf_c_numeroVagas { get; set; }
        public string grf_c_BlocoQuadra { get; set; }
        public string grf_c_LoteApto { get; set; }
        public string grf_c_observacao { get; set; }
        public string grf_c_celular { get; set; }
        public string grf_fot_n_codigo { get; set; }
        public string grf_cli_n_codigo { get; set; }
        public string grf_d_alteracao { get; set; }
        public string grf_c_usuario { get; set; }
        public string grf_d_modificacao { get; set; }
        public string grf_c_unique { get; set; }
        public string grf_d_atualizado { get; set; }
        public string grf_d_inclusao { get; set; }
        public string grf_c_senhaApp { get; set; }
        public string grf_n_ramal { get; set; }
        public string grf_c_autorizacaoPRO { get; set; }
        public string NomeCliente { get; set; }
        public string buscaSimples { get; set; }
        public string buscaSimplesSala { get; set; }
        public string grf_b_permiteHomeCare { get; set; }
        public string grf_c_observacoesHomeCare { get; set; }
        public string grf_ace_n_codigo { get; set; }
        public string grf_c_nomeSalaComercial { get; set; }

        public string grf_c_estado { get; set; }

        public string localizacao { get; set; }
        public AcessoViewModel acesso { get; set; }
        public string grf_cli_tcl_n_codigo { get; set; }
        public string grf_vec_c_placa { get; set; }
    }
}