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

namespace Iconnect.Aplicacao.Services
{
    class ControladoraService : RepositoryBase<tb_con_controladora>, IControladoraService
    {
        private readonly IconnectCoreContext _context;

        public ControladoraService(IconnectCoreContext context) : base(context)
        {
            _context = context;
        }

        private IPontosAcessoService _pontosAcessoService;
        public IPontosAcessoService PontosAcessoService
        {
            get
            {
                if (_pontosAcessoService == null)
                {
                    _pontosAcessoService = new PontosAcessoService(_context);
                }
                return _pontosAcessoService;
            }
        }

        private ISincronizacaoPlacasService _sincronizacaoPlacasService;
        public ISincronizacaoPlacasService SincronizacaoPlacasService
        {
            get
            {
                if (_sincronizacaoPlacasService == null)
                {
                    _sincronizacaoPlacasService = new SincronizacaoPlacasService(_context);
                }
                return _sincronizacaoPlacasService;
            }
        }

        public IPagedList<ControladoraViewModel> GetControladoraFiltrado(ControladoraFilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.idsClientes))
            {
                return new PagedList<ControladoraViewModel>(null, 1, 1);
            }

            var query = QueryControladoraFiltrado(filter);

            //Ajuste tamanho textos
            var listaControladora = query.ToPagedList(filter.paginaDataTable, filter.quantidade);
            foreach (var pessoa in listaControladora)
            {
                if (pessoa.NomeCliente.Length > 25)
                {
                    pessoa.NomeCliente = pessoa.NomeCliente.Substring(0, 25) + "...";
                }
            }

