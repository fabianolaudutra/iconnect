using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using Microsoft.Data.SqlClient;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    public class CatalogoService : RepositoryBase<tb_cal_catalogo>, ICatalogoService
    {

        private readonly IconnectCoreContext context;

        public CatalogoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IEmailService _email;
        public IEmailService Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailService(context);
                }
                return _email;
            }
        }

        private IFotoService _fotoService;
        public IFotoService FotoService
        {
            get
            {
                if (_fotoService == null)
                {
                    _fotoService = new FotoService(context);
                }
                return _fotoService;
            }
        }

        private ISalaComercialCatalogoService _salaComercialCatalogoService;
        public ISalaComercialCatalogoService SalaComercialCatalogoService
        {
            get
            {
                if (_salaComercialCatalogoService == null)
                {
                    _salaComercialCatalogoService = new SalaComercialCatalogoService(context);
                }
                return _salaComercialCatalogoService;
            }
        }

        public bool DeletarCatalogo(int id)
        {
            try
            {
                var cat = context.tb_cal_catalogo.Find(id);
                if (cat != null)
                {
                    if (cat.cal_fot_n_codigo != null)
                    {
                        FotoService.DeletarFoto(cat.cal_fot_n_codigo ?? 0);
                    }

                    Delete(cat);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool DeletarCatalogoBuyGrupoFamiliar(int idGrupo)
        {
            try
            {
                List<tb_cal_catalogo> catalogos = context.tb_cal_catalogo.Where(x => x.cal_grf_n_codigo == idGrupo).ToList();
                if (catalogos.Count() > 0)
                {
                    foreach (var item in catalogos)
                    {
                        Delete(item);
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public CatalogoViewModel GetCatalogo(int id)
        {
            return (from cal in Context.tb_cal_catalogo
                    join scc in context.tb_scc_subCategoriaCatalogo on cal.cal_scc_n_codigo equals scc.scc_n_codigo
                    join cat in context.tb_cat_categoriaCatalogo on cal.cal_cat_n_codigo equals cat.cat_n_codigo
                    join lccTorre in context.tb_lcc_localidadeCliente on cal.cal_lcc_n_codigoTorre equals lccTorre.lcc_n_codigo
                    join lccSala in context.tb_lcc_localidadeCliente on cal.cal_lcc_n_codigoNumero equals lccSala.lcc_n_codigo

                    where cal.cal_n_codigo == id

                    select new CatalogoViewModel
                    {
                        cal_n_codigo = cal.cal_n_codigo.ToString(),
                        cal_cat_n_codigo = cal.cal_cat_n_codigo.ToString(),
                        cal_scc_n_codigo = cal.cal_scc_n_codigo.ToString(),
                        cal_cli_n_codigo = cal.cal_cli_n_codigo.ToString(),
                        cal_lcc_n_codigoTorre = lccTorre.lcc_n_codigo.ToString(),
                        cal_lcc_n_codigoNumero = lccSala.lcc_n_codigo.ToString(),
                        cal_b_ativo = cal.cal_b_ativo == true ? "ATIVO" : "INATIVO",
                        cal_c_nome = cal.cal_c_nome,
                        cal_c_descricao = cal.cal_c_descricao,
                        cal_c_capa = cal.cal_c_capa == null ? "" : cal.cal_c_capa,
                        cal_c_logoMarca = cal.cal_c_logoMarca == null ? "" : cal.cal_c_logoMarca,
                        cal_c_especialidade = cal.cal_c_especialidade,
                        cal_c_telefonePrincipal = cal.cal_c_telefonePrincipal,
                        cal_c_telefoneSecundario = cal.cal_c_telefoneSecundario,
                        cal_c_email = cal.cal_c_email,
                        cal_c_website = cal.cal_c_website,
                        cal_c_redeSocial1 = cal.cal_c_redeSocial1,
                        cal_c_redeSocial2 = cal.cal_c_redeSocial2,
                        cal_cat_c_nome = cat.cat_c_nome,
                        cal_scc_c_nome = scc.scc_c_nome,
                        cal_cat_b_solicitarEspecialidade = cat.cat_b_solicitarEspecialidade.ToString(),
                        cal_lcc_n_torre_nome = lccTorre.lcc_c_descricao,
                        cal_lcc_n_sala_nome = lccSala.lcc_c_descricao,
                    }).FirstOrDefault();
        }

        public CatalogoViewModel GetCatalogoGrupo(int id)
        {
            return (from cal in Context.tb_cal_catalogo
                    join scc in context.tb_scc_subCategoriaCatalogo on cal.cal_scc_n_codigo equals scc.scc_n_codigo
                    join cat in context.tb_cat_categoriaCatalogo on cal.cal_cat_n_codigo equals cat.cat_n_codigo
                    where cal.cal_n_codigo == id
                    select new CatalogoViewModel
                    {
                        cal_n_codigo = cal.cal_n_codigo.ToString(),
                        cal_cat_n_codigo = cal.cal_cat_n_codigo.ToString(),
                        cal_scc_n_codigo = cal.cal_scc_n_codigo.ToString(),
                        cal_cli_n_codigo = cal.cal_cli_n_codigo.ToString(),
                        cal_b_ativo = cal.cal_b_ativo == true ? "ATIVO" : "INATIVO",
                        cal_c_nome = cal.cal_c_nome,
                        cal_c_descricao = cal.cal_c_descricao,
                        cal_c_capa = cal.cal_c_capa == null ? "" : cal.cal_c_capa,
                        cal_c_logoMarca = cal.cal_c_logoMarca == null ? "" : cal.cal_c_logoMarca,
                        cal_c_especialidade = cal.cal_c_especialidade,
                        cal_c_telefonePrincipal = cal.cal_c_telefonePrincipal,
                        cal_c_telefoneSecundario = cal.cal_c_telefoneSecundario,
                        cal_c_email = cal.cal_c_email,
                        cal_c_website = cal.cal_c_website,
                        cal_c_redeSocial1 = cal.cal_c_redeSocial1,
                        cal_c_redeSocial2 = cal.cal_c_redeSocial2,
                        cal_cat_c_nome = cat.cat_c_nome,
                        cal_scc_c_nome = scc.scc_c_nome,
                        cal_cat_b_solicitarEspecialidade = cat.cat_b_solicitarEspecialidade.ToString(),
                        exibeEspecialidade = cat.cat_b_solicitarEspecialidade,
                        cal_fot_n_codigo = cal.cal_fot_n_codigo,
                        cal_n_especialista = cal.cal_n_especialista.ToString(),
                        cal_logo_n_codigo = cal.cal_logo_n_codigo.ToString(),
                    }).FirstOrDefault();
        }

        public List<CatalogoViewModel> GetCatalogoByGrupo(int idGrupo)
        {
            return (from cal in Context.tb_cal_catalogo
                    join scc in context.tb_scc_subCategoriaCatalogo on cal.cal_scc_n_codigo equals scc.scc_n_codigo
                    where cal.cal_grf_n_codigo == idGrupo && cal.cal_b_ativo == true
                    select new CatalogoViewModel
                    {
                        cal_n_codigo = cal.cal_n_codigo.ToString(),
                        cal_scc_c_nome = scc.scc_c_nome,
                    }).ToList();
        }

        public IPagedList<CatalogoViewModel> GetCatalogoFiltrado(CatalogoFilterModel filter)
        {
            try
            {
                var query = (from cal in context.tb_cal_catalogo
                             join scc in context.tb_scc_subCategoriaCatalogo on cal.cal_scc_n_codigo equals scc.scc_n_codigo
                             join cat in context.tb_cat_categoriaCatalogo on cal.cal_cat_n_codigo equals cat.cat_n_codigo
                             select new CatalogoViewModel
                             {
                                 cal_n_codigo = cal.cal_n_codigo.ToString(),
                                 cal_cat_n_codigo = cal.cal_cat_n_codigo.ToString(),
                                 cal_scc_n_codigo = cal.cal_scc_n_codigo.ToString(),
                                 cal_cli_n_codigo = cal.cal_cli_n_codigo.ToString(),
                                 cal_lcc_n_codigoTorre = cal.cal_lcc_n_codigoTorre.ToString(),
                                 cal_lcc_n_codigoNumero = cal.cal_lcc_n_codigoNumero.ToString(),
                                 cal_b_ativo = cal.cal_b_ativo == true ? "ATIVO" : "INATIVO",
                                 cal_c_nome = cal.cal_c_nome,
                                 cal_c_descricao = cal.cal_c_descricao,
                                 cal_c_capa = cal.cal_c_capa == null ? "" : cal.cal_c_capa,
                                 cal_c_logoMarca = cal.cal_c_logoMarca == null ? "" : cal.cal_c_logoMarca,
                                 cal_c_especialidade = cal.cal_c_especialidade,
                                 cal_c_telefonePrincipal = cal.cal_c_telefonePrincipal,
                                 cal_c_telefoneSecundario = cal.cal_c_telefoneSecundario,
                                 cal_c_email = cal.cal_c_email,
                                 cal_c_website = cal.cal_c_website,
                                 cal_c_redeSocial1 = cal.cal_c_redeSocial1,
                                 cal_c_redeSocial2 = cal.cal_c_redeSocial2,
                                 cal_cat_c_nome = cat.cat_c_nome,
                                 cal_scc_c_nome = scc.scc_c_nome,
                                 cal_c_status = cal.cal_c_status,
                                 cal_grf_n_codigo = cal.cal_grf_n_codigo.ToString(),
                                 cal_c_descricaoReprovado = cal.cal_c_descricaoReprovado,
                             });

                int codCli = Convert.ToInt32(filter.cal_cli_n_codigo_filter);
                if (codCli > 0)
                {
                    query = query.Where(w => w.cal_cli_n_codigo.Equals(codCli.ToString()));
                }
                else
                {
                    query = query.Where(w => w.cal_cli_n_codigo == null);
                }
                return query.OrderBy(x => x.cal_cat_c_nome).OrderBy(x => x.cal_scc_c_nome).ThenBy(x => x.cal_c_nome).ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IPagedList<CatalogoViewModel> GetFilteredByGrupoFamiliar(CatalogoFilterModel filter)
        {
            try
            {
                int codGrf = Convert.ToInt32(filter.cal_grf_n_codigo_filter);
                var query = (from cal in context.tb_cal_catalogo
                             join grf in context.tb_grf_grupoFamiliar on cal.cal_grf_n_codigo equals grf.grf_n_codigo
                             join scc in context.tb_scc_subCategoriaCatalogo on cal.cal_scc_n_codigo equals scc.scc_n_codigo
                             join cat in context.tb_cat_categoriaCatalogo on cal.cal_cat_n_codigo equals cat.cat_n_codigo
                             join tempFunc in context.tb_mor_Morador on cal.cal_n_especialista equals tempFunc.mor_n_codigo into tempFuncionario
                             from func in tempFuncionario.DefaultIfEmpty()
                             where cal.cal_grf_n_codigo == codGrf
                             select new CatalogoViewModel
                             {
                                 cal_n_codigo = cal.cal_n_codigo.ToString(),
                                 cal_cat_n_codigo = cal.cal_cat_n_codigo.ToString(),
                                 cal_scc_n_codigo = cal.cal_scc_n_codigo.ToString(),
                                 cal_cli_n_codigo = cal.cal_cli_n_codigo.ToString(),
                                 cal_lcc_n_codigoTorre = cal.cal_lcc_n_codigoTorre.ToString(),
                                 cal_lcc_n_codigoNumero = cal.cal_lcc_n_codigoNumero.ToString(),
                                 cal_b_ativo = cal.cal_b_ativo == true ? "ATIVO" : "INATIVO",
                                 cal_c_nome = grf.grf_c_nomeSalaComercial,
                                 cal_c_descricao = cal.cal_c_descricao,
                                 cal_c_capa = cal.cal_c_capa == null ? "" : cal.cal_c_capa,
                                 cal_c_logoMarca = cal.cal_c_logoMarca == null ? "" : cal.cal_c_logoMarca,
                                 cal_c_especialidade = cal.cal_c_especialidade,
                                 cal_c_telefonePrincipal = cal.cal_c_telefonePrincipal,
                                 cal_c_telefoneSecundario = cal.cal_c_telefoneSecundario,
                                 cal_c_email = cal.cal_c_email,
                                 cal_c_website = cal.cal_c_website,
                                 cal_c_redeSocial1 = cal.cal_c_redeSocial1,
                                 cal_c_redeSocial2 = cal.cal_c_redeSocial2,
                                 cal_cat_c_nome = cat.cat_c_nome,
                                 cal_scc_c_nome = scc.scc_c_nome,
                                 exibeEspecialidade = cat.cat_b_solicitarEspecialidade,
                                 cal_c_status = cal.cal_c_status,
                                 cal_c_nomeEspecialista = string.IsNullOrEmpty(func.mor_c_nome) ? "SEM ESPECIALISTA" : func.mor_c_nome,
                                 cal_d_inclusao = cal.cal_d_inclusao,
                             });

                return query.OrderBy(x => x.cal_d_inclusao).ToPagedList(filter.paginaDataTable, filter.quantidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CatalogoViewModel> GetCatalogoPorCliente(int idCliente)
        {
            var lstCatalogo = (from cal in Context.tb_cal_catalogo
                               where cal.cal_cli_n_codigo == idCliente
                               orderby cal.cal_c_nome ascending
                               select new CatalogoViewModel
                               {
                                   cal_n_codigo = cal.cal_n_codigo.ToString(),
                                   cal_cat_n_codigo = cal.cal_cat_n_codigo.ToString(),
                                   cal_scc_n_codigo = cal.cal_scc_n_codigo.ToString(),
                                   cal_cli_n_codigo = cal.cal_cli_n_codigo.ToString(),
                                   cal_lcc_n_codigoTorre = cal.cal_lcc_n_codigoTorre.ToString(),
                                   cal_lcc_n_codigoNumero = cal.cal_lcc_n_codigoNumero.ToString(),
                                   cal_b_ativo = cal.cal_b_ativo == true ? "ATIVO" : "INATIVO",
                                   cal_c_nome = cal.cal_c_nome == null ? "" : cal.cal_c_nome,
                                   cal_c_descricao = cal.cal_c_descricao == null ? "" : cal.cal_c_descricao,
                                   cal_c_capa = cal.cal_c_capa == null ? "" : cal.cal_c_capa,
                                   cal_c_logoMarca = cal.cal_c_logoMarca == null ? "" : cal.cal_c_logoMarca,
                                   cal_c_especialidade = cal.cal_c_especialidade == null ? "" : cal.cal_c_especialidade,
                                   cal_c_telefonePrincipal = cal.cal_c_telefonePrincipal == null ? "" : cal.cal_c_telefonePrincipal,
                                   cal_c_telefoneSecundario = cal.cal_c_telefoneSecundario == null ? "" : cal.cal_c_telefoneSecundario,
                                   cal_c_email = cal.cal_c_email == null ? "" : cal.cal_c_email,
                                   cal_c_website = cal.cal_c_website == null ? "" : cal.cal_c_website,
                                   cal_c_redeSocial1 = cal.cal_c_redeSocial1 == null ? "" : cal.cal_c_redeSocial1,
                                   cal_c_redeSocial2 = cal.cal_c_redeSocial2 == null ? "" : cal.cal_c_redeSocial2
                               }).ToList();

            return lstCatalogo;
        }

        public Retorno InserOrUpdate(CatalogoViewModel model)
        {
            Retorno retorno = new Retorno();
            var transaction = context.Database.BeginTransaction();
            try
            {
                retorno.status = "Sucesso";
                retorno.conteudo = "Dados salvos com sucesso";

                var duplicidade = validaDuplicidadeEspecialista(Convert.ToInt32(model.cal_n_especialista), Convert.ToInt32(model.cal_n_codigo));

                if (duplicidade == true)
                {
                    retorno.status = "Alerta";
                    retorno.conteudo = "Já existe um catálogo para este especialista";
                    return retorno;
                }

                tb_cal_catalogo catalogo;

                if (model.cal_n_codigo == null)
                {

                    Insert(catalogo = new tb_cal_catalogo()
                    {
                        cal_cat_n_codigo = int.Parse(model.cal_cat_n_codigo),
                        cal_scc_n_codigo = int.Parse(model.cal_scc_n_codigo),
                        cal_cli_n_codigo = Convert.ToInt32(model.cal_cli_n_codigo),
                        cal_lcc_n_codigoTorre = !string.IsNullOrEmpty(model.cal_lcc_n_codigoTorre) && !model.cal_lcc_n_codigoTorre.Equals("0") ? Convert.ToInt32(model.cal_lcc_n_codigoTorre) : new int?(),
                        cal_lcc_n_codigoNumero = !string.IsNullOrEmpty(model.cal_lcc_n_codigoNumero) && !model.cal_lcc_n_codigoNumero.Equals("0") ? Convert.ToInt32(model.cal_lcc_n_codigoNumero) : new int?(),
                        cal_b_ativo = model.cal_b_ativo == "true" ? true : false,
                        cal_c_nome = model.cal_c_nome == null ? "" : model.cal_c_nome,
                        cal_c_descricao = model.cal_c_descricao == null ? "" : model.cal_c_descricao,
                        cal_c_capa = model.cal_c_capa == null ? "" : model.cal_c_capa,
                        cal_c_logoMarca = model.cal_c_logoMarca == null ? "" : model.cal_c_logoMarca,
                        cal_c_especialidade = model.cal_c_especialidade == null ? "" : model.cal_c_especialidade,
                        cal_c_telefonePrincipal = model.cal_c_telefonePrincipal == null ? "" : model.cal_c_telefonePrincipal,
                        cal_c_telefoneSecundario = model.cal_c_telefoneSecundario == null ? "" : model.cal_c_telefoneSecundario,
                        cal_c_email = model.cal_c_email == null ? "" : model.cal_c_email,
                        cal_c_website = model.cal_c_website == null ? "" : model.cal_c_website,
                        cal_c_redeSocial1 = model.cal_c_redeSocial1 == null ? "" : model.cal_c_redeSocial1,
                        cal_c_redeSocial2 = model.cal_c_redeSocial2 == null ? "" : model.cal_c_redeSocial2,
                        cal_grf_n_codigo = Convert.ToInt32(model.cal_grf_n_codigo),
                        cal_c_unique = Guid.NewGuid(),
                        cal_d_atualizado = DateTime.Now,
                        cal_d_inclusao = DateTime.Now,
                        cal_c_status = "PENDENTE LIB.",
                        cal_fot_n_codigo = model.cal_fot_n_codigo,
                        cal_n_especialista = string.IsNullOrEmpty(model.cal_n_especialista) ? new int?() : Convert.ToInt32(model.cal_n_especialista),
                        cal_logo_n_codigo = string.IsNullOrEmpty(model.cal_logo_n_codigo) ? new int?() : Convert.ToInt32(model.cal_logo_n_codigo),
                    });

                    context.SaveChanges();

                    //MontaEmailNovoCatalogo(Convert.ToInt32(model.cal_cli_n_codigo));
                    model.cal_n_codigo = catalogo.cal_n_codigo.ToString();
                    SalaComercialCatalogoService.InserirRelacionamento(model);
                    transaction.Commit();
                    return retorno;
                }
                else
                {
                    int codCat = Convert.ToInt32(model.cal_n_codigo);
                    var cal = (from cat in context.tb_cal_catalogo where cat.cal_n_codigo == codCat select cat).FirstOrDefault();

                    cal.cal_cat_n_codigo = int.Parse(model.cal_cat_n_codigo);
                    cal.cal_scc_n_codigo = int.Parse(model.cal_scc_n_codigo);
                    cal.cal_cli_n_codigo = Convert.ToInt32(model.cal_cli_n_codigo);
                    cal.cal_lcc_n_codigoTorre = !string.IsNullOrEmpty(model.cal_lcc_n_codigoTorre) && !model.cal_lcc_n_codigoTorre.Equals("0") ? Convert.ToInt32(model.cal_lcc_n_codigoTorre) : new int?();
                    cal.cal_lcc_n_codigoNumero = !string.IsNullOrEmpty(model.cal_lcc_n_codigoNumero) && !model.cal_lcc_n_codigoNumero.Equals("0") ? Convert.ToInt32(model.cal_lcc_n_codigoNumero) : new int?();
                    cal.cal_b_ativo = model.cal_b_ativo == "true" ? true : false;
                    cal.cal_c_nome = model.cal_c_nome == null ? "" : model.cal_c_nome;
                    cal.cal_c_descricao = model.cal_c_descricao == null ? "" : model.cal_c_descricao;
                    cal.cal_c_capa = model.cal_c_capa == null ? "" : model.cal_c_capa;
                    cal.cal_c_logoMarca = model.cal_c_logoMarca == null ? "" : model.cal_c_logoMarca;
                    cal.cal_c_especialidade = model.cal_c_especialidade == null ? "" : model.cal_c_especialidade;
                    cal.cal_c_telefonePrincipal = model.cal_c_telefonePrincipal == null ? "" : model.cal_c_telefonePrincipal;
                    cal.cal_c_telefoneSecundario = model.cal_c_telefoneSecundario == null ? "" : model.cal_c_telefoneSecundario;
                    cal.cal_c_email = model.cal_c_email == null ? "" : model.cal_c_email;
                    cal.cal_c_website = model.cal_c_website == null ? "" : model.cal_c_website;
                    cal.cal_c_redeSocial1 = model.cal_c_redeSocial1 == null ? "" : model.cal_c_redeSocial1;
                    cal.cal_c_redeSocial2 = model.cal_c_redeSocial2 == null ? "" : model.cal_c_redeSocial2;
                    cal.cal_c_unique = Guid.NewGuid();
                    cal.cal_d_atualizado = DateTime.Now;
                    cal.cal_d_inclusao = cal.cal_d_inclusao;
                    cal.cal_grf_n_codigo = Convert.ToInt32(model.cal_grf_n_codigo);
                    cal.cal_c_status = "PENDENTE LIB.";
                    cal.cal_fot_n_codigo = model.cal_fot_n_codigo;
                    cal.cal_n_especialista = string.IsNullOrEmpty(model.cal_n_especialista) ? new int?() : Convert.ToInt32(model.cal_n_especialista);
                    cal.cal_logo_n_codigo = string.IsNullOrEmpty(model.cal_logo_n_codigo) ? new int?() : Convert.ToInt32(model.cal_logo_n_codigo);
                    Update(cal);
                    context.SaveChanges();

                    //MontaEmailNovoCatalogo(Convert.ToInt32(model.cal_cli_n_codigo));
                    transaction.Commit();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                retorno.status = "Erro";
                retorno.conteudo = "Ocorreu um erro ao salvar os dados";
                transaction.Rollback();
                return retorno;
            }
        }

        public bool validaQuantidadeCatalogos(int id)
        {
            var cal = (from c in context.tb_cal_catalogo
                       where c.cal_grf_n_codigo == id
                       select c).Count();

            if (cal == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object UpdateStatus(CatalogoViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                var cal = (from cat in context.tb_cal_catalogo where cat.cal_n_codigo == Convert.ToInt32(model.cal_n_codigo) select cat).FirstOrDefault();
                cal.cal_c_status = model.cal_c_status;
                cal.cal_c_descricaoReprovado = model.cal_c_descricaoReprovado;
                Update(cal);
                context.SaveChanges();

                if (model.cal_c_status == "REPROVADO")
                {
                    MontaEmailCatalogoReprovado(model);
                }

                retorno.status = "Sucesso";
                retorno.conteudo = "Status atualizado com sucesso";

                return retorno;
            }
            catch (Exception e)
            {
                retorno.status = "Erro";
                retorno.conteudo = "Ocorreu um erro ao atualizar o status";

                return retorno;
            }
        }


        public void MontaEmailNovoCatalogo(int id)
        {
            try
            {
                var assunto = "UM CATÁLOGO FOI CADASTRADO NO PORTAL iCONNECT";
                var admEmail = (from adm in context.tb_zec_zeladorCliente
                                where adm.zec_cli_n_codigo == id && adm.zec_c_perfil == "ADMINISTRADOR"
                                select adm.zec_c_email).ToList();
                var emails = "";
                if (admEmail != null || admEmail.Count != 0)
                {
                    emails = string.Join(",", admEmail);

                    string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
                    var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
                    FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

                    StreamReader reader = new StreamReader(fileStream);
                    StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());

                    CorpoEmail = CorpoEmail.Replace("{mensagem}", @"OLÁ, UM CADASTRO DE CATÁLOGO FOI REALIZADO NO PORTAL: <br /> " + "https://portaliconnect.com.br/ <br />");

                    fileStream.Close();

                    EnviarEmail(assunto, emails, CorpoEmail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MontaEmailCatalogoReprovado(CatalogoViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.cal_c_email.ToString()))
                {
                    var assunto = "CATÁLOGO CADASTRADO NO PORTAL iCONNECT";

                    string path = Directory.GetCurrentDirectory() + "\\Template\\EmailClienteReserva.html";
                    var caminhoArquivoAnterior = path.Replace("\\iconnect-portal", "");
                    FileStream fileStream = new FileStream(caminhoArquivoAnterior, FileMode.Open);

                    StreamReader reader = new StreamReader(fileStream);
                    StringBuilder CorpoEmail = new StringBuilder(reader.ReadToEnd().Trim());

                    CorpoEmail = CorpoEmail.Replace("{mensagem}", @$"O CATÁLOGO CADASTRADO PARA A SALA COMERCIAL {model.cal_c_nome} FOI REPROVADO, SEGUE A DESCRIÇÃO: <br /> <br />" + $"{model.cal_c_descricaoReprovado.ToUpper()} <br /> <br />");

                    fileStream.Close();
                    EnviarEmail(assunto, model.cal_c_email.ToString(), CorpoEmail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarEmail(string assunto, string destinatario, StringBuilder corpo)
        {
            //Envio de Email
            EmailViewModel modelEma = new EmailViewModel();
            modelEma.ema_b_enviado = false;
            modelEma.ema_c_assunto = assunto;
            modelEma.ema_c_corpo = corpo.ToString();
            modelEma.ema_c_destinatario = destinatario;
            modelEma.ema_c_copiaOculta = "";
            modelEma.ema_d_data = DateTime.Now;
            modelEma.ema_b_enviado = false;
            modelEma.ema_d_modificacao = DateTime.Now;
            Email.InsertOrUpdate(modelEma);
        }

        public bool validaDuplicidadeEspecialista(int id, int idCatalogo)
        {
            var especialista = (from c in context.tb_cal_catalogo
                                where c.cal_n_especialista == id && c.cal_n_codigo != idCatalogo
                                select c).Count();

            if (especialista == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validaPrimeiroCatalogo(int idSala, int idCal)
        {
            var cal = (from c in context.tb_cal_catalogo
                       where c.cal_grf_n_codigo == idSala
                       orderby c.cal_d_inclusao ascending
                       select c.cal_n_codigo).First();

            if (cal == idCal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
