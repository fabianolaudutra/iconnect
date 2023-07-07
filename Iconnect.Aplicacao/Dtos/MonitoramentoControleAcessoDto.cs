namespace Iconnect.Aplicacao.Dtos
{
    public class MonitoramentoControleAcessoDto
    {
        public MonitoramentoControleAcessoDto()
        {
            con_n_codigo = string.Empty;
            con_cli_n_codigo = string.Empty;
            con_usu_n_codigo = string.Empty;
            con_c_usuario = string.Empty;
            con_c_cardNumber = string.Empty;
            con_c_tipoPessoa = string.Empty;
            con_c_pontoAcesso = string.Empty;
            con_c_status = string.Empty;
            cin_c_tipoEventoMotivo = string.Empty;
            con_d_evento = string.Empty;
            con_c_tipoAcesso = string.Empty;
            con_b_panico = string.Empty;
            con_b_panicoTratado = string.Empty;
            con_b_tipoPanico = string.Empty;
            con_c_obsTratamentoPanico = string.Empty;
            NomeCliente = string.Empty;
            con_fot_n_codigo = string.Empty;
            con_c_telefone = string.Empty;
        }

        public string con_n_codigo { get; set; }
        public string con_cli_n_codigo { get; set; }
        public string con_usu_n_codigo { get; set; }
        public string con_c_usuario { get; set; }
        public string con_c_cardNumber { get; set; }
        public string con_c_tipoPessoa { get; set; }
        public string con_c_pontoAcesso { get; set; }
        public string con_c_status { get; set; }
        public string cin_c_tipoEventoMotivo { get; set; }
        public string con_d_evento { get; set; }
        public string con_c_tipoAcesso { get; set; }
        public string con_b_panico { get; set; }
        public string con_b_panicoTratado { get; set; }
        public string con_b_tipoPanico { get; set; }
        public string con_c_obsTratamentoPanico { get; set; }
        public string NomeCliente { get; set; }
        public string con_fot_n_codigo { get; set; }
        public string con_c_telefone { get; set; }
    }
}