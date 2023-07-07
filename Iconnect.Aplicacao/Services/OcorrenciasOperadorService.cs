using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class OcorrenciasOperadorService : RepositoryBase<tb_ocp_ocorrenciasOperador>, IOcorrenciasOperadorService
    {
        private IconnectCoreContext context;

        public OcorrenciasOperadorService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public Retorno Salvar(OcorrenciasOperadorViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                if (string.IsNullOrEmpty(model.ocp_n_codigo))
                {
                    var ocorrencia = new tb_ocp_ocorrenciasOperador
                    {
                        ocp_cli_n_codigo = Convert.ToInt32(model.ocp_cli_n_codigo),
                        ocp_c_data = DateTime.Now,
                        ocp_ope_n_cadastrou = Convert.ToInt32(model.ocp_ope_n_cadastrou),
                        ocp_c_descricao = model.ocp_c_descricao,
                        ocp_c_unique = new Guid(),
                        ocp_d_atualizado = DateTime.Now,
                        ocp_d_inclusao = DateTime.Now,
                        ocp_c_status = model.ocp_c_status,
                    };

                    Insert(ocorrencia);
                }
                else
                {
                    var ocorrencia = (from ocp in context.tb_ocp_ocorrenciasOperador where ocp.ocp_n_codigo == Convert.ToInt32(model.ocp_n_codigo) select ocp).FirstOrDefault();
                    ocorrencia.ocp_c_status = model.ocp_c_status;
                    ocorrencia.ocp_ope_n_modificou = Convert.ToInt32(model.ocp_ope_n_modificou);
                    ocorrencia.ocp_d_atualizado = DateTime.Now;

                    Update(ocorrencia);
                }

                context.SaveChanges();

                retorno.status = "Sucesso";
                retorno.conteudo = "Dados salvos com sucesso.";
            }
            catch (Exception)
            {
                retorno.status = "Erro";
                retorno.conteudo = "Ocorreu um erro ao salvar os dados.";
            }

            return retorno;
        }

        public IPagedList<OcorrenciasOperadorViewModel> GetOcorrenciasOperadorFiltrado(OcorrenciasOperadorFilterModel filter, string idsClientes)
        {
            var ocorrencias = (from ocp in context.tb_ocp_ocorrenciasOperador
                               join opeC in context.tb_ope_operador on ocp.ocp_ope_n_cadastrou equals opeC.ope_n_codigo into tempOpeCadastrou
                               from opeCadastrou in tempOpeCadastrou.DefaultIfEmpty()
                               join opeM in context.tb_ope_operador on ocp.ocp_ope_n_modificou equals opeM.ope_n_codigo into tempOpeModificou
                               from opeModificou in tempOpeModificou.DefaultIfEmpty()
                               join cli in context.tb_cli_cliente on ocp.ocp_cli_n_codigo equals cli.cli_n_codigo
                               where ocp.ocp_c_status != "finalizado"
                               select new OcorrenciasOperadorViewModel()
                               {
                                   ocp_n_codigo = ocp.ocp_n_codigo.ToString(),
                                   ocp_cli_n_codigo = ocp.ocp_cli_n_codigo.ToString(),
                                   ocp_cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                   ocp_ope_n_cadastrou = ocp.ocp_ope_n_cadastrou.ToString(),
                                   ocp_ope_c_nomeCadastrou = opeCadastrou.ope_c_nome,
                                   ocp_ope_n_modificou = ocp.ocp_ope_n_modificou.ToString(),
                                   ocp_ope_c_nomeModificou = opeModificou.ope_c_nome,
                                   ocp_c_data = ocp.ocp_c_data.ToString("dd/MM/yyyy"),
                                   ocp_c_descricao = ocp.ocp_c_descricao,
                                   ocp_c_status = ocp.ocp_c_status

                               }).ToList();

            if (!string.IsNullOrEmpty(idsClientes) && (!idsClientes?.Equals("todos") ?? false) && (!idsClientes?.Equals("NULL") ?? false))
            {
                ocorrencias = ocorrencias.Where(w => idsClientes.Split(",").Contains(w.ocp_cli_n_codigo)).ToList();
            }

            if (!string.IsNullOrEmpty(filter.ocp_cli_n_codigo) && filter.ocp_cli_n_codigo != "0")
            {
                ocorrencias = ocorrencias.Where(x => x.ocp_cli_n_codigo.Contains(filter.ocp_cli_n_codigo)).ToList();
            }

            foreach (var ocorrencia in ocorrencias)
            {
                if (ocorrencia.ocp_c_descricao.Length >= 50)
                {
                    ocorrencia.ocp_c_descricao = ocorrencia.ocp_c_descricao.Substring(0, 55) + "...";
                }
            }

            return ocorrencias.ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public OcorrenciasOperadorViewModel GetOcorrenciaOperador(int id)
        {
            return (from ocp in context.tb_ocp_ocorrenciasOperador
                    where ocp.ocp_n_codigo == id
                    select new OcorrenciasOperadorViewModel()
                    {
                        ocp_n_codigo = ocp.ocp_n_codigo.ToString(),
                        ocp_cli_n_codigo = ocp.ocp_cli_n_codigo.ToString(),
                        ocp_c_descricao = ocp.ocp_c_descricao,
                        ocp_c_status = ocp.ocp_c_status,

                    }).FirstOrDefault();
        }

        public List<OcorrenciasOperadorViewModel> GetRelatorioOcorrenciasOperador(OcorrenciasOperadorViewModel model, string idsClientes)
        {
            var ocorrencias = (from ocp in context.tb_ocp_ocorrenciasOperador
                               join opeC in context.tb_ope_operador on ocp.ocp_ope_n_cadastrou equals opeC.ope_n_codigo into tempOpeCadastrou
                               from opeCadastrou in tempOpeCadastrou.DefaultIfEmpty()
                               join opeM in context.tb_ope_operador on ocp.ocp_ope_n_modificou equals opeM.ope_n_codigo into tempOpeModificou
                               from opeModificou in tempOpeModificou.DefaultIfEmpty()
                               join cli in context.tb_cli_cliente on ocp.ocp_cli_n_codigo equals cli.cli_n_codigo
                               select new OcorrenciasOperadorViewModel()
                               {
                                   ocp_cli_n_codigo = ocp.ocp_cli_n_codigo.ToString(),
                                   ocp_cli_c_nomeFantasia = cli.cli_c_nomeFantasia,
                                   ocp_ope_c_nomeCadastrou = opeCadastrou.ope_c_nome,
                                   ocp_ope_c_nomeModificou = opeModificou.ope_c_nome,
                                   ocp_c_data = ocp.ocp_c_data.ToString("dd/MM/yyyy"),
                                   ocp_d_atualizado = ocp.ocp_d_atualizado.ToString("dd/MM/yyyy"),
                                   ocp_c_descricao = ocp.ocp_c_descricao,
                                   ocp_c_status = ocp.ocp_c_status,
                               }).ToList();

            if (!string.IsNullOrEmpty(idsClientes) && (!idsClientes?.Equals("todos") ?? false) && (!idsClientes?.Equals("NULL") ?? false))
            {
                ocorrencias = ocorrencias.Where(w => idsClientes.Split(",").Contains(w.ocp_cli_n_codigo)).ToList();
            }

            if (!string.IsNullOrEmpty(model.ocp_cli_n_codigo) && model.ocp_cli_n_codigo != "0")
            {
                ocorrencias = ocorrencias.Where(x => x.ocp_cli_n_codigo.Contains(model.ocp_cli_n_codigo)).ToList();
            }

            if (!string.IsNullOrEmpty(model.data_inicio))
            {
                ocorrencias = ocorrencias.Where(x => Convert.ToDateTime(x.ocp_c_data) >= Convert.ToDateTime(model.data_inicio)).ToList();
            }

            if (!string.IsNullOrEmpty(model.data_fim))
            {
                ocorrencias = ocorrencias.Where(x => Convert.ToDateTime(x.ocp_c_data) <= Convert.ToDateTime(model.data_fim).AddHours(23).AddMinutes(59)).ToList();
            }

            return ocorrencias;
        }
    }
}