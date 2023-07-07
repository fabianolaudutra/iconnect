using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    class PermissoesGrupoService : RepositoryBase<tb_pgp_permissoesGrupo>, IPermissoesGrupoService
    {
        private readonly IconnectCoreContext _context;

        public PermissoesGrupoService(IconnectCoreContext context) : base(context)
        {
            _context = context;
        }

        public object InsertOrUpdate(PermissoesGrupoViewModel model)
        {
            var codPgp = 0;

            if (model.pgp_n_codigo != null && model.pgp_n_codigo != "")
                codPgp = Convert.ToInt32(model.pgp_n_codigo);

            if (codPgp == 0)
            {
                var pgp = new tb_pgp_permissoesGrupo()
                {
                    pgp_b_checado = Convert.ToBoolean(model.pgp_b_checado),
                    pgp_gpp_n_codigo = Convert.ToInt32(model.pgp_gpp_n_codigo),
                    pgp_top_n_codigo = Convert.ToInt32(model.pgp_top_n_codigo),
                    pgp_c_unique = Guid.NewGuid(),
                    pgp_d_modificacao = DateTime.Now,
                    pgp_d_atualizado = DateTime.Now,
                    pgp_d_inclusao = DateTime.Now,
                };

                Insert(pgp);
            }
            else
            {
                var pgp = (from permissao in Context.tb_pgp_permissoesGrupo where permissao.pgp_n_codigo == codPgp select permissao).FirstOrDefault();

                pgp.pgp_top_n_codigo = Convert.ToInt32(model.pgp_top_n_codigo);
                pgp.pgp_b_checado = Convert.ToBoolean(model.pgp_b_checado);
                pgp.pgp_d_modificacao = DateTime.Now;
                pgp.pgp_d_atualizado = DateTime.Now;

                Update(pgp);
            }
            _context.SaveChanges();

            return model;
        }
    }
}
