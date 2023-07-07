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
    public class MapeamentoPontoAcessoService : RepositoryBase<tb_mpc_mapeamentoPontoAcesso>, IMapeamentoPontoAcessoService
    {
        private IconnectCoreContext context;

        public MapeamentoPontoAcessoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        public object InsertOrUpdate(MapeamentoPontoAcessoViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                int? codCli = null;
                if (model.mpc_cli_n_codigo != null && model.mpc_cli_n_codigo != "")
                {
                    codCli = Convert.ToInt32(model.mpc_cli_n_codigo);
                }

                int codMpc = Convert.ToInt32(model.mpc_n_codigo);
                int codPta = Convert.ToInt32(model.mpc_pta_n_codigo);
                int codCan = Convert.ToInt32(model.mpc_can_n_codigo);

                var duplicado = VerificaDuplicado(model);
                if (duplicado == true)
                {
                    retorno.status = "duplicado";
                    retorno.conteudo = "Já existe esse ponto de acesso e canal cadastrados.";
                    return retorno;
                }

                if (codMpc == 0)
                {
                    Insert(new tb_mpc_mapeamentoPontoAcesso()
                    {
                        mpc_cli_n_codigo = codCli,
                        mpc_pta_n_codigo = codPta,
                        mpc_can_n_codigo = codCan,
                        mpc_c_tempoGravacao = model.mpc_c_tempoGravacao,
                    });
                }
                else
                {
                    var mpc = (from mapeamento in context.tb_mpc_mapeamentoPontoAcesso where mapeamento.mpc_n_codigo == codMpc select mapeamento).FirstOrDefault();

                    mpc.mpc_cli_n_codigo = codCli;
                    mpc.mpc_pta_n_codigo = codPta;
                    mpc.mpc_can_n_codigo = codCan;
                    mpc.mpc_c_tempoGravacao = model.mpc_c_tempoGravacao;

                    Update(mpc);
                }

                context.SaveChanges();
                retorno.status = "sucesso";
                retorno.conteudo = "Dados salvos com sucesso.";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = "erro";
                retorno.conteudo = "Ocorreu um erro ao salvar os dados.";
                return retorno;
            }
        }

        public bool VerificaDuplicado(MapeamentoPontoAcessoViewModel model)
        {
            var duplicado = (from mpc in context.tb_mpc_mapeamentoPontoAcesso
                             where mpc.mpc_cli_n_codigo == Convert.ToInt32(model.mpc_cli_n_codigo)
                             && mpc.mpc_pta_n_codigo == Convert.ToInt32(model.mpc_pta_n_codigo)
                             && mpc.mpc_can_n_codigo == Convert.ToInt32(model.mpc_can_n_codigo)
                             && mpc.mpc_n_codigo != Convert.ToInt32(model.mpc_n_codigo)
                             select mpc).Count();
            if (duplicado != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IPagedList<MapeamentoPontoAcessoViewModel> GetMapeamentoFiltrado(MapeamentoPontoAcessoFilterModel filter)
        {
            try
            {
                var query = (from mpc in Context.tb_mpc_mapeamentoPontoAcesso
                                 //join con in Context.tb_con_controladora on mpc.mpc_cli_n_codigo equals con.con_cli_n_codigo
                                 //join pta in Context.tb_pta_pontosAcesso on con.con_n_codigo equals pta.pta_con_n_codigo
                                 //join can in Context.tb_can_canalLayout on mpc.mpc_can_n_codigo equals can.can_n_codigo
                                 //join lay in Context.tb_lay_layout on can.can_lay_n_codigo equals lay.lay_n_codigo
                                 //join ddv in Context.tb_ddv_dispositivoDVRCliente on lay.lay_ddv_n_codigo equals ddv.ddv_n_codigo
                             join pta in Context.tb_pta_pontosAcesso on mpc.mpc_pta_n_codigo equals pta.pta_n_codigo
                             join con in Context.tb_con_controladora on pta.pta_con_n_codigo equals con.con_n_codigo
                             join can in Context.tb_can_canalLayout on mpc.mpc_can_n_codigo equals can.can_n_codigo
                             join lay in Context.tb_lay_layout on can.can_lay_n_codigo equals lay.lay_n_codigo
                             join ddv in Context.tb_ddv_dispositivoDVRCliente on lay.lay_ddv_n_codigo equals ddv.ddv_n_codigo
                             orderby con.con_c_nome
                             select new MapeamentoPontoAcessoViewModel
                             {
                                 mpc_n_codigo = mpc.mpc_n_codigo.ToString(),
                                 mpc_cli_n_codigo = mpc.mpc_cli_n_codigo.ToString(),
                                 mpc_pta_n_codigo = mpc.mpc_pta_n_codigo.ToString(),
                                 mpc_can_n_codigo = mpc.mpc_can_n_codigo.ToString(),
                                 mpc_c_tempoGravacao = mpc.mpc_c_tempoGravacao,
                                 //mpc_descricaoPonto = mpc.mpc_pta_n_codigo.ToString(),
                                 //mpc_descricaoCanal = mpc.mpc_can_n_codigo.ToString(),

                                 mpc_descricaoPonto = con.con_c_nome + "/" + pta.pta_c_nomePonto,
                                 mpc_descricaoCanal = lay.lay_c_nome + "/" + ddv.ddv_c_nome + " - " + can.can_c_nome,


                             });


                int codCli = Convert.ToInt32(filter.mpc_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.mpc_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.mpc_cli_n_codigo == null);
                }


                return query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletarMapeamento(int id)
        {
            try
            {
                Delete(context.tb_mpc_mapeamentoPontoAcesso.Find(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public MapeamentoPontoAcessoViewModel GetMapeamento(int id)
        {

            return (from mpc in Context.tb_mpc_mapeamentoPontoAcesso
                    where mpc.mpc_n_codigo == id

                    select new MapeamentoPontoAcessoViewModel
                    {
                        mpc_n_codigo = mpc.mpc_n_codigo.ToString(),
                        mpc_cli_n_codigo = mpc.mpc_cli_n_codigo.ToString(),
                        mpc_pta_n_codigo = mpc.mpc_pta_n_codigo.ToString(),
                        mpc_can_n_codigo = mpc.mpc_can_n_codigo.ToString(),
                        mpc_c_tempoGravacao = mpc.mpc_c_tempoGravacao,

                    }).FirstOrDefault();
        }

        public bool ExcluirTemporarios()
        {
            try
            {
                List<tb_mpc_mapeamentoPontoAcesso> lista = new List<tb_mpc_mapeamentoPontoAcesso>();


                lista = (from mpc in context.tb_mpc_mapeamentoPontoAcesso where mpc.mpc_cli_n_codigo == null select mpc).OrderBy(x => x.mpc_n_codigo).ToList();


                foreach (var item in lista)
                {

                    DeletarMapeamento(item.mpc_n_codigo);
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
                var lista = context.tb_mpc_mapeamentoPontoAcesso.Where(x => x.mpc_cli_n_codigo == null).ToList();

                if (lista.Count() > 0)
                {
                    foreach (var item in lista)
                    {
                        item.mpc_cli_n_codigo = id;
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
