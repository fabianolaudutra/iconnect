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
    class ParametrosEmpresaService : RepositoryBase<tb_par_parametrosEmpresa>, IParametrosEmpresaService
    {
        private IconnectCoreContext context;

        public ParametrosEmpresaService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(ParametrosEmpresaViewModel model)
        {
            try
            {
                tb_par_parametrosEmpresa parametros;
                parametros = (from par in context.tb_par_parametrosEmpresa where par.par_emp_n_codigo == model.par_emp_n_codigo select par).FirstOrDefault();

                if (parametros == null)
                {
                    Insert(parametros = new tb_par_parametrosEmpresa()
                    {
                        par_c_descricao = model.par_c_descricao,
                        par_c_chave = model.par_c_chave,
                        par_c_valor = model.par_c_valor,
                        par_c_titulo = model.par_c_titulo,
                        par_b_interno = model.par_b_interno,
                        par_emp_n_codigo = model.par_emp_n_codigo,
                        par_c_unique = Guid.NewGuid(),
                        par_d_modificacao = DateTime.Now,
                        par_d_atualizado = DateTime.Now,
                        par_d_inclusao = DateTime.Now,
                        
                    });
                }
                else
                {
                    parametros.par_c_descricao = model.par_c_descricao;
                    parametros.par_c_valor = model.par_c_valor;
                    parametros.par_d_atualizado = DateTime.Now;
                    parametros.par_d_modificacao = DateTime.Now;
                    Update(parametros);
                }
              
                context.SaveChanges();
                return parametros.par_n_codigo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ParametrosEmpresaViewModel FindParametrosEmpresa(ParametrosEmpresaViewModel parametros)
        {
            string chave = parametros.par_c_chave;
            int empresa = parametros.par_emp_n_codigo.Value;
            return (from par in Context.tb_par_parametrosEmpresa
                    where par.par_c_chave == chave && par.par_emp_n_codigo == empresa
                    select new ParametrosEmpresaViewModel()
                    {
                        par_n_codigo = par.par_n_codigo,

                        par_c_descricao = par.par_c_descricao,
                        par_c_chave = par.par_c_chave,
                        par_c_valor = par.par_c_valor,
                        par_c_titulo = par.par_c_titulo,
                        par_b_interno = par.par_b_interno,
                        par_c_aba = par.par_c_aba,
                        par_emp_n_codigo = par.par_emp_n_codigo,

                    }).FirstOrDefault();
        }
    }
}
