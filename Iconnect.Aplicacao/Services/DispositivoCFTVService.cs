using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    class DispositivoCFTVService : RepositoryBase<tb_ddv_dispositivoDVRCliente>, IDispositivoCFTVService
    {
        private IconnectCoreContext context;

        public DispositivoCFTVService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        public DispositivoCFTVViewModel InsertOrUpdate(DispositivoCFTVViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.ddv_cli_n_codigo != null && model.ddv_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.ddv_cli_n_codigo);
                }

                int codeDdv = Convert.ToInt32(model.ddv_n_codigo);

                if (codeDdv == 0)
                {
                    Insert(new tb_ddv_dispositivoDVRCliente()
                    {
                        ddv_cli_n_codigo = codeCli,
                        ddv_c_nome = model.ddv_c_nome,
                        ddv_fab_n_codigo = Convert.ToInt32(model.ddv_fab_n_codigo),
                        ddv_mod_n_codigo = Convert.ToInt32(model.ddv_mod_n_codigo),
                        ddv_n_canais = Convert.ToInt32(model.ddv_n_canais),
                        ddv_c_ip = model.ddv_c_ip,
                        ddv_c_portaServico = model.ddv_c_portaServico,
                        ddv_c_porta = model.ddv_c_porta,
                        ddv_c_portaHTTP = model.ddv_c_portaHTTP,
                        ddv_c_usuario = model.ddv_c_usuario,
                        ddv_c_senha = model.ddv_c_senha,
                        ddv_c_unique = Guid.NewGuid(),
                        ddv_d_atualizado = DateTime.Now,
                        ddv_d_inclusao = DateTime.Now,
                        ddv_d_modificacao = DateTime.Now

                    });
                }
                else
                {
                    var ddv = (from dispositivo in context.tb_ddv_dispositivoDVRCliente where dispositivo.ddv_n_codigo == codeDdv select dispositivo).FirstOrDefault();

                    ddv.ddv_cli_n_codigo = codeCli;
                    ddv.ddv_c_nome = model.ddv_c_nome;
                    ddv.ddv_fab_n_codigo = Convert.ToInt32(model.ddv_fab_n_codigo);
                    ddv.ddv_mod_n_codigo = Convert.ToInt32(model.ddv_mod_n_codigo);
                    ddv.ddv_n_canais = Convert.ToInt32(model.ddv_n_canais);
                    ddv.ddv_c_ip = model.ddv_c_ip;
                    ddv.ddv_c_portaServico = model.ddv_c_portaServico;
                    ddv.ddv_c_porta = model.ddv_c_porta;
                    ddv.ddv_c_portaHTTP = model.ddv_c_portaHTTP;
                    ddv.ddv_c_usuario = model.ddv_c_usuario;
                    ddv.ddv_c_senha = model.ddv_c_senha;
                    ddv.ddv_cli_n_codigo = codeCli;
                    ddv.ddv_d_atualizado = DateTime.Now;
                    ddv.ddv_d_modificacao = DateTime.Now;

                    Update(ddv);
                }
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
            }
            return model;


        }

        public IPagedList<DispositivoCFTVViewModel> GetDispositivoFiltrado(DispositivoCFTVFilterModel filter)
        {
            try
            {
                List<DispositivoCFTVViewModel> listaCFTV = new List<DispositivoCFTVViewModel>();
                var query = (from ddv in Context.tb_ddv_dispositivoDVRCliente
                             orderby ddv.ddv_c_nome
                             select new DispositivoCFTVViewModel
                             {
                                 ddv_n_codigo = ddv.ddv_n_codigo.ToString(),
                                 ddv_cli_n_codigo = ddv.ddv_cli_n_codigo.ToString(),
                                 ddv_c_nome = ddv.ddv_c_nome,
                                 ddv_fab_n_codigo = ddv.ddv_fab_n_codigo.ToString(),
                                 ddv_mod_n_codigo = ddv.ddv_mod_n_codigo.ToString(),
                                 ddv_n_canais = ddv.ddv_n_canais.ToString(),
                                 ddv_c_ip = ddv.ddv_c_ip,
                                 ddv_c_portaServico = ddv.ddv_c_portaServico,
                                 ddv_c_porta = ddv.ddv_c_porta,
                                 ddv_c_portaHTTP = ddv.ddv_c_portaHTTP,
                                 ddv_c_usuario = ddv.ddv_c_usuario,
                                 ddv_descricaoModelo = "Modelo-teste",
                                 ddv_descricaoFabricante = "Intelbras"
                             });

                int codCli = Convert.ToInt32(filter.ddv_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.ddv_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.ddv_cli_n_codigo == null);
                }

                foreach (var item in query)
                {
                    item.ddv_descricaoModelo = ModeloDescricao(item.ddv_mod_n_codigo);
                    listaCFTV.Add(item);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarDispositivo(int id)
        {
            try
            {
                Delete(context.tb_ddv_dispositivoDVRCliente.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public DispositivoCFTVViewModel GetDispositivo(int id)
        {

            return (from ddv in Context.tb_ddv_dispositivoDVRCliente
                    where ddv.ddv_n_codigo == id

                    select new DispositivoCFTVViewModel
                    {
                        ddv_n_codigo = ddv.ddv_n_codigo.ToString(),
                        ddv_cli_n_codigo = ddv.ddv_cli_n_codigo.ToString(),
                        ddv_c_nome = ddv.ddv_c_nome,
                        ddv_fab_n_codigo = ddv.ddv_fab_n_codigo.ToString(),
                        ddv_mod_n_codigo = ddv.ddv_mod_n_codigo.ToString(),
                        ddv_n_canais = ddv.ddv_n_canais.ToString(),
                        ddv_c_ip = ddv.ddv_c_ip,
                        ddv_c_portaServico = ddv.ddv_c_portaServico,
                        ddv_c_porta = ddv.ddv_c_porta,
                        ddv_c_portaHTTP = ddv.ddv_c_portaHTTP,
                        ddv_c_usuario = ddv.ddv_c_usuario,
                        ddv_c_senha = ddv.ddv_c_senha
                    }).FirstOrDefault();
        }

        public DispositivoCFTVViewModel GetDispositivoByLayout(int id)
        {
            var auxDvv = (from ddv in Context.tb_ddv_dispositivoDVRCliente
                        join lay in Context.tb_lay_layout on ddv.ddv_n_codigo equals lay.lay_ddv_n_codigo
                        where lay.lay_n_codigo == id

                        select new DispositivoCFTVViewModel
                        {
                            ddv_n_codigo = ddv.ddv_n_codigo.ToString(),
                            ddv_cli_n_codigo = ddv.ddv_cli_n_codigo.ToString(),
                            ddv_c_nome = ddv.ddv_c_nome,
                            ddv_fab_n_codigo = ddv.ddv_fab_n_codigo.ToString(),
                            ddv_mod_n_codigo = ddv.ddv_mod_n_codigo.ToString(),
                            ddv_n_canais = ddv.ddv_n_canais.ToString(),
                            ddv_c_ip = ddv.ddv_c_ip,
                            ddv_c_portaServico = ddv.ddv_c_portaServico,
                            ddv_c_porta = ddv.ddv_c_porta,
                            ddv_c_portaHTTP = ddv.ddv_c_portaHTTP,
                            ddv_c_usuario = ddv.ddv_c_usuario,
                            ddv_c_senha = ddv.ddv_c_senha
                        }).FirstOrDefault();

            return auxDvv;
        }

        public string ModeloDescricao(string codMod)
        {
            string modelo = "";
            switch (codMod)
            {
                case "1":
                    modelo = "Série 1000";
                    break;
                case "2":
                    modelo = "Série 3000";
                    break;
                case "3":
                    modelo = "Série Tribrida";
                    break;
                default:
                    modelo = "";
                    break;
            }
            return modelo;
        }

        public List<GenericList> ListarDispositivos(int id)
        {
            return (from ddv in Context.tb_ddv_dispositivoDVRCliente
                    where ddv.ddv_cli_n_codigo == id
                    select new GenericList()
                    {
                        value = ddv.ddv_n_codigo.ToString(),
                        text = ddv.ddv_c_nome,

                    }).ToList();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_ddv_dispositivoDVRCliente> lista = new List<tb_ddv_dispositivoDVRCliente>();


                lista = (from ddv in context.tb_ddv_dispositivoDVRCliente where ddv.ddv_cli_n_codigo == null select ddv).OrderBy(x => x.ddv_c_nome).ToList();


                foreach (var item in lista)
                {

                    DeletarDispositivo(item.ddv_n_codigo);
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
                var lista = context.tb_ddv_dispositivoDVRCliente.Where(x => x.ddv_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.ddv_cli_n_codigo = id;
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

    }
}

