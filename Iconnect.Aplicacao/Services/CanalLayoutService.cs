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
    class CanalLayoutService : RepositoryBase<tb_can_canalLayout>, ICanalLayoutService
    {
        private IconnectCoreContext context;

        public CanalLayoutService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(CanalLayoutViewModel model)
        {
            try
            {
                int? codLay = null;
                int codCan = 0;
                int index = 0;

                if (model.can_n_codigo != null && model.can_n_codigo != "")
                {
                    codCan = Convert.ToInt32(model.can_n_codigo);
                }
                if (model.can_lay_n_codigo != null && model.can_lay_n_codigo != "")
                {
                    codLay = Convert.ToInt32(model.can_lay_n_codigo);
                }
                if (model.can_n_index != null)
                {
                    index = Convert.ToInt32(model.can_n_index);
                }

                if (codCan == 0)
                {
                    var can = new tb_can_canalLayout()
                    {
                        can_lay_n_codigo = codLay,
                        can_b_check = Convert.ToBoolean(model.can_b_check),
                        can_n_index = index,
                        can_c_nome = model.can_c_nome,
                        can_c_unique = Guid.NewGuid(),
                        can_d_modificacao = DateTime.Now,
                        can_d_atualizado = DateTime.Now,
                        can_d_inclusao = DateTime.Now,
                    };

                    Insert(can);
                }
                else
                {
                    var can = (from canal in context.tb_can_canalLayout where canal.can_n_codigo == codCan select canal).FirstOrDefault();
                    can.can_lay_n_codigo = codLay;
                    can.can_b_check = Convert.ToBoolean(model.can_b_check);
                    can.can_n_index = index;
                    can.can_c_nome = model.can_c_nome;
                    can.can_d_modificacao = DateTime.Now;
                    can.can_d_atualizado = DateTime.Now;


                    Update(can);
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
                Delete(context.tb_can_canalLayout.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool DeleteCanaisByLayout(int codLay)
        {
            try
            {
                List<tb_can_canalLayout> listaCanais = new List<tb_can_canalLayout>();


                listaCanais = (from can in context.tb_can_canalLayout where can.can_lay_n_codigo == codLay select can).OrderBy(x => x.can_lay_n_codigo).ToList();


                foreach (var item in listaCanais)
                {
                    Deletar(item.can_n_codigo);
                }
                return true;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }
    }
}