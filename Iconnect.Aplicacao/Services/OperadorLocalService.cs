using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class OperadorLocalService : RepositoryBase<tb_opl_operadorLocal>, IOperadorLocalService
    {
        private IconnectCoreContext context;

        public OperadorLocalService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarOperadorLocal(int id)
        {
            try
            {
                Delete(context.tb_opl_operadorLocal.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public int SalvarOperadorLocal(OperadorLocalViewModel model)
        {
            var tbResLoc = context.tb_rel_responsavelLocacaoSaloes.Where(x => x.rel_c_login == model.opl_c_login)?.FirstOrDefault();
            var tbAcesso = context.tb_ace_acesso.Where(x => x.ace_c_login == model.opl_c_login)?.FirstOrDefault();
            var tbOpLocal = context.tb_opl_operadorLocal.Where(x => x.opl_c_login == model.opl_c_login && x.opl_n_codigo != model.opl_n_codigo)?.FirstOrDefault();

            if (tbResLoc != null || tbAcesso != null || tbOpLocal != null)
                throw new MensagemException("O login digitado está em uso.");

            tb_opl_operadorLocal operadorLocal;
            if (model.opl_n_codigo == 0)
            {
                model.opl_c_senha = CriptografarSenha(model.opl_c_senha);
                Insert(operadorLocal = new tb_opl_operadorLocal()
                {
                    opl_c_nome = model.opl_c_nome,
                    opl_c_senha = model.opl_c_senha,
                    opl_c_login = model.opl_c_login,
                    opl_cli_n_codigo = Convert.ToInt32(model.opl_cli_n_codigo),
                    opl_gpp_n_codigo = Convert.ToInt32(model.opl_gpp_n_codigo),
                    opl_d_atualizado = DateTime.Now,
                    opl_c_unique = Guid.NewGuid(),
                    opl_d_inclusao = DateTime.Now,
                    opl_c_rg = model.opl_c_rg,
                    opl_c_cpf = model.opl_c_cpf,
                    opl_c_telefone = model.opl_c_telefone,
                    opl_c_email = model.opl_c_email
                });
            }
            else
            {
                operadorLocal = (from ope in context.tb_opl_operadorLocal where ope.opl_n_codigo == model.opl_n_codigo select ope).FirstOrDefault();
                if (model.opl_c_senha != null && !model.opl_c_senha.Equals(operadorLocal.opl_c_senha))
                {
                    operadorLocal.opl_c_senha = CriptografarSenha(model.opl_c_senha);
                }
                operadorLocal.opl_c_nome = model.opl_c_nome;
                operadorLocal.opl_c_login = model.opl_c_login;
                operadorLocal.opl_cli_n_codigo = Convert.ToInt32(model.opl_cli_n_codigo);
                operadorLocal.opl_gpp_n_codigo = Convert.ToInt32(model.opl_gpp_n_codigo);
                operadorLocal.opl_d_atualizado = DateTime.Now;
                operadorLocal.opl_c_rg = model.opl_c_rg;
                operadorLocal.opl_c_cpf = model.opl_c_cpf;
                operadorLocal.opl_c_telefone = model.opl_c_telefone;
                operadorLocal.opl_c_email = model.opl_c_email;

                Update(operadorLocal);
            }
            context.SaveChanges();

            return operadorLocal.opl_n_codigo;
        }

        public IPagedList<OperadorLocalViewModel> GetOperadorLocalFiltrado(OperadorLocalFilterModel filter)
        {
            var query = ObterQueryOperadorLocalFiltrados(filter);

            return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }


        private IQueryable<OperadorLocalViewModel> ObterQueryOperadorLocalFiltrados(OperadorLocalFilterModel filter, bool excel = false)
        {
            var query = (from ope in Context.tb_opl_operadorLocal
                         join cli in Context.tb_cli_cliente on ope.opl_cli_n_codigo equals cli.cli_n_codigo
                         join gpp in Context.tb_gpp_grupoPermissaoOperador on ope.opl_gpp_n_codigo equals gpp.gpp_n_codigo
                         orderby ope.opl_c_nome
                         select new OperadorLocalViewModel
                         {
                             opl_n_codigo = ope.opl_n_codigo,
                             opl_c_nome = ope.opl_c_nome,
                             Cliente = cli.cli_c_nomeFantasia,
                             Descricao = gpp.gpp_c_descricao,
                             opl_cli_n_codigo = cli.cli_n_codigo.ToString(),
                             buscaSimples = ope.opl_c_nome + " " + cli.cli_c_nomeFantasia
                         });

            if (!string.IsNullOrEmpty(filter.opl_cli_n_codigo) && (!filter?.opl_cli_n_codigo?.Equals("todos") ?? false))
            {
               query = query.Where(w => filter.opl_cli_n_codigo.Contains(w.opl_cli_n_codigo));
            }
            if (!string.IsNullOrEmpty(filter.idEmp) && (!filter?.idEmp?.Equals("todos") ?? false) && (!filter?.idEmp?.Equals("0") ?? false))
            {
                var idemp = Convert.ToInt32(filter.idEmp);
                List<string> idsCli = (from cli in Context.tb_cli_cliente where cli.cli_emp_n_codigo == idemp select cli.cli_n_codigo.ToString()).ToList();
                query = query.Where(w => idsCli.Contains(w.opl_cli_n_codigo));
            }
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }
            if (!string.IsNullOrEmpty(filter.opl_c_nome_filter))
            {
                query = query.Where(w => w.opl_c_nome.Contains(filter.opl_c_nome_filter));
            }
            if (!string.IsNullOrEmpty(filter.cliente_filter))
            {
                query = query.Where(w => w.Cliente.Contains(filter.cliente_filter));
            }
            if (!string.IsNullOrEmpty(filter.descricao_filter))
            {
                query = query.Where(w => w.Descricao.Contains(filter.descricao_filter));
            }

            return query;
        }

        public byte[] GeraExcel(OperadorLocalFilterModel filter)
        {
            var query = ObterQueryOperadorLocalFiltrados(filter, true);
            var lstOperador = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Nome",
                    "Cliente",
                    "Descrição",
                };

                var worksheet = package.Workbook.Worksheets.Add("Operador Local");
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
                        worksheet.Cells["A" + j].Value = operador.opl_n_codigo;
                        worksheet.Cells["B" + j].Value = operador.opl_c_nome;
                        worksheet.Cells["C" + j].Value = operador.Descricao;
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

        public OperadorLocalViewModel GetOperadorLocal(int id)
        {

            return (from ope in context.tb_opl_operadorLocal
                    where ope.opl_n_codigo == id
                    select new OperadorLocalViewModel()
                    {
                        opl_n_codigo = ope.opl_n_codigo,
                        opl_cli_n_codigo = ope.opl_cli_n_codigo.ToString(),
                        opl_gpp_n_codigo = ope.opl_gpp_n_codigo.ToString(),
                        opl_c_nome = ope.opl_c_nome,
                        opl_c_login = ope.opl_c_login,
                        opl_c_senha = ope.opl_c_senha,
                        opl_c_cpf = ope.opl_c_cpf,
                        opl_c_email = ope.opl_c_email,
                        opl_c_rg = ope.opl_c_rg,
                        opl_c_telefone = ope.opl_c_telefone,
                    }).FirstOrDefault();

        }

        public List<OperadorLocalViewModel> GetAll()
        {
            return null;
        }

        private string CriptografarSenha(string senha)
        {
            var enc = Encoding.GetEncoding(0);
            byte[] buffer = enc.GetBytes(senha);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");


            return hash;
        }

        public List<GenericList> GetOperadorLocalCliente(int id)
        {
            return (from opl in context.tb_opl_operadorLocal
                    where opl.opl_cli_n_codigo == id
                    select new GenericList()
                    {
                        value = opl.opl_n_codigo.ToString(),
                        text = opl.opl_c_nome,
                        grupo = "Operador Local",
                    }).ToList();
        }
    }
}
