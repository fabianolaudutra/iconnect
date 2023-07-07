using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IDocumentoMoradorService : IRepositoryBase<tb_dmo_documentoMorador>
    {
        //public List<tb_dmo_documentoMorador> GetDocumentosMorador(int id);

        public bool InsertOrUpdate(DocumentoMoradorViewModel[] lstDocumentos);
    }
}
