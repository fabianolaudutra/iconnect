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
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Iconnect.Aplicacao.Services
{
    class DocumentoService : RepositoryBase<tb_doc_documento>, IDocumentoService
    {
        private IconnectCoreContext context;

        public DocumentoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public IPagedList<DocumentoViewModel> GetDocumentoFiltrado(DocumentoFilterModel filter)

        {
            try
            {
                var query = (from doc in Context.tb_doc_documento

                             select new DocumentoViewModel
                             {
                                 doc_n_codigo = doc.doc_n_codigo.ToString(),
                                 doc_cli_n_codigo = doc.doc_cli_n_codigo.ToString(),
                                 doc_c_nomeDocumento = doc.doc_c_nomeDocumento,
                                 doc_b_bloquearAcesso = doc.doc_b_bloquearAcesso == true ? "Sim" : "Não",
                                 doc_b_preNotificacao = doc.doc_b_preNotificacao == true ? "Sim" : "Não",
                                 doc_b_notificacaoAcesso = doc.doc_b_notificacaoAcesso == true ? "Sim" : "Não",
                                 doc_b_notificacaoVencimento = doc.doc_b_notificacaoVencimento == true ? "Sim" : "Não",
                                 doc_b_ativarMonitoramento = doc.doc_b_ativarMonitoramento == true ? "Sim" : "Não",                                 
                                 doc_n_diasNotificacao = doc.doc_n_diasNotificacao.ToString(),
                             });

                int codCli = Convert.ToInt32(filter.doc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.doc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.doc_cli_n_codigo == null);
                }

                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DocumentoViewModel InsertOrUpdate(DocumentoViewModel model)
        {
            try
            {
                int codeCli = Convert.ToInt32(model.doc_cli_n_codigo);
                int codeDoc = Convert.ToInt32(model.doc_n_codigo);

                if (codeDoc == 0)
                {
                    Insert(new tb_doc_documento()
                    {
                        doc_cli_n_codigo = codeCli,
                        doc_c_nomeDocumento = model.doc_c_nomeDocumento,
                        doc_b_ativarMonitoramento = Convert.ToBoolean(model.doc_b_ativarMonitoramento),
                        doc_b_bloquearAcesso = Convert.ToBoolean(model.doc_b_bloquearAcesso),
                        doc_b_notificacaoAcesso = Convert.ToBoolean(model.doc_b_notificacaoAcesso),
                        doc_b_notificacaoVencimento = Convert.ToBoolean(model.doc_b_notificacaoVencimento),
                        doc_b_preNotificacao = Convert.ToBoolean(model.doc_b_preNotificacao),
                        doc_n_diasNotificacao = Convert.ToInt32(model.doc_n_diasNotificacao),
                        doc_c_unique = Guid.NewGuid(),
                        doc_d_atualizado = DateTime.Now,
                        doc_d_inclusao = DateTime.Now,
                        doc_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    var doc = (from documento in context.tb_doc_documento where documento.doc_n_codigo == codeDoc select documento).FirstOrDefault();
                    doc.doc_cli_n_codigo = codeCli;
                    doc.doc_c_nomeDocumento = model.doc_c_nomeDocumento;
                    doc.doc_b_ativarMonitoramento = Convert.ToBoolean(model.doc_b_ativarMonitoramento);
                    doc.doc_b_bloquearAcesso = Convert.ToBoolean(model.doc_b_bloquearAcesso);
                    doc.doc_b_preNotificacao = Convert.ToBoolean(model.doc_b_preNotificacao);
                    doc.doc_b_notificacaoAcesso = Convert.ToBoolean(model.doc_b_notificacaoAcesso);
                    doc.doc_b_notificacaoVencimento = Convert.ToBoolean(model.doc_b_notificacaoVencimento);
                    doc.doc_n_diasNotificacao = Convert.ToInt32(model.doc_n_diasNotificacao);
                    doc.doc_d_atualizado = DateTime.Now;
                    doc.doc_d_modificacao = DateTime.Now;

                    Update(doc);
                }
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
            }
            return model;


        }
        public DocumentoViewModel GetDocumento(int id)
        {

            return (from doc in Context.tb_doc_documento
                    where doc.doc_n_codigo == id

                    select new DocumentoViewModel
                    {
                        doc_n_codigo = doc.doc_n_codigo.ToString(),
                        doc_cli_n_codigo = doc.doc_cli_n_codigo.ToString(),
                        doc_c_nomeDocumento = doc.doc_c_nomeDocumento,
                        doc_b_ativarMonitoramento = doc.doc_b_ativarMonitoramento.ToString(),
                        doc_b_bloquearAcesso = doc.doc_b_bloquearAcesso.ToString(),
                        doc_b_preNotificacao = doc.doc_b_preNotificacao.ToString(),
                        doc_b_notificacaoAcesso = doc.doc_b_notificacaoAcesso.ToString(),
                        doc_b_notificacaoVencimento = doc.doc_b_notificacaoVencimento.ToString(),
                        doc_n_diasNotificacao = doc.doc_n_diasNotificacao.ToString(),
                    }).FirstOrDefault();
        }
        public List<DocumentoViewModel> GetDocSegTrabalho(int id)
        {
            //Se zero, lista todos clientes
            if (id == 0)
            {
                return (from d in Context.tb_doc_documento
                        join cli in Context.tb_cli_cliente on d.doc_cli_n_codigo equals cli.cli_n_codigo
                        where cli.cli_b_ativo == true && cli.cli_tcl_n_codigo == 2
                        select new DocumentoViewModel()
                        {
                            doc_n_codigo = d.doc_n_codigo.ToString(),
                            doc_c_nomeDocumento = d.doc_c_nomeDocumento,
                            doc_cli_n_codigo = cli.cli_c_nomeFantasia,
                        }).OrderBy(x => x.doc_cli_n_codigo).ThenBy(y => y.doc_c_nomeDocumento).ToList();
            }
            else
            {
                return (from d in Context.tb_doc_documento
                        join cli in Context.tb_cli_cliente on d.doc_cli_n_codigo equals cli.cli_n_codigo
                        where cli.cli_b_ativo == true && cli.cli_tcl_n_codigo == 2 && cli.cli_n_codigo == id
                        select new DocumentoViewModel()
                        {
                            doc_n_codigo = d.doc_n_codigo.ToString(),
                            doc_c_nomeDocumento = d.doc_c_nomeDocumento,
                            doc_cli_n_codigo = cli.cli_c_nomeFantasia,
                        }).OrderBy(x => x.doc_cli_n_codigo).ThenBy(y => y.doc_c_nomeDocumento).ToList();
            }

        }

            public bool DeletarDocumento(int id)
            {
                try
                {
                    Delete(context.tb_doc_documento.Find(id));
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                }
                return false;
            }

        public List<DocumentoViewModel> GetDocumentosByCliMor(DocumentoFilterModel filter)
        {
            List<DocumentoMoradorViewModel> lstDocumentoMor;

            lstDocumentoMor = (from doc in Context.tb_dmo_documentoMorador
                      where doc.dmo_mor_n_codigo == Convert.ToInt32(filter.mor_n_codigo_filter)
                         select new DocumentoMoradorViewModel()
                      {
                          dmo_n_codigo = doc.dmo_n_codigo.ToString(),
                          dmo_doc_n_codigo = doc.dmo_doc_n_codigo.ToString(),
                          dmo_d_vencimento = doc.dmo_d_vencimento.ToString()
                      }).ToList();


            var lstDocumentoCli = (from doc in Context.tb_doc_documento
                             where doc.doc_cli_n_codigo == Convert.ToInt32(filter.doc_cli_n_codigo_filter)
                             select new DocumentoViewModel()
                             {
                                 doc_n_codigo = doc.doc_n_codigo.ToString(),
                                 doc_c_nomeDocumento = doc.doc_c_nomeDocumento,
                                 doc_n_diasNotificacao = doc.doc_n_diasNotificacao.ToString()
                             }).ToList();

            //Verifica se morador possui documentos, caso possua adiciona a listagem de retorno
            if (lstDocumentoMor != null && lstDocumentoMor.Count > 0)
            {
                foreach (var documentoCli in lstDocumentoCli)
                {
                    var auxDocMor = lstDocumentoMor.Where(x => x.dmo_doc_n_codigo == documentoCli.doc_n_codigo).FirstOrDefault();
                    if(auxDocMor != null)
                    {
                        int diasPreNotificacao = Convert.ToInt32(documentoCli.doc_n_diasNotificacao) * -1;

                        DateTime dtAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        DateTime dtVencimento = Convert.ToDateTime(auxDocMor.dmo_d_vencimento);
                        DateTime dtPreVencimento = dtVencimento.AddDays(diasPreNotificacao);

                        if (dtAtual > dtVencimento)
                        {
                            documentoCli.documentoVencido = "True";
                        }
                        else if (dtAtual >= dtPreVencimento && dtAtual <= dtVencimento)
                        {
                            documentoCli.documentoQuaseVencendo = "True";
                        }
                        else
                        {
                            documentoCli.documentoValido = "True";
                        }

                        documentoCli.dataVencimento = auxDocMor.dmo_d_vencimento.Substring(0, 10);
                    }
                }
            }      

            return lstDocumentoCli;
        }

        public bool AtivarDesativarMonitoramentoDocumento(DocumentoViewModel model)
        {
            try
            {
                var doc = (from documento in context.tb_doc_documento where documento.doc_n_codigo == Convert.ToInt32(model.doc_n_codigo) select documento).FirstOrDefault();
                doc.doc_b_ativarMonitoramento = Convert.ToBoolean(model.doc_b_ativarMonitoramento);
                doc.doc_d_modificacao = DateTime.Now;

                Update(doc);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public List<DocumentoViewModel> GetSegTrabalhoRel(DocumentoFilterModel filter)
        {

            List <DocumentoViewModel> retorno = new List<DocumentoViewModel>();
            Nullable<int> documento;
            Nullable<int> funcionario;
            
            if(filter.mor_n_codigo_filter == null)
            {
                funcionario = null;
            }
            else
            {
                funcionario = Convert.ToInt32(filter.mor_n_codigo_filter);
            }

            if (filter.doc_n_codigo_filter == null)
            {
                documento = null;
            }
            else
            {
                documento = Convert.ToInt32(filter.doc_n_codigo_filter);
            }

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter cli_n_codigo = new SqlParameter("@CLI_N_CODIGO", Convert.ToInt32(filter.doc_cli_n_codigo_filter));
                SqlParameter doc_n_codigo = new SqlParameter("@DOC_N_CODIGO", documento);
                SqlParameter mor_n_codigo = new SqlParameter("@MOR_N_CODIGO", funcionario);
                SqlParameter status_doc = new SqlParameter("@STATUS_DOC", filter.status);
               
                command.CommandText = "[REL_DOCUMENTOS_SEGURANCA_TRABALHO]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(cli_n_codigo);
                command.Parameters.Add(doc_n_codigo);
                command.Parameters.Add(mor_n_codigo);
                command.Parameters.Add(status_doc);

                context.Database.OpenConnection(); 

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var doc = new DocumentoViewModel();
                    var dtVencto = (DateTime?)dataReader["DMO_D_VENCIMENTO"];
                    doc.doc_c_nomeDocumento = dataReader["DOC_C_NOMEDOCUMENTO"].ToString();
                    doc.doc_mor_c_nome = dataReader["MOR_C_NOME"].ToString();
                    doc.doc_cli_c_nomeFantasia = dataReader["CLI_C_NOMEFANTASIA"].ToString();
                    doc.status = dataReader["STATUS_DOC"].ToString();
                    doc.dataVencimento = dtVencto != null ? Convert.ToDateTime(dtVencto).ToString("dd/MM/yyyy") : string.Empty;
                    
                    retorno.Add(doc);
                }

            }

            return retorno; 
        }

            //public List<DocumentoViewModel> GetDocumentosCliente(int id)
            //{
            //    return (from doc in Context.tb_doc_documento
            //            where doc.doc_cli_n_codigo == id
            //            select new DocumentoViewModel()
            //            {
            //                doc_n_codigo = doc.doc_n_codigo.ToString(),
            //                doc_c_nomeDocumento = doc.doc_c_nomeDocumento
            //            }).ToList();
            //}


            //public bool ExcluirTemporarios()
            //{
            //    try
            //    {
            //        List<tb_zec_zeladorCliente> listaZeladores = new List<tb_zec_zeladorCliente>();


            //        listaZeladores = (from zec in context.tb_zec_zeladorCliente where zec.zec_cli_n_codigo == null select zec).OrderBy(x => x.zec_c_nome).ToList();


            //        foreach (var item in listaZeladores)
            //        {

            //            DeletarZelador(item.zec_n_codigo);
            //        }
            //        return true;

            //    }
            //    catch (Exception)
            //    {
            //        return false;

            //        throw;
            //    }
            //}

            //public bool Vincular(int id)
            //{
            //    try
            //    {
            //        var lista = context.tb_zec_zeladorCliente.Where(x => x.zec_cli_n_codigo == null).ToList();

            //        if (lista.Count() > 0)
            //        {
            //            foreach (var item in lista)
            //            {
            //                item.zec_cli_n_codigo = id;
            //                Update(item);
            //            }

            //            context.SaveChanges();
            //        }

            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        return false;
            //    }
            //}


        }
}