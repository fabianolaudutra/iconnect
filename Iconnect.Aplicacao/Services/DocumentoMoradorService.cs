using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class DocumentoMoradorService : RepositoryBase<tb_dmo_documentoMorador>, IDocumentoMoradorService
    {
        private IconnectCoreContext context;

        public DocumentoMoradorService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        //public List<DocumentoMoradorViewModel> GetDocumentosMorador(int id)
        //{
        //    List<DocumentoMoradorViewModel> lstDocMor = new List<DocumentoMoradorViewModel>();
        //    var auxDocMor = (from doc in context.tb_dmo_documentoMorador where doc.dmo_mor_n_codigo == id select doc).ToList();

        //    return lstDocMor;
        //}

        public bool InsertOrUpdate(DocumentoMoradorViewModel[] lstDocumentos)
        {
            try
            {
                var mor_n_codigo = lstDocumentos[0].dmo_mor_n_codigo;
                if (!string.IsNullOrEmpty(mor_n_codigo))
                {
                    //Apagar os documentos deste morador
                    var auxLstDocExclusao = context.tb_dmo_documentoMorador.Where(x => x.dmo_mor_n_codigo == Convert.ToInt32(mor_n_codigo)).ToList();
                    if (auxLstDocExclusao != null && auxLstDocExclusao.Count > 0)
                    {
                        context.RemoveRange(auxLstDocExclusao);
                    }

                    //Inseri os documentos novamente
                    for (int i = 0; i < lstDocumentos.Length; i++)
                    {
                        var doc = lstDocumentos[i];

                        if(!string.IsNullOrEmpty(doc.dmo_d_vencimento))
                        {
                            Insert(new tb_dmo_documentoMorador()
                            {
                                dmo_mor_n_codigo = Convert.ToInt32(doc.dmo_mor_n_codigo),
                                dmo_doc_n_codigo = Convert.ToInt32(doc.dmo_doc_n_codigo),
                                dmo_d_vencimento = Convert.ToDateTime(doc.dmo_d_vencimento),
                                dmo_c_unique = Guid.NewGuid(),
                                dmo_d_atualizado = DateTime.Now,
                                dmo_d_inclusao = DateTime.Now,
                                dmo_d_modificacao = DateTime.Now
                            });
                        }
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}