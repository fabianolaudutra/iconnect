using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IEstadoService : IRepositoryBase<tb_est_estado>
    {
        public List<EstadoViewModel> ListarEstados();
        public List<EstadoViewModel> ListarEstadosFiltrado();
    }
}
