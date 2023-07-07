using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;

namespace Iconnect.Aplicacao.Services
{
    class PerfilHorarioService : RepositoryBase<tb_phr_perfilHorario>, IPerfilHorarioService
    {
        private IconnectCoreContext context;

        public PerfilHorarioService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public List<PerfilHorarioViewModel> GetPerfilHorarioFilter(int idCliente) {
            var query = (from phr in Context.tb_phr_perfilHorario
                         join hor in Context.tb_hor_horario on phr.phr_hor_n_codigo equals hor.hor_n_codigo
                         where phr.phr_cli_n_codigo == idCliente
                         select new PerfilHorarioViewModel()
                         {
                             phr_n_codigo = phr.phr_n_codigo.ToString(),
                             phr_c_status = phr.phr_c_status,
                             phr_c_nome = phr.phr_c_nome,
                             phr_c_pontoAcesso = phr.phr_c_pontoAcesso,
                             phr_hor_n_codigo = phr.phr_hor_n_codigo.ToString(),
                             phr_b_visitante = phr.phr_b_visitante.Value ? "SIM" : "NÃO",
                             phr_cli_n_codigo = phr.phr_cli_n_codigo.ToString(),
                             phr_b_antipassback = phr.phr_b_antipassback.Value ? "SIM" : "NÃO",
                             phr_d_modificacao = phr.phr_d_modificacao.ToString(),
                             phr_b_servico = phr.phr_b_servico.Value ? "SIM" : "NÃO",
                             phr_c_unique = phr.phr_c_unique.ToString(),
                             phr_d_atualizado = phr.phr_d_atualizado.ToString(),
                             phr_d_inclusao = phr.phr_d_inclusao.ToString(),
                             NomeTabelaHorario = hor.hor_c_nome,
                         }).ToList();

            return query;
        }
        public List<PerfilHorarioViewModel> GetPerfilHorarioByClienteFiltrado(int idCliente)
        {
            var query = (from phr in Context.tb_phr_perfilHorario
                         join hor in Context.tb_hor_horario on phr.phr_hor_n_codigo equals hor.hor_n_codigo
                         where phr.phr_cli_n_codigo == idCliente
                         orderby(phr.phr_c_nome)
                         select new PerfilHorarioViewModel()
                         {
                             phr_n_codigo = phr.phr_n_codigo.ToString(),
                             phr_c_status = phr.phr_c_status,
                             phr_c_nome = phr.phr_c_nome,
                             phr_c_pontoAcesso = phr.phr_c_pontoAcesso,
                             phr_hor_n_codigo = phr.phr_hor_n_codigo.ToString(),
                             phr_b_visitante = phr.phr_b_visitante.Value ? "SIM" : "NÃO",
                             phr_cli_n_codigo = phr.phr_cli_n_codigo.ToString(),
                             phr_b_antipassback = phr.phr_b_antipassback.Value ? "SIM" : "NÃO",
                             phr_d_modificacao = phr.phr_d_modificacao.ToString(),
                             phr_b_servico = phr.phr_b_servico.Value ? "SIM" : "NÃO",
                             phr_c_unique = phr.phr_c_unique.ToString(),
                             phr_d_atualizado = phr.phr_d_atualizado.ToString(),
                             phr_d_inclusao = phr.phr_d_inclusao.ToString(),
                             NomeTabelaHorario = hor.hor_c_nome,
                         }).ToList();

            return query;
        }
        public List<PerfilHorarioViewModel> GetPerfilHorarioByCliente(int idCliente, string tipoPessoa)
        {
            List<PerfilHorarioViewModel> lstPerfil = new List<PerfilHorarioViewModel>();

            switch (tipoPessoa.ToUpper())
            {
                case "VISITANTE":
                    lstPerfil = (from phr in context.tb_phr_perfilHorario
                                 where phr.phr_cli_n_codigo == idCliente && phr.phr_b_visitante == true
                                 orderby phr.phr_c_nome ascending
                                 select new PerfilHorarioViewModel()
                                 {
                                     phr_n_codigo = phr.phr_n_codigo.ToString(),
                                     phr_c_status = phr.phr_c_status,
                                     phr_c_nome = phr.phr_c_nome,
                                     phr_c_pontoAcesso = phr.phr_c_pontoAcesso,
                                     phr_hor_n_codigo = phr.phr_hor_n_codigo.ToString(),
                                     phr_b_visitante = phr.phr_b_visitante.ToString(),
                                     phr_cli_n_codigo = phr.phr_cli_n_codigo.ToString(),
                                     phr_b_antipassback = phr.phr_b_antipassback.ToString(),
                                     phr_d_modificacao = phr.phr_d_modificacao.ToString(),
                                     phr_b_servico = phr.phr_b_servico.ToString(),
                                     phr_c_unique = phr.phr_c_unique.ToString(),
                                     phr_d_atualizado = phr.phr_d_atualizado.ToString(),
                                     phr_d_inclusao = phr.phr_d_inclusao.ToString(),
                                 }).ToList();
                    break;

                case "PRESTADOR":
                    lstPerfil = (from phr in context.tb_phr_perfilHorario
                                 where phr.phr_cli_n_codigo == idCliente && phr.phr_b_servico == true
                                 orderby phr.phr_c_nome ascending
                                 select new PerfilHorarioViewModel()
                                 {
                                     phr_n_codigo = phr.phr_n_codigo.ToString(),
                                     phr_c_status = phr.phr_c_status,
                                     phr_c_nome = phr.phr_c_nome,
                                     phr_c_pontoAcesso = phr.phr_c_pontoAcesso,
                                     phr_hor_n_codigo = phr.phr_hor_n_codigo.ToString(),
                                     phr_b_visitante = phr.phr_b_visitante.ToString(),
                                     phr_cli_n_codigo = phr.phr_cli_n_codigo.ToString(),
                                     phr_b_antipassback = phr.phr_b_antipassback.ToString(),
                                     phr_d_modificacao = phr.phr_d_modificacao.ToString(),
                                     phr_b_servico = phr.phr_b_servico.ToString(),
                                     phr_c_unique = phr.phr_c_unique.ToString(),
                                     phr_d_atualizado = phr.phr_d_atualizado.ToString(),
                                     phr_d_inclusao = phr.phr_d_inclusao.ToString(),
                                 }).ToList();
                    break;

                case "MORADOR":
                    lstPerfil = (from phr in context.tb_phr_perfilHorario
                                 where phr.phr_cli_n_codigo == idCliente && phr.phr_b_visitante == false && phr.phr_b_servico == false
                                 orderby phr.phr_c_nome ascending
                                 select new PerfilHorarioViewModel()
                                 {
                                     phr_n_codigo = phr.phr_n_codigo.ToString(),
                                     phr_c_status = phr.phr_c_status,
                                     phr_c_nome = phr.phr_c_nome,
                                     phr_c_pontoAcesso = phr.phr_c_pontoAcesso,
                                     phr_hor_n_codigo = phr.phr_hor_n_codigo.ToString(),
                                     phr_b_visitante = phr.phr_b_visitante.ToString(),
                                     phr_cli_n_codigo = phr.phr_cli_n_codigo.ToString(),
                                     phr_b_antipassback = phr.phr_b_antipassback.ToString(),
                                     phr_d_modificacao = phr.phr_d_modificacao.ToString(),
                                     phr_b_servico = phr.phr_b_servico.ToString(),
                                     phr_c_unique = phr.phr_c_unique.ToString(),
                                     phr_d_atualizado = phr.phr_d_atualizado.ToString(),
                                     phr_d_inclusao = phr.phr_d_inclusao.ToString(),
                                 }).ToList();
                    break;
            }

            return lstPerfil;
        }

