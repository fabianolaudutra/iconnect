namespace Iconnect.Aplicacao.ViewModels
{
    public class RelatorioRefeitorioViewModel
    {
        public string TipoCliente { get; set; }
        public string ClienteId { get; set; }
        public string TipoPessoa { get; set; }
        public string PontoAcesso { get; set; }
        public string Usuario { get; set; }
        public string UsuarioId { get; set; }
        public string DataEvento { get; set; }
        public string Status { get; set; }
        public string DescricaoRefeicao { get; set; }
        public string ValorRefeicao { get; set; }
        public string CpfMorador { private get; set; }
        public string MoradorGrupoFamiliarId { get; set; }
        public string CpfPrestador { private get; set; }
        public string CpfVisitante { private get; set; }

        private string cpf;
        public string CPF
        {
            get
            {
                if (TipoPessoa.ToUpper().Equals("MORADOR"))
                {
                    cpf = CpfMorador;
                }
                else if (TipoPessoa.ToUpper().Equals("PRESTADOR"))
                {
                    cpf = CpfPrestador;
                }
                else if (TipoPessoa.ToUpper().Equals("VISITANTE"))
                {
                    cpf = CpfVisitante;
                }

                return cpf;
            }
        }
    }
}
