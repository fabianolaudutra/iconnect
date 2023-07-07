using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class GrupoPermissaoOperadorService : RepositoryBase<tb_gpp_grupoPermissaoOperador>, IGrupoPermissaoOperadorService
    {
        private readonly IconnectCoreContext _context;

        public GrupoPermissaoOperadorService(IconnectCoreContext context) : base(context)
        {
            this._context = context;
        }

        private IPermissoesGrupoService _permissoesGrupo;
        public IPermissoesGrupoService PermissoesGrupo
        {
            get
            {
                if (_permissoesGrupo == null)
                {
                    _permissoesGrupo = new PermissoesGrupoService(_context);
                }
                return _permissoesGrupo;
            }
        }

        public List<GenericList> BuscaTipos()
        {

            List<GenericList> lista = (from top in Context.tb_top_tipoPermissaoOperador
                                       select new GenericList()
                                       {
                                           value = top.top_n_codigo.ToString(),
                                           text = top.top_c_descricao,

                                       }).ToList();
            return lista;
        }

        public List<GenericList> ListaTipos()
        {
            List<GenericList> lista = (from top in Context.tb_top_tipoPermissaoOperador
                                       select new GenericList()
                                       {
                                           value = top.top_n_codigo.ToString(),
                                           text = top.top_c_descricao,

                                       }).ToList();
            return lista;
        }

        public List<tb_gpp_grupoPermissaoOperador> ListarGrupoPermissaoOperador()
        {
            return (from g in Context.tb_gpp_grupoPermissaoOperador
                    select g
                    ).ToList();
        }

        public List<tb_gpp_grupoPermissaoOperador> ListarGrupoById(int id)
        {
            return (from g in Context.tb_gpp_grupoPermissaoOperador
                    where g.gpp_cli_n_codigo == id
                    select g).ToList();
        }

        public IPagedList<GrupoPermissaoOperadorViewModel> GetGrupoFiltrado(GrupoPermissaoOperadorFilterViewModel filter)
        {
            var query = ObterQueryGrupoFiltrados(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        private IQueryable<GrupoPermissaoOperadorViewModel> ObterQueryGrupoFiltrados(GrupoPermissaoOperadorFilterViewModel filter, bool excel = false)
        {
            try
            {
                var query = (from gpp in Context.tb_gpp_grupoPermissaoOperador
                             join emp in Context.tb_emp_empresa on gpp.gpp_emp_n_codigo equals emp.emp_n_codigo
                             join cli in Context.tb_cli_cliente on gpp.gpp_cli_n_codigo equals cli.cli_n_codigo
                             orderby gpp.gpp_c_descricao
                             select new GrupoPermissaoOperadorViewModel
                             {
                                 gpp_n_codigo = gpp.gpp_n_codigo.ToString(),
                                 gpp_emp_n_codigo = gpp.gpp_emp_n_codigo.ToString(),
                                 gpp_cli_n_codigo = gpp.gpp_cli_n_codigo.ToString(),
                                 gpp_c_usuario = gpp.gpp_c_usuario,
                                 gpp_c_descricao = gpp.gpp_c_descricao,
                                 gpp_mol_n_codigo = gpp.gpp_mol_n_codigo.ToString(),
                                 EmpresaDescricao = emp.emp_c_nomeFantasia,
                                 ClienteDescricao = cli.cli_c_nomeFantasia,
                                 buscaSimples = gpp.gpp_c_descricao + " "
                             });

                if (!string.IsNullOrEmpty(filter.idEmp) && (!filter?.idEmp?.Equals("todos") ?? false) && (!filter?.idEmp?.Equals("0") ?? false))
                {
                    var ids = filter.idEmp;
                    query = query.Where(w => ids.Contains(w.gpp_emp_n_codigo));
                }

                if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
                {
                    query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
                }

                int codCli = Convert.ToInt32(filter.gpp_cli_n_codigo_filter);
                if (codCli != 0)
                {
                    query = query.Where(w => w.gpp_cli_n_codigo.Equals(codCli.ToString()));
                }

                int codEmpresa = Convert.ToInt32(filter.gpp_emp_n_codigo_filter);
                if (codEmpresa != 0)
                {
                    query = query.Where(w => w.gpp_emp_n_codigo.Equals(codEmpresa.ToString()));
                }

                if (!string.IsNullOrEmpty(filter.gpp_c_descricao_filter))
                {
                    query = query.Where(w => w.gpp_c_descricao.Contains(filter.gpp_c_descricao_filter));
                }

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object InsertOrUpdate(GrupoPermissaoOperadorViewModel model, string UsuarioLogado)
        {
            Retorno retorno = new Retorno();
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                int? codCli = null;
                int? codMol = null;
                int? codEmp;
                int codGpp = 0;

                if (model.gpp_n_codigo != null && model.gpp_n_codigo != "")
                    codGpp = Convert.ToInt32(model.gpp_n_codigo);

                if (model.gpp_cli_n_codigo != null && model.gpp_cli_n_codigo != "")
                    codCli = Convert.ToInt32(model.gpp_cli_n_codigo);

                if (model.Modulo.mol_n_codigo != null && model.Modulo.mol_n_codigo != "")
                    codMol = Convert.ToInt32(model.Modulo.mol_n_codigo);

                codEmp = (from cli in _context.tb_cli_cliente where cli.cli_n_codigo == codCli select cli)?.FirstOrDefault()?.cli_emp_n_codigo;
                tb_gpp_grupoPermissaoOperador grupoPermissao;
                if (codGpp == 0)
                {
                    grupoPermissao = new tb_gpp_grupoPermissaoOperador()
                    {
                        gpp_cli_n_codigo = codCli,
                        gpp_emp_n_codigo = codEmp,
                        gpp_c_descricao = model.gpp_c_descricao,
                        gpp_c_usuario = UsuarioLogado.ToUpper(),
                        gpp_mol_n_codigo = codMol,
                        gpp_c_unique = Guid.NewGuid(),
                        gpp_d_alteracao = DateTime.Now,
                        gpp_d_atualizado = DateTime.Now,
                    };

                    Insert(grupoPermissao);
                    _context.SaveChanges();

                    model.gpp_n_codigo = grupoPermissao.gpp_n_codigo.ToString();
                }
                else
                {
                    grupoPermissao = (from gpp in _context.tb_gpp_grupoPermissaoOperador where gpp.gpp_n_codigo == codGpp select gpp).FirstOrDefault();
                    grupoPermissao.gpp_c_descricao = model.gpp_c_descricao;
                    grupoPermissao.gpp_cli_n_codigo = codCli;
                    grupoPermissao.gpp_emp_n_codigo = codEmp;
                    grupoPermissao.gpp_c_usuario = UsuarioLogado.ToUpper();
                    grupoPermissao.gpp_mol_n_codigo = codMol;
                    grupoPermissao.gpp_d_alteracao = DateTime.Now;
                    grupoPermissao.gpp_d_atualizado = DateTime.Now;

                    Update(grupoPermissao);
                }
                _context.SaveChanges();

                AdicionarPermissoes(model.Permissoes, Convert.ToInt32(model.gpp_n_codigo));

                retorno.id = grupoPermissao.gpp_n_codigo;
                retorno.status = "ok";
                retorno.conteudo = "true";

                transaction.Commit();

                return retorno;
            }
            catch (Exception)
            {
                transaction.Rollback();

                retorno.status = "ok";
                retorno.conteudo = "false";

                return retorno;
            }
        }

        public bool DeletarGrupo(int id)
        {
            try
            {
                var grupo = _context.tb_gpp_grupoPermissaoOperador.Where(x => x.gpp_n_codigo == id)?.FirstOrDefault();

                Delete(grupo);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GrupoPermissaoOperadorViewModel GetGrupo(int id)
        {
            return (from gpp in Context.tb_gpp_grupoPermissaoOperador
                    where gpp.gpp_n_codigo == id
                    select new GrupoPermissaoOperadorViewModel
                    {
                        gpp_n_codigo = gpp.gpp_n_codigo.ToString(),
                        gpp_emp_n_codigo = gpp.gpp_emp_n_codigo.ToString(),
                        gpp_cli_n_codigo = gpp.gpp_cli_n_codigo.ToString(),
                        gpp_c_usuario = gpp.gpp_c_usuario,
                        gpp_c_descricao = gpp.gpp_c_descricao,
                        gpp_mol_n_codigo = gpp.gpp_mol_n_codigo.ToString()
                    }).FirstOrDefault();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_gpp_grupoPermissaoOperador> lista = new List<tb_gpp_grupoPermissaoOperador>();


                lista = (from gpp in _context.tb_gpp_grupoPermissaoOperador where gpp.gpp_cli_n_codigo == null select gpp).OrderBy(x => x.gpp_n_codigo).ToList();


                foreach (var item in lista)
                {

                    DeletarGrupo(item.gpp_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = _context.tb_gpp_grupoPermissaoOperador.Where(x => x.gpp_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.gpp_cli_n_codigo = id;
                        Update(item);
                    }

                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PermissoesGrupoViewModel> BuscaPermissoes(int id)
        {
            var lista = (from pgp in Context.tb_pgp_permissoesGrupo
                         where pgp.pgp_gpp_n_codigo == id
                         select new PermissoesGrupoViewModel()
                         {
                             pgp_n_codigo = pgp.pgp_n_codigo.ToString(),
                             pgp_top_n_codigo = pgp.pgp_top_n_codigo.ToString(),
                             pgp_b_checado = pgp.pgp_b_checado.ToString(),
                         }).ToList();
            return lista;
        }

        public void AdicionarPermissoes(string permissoes, int codGpp)
        {
            foreach (var item in permissoes.Split('-'))
            {
                if (item == "") continue;

                var _item = item.Split('_');
                if (_item[1] == "1000") continue;

                PermissoesGrupoViewModel model = new PermissoesGrupoViewModel
                {
                    pgp_n_codigo = _item[0].ToString(),
                    pgp_top_n_codigo = _item[1].ToString(),
                    pgp_b_checado = _item[2].ToString(),
                    pgp_gpp_n_codigo = codGpp.ToString()
                };

                PermissoesGrupo.InsertOrUpdate(model);
            }
        }

        public byte[] GeraExcel(GrupoPermissaoOperadorFilterViewModel filter)
        {
            var query = ObterQueryGrupoFiltrados(filter, true);
            var lstOperador = query.ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Descrição",
                    "Cliente",
                    "Empresa",
                };

                var worksheet = package.Workbook.Worksheets.Add("Operador");
                using (var cells = worksheet.Cells[1, 1, 1, columHeaders.Count()])
                {
                    cells.Style.Font.Bold = true;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = columHeaders[i];
                }

                var j = 2;

                try
                {
                    foreach (var operador in lstOperador)
                    {
                        worksheet.Cells["A" + j].Value = operador.gpp_n_codigo;
                        worksheet.Cells["B" + j].Value = operador.gpp_c_descricao;
                        worksheet.Cells["C" + j].Value = operador.ClienteDescricao;
                        worksheet.Cells["D" + j].Value = operador.EmpresaDescricao;
                        j++;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].AutoFitColumns();
                }

                return package.GetAsByteArray();
            }
        }
    }
}