        public IPagedList<PerfilHorarioViewModel> GetPerfilHorarioFiltrado(PerfilHorarioFilterModel filter)
        {
            var query = (from phr in Context.tb_phr_perfilHorario
                         join hor in Context.tb_hor_horario on phr.phr_hor_n_codigo equals hor.hor_n_codigo
                         select new PerfilHorarioViewModel
                         {
                             phr_n_codigo = phr.phr_n_codigo.ToString(),
                             phr_c_status = phr.phr_c_status,
                             phr_c_nome = phr.phr_c_nome,
                             phr_c_pontoAcesso = phr.phr_c_pontoAcesso,
                             phr_hor_n_codigo = phr.phr_hor_n_codigo.ToString(),
                             phr_b_visitante = phr.phr_b_visitante.Value ? "SIM" : "NÃO",
                             phr_cli_n_codigo = phr.phr_cli_n_codigo.ToString(),
                             phr_b_antipassback = phr.phr_b_antipassback.Value ? "SIM" : "NÃO",
                             phr_d_modificacao = phr.phr_d_modificacao.ToString(),
                             phr_b_servico = phr.phr_b_servico.Value ? "SIM" : "NÃO",
                             phr_c_unique = phr.phr_c_unique.ToString(),
                             phr_d_atualizado = phr.phr_d_atualizado.ToString(),
                             phr_d_inclusao = phr.phr_d_inclusao.ToString(),
                             NomeTabelaHorario = hor.hor_c_nome,
                         });

            if (!string.IsNullOrEmpty(filter.phr_cli_n_codigo_filter) && filter.phr_cli_n_codigo_filter != "0")
            {
                query = query.Where(w => w.phr_cli_n_codigo == filter.phr_cli_n_codigo_filter);
            }
            else
            {
                query = query.Where(w => w.phr_cli_n_codigo == null);
            }

            return query.OrderBy(x => x.NomeTabelaHorario).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool SalvarPerfilHorario(PerfilHorarioViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.phr_n_codigo) || model.phr_n_codigo.ToString() == "0")
                {
                    Insert(new tb_phr_perfilHorario()
                    {
                        phr_c_status = model.phr_c_status,
                        phr_c_nome = model.phr_c_nome,
                        phr_c_pontoAcesso = model.phr_c_pontoAcesso,
                        phr_hor_n_codigo = Convert.ToInt32(model.phr_hor_n_codigo),
                        phr_b_visitante = Convert.ToBoolean(model.phr_b_visitante),
                        phr_cli_n_codigo = Convert.ToInt32(model.phr_cli_n_codigo),
                        phr_b_antipassback = Convert.ToBoolean(model.phr_b_antipassback),
                        phr_d_modificacao = DateTime.Now,
                        phr_b_servico = Convert.ToBoolean(model.phr_b_servico),
                        phr_c_unique = new Guid(),
                        phr_d_atualizado = DateTime.Now,
                        phr_d_inclusao = DateTime.Now,
                    });
                }
                else
                {
                    var PerfilHorario = (from phr in context.tb_phr_perfilHorario where phr.phr_n_codigo == Convert.ToInt32(model.phr_n_codigo) select phr).FirstOrDefault();
                    PerfilHorario.phr_c_status = model.phr_c_status;
                    PerfilHorario.phr_c_nome = model.phr_c_nome;
                    PerfilHorario.phr_c_pontoAcesso = model.phr_c_pontoAcesso;
                    PerfilHorario.phr_hor_n_codigo = Convert.ToInt32(model.phr_hor_n_codigo);
                    PerfilHorario.phr_b_visitante = Convert.ToBoolean(model.phr_b_visitante);
                    PerfilHorario.phr_cli_n_codigo = Convert.ToInt32(model.phr_cli_n_codigo);
                    PerfilHorario.phr_b_antipassback = Convert.ToBoolean(model.phr_b_antipassback);
                    PerfilHorario.phr_d_modificacao = DateTime.Now;
                    PerfilHorario.phr_b_servico = Convert.ToBoolean(model.phr_b_servico);
                    PerfilHorario.phr_d_atualizado = DateTime.Now;

                    Update(PerfilHorario);
                }

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarPerfilHorario(int id)
        {
            try
            {
                Delete(context.tb_phr_perfilHorario.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PerfilHorarioViewModel GetPerfilHorario(string idPerfil)
        {
            string textoConcatenar = "";
            if (idPerfil != "") {
                foreach (var item in idPerfil.Split(','))
                {
                    int id = Convert.ToInt32(item);
                    var perfil = (from phr in Context.tb_phr_perfilHorario where phr.phr_n_codigo == id select phr.phr_c_nome).FirstOrDefault();

                    if (textoConcatenar == "")
                        textoConcatenar = perfil.ToString().ToUpper();
                    else
                        textoConcatenar = textoConcatenar + ", " + perfil;
                }
            }
            PerfilHorarioViewModel _perfil = new PerfilHorarioViewModel();
            _perfil.phr_c_nome = textoConcatenar;
            return _perfil;
                
        }

        
    }
}