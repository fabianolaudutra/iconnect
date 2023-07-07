using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System.Collections.Generic;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface IDocumentoService : IRepositoryBase<tb_doc_documento>
    {
        public DocumentoViewModel InsertOrUpdate(DocumentoViewModel model);
        IPagedList<DocumentoViewModel> GetDocumentoFiltrado(DocumentoFilterModel filter);
        public DocumentoViewModel GetDocumento(int id);
        public List<DocumentoViewModel> GetDocSegTrabalho(int id);
        public List<DocumentoViewModel> GetSegTrabalhoRel(DocumentoFilterModel model);
        public bool DeletarDocumento(int id);
        //bool ExcluirTemporarios();
        //public bool Vincular(int id);
        public List<DocumentoViewModel> GetDocumentosByCliMor(DocumentoFilterModel filter);
        bool AtivarDesativarMonitoramentoDocumento(DocumentoViewModel model);
    }
}
