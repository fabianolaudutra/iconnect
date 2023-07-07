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
    class ZeladorClienteService : RepositoryBase<tb_zec_zeladorCliente>, IZeladorClienteService
    {
        private IconnectCoreContext context;

        public ZeladorClienteService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IAcessoService _acesso;
        public IAcessoService Acesso
        {
            get
            {
                if (_acesso == null)
                {
                    _acesso = new AcessoService(context);
                }
                return _acesso;
            }
        }

        private IModuloService _modulo;
        public IModuloService Modulo
        {
            get
            {
                if (_modulo == null)
                {
                    _modulo = new ModuloService(context);
                }
                return _modulo;
            }
        }

        public IPagedList<ZeladorClienteViewModel> GetZeladorFiltrado(ZeladorClienteFilterModel filter)
        {
            try
            {
                var query = (from zec in Context.tb_zec_zeladorCliente
                             orderby zec.zec_c_nome
                             select new ZeladorClienteViewModel
                             {
                                 zec_n_codigo = zec.zec_n_codigo.ToString(),
                                 zec_mol_n_codigo = zec.zec_mol_n_codigo.ToString(),
                                 zec_ace_n_codigo = zec.zec_ace_n_codigo.ToString(),
                                 zec_cli_n_codigo = zec.zec_cli_n_codigo.ToString(),
                                 zec_c_nome = zec.zec_c_nome,
                                 zec_mor_n_codigo = zec.zec_mor_n_codigo.ToString(),
                                 zec_c_perfil = zec.zec_c_perfil,
                                 zec_c_rg = zec.zec_c_rg,
                                 zec_c_telefone = zec.zec_c_telefone,

                             });

                int codCli = Convert.ToInt32(filter.zec_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.zec_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.zec_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertOrUpdate(ZeladorClienteViewModel model)
        {
            try
            {
                int? codeCli = null;
                int? codMor = null;
                if (!string.IsNullOrEmpty(model.zec_cli_n_codigo))
                    codeCli = Convert.ToInt32(model.zec_cli_n_codigo);

                if (!string.IsNullOrEmpty(model.zec_mor_n_codigo))
                    codMor = Convert.ToInt32(model.zec_mor_n_codigo);

                int codeZec = Convert.ToInt32(model.zec_n_codigo);
                int codeAce = model.Acesso.ace_n_codigo;
                int codeMol = Convert.ToInt32(model.Modulo.mol_n_codigo);

                if (codeZec == 0)
                {
                    Insert(new tb_zec_zeladorCliente()
                    {
                        zec_cli_n_codigo = codeCli,
                        zec_ace_n_codigo = codeAce,
                        zec_mol_n_codigo = codeMol,
                        zec_c_nome = model.zec_c_nome,
                        zec_mor_n_codigo = codMor,
                        zec_c_perfil = model.zec_c_perfil,
                        zec_c_rg = model.zec_c_rg,
                        zec_c_telefone = model.zec_c_telefone,
                        zec_c_email = model.zec_c_email,
                        zec_c_unique = Guid.NewGuid(),
                        zec_d_atualizado = DateTime.Now,
                        zec_d_inclusao = DateTime.Now,
                        zec_d_modificacao = DateTime.Now
                    });
                }
                else
                {
                    var zec = (from zelador in context.tb_zec_zeladorCliente where zelador.zec_n_codigo == codeZec select zelador)?.FirstOrDefault();

                    if (zec == null) throw new Exception("Zelador não encontrado.");

                    zec.zec_cli_n_codigo = codeCli;
                    zec.zec_ace_n_codigo = codeAce;
                    zec.zec_mol_n_codigo = codeMol;
                    zec.zec_mor_n_codigo = codMor;
                    zec.zec_c_perfil = model.zec_c_perfil;
                    zec.zec_c_nome = model.zec_c_nome;
                    zec.zec_c_rg = model.zec_c_rg;
                    zec.zec_c_telefone = model.zec_c_telefone;
                    zec.zec_c_email = model.zec_c_email;
                    zec.zec_d_atualizado = DateTime.Now;
                    zec.zec_d_modificacao = DateTime.Now;

                    Update(zec);
                }
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao salvar os dados");
            }
        } 

        public ZeladorClienteViewModel GetZelador(int id)
        {
            var zelador =  (from zec in Context.tb_zec_zeladorCliente
                    where zec.zec_n_codigo == id

                    select new ZeladorClienteViewModel
                    {
                        zec_n_codigo = zec.zec_n_codigo.ToString(),
                        zec_mor_n_codigo = zec.zec_mor_n_codigo.ToString(),
                        zec_c_perfil = zec.zec_c_perfil,
                        zec_c_nome = zec.zec_c_nome,
                        zec_c_telefone = zec.zec_c_telefone,
                        zec_c_rg = zec.zec_c_rg,
                        zec_c_email = zec.zec_c_email,
                        zec_ace_n_codigo = zec.zec_ace_n_codigo.ToString()

                        //Acesso = Acesso.GetAcesso(zec.zec_ace_n_codigo.Value),
                    }).FirstOrDefault() ?? new ZeladorClienteViewModel();

            zelador.Acesso = Acesso.GetAcesso(Convert.ToInt32(zelador.zec_ace_n_codigo));

            return zelador;
        }

        public bool DeletarZelador(int id)
        {
            try
            {
                int idAcesso = Context.tb_zec_zeladorCliente.FirstOrDefault(w => w.zec_n_codigo == id).zec_ace_n_codigo.Value;
                int idModulo = Context.tb_zec_zeladorCliente.FirstOrDefault(w => w.zec_n_codigo == id).zec_mol_n_codigo.Value;
                Delete(context.tb_zec_zeladorCliente.Find(id));
                context.SaveChanges();

                Acesso.DeletarAcesso(idAcesso);
                Modulo.DeletarModulo(idModulo);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_zec_zeladorCliente> listaZeladores = new List<tb_zec_zeladorCliente>();


                listaZeladores = (from zec in context.tb_zec_zeladorCliente where zec.zec_cli_n_codigo == null select zec).OrderBy(x => x.zec_c_nome).ToList();


                foreach (var item in listaZeladores)
                {

                    DeletarZelador(item.zec_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public bool Vincular(int id)
        {
            try
            {
                var lista = context.tb_zec_zeladorCliente.Where(x => x.zec_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.zec_cli_n_codigo = id;
                        Update(item);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<GenericList> GetZeladoresCliente(int id)
        {
            return (from z in Context.tb_zec_zeladorCliente
                    where z.zec_cli_n_codigo == id
                    select new GenericList()
                    {
                        value = z.zec_n_codigo.ToString(),
                        text = z.zec_c_nome,
                        grupo = z.zec_c_perfil


                    }).ToList();
        }
    }
}
