using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
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

namespace Iconnect.Aplicacao.Services
{
    class AfastamentoService : RepositoryBase<tb_afa_afastamento>, IAfastamentoService
    {
        private IconnectCoreContext context;

        public AfastamentoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private ISincronizacaoPlacasService _sincronizacaoPlacas;
        public ISincronizacaoPlacasService SincronizacaoPlacas
        {
            get
            {
                if (_sincronizacaoPlacas == null)
                {
                    _sincronizacaoPlacas = new SincronizacaoPlacasService(context);
                }
                return _sincronizacaoPlacas;
            }
        }

        public object InsertOrUpdate(AfastamentoViewModel model)
        {
            try
            {
                bool sincronizar = false;
                bool expirado = false;


                DateTime inicio = Convert.ToDateTime(model.afa_d_inicio);
                DateTime fim = Convert.ToDateTime(model.afa_d_fim);

                if (inicio.Date <= DateTime.Now.Date)
                {
                    sincronizar = true;
                }

                if (fim.Date < DateTime.Now.Date)
                {
                    expirado = true;
                }
                int codeMor = 0;
                if (model.afa_mor_n_codigo != null && model.afa_mor_n_codigo != "")
                {
                    codeMor = Convert.ToInt32(model.afa_mor_n_codigo);
                }

                int codeAfa = Convert.ToInt32(model.afa_n_codigo);
                if (codeAfa == 0)
                {
                    var novoAfastamento = new tb_afa_afastamento()
                    {
                        afa_mor_n_codigo = codeMor,
                        afa_c_descricao = model.afa_c_descricao,
                        afa_d_inicio = Convert.ToDateTime(model.afa_d_inicio),
                        afa_d_fim = Convert.ToDateTime(model.afa_d_fim),
                        afa_c_unique = Guid.NewGuid(),
                        afa_d_atualizado = DateTime.Now,
                        afa_d_inclusao = DateTime.Now,
                        afa_d_modificacao = DateTime.Now,
                        afa_b_expirado = expirado,
                        afa_b_sincronizado = sincronizar
                    };


                    Insert(novoAfastamento);
                    context.SaveChanges();
                }
                else
                {
                    var Afastamento = (from a in context.tb_afa_afastamento where a.afa_n_codigo == codeAfa select a).FirstOrDefault();
                    Afastamento.afa_c_descricao = model.afa_c_descricao;
                    Afastamento.afa_d_inicio = Convert.ToDateTime(model.afa_d_inicio);
                    Afastamento.afa_d_fim = Convert.ToDateTime(model.afa_d_fim);
                    Afastamento.afa_d_atualizado = DateTime.Now;
                    Afastamento.afa_d_modificacao = DateTime.Now;
                    Afastamento.afa_b_expirado = expirado;
                    Afastamento.afa_b_sincronizado = sincronizar;


                    Update(Afastamento);
                    context.SaveChanges();
                }

                if (sincronizar == true && expirado == false)
                {
                    SincronizarPlaca(codeMor);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public object InsertOrUpdateByGrupo(AfastamentoViewModel model)
        {
            try
            {
                int codeGrupo = 0;
                if (model.codeGrupoFamiliar != null && model.codeGrupoFamiliar != "")
                {
                    codeGrupo = Convert.ToInt32(model.codeGrupoFamiliar);
                }

                List<tb_mor_Morador> LstMoradores = (from mor in Context.tb_mor_Morador where mor.mor_grf_n_codigo == codeGrupo select mor).ToList();

                foreach (var id in model.idsMoradores)
                {
                    model.afa_mor_n_codigo = id.ToString();
                    InsertOrUpdate(model);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public IPagedList<AfastamentoViewModel> GetFiltrado(AfastamentoFilterModel filter)
        {
            var query = (from a in Context.tb_afa_afastamento
                         join m in Context.tb_mor_Morador on a.afa_mor_n_codigo equals m.mor_n_codigo
                         where a.afa_b_expirado == false
                       
                         select new AfastamentoViewModel
                         {
                             afa_n_codigo = a.afa_n_codigo.ToString(),
                             afa_mor_n_codigo = a.afa_mor_n_codigo.ToString(),
                             afa_c_descricao = a.afa_c_descricao.ToString(),
                             afa_d_inicio = a.afa_d_inicio.ToString("dd/MM/yyyy"),
                             afa_d_fim = a.afa_d_fim.ToString("dd/MM/yyyy"),
                             codeGrupoFamiliar = m.mor_grf_n_codigo.ToString(),
                             nomeMorador = m.mor_c_nome

                         });

            if (!string.IsNullOrEmpty(filter.afa_mor_n_codigo_filter))
            {
                query = query.Where(w => w.afa_mor_n_codigo == filter.afa_mor_n_codigo_filter);
            }

            if (!string.IsNullOrEmpty(filter.codeGrupoFamiliar_filter))
            {
                query = query.Where(w => w.codeGrupoFamiliar == filter.codeGrupoFamiliar_filter);
            }

            return query.OrderBy(x => x.afa_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public bool Deletar(int id)
        {
            try
            {
                Delete(context.tb_afa_afastamento.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AfastamentoViewModel GetAfastamento(int id)
        {
            return (from afa in Context.tb_afa_afastamento
                    where afa.afa_n_codigo == id

                    select new AfastamentoViewModel
                    {
                        afa_n_codigo = afa.afa_n_codigo.ToString(),
                        afa_mor_n_codigo = afa.afa_mor_n_codigo.ToString(),
                        afa_c_descricao = afa.afa_c_descricao,
                        afa_d_inicio = afa.afa_d_inicio.ToString("yyyy-MM-dd"),
                        afa_d_fim = afa.afa_d_fim.ToString("yyyy-MM-dd"),
                    }).FirstOrDefault();
        }



        public List<AfastamentoViewModel> GetAfastamentoRel(AfastamentoViewModel model)
        {
            List<AfastamentoViewModel> query;
            DateTime dtInicial, dtFinal;
            if (((model.afa_d_inicio != null && model.afa_d_fim != null) && (model.afa_d_inicio != "" && model.afa_d_fim != "")))
            {
                dtInicial = Convert.ToDateTime(model.afa_d_inicio);
                dtFinal = Convert.ToDateTime(model.afa_d_fim);
                dtFinal = dtFinal.AddHours(23).AddMinutes(59);

                query = (from afa in context.tb_afa_afastamento
                         join mor in Context.tb_mor_Morador on afa.afa_mor_n_codigo equals mor.mor_n_codigo
                         join cli in Context.tb_cli_cliente on mor.mor_cli_n_codigo equals cli.cli_n_codigo
                         where cli.cli_n_codigo == model.cli_n_codigo && afa.afa_d_inicio >= dtInicial && afa.afa_d_fim <= dtFinal
                         select new AfastamentoViewModel()
                         {
                             nomeMorador = mor.mor_c_nome,
                             afa_c_descricao = afa.afa_c_descricao,
                             afa_mor_n_codigo = afa.afa_mor_n_codigo.ToString(),
                             afa_d_inicio = afa.afa_d_inicio.ToString("dd/MM/yyyy"),
                             afa_d_fim = afa.afa_d_fim.ToString("dd/MM/yyyy"),
                             nomeCliente = cli.cli_c_nomeFantasia,
                         }).ToList();

            }
            else {
                 query = (from afa in context.tb_afa_afastamento
                             join mor in Context.tb_mor_Morador on afa.afa_mor_n_codigo equals mor.mor_n_codigo
                             join cli in Context.tb_cli_cliente on mor.mor_cli_n_codigo equals cli.cli_n_codigo
                             where cli.cli_n_codigo == model.cli_n_codigo
                             select new AfastamentoViewModel()
                             {
                                 nomeMorador = mor.mor_c_nome,
                                 afa_c_descricao = afa.afa_c_descricao,
                                 afa_mor_n_codigo = afa.afa_mor_n_codigo.ToString(),
                                 afa_d_inicio = afa.afa_d_inicio.ToString("dd/MM/yyyy"),
                                 afa_d_fim = afa.afa_d_fim.ToString("dd/MM/yyyy"),
                                 nomeCliente = cli.cli_c_nomeFantasia,
                             }).ToList();

            }

            if (model.idsMoradores != null && model.idsMoradores.Length > 0)
            {
                query = query.Where(w => model.idsMoradores.Contains(w.afa_mor_n_codigo)).ToList();
            }
            
            if (model.tipos != null && model.tipos.Length > 0)
            {
                query = query.Where(w => model.tipos.Contains(w.afa_c_descricao)).ToList();
            }
            
            return query;
        }

        private void SincronizarPlaca(int codMor)
        {
            string controladoras = "";
            var tb_mor = (from mor in Context.tb_mor_Morador where mor.mor_n_codigo == codMor select mor).FirstOrDefault();
            var tb_cac = (from cac in Context.tb_cac_controleAcesso where cac.cac_mor_n_codigo == codMor select cac).ToList();
            List<tb_con_controladora> lstCon = (from con in Context.tb_con_controladora where con.con_cli_n_codigo == tb_mor.mor_cli_n_codigo && (con.con_c_modelo == "ZK" || con.con_c_modelo == "LINEAR HCS" || con.con_c_modelo == "CONTROL ID" || con.con_c_modelo == "CITROX") select con).ToList();

            foreach (var item in lstCon)
            {
                if (item.con_c_modelo != "CITROX")
                    controladoras += item.con_n_codigo.ToString() + ",";
            }

            foreach (var item in tb_cac)
            {
                SincronizacaoPlacas.SalvarSincronizacaoPlacasInterna(Convert.ToInt32(tb_mor.mor_cli_n_codigo), controladoras, item.cac_n_codigo);
            }
        }
    }
}
