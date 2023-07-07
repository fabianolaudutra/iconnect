using System;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using Iconnect.Aplicacao.FilterModel;
using System.Collections.Generic;
using Iconnect.Infraestrutura.Enums;
using Iconnect.Infraestrutura.Exceptions;

namespace Iconnect.Aplicacao.Services
{
    public class DependenciasService : RepositoryBase<tb_dpn_dependencias>, IDependenciasService
    {
        private IconnectCoreContext context;

        public DependenciasService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public void Deletar(int id)
        {
            var dependencia = context.tb_dpn_dependencias.Find(id);

            if (dependencia == null)
                throw new MensagemException("Dependência não encontrada.");

            Delete(dependencia);
            context.SaveChanges();
        }

        public DependenciaViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public DependenciaViewModel GetDependencia(int id)
        {
            return (from dpn in Context.tb_dpn_dependencias
                    join ard in context.tb_ard_arquivoDependencias on dpn.dpn_ard_n_codigo equals ard.ard_n_codigo into tempArd
                    from ard in tempArd.DefaultIfEmpty()

                    where dpn.dpn_n_codigo == id

                    select new DependenciaViewModel
                    {
                        dpn_n_codigo = dpn.dpn_n_codigo.ToString(),
                        dpn_c_nome = dpn.dpn_c_nome,
                        dpn_b_ativoInativo = dpn.dpn_b_ativoInativo.ToString(),
                        dpn_b_autoLiberar = dpn.dpn_b_autoLiberar.ToString(),
                        dpn_c_bloco = dpn.dpn_c_bloco,
                        dpn_n_reservaPeriodo = $"{(int)dpn.dpn_n_reservaPeriodo}",
                        dpn_c_periodoManha = dpn.dpn_c_periodoManha,
                        dpn_c_periodoTarde = dpn.dpn_c_periodoTarde,
                        dpn_c_periodoNoite = dpn.dpn_c_periodoNoite,
                        dpn_c_periodoPorHorario = dpn.dpn_c_periodoPorHorario,
                        dpn_n_limitePessoas = dpn.dpn_n_limitePessoas.ToString(),
                        dpn_c_descricao = dpn.dpn_c_descricao,
                        dpn_c_tipoTermoUso = dpn.dpn_c_tipoTermoUso,
                        dpn_c_termosUso = dpn.dpn_c_termosUso,
                        dpn_ftd_n_codigo = dpn.dpn_ftd_n_codigo.ToString(),
                        dpn_ard_n_codigo = dpn.dpn_ard_n_codigo.ToString(),
                        dpn_cli_n_codigo = dpn.dpn_cli_n_codigo.ToString(),
                        dpn_nomeArquivo = ard.ard_c_nomePDFImagem
                    }).FirstOrDefault();
        }

