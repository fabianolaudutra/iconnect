using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using System.Security.Cryptography;
using Iconnect.Aplicacao.ViewModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using Iconnect.Aplicacao.Interfaces;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Services
{
    public class UsuarioSalaComercialService : RepositoryBase<tb_usc_usuarioSalaComercial>, IUsuarioSalaComercialService
    {
        private IconnectCoreContext context;

        public UsuarioSalaComercialService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        private IAcessoService _acesso;
        public IAcessoService AcessoService
        {
            get
            {
                if (_acesso == null)
                {
                    _acesso = new AcessoService(context);
                }
                return _acesso;
            }
        }


        public UsuarioSalaComercialViewModel GetUsuarioById(int id)
        {
            try
            {
                return (from usu in Context.tb_usc_usuarioSalaComercial
                        join ace in Context.tb_ace_acesso on usu.usc_ace_n_codigo equals ace.ace_n_codigo
                        where usu.usc_n_codigo == id
                        select new UsuarioSalaComercialViewModel()
                        {
                           usc_c_nome = usu.usc_c_nome,
                           usc_c_cpf = usu.usc_c_cpf,
                           usc_c_perfil = usu.usc_c_perfil,
                           usc_mor_n_codigo = usu.usc_mor_n_codigo.Value.ToString(),
                           usc_ace_n_codigo = usu.usc_ace_n_codigo.ToString(),
                           usc_n_codigo = usu.usc_n_codigo.ToString(),

                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool DeletarUsuario(int id)
        {
            try
            {
                var idAce = (from usc in context.tb_usc_usuarioSalaComercial where usc.usc_n_codigo == id select usc.usc_ace_n_codigo).FirstOrDefault();

                Delete(context.tb_usc_usuarioSalaComercial.Find(id));
                context.SaveChanges();


                //DELETE ACESSO
                AcessoService.DeletarAcesso(idAce);

               

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void InsertOrUpdate(UsuarioSalaComercialViewModel model)
        {
            try
            {
                var duplicado = ValidaDuplicado(model);

                if(duplicado == true)
                {
                    throw new Exception("Esta pessoa já possui um acesso cadastrado");
                }

                int? codeGrf = null;
                int? codMor = null;
                if (!string.IsNullOrEmpty(model.usc_grf_n_codigo))
                    codeGrf = Convert.ToInt32(model.usc_grf_n_codigo);

                if (!string.IsNullOrEmpty(model.usc_mor_n_codigo))
                    codMor = Convert.ToInt32(model.usc_mor_n_codigo);

                int codeUsc = Convert.ToInt32(model.usc_n_codigo);
                int codeAce = model.Acesso.ace_n_codigo;
                string atualizaNome = (from mor in context.tb_mor_Morador where mor.mor_n_codigo == codMor select mor.mor_c_nome).FirstOrDefault();

                if (codeUsc == 0)
                {
                    
                    Insert(new tb_usc_usuarioSalaComercial()
                    {
                        usc_grf_n_codigo = codeGrf,
                        usc_ace_n_codigo = codeAce,
                        usc_mor_n_codigo = codMor,
                        usc_c_nome = atualizaNome,
                        usc_c_perfil = model.usc_c_perfil,
                        usc_c_cpf = model.usc_c_cpf,
                        usc_c_usuario = model.usc_c_usuario,
                        usc_c_unique = Guid.NewGuid(),
                        usc_d_inclusao = DateTime.Now,
                        
                    });
                }
                else
                {
                    var usuario = (from usu in context.tb_usc_usuarioSalaComercial where usu.usc_n_codigo == codeUsc select usu)?.FirstOrDefault();

                    if (usuario == null) throw new Exception("Usuário não encontrado.");
                    
                    usuario.usc_ace_n_codigo = codeAce;
                    usuario.usc_mor_n_codigo = codMor;
                    usuario.usc_grf_n_codigo = codeGrf;
                    usuario.usc_c_perfil = model.usc_c_perfil;
                    usuario.usc_c_nome = atualizaNome;
                    usuario.usc_c_cpf = model.usc_c_cpf;
                    usuario.usc_c_usuario = model.usc_c_usuario;

                    Update(usuario);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar os dados");
            }
        }

        public IPagedList<UsuarioSalaComercialViewModel> GetUsuarioSalaFiltrado(UsuarioSalaComercialFilterModel filter)
        {
            try
            {
                var query = (from usu in Context.tb_usc_usuarioSalaComercial
                             orderby usu.usc_c_nome
                             select new UsuarioSalaComercialViewModel
                             {
                                 usc_n_codigo = usu.usc_n_codigo.ToString(),
                                 usc_mor_n_codigo = usu.usc_mor_n_codigo.ToString(),
                                 usc_ace_n_codigo = usu.usc_ace_n_codigo.ToString(),
                                 usc_grf_n_codigo = usu.usc_grf_n_codigo.ToString(),
                                 usc_c_nome = usu.usc_c_nome,
                                 usc_c_perfil = usu.usc_c_perfil,
                                 usc_c_cpf = usu.usc_c_cpf,
                             });

                int codGrf = Convert.ToInt32(filter.usc_grf_n_codigo_filter);
                if (codGrf > 0)
                {
                    query = query.Where(w => w.usc_grf_n_codigo.Equals(codGrf.ToString()));
                }
                else
                {
                    query = query.Where(w => w.usc_grf_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ValidaDuplicado(UsuarioSalaComercialViewModel model)
        {
            var query = (from usc in context.tb_usc_usuarioSalaComercial
                         where usc.usc_grf_n_codigo == Convert.ToInt32(model.usc_grf_n_codigo)
                         && usc.usc_mor_n_codigo == Convert.ToInt32(model.usc_mor_n_codigo)
                         && usc.usc_n_codigo != Convert.ToInt32(model.usc_n_codigo)
                         select usc).Count();
            if(query != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
