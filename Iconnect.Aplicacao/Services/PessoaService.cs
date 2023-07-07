using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Iconnect.Aplicacao.Services
{
    class PessoaService : RepositoryBase<vw_pessoa>, IPessoaService
    {
        private readonly IconnectCoreContext context;

        public PessoaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<PessoaViewModel> GetPessoaFiltrado(PessoaFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.IdsClientes))
            {
                return new PagedList<PessoaViewModel>(null, 1, 1);
            }

            var pessoasQuery = ObterPessoasQueryFiltrado(filter);
            return pessoasQuery.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public List<GenericList> GetPessoasCombo(int idCliente, string usuarioLogado)
        {
            //Lista
            List<GenericList> lstFinal = new List<GenericList>();
            List<GenericList> auxLista = new List<GenericList>();


            //Item fixo
            GenericList operador = new GenericList();
            operador.text = "OPERADOR | " + usuarioLogado.ToUpper();
            operador.value = "0";
            var cli = (from cliente in context.tb_cli_cliente where cliente.cli_n_codigo == idCliente select cliente).FirstOrDefault();


            if (idCliente != 0 && cli.cli_b_free == false)
            {
                var query = (from pessoa in Context.vw_pessoa
                             where pessoa.CODCLIENTE.Value == idCliente
                             orderby pessoa.TIPO, pessoa.NOME
                             select new GenericList
                             {
                                 text = $"{(pessoa.TIPOCLIENTE.Equals(2) && pessoa.TIPO == "MORADOR" ? "FUNCIONÁRIO" : pessoa.TIPO)} | {pessoa.NOME}",
                                 value = pessoa.CODIGO.ToString(),
                             });

                lstFinal.Add(operador);
                auxLista = query.ToList();
            }
            else if (idCliente != 0 && cli.cli_b_free == true)
            {
                var query = (from pessoa in Context.vw_pessoa
                             where pessoa.CODCLIENTE.Value == idCliente && pessoa.ATIVO_INATIVO == true && pessoa.TIPO == "Morador"
                             orderby pessoa.TIPO, pessoa.NOME
                             select new GenericList
                             {
                                 text = $"{(pessoa.TIPOCLIENTE.Equals(2) && pessoa.TIPO == "MORADOR" ? "FUNCIONÁRIO" : pessoa.TIPO)} | {pessoa.NOME}",
                                 value = pessoa.CODIGO.ToString(),
                             });

                auxLista = query.ToList();
            }

            lstFinal.AddRange(auxLista);

            return lstFinal;
        }


        public List<GenericList> GetPessoasComboFiltro(int idCliente, string usuarioLogado, string pesquisa)
        {
            //Lista
            List<GenericList> lstFinal = new List<GenericList>();
            List<GenericList> auxLista = new List<GenericList>();


            //Item fixo
            GenericList operador = new GenericList();
            operador.text = "OPERADOR | " + usuarioLogado.ToUpper();
            operador.value = "0";
            lstFinal.Add(operador);


            if (idCliente != 0)
            {
                var query = (from pessoa in Context.vw_pessoa
                             where pessoa.CODCLIENTE.Value == idCliente && pessoa.ATIVO_INATIVO == true && pessoa.NOME.Contains(pesquisa)
                             orderby pessoa.TIPO, pessoa.NOME
                             select new GenericList
                             {
                                 text = $"{(pessoa.TIPOCLIENTE.Equals(2) && pessoa.TIPO == "MORADOR" ? "FUNCIONÁRIO" : pessoa.TIPO)} | {pessoa.NOME}",
                                 value = pessoa.CODIGO.ToString(),
                             });

                auxLista = query.ToList();
            }

            lstFinal.AddRange(auxLista);

            return lstFinal;
        }

        public List<GenericList> GetPessoasComboFiltrado(int idCliente, string tipo)
        {
            List<GenericList> auxLista = new List<GenericList>();

            if (idCliente != 0)
            {
                var query = (from pessoa in Context.vw_pessoa
                             where pessoa.CODCLIENTE.Value == idCliente && pessoa.ATIVO_INATIVO == true && pessoa.TIPO == tipo
                             orderby pessoa.TIPO, pessoa.NOME
                             select new GenericList
                             {
                                 text =
                                    pessoa.TIPOCLIENTE == 2 && pessoa.TIPO.ToUpper() == "MORADOR" ?
                                        $"FUNCIONÁRIO | {pessoa.NOME}" :
                                        $"{ tipo } | { pessoa.NOME }",
                                 value = pessoa.CODIGO.ToString(),
                             });

                auxLista = query.ToList();
            }

            return auxLista;
        }

        public byte[] GeraExcel(PessoaFilterModel filter)
        {
            var query = ObterPessoasQueryFiltrado(filter, true);

            //Ajuste tamanho textos
            var listaPessoa = query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            foreach (var pessoa in listaPessoa)
            {
                if (pessoa.TIPOCLIENTE == "2")
                {
                    pessoa.TIPO = "FUNCIONÁRIO";
                }
            }
            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Código",
                    "Cliente",
                    "Tipo",
                    "Nome",
                    "RG",
                    "CPF",
                    "E-mail",
                    "Telefone",
                    "Status",
                };

                var worksheet = package.Workbook.Worksheets.Add("Pessoas");
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
                    foreach (var pessoa in listaPessoa)
                    {
                        worksheet.Cells["A" + j].Value = pessoa.CODIGO;
                        worksheet.Cells["B" + j].Value = pessoa.cli_c_nomeFantasia;
                        worksheet.Cells["C" + j].Value = pessoa.TIPO;
                        worksheet.Cells["D" + j].Value = pessoa.NOME;
                        worksheet.Cells["E" + j].Value = pessoa.RG;
                        worksheet.Cells["F" + j].Value = pessoa.CPF;
                        worksheet.Cells["G" + j].Value = pessoa.EMAIL;
                        worksheet.Cells["H" + j].Value = pessoa.TELEFONE;
                        worksheet.Cells["I" + j].Value = pessoa.ativoInativo;
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

        public List<PessoaViewModel> GetRelPessoas(PessoaViewModel model)
        {
            int? idEmp = null;
            int? idCli = null;
            List<PessoaViewModel> query;
            if (model.CODIGOEMPRESA != null)
            {
                idEmp = Convert.ToInt32(model.CODIGOEMPRESA);
            }
            if (model.CODCLIENTE != null)
            {
                idCli = Convert.ToInt32(model.CODCLIENTE);
            }

            query = (from pes in context.vw_relatorio_pessoa
                     join emp in Context.tb_emp_empresa on pes.CODIGOEMPRESA equals emp.emp_n_codigo
                     join mor in context.tb_mor_Morador on pes.CODIGO equals mor.mor_n_codigo into tempMor
                     from mor in tempMor.DefaultIfEmpty()
                     join vec in context.tb_vec_veiculo on mor.mor_vec_n_codigo equals vec.vec_n_codigo into tempVec
                     from vec in tempVec.DefaultIfEmpty()
                     join vis in context.tb_vis_visitante on pes.CODIGO equals vis.vis_n_codigo into tempVis
                     from vis in tempVis.DefaultIfEmpty()
                     join pse in context.tb_pse_prestadorServico on pes.CODIGO equals pse.pse_n_codigo into tempPse
                     from pse in tempPse.DefaultIfEmpty()
                     join grf in Context.tb_grf_grupoFamiliar on pes.LOCALIZACAO equals grf.grf_n_codigo.ToString() into tempGrf
                     from grf in tempGrf.DefaultIfEmpty()
                     where pes.CODIGOEMPRESA == idEmp && pes.CODCLIENTE == idCli
                     select new PessoaViewModel()
                     {
                         NOME = pes.NOME,
                         cli_c_nomeFantasia = emp.tb_cli_cliente.FirstOrDefault(cliente => cliente.cli_n_codigo == Convert.ToInt32(model.CODCLIENTE)).cli_c_nomeFantasia,
                         emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                         TIPO = pes.TIPO,
                         RG = pes.RG,
                         TELEFONE = pes.TELEFONE,
                         PERFIL = pes.PERFIL,
                         LOCALIZACAO = grf.grf_n_codigo.ToString(),
                         LOCALIZACAONOME =
                            string.IsNullOrEmpty(grf.grf_c_nomeResponsavel) ? "" : grf.grf_c_nomeResponsavel.ToUpper(),
                         STATUS = pes.STATUS.ToString(),
                         vec_c_placa = pes.TIPO.ToUpper() == "MORADOR" || pes.TIPO.ToUpper() == "FUNCIONÁRIO" ? vec.vec_c_placa :
                         pes.TIPO.ToUpper() == "VISITANTE" ? vis.vis_c_placaVeiculo : 
                         pse.pse_c_placaVeiculo,
                     }).ToList();

            List<PessoaViewModel> query1 = (from pes in context.vw_relatorio_pessoa
                                            join emp in Context.tb_emp_empresa on pes.CODIGOEMPRESA equals emp.emp_n_codigo
                                            join grf in Context.tb_grf_grupoFamiliar on pes.LOCALIZACAO equals grf.grf_n_codigo.ToString() into tempGrf
                                            from grf in tempGrf.DefaultIfEmpty()
                                            where pes.CODIGOEMPRESA == idEmp && pes.CODCLIENTE == idCli && pes.LOCALIZACAO != null
                                            select new PessoaViewModel()
                                            {
                                                NOME = pes.NOME,
                                                cli_c_nomeFantasia = emp.tb_cli_cliente.FirstOrDefault(cliente => cliente.cli_n_codigo == Convert.ToInt32(model.CODCLIENTE)).cli_c_nomeFantasia,
                                                emp_c_nomeFantasia = emp.emp_c_nomeFantasia,
                                                TIPO = pes.TIPO,
                                                RG = pes.RG,
                                                TELEFONE = pes.TELEFONE,
                                                PERFIL = pes.PERFIL,
                                                LOCALIZACAO = grf.grf_n_codigo.ToString(),
                                                LOCALIZACAONOME =
                                                   string.IsNullOrEmpty(grf.grf_c_nomeResponsavel) ? "" : grf.grf_c_nomeResponsavel.ToUpper(),
                                                STATUS = pes.STATUS.ToString(),
                                            }).ToList();

            if (!string.IsNullOrEmpty(model.TIPO))
            {
                query = query.Where(x => x.TIPO.Contains(model.TIPO)).ToList();
            }

            if (!string.IsNullOrEmpty(model.PERFIL))
            {
                query = query.Where(x => x.PERFIL.Contains(model.PERFIL)).ToList();
                //if (query.Count > 0)
                //{
                //    query = query.Where(w => w.PERFIL.Split(',').Contains(model.PERFIL)).ToList();
                //}
            }

            if (!string.IsNullOrWhiteSpace(model.LOCALIZACAO))
            {
                query = query.Where(x => x.LOCALIZACAO.Contains(model.LOCALIZACAO)).ToList();
            }

            if (!string.IsNullOrEmpty(model.ativoInativo))
            {
                query = query.Where(w => w.STATUS == (model.ativoInativo == "0" ? "False" : "True")).ToList();
            }

            return query;
        }

        private IQueryable<PessoaViewModel> ObterPessoasQueryFiltrado(PessoaFilterModel filter, bool excel = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> sqlCodigos = new List<string>();
            var subQueryClientes = "";

            if (!string.IsNullOrEmpty(filter.IdsClientes) && (!filter?.IdsClientes?.Equals("todos") ?? false) && (!filter?.IdsClientes?.Equals("NULL") ?? false) && string.IsNullOrEmpty(filter.CODCLIENTE_filter))
            {
                var ids = filter.IdsClientes.Split(",");
                for (int i = 0; i < ids.Length; i++)
                {
                    sqlCodigos.Add(item: $@"@CODCLIENTE_filter{i}");
                    parameters.Add(new SqlParameter($"@CODCLIENTE_filter{i}", (object)ids[i] ?? DBNull.Value));

                    if (i == (ids.Length - 1))
                    {
                        subQueryClientes = $@"pessoa.CODCLIENTE IN({ string.Join(',', sqlCodigos)})";
                    }
                }
            }
            else
            {
                sqlCodigos.Add($"@CODCLIENTE_filter");
                parameters.Add(new SqlParameter($"@CODCLIENTE_filter", (object)filter.CODCLIENTE_filter ?? DBNull.Value));
                subQueryClientes = $"(@CODCLIENTE_filter IS NULL OR pessoa.CODCLIENTE = @CODCLIENTE_filter)";
            }

            string query = $@"SELECT
                            pessoa.cli_c_nomeFantasia AS cli_c_nomeFantasia,
                            pessoa.cli_c_nomeFantasia AS Cliente,
                            pessoa.CODIGO AS CODIGO,
                            NOME + RG + CPF AS buscaSimples,
                            pessoa.NOME AS NOME,
                            pessoa.RG AS RG,
                            pessoa.CPF AS CPF,
                            pessoa.DATA AS DATA,
                            pessoa.EMAIL AS EMAIL,
                            pessoa.TELEFONE AS TELEFONE,
                            pessoa.CELULAR AS CELULAR,
                            pessoa.ATIVO_INATIVO,
                            pessoa.RAMAL AS RAMAL,
                            CASE 
                            	WHEN pessoa.TIPO = 'MORADOR' and (pessoa.TIPOCLIENTE = 2 OR pessoa.TIPOCLIENTE = 3)
                            	THEN 'FUNCIONÁRIO'
                            	ELSE pessoa.TIPO
                            END AS TIPO,
                            pessoa.CODCLIENTE AS CODCLIENTE,
                            pessoa.CODIGOEMPRESA AS CODIGOEMPRESA,
                            pessoa.TIPOCLIENTE AS TIPOCLIENTE
                            FROM vw_pessoa pessoa
                            WHERE
                            (@buscaSimples_filter IS NULL OR pessoa.NOME LIKE '%' + @buscaSimples_filter + '%' COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI
                                OR REPLACE(REPLACE(RG, '-', ''), '.', '') LIKE '%' + @buscaSimples_filter + '%'
	                            OR REPLACE(REPLACE(CPF, '-', ''), '.', '') LIKE '%' + @buscaSimples_filter + '%') AND
                            ({subQueryClientes}) AND
                            (@NOME_filter IS NULL OR pessoa.NOME LIKE '%' + @NOME_filter + '%' COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI) AND
                            (@CELULAR_filter IS NULL OR REPLACE(REPLACE(REPLACE(REPLACE(pessoa.CELULAR, '(', ''), ')', ''), '-', ''), ' ', '') LIKE '%' + @CELULAR_filter + '%') AND
                            (@TELEFONE_filter IS NULL OR REPLACE(REPLACE(REPLACE(REPLACE(pessoa.TELEFONE, '(', ''), ')', ''), '-', ''), ' ', '') LIKE '%' + @TELEFONE_filter + '%') AND
                            (@RG_filter IS NULL OR REPLACE(REPLACE(RG, '-', ''), '.', '') LIKE '%' + @RG_filter + '%') AND
                            (@CPF_filter IS NULL OR REPLACE(REPLACE(CPF, '-', ''), '.', '') LIKE '%' + @CPF_filter + '%') AND
                            (@TIPO_filter IS NULL OR pessoa.TIPO = @TIPO_filter) AND
                            (@ATIVO_INATIVO_filter IS NULL OR pessoa.ATIVO_INATIVO = @ATIVO_INATIVO_filter) AND cli_b_ativo = 1";

            string cpfFilter = null, rgFilter = null, telefoneFilter = null, celularFilter = null;
            if (!string.IsNullOrEmpty(filter?.CPF_filter))
                cpfFilter = Regex.Replace(filter?.CPF_filter ?? "", "[^0-9,]", "");
            if (!string.IsNullOrEmpty(filter?.RG_filter))
                rgFilter = Regex.Replace(filter?.RG_filter ?? "", "[^0-9,]", "");
            if (!string.IsNullOrEmpty(filter?.TELEFONE_filter))
                telefoneFilter = Regex.Replace(filter?.TELEFONE_filter ?? "", "[^0-9,]", "");
            if (!string.IsNullOrEmpty(filter?.CELULAR_filter))
                celularFilter = Regex.Replace(filter?.CELULAR_filter ?? "", "[^0-9,]", "");

            parameters.Add(new SqlParameter("@buscaSimples_filter", (object)filter.buscaSimples_filter ?? DBNull.Value));
            parameters.Add(new SqlParameter("@NOME_filter", (object)filter.NOME_filter ?? DBNull.Value));
            parameters.Add(new SqlParameter("@TELEFONE_filter", (object)telefoneFilter ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RG_filter", (object)rgFilter ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CPF_filter", (object)cpfFilter ?? DBNull.Value));
            parameters.Add(new SqlParameter("@TIPO_filter", (object)filter.TIPO_filter ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CELULAR_filter", (object)celularFilter ?? DBNull.Value));

            if (string.IsNullOrEmpty(filter.ATIVO_INATIVO_filter))
            {
                parameters.Add(new SqlParameter("@ATIVO_INATIVO_filter", DBNull.Value));
            }
            else
            {
                parameters.Add(new SqlParameter("@ATIVO_INATIVO_filter", filter.ATIVO_INATIVO_filter == "ATIVO"));
            }

            // Order By foi inserido aqui porque a query sql não permite
            var pessoasQuery = context.vw_pessoa.FromSqlRaw(query, parameters.ToArray())
                 .OrderBy(pessoa => pessoa.ATIVO_INATIVO == false)
                 .ThenBy(pessoa => pessoa.NOME)
                 .Select(pessoa => new PessoaViewModel()
                 {
                     cli_c_nomeFantasia = pessoa.cli_c_nomeFantasia,
                     Cliente = pessoa.cli_c_nomeFantasia,
                     CODIGO = pessoa.CODIGO.ToString(),
                     NOME = pessoa.NOME,
                     RG = pessoa.RG,
                     CPF = pessoa.CPF,
                     DATA = pessoa.DATA.ToString(),
                     EMAIL = pessoa.EMAIL,
                     TELEFONE = pessoa.TELEFONE.Replace(" ", ""),
                     CELULAR = pessoa.CELULAR.Replace(" ", ""),
                     ativoInativo = pessoa.ATIVO_INATIVO ? "Ativo" : "Inativo",
                     RAMAL = pessoa.RAMAL,
                     TIPO = (pessoa.TIPOCLIENTE.ToString() == "2" || pessoa.TIPOCLIENTE.ToString() == "3") && pessoa.TIPO == "MORADOR" ? "FUNCIONÁRIO" : pessoa.TIPO,
                     CODCLIENTE = pessoa.CODCLIENTE.ToString(),
                     CODIGOEMPRESA = pessoa.CODIGOEMPRESA.ToString(),
                     TIPOCLIENTE = pessoa.TIPOCLIENTE.ToString(),
                 });

            return pessoasQuery;
        }
    }
}