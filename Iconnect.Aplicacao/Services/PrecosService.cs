using Iconnect.Aplicacao.FilterModel;
using System.Collections.Generic;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using System;
using OfficeOpenXml;
using System.Globalization;

namespace Iconnect.Aplicacao.Services
{
    public class PrecosService : RepositoryBase<tb_pre_precos>, IPrecosService
    {
        private IconnectCoreContext context;

        public PrecosService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IAcessoService _acessoService;
        public IAcessoService AcessoService
        {
            get
            {
                if (_acessoService == null)
                {
                    _acessoService = new AcessoService(context);
                }
                return _acessoService;
            }
        }


        public object Salvar(PrecosViewModel model)
        {
            Retorno retorno = new Retorno();
            tb_pre_precos precos;
            var cod = model.pre_n_codigo.Split(',');
            var preco = model.pre_n_precos.Split(',');
            var porcentDist = model.pre_n_porcentagensDist.Split(',');
            var porcentEmp = model.pre_n_porcentagensEmp.Split(',');
            var porcentCli = model.pre_n_porcentagensCli.Split(',');
            var modulo = model.pre_mol_c_nomes.Split(',');

            try
            {
                for (int i = 0; i < preco.Length; i++)
                {
                    if (string.IsNullOrEmpty(cod[i]))
                    {
                        //distribuidor
                        var precoDist = (Convert.ToDecimal(preco[i]) * Convert.ToInt32(porcentDist[i])) / 100;
                        precoDist = precoDist + Convert.ToDecimal(preco[i]);
                        //integrador
                        var precoEmp = (Convert.ToDecimal(preco[i]) * Convert.ToInt32(porcentEmp[i])) / 100;
                        precoEmp = precoEmp + Convert.ToDecimal(preco[i]);
                        //cliente
                        var precoCli = (Convert.ToDecimal(preco[i]) * Convert.ToInt32(porcentCli[i])) / 100;
                        precoCli = precoCli + Convert.ToDecimal(preco[i]);

                        precos = new tb_pre_precos()
                        {
                            pre_mol_c_nome = modulo[i],
                            pre_n_preco = Convert.ToDecimal(preco[i]),
                            pre_n_precoDist = precoDist,
                            pre_n_precoEmp = precoEmp,
                            pre_n_precoCli = precoCli,
                            pre_n_porcentDist = Convert.ToInt32(porcentDist[i]),
                            pre_n_porcentEmp = Convert.ToInt32(porcentEmp[i]),
                            pre_n_porcentCli = Convert.ToInt32(porcentCli[i]),
                        };

                        Insert(precos);
                        context.SaveChanges();

                    }
                    else
                    {
                        //distribuidor
                        var precoDist = (Convert.ToDecimal(preco[i]) * Convert.ToInt32(porcentDist[i])) / 100;
                        precoDist = precoDist + Convert.ToDecimal(preco[i]);
                        //integrador
                        var precoEmp = (precoDist * Convert.ToInt32(porcentEmp[i])) / 100;
                        precoEmp = precoEmp + precoDist;
                        //cliente
                        var precoCli = (precoEmp * Convert.ToInt32(porcentCli[i])) / 100;
                        precoCli = precoCli + precoEmp;

                        precos = (from pre in context.tb_pre_precos where pre.pre_n_codigo == Convert.ToInt32(cod[i]) select pre).FirstOrDefault();

                        precos.pre_n_preco = Convert.ToDecimal(preco[i]);
                        precos.pre_n_precoDist = precoDist;
                        precos.pre_n_precoEmp = precoEmp;
                        precos.pre_n_precoCli = precoCli;
                        precos.pre_n_porcentDist = Convert.ToInt32(porcentDist[i]);
                        precos.pre_n_porcentEmp = Convert.ToInt32(porcentEmp[i]);
                        precos.pre_n_porcentCli = Convert.ToInt32(porcentCli[i]);

                        Update(precos);
                        context.SaveChanges();
                    }
                }

                retorno.id = 0;
                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }

            catch (Exception e)
            {
                retorno.id = 0;
                retorno.status = e.ToString();
                retorno.conteudo = "false";
                return retorno;
            }
        }

        public PrecosViewModel[] GetPrecos()
        {
            var query = from pre in context.tb_pre_precos
                        select new PrecosViewModel()
                        {
                            pre_n_codigo = pre.pre_n_codigo.ToString(),
                            pre_mol_c_nomes = pre.pre_mol_c_nome,
                            pre_n_precos = pre.pre_n_preco.ToString(),
                            pre_n_precosDist = pre.pre_n_precoDist.ToString(),
                            pre_n_precosEmp = pre.pre_n_precoEmp.ToString(),
                            pre_n_precosCli = pre.pre_n_precoCli.ToString(),
                            pre_n_porcentagensDist = pre.pre_n_porcentDist.ToString(),
                            pre_n_porcentagensEmp = pre.pre_n_porcentEmp.ToString(),
                            pre_n_porcentagensCli = pre.pre_n_porcentCli.ToString(),
                        };

            return query.ToArray();
        }

