using System;
using System.Collections.Generic;
using System.Text;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using System.Linq;
using Iconnect.Aplicacao.ViewModels;

namespace Iconnect.Aplicacao.Services
{
    public class ModuloService : RepositoryBase<tb_mol_modulosLiberados>, IModuloService
    {
        private IconnectCoreContext context;

        public ModuloService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private ILicencasService _licenca;
        public ILicencasService Licenca
        {
            get
            {
                if (_licenca == null)
                {
                    _licenca = new LicencasService(context);
                }
                return _licenca;
            }
        }

        //public object SalvarModulo(ModuloViewModel model)
        //{
        //    try
        //    {
        //        Retorno retorno = new Retorno();

        //        if (model.mol_n_codigo == null || model.mol_n_codigo == "")
        //        {

        //            Insert(new tb_mol_modulosLiberados()
        //            {
        //                mol_b_controleDeAcesso = Convert.ToBoolean(model.mol_b_controleDeAcesso),
        //                mol_b_OrdemServico = Convert.ToBoolean(model.mol_b_OrdemServico),
        //                mol_b_MonitoriamentoPerimetral = Convert.ToBoolean(model.mol_b_MonitoriamentoPerimetral),
        //                mol_b_CFTV = Convert.ToBoolean(model.mol_b_CFTV),
        //                mol_b_connectSolutions = Convert.ToBoolean(model.mol_b_connectSolutions),
        //                mol_b_connectPRO = Convert.ToBoolean(model.mol_b_connectPRO),
        //                mol_b_connectGaren = Convert.ToBoolean(model.mol_b_connectGaren),
        //                mol_b_portariaVirtual = Convert.ToBoolean(model.mol_b_portariaVirtual),
        //                mol_b_connectSync = Convert.ToBoolean(model.mol_b_connectSync),
        //                mol_b_accessView = Convert.ToBoolean(model.mol_b_accessView),
        //                mol_d_atualizado = DateTime.Now,
        //                mol_c_unique = Guid.NewGuid(),
        //                mol_d_inclusao = DateTime.Now,
        //            });
        //        }
        //        else
        //        {
        //            int codMol = Convert.ToInt32(model.mol_n_codigo);
        //            var mol = (from modulo in context.tb_mol_modulosLiberados where modulo.mol_n_codigo == codMol select modulo).FirstOrDefault();

        //            mol.mol_b_controleDeAcesso = mol.mol_b_controleDeAcesso;


        //            mol.mol_d_atualizado = DateTime.Now;
        //            mol.mol_d_modificacao = DateTime.Now;
        //            Update(mol);
        //        }
        //        context.SaveChanges();
        //        retorno.status = "ok";
        //        retorno.conteudo = "true";
        //        return retorno;

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return false;
        //}

        public ModuloViewModel GetModulos(int id)
        {
            return (from mol in context.tb_mol_modulosLiberados
                         where mol.mol_n_codigo == id
                         select new ModuloViewModel()
                         {
                             mol_n_codigo = mol.mol_n_codigo.ToString(),
                             mol_b_controleDeAcesso = mol.mol_b_controleDeAcesso.ToString(),
                             mol_b_OrdemServico = mol.mol_b_OrdemServico.ToString(),
                             mol_b_MonitoriamentoPerimetral = mol.mol_b_MonitoriamentoPerimetral.ToString(),
                             mol_b_CFTV = mol.mol_b_CFTV.ToString(),
                             mol_b_connectSolutions = mol.mol_b_connectSolutions.ToString(),
                             mol_b_connectPRO = mol.mol_b_connectPRO.ToString(),
                             mol_b_connectGaren = mol.mol_b_connectGaren,
                             mol_b_portariaVirtual = mol.mol_b_portariaVirtual.ToString(),
                             mol_b_connectSync = mol.mol_b_connectSync.ToString(),
                             mol_b_accessView = mol.mol_b_accessView.ToString()
                         })?.FirstOrDefault() ?? new ModuloViewModel();
        }

        public void Find(ref tb_mol_modulosLiberados tbModulo)
        {
            try
            {
                if (tbModulo.mol_n_codigo > 0)
                {
                    int codigo = tbModulo.mol_n_codigo;
                    tbModulo = (from mol in context.tb_mol_modulosLiberados where mol.mol_n_codigo == codigo select mol).FirstOrDefault();
                }
            }
            catch (Exception)
            {
            }
        }