            return listaControladora;
        }

        public byte[] GeraExcel(ControladoraFilterModel filter)
        {
            var query = QueryControladoraFiltrado(filter);
            var lstControladora = query.ToList();

            using (var package = new ExcelPackage())
            {
                var columHeaders = new string[]
                {
                    "Cliente",
                    "Nome",
                    "Fabricante",
                    "DDNS",
                    "IP",
                    "Porta",
                    "Status",
                };

                var worksheet = package.Workbook.Worksheets.Add("Controladoras");
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
                    foreach (var con in lstControladora)
                    {
                        worksheet.Cells["A" + j].Value = con.NomeCliente;
                        worksheet.Cells["B" + j].Value = con.con_c_nome;
                        worksheet.Cells["C" + j].Value = con.con_c_modelo;
                        worksheet.Cells["D" + j].Value = con.con_c_dominioDDNS;
                        worksheet.Cells["E" + j].Value = con.con_c_ip;
                        worksheet.Cells["F" + j].Value = con.con_c_porta;
                        worksheet.Cells["G" + j].Value = con.con_b_ativo;
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

        public ControladoraViewModel GetControladora(int id)
        {
            var query = (from con in Context.tb_con_controladora
                         join cli in Context.tb_cli_cliente on con.con_cli_n_codigo equals cli.cli_n_codigo
                         where con.con_n_codigo == id
                         select new ControladoraViewModel
                         {
                             NomeCliente = cli.cli_c_nomeFantasia,
                             con_cli_n_codigo = con.con_cli_n_codigo.ToString(),
                             con_c_nome = con.con_c_nome,
                             con_c_modelo = con.con_c_modelo,
                             con_c_ip = con.con_c_ip,
                             con_c_dominioDDNS = con.con_c_dominioDDNS,
                             con_c_porta = con.con_c_porta,
                             con_b_ativo = con.con_b_ativo.Value ? "ATIVO" : "INATIVO",
                             con_c_perfis = con.con_c_perfis,
                             con_n_quantidadePortas = con.con_n_quantidadePortas.ToString(),
                             con_c_senha = con.con_c_senha,
                         });

            return query.FirstOrDefault();
        }

        public List<ControladoraViewModel> GetControladoraByCliente(int id)
        {
            var query = (from con in Context.tb_con_controladora
                         where con.con_cli_n_codigo == id && con.con_b_ativo == true
                         select new ControladoraViewModel
                         {
                             con_n_codigo = con.con_n_codigo.ToString(),
                             con_c_nome = con.con_c_nome
                         }).OrderBy(x => x.con_c_nome);

            return query.ToList();
        }

        public object SalvarControladora(ControladoraViewModel model)
        {
            Retorno retorno = new Retorno();

            try
            {
                var duplicado = !string.IsNullOrEmpty(model.con_c_ip) ? ValidaDuplicidade(model) : false;
                if (duplicado == true)
                {
                    retorno.status = "duplicado";
                    retorno.conteudo = "Já existe um dispositivo cadastrado com esse IP.";
                    return retorno;
                }
                if (string.IsNullOrEmpty(model.con_n_codigo) || model.con_n_codigo.ToString() == "0")
                {
                    var clienteFree = (from con in Context.tb_con_controladora
                                       join cli in Context.tb_cli_cliente on con.con_cli_n_codigo equals cli.cli_n_codigo
                                       where cli.cli_n_codigo == Convert.ToInt32(model.con_cli_n_codigo) && cli.cli_b_free == true
                                       select con).Count();

                    var qtdCadastroFree = 5;

                    if (clienteFree < qtdCadastroFree)
                    {
                        var novaControladora = new tb_con_controladora()
                        {
                            con_cli_n_codigo = Convert.ToInt32(model.con_cli_n_codigo),
                            con_c_nome = model.con_c_nome,
                            con_c_modelo = model.con_c_modelo,
                            con_c_ip = model.con_c_ip,
                            con_c_dominioDDNS = model.con_c_dominioDDNS,
                            con_c_usuario = "FELIPE",
                            con_c_senha = string.IsNullOrEmpty(model.con_c_senha) ? string.Empty : model.con_c_senha.ToLower(),
                            con_c_porta = model.con_c_porta,
                            con_b_ativo = model.con_b_ativo == "ATIVO",
                            con_d_alteracao = DateTime.Now,
                            con_c_usuarioAlteracao = "FELIPE",
                            con_d_modificacao = DateTime.Now,
                            con_c_unique = Guid.NewGuid(),
                            con_d_atualizado = DateTime.Now,
                            con_d_inclusao = DateTime.Now,
                            con_c_perfis = model.con_c_perfis,
                            con_n_quantidadePortas = Convert.ToInt32(model.con_n_quantidadePortas),
                        };

                        Insert(novaControladora);
                        _context.SaveChanges();

                        PontosAcessoService.VincularPontoAcesso(novaControladora.con_n_codigo, novaControladora.con_cli_n_codigo);

                        retorno.status = "ok";
                        retorno.conteudo = "true";
                        return retorno;
                    }
                    else
                    {
                        retorno.status = "erro_gratuito";
                        retorno.conteudo = "O limite de cadastros de 5 controladoras da conta gratuita foi alcançado";
                        return retorno;
                    }
                }
                else
                {
                    var controladora = (from con in _context.tb_con_controladora where con.con_n_codigo == Convert.ToInt32(model.con_n_codigo) select con).FirstOrDefault();
                    controladora.con_cli_n_codigo = Convert.ToInt32(model.con_cli_n_codigo);
                    controladora.con_c_nome = model.con_c_nome;
                    controladora.con_c_modelo = model.con_c_modelo;
                    controladora.con_c_ip = model.con_c_ip;
                    controladora.con_c_dominioDDNS = model.con_c_dominioDDNS;
                    controladora.con_c_senha = model.con_c_senha;
                    controladora.con_c_porta = model.con_c_porta;
                    controladora.con_b_ativo = model.con_b_ativo == "ATIVO";
                    controladora.con_d_alteracao = DateTime.Now;
                    controladora.con_c_usuarioAlteracao = "FELIPE";
                    controladora.con_d_modificacao = DateTime.Now;
                    controladora.con_d_atualizado = DateTime.Now;
                    controladora.con_c_perfis = model.con_c_perfis;
                    controladora.con_n_quantidadePortas = Convert.ToInt32(model.con_n_quantidadePortas);

                    Update(controladora);
                    _context.SaveChanges();
                }

                retorno.status = "ok";
                retorno.conteudo = "true";
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.conteudo = "false";
                return retorno;
            }
        }

        public bool DeletarControladora(int id)
        {
            try
            {
                Delete(_context.tb_con_controladora.Find(id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public bool ExcluirTodosPontosAcesso(ControladoraViewModel model)
        {
            try
            {
                List<tb_pta_pontosAcesso> lstPontoAcesso = new List<tb_pta_pontosAcesso>();

                if (string.IsNullOrEmpty(model.con_n_codigo) || model.con_n_codigo.ToString() == "0")
                {
                    lstPontoAcesso = _context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == null).ToList();
                }
                else
                {
                    //Atualiza alterações da controladora
                    try
                    {
                        var controladora = (from con in _context.tb_con_controladora where con.con_n_codigo == Convert.ToInt32(model.con_n_codigo) select con).FirstOrDefault();
                        if (controladora != null)
                        {
                            controladora.con_c_modelo = model.con_c_modelo;
                            controladora.con_n_quantidadePortas = Convert.ToInt32(model.con_n_quantidadePortas);

                            Update(controladora);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception) { }

                    //Lista pontos de acesso dessa controlaodra
                    lstPontoAcesso = _context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == Convert.ToInt32(model.con_n_codigo)).ToList();
                }

                if (lstPontoAcesso.Count > 0)
                {
                    _context.tb_pta_pontosAcesso.RemoveRange(lstPontoAcesso);
                    _context.SaveChanges();
                }


                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public List<GenericList> RebindComboPorta(ControladoraViewModel model)
        {
            try
            {
                List<tb_pta_pontosAcesso> lstPontoAcesso = new List<tb_pta_pontosAcesso>();

                if (string.IsNullOrEmpty(model.con_n_codigo) || model.con_n_codigo.ToString() == "0")
                {
                    lstPontoAcesso = _context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == null).ToList();
                }
                else
                {
                    lstPontoAcesso = _context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == Convert.ToInt32(model.con_n_codigo)).ToList();
                }


                //Verifica qual a qtd portar definida da controladora
                int numPortasControladora = 0;

                if ((model.con_c_modelo?.ToUpper()?.Equals("ZK") ?? false) || (model.con_c_modelo?.ToUpper()?.Equals("GAREN") ?? false))
                {
                    if (!int.TryParse(model.con_n_quantidadePortas, out numPortasControladora))
                    {
                        //Default é 4
                        numPortasControladora = 4;
                    }
                }
                else
                {
                    //Default é 4
                    numPortasControladora = 4;
                }

                List<int> portas = new List<int>();
                if (numPortasControladora == 4)
                {
                    bool controladoraCitrox = false;
                    try
                    {
                        if (model.con_c_modelo == "CITROX")
                        {
                            controladoraCitrox = true;
                        }
                    }
                    catch (Exception) { }


                    //Se for 4 portas, é o padrão
                    portas = new List<int> { 1, 2, 3, 4 };
                    if (controladoraCitrox)
                    {
                        foreach (var pta in lstPontoAcesso)
                        {
                            if (pta.pta_n_indexPorta != null && pta.pta_n_codigo != Convert.ToInt32(model.con_c_porta))
                            {
                                portas.Remove(Convert.ToInt32(pta.pta_n_indexPorta + 1));
                            }
                        }
                    }
                    else
                    {
                        foreach (var pta in lstPontoAcesso)
                        {
                            if (pta.pta_n_indexPorta != null && pta.pta_n_codigo != Convert.ToInt32(model.con_c_porta))
                            {
                                portas.Remove(Convert.ToInt32(pta.pta_n_indexPorta));
                            }
                        }
                    }
                }
                else
                {
                    //Verifica se é 1 porta ou 2, especifico ZK
                    if (numPortasControladora == 1)
                    {
                        portas = new List<int> { 1 };
                    }
                    else if (numPortasControladora == 2)
                    {
                        portas = new List<int> { 1, 2 };
                    }

                    //Caso
                    if (lstPontoAcesso.Count > 0)
                    {
                        var lstPontosPorta1 = lstPontoAcesso.Where(x => x.pta_n_indexPorta == 1 && x.pta_n_codigo != Convert.ToInt32(model.con_c_porta)).ToList();
                        if (lstPontosPorta1.Count >= 2)
                        {
                            portas.Remove(1);
                        }

                        var lstPontosPorta2 = lstPontoAcesso.Where(x => x.pta_n_indexPorta == 2 && x.pta_n_codigo != Convert.ToInt32(model.con_c_porta)).ToList();
                        if (lstPontosPorta2.Count >= 2)
                        {
                            portas.Remove(2);
                        }
                    }
                }

                List<GenericList> lstRetorno = new List<GenericList>();
                foreach (var porta in portas)
                {
                    var item = new GenericList();

                    item.text = porta.ToString();
                    item.value = porta.ToString();

                    lstRetorno.Add(item);
                }

                return lstRetorno;
            }
            catch (Exception erro)
            {
            }

            return null;
        }

        public List<GenericList> RebindComboFluxo(ControladoraViewModel model)
        {
            try
            {
                int? indexPorta = null;

                //Verifica qual a qtd portas definida da controladora
                int numPortasControladora = 0;

                if (model.con_c_modelo == "ZK")
                {
                    if (!int.TryParse(model.con_n_quantidadePortas, out numPortasControladora))
                    {
                        //Default é 4
                        numPortasControladora = 4;
                    }
                }
                else
                {
                    //Default é 4
                    numPortasControladora = 4;
                }

                //Default
                List<string> fluxos = new List<string> { "ENTRADA", "SAIDA", "BIDIRECIONAL" };

                if (numPortasControladora != 4)
                {
                    indexPorta = Convert.ToInt32(model.con_c_porta);

                    int idPorta = 0; // Convert.ToInt32(model.con_c_porta);
                    if (idPorta != 0)
                    {
                        tb_pta_pontosAcesso auxPonto = _context.tb_pta_pontosAcesso.Find(idPorta);
                        if (auxPonto != null)
                        {
                            indexPorta = auxPonto.pta_n_indexPorta;
                        }
                    }

                    fluxos = new List<string> { "ENTRADA", "SAIDA" };
                    if (indexPorta != null && indexPorta != 0)
                    {
                        //Lista os pontos de acesso da controladora ou se for novo cadastro os com con_n_Codigo = null
                        List<tb_pta_pontosAcesso> lstPontoAcesso = new List<tb_pta_pontosAcesso>();
                        if (string.IsNullOrEmpty(model.con_n_codigo) || model.con_n_codigo.ToString() == "0")
                        {
                            lstPontoAcesso = _context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == null && x.pta_n_indexPorta == indexPorta).ToList();
                        }
                        else
                        {
                            lstPontoAcesso = _context.tb_pta_pontosAcesso.Where(x => x.pta_con_n_codigo == Convert.ToInt32(model.con_n_codigo) && x.pta_n_indexPorta == indexPorta).ToList();
                        }

                        var auxLstPontos = lstPontoAcesso.Where(x => x.pta_c_fluxo == "ENTRADA" && x.pta_n_codigo != idPorta).ToList();
                        if (auxLstPontos.Count >= 1)
                        {
                            fluxos.Remove("ENTRADA");
                        }

                        auxLstPontos = lstPontoAcesso.Where(x => x.pta_c_fluxo == "SAIDA" && x.pta_n_codigo != idPorta).ToList();
                        if (auxLstPontos.Count >= 1)
                        {
                            fluxos.Remove("SAIDA");
                        }
                    }
                }

                List<GenericList> lstRetorno = new List<GenericList>();
                foreach (var fluxo in fluxos)
                {
                    var item = new GenericList();

                    item.text = fluxo.ToString();
                    item.value = fluxo.ToString();

                    lstRetorno.Add(item);
                }

                return lstRetorno;
            }
            catch (Exception erro)
            {
            }
            return null;
        }

        public bool SincronizarAlteracoesPlacas(int cli_n_codigo, string sin_c_controladoras)
        {
            try
            {
                SincronizacaoPlacasService.SalvarSincronizacaoPlacasExterna(cli_n_codigo, sin_c_controladoras);

                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        private IQueryable<ControladoraViewModel> QueryControladoraFiltrado(ControladoraFilterModel filter)
        {
            var query = (from con in Context.tb_con_controladora
                         join cli in Context.tb_cli_cliente on con.con_cli_n_codigo equals cli.cli_n_codigo
                         where cli.cli_b_ativo == true
                         select new ControladoraViewModel
                         {
                             con_n_codigo = con.con_n_codigo.ToString(),
                             NomeCliente = cli.cli_c_nomeFantasia,
                             con_cli_n_codigo = con.con_cli_n_codigo.ToString(),
                             con_c_nome = con.con_c_nome,
                             con_c_modelo = con.con_c_modelo,
                             con_c_ip = con.con_c_ip,
                             con_c_porta = con.con_c_porta,
                             con_b_ativo = con.con_b_ativo.Value ? "Ativo" : "Inativo",
                             buscaSimples = cli.cli_c_nomeFantasia + " " + con.con_c_nome + " " + con.con_c_modelo
                         });


            if (!string.IsNullOrEmpty(filter.idsClientes) && (!filter?.idsClientes?.Equals("todos") ?? false) && (!filter?.idsClientes?.Equals("NULL") ?? false) && string.IsNullOrEmpty(filter.con_cli_n_codigo_filter))
            {
                var ids = filter.idsClientes.Split(",");
                query = query.Where(w => ids.Contains(w.con_cli_n_codigo));
            }

            if (!string.IsNullOrEmpty(filter.buscaSimples_filter))
            {
                query = query.Where(w => w.buscaSimples.Contains(filter.buscaSimples_filter));
            }

            if (!string.IsNullOrEmpty(filter.con_cli_n_codigo_filter))
            {
                query = query.Where(w => w.con_cli_n_codigo.Equals(filter.con_cli_n_codigo_filter));
            }

            if (!string.IsNullOrEmpty(filter.con_c_nome_filter))
            {
                query = query.Where(w => w.con_c_nome.Contains(filter.con_c_nome_filter));
            }

            if (!string.IsNullOrEmpty(filter.con_c_modelo_filter))
            {
                query = query.Where(w => w.con_c_modelo.Contains(filter.con_c_modelo_filter));
            }

            if (!string.IsNullOrEmpty(filter.con_b_ativo_filter))
            {
                query = query.Where(w => w.con_b_ativo.Equals(filter.con_b_ativo_filter));
            }

            //Ordenação
            query = query.OrderBy(x => x.con_b_ativo == "inativo").ThenBy(x => x.con_c_nome);

            return query;
        }

        public bool ValidaDuplicidade(ControladoraViewModel model)
        {
            var query = (from con in Context.tb_con_controladora
                         where con.con_c_ip == model.con_c_ip
                         && con.con_cli_n_codigo == Convert.ToInt32(model.con_cli_n_codigo)
                         && con.con_n_codigo != Convert.ToInt32(model.con_n_codigo)
                         select con).Count();
            if (query != 0)
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