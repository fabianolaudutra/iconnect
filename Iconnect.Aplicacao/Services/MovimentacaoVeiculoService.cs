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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Iconnect.Infraestrutura.Interfaces;
using OfficeOpenXml;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Iconnect.Aplicacao.Services
{
    class MovimentacaoVeiculoService : RepositoryBase<tb_mve_movimentacaoVeiculo>, IMovimentacaoVeiculoService
    {
        private IconnectCoreContext context;

        public MovimentacaoVeiculoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarMovimentacao(int id)
        {
            try
            {
                Delete(context.tb_mve_movimentacaoVeiculo.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false; throw new NotImplementedException();
        }

        public object GetUltimaMovimentacao(int id)
        {
            Retorno retorno = new Retorno();

            try
            {
                var mov = (from mve in context.tb_mve_movimentacaoVeiculo
                           where mve.mve_fro_n_codigo == id
                           select mve).OrderByDescending(x => x.mve_n_codigo).FirstOrDefault();

                retorno.status = "ok";
                retorno.conteudo = mov.mve_n_quilometragem.ToString();

                return retorno;
            }
            catch (Exception)
            {
                retorno.status = "error";
                retorno.conteudo = "0";
                return retorno;
                throw;
            }

        }

        public IPagedList<MovimentacaoVeiculoViewModel> GetMovimentacaoFiltrado(MovimentacaoVeiculoFilterModel filter)
        {
            List<MovimentacaoVeiculoViewModel> Lista = new List<MovimentacaoVeiculoViewModel>();
            var query = (from mve in Context.tb_mve_movimentacaoVeiculo
                         join mor in Context.tb_mor_Morador on mve.mve_mor_n_codigo equals mor.mor_n_codigo
                         join fro in Context.tb_fro_frota on mve.mve_fro_n_codigo equals fro.fro_n_codigo
                         join mav in Context.tb_mav_marcaVeiculo on fro.fro_mav_n_codigo equals mav.mav_n_codigo

                         select new MovimentacaoVeiculoViewModel
                         {
                             mve_n_codigo = mve.mve_n_codigo.ToString(),
                             mve_c_fluxo = mve.mve_c_fluxo,
                             mve_c_usuarioLogado = mve.mve_c_usuarioLogado,
                             mve_n_quilometragem = mve.mve_n_quilometragem.ToString(),
                             mve_fro_n_codigo = mve.mve_fro_n_codigo.ToString(),
                             mve_mor_n_codigo = mve.mve_mor_n_codigo.ToString(),
                             Morador = mor.mor_c_nome,
                             Fluxo = mve.mve_c_fluxo == "E" ? "Entrada" : "Saída",
                             Editavel = "false"
                         });

            query = query.Where(w => w.mve_fro_n_codigo == filter.mve_fro_n_codigo_filter);

            Lista = query.ToList();
            Lista = Lista.OrderByDescending(x => x.mve_n_codigo).ToList();

           
            if (Lista.Count != 0)
            {
                Lista[0].Editavel = "true";
            }

            return Lista.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public object SalvarMovimentacao(MovimentacaoVeiculoViewModel model, string usuarioLogado)
        {
            
            Retorno retorno = new Retorno();

            try
            {
                int codMve = 0;
                int codFro = Convert.ToInt32(model.mve_fro_n_codigo);
                int codMor = Convert.ToInt32(model.mve_mor_n_codigo);
                int quilometragem = Convert.ToInt32(model.mve_n_quilometragem);



                if (model.mve_n_codigo != "0" && model.mve_n_codigo != "0")
                {
                    codMve = Convert.ToInt32(model.mve_n_codigo);
                }

                if (codMve == 0)
                {
                    string retornoValidacao = VerificaUltimo(codFro, codMor, model.mve_c_fluxo, quilometragem);
                    if (retornoValidacao == "valorMenor")
                    {
                        retorno.status = "invalido";
                        retorno.conteudo = retornoValidacao;
                        return retorno;
                    }

                  
                    Insert(new tb_mve_movimentacaoVeiculo()
                    {
                        mve_fro_n_codigo = codFro,
                        mve_mor_n_codigo = codMor,
                        mve_c_fluxo = model.mve_c_fluxo,
                        mve_n_quilometragem = quilometragem,
                        mve_c_usuarioLogado = usuarioLogado,
                        mve_d_dataRegistro = DateTime.Now,
                        mve_d_modificacao = DateTime.Now,
                        mve_c_unique = new Guid(),
                        mve_d_atualizado = DateTime.Now,
                        mve_d_inclusao = DateTime.Now
                    }); 
                }
                else
                {
                    var Movimentacao = (from mve in context.tb_mve_movimentacaoVeiculo where mve.mve_n_codigo == codMve select mve).FirstOrDefault();
                    Movimentacao.mve_mor_n_codigo = codMor;
                    Movimentacao.mve_c_fluxo = model.mve_c_fluxo;
                    Movimentacao.mve_n_quilometragem = quilometragem;
                    Movimentacao.mve_c_usuarioLogado = usuarioLogado;
                    Movimentacao.mve_d_dataRegistro = DateTime.Now;
                    Movimentacao.mve_d_modificacao = DateTime.Now;
                    Movimentacao.mve_d_atualizado = DateTime.Now;
                    Movimentacao.mve_d_inclusao = DateTime.Now;

                    Update(Movimentacao);
                }

                context.SaveChanges();

                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = "error";
                retorno.conteudo = "false";
                return retorno;
            }

        }

        public string VerificaUltimo(int codFro, int codMor, string fluxo, int quilometragem)
        {
            var movimentacaoVeiculo = (from mve in context.tb_mve_movimentacaoVeiculo where mve.mve_fro_n_codigo == codFro select mve).OrderByDescending(x => x.mve_n_codigo).FirstOrDefault();
            string retorno = "true";
            if (movimentacaoVeiculo != null)
            {
                if (movimentacaoVeiculo.mve_n_quilometragem > quilometragem)
                {
                    retorno = "valorMenor";
                    return retorno;
                }

                if (movimentacaoVeiculo.mve_c_fluxo == "S" && fluxo == "S")
                {
                    Insert(new tb_mve_movimentacaoVeiculo()
                    {
                        mve_fro_n_codigo = codFro,
                        mve_mor_n_codigo = movimentacaoVeiculo.mve_mor_n_codigo,
                        mve_c_fluxo = "E",
                        mve_n_quilometragem = quilometragem,
                        mve_b_registroAutomatico = true,
                        mve_c_usuarioLogado = "GERADO PELO SISTEMA",
                        mve_d_dataRegistro = DateTime.Now,
                        mve_d_modificacao = DateTime.Now,
                        mve_c_unique = new Guid(),
                        mve_d_atualizado = DateTime.Now,
                        mve_d_inclusao = DateTime.Now
                    });
                }
                else if (movimentacaoVeiculo.mve_c_fluxo == "E" && fluxo == "E")
                {
                    Insert(new tb_mve_movimentacaoVeiculo()
                    {
                        mve_fro_n_codigo = codFro,
                        mve_mor_n_codigo = codMor,
                        mve_c_fluxo = "S",
                        mve_n_quilometragem = movimentacaoVeiculo.mve_n_quilometragem,
                        mve_b_registroAutomatico = true,
                        mve_c_usuarioLogado = "GERADO PELO SISTEMA",
                        mve_d_dataRegistro = DateTime.Now,
                        mve_d_modificacao = DateTime.Now,
                        mve_c_unique = new Guid(),
                        mve_d_atualizado = DateTime.Now,
                        mve_d_inclusao = DateTime.Now
                    });
                }
            }
            return retorno;
        }

        public List<RelatorioMovimentacao>RelatorioAnalitico(MovimentacaoVeiculoViewModel model)
        {
            int? idCli = null;
            int? idFro = null;
            int? idMor = null;
            DateTime dataInicio;
            DateTime dataFim;

            if (model.cli_n_codigo != null)
            {
                idCli = Convert.ToInt32(model.cli_n_codigo);
            }

            if (model.mve_fro_n_codigo != null)
            {
                idFro = Convert.ToInt32(model.mve_fro_n_codigo);
            }

            if (model.mve_mor_n_codigo != null)
            {
                idMor = Convert.ToInt32(model.mve_mor_n_codigo);
            }

            if(model.data_inicio != null){
                dataInicio = Convert.ToDateTime(model.data_inicio);
            }
            else
            {
                dataInicio = new DateTime(1753, 1, 1);
            }

            if (model.data_fim != null)
            {
                dataFim = Convert.ToDateTime(model.data_fim).AddHours(23).AddMinutes(59);
            }
            else
            {
                dataFim = DateTime.Now;
            }

            List<RelatorioMovimentacao> relatorio = new List<RelatorioMovimentacao>();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {

                SqlParameter IDCLIENTE = new SqlParameter("@IDCLIENTE", idCli);
                SqlParameter IDFROTA = new SqlParameter("@IDFROTA", idFro);
                SqlParameter IDMORADOR = new SqlParameter("@IDMORADOR", idMor);
                SqlParameter DATAINICIO = new SqlParameter("@DATAINICIO", dataInicio);
                SqlParameter DATAFIM = new SqlParameter("@DATAFIM", dataFim);

                command.CommandText = "[GET_MOVIMENTACAO_ANALITICO_COMPLETO]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(IDFROTA);
                command.Parameters.Add(IDMORADOR);
                command.Parameters.Add(DATAINICIO);
                command.Parameters.Add(DATAFIM);
                command.Parameters.Add(IDCLIENTE);

                context.Database.OpenConnection();

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    RelatorioMovimentacao item_relatorio = new RelatorioMovimentacao();
                    item_relatorio.Codigo = dataReader["Codigo"].ToString();
                    item_relatorio.Data = dataReader["DataRegistro"].ToString();
                    item_relatorio.Modelo = dataReader["Modelo"].ToString();
                    item_relatorio.Placa = dataReader["Placa"].ToString();
                    item_relatorio.Funcionario = dataReader["Funcionario"].ToString();
                    item_relatorio.Fluxo = dataReader["Fluxo"].ToString();
                    item_relatorio.Quilometragem = dataReader["Quilometragem"].ToString();
                    item_relatorio.KmRodado = dataReader["km_Rodado"].ToString();

                    relatorio.Add(item_relatorio);
                }       
            }

            return relatorio;

        }

        public List<RelatorioMovimentacao> RelatorioMacro(MovimentacaoVeiculoViewModel model)
        {
            int? idCli = null;
            int? idFro = null;
            int? idMor = null;
            DateTime dataInicio;
            DateTime dataFim;

            if (model.cli_n_codigo != null)
            {
                idCli = Convert.ToInt32(model.cli_n_codigo);
            }

            if (model.mve_fro_n_codigo != null)
            {
                idFro = Convert.ToInt32(model.mve_fro_n_codigo);
            }

            if (model.mve_mor_n_codigo != null)
            {
                idMor = Convert.ToInt32(model.mve_mor_n_codigo);
            }

            if (model.data_inicio != null)
            {
                dataInicio = Convert.ToDateTime(model.data_inicio);
            }
            else
            {
                dataInicio = new DateTime(1753, 1, 1);
            }

            if (model.data_fim != null)
            {
                dataFim = Convert.ToDateTime(model.data_fim).AddHours(23).AddMinutes(59);
            }
            else
            {
                dataFim = DateTime.Now;
            }

            List<RelatorioMovimentacao> relatorio = new List<RelatorioMovimentacao>();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {

                SqlParameter IDCLIENTE = new SqlParameter("@IDCLIENTE", idCli);
                SqlParameter IDFROTA = new SqlParameter("@IDFROTA", idFro);
                SqlParameter IDMORADOR = new SqlParameter("@IDMORADOR", idMor);
                SqlParameter DATAINICIO = new SqlParameter("@DATAINICIO", dataInicio);
                SqlParameter DATAFIM = new SqlParameter("@DATAFIM", dataFim);
                SqlParameter TIPO_AGRUPAMENTO = new SqlParameter("@TIPO_AGRUPAMENTO", model.tipo_agrupamento);

                command.CommandText = "[GET_MOVIMENTACAO_MACRO]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(IDFROTA);
                command.Parameters.Add(IDMORADOR);
                command.Parameters.Add(DATAINICIO);
                command.Parameters.Add(DATAFIM);
                command.Parameters.Add(IDCLIENTE);
                command.Parameters.Add(TIPO_AGRUPAMENTO);

                context.Database.OpenConnection();

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    RelatorioMovimentacao item_relatorio = new RelatorioMovimentacao();
                    item_relatorio.mve_mor_n_codigo = dataReader["mve_mor_n_codigo"].ToString();
                    item_relatorio.mve_fro_n_codigo = dataReader["mve_fro_n_codigo"].ToString();
                    item_relatorio.Modelo = dataReader["Modelo"].ToString();
                    item_relatorio.Placa = dataReader["Placa"].ToString();
                    item_relatorio.Funcionario = dataReader["Funcionario"].ToString();
                    item_relatorio.KmRodado = dataReader["km_Rodado"].ToString();

                    relatorio.Add(item_relatorio);
                }
            }

            return relatorio;

        }
    }
}
