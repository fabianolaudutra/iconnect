using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IDashboardService
    {
        public DashboardViewModel RelAcessosPorPeriodo(DashboardFilterModel filter);
        public DashboardViewModel RelAcessosPorPessoa(DashboardFilterModel filter);
        public DashboardViewModel RelAcessosPorCliente(DashboardFilterModel filter);
        public DashboardViewModel RelMonitoramentoTempoMedioAtendimento(DashboardFilterModel filter);
        public DashboardViewModel RelMonitoramentoTempoMedioCliente(DashboardFilterModel filter);
        public DashboardViewModel RelMonitoramentoPorCategoria(DashboardFilterModel filter);
        public DashboardViewModel RelMonitoramentoPorDia(DashboardFilterModel filter);
        public DashboardViewModel RelTotalizadores(DashboardFilterModel filter);
    }
}