        public ModuloViewModel InsertOrUpdate(ModuloViewModel model)
        {
            Retorno retorno = new Retorno();
            int MolCodigo = Convert.ToInt32(model.mol_n_codigo);
            tb_mol_modulosLiberados mol = new tb_mol_modulosLiberados();

            try
            {
                if (MolCodigo > 0)
                {
                    mol.mol_n_codigo = MolCodigo;
                    Find(ref mol);

                    mol.mol_b_controleDeAcesso = Convert.ToBoolean(model.mol_b_controleDeAcesso);
                    mol.mol_b_OrdemServico = Convert.ToBoolean(model.mol_b_OrdemServico);
                    mol.mol_b_MonitoriamentoPerimetral = Convert.ToBoolean(model.mol_b_MonitoriamentoPerimetral);
                    mol.mol_b_CFTV = Convert.ToBoolean(model.mol_b_CFTV);
                    mol.mol_b_connectSolutions = Convert.ToBoolean(model.mol_b_connectSolutions);
                    mol.mol_b_connectPRO = Convert.ToBoolean(model.mol_b_connectPRO);
                    mol.mol_b_connectGaren = model.mol_b_connectGaren;
                    mol.mol_b_portariaVirtual = Convert.ToBoolean(model.mol_b_portariaVirtual);
                    mol.mol_b_connectSync = Convert.ToBoolean(model.mol_b_connectSync);
                    mol.mol_b_accessView = Convert.ToBoolean(model.mol_b_accessView);
                    mol.mol_b_portariaVirtual = Convert.ToBoolean(model.mol_b_portariaVirtual);
                    mol.mol_d_atualizado = DateTime.Now;
                    mol.mol_d_modificacao = DateTime.Now;

                    Update(mol);

                    Licenca.MontaEmailAlteracaoModulos(model);
                }
                else
                {
                    mol.mol_b_controleDeAcesso = Convert.ToBoolean(model.mol_b_controleDeAcesso);
                    mol.mol_b_OrdemServico = Convert.ToBoolean(model.mol_b_OrdemServico);
                    mol.mol_b_MonitoriamentoPerimetral = Convert.ToBoolean(model.mol_b_MonitoriamentoPerimetral);
                    mol.mol_b_CFTV = Convert.ToBoolean(model.mol_b_CFTV);
                    mol.mol_b_connectSolutions = Convert.ToBoolean(model.mol_b_connectSolutions);
                    mol.mol_b_connectPRO = Convert.ToBoolean(model.mol_b_connectPRO);
                    mol.mol_b_connectGaren = model.mol_b_connectGaren;
                    mol.mol_b_portariaVirtual = Convert.ToBoolean(model.mol_b_portariaVirtual);
                    mol.mol_b_connectSync = Convert.ToBoolean(model.mol_b_connectSync);
                    mol.mol_b_accessView = Convert.ToBoolean(model.mol_b_accessView);
                    mol.mol_d_atualizado = DateTime.Now;
                    mol.mol_d_inclusao = DateTime.Now;
                    mol.mol_c_unique = Guid.NewGuid();

                    Insert(mol);
                }
                context.SaveChanges();
                // retorno.status = "ok";
                // retorno.conteudo = "true";
                // retorno.id = mol.mol_n_codigo.ToString();
                model.mol_n_codigo = mol.mol_n_codigo.ToString();

               

                return model;
            }
            catch (Exception)
            { }
            return model;
        }


        public bool DeletarModulo(int id)
        {
            try
            {
                Delete(context.tb_mol_modulosLiberados.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        //public void InsertOrUpdate(tb_mol_modulosLiberados tbModulo)
        //{
        //    int MolCodigo = tbModulo.mol_n_codigo;
        //    try
        //    {
        //        if (MolCodigo > 0)
        //        {
        //            tbModulo.mol_d_atualizado = DateTime.Now;

        //            Update(tbModulo);
        //        }
        //        else
        //        {
        //            tbModulo.mol_d_atualizado = DateTime.Now;
        //            tbModulo.mol_d_inclusao = DateTime.Now;
        //            tbModulo.mol_c_unique = Guid.NewGuid();
        //            Insert(tbModulo);
        //        }
        //        context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}
