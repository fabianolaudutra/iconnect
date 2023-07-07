using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class MonitoramentoViewModel
    {
        public string mon_n_codigo { get; set; }
        public string mon_cli_n_codigo { get; set; }
        public string mon_eve_n_codigo { get; set; }
        public string mon_cev_n_codigo { get; set; }
        public string mon_d_dataInsercao { get; set; }
        public string mon_d_dataEdicao { get; set; }
        public string mon_stm_n_codigo { get; set; }
        public string mon_zoc_n_codigo { get; set; }
        public string mon_c_observacao { get; set; }
        public string mon_n_responsavel { get; set; }
        public string mon_d_dataEvento { get; set; }
        public string mon_c_motivo { get; set; }
        public string mon_ate_n_codigo { get; set; }
        public string mon_b_precisaAtendimento { get; set; }
        public string mon_c_motivoConclusao { get; set; }
        public string mon_n_responsavelConclusao { get; set; }
        public string mon_c_observacaoConclusao { get; set; }
        public string mon_d_dataEventoConclusao { get; set; }
        public string mon_d_modificacao { get; set; }
        public string mon_d_dataExibicao { get; set; }
        public string mon_b_exibido { get; set; }
        public string mon_b_limpaEvento { get; set; }
        public string mon_pec_n_codigo { get; set; }
        public string mon_c_unique { get; set; }
        public string mon_d_atualizado { get; set; }
        public string mon_d_inclusao { get; set; }
        public string NomeZona { get; set; }
        public string NomeCentral { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeCliente { get; set; }
        public string cev_c_cor { get; set; }
        public string[] pessoas { get; set; }
        public string[] cev_n_codigo { get; set; }
        public string tipoPessoa { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string conclusao_inicio { get; set; }
        public string conclusao_fim { get; set; }
        public string Status { get; set; }
        public string tipoEvento { get; set; }
        public string CodigoStatus { get; set; }
        public string mon_n_codigoPessoaConclusao { get; set; }
        public string mon_n_codigoPessoa { get; set; }
        public DateTime mon_dtEvento { get; set; }
        public DateTime mon_dtEventoConclusao { get; set; }
        public string moc_b_encerrar { get; set; }
    }
}