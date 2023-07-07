
using Iconnect.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Iconnect.Aplicacao.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Iconnect.Aplicacao;
using System.Threading.Tasks;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstaladorController : PadraoController
    {
        private IWebHostEnvironment _hostEnvironment;
        private readonly IConfiguration Configuration;


        private readonly ILogger<InstaladorController> _logger;
        private readonly IServiceWrapper _service;

        private static bool usuarioWindows = true;


        public InstaladorController(

            ILogger<InstaladorController> logger,
            IHttpContextAccessor acessor,
            IServiceWrapper service,

            IWebHostEnvironment environment,
            IConfiguration configuration

        ) : base(acessor)
        {
            _hostEnvironment = environment;
            Configuration = configuration;

            _logger = logger;
            _service = service;
        }

        public static string conexaoOffline
        {
            get
            {
                if (usuarioWindows)
                {
                    return "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true";
                }
                else
                {
                    return "Server=(localdb)\\mssqllocaldb;Database=master;user id=iconnect.offline;password=" + BancoService.senhaBancoOffline + ";MultipleActiveResultSets=true";
                }
            }
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("getVerificaEstado")]
        public ActionResult VerificarEstado()
        {
            JObject retorno = new JObject();
            List<Dictionary<string, string>> Etapas = new List<Dictionary<string, string>>();
            try
            {
                if (!Directory.Exists(@"C:\Iconnect\db"))
                {
                    Etapas.Add(new Dictionary<string, string>()
                    {
                        {"status","nao"},
                        {"etapa","pastaBanco"}
                    });
                }
                else
                {
                    Etapas.Add(new Dictionary<string, string>()
                    {
                        {"status","sim"},
                        {"etapa","pastaBanco"}
                    });


                    if (!TestarConexaoLocalDB())
                    {
                        Etapas.Add(new Dictionary<string, string>()
                        {
                            {"status","nao"},
                            {"etapa","conexaoLocalDB"}
                        });
                    }
                    else
                    {
                        Etapas.Add(new Dictionary<string, string>()
                        {
                            {"status","sim"},
                            {"etapa","conexaoLocalDB"}
                        });


                        if (!dbCriado())
                        {
                            Etapas.Add(new Dictionary<string, string>()
                            {
                                {"status","nao"},
                                {"etapa","dbCriado"}
                            });
                        }
                        else
                        {
                            Etapas.Add(new Dictionary<string, string>()
                            {
                                {"status","sim"},
                                {"etapa","dbCriado"}
                            });

                            if (!CargaInicial())
                            {
                                Etapas.Add(new Dictionary<string, string>()
                                {
                                    {"status","nao"},
                                    {"etapa","cargaInicial"}
                                });
                            }
                            else
                            {
                                Etapas.Add(new Dictionary<string, string>()
                                {
                                    {"status","sim"},
                                    {"etapa","cargaInicial"}
                                });


                                if (!ClientesNaBase())
                                {
                                    Etapas.Add(new Dictionary<string, string>()
                                    {
                                        {"status","nao"},
                                        {"etapa","cargaCliente"}
                                    });
                                }
                                else
                                {
                                    Etapas.Add(new Dictionary<string, string>()
                                    {
                                        {"status","sim"},
                                        {"etapa","cargaCliente"}
                                    });

                                    if (!LicencaValida())
                                    {
                                        Etapas.Add(new Dictionary<string, string>()
                                        {
                                            {"status","nao"},
                                            {"etapa","Licenca"}
                                        });
                                    }
                                    else
                                    {
                                        Etapas.Add(new Dictionary<string, string>()
                                        {
                                            {"status","sim"},
                                            {"etapa","Licenca"}
                                        });

                                        if (usuarioWindows == true)
                                        {
                                            AjustarUsuarioSQL();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                retorno.Add("etapas", JToken.FromObject(Etapas));
            }
            catch (Exception)
            {
                BadRequest();
            }

            return Ok(retorno.ToString());
        }

        [HttpGet]
        [Route("getCodInstalacao")]
        public ActionResult GetCodInstalacao()
        {
            //JObject retorno = new JObject();
            string codInstalacao = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        command.CommandText = "use dbIconnect select cli_c_codInstalacaoOffline from tb_cli_cliente";
                        connection.Open();

                        object aux = command.ExecuteScalar();
                        try
                        {
                            codInstalacao = aux.ToString();
                            //retorno.Add(codInstalacao);
                            // retorno.Add("codigo", JToken.FromObject(Etapas));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                return Ok(JToken.FromObject(codInstalacao));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        private void AjustarUsuarioSQL()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        command.CommandText = "DECLARE @comandoSql VARCHAR(MAX) = 'ALTER LOGIN [' + (SELECT SYSTEM_USER) +'] DISABLE'; EXEC(@comandoSql); ";
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ApagarDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        command.CommandText = "DROP DATABASE dbIconnect;";
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private bool ClientesNaBase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        command.CommandText = "use dbIconnect select count(cli_n_codigo) from tb_cli_cliente";
                        connection.Open();
                        int qtd = (int)command.ExecuteScalar();
                        return qtd > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private bool LicencaValida()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        command.CommandText = "use dbIconnect select cli_d_dataExpiracao from tb_cli_cliente";
                        connection.Open();

                        object auxRetorno = command.ExecuteScalar();

                        DateTime dtExpiracao;
                        if (DateTime.TryParse(auxRetorno.ToString(), out dtExpiracao))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        [HttpGet]
        [Route("getCriaPasta")]
        public ActionResult CriarPasta()
        {
            try
            {
                if (!Directory.Exists(@"C:\Iconnect\db"))
                {
                    Directory.CreateDirectory(@"C:\Iconnect\db");
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("getBuscarCliente/{cliente}")]
        public ActionResult BuscarCliente(string cliente)
        {
            try
            {
                string script = " select * from tb_cli_cliente inner join tb_emp_empresa on emp_n_codigo = cli_emp_n_codigo inner join tb_mol_modulosLiberados on mol_n_codigo = cli_mol_n_codigo where cli_c_codigoreferencia = '" + cliente + "'";

                DataTable dtCliente = new DataTable();

                try
                {
                    string queryString = script;

                    string sinc = Configuration.GetSection("AppSettings")["sincronizandoCom"];

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.CommandText = queryString;
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Connection = new SqlConnection(
 
                        BancoService.getConnectionSincronizacao(
                         Configuration.GetSection("AppSettings")["sincronizandoCom"]
                       )

                    );
                    adapter.Fill(dtCliente);

                    if (dtCliente.Rows.Count > 0)
                    {
                        ImportarCliente(dtCliente);
                    }
                    else
                    {
                        return Ok(false);
                    }

                }
                catch (Exception ex)
                {

                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(false); throw;
            }
        }

        [HttpGet]
        [Route("getValidarLicenca/{codigoInstalacao}/{serial}")]
        public ActionResult ValidarLicenca(string codigoInstalacao, string serial)
        {

            try
            {
                bool licencaValida = _service.SegurancaService.IsValid(codigoInstalacao, serial);
                if (!licencaValida)
                {
                    return Ok(false);
                }

                DateTime dtExpiracao;

                try
                {
                    dtExpiracao = _service.SegurancaService.getDataExpiracao(codigoInstalacao, serial).Value;
                    if (dtExpiracao != null)
                    {
                        if (dtExpiracao < DateTime.Now)
                        {
                            return Ok(false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Ok(false);
                }

                DateTime dtCriacao = _service.SegurancaService.getDataCriacao(codigoInstalacao, serial).Value;
                int diasLicenca = (int)(dtExpiracao - dtCriacao).TotalDays;

                //Atualiza licença no banco local
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        connection.Open();

                        command.CommandText = "use dbIconnect update tb_cli_cliente set cli_c_codInstalacaoOffline = '" + codigoInstalacao + "', cli_n_numDiasExpiracao = " + diasLicenca + ", cli_c_serial = '" + serial + "', cli_d_dataCriacao = '" + dtCriacao.ToString("yyyy-MM-dd") + "', cli_d_dataExpiracao = '" + dtExpiracao.ToString("yyyy-MM-dd") + "'";
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message); throw;
            }
        }

        private void ImportarCliente(DataTable dtCliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        connection.Open();

                        command.CommandText = "use dbIconnect insert into tb_mol_modulosLiberados (mol_b_controleDeAcesso, mol_b_CFTV, mol_b_MonitoriamentoPerimetral,mol_b_OrdemServico, mol_b_connectSolutions,mol_c_unique,mol_b_connectSync, mol_b_accessView) values ('False','False','False','False','False','" + dtCliente.Rows[0]["mol_c_unique"].ToString() + "','" + dtCliente.Rows[0]["mol_b_connectSync"].ToString() + "','False') ";
                        command.ExecuteNonQuery();

                        command.CommandText = "use dbIconnect insert into tb_emp_empresa(emp_c_unique) values ('" + dtCliente.Rows[0]["emp_c_unique"].ToString() + "') ";
                        command.ExecuteNonQuery();

                        command.CommandText = "use dbIconnect insert into tb_cli_cliente (cli_c_unique,cli_c_nomefantasia,cli_c_codigoreferencia, cli_mol_n_codigo, cli_emp_n_codigo, cli_c_codInstalacaoOffline) values ('" + dtCliente.Rows[0]["cli_c_unique"].ToString() + "','" + dtCliente.Rows[0]["cli_c_nomeFantasia"].ToString() + " - PENDENTE SINCRONIZACAO','" + dtCliente.Rows[0]["cli_c_codigoreferencia"].ToString() + "',1,1,'" + _service.SegurancaService.getCodigoInstalacao() + "')";
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpGet]
        public ActionResult RealizarTestarConexaoLocalDB()
        {
            try
            {
                return Ok(TestarConexaoLocalDB());
            }
            catch (Exception)
            {
                return Ok(false);
            }

        }

        [HttpGet]
        [Route("getCriaDatabase")]
        public ActionResult CriarDataBase()
        {
            try
            {

                string basePath = Environment.CurrentDirectory;
                string relativePath = "./dbConfig/gerarDB.sql";
                string fullPath = Path.GetFullPath(relativePath, basePath);

                string script = System.IO.File.ReadAllText(fullPath);

                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                         RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    connection.Open();
                    foreach (string auxComando in commandStrings)
                    {
                        string comando = auxComando;
                        if (comando.Trim() != "")
                        {
                            if (comando.Contains("senha_iconnect"))
                            {
                                comando = auxComando.Replace("senha_iconnect", BancoService.senhaBancoOffline);
                            }

                            using (var command = new SqlCommand(comando, connection))
                            {
                                command.CommandTimeout = 999999;
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    connection.Close();
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                ApagarDatabase();
                return Ok(false); throw;
            }
        }

        [HttpGet]
        [Route("getCargaInicial")]
        public ActionResult GerarCargaInicial()
        {
            try
            {

                string basePath = Environment.CurrentDirectory;
                string relativePath = "./dbConfig/cargaInicial.sql";
                string fullPath = Path.GetFullPath(relativePath, basePath);

                string script = System.IO.File.ReadAllText(fullPath);

                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    connection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                command.CommandTimeout = 999999;
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    connection.Close();
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ToString()); throw;
            }
        }

        private bool CargaInicial()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 1000;
                        command.CommandText = "use dbIconnect select count(est_n_codigo) from tb_est_estado";
                        connection.Open();
                        int qtd = (int)command.ExecuteScalar();
                        return qtd > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private bool dbCriado()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandTimeout = 5;
                        command.Connection = connection;
                        command.CommandText = "SELECT count(name) FROM sys.databases where name = 'dbiconnect'";
                        connection.Open();
                        int i = (int)command.ExecuteScalar();
                        return i > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;

        }

        private bool TestarConexaoLocalDB()
        {
            try
            {
                usuarioWindows = true;
                using (SqlConnection connection = new SqlConnection(conexaoOffline))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 5;
                        command.CommandText = "select getdate()";
                        connection.Open();
                        command.ExecuteScalar();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    usuarioWindows = false;

                    using (SqlConnection connection = new SqlConnection(conexaoOffline))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandTimeout = 5;
                            command.CommandText = "select getdate()";
                            connection.Open();
                            command.ExecuteScalar();
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public static class Server
        {
            public static string MapPath(string path)
            {
                return Path.Combine(
                    (string)AppDomain.CurrentDomain.GetData("ContentRootPath"), path
                );
            }
        }
    }

}

