using Iconnect.Aplicacao.FilterModel;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Base;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Iconnect.Aplicacao.Services
{
    class GrupoFamiliarService : RepositoryBase<tb_grf_grupoFamiliar>, IGrupoFamiliarService
    {
        private IconnectCoreContext context;

        public GrupoFamiliarService(IconnectCoreContext context) : base(context)
        {
            this.context = context;
        }

        private IAvisoGrupoFamiliarService _avisoGrupoFamiliarService;
        public IAvisoGrupoFamiliarService AvisoGrupoFamiliarService
        {
            get
            {
                if (_avisoGrupoFamiliarService == null)
                {
                    _avisoGrupoFamiliarService = new AvisoGrupoFamiliarService(context);
                }
                return _avisoGrupoFamiliarService;
            }
        }

        private IPetService _petService;
        public IPetService PetService
        {
            get
            {
                if (_petService == null)
                {
                    _petService = new PetService(context);
                }
                return _petService;
            }
        }

        private IVeiculoService _veiculoService;
        public IVeiculoService VeiculoService
        {
            get
            {
                if (_veiculoService == null)
                {
                    _veiculoService = new VeiculoService(context);
                }
                return _veiculoService;
            }
        }

        private IMoradorService _morador;
        public IMoradorService morador
        {
            get
            {
                if (_morador == null)
                {
                    _morador = new MoradorService(context);
                }
                return _morador;
            }
        }

        private IAcessoService _acessoService;
        public IAcessoService AcessoService
        {
            get
            {
                if (_acessoService == null)
                {
                    _acessoService = new AcessoService(context);
                }
                return _acessoService;
            }
        }

        private ICatalogoService _catalogoService;
        public ICatalogoService CatalogoService
        {
            get
            {
                if (_catalogoService == null)
                {
                    _catalogoService = new CatalogoService(context);
                }
                return _catalogoService;
            }
        }

        private ISincronizacaoPlacasService _sincronizacaoPlacas;
        public ISincronizacaoPlacasService SincronizacaoPlacas
        {
            get
            {
                if (_sincronizacaoPlacas == null)
                {
                    _sincronizacaoPlacas = new SincronizacaoPlacasService(context);
                }
                return _sincronizacaoPlacas;
            }
        }

        private ILocalidadeGrupoFamiliarService _localidadeGrupoFamiliar;
        public ILocalidadeGrupoFamiliarService LocalidadeGrupoFamiliarService
        {
            get
            {
                if (_localidadeGrupoFamiliar == null)
                {
                    _localidadeGrupoFamiliar = new LocalidadeGrupoFamiliarService(context);
                }
                return _localidadeGrupoFamiliar;
            }
        }

        public List<GrupoFamiliarViewModel> GetGruposFamiliar()
        {
            return (from grf in context.tb_grf_grupoFamiliar
                    select new GrupoFamiliarViewModel()
                    {
                        grf_n_codigo = grf.grf_n_codigo.ToString(),
                        grf_c_nomeResponsavel = grf.grf_c_nomeResponsavel,
                        grf_c_status = grf.grf_c_status,
                        grf_c_tipo = grf.grf_c_tipo,
                        grf_c_rg = grf.grf_c_rg,
                        grf_c_cpf = grf.grf_c_cpf,
                        grf_c_telefone = grf.grf_c_telefone,
                        grf_c_email = grf.grf_c_email,
                        grf_c_numeroVagas = grf.grf_c_numeroVagas,
                        grf_c_BlocoQuadra = grf.grf_c_BlocoQuadra,
                        grf_c_LoteApto = grf.grf_c_LoteApto,
                        grf_c_observacao = grf.grf_c_observacao,
                        grf_c_celular = grf.grf_c_celular,
                        grf_fot_n_codigo = grf.grf_fot_n_codigo.ToString(),
                        grf_cli_n_codigo = grf.grf_cli_n_codigo.ToString(),
                        grf_d_alteracao = grf.grf_d_alteracao.ToString(),
                        grf_c_usuario = grf.grf_c_usuario,
                        grf_d_modificacao = grf.grf_d_modificacao.ToString(),
                        grf_c_unique = grf.grf_c_unique.ToString(),
                        grf_d_atualizado = grf.grf_d_atualizado.ToString(),
                        grf_d_inclusao = grf.grf_d_inclusao.ToString(),
                        grf_c_senhaApp = grf.grf_c_senhaApp,
                        grf_n_ramal = grf.grf_n_ramal.ToString(),
                        grf_c_autorizacaoPRO = grf.grf_c_autorizacaoPRO,
                        grf_b_permiteHomeCare = grf.grf_b_permiteHomeCare.ToString(),
                        grf_c_estado = grf.grf_c_estado,
                    }).ToList();
        }

        public List<GrupoFamiliarViewModel> GetGruposFamiliarByCliente(int idCliente)
        {
            return (from grf in context.tb_grf_grupoFamiliar
                    where grf.grf_cli_n_codigo == idCliente && grf.grf_c_status == "ATIVO"
                    orderby grf.grf_c_nomeResponsavel ascending
                    select new GrupoFamiliarViewModel()
                    {
                        grf_n_codigo = grf.grf_n_codigo.ToString(),
                        grf_c_nomeResponsavel = grf.grf_c_nomeResponsavel,
                        grf_c_status = grf.grf_c_status,
                        grf_c_tipo = grf.grf_c_tipo,
                        grf_c_rg = grf.grf_c_rg,
                        grf_c_cpf = grf.grf_c_cpf,
                        grf_c_telefone = grf.grf_c_telefone,
                        grf_c_email = grf.grf_c_email,
                        grf_c_numeroVagas = grf.grf_c_numeroVagas,
                        grf_c_BlocoQuadra = grf.grf_c_BlocoQuadra,
                        grf_c_LoteApto = grf.grf_c_LoteApto,
                        grf_c_observacao = grf.grf_c_observacao,
                        grf_c_celular = grf.grf_c_celular,
                        grf_fot_n_codigo = grf.grf_fot_n_codigo.ToString(),
                        grf_cli_n_codigo = grf.grf_cli_n_codigo.ToString(),
                        grf_d_alteracao = grf.grf_d_alteracao.ToString(),
                        grf_c_usuario = grf.grf_c_usuario,
                        grf_d_modificacao = grf.grf_d_modificacao.ToString(),
                        grf_c_unique = grf.grf_c_unique.ToString(),
                        grf_d_atualizado = grf.grf_d_atualizado.ToString(),
                        grf_d_inclusao = grf.grf_d_inclusao.ToString(),
                        grf_c_senhaApp = grf.grf_c_senhaApp,
                        grf_n_ramal = grf.grf_n_ramal.ToString(),
                        grf_c_autorizacaoPRO = grf.grf_c_autorizacaoPRO,
                        grf_b_permiteHomeCare = grf.grf_b_permiteHomeCare.ToString(),
                        grf_c_nomeSalaComercial = grf.grf_c_nomeSalaComercial,
                        grf_c_estado = grf.grf_c_estado,
                    }).ToList();


        }
        public List<GrupoFamiliarViewModel> GetResponsavelByCliente(int idCliente)
        {
            List<GrupoFamiliarViewModel> query = (from grf in context.vw_grupo_familiar
                                                  where grf.grf_cli_n_codigo == idCliente
                                                  orderby grf.LOCALIZACAO ascending
                                                  select new GrupoFamiliarViewModel()
                                                  {
                                                      grf_n_codigo = grf.grf_n_codigo.ToString(),
                                                      localizacao = grf.LOCALIZACAO.ToString(),

                                                  }).ToList();

            return query;


        }

        public GrupoFamiliarViewModel GetGrupoFamiliar(int id)
        {
            var grupoFamiliar = (from grf in context.tb_grf_grupoFamiliar
                                 where grf.grf_n_codigo == id
                                 select new GrupoFamiliarViewModel()
                                 {
                                     grf_n_codigo = grf.grf_n_codigo.ToString(),
                                     grf_c_nomeResponsavel = grf.grf_c_nomeResponsavel,
                                     grf_c_status = grf.grf_c_status,
                                     grf_c_tipo = grf.grf_c_tipo,
                                     grf_c_rg = grf.grf_c_rg,
                                     grf_c_cpf = grf.grf_c_cpf,
                                     grf_c_telefone = grf.grf_c_telefone,
                                     grf_c_email = grf.grf_c_email,
                                     grf_c_numeroVagas = grf.grf_c_numeroVagas,
                                     grf_c_BlocoQuadra = grf.grf_c_BlocoQuadra,
                                     grf_c_LoteApto = grf.grf_c_LoteApto,
                                     grf_c_observacao = grf.grf_c_observacao,
                                     grf_c_celular = grf.grf_c_celular,
                                     grf_fot_n_codigo = grf.grf_fot_n_codigo != null ? grf.grf_fot_n_codigo.ToString() : "0",
                                     grf_cli_n_codigo = grf.grf_cli_n_codigo.ToString(),
                                     grf_d_alteracao = grf.grf_d_alteracao.ToString(),
                                     grf_c_usuario = grf.grf_c_usuario,
                                     grf_d_modificacao = grf.grf_d_modificacao.ToString(),
                                     grf_c_unique = grf.grf_c_unique.ToString(),
                                     grf_d_atualizado = grf.grf_d_atualizado.ToString(),
                                     grf_d_inclusao = grf.grf_d_inclusao.ToString(),
                                     grf_c_senhaApp = grf.grf_c_senhaApp,
                                     grf_n_ramal = grf.grf_n_ramal.ToString(),
                                     grf_c_autorizacaoPRO = grf.grf_c_autorizacaoPRO,
                                     grf_c_observacoesHomeCare = grf.grf_c_observacoesHomeCare,
                                     grf_b_permiteHomeCare = grf.grf_b_permiteHomeCare.ToString(),
                                     grf_ace_n_codigo = grf.grf_ace_n_codigo.ToString(),
                                     grf_c_nomeSalaComercial = grf.grf_c_nomeSalaComercial,
                                     grf_c_estado = grf.grf_c_estado,
                                 })?.FirstOrDefault() ?? new GrupoFamiliarViewModel();

            if (grupoFamiliar.grf_ace_n_codigo != null)
            {
                grupoFamiliar.acesso = AcessoService.GetAcesso(Convert.ToInt32(grupoFamiliar.grf_ace_n_codigo));
            }

            return grupoFamiliar;
        }

        public IPagedList<GrupoFamiliarViewModel> GetGrupoFamiliarFiltrado(GrupoFamiliarFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.idsClientes))
            {
                return new PagedList<GrupoFamiliarViewModel>(null, 1, 1);
            }

            var query = ObterQueryGrupoFamiliarFiltrador(filter);

            //Ajuste tamanho textos
            var listaGrupoFamiliar = query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            foreach (var gru in listaGrupoFamiliar)
            {
                if (gru.NomeCliente.Length > 25)
                {
                    gru.NomeCliente = gru.NomeCliente.Substring(0, 25) + "...";
                }

                if (gru.grf_c_nomeResponsavel.Length > 45)
                {
                    gru.grf_c_nomeResponsavel = gru.grf_c_nomeResponsavel.Substring(0, 45) + "...";
                }
            }

            return listaGrupoFamiliar;
        }

        public byte[] GeraExcel(GrupoFamiliarFilterModel filter)
        {
            var query = ObterQueryGrupoFamiliarFiltrador(filter);
            var lstGrupoFamiliar = query.ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Cliente",
                    "Tipo",
                    "Responsavel",
                    "RG",
                    "CPF",
                    "Telefone",
                    "Ramal",
                    "Celular",
                    "E-mail",
                    "Num. Vagas",
                    "Bloco/Quadra",
                    "Lote/Apto",
                    "Status",
                };

                var worksheet = package.Workbook.Worksheets.Add("GrupoFamiliars");
                using (var cells = worksheet.Cells[1, 1, 1, columHeaders.Count()])
                {
                    cells.Style.Font.Bold = true;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = columHeaders[i];
                }

                var j = 2;

                try
                {
                    foreach (var grupoFamiliar in lstGrupoFamiliar)
                    {
                        worksheet.Cells["A" + j].Value = grupoFamiliar.NomeCliente;
                        worksheet.Cells["B" + j].Value = grupoFamiliar.grf_c_tipo;
                        worksheet.Cells["C" + j].Value = grupoFamiliar.grf_c_nomeResponsavel;
                        worksheet.Cells["D" + j].Value = grupoFamiliar.grf_c_rg;
                        worksheet.Cells["E" + j].Value = grupoFamiliar.grf_c_cpf;
                        worksheet.Cells["F" + j].Value = grupoFamiliar.grf_c_telefone;
                        worksheet.Cells["G" + j].Value = grupoFamiliar.grf_n_ramal;
                        worksheet.Cells["H" + j].Value = grupoFamiliar.grf_c_celular;
                        worksheet.Cells["I" + j].Value = grupoFamiliar.grf_c_email;
                        worksheet.Cells["J" + j].Value = grupoFamiliar.grf_c_numeroVagas;
                        worksheet.Cells["K" + j].Value = grupoFamiliar.grf_c_BlocoQuadra;
                        worksheet.Cells["L" + j].Value = grupoFamiliar.grf_c_LoteApto;
                        worksheet.Cells["M" + j].Value = grupoFamiliar.grf_c_status;
                        j++;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                for (var i = 0; i < columHeaders.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].AutoFitColumns();
                }

                return package.GetAsByteArray();
            }
        }

        public object SalvarGrupoFamiliar(GrupoFamiliarViewModel model)
        {
            Retorno retorno = new Retorno();
            retorno.status = "error";
            retorno.conteudo = "error";
            var retornoRgEstado = false;

            try
            {
                bool retornoSemLocalidade;

                if (!model.grf_cli_tcl_n_codigo.Equals("2"))
                {
                    retornoSemLocalidade = LocalidadeGrupoFamiliarService.verificaLocalidade(Convert.ToInt32(model.grf_n_codigo), Convert.ToInt32(model.grf_cli_n_codigo));
                }
                else
                {
                    retornoSemLocalidade = false;
                }

                if (!string.IsNullOrEmpty(model.grf_c_rg))
                    retornoRgEstado = verificaRgEstado(model);

                bool retornoCpf = verificaCpf(model);
                bool retornoEmail = verificaEmail(model);
                bool retornoRamal = model.grf_n_ramal != null ? verificaRamal(model) : false;
                if (retornoEmail)
                {
                    retorno.status = "error";
                    retorno.conteudo = "EmailExistente";

                    return retorno;
                }
                else if (retornoRamal)
                {
                    retorno.status = "error";
                    retorno.conteudo = "RamalExistente";

                    return retorno;
                }
                else if (retornoRgEstado)
                {
                    retorno.status = "error";
                    retorno.conteudo = "RgExistente";

                    return retorno;
                }
                else if (retornoCpf)
                {
                    retorno.status = "error";
                    retorno.conteudo = "CpfExistente";

                    return retorno;
                }
                if (retornoSemLocalidade)
                {
                    retorno.status = "error";
                    retorno.conteudo = "SemLocalidade";

                    return retorno;
                }

                if (model.acesso != null)
                { /*APENAS PARA TIPO COMERCIAL*/
                    var acesso = new AcessoViewModel
                    {
                        ace_n_codigo = !string.IsNullOrEmpty(model.grf_ace_n_codigo) ? Convert.ToInt32(model.grf_ace_n_codigo) : new int(),
                        ace_c_login = model?.acesso.ace_c_login,
                        ace_c_senha = model?.acesso.ace_c_senha,
                        ace_per_n_codigo = 4 //ATUALIZAR PARA 17 POSTERIORMENTE
                    };

                    AcessoService.InsertOrUpdate(acesso);
                    model.grf_ace_n_codigo = acesso.ace_n_codigo.ToString();
                }

                if (string.IsNullOrEmpty(model.grf_n_codigo) || model.grf_n_codigo.Equals("0"))
                {
                    var novoGrupoFamiliar = new tb_grf_grupoFamiliar()
                    {
                        grf_c_status = model.grf_c_status,
                        grf_c_tipo = model.grf_c_tipo,
                        grf_c_nomeResponsavel = model.grf_c_nomeResponsavel,
                        grf_c_rg = model.grf_c_rg,
                        grf_c_cpf = model.grf_c_cpf,
                        grf_c_telefone = model.grf_c_telefone,
                        grf_c_email = model.grf_c_email,
                        grf_c_numeroVagas = model.grf_c_numeroVagas,
                        grf_c_BlocoQuadra = model.grf_c_BlocoQuadra,
                        grf_c_LoteApto = model.grf_c_LoteApto,
                        grf_c_observacao = model.grf_c_observacao,
                        grf_c_celular = model.grf_c_celular,
                        grf_fot_n_codigo = !string.IsNullOrEmpty(model.grf_fot_n_codigo) && !model.grf_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.grf_fot_n_codigo) : new int?(),
                        grf_cli_n_codigo = !string.IsNullOrEmpty(model.grf_cli_n_codigo) && !model.grf_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.grf_cli_n_codigo) : new int?(),
                        grf_d_alteracao = DateTime.Now,
                        grf_c_usuario = model.grf_c_usuario,
                        grf_d_modificacao = DateTime.Now,
                        grf_c_unique = Guid.NewGuid(),
                        grf_d_atualizado = DateTime.Now,
                        grf_d_inclusao = DateTime.Now,
                        grf_n_ramal = !string.IsNullOrEmpty(model.grf_n_ramal) && !model.grf_n_ramal.Equals("0") ? Convert.ToInt32(model.grf_n_ramal) : new int?(),
                        grf_b_permiteHomeCare = (model.grf_b_permiteHomeCare != null ? Convert.ToBoolean(model.grf_b_permiteHomeCare.ToString()) : false),
                        grf_c_observacoesHomeCare = model.grf_c_observacoesHomeCare,
                        grf_ace_n_codigo = !string.IsNullOrEmpty(model.grf_ace_n_codigo) && !model.grf_ace_n_codigo.Equals("0") ? Convert.ToInt32(model.grf_ace_n_codigo) : new int?(),//REMOVER RELACIONAMENTO
                        grf_c_nomeSalaComercial = model.grf_c_nomeSalaComercial,
                        grf_c_estado = model.grf_c_estado
                    };

                    Insert(novoGrupoFamiliar);
                    context.SaveChanges();

                    AvisoGrupoFamiliarService.VincularAvisos(novoGrupoFamiliar.grf_n_codigo);
                    PetService.VincularPets(novoGrupoFamiliar.grf_n_codigo);
                    VeiculoService.VincularVeiculos(novoGrupoFamiliar.grf_n_codigo);
                    LocalidadeGrupoFamiliarService.VincularGrupoFamiliar(novoGrupoFamiliar.grf_n_codigo);

                    retorno.status = "success";
                    retorno.conteudo = "OK";
                    retorno.id = novoGrupoFamiliar.grf_n_codigo;
                }
                else
                {
                    var grupoFamiliar = (from grf in context.tb_grf_grupoFamiliar where grf.grf_n_codigo == Convert.ToInt32(model.grf_n_codigo) select grf).FirstOrDefault();
                    grupoFamiliar.grf_c_status = model.grf_c_status;
                    grupoFamiliar.grf_cli_n_codigo = Convert.ToInt32(model.grf_cli_n_codigo);
                    grupoFamiliar.grf_c_tipo = model.grf_c_tipo;
                    grupoFamiliar.grf_c_nomeResponsavel = model.grf_c_nomeResponsavel;
                    grupoFamiliar.grf_c_rg = model.grf_c_rg;
                    grupoFamiliar.grf_c_cpf = model.grf_c_cpf;
                    grupoFamiliar.grf_c_telefone = model.grf_c_telefone;
                    grupoFamiliar.grf_c_email = model.grf_c_email;
                    grupoFamiliar.grf_c_numeroVagas = model.grf_c_numeroVagas;
                    grupoFamiliar.grf_c_BlocoQuadra = model.grf_c_BlocoQuadra;
                    grupoFamiliar.grf_c_LoteApto = model.grf_c_LoteApto;
                    grupoFamiliar.grf_c_observacao = model.grf_c_observacao;
                    grupoFamiliar.grf_c_celular = model.grf_c_celular;
                    grupoFamiliar.grf_fot_n_codigo = !string.IsNullOrEmpty(model.grf_fot_n_codigo) && !model.grf_fot_n_codigo.Equals("0") ? Convert.ToInt32(model.grf_fot_n_codigo) : new int?();
                    grupoFamiliar.grf_cli_n_codigo = !string.IsNullOrEmpty(model.grf_cli_n_codigo) && !model.grf_cli_n_codigo.Equals("0") ? Convert.ToInt32(model.grf_cli_n_codigo) : new int?();
                    grupoFamiliar.grf_d_alteracao = DateTime.Now;
                    grupoFamiliar.grf_c_usuario = model.grf_c_usuario;
                    grupoFamiliar.grf_d_modificacao = DateTime.Now;
                    grupoFamiliar.grf_d_atualizado = DateTime.Now;
                    grupoFamiliar.grf_n_ramal = !string.IsNullOrEmpty(model.grf_n_ramal) && !model.grf_n_ramal.Equals("0") ? Convert.ToInt32(model.grf_n_ramal) : new int?();
                    grupoFamiliar.grf_b_permiteHomeCare = Convert.ToBoolean(model.grf_b_permiteHomeCare.ToString());
                    grupoFamiliar.grf_c_observacoesHomeCare = model.grf_c_observacoesHomeCare;
                    grupoFamiliar.grf_ace_n_codigo = !string.IsNullOrEmpty(model.grf_ace_n_codigo) ? Convert.ToInt32(model.grf_ace_n_codigo) : new int?();//REMOVER RELACIONAMENTO
                    grupoFamiliar.grf_c_nomeSalaComercial = model.grf_c_nomeSalaComercial;
                    grupoFamiliar.grf_c_estado = model.grf_c_estado;
                    inativaVinculados(model.grf_c_status, grupoFamiliar.grf_n_codigo);

                    Update(grupoFamiliar);
                    context.SaveChanges();
                    retorno.status = "success";
                    retorno.conteudo = "OK";
                    retorno.id = grupoFamiliar.grf_n_codigo;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return retorno;
            }
        }

        private string buscaLocalizacao(string grf_c_BlocoQuadra)
        {
            try
            {
                int id = Convert.ToInt32(grf_c_BlocoQuadra);
                string loc = (from local in context.tb_lcc_localidadeCliente where local.lcc_n_codigo == id select local).FirstOrDefault().lcc_c_descricao;
                return loc;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void inativaVinculados(string status, int grf)
        {
            List<tb_mor_Morador> listPessoas = (from mor in context.tb_mor_Morador where mor.mor_grf_n_codigo == grf select mor).ToList();
            if (status == "INATIVO")
            {
                foreach (var item in listPessoas)
                {
                    item.mor_b_ativoInativo = false;
                    morador.Update(item);
                    context.SaveChanges();

                    //SINCRONIZA MORADORES
                    SincronizarPlaca(item.mor_n_codigo);
                }
            }
            else
            {
                foreach (var item in listPessoas)
                {
                    item.mor_b_ativoInativo = true;
                    morador.Update(item);
                    context.SaveChanges();
                }
            }
        }

        public bool DeletarGrupoFamiliar(int id)
        {
            try
            {
                int? result = Context.tb_grf_grupoFamiliar.FirstOrDefault(w => w.grf_n_codigo == id).grf_ace_n_codigo;


                CatalogoService.DeletarCatalogoBuyGrupoFamiliar(id);
                Delete(context.tb_grf_grupoFamiliar.Find(id));
                context.SaveChanges();
                if (result != null)
                {
                    AcessoService.DeletarAcesso(result.Value);
                }

                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool GetResetSenha(int id)
        {
            try
            {
                var grupoFamiliar = context.tb_grf_grupoFamiliar.Find(id);
                grupoFamiliar.grf_c_senhaApp = null;

                Update(grupoFamiliar);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public GrupoFamiliarViewModel GetGruposByMorador(int idMorador)
        {
            return (from grf in Context.tb_grf_grupoFamiliar
                    join mor in Context.tb_mor_Morador on grf.grf_n_codigo equals mor.mor_grf_n_codigo
                    where mor.mor_n_codigo == idMorador
                    orderby grf.grf_c_nomeResponsavel ascending
                    select new GrupoFamiliarViewModel()
                    {
                        grf_n_codigo = grf.grf_n_codigo.ToString(),
                        grf_c_nomeResponsavel = grf.grf_c_nomeResponsavel,
                        grf_c_BlocoQuadra = grf.grf_c_BlocoQuadra,
                        grf_c_LoteApto = grf.grf_c_LoteApto,
                        grf_c_observacao = grf.grf_c_observacao,
                        grf_cli_n_codigo = grf.grf_cli_n_codigo.ToString(),

                    }).FirstOrDefault();
        }

        public bool verificaEmail(GrupoFamiliarViewModel model)
        {
            try
            {
                int idGrupo = Convert.ToInt32(model.grf_n_codigo);
                int idCliente = Convert.ToInt32(model.grf_cli_n_codigo);
                int grupoFamiliar = context.tb_grf_grupoFamiliar.Where(x => x.grf_c_email == model.grf_c_email && x.grf_n_codigo != idGrupo && x.grf_cli_n_codigo == idCliente).Count();

                if (grupoFamiliar > 0)
                {
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

        public bool verificaRgEstado(GrupoFamiliarViewModel model)
        {
            int idGrupo = Convert.ToInt32(model.grf_n_codigo);
            int idCliente = Convert.ToInt32(model.grf_cli_n_codigo);
            string inputIn = model.grf_c_rg;
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\\s]";
            string inputOut = Regex.Replace(inputIn, pattern, "");
            List<string> listaGrupoFamiliar = new List<string>();

            var grupoFamiliar = (from grf in context.tb_grf_grupoFamiliar
                                 where grf.grf_n_codigo != idGrupo
                                 && grf.grf_cli_n_codigo == idCliente
                                 select grf).ToList();

            for (int i = 0; i < grupoFamiliar.Count; i++)
            {
                listaGrupoFamiliar.Add(Regex.Replace(grupoFamiliar[i].grf_c_rg.ToString(), pattern, ""));
            }
            string[] arrayGrupo_rg = listaGrupoFamiliar.ToArray();
            for (int i = 0; i < arrayGrupo_rg.Length; i++)
            {
                if (inputOut == arrayGrupo_rg[i] && model.grf_c_estado == grupoFamiliar[i].grf_c_estado)
                {
                    return true;
                }
            }
            return false;
        }

        public bool verificaCpf(GrupoFamiliarViewModel model)
        {
            int idGrupo = Convert.ToInt32(model.grf_n_codigo);
            int idCliente = Convert.ToInt32(model.grf_cli_n_codigo);

            var grupoFamiliar = (from grf in context.tb_grf_grupoFamiliar
                                 where grf.grf_n_codigo != idGrupo
                                 && grf.grf_cli_n_codigo == idCliente
                                 && !string.IsNullOrEmpty(grf.grf_c_cpf)
                                 select grf).ToList();

            for (int i = 0; i < grupoFamiliar.Count; i++)
            {
                if (model.grf_c_cpf == grupoFamiliar[i].grf_c_cpf)
                {
                    return true;
                }
            }
            return false;
        }

        public bool verificaRamal(GrupoFamiliarViewModel model)
        {
            try
            {
                int idGrupo = Convert.ToInt32(model.grf_n_codigo);
                int ramal = Convert.ToInt32(model.grf_n_ramal);
                int grupoFamiliar = context.tb_grf_grupoFamiliar.Where(x => x.grf_n_ramal == ramal && x.grf_n_codigo != idGrupo).Count();
                if (grupoFamiliar > 0)
                {
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

        private void SincronizarPlaca(int codMor)
        {
            string controladoras = "";
            var tb_mor = (from mor in Context.tb_mor_Morador where mor.mor_n_codigo == codMor select mor).FirstOrDefault();
            var tb_cac = (from cac in Context.tb_cac_controleAcesso where cac.cac_mor_n_codigo == codMor select cac).ToList();
            List<tb_con_controladora> lstCon = (from con in Context.tb_con_controladora where con.con_cli_n_codigo == tb_mor.mor_cli_n_codigo && (con.con_c_modelo == "ZK" || con.con_c_modelo == "LINEAR HCS" || con.con_c_modelo == "CONTROL ID") select con).ToList();

            foreach (var item in lstCon)
            {
                if (item.con_c_modelo != "CITROX")
                    controladoras += item.con_n_codigo.ToString() + ",";
            }

            foreach (var item in tb_cac)
            {
                SincronizacaoPlacas.SalvarSincronizacaoPlacasInterna(Convert.ToInt32(tb_mor.mor_cli_n_codigo), controladoras, item.cac_n_codigo);
            }
        }

        private IQueryable<GrupoFamiliarViewModel> ObterQueryGrupoFamiliarFiltrador(GrupoFamiliarFilterModel filter)
        {

            var query = from gru in Context.tb_grf_grupoFamiliar
                        join cli in Context.tb_cli_cliente on gru.grf_cli_n_codigo equals cli.cli_n_codigo
                        where cli.cli_b_ativo == true
                        select new GrupoFamiliarViewModel
                        {
                            grf_n_codigo = gru.grf_n_codigo.ToString(),
                            grf_cli_n_codigo = gru.grf_cli_n_codigo.ToString(),
                            grf_c_nomeResponsavel = gru.grf_c_nomeResponsavel,
                            grf_c_rg = gru.grf_c_rg,
                            grf_c_cpf = gru.grf_c_cpf,
                            grf_c_telefone = gru.grf_c_telefone.Replace(" ", ""),
                            grf_c_celular = gru.grf_c_celular.Replace(" ", ""),
                            grf_c_status = gru.grf_c_status,
                            NomeCliente = cli.cli_c_nomeFantasia,
                            buscaSimples = gru.grf_c_nomeResponsavel + " " + gru.grf_c_rg + " " + gru.grf_c_cpf + " " + cli.cli_c_nomeFantasia,
                            grf_c_nomeSalaComercial = gru.grf_c_nomeSalaComercial,
                            buscaSimplesSala = gru.grf_c_nomeSalaComercial + " " + gru.grf_c_rg + " " + gru.grf_c_cpf + " " + cli.cli_c_nomeFantasia,
                            grf_c_estado = gru.grf_c_estado,
                            grf_cli_tcl_n_codigo = cli.cli_tcl_n_codigo.ToString(),
                        };

            if (!string.IsNullOrEmpty(filter.grf_cli_tcl_n_codigo))
            {
                query = query.Where(w => w.grf_cli_tcl_n_codigo == filter.grf_cli_tcl_n_codigo);
            }
            if (!string.IsNullOrEmpty(filter.idsClientes) && (!filter?.idsClientes?.Equals("todos") ?? false) && (!filter?.idsClientes?.Equals("NULL") ?? false) && (string.IsNullOrEmpty(filter.grf_cli_n_codigo_filter) || filter.grf_cli_n_codigo_filter.Equals("0")))
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.grf_cli_n_codigo));
            }
            if (!string.IsNullOrEmpty(filter.adm_salaComercial_filter))
            {
                query = query.Where(w => w.grf_n_codigo == filter.adm_salaComercial_filter);
            }
            //Filtros
            if (!string.IsNullOrEmpty(filter.buscaSimplesSala_filter))
            {
                query = query.Where(w => w.buscaSimplesSala.ToUpper().Contains(filter.buscaSimplesSala_filter.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.ToUpper().Contains(filter.buscaSimples_filter.ToUpper()));
            }
            if (!string.IsNullOrEmpty(filter.grf_c_status_filter))
            {
                var filtro = filter.grf_c_status_filter.ToUpper();
                query = query.Where(w => w.grf_c_status.ToUpper().Equals(filtro));
            }
            if (!string.IsNullOrEmpty(filter.grf_cli_n_codigo_filter) && (!filter?.grf_cli_n_codigo_filter?.Equals("todos") ?? false) && filter.grf_cli_n_codigo_filter != "0")
            {
                query = query.Where(w => w.grf_cli_n_codigo.Equals(filter.grf_cli_n_codigo_filter));
            }
            if (!string.IsNullOrEmpty(filter.grf_c_nomeSalaComercial_filter))
            {
                query = query.Where(w => w.grf_c_nomeSalaComercial.Contains(filter.grf_c_nomeSalaComercial_filter));
            }
            if (!string.IsNullOrEmpty(filter.grf_c_nomeResponsavel_filter))
            {
                var filtro = filter.grf_c_nomeResponsavel_filter.ToUpper();
                query = query.Where(w => w.grf_c_nomeResponsavel.ToUpper().Contains(filtro));
            }
            else if (!string.IsNullOrEmpty(filter.grf_c_cpf_filter))
            {
                string auxDoc = filter.grf_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.grf_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.grf_c_rg_filter))
            {
                string auxDoc = filter.grf_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.grf_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.grf_c_telefone_filter))
            {
                string auxFone = filter.grf_c_telefone_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.grf_c_telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            var verificaTipo = filter.grf_cli_tcl_n_codigo;

            if (verificaTipo != "3")
            {
                query = query.OrderBy(x => x.grf_c_status == "inativo").ThenBy(x => x.grf_c_nomeResponsavel);
            }
            else
            {
                query = query.OrderBy(x => x.grf_c_status == "inativo").ThenBy(x => x.grf_c_nomeSalaComercial);
            }

            return query;
        }

        public GrupoFamiliarViewModel SalaComercial(int id)
        {
            //método que retorna a sala comercial de acordo com o catálogo (aprovação de catálogo)
            var sala = from s in context.tb_grf_grupoFamiliar
                       join cli in context.tb_cli_cliente on s.grf_cli_n_codigo equals cli.cli_n_codigo
                       where s.grf_n_codigo == id
                       select new GrupoFamiliarViewModel
                       {
                           grf_cli_n_codigo = cli.cli_c_nomeFantasia,
                           grf_c_status = s.grf_c_status,
                           grf_c_nomeResponsavel = s.grf_c_nomeResponsavel,
                           grf_c_rg = s.grf_c_rg,
                           grf_c_cpf = s.grf_c_cpf,
                           grf_c_email = s.grf_c_email,
                           grf_c_telefone = s.grf_c_telefone,
                           grf_n_ramal = s.grf_n_ramal.ToString(),
                           grf_c_celular = s.grf_c_celular,
                           grf_c_BlocoQuadra = s.grf_c_BlocoQuadra,
                           grf_c_LoteApto = s.grf_c_LoteApto,
                       };

            return sala.FirstOrDefault();
        }

        public IPagedList<MembrosGrupoFamiliarViewModel> GetMembrosGrupoFamiliar(GrupoFamiliarFilterModel filter)
        {
            return (from mor in context.tb_mor_Morador
                    where mor.mor_grf_n_codigo == Convert.ToInt32(filter.grf_n_codigo)
                    select new MembrosGrupoFamiliarViewModel
                    {
                        grf_mor_n_codigo = mor.mor_n_codigo.ToString(),
                        grf_mor_c_nome = mor.mor_c_nome.ToString(),
                        grf_mor_c_telefone = string.IsNullOrEmpty(mor.mor_c_celular) 
                        ? mor.mor_c_telefonePermitido.Replace(" ", "")
                        : mor.mor_c_celular.Replace(" ", ""),
                        grf_mor_c_rg = mor.mor_c_rg
                    }).ToList().ToPagedList(filter.paginaDataTable, filter.quantidade);
        }

        public IPagedList<GrupoFamiliarViewModel> GetGrupoFamiliarBuscarFiltrador(GrupoFamiliarFilterModel filter)
        {

            var query = from gru in Context.tb_grf_grupoFamiliar
                        join cli in Context.tb_cli_cliente on gru.grf_cli_n_codigo equals cli.cli_n_codigo
                        join lcg in context.tb_lcg_localidadeClienteGrupoFamiliar on gru.grf_n_codigo equals lcg.lcg_grf_n_codigo
                        join lccB in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoBlocoQuadra equals lccB.lcc_n_codigo
                        join lccL in context.tb_lcc_localidadeCliente on lcg.lcg_lcc_n_codigoLoteApto equals lccL.lcc_n_codigo
                        join vec in context.tb_vec_veiculo on gru.grf_n_codigo equals vec.vec_grf_n_codigo into tempVeiculo
                        from veiculo in tempVeiculo.DefaultIfEmpty()
                        where cli.cli_b_ativo == true
                        select new GrupoFamiliarViewModel
                        {
                            grf_n_codigo = gru.grf_n_codigo.ToString(),
                            grf_cli_n_codigo = gru.grf_cli_n_codigo.ToString(),
                            grf_c_nomeResponsavel = gru.grf_c_nomeResponsavel,
                            grf_c_rg = gru.grf_c_rg,
                            grf_c_cpf = gru.grf_c_cpf,
                            grf_c_telefone = gru.grf_c_telefone.Replace(" ", ""),
                            grf_c_celular = gru.grf_c_celular.Replace(" ", ""),
                            grf_c_status = gru.grf_c_status,
                            grf_c_BlocoQuadra = lccB.lcc_c_descricao,
                            grf_c_LoteApto = lccL.lcc_c_descricao,
                            NomeCliente = cli.cli_c_nomeFantasia,
                            buscaSimples = gru.grf_c_nomeResponsavel + " " + gru.grf_c_rg + " " + gru.grf_c_cpf + " " + cli.cli_c_nomeFantasia,
                            grf_c_nomeSalaComercial = gru.grf_c_nomeSalaComercial,
                            buscaSimplesSala = gru.grf_c_nomeSalaComercial + " " + gru.grf_c_rg + " " + gru.grf_c_cpf + " " + cli.cli_c_nomeFantasia,
                            grf_c_estado = gru.grf_c_estado,
                            grf_cli_tcl_n_codigo = cli.cli_tcl_n_codigo.ToString(),
                            grf_vec_c_placa = veiculo.vec_c_placa,
                        };

            if (!string.IsNullOrEmpty(filter.grf_cli_tcl_n_codigo))
            {
                query = query.Where(w => w.grf_cli_tcl_n_codigo == filter.grf_cli_tcl_n_codigo);
            }
            if (!string.IsNullOrEmpty(filter.idsClientes) && (!filter?.idsClientes?.Equals("todos") ?? false) && (!filter?.idsClientes?.Equals("NULL") ?? false) && (string.IsNullOrEmpty(filter.grf_cli_n_codigo_filter) || filter.grf_cli_n_codigo_filter.Equals("0")))
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.grf_cli_n_codigo));
            }
            if (!string.IsNullOrEmpty(filter.grf_cli_n_codigo_filter) && (!filter?.grf_cli_n_codigo_filter?.Equals("todos") ?? false) && filter.grf_cli_n_codigo_filter != "0")
            {
                query = query.Where(w => w.grf_cli_n_codigo.Equals(filter.grf_cli_n_codigo_filter));
            }
            if (!string.IsNullOrEmpty(filter.grf_c_nomeSalaComercial_filter))
            {
                query = query.Where(w => w.grf_c_nomeSalaComercial.Contains(filter.grf_c_nomeSalaComercial_filter));
            }
            if (!string.IsNullOrEmpty(filter.grf_c_nomeResponsavel_filter))
            {
                var filtro = filter.grf_c_nomeResponsavel_filter.ToUpper();
                query = query.Where(w => w.grf_c_nomeResponsavel.ToUpper().Contains(filtro));
            }
            else if (!string.IsNullOrEmpty(filter.grf_c_cpf_filter))
            {
                string auxDoc = filter.grf_c_cpf_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.grf_c_cpf.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.grf_c_rg_filter))
            {
                string auxDoc = filter.grf_c_rg_filter.Replace(".", "").Replace("-", "");
                query = query.Where(w => w.grf_c_rg.Replace(".", "").Replace("-", "").Contains(auxDoc));
            }
            else if (!string.IsNullOrEmpty(filter.grf_c_telefone_filter))
            {
                string auxFone = filter.grf_c_telefone_filter.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                query = query.Where(w => w.grf_c_telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Contains(auxFone));
            }

            if (!string.IsNullOrEmpty(filter.grf_vec_c_placaVeiculo_filter))
            {
                query = query.Where(x => x.grf_vec_c_placa.Contains(filter.grf_vec_c_placaVeiculo_filter));
            }

            if (!string.IsNullOrEmpty(filter.grf_c_BlocoQuadra_filter))
            {
                query = query.Where(x => x.grf_c_BlocoQuadra == filter.grf_c_BlocoQuadra_filter);
            }

            if (!string.IsNullOrEmpty(filter.grf_c_LoteApto_filter))
            {
                query = query.Where(x => x.grf_c_LoteApto == filter.grf_c_LoteApto_filter);
            }

            return query.DistinctBy(p => p.grf_n_codigo).ToPagedList(filter.paginaDataTable, filter.quantidade); ;
        }
    }
}