        public byte[] GeraExcel(FaturamentoFilterModel filter)
        {
            //qtde de licenças
            int qtdeAccess = 0;
            int qtdeGuard = 0;
            int qtdeSolution = 0;
            //preço de acordo com perfil
            double precoAccess = 0;
            double precoGuard = 0;
            double precoSolution = 0;
            //valor total (distribuidor)
            double valorAccess = 0;
            double valorGuard = 0;
            double valorSolution = 0;

            var precos = (from pre in context.tb_pre_precos
                          select new PrecosViewModel()
                          {
                              pre_n_codigo = pre.pre_n_codigo.ToString(),
                              pre_mol_c_nomes = pre.pre_mol_c_nome,
                              pre_n_precosDist = pre.pre_n_porcentDist.ToString(),
                              pre_n_precosEmp = pre.pre_n_precoEmp.ToString(),
                              pre_n_precosCli = pre.pre_n_precoCli.ToString(),
                          });

            var clientes = (from cli in context.tb_cli_cliente
                            join mol in context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                            where cli.cli_b_ativo == true
                            select new ClienteViewModel()
                            {
                                cli_emp_n_codigo = cli.cli_emp_n_codigo.ToString(),
                                cli_n_codigo = cli.cli_n_codigo.ToString(),
                                cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                mol_b_controleDeAcesso = mol.mol_b_controleDeAcesso.ToString(),
                                mol_b_MonitoriamentoPerimetral = mol.mol_b_MonitoriamentoPerimetral.ToString(),
                                mol_b_connectSolutions = mol.mol_b_connectSolutions.ToString(),
                            });

            var empresas = (from emp in context.tb_emp_empresa
                            select new EmpresaViewModel()
                            {
                                emp_n_codigo = emp.emp_n_codigo.ToString(),
                                emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                                emp_dis_n_codigo = emp.emp_dis_n_codigo.ToString(),
                            });

            if (filter.perfil == "2" || filter.opcao == "integrador")
            {
                if (filter.perfil != "1")
                {
                    clientes = clientes.Where(w => w.cli_emp_n_codigo.Contains(filter.usuario));
                }

                if (!string.IsNullOrEmpty(filter.emp_n_codigo))
                {
                    var id = filter.emp_n_codigo.Split(",");
                    clientes = clientes.Where(w => id.Contains(w.cli_emp_n_codigo));
                }

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    var id = filter.cli_n_codigo.Split(",");
                    clientes = clientes.Where(w => id.Contains(w.cli_n_codigo));
                }

                foreach (var preco in precos)
                {
                    if (preco.pre_mol_c_nomes == "CONNECT ACCESS")
                    {
                        precoAccess = Convert.ToDouble(preco.pre_n_precosCli);
                    }

                    if (preco.pre_mol_c_nomes == "CONNECT GUARD")
                    {
                        precoGuard = Convert.ToDouble(preco.pre_n_precosCli);
                    }

                    if (preco.pre_mol_c_nomes == "CONNECT SOLUTION")
                    {
                        precoSolution = Convert.ToDouble(preco.pre_n_precosCli);
                    }
                }

                var listaClientes = clientes.ToList();
                using (var package = new ExcelPackage())
                {
                    var columHeaders = new string[]
                    {
                        "Nome",
                        "Connect Access",
                        "Valor",
                        "Connect Guard",
                        "Valor",
                        "Connect Solutions",
                        "Valor",
                        "Total",
                    };

                    var worksheet = package.Workbook.Worksheets.Add("cliente");
                    worksheet.DefaultColWidth = 20;
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
                        foreach (var cliente in listaClientes)
                        {
                            double total = 0;

                            if (Convert.ToBoolean(cliente.mol_b_controleDeAcesso) == true)
                            {
                                total = total + precoAccess;
                            }

                            if (Convert.ToBoolean(cliente.mol_b_MonitoriamentoPerimetral) == true)
                            {
                                total = total + precoGuard;
                            }

                            if (Convert.ToBoolean(cliente.mol_b_connectSolutions) == true)
                            {
                                total = total + precoSolution;
                            }

                            worksheet.Cells["A" + j].Value = cliente.cli_c_nomeFantasia;
                            worksheet.Cells["B" + j].Value = Convert.ToBoolean(cliente.mol_b_controleDeAcesso) ? "Sim" : "Não";
                            worksheet.Cells["C" + j].Value = precoAccess == 0 ? "R$ 0,00" : "R$ " + precoAccess.ToString(@"#\,##", CultureInfo.InvariantCulture);
                            worksheet.Cells["D" + j].Value = Convert.ToBoolean(cliente.mol_b_MonitoriamentoPerimetral) ? "Sim" : "Não";
                            worksheet.Cells["E" + j].Value = precoGuard == 0 ? "R$ 0,00" : "R$ " + precoGuard.ToString(@"#\,##", CultureInfo.InvariantCulture);
                            worksheet.Cells["F" + j].Value = Convert.ToBoolean(cliente.mol_b_connectSolutions) ? "Sim" : "Não";
                            worksheet.Cells["G" + j].Value = precoSolution == 0 ? "R$ 0,00" : "R$ " + precoSolution.ToString(@"#\,##", CultureInfo.InvariantCulture);
                            worksheet.Cells["H" + j].Value = total == 0 ? "R$ 0,00" : "R$ " + total.ToString(@"#\,##", CultureInfo.InvariantCulture);

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
            if (filter.perfil == "11" || filter.opcao == "distribuidor")
            {
                if (filter.perfil != "1")
                {
                    empresas = empresas.Where(w => w.emp_dis_n_codigo.Contains(filter.usuario));
                }

                if (!string.IsNullOrEmpty(filter.emp_n_codigo))
                {
                    var id = filter.emp_n_codigo.Split(",");
                    empresas = empresas.Where(w => id.Contains(w.emp_n_codigo));
                    clientes = clientes.Where(w => id.Contains(w.cli_emp_n_codigo));
                }

                foreach (var preco in precos)
                {
                    if (preco.pre_mol_c_nomes == "CONNECT ACCESS")
                    {
                        precoAccess = Convert.ToDouble(preco.pre_n_precosEmp);
                    }

                    if (preco.pre_mol_c_nomes == "CONNECT GUARD")
                    {
                        precoGuard = Convert.ToDouble(preco.pre_n_precosEmp);
                    }

                    if (preco.pre_mol_c_nomes == "CONNECT SOLUTION")
                    {
                        precoSolution = Convert.ToDouble(preco.pre_n_precosEmp);
                    }
                }

                var listaEmpresas = empresas.ToList();
                using (var package = new ExcelPackage())
                {
                    var columHeaders = new string[]
                    {
                        "Nome",
                        "Connect Access",
                        "Valor",
                        "Connect Guard",
                        "Valor",
                        "Connect Solutions",
                        "Valor",
                        "Total",
                    };

                    var worksheet = package.Workbook.Worksheets.Add("empresa");
                    worksheet.DefaultColWidth = 20;
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
                        foreach (var empresa in listaEmpresas)
                        {
                            double total = 0;
                            qtdeAccess = 0;
                            qtdeGuard = 0;
                            qtdeSolution = 0;
                            valorAccess = 0;
                            valorGuard = 0;
                            valorSolution = 0;

                            foreach (var cliente in clientes)
                            {
                                if (cliente.cli_emp_n_codigo == empresa.emp_n_codigo)
                                {
                                    if (cliente.mol_b_controleDeAcesso == "True")
                                    {
                                        qtdeAccess++;
                                    }

                                    if (cliente.mol_b_MonitoriamentoPerimetral == "True")
                                    {
                                        qtdeGuard++;
                                    }

                                    if (cliente.mol_b_connectSolutions == "True")
                                    {
                                        qtdeSolution++;
                                    }
                                }

                                valorAccess = qtdeAccess * precoAccess;
                                valorGuard = qtdeGuard * precoGuard;
                                valorSolution = qtdeSolution * precoSolution;

                                total = valorAccess + valorGuard + valorSolution;
                            }

                            worksheet.Cells["A" + j].Value = empresa.emp_c_nomeFantasia;
                            worksheet.Cells["B" + j].Value = qtdeAccess;
                            worksheet.Cells["C" + j].Value = valorAccess == 0 ? "R$ 0,00" : "R$ " + valorAccess.ToString(@"#\,##", CultureInfo.InvariantCulture);
                            worksheet.Cells["D" + j].Value = qtdeGuard;
                            worksheet.Cells["E" + j].Value = valorGuard == 0 ? "R$ 0,00" : "R$ " + valorGuard.ToString(@"#\,##", CultureInfo.InvariantCulture);
                            worksheet.Cells["F" + j].Value = qtdeSolution;
                            worksheet.Cells["G" + j].Value = valorSolution == 0 ? "R$ 0,00" : "R$ " + valorSolution.ToString(@"#\,##", CultureInfo.InvariantCulture);
                            worksheet.Cells["H" + j].Value = total == 0 ? "R$ 0,00" : "R$ " + total.ToString(@"#\,##", CultureInfo.InvariantCulture);

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

            return null;
        }
    }
}
