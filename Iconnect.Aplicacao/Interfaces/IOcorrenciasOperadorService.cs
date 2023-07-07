using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IOcorrenciasOperadorService : IRepositoryBase<tb_ocp_ocorrenciasOperador>
    {
        Retorno Salvar(OcorrenciasOperadorViewModel model);
        IPagedList<OcorrenciasOperadorViewModel> GetOcorrenciasOperadorFiltrado(OcorrenciasOperadorFilterModel filter, string idsClientes);
        OcorrenciasOperadorViewModel GetOcorrenciaOperador(int id);
        List<OcorrenciasOperadorViewModel> GetRelatorioOcorrenciasOperador(OcorrenciasOperadorViewModel model, string idsClientes);
    }
}