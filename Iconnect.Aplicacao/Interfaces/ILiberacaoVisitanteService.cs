using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ILiberacaoVisitanteService : IRepositoryBase<tb_liv_liberacaoVisitante>
    {
        public  LiberacaoVisitanteViewModel SalvarLiberacao(LiberacaoVisitanteViewModel model);

        bool DeleteLiberacao(int id);
    }
}
