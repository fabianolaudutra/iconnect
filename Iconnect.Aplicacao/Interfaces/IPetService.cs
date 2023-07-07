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
    public interface IPetService : IRepositoryBase<tb_pet_pet>
    {
        IPagedList<PetViewModel> GetPetFiltrado(PetFilterModel filter);
        
        public bool SalvarPet(PetViewModel model);

        public bool DeletarPet(int id);

        public bool DeletarPetSemGrupo();

        public bool VincularPets(int idGrupo);
    }
}