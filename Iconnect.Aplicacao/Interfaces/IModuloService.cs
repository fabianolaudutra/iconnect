using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IModuloService : IRepositoryBase<tb_mol_modulosLiberados>
    {
        public ModuloViewModel InsertOrUpdate(ModuloViewModel model);
        public void Find(ref tb_mol_modulosLiberados tbModulo);
        public ModuloViewModel GetModulos(int id);
        public bool DeletarModulo(int id);
    }
}
