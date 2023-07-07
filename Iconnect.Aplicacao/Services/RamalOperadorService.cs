using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Iconnect.Infraestrutura.Exceptions;

namespace Iconnect.Aplicacao.Services
{
    public class RamalOperadorService : RepositoryBase<tb_rop_ramalOperador>, IRamalOperadorService
    {
        private IconnectCoreContext context;

        public RamalOperadorService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public void SalvarRamal(RamalOperadorViewModel model)
        {
            ValidaRamal(model);

            tb_rop_ramalOperador ramal;

            if (String.IsNullOrEmpty(model.rop_n_codigo))
            {
                ramal = new tb_rop_ramalOperador()
                {
                    rop_ope_n_codigo = Convert.ToInt32(model.rop_ope_n_codigo),
                    rop_c_ramal = model.rop_c_ramal,
                    rop_d_inclusao = DateTime.Now,
                    rop_d_atualizado = DateTime.Now,
                    rop_d_data = DateTime.Now,
                };

                Insert(ramal);
            }
            else
            {
                ramal = (from rop in context.tb_rop_ramalOperador where rop.rop_n_codigo == Convert.ToInt32(model.rop_n_codigo) select rop).FirstOrDefault();
                ramal.rop_c_ramal = model.rop_c_ramal;
                ramal.rop_d_atualizado = DateTime.Now;

                Update(ramal);
            }

            context.SaveChanges();
        }

        private int? BuscarEmpresa(int idOperador)
        {
            return (from ope in context.tb_ope_operador
                    where ope.ope_n_codigo == idOperador
                    select ope.ope_emp_n_codigo).FirstOrDefault();
        }

        private List<int> BuscarOperadores(int idOperador)
        {
            var empresa = BuscarEmpresa(idOperador);

            return (from ope in context.tb_ope_operador
                    where ope.ope_emp_n_codigo == empresa
                    && ope.ope_n_codigo != idOperador
                    select ope.ope_n_codigo).ToList();
        }

        private void ValidaRamal(RamalOperadorViewModel model)
        {
            var ramais = (from rop in context.tb_rop_ramalOperador
                          where rop.rop_d_data >= DateTime.Now.Date
                          select rop).ToList();

            var operadores = BuscarOperadores(Convert.ToInt32(model.rop_ope_n_codigo));

            List<tb_rop_ramalOperador> aux = new List<tb_rop_ramalOperador>();
            if (operadores?.Count() != 0)
            {
                foreach (var operador in operadores)
                {
                    var operadorRamal = ramais.Where(x => x.rop_ope_n_codigo.Equals(operador)).FirstOrDefault();

                    if (operadorRamal != null)
                        aux.Add(operadorRamal);
                }
            }

            if (aux?.Where(x => x.rop_c_ramal.Contains(model.rop_c_ramal)).Count() != 0)
            {
                throw new MensagemException("O ramal selecionado está em uso.");
            }
        }
    }
}