        public IPagedList<DependenciaViewModel> GetFiltrado(DependenciaFilterModel filter)
        {
            try
            {
                List<DependenciaViewModel> lstDpn = new List<DependenciaViewModel>();

                var query = from dpn in Context.tb_dpn_dependencias
                            orderby dpn.dpn_b_ativoInativo == false, dpn.dpn_c_nome
                            select new DependenciaViewModel
                            {
                                dpn_n_codigo = dpn.dpn_n_codigo.ToString(),
                                dpn_cli_n_codigo = dpn.dpn_cli_n_codigo.ToString(),
                                dpn_c_nome = dpn.dpn_c_nome,
                                dpn_b_ativoInativo = dpn.dpn_b_ativoInativo.ToString(),
                                dpn_c_bloco = dpn.dpn_c_bloco,
                                dpn_n_limitePessoas = dpn.dpn_n_limitePessoas.ToString(),
                                dpn_c_periodoManha = dpn.dpn_c_periodoManha,
                                dpn_c_periodoTarde = dpn.dpn_c_periodoTarde,
                                dpn_c_periodoNoite = dpn.dpn_c_periodoNoite,
                                dpn_c_descricao = dpn.dpn_c_descricao,
                                dpn_c_tipoTermoUso = dpn.dpn_c_tipoTermoUso,
                                dpn_ftd_n_codigo = dpn.dpn_ftd_n_codigo.ToString(),
                                dpn_c_periodoPorHorario = dpn.dpn_c_periodoPorHorario,
                                dpn_n_reservaPeriodo = $"{(int)dpn.dpn_n_reservaPeriodo}"
                            };

                if (!string.IsNullOrEmpty(filter.dpn_cli_n_codigo_filter))
                {
                    query = query.Where(w => w.dpn_cli_n_codigo.Equals(filter.dpn_cli_n_codigo_filter));
                }
                if (!string.IsNullOrEmpty(filter.dpn_b_ativoInativo_filter))
                {
                    foreach (var item in query)
                    {
                        if (item.dpn_b_ativoInativo != "False")
                        {
                            lstDpn.Add(item);
                        }
                    }

                }
                else
                {
                    lstDpn = query.ToList();
                }
                //else
                //{
                //    query = query.Where(w => w.rel_cli_n_codigo == null);
                //}


                return lstDpn.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertOrUpdate(DependenciaViewModel model)
        {
            if (model == null)
                throw new MensagemException("Os dados são obrigatórios para salvar a Dependência.");

            int? codeCli = !string.IsNullOrEmpty(model.dpn_cli_n_codigo) && !model.dpn_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.dpn_cli_n_codigo) : new int?();
            int? codeFtd = !string.IsNullOrEmpty(model.dpn_ftd_n_codigo) && !model.dpn_ftd_n_codigo.Equals("0") ? Convert.ToInt32(model.dpn_ftd_n_codigo) : new int?();
            int? codeArd = !string.IsNullOrEmpty(model.dpn_ard_n_codigo) && !model.dpn_ard_n_codigo.Equals("0") ? Convert.ToInt32(model.dpn_ard_n_codigo) : new int?();
            int codeDpn = !string.IsNullOrEmpty(model.dpn_n_codigo) && !model.dpn_n_codigo.Equals("0") ? Convert.ToInt32(model.dpn_n_codigo) : new int();

            Enum.TryParse(model.dpn_n_reservaPeriodo, out EnumDependenciaPeriodo reservaPeriodo);

            if (model.tipoPeriodoAlterado)
            {
                var dataHoje = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
                var itens = context.tb_res_registroSalao.Where(x => x.res_dpn_n_codigo == codeDpn && x.res_d_dataSolicitacao > dataHoje)?.ToList();

                if (itens?.Count > 0)
                {
                    foreach (var item in itens)
                    {
                        context.Remove(item);
                    }
                }
            }

            if (codeDpn == 0)
            {
                Insert(new tb_dpn_dependencias()
                {
                    dpn_cli_n_codigo = codeCli,
                    dpn_c_nome = model.dpn_c_nome,
                    dpn_b_ativoInativo = Convert.ToBoolean(model.dpn_b_ativoInativo),
                    dpn_b_autoLiberar = Convert.ToBoolean(model.dpn_b_autoLiberar),
                    dpn_c_bloco = model.dpn_c_bloco,
                    dpn_n_reservaPeriodo = reservaPeriodo,
                    dpn_n_limitePessoas = !string.IsNullOrEmpty(model.dpn_n_limitePessoas) && !model.dpn_n_limitePessoas.Equals("0") ? Convert.ToInt32(model.dpn_n_limitePessoas) : new int?(),
                    dpn_c_periodoManha = model.dpn_c_periodoManha,
                    dpn_c_periodoTarde = model.dpn_c_periodoTarde,
                    dpn_c_periodoNoite = model.dpn_c_periodoNoite,
                    dpn_c_periodoPorHorario = model.dpn_c_periodoPorHorario,
                    dpn_c_descricao = model.dpn_c_descricao,
                    dpn_c_tipoTermoUso = model.dpn_c_tipoTermoUso,
                    dpn_c_termosUso = model.dpn_c_termosUso,
                    dpn_ftd_n_codigo = codeFtd,
                    dpn_ard_n_codigo = codeArd,

                    dpn_c_unique = Guid.NewGuid(),
                    dpn_d_atualizado = DateTime.Now,
                    dpn_d_inclusao = DateTime.Now,
                    dpn_d_modificacao = DateTime.Now,
                });
            }
            else
            {
                var dpn = context.tb_dpn_dependencias.Where(x => x.dpn_n_codigo == codeDpn)?.FirstOrDefault();

                if (dpn == null)
                    throw new MensagemException("Dependência não encontrada.");

                dpn.dpn_cli_n_codigo = codeCli;
                dpn.dpn_c_nome = model.dpn_c_nome;
                dpn.dpn_b_ativoInativo = !string.IsNullOrEmpty(model.dpn_b_ativoInativo) && !model.dpn_b_ativoInativo.Equals("0") ? Convert.ToBoolean(model.dpn_b_ativoInativo) : new bool?();
                dpn.dpn_b_autoLiberar = !string.IsNullOrEmpty(model.dpn_b_autoLiberar) && !model.dpn_b_autoLiberar.Equals("0") ? Convert.ToBoolean(model.dpn_b_autoLiberar) : new bool?();
                dpn.dpn_c_bloco = model.dpn_c_bloco;
                dpn.dpn_n_reservaPeriodo = reservaPeriodo;
                dpn.dpn_n_limitePessoas = !string.IsNullOrEmpty(model.dpn_n_limitePessoas) && !model.dpn_n_limitePessoas.Equals("0") ? Convert.ToInt32(model.dpn_n_limitePessoas) : new int?();
                dpn.dpn_c_periodoManha = model.dpn_c_periodoManha;
                dpn.dpn_c_periodoTarde = model.dpn_c_periodoTarde;
                dpn.dpn_c_periodoNoite = model.dpn_c_periodoNoite;
                dpn.dpn_c_periodoPorHorario = model.dpn_c_periodoPorHorario;
                dpn.dpn_c_descricao = model.dpn_c_descricao;
                dpn.dpn_c_tipoTermoUso = model.dpn_c_tipoTermoUso;
                dpn.dpn_c_termosUso = model.dpn_c_termosUso;
                dpn.dpn_ftd_n_codigo = codeFtd;
                dpn.dpn_ard_n_codigo = codeArd;

                dpn.dpn_d_atualizado = DateTime.Now;
                dpn.dpn_d_modificacao = DateTime.Now;

                Update(dpn);
            }

            context.SaveChanges();
        }

        public RetornoFotoViewModel GetFoto(int id)
        {
            var ret = new RetornoFotoViewModel();
            if (id != 0)
            {
                ret = (from ftd in context.tb_ftd_fotoDependencia
                       where ftd.ftd_n_codigo == id
                       select new RetornoFotoViewModel
                       {
                           Id = ftd.ftd_n_codigo,
                           Imagem = ftd.ftd_c_imagem
                       })?.FirstOrDefault();
            }

            return ret;
        }
    }
}
