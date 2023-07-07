using Citrox.Util;
using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Exceptions;
using Iconnect.Infraestrutura.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Iconnect.Aplicacao.Services
{
    class ControleAcessoService : RepositoryBase<tb_cac_controleAcesso>, IControleAcessoService
    {
        private IconnectCoreContext context;

        public ControleAcessoService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private ISincronizacaoPlacasService _sincronizacaoPlacasService;
        public ISincronizacaoPlacasService SincronizacaoPlacasService
        {
            get
            {
                if (_sincronizacaoPlacasService == null)
                {
                    _sincronizacaoPlacasService = new SincronizacaoPlacasService(context);
                }
                return _sincronizacaoPlacasService;
            }
        }

        public IPagedList<ControleAcessoViewModel> GetControleAcessoFiltrado(ControleAcessoFilterModel filter)
        {
            var query = from cac in Context.tb_cac_controleAcesso
                      select new ControleAcessoViewModel

                        {
                            cac_n_codigo = cac.cac_n_codigo.ToString(),
                            cac_mor_n_codigo = cac.cac_mor_n_codigo.ToString(),
                            cac_c_descricao = cac.cac_c_descricao,
                            cac_c_numeroCartao = cac.cac_c_numeroCartao,
                            cac_b_ativo = cac.cac_b_ativo.ToString(),
                            cac_b_panico = cac.cac_b_panico.Value ? "SIM" : "NÃO",
                            cac_c_tipo = cac.cac_c_tipo,
                            cac_c_tipoAcesso = cac.cac_c_tipoAcesso,
                            cac_c_senha = cac.cac_c_senha,
                            cac_vis_n_codigo = cac.cac_vis_n_codigo.ToString(),
                            cac_pse_n_codigo = cac.cac_pse_n_codigo.ToString(),
                            cac_c_numeroChave = cac.cac_c_numeroChave,
                            cac_usu_n_codigo = cac.cac_usu_n_codigo.ToString(),
                            cac_d_modificacao = cac.cac_d_modificacao.ToString(),
                            cac_c_unique = cac.cac_c_unique.ToString(),
                            cac_d_atualizado = cac.cac_d_atualizado.ToString(),
                            cac_d_inclusao = cac.cac_d_inclusao.ToString(),
                            cac_c_biometria = cac.cac_c_biometria
                        };

            if (!string.IsNullOrEmpty(filter.cac_mor_n_codigo_filter))
            {
                if (filter.cac_mor_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.cac_mor_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.cac_mor_n_codigo == filter.cac_mor_n_codigo_filter);
                }
            }

            if (!string.IsNullOrEmpty(filter.cac_vis_n_codigo_filter))
            {
                if (filter.cac_vis_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.cac_vis_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.cac_vis_n_codigo == filter.cac_vis_n_codigo_filter);
                }
            }

            if (!string.IsNullOrEmpty(filter.cac_pse_n_codigo_filter))
            {
                if (filter.cac_pse_n_codigo_filter == "0")
                {
                    query = query.Where(w => w.cac_pse_n_codigo == null);
                }
                else
                {
                    query = query.Where(w => w.cac_pse_n_codigo == filter.cac_pse_n_codigo_filter);
                }
            }

            var lista = query.OrderByDescending(x => x.cac_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade);

            foreach (var item in lista)
            {
                item.valor_acesso = GetValorAcesso(item.cac_c_tipoAcesso, item.cac_c_numeroCartao, item.cac_c_numeroChave, item.cac_c_senha);
                item.cac_c_tipoAcesso = GetTipoAcesso(item.cac_c_tipoAcesso);
            }

            return lista;
        }

        private string GetTipoAcesso(string cac_c_tipoAcesso)
        {
            try
            {
                return (cac_c_tipoAcesso.ToUpper()) switch
                {
                    "CA" => "CARTÃO",
                    "CV" => "CHAVEIRO",
                    "CT" => "CONTROLE",
                    "SE" => "SENHA",
                    "TA" => "TAG",
                    "BI" => "BIOMETRIA",
                    "QR" => "QR CODE",
                    "LA" => "LIBERAÇÃO APP",
                    _ => string.Empty,
                };
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private string GetValorAcesso(string cac_c_tipoAcesso, string cac_c_numeroCartao, string cac_c_numeroChave, string cac_c_senha)
        {
            try
            {
                return (cac_c_tipoAcesso.ToUpper()) switch
                {
                    "CA" => cac_c_numeroCartao,
                    "CV" => cac_c_numeroChave,
                    "CT" => cac_c_numeroChave,
                    "SE" => cac_c_senha,
                    "LA" => cac_c_senha,
                    "TA" => cac_c_numeroChave,
                    "BI" => string.Empty,
                    "QR" => cac_c_numeroChave,
                    _ => string.Empty,
                };
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public IList<Dictionary<string, string>> SalvarControleAcesso(ControleAcessoViewModel model, bool validarDuplicidade = false)
        {
            Random cod = new Random();
            int codigo = Convert.ToInt32(cod.Next(1000000, 9999999));
            var ret = new List<Dictionary<string, string>>();
            int? auxIdMorador = null;
            int? auxIdVisitante = null;
            int? auxIdPrestador = null;
            int idCli = 0;

            if (!string.IsNullOrEmpty(model.cac_mor_n_codigo) && !model.cac_mor_n_codigo.Equals("0"))
            {
                auxIdMorador = Convert.ToInt32(model.cac_mor_n_codigo);
                if (auxIdMorador != null)
                {
                    idCli = context.tb_mor_Morador.Where(x => x.mor_n_codigo == auxIdMorador)?.Select(x => x.mor_cli_n_codigo)?.FirstOrDefault() ?? 0;
                }
            }
            else if (!string.IsNullOrEmpty(model.cac_vis_n_codigo) && !model.cac_vis_n_codigo.Equals("0"))
            {
                auxIdVisitante = Convert.ToInt32(model.cac_vis_n_codigo);
                if (auxIdVisitante != null)
                {
                    idCli = context.tb_vis_visitante.Where(x => x.vis_n_codigo == auxIdVisitante)?.Select(x => x.vis_cli_n_codigo)?.FirstOrDefault() ?? 0;
                }
            }
            else if (!string.IsNullOrEmpty(model.cac_pse_n_codigo) && !model.cac_pse_n_codigo.Equals("0"))
            {
                auxIdPrestador = Convert.ToInt32(model.cac_pse_n_codigo);
                if (auxIdPrestador != null)
                {
                    idCli = context.tb_pse_prestadorServico.Where(x => x.pse_n_codigo == auxIdPrestador)?.Select(x => x.pse_cli_n_codigo)?.FirstOrDefault() ?? 0;
                }
            }

            /*Ainda nao foi testado, ainda sendo implementado*/
            //Verifica se é biometria
            if (model.cac_c_tipoAcesso.ToUpper().Equals("BI"))
            {
                var biometria = context.tb_bio_biometria.Where(x => x.bio_n_codigo == Convert.ToInt32(model.bio_n_codigo))?.FirstOrDefault();
                if (biometria != null)
                {
                    model.cac_c_biometria = biometria.bio_c_template;
                    context.tb_bio_biometria.Remove(biometria);
                }
            }
            else if (validarDuplicidade)
            {
                if (model.cac_c_tipoAcesso.ToUpper().Equals("SE"))
                {
                    var lstAcessoTipoSenhaDuplicado = (from acesso in context.tb_cac_controleAcesso
                                                       join morador in context.tb_mor_Morador on acesso.cac_mor_n_codigo equals morador.mor_n_codigo into tempMorador
                                                       from morador in tempMorador.DefaultIfEmpty()
                                                       join prestador in context.tb_pse_prestadorServico on acesso.cac_pse_n_codigo equals prestador.pse_n_codigo into tempPrestador
                                                       from prestador in tempPrestador.DefaultIfEmpty()
                                                       join visitante in context.tb_vis_visitante on acesso.cac_vis_n_codigo equals visitante.vis_n_codigo into tempVisitante
                                                       from visitante in tempVisitante.DefaultIfEmpty()
                                                       where acesso.cac_c_tipoAcesso.ToUpper() == "SE" && acesso.cac_c_senha == ConverterSenhaCitrox(model.cac_c_senha)
                                                       && (visitante.vis_cli_n_codigo == idCli || morador.mor_cli_n_codigo == idCli || prestador.pse_cli_n_codigo == idCli)
                                                       && (acesso.cac_n_codigo != (!string.IsNullOrEmpty(model.cac_n_codigo) && !model.cac_n_codigo.Equals("0") ? Convert.ToInt32(model.cac_n_codigo) : 0))
                                                       select new tb_cac_controleAcesso
                                                       {
                                                           cac_n_codigo = acesso.cac_n_codigo,
                                                           cac_c_descricao = acesso.cac_c_descricao,
                                                           cac_c_numeroCartao = acesso.cac_c_numeroCartao,
                                                           cac_b_ativo = acesso.cac_b_ativo,
                                                           cac_b_panico = acesso.cac_b_panico,
                                                           cac_c_tipo = acesso.cac_c_tipo,
                                                           cac_c_tipoAcesso = acesso.cac_c_tipoAcesso,
                                                           cac_c_senha = acesso.cac_c_senha,
                                                           cac_c_numeroChave = acesso.cac_c_numeroChave,
                                                           cac_usu_n_codigo = acesso.cac_usu_n_codigo,
                                                           cac_d_modificacao = acesso.cac_d_modificacao,
                                                           cac_c_unique = acesso.cac_c_unique,
                                                           cac_d_atualizado = acesso.cac_d_atualizado,
                                                           cac_d_inclusao = acesso.cac_d_inclusao,
                                                           cac_c_biometria = acesso.cac_c_biometria,
                                                           cac_mor_n_codigoNavigation = morador,
                                                           cac_mor_n_codigo = acesso.cac_mor_n_codigo,
                                                           cac_pse_n_codigoNavigation = prestador,
                                                           cac_pse_n_codigo = acesso.cac_pse_n_codigo,
                                                           cac_vis_n_codigoNavigation = visitante,
                                                           cac_vis_n_codigo = acesso.cac_vis_n_codigo
                                                       }).ToList();

                    //Verifico se a chave (convertida) não existe na tabela de Chave Acesso e em suas dependencias se há alguma chave com status pendente.
                    string senhaDesconvertida = Citrox.Util.PasswordConverter.ConvertCardIdToPassword(model.cac_c_senha);

                    var lstAcessoDuplicadoChave = (from chaves in context.tb_cha_chavesDeAcesso
                                                   join liberacaoDelivery in context.tb_lid_liberacaoDelivery on chaves.cha_lid_n_codigo equals liberacaoDelivery.lid_n_codigo
                                                   join liberacaoPrestador in context.tb_lip_liberacaoPrestador on chaves.cha_lip_n_codigo equals liberacaoPrestador.lip_n_codigo
                                                   join liberacaoVisitante in context.tb_liv_liberacaoVisitante on chaves.cha_liv_n_codigo equals liberacaoVisitante.liv_n_codigo
                                                   where (chaves.cha_c_chave == senhaDesconvertida && model.cac_c_senha != null) &&
                                                   ((liberacaoDelivery.lid_b_pendente == true) || (liberacaoPrestador.lip_b_pendente == true) ||
                                                   (liberacaoVisitante.liv_b_pendente == true))
                                                   select new tb_cha_chavesDeAcesso
                                                   {
                                                       cha_n_codigo = chaves.cha_n_codigo,
                                                       cha_c_chave = chaves.cha_c_chave,
                                                       cha_liv_n_codigo = chaves.cha_liv_n_codigo,
                                                       cha_lid_n_codigo = chaves.cha_lid_n_codigo,
                                                       cha_lip_n_codigo = chaves.cha_lip_n_codigo,
                                                       cha_d_modificacao = chaves.cha_d_modificacao,
                                                       cha_c_unique = chaves.cha_c_unique,
                                                       cha_d_atualizado = chaves.cha_d_atualizado,
                                                       cha_d_inclusao = chaves.cha_d_inclusao,
                                                       cha_lid_n_codigoNavigation = liberacaoDelivery,
                                                       cha_lip_n_codigoNavigation = liberacaoPrestador,
                                                       cha_liv_n_codigoNavigation = liberacaoVisitante
                                                   }).ToList();

                    if (lstAcessoTipoSenhaDuplicado.Count() > 0)
                    {
                        throw new MensagemException("Não é possível utilizar está senha, insira uma diferente.");
                    }
                    else if (lstAcessoDuplicadoChave.Count() > 0)
                    {
                        throw new MensagemException("Acesso duplicado. Por favor, digite outro.");
                    }
                }
                else
                {
                    var lstAcessoDuplicado = (from acesso in context.tb_cac_controleAcesso
                                              join morador in context.tb_mor_Morador on acesso.cac_mor_n_codigo equals morador.mor_n_codigo into tempMorador
                                              from morador in tempMorador.DefaultIfEmpty()
                                              join prestador in context.tb_pse_prestadorServico on acesso.cac_pse_n_codigo equals prestador.pse_n_codigo into tempPrestador
                                              from prestador in tempPrestador.DefaultIfEmpty()
                                              join visitante in context.tb_vis_visitante on acesso.cac_vis_n_codigo equals visitante.vis_n_codigo into tempVisitante
                                              from visitante in tempVisitante.DefaultIfEmpty()
                                              where (acesso.cac_c_tipoAcesso.ToUpper() == "CA" || acesso.cac_c_tipoAcesso.ToUpper() == "CV" ||
                                              acesso.cac_c_tipoAcesso.ToUpper() == "CT" || acesso.cac_c_tipoAcesso.ToUpper() == "TA" || acesso.cac_c_tipoAcesso.ToUpper() == "QR") && //Tipo Senha
                                              ((acesso.cac_c_numeroCartao == model.cac_c_numeroCartao && !string.IsNullOrEmpty(model.cac_c_numeroCartao)) ||
                                               (acesso.cac_c_numeroChave == model.cac_c_numeroChave && !string.IsNullOrEmpty(model.cac_c_numeroChave)) ||
                                               (acesso.cac_c_numeroCartao == model.cac_c_numeroChave && !string.IsNullOrEmpty(model.cac_c_numeroChave)) ||
                                               (acesso.cac_c_numeroChave == model.cac_c_numeroCartao && !string.IsNullOrEmpty(model.cac_c_numeroCartao))) &&
                                               (morador.mor_cli_n_codigo == idCli || visitante.vis_cli_n_codigo == idCli || prestador.pse_cli_n_codigo == idCli) && //No mesmo condominio
                                               (acesso.cac_n_codigo != Convert.ToInt32(model.cac_n_codigo))
                                              select new tb_cac_controleAcesso
                                              {
                                                  cac_n_codigo = acesso.cac_n_codigo,
                                                  cac_c_descricao = acesso.cac_c_descricao,
                                                  cac_c_numeroCartao = acesso.cac_c_numeroCartao,
                                                  cac_b_ativo = acesso.cac_b_ativo,
                                                  cac_b_panico = acesso.cac_b_panico,
                                                  cac_c_tipo = acesso.cac_c_tipo,
                                                  cac_c_tipoAcesso = acesso.cac_c_tipoAcesso,
                                                  cac_c_senha = acesso.cac_c_senha,
                                                  cac_c_numeroChave = acesso.cac_c_numeroChave,
                                                  cac_usu_n_codigo = acesso.cac_usu_n_codigo,
                                                  cac_d_modificacao = acesso.cac_d_modificacao,
                                                  cac_c_unique = acesso.cac_c_unique,
                                                  cac_d_atualizado = acesso.cac_d_atualizado,
                                                  cac_d_inclusao = acesso.cac_d_inclusao,
                                                  cac_c_biometria = acesso.cac_c_biometria,
                                                  cac_mor_n_codigoNavigation = morador,
                                                  cac_mor_n_codigo = acesso.cac_mor_n_codigo,
                                                  cac_pse_n_codigoNavigation = prestador,
                                                  cac_pse_n_codigo = acesso.cac_pse_n_codigo,
                                                  cac_vis_n_codigoNavigation = visitante,
                                                  cac_vis_n_codigo = acesso.cac_vis_n_codigo
                                              }).ToList();

                    //Verifico se a chave (convertida) não existe na tabela de Chave Acesso e em suas dependencias se há alguma chave com status pendente.
                    string chave = null;
                    if (model.cac_c_tipoAcesso == "CV" || model.cac_c_tipoAcesso == "CT" || model.cac_c_tipoAcesso == "TA")
                    {
                        chave = model.cac_c_numeroChave;
                    }
                    else if (model.cac_c_tipoAcesso == "CA")
                    {
                        chave = model.cac_c_numeroCartao;
                    }

                    var lstAcessoDuplicadoChave = (from chaves in context.tb_cha_chavesDeAcesso
                                                   join liberacaoDelivery in context.tb_lid_liberacaoDelivery on chaves.cha_lid_n_codigo equals liberacaoDelivery.lid_n_codigo
                                                   join liberacaoPrestador in context.tb_lip_liberacaoPrestador on chaves.cha_lip_n_codigo equals liberacaoPrestador.lip_n_codigo
                                                   join liberacaoVisitante in context.tb_liv_liberacaoVisitante on chaves.cha_liv_n_codigo equals liberacaoVisitante.liv_n_codigo
                                                   where chaves.cha_c_chave == chave && !string.IsNullOrEmpty(model.cac_c_senha) &&
                                                   ((liberacaoDelivery.lid_b_pendente == true) || (liberacaoPrestador.lip_b_pendente == true) ||
                                                   (liberacaoVisitante.liv_b_pendente == true))
                                                   select new tb_cha_chavesDeAcesso
                                                   {
                                                       cha_n_codigo = chaves.cha_n_codigo,
                                                       cha_c_chave = chaves.cha_c_chave,
                                                       cha_liv_n_codigo = chaves.cha_liv_n_codigo,
                                                       cha_lid_n_codigo = chaves.cha_lid_n_codigo,
                                                       cha_lip_n_codigo = chaves.cha_lip_n_codigo,
                                                       cha_d_modificacao = chaves.cha_d_modificacao,
                                                       cha_c_unique = chaves.cha_c_unique,
                                                       cha_d_atualizado = chaves.cha_d_atualizado,
                                                       cha_d_inclusao = chaves.cha_d_inclusao,
                                                       cha_lid_n_codigoNavigation = liberacaoDelivery,
                                                       cha_lip_n_codigoNavigation = liberacaoPrestador,
                                                       cha_liv_n_codigoNavigation = liberacaoVisitante
                                                   }).ToList();

                    if (lstAcessoDuplicado.Count() > 0)
                    {
                        return RetornoAcessosDuplicados(lstAcessoDuplicado);
                    }
                    else if (lstAcessoDuplicadoChave.Count() > 0)
                    {
                        throw new MensagemException("Acesso duplicado. Por favor, digite outro.");
                    }

                    if (model.cac_c_tipoAcesso == "QR")
                    {
                        chave = codigo.ToString();
                        var lstAcessoDuplicadoQR = new List<tb_cac_controleAcesso>();

                        do
                        {
                            lstAcessoDuplicadoQR = (from acesso in context.tb_cac_controleAcesso
                                                    where acesso.cac_c_numeroChave == chave
                                                    select new tb_cac_controleAcesso
                                                    {
                                                        cac_c_numeroChave = acesso.cac_c_numeroChave,
                                                    }).ToList();

                            if (lstAcessoDuplicado.Count() > 0)
                            {
                                return RetornoAcessosDuplicados(lstAcessoDuplicado);
                            }
                            else if (lstAcessoDuplicadoQR.Count() > 0)
                            {
                                Random codAux = new Random();
                                int codigoAux = Convert.ToInt32(codAux.Next(1000000, 9999999));
                                chave = codigoAux.ToString();
                            }

                            codigo = Convert.ToInt32(chave);

                        } while (lstAcessoDuplicadoQR.Count() > 0);
                    }
                }
            }

            var controleAcesso = new tb_cac_controleAcesso();
            if (string.IsNullOrEmpty(model.cac_n_codigo) || model.cac_n_codigo.ToString() == "0")
            {
                if (model.cac_c_tipoAcesso.ToUpper() == "SE")
                {
                    model.cac_c_senha = ConverterSenhaCitrox(model.cac_c_senha);
                }

                if (model.cac_c_tipoAcesso.ToUpper() == "QR")
                {
                    model.cac_c_numeroChave = codigo.ToString();
                }

                Insert(controleAcesso = new tb_cac_controleAcesso()
                {
                    cac_mor_n_codigo = auxIdMorador,
                    cac_c_descricao = model.cac_c_descricao,
                    cac_c_numeroCartao = model.cac_c_numeroCartao,
                    cac_b_ativo = Convert.ToBoolean(model.cac_b_ativo),
                    cac_b_panico = model.cac_b_panico == "SIM",
                    cac_c_tipo = model.cac_c_tipo,
                    cac_c_tipoAcesso = model.cac_c_tipoAcesso,
                    cac_c_senha = model.cac_c_senha,
                    cac_vis_n_codigo = auxIdVisitante,
                    cac_pse_n_codigo = auxIdPrestador,
                    cac_c_numeroChave = model.cac_c_numeroChave,
                    cac_usu_n_codigo = Convert.ToInt32(model.cac_usu_n_codigo),
                    cac_d_modificacao = DateTime.Now,
                    cac_c_unique = new Guid(),
                    cac_d_atualizado = DateTime.Now,
                    cac_d_inclusao = DateTime.Now,
                    cac_c_biometria = model.cac_c_biometria
                });
            }
            else
            {
                controleAcesso = (from cac in context.tb_cac_controleAcesso where cac.cac_n_codigo == Convert.ToInt32(model.cac_n_codigo) select cac).FirstOrDefault();

                //Converte senha
                //Caso tenha trocado de senha, convertemos a nova senha
                if (controleAcesso.cac_c_tipoAcesso.ToUpper() != "SE" &&
                    model.cac_c_tipoAcesso.ToUpper() == "SE")
                {
                    model.cac_c_senha = ConverterSenhaCitrox(model.cac_c_senha);
                }
                else if (controleAcesso.cac_c_tipoAcesso.ToUpper() == "SE" && model.cac_c_tipoAcesso.ToUpper() == "SE")
                {
                    if (controleAcesso.cac_c_senha != model.cac_c_senha)
                    {
                        model.cac_c_senha = ConverterSenhaCitrox(model.cac_c_senha);
                    }
                }

                controleAcesso.cac_mor_n_codigo = auxIdMorador;
                controleAcesso.cac_c_descricao = model.cac_c_descricao;
                controleAcesso.cac_c_numeroCartao = model.cac_c_numeroCartao;
                controleAcesso.cac_b_ativo = Convert.ToBoolean(model.cac_b_ativo);
                controleAcesso.cac_b_panico = model.cac_b_panico == "SIM";
                controleAcesso.cac_c_tipo = model.cac_c_tipo;
                controleAcesso.cac_c_tipoAcesso = model.cac_c_tipoAcesso;
                controleAcesso.cac_c_senha = model.cac_c_senha;
                controleAcesso.cac_vis_n_codigo = auxIdVisitante;
                controleAcesso.cac_pse_n_codigo = auxIdPrestador;
                controleAcesso.cac_c_numeroChave = model.cac_c_numeroChave;
                controleAcesso.cac_usu_n_codigo = Convert.ToInt32(model.cac_usu_n_codigo);
                controleAcesso.cac_d_modificacao = DateTime.Now;
                controleAcesso.cac_d_atualizado = DateTime.Now;
                controleAcesso.cac_c_biometria = model.cac_c_biometria;

                Update(controleAcesso);
            }

            context.SaveChanges();

            SincronizarAlteraçõesPlacas(idCli, controleAcesso.cac_n_codigo);

            return null;
        }

        private IList<Dictionary<string, string>> RetornoAcessosDuplicados(IList<tb_cac_controleAcesso> ListaCac)
        {
            List<Dictionary<string, string>> arraylistRetrono = new List<Dictionary<string, string>>();
            if (ListaCac.Count > 0)
            {
                foreach (var item in ListaCac)
                {
                    if (item.cac_vis_n_codigo != null)
                    {
                        DateTime? dtExpiracao = null;
                        if (item.cac_vis_n_codigoNavigation.vis_d_dataExpriracao != null)
                        {
                            DateTime dataPessoa = Convert.ToDateTime(item.cac_vis_n_codigoNavigation.vis_d_dataExpriracao.Value.ToString("dd/MM/yyyy"));
                            DateTime dataHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                            if (dataPessoa >= dataHoje)
                                dtExpiracao = dataPessoa;
                        }

                        item.cac_vis_n_codigoNavigation = context.tb_vis_visitante.Where(x => x.vis_n_codigo == item.cac_vis_n_codigo)?.FirstOrDefault();

                        arraylistRetrono.Add(new Dictionary<string, string>()
                        {
                            { "TIPO", "VIS"},
                            { "CODIGO", item.cac_vis_n_codigoNavigation?.vis_n_codigo.ToString()},
                            { "NOME", item.cac_vis_n_codigoNavigation?.vis_c_nome },
                            { "CAC", item.cac_n_codigo.ToString()},
                            { "DATA_EXPIRACAO", dtExpiracao != null ? dtExpiracao.Value.ToString("dd/MM/yyyy") : ""}
                        });
                    }
                    else if (item.cac_pse_n_codigo != null)
                    {
                        DateTime? dtExpiracao = null;
                        if (item.cac_pse_n_codigoNavigation.pse_d_dataExpriracao != null)
                        {
                            DateTime dataPessoa = Convert.ToDateTime(item.cac_pse_n_codigoNavigation.pse_d_dataExpriracao.Value.ToString("dd/MM/yyyy"));
                            DateTime dataHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                            if (dataPessoa >= dataHoje) dtExpiracao = dataPessoa;
                        }

                        item.cac_pse_n_codigoNavigation = context.tb_pse_prestadorServico.Where(x => x.pse_n_codigo == item.cac_pse_n_codigo)?.FirstOrDefault();

                        arraylistRetrono.Add(new Dictionary<string, string>()
                        {
                            { "TIPO", "PSE"},
                            { "CODIGO", item.cac_pse_n_codigoNavigation.pse_n_codigo.ToString()},
                            { "NOME", item.cac_pse_n_codigoNavigation.pse_c_nome },
                            { "CAC", item.cac_n_codigo.ToString()},
                            { "DATA_EXPIRACAO", dtExpiracao != null ? dtExpiracao.Value.ToString("dd/MM/yyyy") : ""}
                        });
                    }
                    if (item.cac_mor_n_codigo != null)
                    {
                        item.cac_mor_n_codigoNavigation = context.tb_mor_Morador.Where(x => x.mor_n_codigo == item.cac_mor_n_codigo)?.FirstOrDefault();

                        arraylistRetrono.Add(new Dictionary<string, string>()
                        {
                            { "TIPO", "MOR"},
                            { "CODIGO", item.cac_mor_n_codigoNavigation.mor_n_codigo.ToString()},
                            { "NOME", item.cac_mor_n_codigoNavigation.mor_c_nome },
                            { "CAC", item.cac_n_codigo.ToString()},
                            { "DATA_EXPIRACAO", "" }
                        });
                    }
                }

                return arraylistRetrono;
            }
            else
            {
                return arraylistRetrono;
            }
        }

        private void SincronizarAlteraçõesPlacas(int idCliente, int cac_n_codigo)
        {

            if (idCliente > 0)
            {
                var lstControladoras = context.tb_con_controladora.Where(x => x.con_cli_n_codigo == idCliente && x.con_b_ativo == true && x.con_c_modelo != "CITROX").ToList();
                if (lstControladoras.Count > 0)
                {
                    string controladoras = "";
                    foreach (var controladora in lstControladoras)
                    {
                        controladoras += "," + controladora.con_n_codigo;
                    }

                    if (!string.IsNullOrEmpty(controladoras))
                    {
                        SincronizacaoPlacasService.SalvarSincronizacaoPlacasInterna(idCliente, controladoras, cac_n_codigo);
                    }
                }
            }
        }

        private string ConverterSenhaCitrox(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                return string.Format("{0}", Convert.ToUInt64(password, 16));
            }

            return password;
        }

        private string DesconverterSenhaCitrox(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                return string.Format("{0:x}", long.Parse(password));
            }

            return password;
        }

        public bool DeletarControleAcesso(int id)
        {
            try
            {
                Delete(context.tb_cac_controleAcesso.Find(id));

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarControleAcessoSemPessoa()
        {
            try
            {
                var lstAvisos = context.tb_cac_controleAcesso.Where(x => x.cac_mor_n_codigo == null && x.cac_vis_n_codigo == null && x.cac_pse_n_codigo == null).ToList();

                if (lstAvisos.Count() > 0)
                {
                    foreach (var aviso in lstAvisos)
                    {
                        Delete(aviso);
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

        public bool VincularAcessos(int idPessoa, string tipoPessoa)
        {
            try
            {
                var lstAcessos = context.tb_cac_controleAcesso.Where(x => x.cac_mor_n_codigo == null && x.cac_vis_n_codigo == null && x.cac_pse_n_codigo == null).ToList();

                if (lstAcessos.Count() > 0)
                {
                    foreach (var acesso in lstAcessos)
                    {
                        if (tipoPessoa == "MORADOR")
                        {
                            acesso.cac_mor_n_codigo = idPessoa;
                        }
                        else if (tipoPessoa == "VISITANTE")
                        {
                            acesso.cac_vis_n_codigo = idPessoa;
                        }
                        else if (tipoPessoa == "PRESTADOR")
                        {
                            acesso.cac_pse_n_codigo = idPessoa;
                        }

                        Update(acesso);
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

        public bool DeleteComSincronizacao(int id)
        {
            try
            {
                var controleAcesso = context.tb_cac_controleAcesso.Where(x => x.cac_n_codigo == id)?.FirstOrDefault();
                if (controleAcesso != null)
                {
                    //Utilizaremos essa variavel para armazenar os ids das controladoras que deverão ser sincronizadas a exclusão deste acesso
                    string con_n_codigo_para_sincronizacao = ",";

                    //Lista controladoras do cliente desta pessoa para para que esse acesso seja excluido em todas controladoras
                    List<tb_con_controladora> lstControladoras = GetControladorasPorAcesso(controleAcesso);
                    foreach (var controladora in lstControladoras)
                    {
                        //Inseri na tabela tb_cae_controleAcessoExcluido para que seja sincronizado na placa (Implementado a principio na Linear)
                        tb_cae_controleAcessoExcluido tb_cae_controleAcessoExcluido = new tb_cae_controleAcessoExcluido
                        {
                            cae_cac_n_codigo = controleAcesso.cac_n_codigo,
                            cae_mor_n_codigo = controleAcesso.cac_mor_n_codigo,
                            cae_c_descricao = controleAcesso.cac_c_descricao,
                            cae_c_numeroCartao = controleAcesso.cac_c_numeroCartao,
                            cae_b_ativo = controleAcesso.cac_b_ativo,
                            cae_b_panico = controleAcesso.cac_b_panico,
                            cae_c_tipo = controleAcesso.cac_c_tipo,
                            cae_c_tipoAcesso = controleAcesso.cac_c_tipoAcesso,
                            cae_c_senha = controleAcesso.cac_c_senha,
                            cae_vis_n_codigo = controleAcesso.cac_vis_n_codigo,
                            cae_pse_n_codigo = controleAcesso.cac_pse_n_codigo,
                            cae_c_numeroChave = controleAcesso.cac_c_numeroChave,
                            cae_usu_n_codigo = controleAcesso.cac_usu_n_codigo,
                            cae_d_modificacao = controleAcesso.cac_d_modificacao,
                            cae_b_sincronizado = false,
                            cae_con_n_codigo = controladora.con_n_codigo
                        };

                        //Inseri
                        context.tb_cae_controleAcessoExcluido.Add(tb_cae_controleAcessoExcluido);

                        //Devemos solicitar sincronização apenas para as controladoras diferentes da CITROX
                        if (controladora.con_c_modelo != "CITROX")
                        {
                            con_n_codigo_para_sincronizacao += controladora.con_n_codigo.ToString() + ",";
                        }
                    }

                    //Remove da tb_cac_controleAcesso
                    context.tb_cac_controleAcesso.Remove(controleAcesso);

                    if (con_n_codigo_para_sincronizacao != ",")
                    {
                        //Remover a última virgula
                        con_n_codigo_para_sincronizacao = con_n_codigo_para_sincronizacao.Remove(con_n_codigo_para_sincronizacao.Length - 1);

                        //Verifica qual cliente
                        int cli_n_codigo = lstControladoras.ToList().FirstOrDefault().con_cli_n_codigo.Value;
                        if (cli_n_codigo != 0)
                        {
                            tb_sin_sincronizacaoPlacas sin = new tb_sin_sincronizacaoPlacas
                            {
                                sin_ace_n_codigo = id,
                                sin_b_interno = true,
                                sin_cli_n_codigo = cli_n_codigo,
                                sin_c_status = "AI",
                                sin_c_controladoras = con_n_codigo_para_sincronizacao,
                                sin_d_dataSolicitacao = DateTime.Now
                            };
                            context.tb_sin_sincronizacaoPlacas.Add(sin);
                        }
                    }

                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { }
        }

        private List<tb_con_controladora> GetControladorasPorAcesso(tb_cac_controleAcesso controleAcesso)
        {
            try
            {
                var lstControladoras = new List<tb_con_controladora>();
                var clienteId = 0;

                if (controleAcesso.cac_mor_n_codigo != null)
                {
                    clienteId = context.tb_mor_Morador.Where(x => x.mor_n_codigo == Convert.ToInt32(controleAcesso.cac_mor_n_codigo))?.FirstOrDefault()?.mor_cli_n_codigo ?? 0;
                }
                else if (controleAcesso.cac_vis_n_codigo != null)
                {
                    clienteId = context.tb_vis_visitante.Where(x => x.vis_n_codigo == Convert.ToInt32(controleAcesso.cac_vis_n_codigo))?.FirstOrDefault()?.vis_cli_n_codigo ?? 0;
                }
                else if (controleAcesso.cac_pse_n_codigo != null)
                {
                    clienteId = context.tb_pse_prestadorServico.Where(x => x.pse_n_codigo == Convert.ToInt32(controleAcesso.cac_vis_n_codigo))?.FirstOrDefault()?.pse_cli_n_codigo ?? 0;
                }

                lstControladoras = (from con in context.tb_con_controladora where con.con_cli_n_codigo == clienteId && con.con_b_ativo == true && con.con_c_modelo != "CITROX" select con)?.ToList();

                return lstControladoras;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int SolicitacaoBiometria(string idCliente, string idControladora)
        {
            tb_bio_biometria bio = new tb_bio_biometria();

            bio.bio_cli_n_codigo = Convert.ToInt32(idCliente);
            bio.bio_c_status = "P";
            bio.bio_d_dataSolicitacao = DateTime.Now;
            bio.bio_d_atualizado = DateTime.Now;
            bio.bio_d_inclusao = DateTime.Now;
            bio.bio_c_unique = Guid.NewGuid();

            if (!string.IsNullOrEmpty(idControladora) && idControladora != "0")
            {
                bio.bio_con_n_codigo = Convert.ToInt32(idControladora);
            }

            context.tb_bio_biometria.Add(bio);
            context.SaveChanges();

            return bio?.bio_n_codigo ?? 0;
        }

        public IList<Dictionary<string, string>> CarregaComboDispositivoBiometrico(int cli_n_codigo)
        {
            tb_con_controladora objControladora = new tb_con_controladora();
            List<Dictionary<string, string>> lstOptions = new List<Dictionary<string, string>>
            {
                //Fixo Intelbras
                new Dictionary<string, string>() { { "Nome", "Leitor Intelbras" }, { "Codigo", "0" } }
            };

            //ControlID
            var lstControlID = context.tb_con_controladora.Where(x => x.con_cli_n_codigo == cli_n_codigo && x.con_c_modelo == "CONTROL ID").ToList();
            foreach (tb_con_controladora controladora in lstControlID)
            {
                lstOptions.Add(new Dictionary<string, string>() { { "Nome", controladora.con_c_nome }, { "Codigo", controladora.con_n_codigo.ToString() } });
            }

            return lstOptions;
        }

        public string GetImagemBiometria(int idBiometria)
        {
            var biometria = context.tb_bio_biometria.Where(x => x.bio_n_codigo == idBiometria)?.FirstOrDefault();
            var base64String = "";
            if (biometria != null)
            {
                if (biometria.bio_c_imagem != null)
                {
                    MemoryStream memory = new MemoryStream();
                    BitmapFormat.GetBitmap(biometria.bio_c_imagem, biometria.bio_n_largura, biometria.bio_n_altura, ref memory);
                    Bitmap bmp = new Bitmap(memory);

                    MemoryStream memoryConvertido = new MemoryStream();
                    bmp.Save(memoryConvertido, ImageFormat.Jpeg);

                    base64String = $"data:image/jpeg;base64,{Convert.ToBase64String(memoryConvertido.ToArray())}";
                }
            }
            return base64String;
        }
        public bool GerarQrCodeLiberacaoApp(int mor_n_codigo)
        {

            try
            {
                tb_cac_controleAcesso cac = new tb_cac_controleAcesso();
                cac.cac_mor_n_codigo = mor_n_codigo;
                cac.cac_c_descricao = "QR CODE";
                cac.cac_c_numeroCartao = string.Empty;
                cac.cac_b_panico = false;
                cac.cac_c_tipo = string.Empty;
                cac.cac_c_tipoAcesso = "QR";
                cac.cac_c_senha = string.Empty;
                cac.cac_c_numeroChave = GerarChave();
                cac.cac_d_modificacao = DateTime.Now;

                Insert(cac);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string GerarChave()
        {
            List<tb_cac_controleAcesso> controleAcesso = new List<tb_cac_controleAcesso>();
            List<tb_cha_chavesDeAcesso> ChaveAcesso = new List<tb_cha_chavesDeAcesso>();
            string token = "";
            string tokenConvertido = "";
            try
            {
                do
                {
                    token = geraChaveToken();
                    tokenConvertido = ConverterSenha(token);
                    controleAcesso = context.tb_cac_controleAcesso.Where(x => x.cac_c_senha == tokenConvertido || x.cac_c_numeroCartao == token || x.cac_c_numeroChave == token).ToList();
                    ChaveAcesso = context.tb_cha_chavesDeAcesso.Where(x => x.cha_c_chave == token).ToList();

                } while (controleAcesso.Count > 0 || ChaveAcesso.Count > 0);

                return token;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string geraChaveToken()
        {
            string chave = "";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                chave += random.Next(0, 9).ToString();
            }

            return chave;
        }

        public string ConverterSenha(string senhaConvertida)
        {
            try
            {
                if (senhaConvertida.Length >= 8)
                {
                    senhaConvertida = senhaConvertida.Substring(0, 8);
                }
                senhaConvertida = PasswordConverter.ConvertPasswordToCardId(senhaConvertida);
            }
            catch (Exception)
            {

            }
            return senhaConvertida;
        }

        public string Criptografar(string parametro)
        {
            var chave = "b14ca5898a4e4133bbce2ea2315a1916";

            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(chave);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(parametro);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public string Descriptografar(string parametro)
        {
            var chave = "b14ca5898a4e4133bbce2ea2315a1916";

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(parametro);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(chave);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }        

        public ControleAcessoViewModel GetAcessoByGuid(string guid)
        {
            var query = (from cac in context.tb_cac_controleAcesso
                         where cac.cac_c_unique == Guid.Parse(guid)
                         select new ControleAcessoViewModel()
                         {
                             cac_c_numeroChave = cac.cac_c_numeroChave,
                             cac_mor_n_codigo = cac.cac_mor_n_codigo.ToString(),
                             cac_pse_n_codigo = cac.cac_pse_n_codigo.ToString(),
                             cac_vis_n_codigo = cac.cac_vis_n_codigo.ToString(),

                         });

            return query.FirstOrDefault();
        }

        public ControleAcessoViewModel GetAcessoVisitanteQR(int id)
        {
            var query = (from cac in context.tb_cac_controleAcesso
                         where cac.cac_c_tipoAcesso == "LA" && cac.cac_vis_n_codigo == id
                         select new ControleAcessoViewModel()
                         {
                             cac_c_unique = cac.cac_c_unique.ToString(),
                         }).FirstOrDefault();

            return query;
        }
    }
}