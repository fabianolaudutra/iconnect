using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace Iconnect.Aplicacao.Services
{
    public class DashboardService : IDashboardService
    {
        private IconnectCoreContext context;

        public DashboardService(IconnectCoreContext context)
        {
            this.context = context;
        }

        public DashboardViewModel RelAcessosPorPeriodo(DashboardFilterModel filter)
        {
            try
            {
                ProcessarFiltros(ref filter);

                DashboardViewModel retorno = new DashboardViewModel
                {
                    periodo = listaPeriodoPadrao(filter.periodo, filter.dtDe),
                    periodoAnterior = listaPeriodoPadrao(filter.periodo, filter.dtDeAnterior),

                    total = listaValorPadrao(filter.periodo),
                    totalAnterior = listaValorPadrao(filter.periodo)
                };

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_ACESSOS_POR_DIA]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            string auxDia = Convert.ToDateTime(dataReader["PERIODO"]).ToString("dd");
                            var i = retorno.periodo.FindIndex(x => x == auxDia);

                            retorno.total[i] = dataReader["TOTAL"].ToString();
                        }

                        context.Database.CloseConnection();
                    }
                }

                if (filter.processarPeriodoAnterior && !string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDeAnterior = new SqlParameter("@DT_DE", filter.dtDeAnterior);
                        SqlParameter dtAteAnterior = new SqlParameter("@DT_ATE", filter.dtAteAnterior);

                        command.CommandText = "[REL_ACESSOS_POR_DIA]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDeAnterior);
                        command.Parameters.Add(dtAteAnterior);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            string auxDia = Convert.ToDateTime(dataReader["PERIODO"]).ToString("dd");
                            var i = retorno.periodoAnterior.FindIndex(x => x == auxDia);

                            retorno.totalAnterior[i] = dataReader["TOTAL"].ToString();
                        }

                        context.Database.CloseConnection();
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelAcessosPorPessoa(DashboardFilterModel filter)
        {
            try
            {
                ProcessarFiltros(ref filter);

                DashboardViewModel retorno = new DashboardViewModel
                {
                    periodo = listaPeriodoPadrao(filter.periodo, filter.dtDe),
                    totalMorador = listaValorPadrao(filter.periodo),
                    totalFuncionario = listaValorPadrao(filter.periodo),
                    totalPrestador = listaValorPadrao(filter.periodo),
                    totalVisitante = listaValorPadrao(filter.periodo)
                };

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_ACESSOS_POR_PESSOA]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            string auxDia = Convert.ToDateTime(dataReader["PERIODO"]).ToString("dd");
                            var i = retorno.periodo.FindIndex(x => x == auxDia);

                            retorno.totalMorador[i] = dataReader["MORADOR"].ToString();
                            retorno.totalFuncionario[i] = dataReader["FUNCIONARIO"].ToString();
                            retorno.totalPrestador[i] = dataReader["PRESTADOR"].ToString();
                            retorno.totalVisitante[i] = dataReader["VISITANTE"].ToString();
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelAcessosPorCliente(DashboardFilterModel filter)
        {
            try
            {
                DashboardViewModel retorno = new DashboardViewModel
                {
                    nomeCliente = new List<string>(),
                    total = new List<string>()
                };

                ProcessarFiltros(ref filter);

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_ACESSOS_POR_CLIENTE]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            retorno.nomeCliente.Add(dataReader["CLI_C_NOMEFANTASIA"].ToString());
                            retorno.total.Add(dataReader["TOTAL"].ToString());
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelMonitoramentoPorDia(DashboardFilterModel filter)
        {
            try
            {
                ProcessarFiltros(ref filter);

                DashboardViewModel retorno = new DashboardViewModel
                {
                    periodo = listaPeriodoPadrao(filter.periodo, filter.dtDe),
                    periodoAnterior = listaPeriodoPadrao(filter.periodo, filter.dtDeAnterior),

                    total = listaValorPadrao(filter.periodo),
                    totalAnterior = listaValorPadrao(filter.periodo)
                };

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_MONITORAMENTO_POR_DIA]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            string auxDia = Convert.ToDateTime(dataReader["PERIODO"]).ToString("dd");

                            var i = retorno.periodo.FindIndex(x => x == auxDia);
                            retorno.total[i] = dataReader["TOTAL"].ToString();
                        }

                        context.Database.CloseConnection();
                    }
                }

                if (!string.IsNullOrEmpty(filter.cli_n_codigo) && filter.processarPeriodoAnterior)
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDeAnterior = new SqlParameter("@DT_DE", filter.dtDeAnterior);
                        SqlParameter dtAteAnterior = new SqlParameter("@DT_ATE", filter.dtAteAnterior);

                        command.CommandText = "[REL_MONITORAMENTO_POR_DIA]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDeAnterior);
                        command.Parameters.Add(dtAteAnterior);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            string auxDia = dataReader["PERIODO"].ToString().Remove(2);
                            var i = retorno.periodoAnterior.FindIndex(x => x == auxDia);

                            retorno.totalAnterior[i] = dataReader["TOTAL"].ToString();
                        }

                        context.Database.CloseConnection();
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelMonitoramentoTempoMedioAtendimento(DashboardFilterModel filter)
        {
            try
            {
                ProcessarFiltros(ref filter);

                DashboardViewModel retorno = new DashboardViewModel
                {
                    periodo = listaPeriodoPadrao(filter.periodo, filter.dtDe),
                    periodoAnterior = listaPeriodoPadrao(filter.periodo, filter.dtDeAnterior),

                    total = listaValorPadrao(filter.periodo),
                    totalAnterior = listaValorPadrao(filter.periodo)
                };

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_MONITORAMENTO_TEMPO_MEDIO_ATENDIOMENTO]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            string auxDia = Convert.ToDateTime(dataReader["PERIODO"]).ToString("dd");

                            var i = retorno.periodo.FindIndex(x => x == auxDia);
                            retorno.total[i] = dataReader["TOTAL"].ToString(); //Tempo médio em minutos
                        }

                        context.Database.CloseConnection();
                    }
                }

                if (filter.processarPeriodoAnterior && !string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDeAnterior = new SqlParameter("@DT_DE", filter.dtDeAnterior);
                        SqlParameter dtAteAnterior = new SqlParameter("@DT_ATE", filter.dtAteAnterior);

                        command.CommandText = "[REL_MONITORAMENTO_TEMPO_MEDIO_ATENDIOMENTO]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDeAnterior);
                        command.Parameters.Add(dtAteAnterior);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            string auxDia = Convert.ToDateTime(dataReader["PERIODO"]).ToString("dd");

                            var i = retorno.periodoAnterior.FindIndex(x => x == auxDia);
                            retorno.totalAnterior[i] = dataReader["TOTAL"].ToString(); //Tempo médio em minutos
                        }

                        context.Database.CloseConnection();
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelMonitoramentoTempoMedioCliente(DashboardFilterModel filter)
        {
            try
            {
                DashboardViewModel retorno = new DashboardViewModel
                {
                    nomeCliente = new List<string>(),
                    total = new List<string>()
                };

                ProcessarFiltros(ref filter);

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_MONITORAMENTO_TEMPO_MEDIO_CLIENTE]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            retorno.nomeCliente.Add(dataReader["CLI_C_NOMEFANTASIA"].ToString());
                            retorno.total.Add(dataReader["TOTAL"].ToString());
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelMonitoramentoPorCategoria(DashboardFilterModel filter)
        {
            try
            {
                DashboardViewModel retorno = new DashboardViewModel
                {
                    nomeCategoria = new List<string>(),
                    total = new List<string>()
                };

                ProcessarFiltros(ref filter);

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_MONITORAMENTO_POR_CATEGORIA]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);
                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();

                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            retorno.nomeCategoria.Add(dataReader["CEV_C_DESCRICAO"].ToString());
                            retorno.total.Add(dataReader["TOTAL"].ToString());
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DashboardViewModel RelTotalizadores(DashboardFilterModel filter)
        {
            try
            {
                DashboardViewModel retorno = new DashboardViewModel
                {
                    nomeCategoria = new List<string>(),
                    total = new List<string>()
                };

                ProcessarFiltros(ref filter);

                if (!string.IsNullOrEmpty(filter.cli_n_codigo))
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGOS", filter.cli_n_codigo);
                        SqlParameter dtDe = new SqlParameter("@DT_DE", filter.dtDe);
                        SqlParameter dtAte = new SqlParameter("@DT_ATE", filter.dtAte);

                        command.CommandText = "[REL_TOTALIZADORES]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(cli_n_codigo);
                        command.Parameters.Add(dtDe);

                        command.Parameters.Add(dtAte);

                        context.Database.OpenConnection();
                        
                        var dataReader = command.ExecuteReader();
                       
                        while (dataReader.Read())
                        {
                            switch (dataReader["DESCRICAO"].ToString())
                            {
                                case "ACESSOS":
                                    retorno.countlAcessos = dataReader["TOTAL"].ToString();
                                    break;

                                case "EVENTOS":
                                    retorno.countlEventos = dataReader["TOTAL"].ToString();
                                    break;

                                case "MORADOR":
                                    retorno.countlMorador = dataReader["TOTAL"].ToString();
                                    break;

                                case "FUNCIONÁRIO":
                                    retorno.countlFuncionario = dataReader["TOTAL"].ToString();
                                    break;

                                case "PRESTADOR":
                                    retorno.countlPrestador = dataReader["TOTAL"].ToString();
                                    break;

                                case "VISITANTE":
                                    retorno.countlVisitante = dataReader["TOTAL"].ToString();
                                    break;
                            }
                        }
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<string> listaPeriodoPadrao(string periodo, DateTime data)
        {
            List<string> lista = new List<string>();

            try
            {
                int diasPeriodo = Convert.ToInt32(periodo);

                for (int i = 0; i < diasPeriodo; i++)
                {
                    DateTime auxDia = data.AddDays(i);
                    lista.Add(auxDia.ToString("dd"));
                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }

        private List<string> listaValorPadrao(string periodo)
        {
            List<string> lista = new List<string>();

            try
            {
                int diasPeriodo = Convert.ToInt32(periodo);

                for (int i = 0; i < diasPeriodo; i++)
                {
                    lista.Add("0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        private void ProcessarFiltros(ref DashboardFilterModel filter)
        {
            try
            {
                if (filter.processarPeriodoAnterior)
                {
                    //Filtro Periodo
                    filter.dtAte = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    switch (filter.periodo)
                    {
                        case "7": //ÚLTIMOS 7 DIAS
                            filter.dtDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-6);
                            filter.dtAteAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-6);
                            filter.dtDeAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-12);
                            break;

                        case "15": //ÚLTIMOS 15 DIAS
                            filter.dtDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-14);
                            filter.dtAteAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-14);
                            filter.dtDeAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-28);

                            break;

                        case "30": //ÚLTIMOS 30 DIAS
                            filter.dtDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-29);
                            filter.dtAteAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-29);
                            filter.dtDeAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-58);

                            break;
                    }
                }

                //Filtro Periodo
                filter.dtAte = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                switch (filter.periodo)
                {
                    case "7": //ÚLTIMOS 7 DIAS
                        filter.dtDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-6);
                        break;

                    case "15": //ÚLTIMOS 15 DIAS
                        filter.dtDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-14);
                        break;

                    case "30": //ÚLTIMOS 30 DIAS
                        filter.dtDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-29);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}