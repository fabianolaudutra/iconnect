using Iconnect.Aplicacao.FilterModel;
using System.Collections.Generic;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using System;
using OfficeOpenXml;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;

namespace Iconnect.Aplicacao.Services
{
    class LicencasService : RepositoryBase<vw_licencas>, ILicencasService
    {
        private IconnectCoreContext context;

        public LicencasService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IEmailService _email;
        public IEmailService Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailService(context);
                }
                return _email;
            }
        }

        public IPagedList<ClienteViewModel> GetClientesFiltrado(ClienteFilterModel filter)
        {
            try
            {
                int codEmp = Convert.ToInt32(filter.cli_emp_n_codigo_filter);

                var query = (from cli in Context.tb_cli_cliente
                             join mol in Context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                             where cli.cli_emp_n_codigo == codEmp && cli.cli_d_inicioLicenca != null && cli.cli_d_dataVencimentoLicenca != null
                             orderby cli.cli_b_ativo == false, cli.cli_c_nomeFantasia
                             select new ClienteViewModel
                             {
                                 cli_n_codigo = cli.cli_n_codigo.ToString(),
                                 cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                 cli_b_ativo = (cli.cli_b_ativo == true ? "ATIVO" : "INATIVO"),
                                 cli_d_inicioLicenca = cli.cli_d_inicioLicenca.Value.ToString("dd/MM/yyyy"),
                                 cli_n_diaVencimento = cli.cli_n_diaVencimento.ToString(),
                                 cli_d_dataVencimentoLicenca = cli.cli_d_dataVencimentoLicenca.Value.ToString("dd/MM/yyyy"),
                                 cli_n_valorLicenca = cli.cli_n_valorLicenca.ToString(),
                                 mol_b_controleDeAcesso = (mol.mol_b_MonitoriamentoPerimetral != null ? ((mol.mol_b_MonitoriamentoPerimetral != null ? mol.mol_b_controleDeAcesso : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_MonitoriamentoPerimetral = (mol.mol_b_MonitoriamentoPerimetral ? "SIM" : "NÃO"),
                                 mol_b_CFTV = (mol.mol_b_CFTV != null ? ((mol.mol_b_CFTV != null ? mol.mol_b_CFTV : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_OrdemServico = (mol.mol_b_OrdemServico != null ? ((mol.mol_b_OrdemServico != null ? mol.mol_b_OrdemServico : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_connectSync = (mol.mol_b_connectSync != null ? ((mol.mol_b_connectSync != null ? mol.mol_b_connectSync : false) == true ? "SIM" : "NÃO") : ""),
                                 mol_b_accessView = (mol.mol_b_accessView != null ? ((mol.mol_b_accessView != null ? mol.mol_b_accessView : false) == true ? "SIM" : "NÃO") : ""),
                                 buscaSimples = cli.cli_c_nomeFantasia,
                                 data_fim = cli.cli_d_dataVencimentoLicenca,
                                 data_inicio = cli.cli_d_inicioLicenca,
                                 cli_b_free = cli.cli_b_free,
                             }); ;


                //int codEmp = Convert.ToInt32(filter.cli_emp_n_codigo_filter);
                //if (codEmp > 0)
                //{
                //    query = query.Where(w => w.cli_emp_n_codigo.Equals(codEmp.ToString()));
                //}
                if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
                {
                    query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

                }

                if (!string.IsNullOrEmpty(filter.cli_c_nomeFantasia_filter))
                {
                    query = query.Where(w => w.cli_c_nomeFantasia.Contains(filter.cli_c_nomeFantasia_filter));
                }
                if (!string.IsNullOrEmpty(filter.cli_b_ativo_filter))
                {
                    query = query.Where(w => w.cli_b_ativo.Contains(filter.cli_b_ativo_filter));
                }

                //if (!string.IsNullOrEmpty(filter.cli_d_inicioLicenca_filter))
                //{
                //    query = query.Where(w => w.cli_d_inicioLicenca.Contains(filter.cli_d_inicioLicenca_filter));
                //}

                //if (!string.IsNullOrEmpty(filter.cli_n_diaVencimento_filter))
                //{
                //    query = query.Where(w => w.cli_n_diaVencimento.Contains(filter.cli_n_diaVencimento_filter));
                //}

                if (!string.IsNullOrEmpty(filter.cli_d_inicioLicenca_filter))
                {
                    DateTime auxData;
                    if (DateTime.TryParse(filter.cli_d_inicioLicenca_filter, out auxData))
                    {
                        query = query.Where(w => w.data_inicio == auxData);
                    }
                }

                if (!string.IsNullOrEmpty(filter.cli_n_diaVencimento_filter))
                {
                    DateTime auxData;
                    if (DateTime.TryParse(filter.cli_n_diaVencimento_filter, out auxData))
                    {
                        query = query.Where(w => w.data_fim == auxData);
                    }
                }

                if (!string.IsNullOrEmpty(filter.cli_d_dataVencimentoLicenca_filter))
                {
                    query = query.Where(w => w.cli_d_dataVencimentoLicenca.Contains(filter.cli_d_dataVencimentoLicenca_filter));
                }

                if (!string.IsNullOrEmpty(filter.cli_n_valorLicenca_filter))
                {
                    query = query.Where(w => w.cli_n_valorLicenca.Contains(filter.cli_n_valorLicenca_filter));
                }

                if (!string.IsNullOrEmpty(filter.mol_b_controleDeAcesso_filter))
                {
                    query = query.Where(w => w.mol_b_controleDeAcesso.Contains(filter.mol_b_controleDeAcesso_filter));
                }
                if (!string.IsNullOrEmpty(filter.mol_b_MonitoriamentoPerimetral_filter))
                {
                    query = query.Where(w => w.mol_b_MonitoriamentoPerimetral.Contains(filter.mol_b_MonitoriamentoPerimetral_filter));
                }

                if (!string.IsNullOrEmpty(filter.mol_b_CFTVl_b_CFTV_filter))
                {
                    query = query.Where(w => w.mol_b_CFTV.Contains(filter.mol_b_CFTVl_b_CFTV_filter));
                }

                if (!string.IsNullOrEmpty(filter.mol_b_OrdemServico_filter))
                {
                    query = query.Where(w => w.mol_b_OrdemServico.Contains(filter.mol_b_OrdemServico_filter));
                }
                if (!string.IsNullOrEmpty(filter.mol_b_connectSync_filter))
                {
                    query = query.Where(w => w.mol_b_connectSync.Contains(filter.mol_b_connectSync_filter));
                }
                if (!string.IsNullOrEmpty(filter.mol_b_accessView_filter))
                {
                    query = query.Where(w => w.mol_b_accessView.Contains(filter.mol_b_accessView_filter));
                }

                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public byte[] GeraExcelCliente(ClienteFilterModel filter)
        {
            int codEmp = Convert.ToInt32(filter.cli_emp_n_codigo_filter);

            var query = (from cli in Context.tb_cli_cliente
                         join mol in Context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                         where cli.cli_emp_n_codigo == codEmp && cli.cli_d_inicioLicenca != null && cli.cli_d_dataVencimentoLicenca != null

                         select new ClienteViewModel
                         {
                             cli_n_codigo = cli.cli_n_codigo.ToString(),
                             cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                             cli_b_ativo = (cli.cli_b_ativo == true ? "ATIVO" : "INATIVO"),
                             cli_d_inicioLicenca = cli.cli_d_inicioLicenca.Value.ToString("dd/MM/yyyy"),
                             cli_n_diaVencimento = cli.cli_n_diaVencimento.ToString(),
                             cli_d_dataVencimentoLicenca = cli.cli_d_dataVencimentoLicenca.Value.ToString("dd/MM/yyyy"),
                             cli_n_valorLicenca = cli.cli_n_valorLicenca.ToString(),
                             mol_b_controleDeAcesso = (mol.mol_b_MonitoriamentoPerimetral != null ? ((mol.mol_b_MonitoriamentoPerimetral != null ? mol.mol_b_controleDeAcesso : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_MonitoriamentoPerimetral = (mol.mol_b_MonitoriamentoPerimetral ? "SIM" : "NÃO"),
                             mol_b_CFTV = (mol.mol_b_CFTV != null ? ((mol.mol_b_CFTV != null ? mol.mol_b_CFTV : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_OrdemServico = (mol.mol_b_OrdemServico != null ? ((mol.mol_b_OrdemServico != null ? mol.mol_b_OrdemServico : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_connectSync = (mol.mol_b_connectSync != null ? ((mol.mol_b_connectSync != null ? mol.mol_b_connectSync : false) == true ? "SIM" : "NÃO") : ""),
                             mol_b_accessView = (mol.mol_b_accessView != null ? ((mol.mol_b_accessView != null ? mol.mol_b_accessView : false) == true ? "SIM" : "NÃO") : ""),
                             buscaSimples = cli.cli_c_nomeFantasia,
                             data_fim = cli.cli_d_dataVencimentoLicenca,
                             data_inicio = cli.cli_d_inicioLicenca,

                         }); ;


            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.cli_c_nomeFantasia_filter))
            {
                query = query.Where(w => w.cli_c_nomeFantasia.Contains(filter.cli_c_nomeFantasia_filter));
            }
            if (!string.IsNullOrEmpty(filter.cli_b_ativo_filter))
            {
                query = query.Where(w => w.cli_b_ativo.Contains(filter.cli_b_ativo_filter));
            }

            if (!string.IsNullOrEmpty(filter.cli_d_inicioLicenca_filter))
            {
                DateTime auxData;
                if (DateTime.TryParse(filter.cli_d_inicioLicenca_filter, out auxData))
                {
                    query = query.Where(w => w.data_inicio == auxData);
                }
            }

            if (!string.IsNullOrEmpty(filter.cli_n_diaVencimento_filter))
            {
                DateTime auxData;
                if (DateTime.TryParse(filter.cli_n_diaVencimento_filter, out auxData))
                {
                    query = query.Where(w => w.data_fim == auxData);
                }
            }

            if (!string.IsNullOrEmpty(filter.cli_d_dataVencimentoLicenca_filter))
            {
                query = query.Where(w => w.cli_d_dataVencimentoLicenca.Contains(filter.cli_d_dataVencimentoLicenca_filter));
            }

            if (!string.IsNullOrEmpty(filter.cli_n_valorLicenca_filter))
            {
                query = query.Where(w => w.cli_n_valorLicenca.Contains(filter.cli_n_valorLicenca_filter));
            }

            if (!string.IsNullOrEmpty(filter.mol_b_controleDeAcesso_filter))
            {
                query = query.Where(w => w.mol_b_controleDeAcesso.Contains(filter.mol_b_controleDeAcesso_filter));
            }
            if (!string.IsNullOrEmpty(filter.mol_b_MonitoriamentoPerimetral_filter))
            {
                query = query.Where(w => w.mol_b_MonitoriamentoPerimetral.Contains(filter.mol_b_MonitoriamentoPerimetral_filter));
            }

            if (!string.IsNullOrEmpty(filter.mol_b_CFTVl_b_CFTV_filter))
            {
                query = query.Where(w => w.mol_b_CFTV.Contains(filter.mol_b_CFTVl_b_CFTV_filter));
            }

            if (!string.IsNullOrEmpty(filter.mol_b_OrdemServico_filter))
            {
                query = query.Where(w => w.mol_b_OrdemServico.Contains(filter.mol_b_OrdemServico_filter));
            }
            if (!string.IsNullOrEmpty(filter.mol_b_connectSync_filter))
            {
                query = query.Where(w => w.mol_b_connectSync.Contains(filter.mol_b_connectSync_filter));
            }
            if (!string.IsNullOrEmpty(filter.mol_b_accessView_filter))
            {
                query = query.Where(w => w.mol_b_accessView.Contains(filter.mol_b_accessView_filter));
            }

            var listaClientes = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Cliente",
                    "Status",
                    "Incio Licença",
                    "´Fim Licença",
                    "Dia Venc.",
                    "Valor R$",
                    "Connect Acces",
                    "'Connect Guard",
                    "Connect View",
                    "Connect Work",
                    "Connect Sinc",
                    "Acess View",
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
                    foreach (var cliente in listaClientes)
                    {
                        worksheet.Cells["A" + j].Value = cliente.cli_n_codigo;
                        worksheet.Cells["B" + j].Value = cliente.cli_c_nomeFantasia;
                        worksheet.Cells["C" + j].Value = cliente.cli_b_ativo;
                        worksheet.Cells["D" + j].Value = cliente.cli_d_inicioLicenca;
                        worksheet.Cells["E" + j].Value = cliente.cli_d_dataVencimentoLicenca;
                        worksheet.Cells["F" + j].Value = cliente.cli_n_diaVencimento;
                        worksheet.Cells["G" + j].Value = cliente.cli_n_valorLicenca;
                        worksheet.Cells["H" + j].Value = cliente.mol_b_controleDeAcesso;
                        worksheet.Cells["I" + j].Value = cliente.mol_b_MonitoriamentoPerimetral;
                        worksheet.Cells["J" + j].Value = cliente.mol_b_CFTV;
                        worksheet.Cells["K" + j].Value = cliente.mol_b_OrdemServico;
                        worksheet.Cells["L" + j].Value = cliente.mol_b_connectSync;
                        worksheet.Cells["M" + j].Value = cliente.mol_b_accessView;
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

        public IPagedList<EmpresaViewModel> GetEmpresasFiltrado(EmpresaFilterModel filter)
        {
            try
            {
                var query = (from emp in Context.vw_licencas
                             orderby emp.emp_c_nomeFantasia
                             select new EmpresaViewModel
                             {
                                 emp_n_codigo = emp.emp_n_codigo.ToString(),
                                 emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                                 QtdLicencas = emp.QtdLicencas.ToString(),
                                 ValorLicencas = emp.ValorLicencas.ToString(),
                                 ProxVenc = emp.ProxVenc != null ? emp.ProxVenc.Value.ToString("dd/MM/yyyy") : "",
                                 QtdAtivos = emp.QtdAtivos.ToString(),
                                 QtdInativos = emp.QtdInativos.ToString(),
                                 ControlAcess = emp.ControlAcess.ToString(),
                                 MonitPC = emp.MonitPC.ToString(),
                                 MonitCFTV = emp.MonitCFTV.ToString(),
                                 OS = emp.OS.ToString(),
                                 Sync = emp.Sync.ToString(),
                                 accessView = emp.accessView.ToString(),
                                 buscaSimples = emp.emp_c_nomeFantasia
                             });

                if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
                {
                    query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
                }

                if (!string.IsNullOrEmpty(filter.emp_n_codigo_filter))
                {
                    query = query.Where(w => w.emp_n_codigo.Contains(filter.emp_n_codigo_filter));
                }

                if (!string.IsNullOrEmpty(filter.QtdLicencas_filter))
                {
                    query = query.Where(w => w.QtdLicencas.Contains(filter.QtdLicencas_filter));
                }

                if (!string.IsNullOrEmpty(filter.ValorLicencas_filter))
                {
                    query = query.Where(w => w.ValorLicencas.Contains(filter.ValorLicencas_filter));
                }

                if (!string.IsNullOrEmpty(filter.ProxVenc_filter))
                {
                    query = query.Where(w => w.ProxVenc.Contains(filter.ProxVenc_filter));
                }

                if (!string.IsNullOrEmpty(filter.QtdAtivos_filter))
                {
                    query = query.Where(w => w.QtdAtivos.Contains(filter.QtdAtivos_filter));
                }

                if (!string.IsNullOrEmpty(filter.QtdInativos_filter))
                {
                    query = query.Where(w => w.QtdInativos.Contains(filter.QtdInativos_filter));
                }

                if (!string.IsNullOrEmpty(filter.ControlAcess_filter))
                {
                    query = query.Where(w => w.ControlAcess.Equals(filter.ControlAcess_filter.ToUpper()));
                }

                if (!string.IsNullOrEmpty(filter.MonitPC_filter))
                {
                    query = query.Where(w => w.MonitPC.Equals(filter.MonitPC_filter.ToUpper()));
                }
                if (!string.IsNullOrEmpty(filter.MonitCFTV_filter))
                {
                    query = query.Where(w => w.MonitCFTV.Equals(filter.MonitCFTV_filter.ToUpper()));
                }
                if (!string.IsNullOrEmpty(filter.OS_filter))
                {
                    query = query.Where(w => w.OS.Equals(filter.OS_filter.ToUpper()));
                }
                if (!string.IsNullOrEmpty(filter.Sync_filter))
                {
                    query = query.Where(w => w.Sync.Equals(filter.Sync_filter.ToUpper()));
                }
                if (!string.IsNullOrEmpty(filter.accessView_filter))
                {
                    query = query.Where(w => w.accessView.Equals(filter.accessView_filter.ToUpper()));
                }

                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public byte[] GeraExcel(EmpresaFilterModel filter)
        {
            var query = (from emp in Context.vw_licencas
                         select new EmpresaViewModel
                         {
                             emp_n_codigo = emp.emp_n_codigo.ToString(),
                             emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                             QtdLicencas = emp.QtdLicencas.ToString(),
                             ValorLicencas = emp.ValorLicencas.ToString(),
                             ProxVenc = emp.ProxVenc != null ? emp.ProxVenc.Value.ToString("dd/MM/yyyy") : "",
                             QtdAtivos = emp.QtdAtivos.ToString(),
                             QtdInativos = emp.QtdInativos.ToString(),
                             ControlAcess = emp.ControlAcess.ToString(),
                             MonitPC = emp.MonitPC.ToString(),
                             MonitCFTV = emp.MonitCFTV.ToString(),
                             OS = emp.OS.ToString(),
                             Sync = emp.Sync.ToString(),
                             accessView = emp.accessView.ToString(),
                             buscaSimples = emp.emp_c_nomeFantasia
                         });

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));

            }

            if (!string.IsNullOrEmpty(filter.emp_c_nomeFantasia_filter))
            {
                query = query.Where(w => w.emp_c_nomeFantasia.Contains(filter.emp_c_nomeFantasia_filter));
            }

            if (!string.IsNullOrEmpty(filter.QtdLicencas_filter))
            {
                query = query.Where(w => w.QtdLicencas.Contains(filter.QtdLicencas_filter));
            }

            if (!string.IsNullOrEmpty(filter.ValorLicencas_filter))
            {
                query = query.Where(w => w.ValorLicencas.Contains(filter.ValorLicencas_filter));
            }

            if (!string.IsNullOrEmpty(filter.ProxVenc_filter))
            {
                query = query.Where(w => w.ProxVenc.Contains(filter.ProxVenc_filter));
            }

            if (!string.IsNullOrEmpty(filter.QtdAtivos_filter))
            {
                query = query.Where(w => w.QtdAtivos.Contains(filter.QtdAtivos_filter));
            }

            if (!string.IsNullOrEmpty(filter.QtdInativos_filter))
            {
                query = query.Where(w => w.QtdInativos.Contains(filter.QtdInativos_filter));
            }

            if (!string.IsNullOrEmpty(filter.ControlAcess_filter))
            {
                query = query.Where(w => w.ControlAcess.Equals(filter.ControlAcess_filter.ToUpper()));
            }

            if (!string.IsNullOrEmpty(filter.MonitPC_filter))
            {
                query = query.Where(w => w.MonitPC.Equals(filter.MonitPC_filter.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.MonitCFTV_filter))
            {
                query = query.Where(w => w.MonitCFTV.Equals(filter.MonitCFTV_filter.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.OS_filter))
            {
                query = query.Where(w => w.OS.Equals(filter.OS_filter.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.Sync_filter))
            {
                query = query.Where(w => w.Sync.Equals(filter.Sync_filter.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.accessView_filter))
            {
                query = query.Where(w => w.accessView.Equals(filter.accessView_filter.ToUpper()));
            }

            var listaEmpresas = query.ToList();
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Empresa",
                    "Qtd. Licenças",
                    "Valor Licenças",
                    "Prox. Venc.",
                    "Qtd. Ativos",
                    "Qtd. Inativos",
                    "Connect Acess",
                    "'Connect Guard",
                    "Connect View",
                    "Connect Work",
                    "Connect Sinc",
                    "Acess View",
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
                    foreach (var empresa in listaEmpresas)
                    {
                        worksheet.Cells["A" + j].Value = empresa.emp_n_codigo;
                        worksheet.Cells["B" + j].Value = empresa.emp_c_nomeFantasia;
                        worksheet.Cells["C" + j].Value = empresa.QtdLicencas;
                        worksheet.Cells["D" + j].Value = empresa.ValorLicencas;
                        worksheet.Cells["E" + j].Value = empresa.ProxVenc;
                        worksheet.Cells["F" + j].Value = empresa.QtdAtivos;
                        worksheet.Cells["G" + j].Value = empresa.QtdInativos;
                        worksheet.Cells["H" + j].Value = empresa.ControlAcess;
                        worksheet.Cells["I" + j].Value = empresa.MonitPC;
                        worksheet.Cells["J" + j].Value = empresa.OS;
                        worksheet.Cells["K" + j].Value = empresa.MonitCFTV;
                        worksheet.Cells["L" + j].Value = empresa.Sync;
                        worksheet.Cells["M" + j].Value = empresa.accessView;
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

        public List<GenericList> ClientesSemLicenca(int idEmp)
        {
            List<GenericList> lista = (from cli in Context.tb_cli_cliente
                                       where cli.cli_emp_n_codigo == idEmp && cli.cli_d_inicioLicenca == null

                                       select new GenericList()
                                       {
                                           value = cli.cli_n_codigo.ToString(),
                                           text = cli.cli_c_nomeFantasia,

                                       }).ToList();
            return lista;
        }

        public List<GenericList> TodosClientesSemLicenca()
        {
            List<GenericList> lista = (from cli in Context.tb_cli_cliente
                                       where cli.cli_d_inicioLicenca == null && cli.cli_b_ativo == false

                                       select new GenericList()
                                       {
                                           value = cli.cli_n_codigo.ToString(),
                                           text = cli.cli_c_nomeFantasia,
                                       }).ToList();

            return lista;
        }

        public void MontaEmailNovoCliente()
        {
            List<EmailAgenteComercialViewModel> clientes = (from cli in context.tb_cli_cliente
                                                            join mol in context.tb_mol_modulosLiberados on cli.cli_mol_n_codigo equals mol.mol_n_codigo
                                                            where cli.cli_d_inicioLicenca == null && cli.cli_b_ativo == false
                                                            select new EmailAgenteComercialViewModel()
                                                            {
                                                                cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                                                cli_c_cnpj = cli.cli_c_cnpj,
                                                                cli_d_inclusao = cli.cli_d_inclusao.Value.ToString("dd/MM/yyyy"),
                                                                mol_b_controleDeAcesso = mol.mol_b_controleDeAcesso.ToString(),
                                                                mol_b_MonitoriamentoPerimetral = mol.mol_b_MonitoriamentoPerimetral.ToString(),
                                                                mol_b_connectSolutions = mol.mol_b_connectSolutions.ToString(),

                                                            }).ToList();

            if (clientes.Count != 0)
            {
                var assunto = "Novo Cliente Cadastrado";

                var email = (from age in context.tb_age_agenteComercial 
                                select age.age_c_email).ToList();

                var emails = "ramon@iconnectdobrasil.com.br,";
                for (var i = 0; i < email.Count; i++)
                {
                    emails = emails + email[i].ToString() + ",";
                }

                string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
                var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
                FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

                StreamReader reader = new StreamReader(fileStream);
                StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());
                StringBuilder mensagem = new StringBuilder($@"OLÁ, UM NOVO CADASTRO DE CLIENTE FOI REALIZADO NO PORTAL: 
                <br /> https://portaliconnect.com.br/ <br /> <br /> CLIENTE(S) PENDENTE(S): <br />");

                foreach (var cli in clientes)
                {
                    mensagem.AppendFormat("<br />{0}", $"Nome: {cli.cli_c_nomeFantasia}");
                    mensagem.AppendFormat("<br />{0}", $"CNPJ: {cli.cli_c_cnpj}");
                    mensagem.AppendFormat("<br />{0}", $"Data Cadastro: {cli.cli_d_inclusao}");
                    mensagem.AppendFormat("<br />{0}", $"Connect Access: {(cli.mol_b_controleDeAcesso == "True" ? "Sim" : "Não")}");
                    mensagem.AppendFormat("<br />{0}", $"Connect Guard: {(cli.mol_b_MonitoriamentoPerimetral == "True" ? "Sim" : "Não")}");
                    mensagem.AppendFormat("<br />{0}", $"Connect Solutions: {(cli.mol_b_connectSolutions == "True" ? "Sim" : "Não")}");
                    mensagem.AppendFormat("<br /> <br />");
                }

                CorpoEmail = CorpoEmail
                .Replace("{mensagem}", mensagem.ToString());

                fileStream.Close();

                EnviaEmail(assunto, emails, CorpoEmail);
            }
        }

        public void MontaEmailAlteracaoCliente(ClienteViewModel cliente)
        {
            var assunto = "Alteração Cliente Cadastrado";

            var email = (from age in context.tb_age_agenteComercial
                         select age.age_c_email).ToList();

            var emails = "ramon@iconnectdobrasil.com.br,";
            for (var i = 0; i < email.Count; i++)
            {
                emails = emails + email[i].ToString() + ",";
            }

            string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
            var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
            FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());
            StringBuilder mensagem = new StringBuilder($@"OLÁ, UMA ALTERAÇÃO NO CADASTRO DE CLIENTE FOI REALIZADA NO PORTAL: 
                <br /> https://portaliconnect.com.br/ <br /> <br /> CLIENTE ALTERADO: <br />");

            mensagem.AppendFormat("<br />{0}", $"Nome: {cliente.cli_c_nomeFantasia}");
            mensagem.AppendFormat("<br />{0}", $"CNPJ: {cliente.cli_c_cnpj}");
            mensagem.AppendFormat("<br />{0}", $"Data Atualização: {cliente.cli_d_atualizado}");
            mensagem.AppendFormat("<br />{0}", $"Connect Access: {(cliente.Modulo.mol_b_controleDeAcesso == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect Guard: {(cliente.Modulo.mol_b_MonitoriamentoPerimetral == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect Solutions: {(cliente.Modulo.mol_b_connectSolutions == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br /> <br />");

            CorpoEmail = CorpoEmail
            .Replace("{mensagem}", mensagem.ToString());

            fileStream.Close();

            EnviaEmail(assunto, emails, CorpoEmail);

        }

        public void MontaEmailAlteracaoModulos(ModuloViewModel modulos)
        {
            var assunto = "Alteração de Módulos Cadastrados";

            var cliente = (from _cliente in context.tb_cli_cliente where _cliente.cli_mol_n_codigo == Convert.ToInt32(modulos.mol_n_codigo) select _cliente).FirstOrDefault();

            var email = (from age in context.tb_age_agenteComercial
                         select age.age_c_email).ToList();

            var emails = "ramon@iconnectdobrasil.com.br,";
            
            for (var i = 0; i < email.Count; i++)
            {
                emails = emails + email[i].ToString() + ",";
            }

            string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
            var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
            FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());
            StringBuilder mensagem = new StringBuilder($@"OLÁ, UMA ALTERAÇÃO NOS MÓDULOS FOI REALIZADA NO PORTAL: 
                <br /> https://portaliconnect.com.br/ <br /> <br />  <br />");

            mensagem.AppendFormat("<br />{0}", $"Nome: {cliente.cli_c_nomeFantasia}");
            mensagem.AppendFormat("<br />{0}", $"CNPJ: {cliente.cli_c_cnpj}");
            mensagem.AppendFormat("<br />{0}", $"Data Atualização: {cliente.cli_d_atualizado}");
            // mensagem.AppendFormat("<br />{0}", $"Connect Guard: {(modulos.mol_b_CFTV == "True" ? "Sim" : "Não")}");
            // mensagem.AppendFormat("<br />{0}", $"Connect Guard: {(modulos.mol_b_OrdemServico == "True" ? "Sim" : "Não")}");
            // mensagem.AppendFormat("<br />{0}", $"Connect Guard: {(modulos.mol_b_connectPRO == "True" ? "Sim" : "Não")}");
            // mensagem.AppendFormat("<br />{0}", $"Connect Access: {(modulos.mol_b_portariaVirtual == "True" ? "Sim" : "Não")}");            
            mensagem.AppendFormat("<br />{0}", $"Connect Solutions: {(modulos.mol_b_connectSolutions == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect Access: {(modulos.mol_b_controleDeAcesso == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect Guard: {(modulos.mol_b_MonitoriamentoPerimetral == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect Sync: {(modulos.mol_b_connectSync == "True" ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect Garen: {(modulos.mol_b_connectGaren == true ? "Sim" : "Não")}");
            mensagem.AppendFormat("<br />{0}", $"Connect View Access: {(modulos.mol_b_accessView == "True" ? "Sim" : "Não")}");



            
            mensagem.AppendFormat("<br /> <br />");

            CorpoEmail = CorpoEmail
            .Replace("{mensagem}", mensagem.ToString());

            fileStream.Close();

            EnviaEmail(assunto, emails, CorpoEmail);

        }

        public void EnviaEmail(string assunto, string email, StringBuilder CorpoEmail)
        {
            //Envio de Email
            EmailViewModel modelEma = new EmailViewModel();
            modelEma.ema_b_enviado = false;
            modelEma.ema_c_assunto = assunto;
            modelEma.ema_c_corpo = CorpoEmail.ToString();
            modelEma.ema_c_destinatario = email;
            modelEma.ema_c_copiaOculta = "";
            modelEma.ema_d_data = DateTime.Now;
            modelEma.ema_b_enviado = false;
            modelEma.ema_d_modificacao = DateTime.Now;
            Email.InsertOrUpdate(modelEma);
        }

    }
}
