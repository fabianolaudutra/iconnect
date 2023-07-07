using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ICidadeService : IRepositoryBase<tb_cid_cidade>
    {
        public List<CidadeViewModel> ListarCidades();
        public List<CidadeViewModel> ListarCidadesFiltrado(int id);
    }
}
