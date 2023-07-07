using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IAcompanhanteService : IRepositoryBase<tb_aco_acompanhante>
    {
        bool DeletarAcompanhante(int id);
    }
}
