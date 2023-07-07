using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class PetService : RepositoryBase<tb_pet_pet>, IPetService
    {
        private IconnectCoreContext context;

        public PetService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<PetViewModel> GetPetFiltrado(PetFilterModel filter)
        {
            var query = (from pet in Context.tb_pet_pet
                         join rac in Context.tb_rac_raca on pet.pet_rac_n_codigo equals rac.rac_n_codigo
                         select new PetViewModel
                         {
                             pet_n_codigo = pet.pet_n_codigo.ToString(),
                             pet_c_foto = pet.pet_c_foto.ToString(),
                             pet_c_nome = pet.pet_c_nome,
                             pet_c_cor = pet.pet_c_cor,
                             pet_rac_n_codigo = pet.pet_rac_n_codigo.ToString(),
                             pet_c_porte = pet.pet_c_porte,
                             pet_c_pelagem = pet.pet_c_pelagem,
                             pet_c_caracteristicas = pet.pet_c_caracteristicas,
                             pet_grf_n_codigo = pet.pet_grf_n_codigo.ToString(),
                             pet_fot_n_codigo = pet.pet_fot_n_codigo != null ? pet.pet_fot_n_codigo.ToString() : "0",
                             pet_d_modificacao = pet.pet_d_modificacao.ToString(),
                             pet_c_unique = pet.pet_c_unique.ToString(),
                             pet_d_atualizado = pet.pet_d_atualizado.ToString(),
                             pet_d_inclusao = pet.pet_d_inclusao.ToString(),
                             Raca = rac.rac_c_nome.ToString(),
                         });

            if (!string.IsNullOrEmpty(filter.pet_grf_n_codigo_filter))
            {
                if(filter.pet_grf_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.pet_grf_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.pet_grf_n_codigo == filter.pet_grf_n_codigo_filter);
                }
            }

            return query.OrderBy(x => x.pet_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarPet(PetViewModel model)
        {
            try
            {
                if (model != null)
                {
                    if (string.IsNullOrEmpty(model?.pet_n_codigo) || model.pet_n_codigo.Equals("0"))
                    {
                        Insert(new tb_pet_pet()
                        {
                            pet_c_nome = model?.pet_c_nome,
                            pet_c_cor = model?.pet_c_cor,
                            pet_rac_n_codigo = Convert.ToInt32(model?.pet_rac_n_codigo),
                            pet_c_porte = model?.pet_c_porte,
                            pet_c_pelagem = model?.pet_c_pelagem,
                            pet_c_caracteristicas = model?.pet_c_caracteristicas,
                            pet_grf_n_codigo = !string.IsNullOrEmpty(model?.pet_grf_n_codigo) && !model.pet_grf_n_codigo.Equals("0") ? Convert.ToInt32(model?.pet_grf_n_codigo) : new int?(),
                            pet_fot_n_codigo = !string.IsNullOrEmpty(model?.pet_fot_n_codigo) && !model.pet_fot_n_codigo.Equals("0") ? Convert.ToInt32(model?.pet_fot_n_codigo) : new int?(),
                            pet_d_modificacao = DateTime.Now,
                            pet_c_unique = new Guid(),
                            pet_d_atualizado = DateTime.Now,
                            pet_d_inclusao = DateTime.Now
                        });
                    }
                    else
                    {
                        var Pet = (from pet in context.tb_pet_pet where pet.pet_n_codigo == Convert.ToInt32(model.pet_n_codigo) select pet)?.FirstOrDefault();
                        if (Pet != null)
                        {
                            Pet.pet_c_nome = model?.pet_c_nome;
                            Pet.pet_c_cor = model?.pet_c_cor;
                            Pet.pet_rac_n_codigo = !string.IsNullOrEmpty(model?.pet_rac_n_codigo) && !model.pet_rac_n_codigo.Equals("0") ? Convert.ToInt32(model?.pet_rac_n_codigo) : new int?();
                            Pet.pet_c_porte = model?.pet_c_porte;
                            Pet.pet_c_pelagem = model?.pet_c_pelagem;
                            Pet.pet_fot_n_codigo = !string.IsNullOrEmpty(model?.pet_fot_n_codigo) && !model.pet_fot_n_codigo.Equals("0") ? Convert.ToInt32(model?.pet_fot_n_codigo) : new int?();
                            Pet.pet_c_caracteristicas = model?.pet_c_caracteristicas;
                            Pet.pet_d_modificacao = DateTime.Now;
                            Pet.pet_d_atualizado = DateTime.Now;

                            Update(Pet);
                        }
                    }

                    context.SaveChanges();

                    return true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPet(int id)
        {
            try
            {
                Delete(context.tb_pet_pet.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPetSemGrupo()
        {
            try
            {
                var lstPets = context.tb_pet_pet.Where(x => x.pet_grf_n_codigo == null).ToList();

                if(lstPets.Count() > 0)
                {
                    foreach (var aviso in lstPets)
                    {
                        Delete(aviso);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        public bool VincularPets(int idGrupo)
        {
            try
            {
                var lstPets = context.tb_pet_pet.Where(x => x.pet_grf_n_codigo == null).ToList();

                if (lstPets.Count() > 0)
                {
                    foreach (var aviso in lstPets)
                    {
                        aviso.pet_grf_n_codigo = idGrupo;
                        Update(aviso);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}