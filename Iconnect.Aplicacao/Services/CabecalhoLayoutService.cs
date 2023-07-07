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
using Microsoft.EntityFrameworkCore;

namespace Iconnect.Aplicacao.Services
{
    class CabecalhoLayoutService : RepositoryBase<tb_cla_cabecalhoLayout>, ICabecalhoLayoutService
    {
        private IconnectCoreContext context;

        public CabecalhoLayoutService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }
        private ILayoutService _layout;
        public ILayoutService Layout
        {
            get
            {
                if (_layout == null)
                {
                    _layout = new LayoutService(context);
                }
                return _layout;
            }
        }
        private IClienteService _cliente;
        public IClienteService Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteService(context);
                }
                return _cliente;
            }
        }

        public List<GenericList> ListarLayout(int codigo)
        {
            List<GenericList> lista = (from cla in Context.tb_cla_cabecalhoLayout
                                       where cla.cla_cli_n_codigo == codigo && cla.cla_c_exibirem.Contains("GUARD")
                                       select new GenericList()
                                       {
                                           value = cla.cla_n_codigo.ToString(),
                                           text = cla.cla_c_nome,

                                       }).ToList();
            return lista;
        }

        public object InsertOrUpdate(CabecalhoLayoutViewModel model)
        {
            try
            {
                int? codeCli = null;
                if (model.cla_cli_n_codigo != null && model.cla_cli_n_codigo != "")
                {
                    codeCli = Convert.ToInt32(model.cla_cli_n_codigo);
                }

                int codeCla = Convert.ToInt32(model.cla_n_codigo);
                if (codeCla == 0)
                {
                    var novoCabecalho = new tb_cla_cabecalhoLayout()
                    {
                        cla_cli_n_codigo = codeCli,
                        cla_n_codigo = codeCla,
                        cla_c_nome = model.cla_c_nome,
                        cla_c_exibirem = model.cla_c_exibirem,
                        cla_c_unique = Guid.NewGuid(),
                        cla_d_atualizado = DateTime.Now,
                        cla_d_inclusao = DateTime.Now,
                    };

                    Insert(novoCabecalho);
                    context.SaveChanges();

                    model.Layout.lay_cla_n_codigo = novoCabecalho.cla_n_codigo.ToString();
                    Layout.InsertOrUpdate(model.Layout);

                }
                else
                {
                    var Cabecalho = (from layout in context.tb_cla_cabecalhoLayout where layout.cla_n_codigo == codeCla select layout).FirstOrDefault();
                    Cabecalho.cla_cli_n_codigo = codeCli;
                    Cabecalho.cla_cli_n_codigo = codeCli;
                    Cabecalho.cla_n_codigo = codeCla;
                    Cabecalho.cla_c_nome = model.cla_c_nome;
                    Cabecalho.cla_c_exibirem = model.cla_c_exibirem;
                    Cabecalho.cla_d_atualizado = DateTime.Now;

                    Update(Cabecalho);
                    context.SaveChanges();

                    model.Layout.lay_cla_n_codigo = Cabecalho.cla_n_codigo.ToString();
                    Layout.InsertOrUpdate(model.Layout);

                }

                return model;
            }
            catch (Exception ex)
            {
            }

            return model;


        }

        public IPagedList<CabecalhoLayoutViewModel> GetLayoutFiltrado(CabecalhoLayoutFilterModel filter)
        {
            try
            {
                var query = (from cla in Context.tb_cla_cabecalhoLayout
                             orderby cla.cla_c_nome
                             select new CabecalhoLayoutViewModel
                             {
                                 cla_n_codigo = cla.cla_n_codigo.ToString(),
                                 cla_cli_n_codigo = cla.cla_cli_n_codigo.ToString(),
                                 cla_c_nome = cla.cla_c_nome,
                                 cla_c_exibirem = cla.cla_c_exibirem,
                             });

                int codCli = Convert.ToInt32(filter.cla_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.cla_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.cla_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarLayout(int id)
        {
            try
            {
                int idCliente = context.tb_cla_cabecalhoLayout.Find(id).cla_cli_n_codigo.Value;
                tb_cli_cliente tbCli = (from cli in context.tb_cli_cliente where cli.cli_n_codigo == idCliente select cli).FirstOrDefault();  
                tbCli.cli_lay_n_codigo = null;
                Cliente.Update(tbCli);
               
                Delete(context.tb_cla_cabecalhoLayout.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public CabecalhoLayoutViewModel GetLayout(int id)
        {

            return (from cla in Context.tb_cla_cabecalhoLayout
                    join lay in context.tb_lay_layout on cla.cla_n_codigo equals lay.lay_cla_n_codigo
                    where cla.cla_n_codigo == id 

                    select new CabecalhoLayoutViewModel
                    {
                        cla_n_codigo = cla.cla_n_codigo.ToString(),
                        cla_cli_n_codigo = cla.cla_cli_n_codigo.ToString(),
                        cla_c_nome = cla.cla_c_nome,
                        cla_c_exibirem = cla.cla_c_exibirem,
                        lay_ddv_n_codigo = lay.lay_ddv_n_codigo.ToString(),
                        lay_n_codigo = lay.lay_n_codigo.ToString(),

                    }).FirstOrDefault();
        }

        public List<CabecalhoLayoutViewModel> GetLayoutPadrao(int id)
        {
            List<CabecalhoLayoutViewModel> listCab = (from cla in Context.tb_cla_cabecalhoLayout
                           where cla.cla_cli_n_codigo == id

                           select new CabecalhoLayoutViewModel
                           {
                               cla_n_codigo = cla.cla_n_codigo.ToString(),
                               cla_c_nome = cla.cla_c_nome,

                           }).ToList();


            return listCab;
        }
        public List<CabecalhoLayoutViewModel> GetLayoutPadraoFiltered(int id)
        {
            var cabec = (from lay in Context.tb_lay_layout where lay.lay_n_codigo == id select lay.lay_cla_n_codigo).FirstOrDefault();
            List<CabecalhoLayoutViewModel> listCab = (from cla in Context.tb_cla_cabecalhoLayout
                                                      where cla.cla_n_codigo == cabec

                                                      select new CabecalhoLayoutViewModel
                                                      {
                                                          cla_n_codigo = cla.cla_n_codigo.ToString(),
                                                          cla_c_nome = cla.cla_c_nome,

                                                      }).ToList();
            return listCab;
        }
        //public List<GenericList> ListarCanais(int codigo)
        //{
        //    List<GenericList> lista = (from can in Context.tb_can_canalLayout
        //                               where can.can_lay_n_codigo == codigo
        //                               select new GenericList()
        //                               {
        //                                   value = can.can_n_codigo.ToString(),
        //                                   text = can.can_c_nome,

        //                               }).ToList();
        //    return lista;
        //}

        public List<CanalLayoutViewModel> ListarDispositivoCanal(int codigo)
        {
            int? codLay = codigo;

            if (codigo == 0)
            {
                codLay = null;
            }
            List<CanalLayoutViewModel> lista = (from can in Context.tb_can_canalLayout
                                                join lay in Context.tb_lay_layout on can.can_lay_n_codigo equals lay.lay_n_codigo
                                                join ddv in Context.tb_ddv_dispositivoDVRCliente on lay.lay_ddv_n_codigo equals ddv.ddv_n_codigo

                                                select new CanalLayoutViewModel()
                                                {
                                                    can_c_nome = can.can_c_nome,
                                                    can_n_codigo = can.can_n_codigo.ToString(),
                                                    can_n_index = Convert.ToInt32(can.can_n_index),
                                                    nomeDispositivo = ddv.ddv_c_nome,
                                                    codDispositivo = ddv.ddv_n_codigo.ToString(),
                                                    lay_cli_n_codigo = lay.lay_cli_n_codigo.ToString()


                                                }).ToList();

            if (codigo != 0)
            {
                lista = lista.Where(w => w.lay_cli_n_codigo == codLay.ToString()).OrderBy(x => x.can_n_index).ToList();
            }

            List<CanalLayoutViewModel> listaAux = new List<CanalLayoutViewModel>();
            List<CanalLayoutViewModel> listaTemp = new List<CanalLayoutViewModel>();


            foreach (var item in lista)
            {
                //    string ddv_n_codigo = row["ddv_n_codigo"].ToString();
                //    string can_n_index = row["can_n_index"].ToString();

                //int repetido = dtAux.Select("ddv_n_codigo= '" + ddv_n_codigo + "' and can_n_index= '" + can_n_index + "' ").Count();
                int repetido = listaAux.Where(w => w.codDispositivo == item.codDispositivo && w.can_n_index == item.can_n_index).ToList().Count();

                if (repetido == 0)
                {
                    item.can_c_nome = "Canal " + item.can_n_index;
                    listaAux.Add(item);
                }
            }
            listaAux = listaAux.OrderBy(x => x.can_n_index).ToList();

            return listaAux;

        }


        public List<GenericList> ListarCanais(int codigo)
        {
            List<GenericList> lista = (from can in Context.tb_can_canalLayout
                                       join lay in Context.tb_lay_layout on can.can_lay_n_codigo equals lay.lay_n_codigo
                                       join ddv in Context.tb_ddv_dispositivoDVRCliente on lay.lay_ddv_n_codigo equals ddv.ddv_n_codigo
                                       where can.can_b_check.Value && lay.lay_cli_n_codigo == codigo
                                       select new GenericList()
                                       {
                                           value = can.can_n_codigo.ToString(),
                                           text = lay.lay_c_nome + "/" + ddv.ddv_c_nome + " - " + can.can_c_nome,

                                       }).ToList();
            return lista;
        }


        public List<CanalLayoutViewModel> ListarCanaisByLayout(int codigo)
        {
            //int IdCabecalho = (from lay in Context.tb_lay_layout where lay.lay_n_codigo == codigo select lay).FirstOrDefault().lay_cla_n_codigo.Value;
            //List<int> IdsLayout = (from lay in Context.tb_lay_layout where lay.lay_cla_n_codigo == IdCabecalho select lay.lay_n_codigo).ToList();

            List<CanalLayoutViewModel> lista = (from can in Context.tb_can_canalLayout

                                                where can.can_lay_n_codigo == codigo   //IdsLayout.Contains(can.can_lay_n_codigo.Value)
                                                select new CanalLayoutViewModel()
                                                {
                                                    can_b_check = can.can_b_check.ToString(),
                                                    can_c_nome = can.can_c_nome,
                                                    can_n_index = Convert.ToInt32(can.can_n_index)

                                                }).ToList();
            return lista;
        }
        public List<CanalLayoutViewModel> ListarCanaisByDispositivo(CabecalhoLayoutViewModel model)
        {
            int idCabec = Convert.ToInt32(model.cla_n_codigo);
            int idDisp = Convert.ToInt32(model.lay_ddv_n_codigo);
            List<int> IdsLayout = (from lay in Context.tb_lay_layout where lay.lay_cla_n_codigo == idCabec && lay.lay_ddv_n_codigo == idDisp select lay.lay_n_codigo).ToList();

            List<CanalLayoutViewModel> lista = (from can in Context.tb_can_canalLayout

                                                where IdsLayout.Contains(can.can_lay_n_codigo.Value)   //IdsLayout.Contains(can.can_lay_n_codigo.Value)
                                                select new CanalLayoutViewModel()
                                                {
                                                    can_b_check = can.can_b_check.ToString(),
                                                    can_c_nome = can.can_c_nome,
                                                    can_n_index = Convert.ToInt32(can.can_n_index)

                                                }).ToList();
            return lista;
        }
        public List<CabecalhoLayoutViewModel> GetLayoutGuardByCliente(int cli_n_codigo)
        {
            int cla_n_codigo = 0;

            //Executar aplicação cameras no servidor
            context.Database.ExecuteSqlRaw("exec [EXECUTAJOBREBUILDSTREAM] '"+ cli_n_codigo.ToString() + "'");


            //VERIFICAMOS O ÚLTIMO DISPARO PENDENTE DESTE CLIENTE DE UMA ZONA COM MAPEAMENTO DE CAMERAS
            var monitoramento = (from mon in Context.tb_mon_monitoramento
                                 join zoc in Context.tb_zoc_zoneamentoCliente on mon.mon_zoc_n_codigo equals zoc.zoc_n_codigo
                                 where mon.mon_cli_n_codigo == cli_n_codigo && mon.mon_stm_n_codigo.Value == 1 && mon.mon_zoc_n_codigo != null
                                 orderby mon.mon_n_codigo descending

                                 select new MonitoramentoViewModel
                                 {
                                     mon_n_codigo = mon.mon_n_codigo.ToString(),
                                     mon_zoc_n_codigo = zoc.zoc_cla_n_codigo.ToString(),
                                 }).FirstOrDefault();

            if (monitoramento != null && !string.IsNullOrEmpty(monitoramento.mon_zoc_n_codigo))
            {
                cla_n_codigo = Convert.ToInt32(monitoramento.mon_zoc_n_codigo);
               
                //Valida se cabeçalho existe
                var cabecalho = (from cla in Context.tb_cla_cabecalhoLayout
                                 where cla.cla_n_codigo == cla_n_codigo && cla.cla_c_exibirem.Contains("CONNECT GUARD")
                                 orderby cla.cla_n_codigo ascending

                                 select new CabecalhoLayoutViewModel
                                 {
                                     cla_n_codigo = cla.cla_n_codigo.ToString()
                                 }).FirstOrDefault();

                if (cabecalho == null)
                {
                    cla_n_codigo = 0;
                }

            }

            //VERIFICAMOS SE LAYOUT FOI ENCONTRADO
            if (cla_n_codigo == 0)
            {
                //CASO AINDA NÃO TENHA ENCONTRADO, PEGAMOS O PRIMEIRO LAYOUT CADASTRADO PARA ESTE CLIENTE
                var cabecalho = (from cla in Context.tb_cla_cabecalhoLayout
                                 join lay in Context.tb_lay_layout on cla.cla_n_codigo equals lay.lay_cla_n_codigo
                                 join can in Context.tb_can_canalLayout on lay.lay_n_codigo equals can.can_lay_n_codigo
                                 where cla.cla_cli_n_codigo == cli_n_codigo && cla.cla_c_exibirem.Contains("CONNECT GUARD") && can.can_b_check == true
                                 orderby cla.cla_n_codigo ascending

                                 select new CabecalhoLayoutViewModel
                                 {
                                     cla_n_codigo = cla.cla_n_codigo.ToString()
                                 }).FirstOrDefault();

                if (cabecalho != null)
                {
                    cla_n_codigo = Convert.ToInt32(cabecalho.cla_n_codigo);
                }
            }

            //PORTA COMUNICAÇÃO
            string _porta = "8080";
            var auxPorta = Context.tb_por_portasStream.Where(x => x.por_cli_n_codigo == cli_n_codigo).FirstOrDefault();
            if(auxPorta != null)
            {
                _porta = auxPorta.por_n_porta.ToString();
            }

            //CASO AINDA NÃO TENHA ENCONTRADO, PEGAMOS O PRIMEIRO LAYOUT CADASTRADO PARA ESTE CLIENTE
            var lstCabecalho = (from cla in Context.tb_cla_cabecalhoLayout
                                    join lay in Context.tb_lay_layout on cla.cla_n_codigo equals lay.lay_cla_n_codigo
                                    join can in Context.tb_can_canalLayout on lay.lay_n_codigo equals can.can_lay_n_codigo
                                    where cla.cla_n_codigo == cla_n_codigo && cla.cla_c_exibirem.Contains("CONNECT GUARD") && can.can_b_check == true
                                    orderby can.can_n_index ascending
                                    select new CabecalhoLayoutViewModel
                                    {
                                        cla_n_codigo = cla.cla_n_codigo.ToString(),
                                        lay_n_codigo = lay.lay_n_codigo.ToString(),
                                        lay_c_nome = lay.lay_c_nome,
                                        lay_ddv_n_codigo = lay.lay_ddv_n_codigo.ToString(),
                                        can_n_index = can.can_n_index.ToString(),
                                        cla_id_video = "h5Video_" + (lay.lay_ddv_n_codigo.ToString()) + "_" + can.can_n_index.ToString(),
                                        porta = _porta
                                    }).ToList();

            return lstCabecalho;
        }

        public List<CabecalhoLayoutViewModel> GetLayoutGuardByLayout(int id)
        {
            //PORTA COMUNICAÇÃO
            string _porta = "8080";
            var auxLay = Context.tb_lay_layout.Where(x => x.lay_n_codigo == id).FirstOrDefault();
            if(auxLay != null)
            {
                var auxCli = auxLay.lay_cli_n_codigo;
                var auxPorta = Context.tb_por_portasStream.Where(x => x.por_cli_n_codigo == auxCli).FirstOrDefault();
                if (auxPorta != null)
                {
                    _porta = auxPorta.por_n_porta.ToString();
                }
            }

            var lstCabecalho = (from cla in Context.tb_cla_cabecalhoLayout
                                join lay in Context.tb_lay_layout on cla.cla_n_codigo equals lay.lay_cla_n_codigo
                                join can in Context.tb_can_canalLayout on lay.lay_n_codigo equals can.can_lay_n_codigo
                                where lay.lay_n_codigo == id && can.can_b_check == true
                                orderby can.can_n_index ascending
                                select new CabecalhoLayoutViewModel
                                {
                                    cla_n_codigo = cla.cla_n_codigo.ToString(),
                                    cla_cli_n_codigo = cla.cla_cli_n_codigo.ToString(),
                                    lay_n_codigo = lay.lay_n_codigo.ToString(),
                                    lay_c_nome = lay.lay_c_nome,
                                    lay_ddv_n_codigo = lay.lay_ddv_n_codigo.ToString(),
                                    can_n_index = can.can_n_index.ToString(),
                                    cla_id_video = "h5Video_" + (lay.lay_ddv_n_codigo.ToString()) + "_" + can.can_n_index.ToString(),
                                    porta = _porta
                                }).ToList();

            if(lstCabecalho.Count > 0)
            {
                var cabecalho = lstCabecalho.FirstOrDefault();
                if(cabecalho != null)
                {
                    //Executar aplicação cameras no servidor
                    //context.Database.ExecuteSqlRaw("exec [EXECUTAJOBREBUILDSTREAM] '" + cabecalho.cla_cli_n_codigo + "'");
                }
            }

            return lstCabecalho;
        }

        public IEnumerable<CabecalhoLayoutViewModel> GetLayoutsGuardModalByCliente(int cli_n_codigo)
        {
            var lstCabecalho = (from cla in Context.tb_cla_cabecalhoLayout
                                join lay in Context.tb_lay_layout on cla.cla_n_codigo equals lay.lay_cla_n_codigo
                                join can in Context.tb_can_canalLayout on lay.lay_n_codigo equals can.can_lay_n_codigo
                                where cla.cla_cli_n_codigo == cli_n_codigo && cla.cla_c_exibirem.Contains("CONNECT GUARD") && can.can_b_check == true
                                orderby lay.lay_c_nome ascending
                                select new CabecalhoLayoutViewModel
                                {
                                    cla_n_codigo = cla.cla_n_codigo.ToString(),
                                    lay_n_codigo = lay.lay_n_codigo.ToString(),
                                    lay_c_nome = lay.lay_c_nome,
                                    lay_ddv_n_codigo = lay.lay_ddv_n_codigo.ToString(),
                                    can_n_index = can.can_n_index.ToString(),
                                    cla_id_video = "h5Video_" + (lay.lay_ddv_n_codigo.ToString()) + "_" + can.can_n_index.ToString()
                                }).ToList().GroupBy(x => x.lay_c_nome).Select(y => y.First());

            return lstCabecalho;
        }

        public IEnumerable<CabecalhoLayoutViewModel> GetLayoutsViewModalByCliente(int cli_n_codigo)
        {
            var lstCabecalho = (from cla in Context.tb_cla_cabecalhoLayout
                                join lay in Context.tb_lay_layout on cla.cla_n_codigo equals lay.lay_cla_n_codigo
                                join can in Context.tb_can_canalLayout on lay.lay_n_codigo equals can.can_lay_n_codigo
                                where cla.cla_cli_n_codigo == cli_n_codigo && !cla.cla_c_exibirem.Contains("CONNECT GUARD") && cla.cla_c_exibirem.Contains("CONNECT VIEW") && can.can_b_check == true
                                orderby lay.lay_c_nome ascending
                                select new CabecalhoLayoutViewModel
                                {
                                    cla_n_codigo = cla.cla_n_codigo.ToString(),
                                    lay_n_codigo = lay.lay_n_codigo.ToString(),
                                    lay_c_nome = lay.lay_c_nome,
                                    lay_ddv_n_codigo = lay.lay_ddv_n_codigo.ToString(),
                                    can_n_index = can.can_n_index.ToString(),
                                    cla_id_video = "h5Video_" + (lay.lay_ddv_n_codigo.ToString()) + "_" + can.can_n_index.ToString()
                                }).ToList().GroupBy(x => x.lay_c_nome).Select(y => y.First());

            return lstCabecalho;
        }


        //    public List<GenericList> ListarCanais(int codigo)
        //    {
        //        List<GenericList> lista = (from can in Context.tb_can_canalLayout
        //                                   where can.can_lay_n_codigo == codigo
        //                                   select new GenericList()
        //                                   {
        //                                       value = can.can_n_codigo.ToString(),
        //                                       text = can.can_c_nome,

        //                                   }).ToList();
        //        return lista;
        //    }
        //    @foreach(var item in Model.tb_lay_layout.OrderBy(x => x.lay_c_nome).ToList().Select(x => x.tb_can_canalLayout).ToList())

        //    @foreach(var item in db.tb_can_canalLayout.Where(x => x.can_b_check.Value && x.tb_lay_layout.lay_cli_n_codigo == Model.cli_n_codigo).OrderBy(x => new { x.tb_lay_layout.lay_c_nome, x.can_c_nome
        //}).ToList())

    }
}
