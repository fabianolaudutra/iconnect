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
    class LayoutService : RepositoryBase<tb_lay_layout>, ILayoutService
    {
        private IconnectCoreContext context;

        public LayoutService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private ICanalLayoutService _canalLayout;
        public ICanalLayoutService CanalLayout
        {
            get
            {
                if (_canalLayout == null)
                {
                    _canalLayout = new CanalLayoutService(context);
                }
                return _canalLayout;
            }
        }

        public LayoutViewModel InsertOrUpdate(LayoutViewModel model)
        {
            try
            {

                int codLay = 0;
                int? codCli = null;
                int? codUsu = null;
                int codCla;
                int codDdv;
                string canais;


                if (model.lay_cli_n_codigo != null && model.lay_cli_n_codigo != "")
                {
                    codCli = Convert.ToInt32(model.lay_cli_n_codigo);
                }
                if (model.lay_usu_n_codigo != null && model.lay_usu_n_codigo != "")
                {
                    codUsu = Convert.ToInt32(model.lay_usu_n_codigo);
                }

                codCla = Convert.ToInt32(model.lay_cla_n_codigo);
                codDdv = Convert.ToInt32(model.lay_ddv_n_codigo);

                var tbLayout = (from layout in context.tb_lay_layout where layout.lay_cla_n_codigo == codCla && layout.lay_ddv_n_codigo == codDdv select layout).FirstOrDefault();
                if (tbLayout!= null)
                {
                    codLay = tbLayout.lay_n_codigo;
                }

                if (codLay == 0)
                {
                    var novoLayout = new tb_lay_layout()
                    {
                        lay_cla_n_codigo = codCla,
                        lay_ddv_n_codigo = codDdv,
                        lay_cli_n_codigo = codCli,

                        lay_c_nome = model.lay_c_nome,
                        lay_c_exibeLayout = model.lay_c_exibeLayout,
                        lay_c_canais = model.lay_c_canais.ToUpper(),
                        lay_usu_n_codigo = codUsu,
                        lay_c_unique = Guid.NewGuid(),
                        lay_d_atualizado = DateTime.Now,
                        lay_d_inclusao = DateTime.Now,
                        lay_d_modificacao = DateTime.Now
                    };
                    Insert(novoLayout);
                    context.SaveChanges();
                    AdicionarCanais(novoLayout.lay_c_canais, novoLayout.lay_n_codigo);

                }
                else
                {
                    var lay = (from layout in context.tb_lay_layout where layout.lay_cla_n_codigo == codCla && layout.lay_ddv_n_codigo == codDdv select layout).FirstOrDefault();
                    lay.lay_cla_n_codigo = codCla;
                    lay.lay_ddv_n_codigo = codDdv;
                    lay.lay_cli_n_codigo = codCli;
                    lay.lay_c_nome = model.lay_c_nome;
                    lay.lay_c_exibeLayout = model.lay_c_exibeLayout;
                    lay.lay_c_canais = model.lay_c_canais.ToUpper();
                    lay.lay_usu_n_codigo = codUsu;
                    lay.lay_d_atualizado = DateTime.Now;
                    lay.lay_d_modificacao = DateTime.Now;

                    Update(lay);
                    context.SaveChanges();
                    AdicionarCanais(lay.lay_c_canais, lay.lay_n_codigo);


                }
                context.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
            }
            return model;

        }

        public bool Deletar(int id)
        {
            try
            {
                Delete(context.tb_lay_layout.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public object AdicionarCanais(string canais, int codLay)
        {
            Retorno retorno = new Retorno();
            CanalLayout.DeleteCanaisByLayout(codLay);
            try
            {
                foreach (var item in canais.Split('-'))
                {
                    if (item == "") continue;
                    CanalLayoutViewModel model = new CanalLayoutViewModel();
                    model.can_b_check = item.Split('_')[2].ToString();
                    model.can_n_index = Convert.ToInt32(item.Split('_')[1].ToString());
                    model.can_n_codigo = "0";
                    model.can_c_nome = item.Split('_')[3].ToString();
                    model.can_lay_n_codigo = codLay.ToString();

                    CanalLayout.InsertOrUpdate(model);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return retorno;
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_lay_layout> lista = new List<tb_lay_layout>();


                lista = (from lay in context.tb_lay_layout where lay.lay_cli_n_codigo == null select lay).OrderBy(x => x.lay_c_nome).ToList();


                foreach (var item in lista)
                {

                    Deletar(item.lay_n_codigo);
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
                var lista = context.tb_lay_layout.Where(x => x.lay_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.lay_cli_n_codigo = id;
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
