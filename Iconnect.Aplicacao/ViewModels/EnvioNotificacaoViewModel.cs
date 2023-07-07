using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class EnvioNotificacaoViewModel
    {
        public string eno_n_codigo { get; set; }
        public string eno_c_titulo { get; set; }
        public string eno_c_mensagem { get; set; }
        public string eno_cli_n_codigo { get; set; }
        public string eno_c_GruposFamiliares { get; set; }
        public string eno_d_inicio { get; set; }
        public string eno_d_fim { get; set; }
        public string eno_c_MoradoresGruposFamiliares { get; set; }
        public string eno_c_unique { get; set; }
        public string eno_d_atualizado { get; set; }
        public string eno_d_inclusao { get; set; }
        public string NomeCliente { get; set; }
        public string mor_n_codigo { get; set; }
        public string mor_c_nome { get; set; }
        public string Status { get; set; }
        public string buscaSimples { get; set; }
        public DateTime? data_inicio { get; set; }

        public DateTime? data_fim { get; set; }
        public List<MoradorViewModel> Moradores { get; set; }
        public string[] MoradoresSelecionados { get; set; }
        public string enviar_app_connect { get; set; }
    }
}