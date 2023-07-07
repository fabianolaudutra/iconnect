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
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;

namespace Iconnect.Aplicacao.Services
{
    public class ChavesDeAcessoService : RepositoryBase<tb_cha_chavesDeAcesso>, IChavesDeAcessoService
    {
        private IconnectCoreContext context;

        public ChavesDeAcessoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool DeleteChaveAcesso(int id)
        {
            try
            {
                Delete(context.tb_cha_chavesDeAcesso.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ChavesDeAcessoViewModel SalvarChaveAcesso(ChavesDeAcessoViewModel model)
        {
            try
            {
                if (model != null)
                {
                    tb_cha_chavesDeAcesso tbChave = new tb_cha_chavesDeAcesso
                    {
                        cha_n_codigo = model.cha_n_codigo
                    };

                    if (model.cha_n_codigo == 0)
                    {
                        tbChave.cha_liv_n_codigo = model.cha_liv_n_codigo;
                        tbChave.cha_c_chave = model.cha_c_chave;
                        tbChave.cha_c_unique = Guid.NewGuid();
                        tbChave.cha_d_inclusao = DateTime.Now;
                        tbChave.cha_d_atualizado = DateTime.Now;
                        Insert(tbChave);
                   
                    }
                    else
                    {
                        //REVISAR CAMPOS PARA UPDATE
                        tbChave = (from cha in context.tb_cha_chavesDeAcesso where cha.cha_n_codigo == model.cha_n_codigo select cha).FirstOrDefault();
                        tbChave.cha_c_chave = model.cha_c_chave;
                        tbChave.cha_d_atualizado = DateTime.Now;
                        Update(tbChave);
                    }

                    context.SaveChanges();


                    model.cha_n_codigo = tbChave.cha_n_codigo;
                    return model;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
