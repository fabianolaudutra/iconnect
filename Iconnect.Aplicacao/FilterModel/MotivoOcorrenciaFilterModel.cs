using Iconnect.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public class MotivoOcorrenciaFilterModel : Paginacao
    {
        public string moc_n_codigo_filter { get; set; }
        public string moc_c_descricao_filter { get; set; }
        public string moc_b_encerrar_filter { get; set; }
        public string moc_cli_n_codigo_filter { get; set; }

    }
}
