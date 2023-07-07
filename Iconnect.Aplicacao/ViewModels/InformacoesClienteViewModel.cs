using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class InformacoesClienteViewModel
    {
        public string inc_n_codigo { get; set; }
        public string inc_cli_n_codigo { get; set; }
        public string inc_c_titulo { get; set; }
        public string inc_c_descricao { get; set; }
        public string inc_n_ordem { get; set; }
        public string inc_c_unique { get; set; }
        public string inc_d_atualizado { get; set; }
        public string inc_d_inclusao { get; set; }
    }
}