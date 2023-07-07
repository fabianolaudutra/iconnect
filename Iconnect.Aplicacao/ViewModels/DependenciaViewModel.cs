using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class DependenciaViewModel
    {
        public string dpn_n_codigo { get; set; }
        public string dpn_cli_n_codigo { get; set; }
        public string dpn_c_nome { get; set; }
        public string dpn_c_bloco { get; set; }
        public string dpn_c_apto { get; set; }
        public string dpn_n_limitePessoas { get; set; }
        public string dpn_c_termosUso { get; set; }
        public string dpn_n_reservaPeriodo { get; set; }
        public string dpn_c_periodoManha { get; set; }
        public string dpn_c_periodoTarde { get; set; }
        public string dpn_c_periodoNoite { get; set; }
        public string dpn_c_periodoPorHorario { get; set; }
        public DateTime? dpn_d_modificacao { get; set; }
        public string dpn_ard_n_codigo { get; set; }
        public string dpn_c_tipoTermoUso { get; set; }
        public string dpn_ftd_n_codigo { get; set; }
        public string dpn_c_descricao { get; set; }
        public Guid dpn_c_unique { get; set; }
        public DateTime dpn_d_atualizado { get; set; }
        public DateTime dpn_d_inclusao { get; set; }
        public string dpn_b_autoLiberar { get; set; }
        public string dpn_b_ativoInativo { get; set; }
        public string dpn_nomeArquivo { get; set; }
        public bool tipoPeriodoAlterado { get; set; }
    }
}
