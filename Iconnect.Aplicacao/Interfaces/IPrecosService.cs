using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IPrecosService : IRepositoryBase<tb_pre_precos>
    {
        object Salvar(PrecosViewModel model);
        PrecosViewModel[] GetPrecos();
        byte[] GeraExcel(FaturamentoFilterModel filter);
    }
}
