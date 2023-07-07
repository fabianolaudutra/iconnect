using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Interfaces
{
    public interface ITopicosService
    {
        void Insert(TopicoViewModel model);
        List<TopicoViewModel> GetTopicos();
        IPagedList<TopicoViewModel> GetListaTopicos(TopicosFilterModel filter);
        void Deletar(int id);
    }
}
