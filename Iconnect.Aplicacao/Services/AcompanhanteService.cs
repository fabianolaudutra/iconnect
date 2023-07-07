using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;
using System.Data;
using System.Linq;

namespace Iconnect.Aplicacao.Services
{
    public class AcompanhanteService : RepositoryBase<tb_aco_acompanhante>, IAcompanhanteService
    {
        private IconnectCoreContext context;

        public AcompanhanteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeletarAcompanhante(int id)
        {
            try
            {
                var acompanhante = (from aco in context.tb_aco_acompanhante where aco.aco_age_n_codigo == id select aco).FirstOrDefault();
                Delete(acompanhante);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
