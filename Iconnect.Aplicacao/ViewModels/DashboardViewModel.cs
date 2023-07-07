using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.ViewModels
{
    public class DashboardViewModel
    {
        public string countlAcessos { get; set; }
        public string countlEventos{ get; set; }
        public string countlMorador{ get; set; }
        public string countlPrestador{ get; set; }
        public string countlVisitante{ get; set; }
        public string countlFuncionario{ get; set; }

        public List<string> periodo { get; set; }
        public List<string> total { get; set; }
        public List<string> periodoAnterior { get; set; }
        public List<string> totalAnterior { get; set; }
        public List<string> totalMorador { get; set; }
        public List<string> totalFuncionario { get; set; }
        public List<string> totalPrestador { get; set; }
        public List<string> totalVisitante { get; set; }
        public List<string> nomeCliente { get; set; }
        public List<string> nomeCategoria { get; set; }
    }
}