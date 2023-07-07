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
    class UsuarioAppService : RepositoryBase<tb_usu_UsuarioApp>, IUsuarioAppService
    {
        private readonly IconnectCoreContext context;

        public UsuarioAppService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool deleteUsuario(int id)
        {
            try
            {
                try
                {
                    Delete(context.tb_usu_UsuarioApp.Find(id));

                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public UsuarioAppViewModel GetLiberacoesUsuario(int id)
        {
            return (from usuario in context.tb_usu_UsuarioApp
                    join morador in context.tb_mor_Morador on usuario.usu_mor_n_codigo equals morador.mor_n_codigo
                    where usuario.usu_n_codigo == id
                    select new UsuarioAppViewModel()
                    {
                        usu_n_codigo = usuario.usu_n_codigo.ToString(),
                        usu_c_nome = usuario.usu_c_nome,
                        usu_mor_n_codigo = usuario.usu_mor_n_codigo.ToString(),
                        usu_c_email = usuario.usu_c_email,
                        usu_c_rg = usuario.usu_c_rg,
                        usu_c_telefone = usuario.usu_c_telefone,
                        usu_c_senha = usuario.usu_c_senha,
                        usu_b_liberado = usuario.usu_b_liberado.ToString(),
                        usu_c_condominio = usuario.usu_c_condominio,
                        usu_d_inclusao = usuario.usu_d_inclusao.ToString("dd/MM/yyyy HH:mm:ss"),
                        NomeMorador = morador.mor_c_nome,
                        mor_usu_c_cpf = morador.mor_c_cpf,
                    }).FirstOrDefault();
        }

        public IPagedList<UsuarioAppViewModel> GetUsuarioAppFiltrado(UsuarioAppFilterModel filter)
        {
            var query = from usuario in context.tb_usu_UsuarioApp
                        join morador in context.tb_mor_Morador on usuario.usu_mor_n_codigo equals morador.mor_n_codigo
                        where usuario.usu_b_liberado == false
                        orderby usuario.usu_d_inclusao descending
                        select new UsuarioAppViewModel
                        {
                            usu_n_codigo = usuario.usu_n_codigo.ToString(),
                            usu_c_nome = usuario.usu_c_nome,
                            usu_mor_n_codigo = usuario.usu_mor_n_codigo.ToString(),
                            usu_c_email = usuario.usu_c_email,
                            usu_c_rg = usuario.usu_c_rg,
                            usu_d_dataInclusao = usuario.usu_d_dataInclusao.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                            usu_c_telefone = usuario.usu_c_telefone,
                            usu_c_senha = usuario.usu_c_senha,
                            usu_b_liberado = usuario.usu_b_liberado.ToString(),
                            usu_c_condominio = usuario.usu_c_condominio,
                            usu_d_inclusao = usuario.usu_d_inclusao.ToString("dd/MM/yyyy"),
                            NomeMorador = morador.mor_c_nome,
                            dateOrder = usuario.usu_d_inclusao,
                            mor_usu_c_cpf = morador.mor_c_cpf,
                        };

            if (!string.IsNullOrEmpty(filter.idsClientes) && (!filter?.idsClientes?.Equals("todos") ?? false) && (!filter?.idsClientes?.Equals("NULL") ?? false) && string.IsNullOrEmpty(filter.cli_n_codigo_filter))
            {
                var ids = filter.idsClientes.Split(",");
                var lstIdsMoradores = (from morador in context.tb_mor_Morador
                                       where ids.Contains(morador.mor_cli_n_codigo.ToString())
                                       select morador.mor_n_codigo.ToString()).ToList();

                query = query.Where(w => lstIdsMoradores.Contains(w.usu_mor_n_codigo));
            }
            else if (!string.IsNullOrEmpty(filter.cli_n_codigo_filter))
            {
                var lstIdsMoradores = (from morador in context.tb_mor_Morador
                                       where morador.mor_cli_n_codigo == Convert.ToInt32(filter.cli_n_codigo_filter)
                                       select morador.mor_n_codigo.ToString()).ToList();

                query = query.Where(w => lstIdsMoradores.Contains(w.usu_mor_n_codigo));
            }

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarLiberacoesUsuario(UsuarioAppViewModel model)
        {
            try
            {
                var usuario = (from usu in context.tb_usu_UsuarioApp where usu.usu_n_codigo == Convert.ToInt32(model.usu_n_codigo) select usu).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.usu_b_liberado = Convert.ToBoolean(model.usu_b_liberado);
                    usuario.usu_d_modificacao = DateTime.Now;
                    usuario.usu_d_atualizado = DateTime.Now;

                    Update(usuario);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public UsuarioAppViewModel GetLiberacaoAtualizacaoGrid(int clienteId)
        {
            return (from usuario in context.tb_usu_UsuarioApp
                    join morador in context.tb_mor_Morador on usuario.usu_mor_n_codigo equals morador.mor_n_codigo
                    where morador.mor_cli_n_codigo == clienteId
                    select new UsuarioAppViewModel()
                    {
                        usu_n_codigo = usuario.usu_n_codigo.ToString(),
                        usu_c_nome = usuario.usu_c_nome,
                        usu_mor_n_codigo = usuario.usu_mor_n_codigo.ToString(),
                        usu_c_email = usuario.usu_c_email,
                        usu_c_rg = usuario.usu_c_rg,
                        mor_usu_c_cpf = morador.mor_c_cpf,
                        usu_d_dataInclusao = usuario.usu_d_dataInclusao.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        usu_c_telefone = usuario.usu_c_telefone,
                        usu_c_senha = usuario.usu_c_senha,
                        usu_b_liberado = usuario.usu_b_liberado.ToString(),
                        usu_c_condominio = usuario.usu_c_condominio,
                        usu_d_inclusao = usuario.usu_d_inclusao.ToString("dd/MM/yyyy"),
                        NomeMorador = morador.mor_c_nome,
                        dateOrder = usuario.usu_d_inclusao
                    }).FirstOrDefault();
        }
    }
}
