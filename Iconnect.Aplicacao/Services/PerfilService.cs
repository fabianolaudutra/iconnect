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

namespace Iconnect.Aplicacao.Services
{
    public class PerfilService : RepositoryBase<tb_per_perfil>, IPerfilService
    {
        private IconnectCoreContext context;

        public PerfilService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public List<PerfilViewModel> GetAllPerfis()
        {
            return (from p in context.tb_per_perfil
                    select new PerfilViewModel()
                    {
                        per_c_nome = p.per_c_nome,
                        per_c_unique = p.per_c_unique,
                        per_d_atualizado = p.per_d_atualizado,
                        per_d_inclusao = p.per_d_inclusao,
                        per_d_modificacao = p.per_d_modificacao,
                        per_n_codigo = p.per_n_codigo
                    }).OrderBy(x=>x.per_c_nome).ToList();
        }
    }
}
