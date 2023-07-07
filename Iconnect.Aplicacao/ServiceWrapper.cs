using AutoMapper;
using Iconnect.Aplicacao.Interfaces;
using Iconnect.Aplicacao.Services;
using Iconnect.Infraestrutura.Context;

namespace Iconnect.Aplicacao
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IconnectCoreContext _context;
        private readonly IMapper _mapper;

        public ServiceWrapper(IconnectCoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IPermissionamentoService _permissionamento;

        public IPermissionamentoService Permissionamento
        {
            get
            {
                if (_permissionamento == null)
                {
                    _permissionamento = new PermissionamentoService(_context);
                }
                return _permissionamento;
            }
        }
        private IPerfilService _perfilService;

        public IPerfilService Perfil
        {
            get
            {
                if (_perfilService == null)
                {
                    _perfilService = new PerfilService(_context);
                }
                return _perfilService;
            }
        }

        private IClienteService _cliente;

        public IClienteService Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteService(_context);
                }
                return _cliente;
            }
        }
        private IAcessoService _acesso;

        public IAcessoService Acesso
        {
            get
            {
                if (_acesso == null)
                {
                    _acesso = new AcessoService(_context);
                }
                return _acesso;
            }
        }

        private IEmpresaService _empresa;

        public IEmpresaService Empresa
        {
            get
            {
                if (_empresa == null)
                {
                    _empresa = new EmpresaService(_context);
                }
                return _empresa;
            }
        }

        private IFotoEmpresaService _fotoEmpresa;

        public IFotoEmpresaService FotoEmpresa
        {
            get
            {
                if (_fotoEmpresa == null)
                {
                    _fotoEmpresa = new FotoEmpresaService(_context);
                }
                return _fotoEmpresa;
            }
        }

        private IRacaService _raca;
        public IRacaService Raca
        {
            get
            {
                if (_raca == null)
                {
                    _raca = new RacaService(_context);
                }
                return _raca;
            }
        }

        private IMarcaVeiculoService _marca;
        public IMarcaVeiculoService MarcaVeiculo
        {
            get
            {
                if (_marca == null)
                {
                    _marca = new MarcaVeiculoService(_context);
                }
                return _marca;
            }
        }

        private ICategorizacaoEventoService _catego;
        public ICategorizacaoEventoService CategorizacaoEvento
        {
            get
            {
                if (_catego == null)
                {
                    _catego = new CategorizacaoEventoService(_context);
                }
                return _catego;
            }
        }
        private ICategorizacaoAvisoService _aviso;
        public ICategorizacaoAvisoService CategorizacaoAviso
        {
            get
            {
                if (_aviso == null)
                {
                    _aviso = new CategorizacaoAvisoService(_context);
                }
                return _aviso;
            }
        }

        private ILimpezaClienteService _proc;
        public ILimpezaClienteService LimpezaCliente
        {
            get
            {
                if (_proc == null)
                {
                    _proc = new LimpezaClienteService(_context);
                }
                return _proc;
            }
        }

        private IOperadorLocalService _opeLoc;
        public IOperadorLocalService OperadorLocal
        {
            get
            {
                if (_opeLoc == null)
                {
                    _opeLoc = new OperadorLocalService(_context);
                }
                return _opeLoc;
            }
        }

        private IGrupoPermissaoOperadorService _gpp;

        public IGrupoPermissaoOperadorService GrupoPermissaoOperador
        {
            get
            {
                if (_gpp == null)
                {
                    _gpp = new GrupoPermissaoOperadorService(_context);
                }
                return _gpp;
            }
        }

        private IGrupoVagasService _grupoVagas;

        public IGrupoVagasService GrupoVagas
        {
            get
            {
                if (_grupoVagas == null)
                {
                    _grupoVagas = new GrupoVagasService(_context);
                }
                return _grupoVagas;
            }
        }

        private IProprietarioService _Prop;

        public IProprietarioService Proprietario
        {
            get
            {
                if (_Prop == null)
                {
                    _Prop = new ProprietarioService(_context);
                }
                return _Prop;
            }
        }

        private IEstadoService _estado;
        public IEstadoService Estado
        {
            get
            {
                if (_estado == null)
                {
                    _estado = new EstadoService(_context);
                }
                return _estado;
            }
        }

        private ICidadeService _cidade;
        public ICidadeService Cidade
        {
            get
            {
                if (_cidade == null)
                {
                    _cidade = new CidadeService(_context);
                }
                return _cidade;
            }
        }

        private ICepService _cep;
        public ICepService Cep
        {
            get
            {
                if (_cep == null)
                {
                    _cep = new CepService(_context);
                }
                return _cep;
            }
        }

        private IModuloService _modulo;
        public IModuloService Modulo
        {
            get
            {
                if (_modulo == null)
                {
                    _modulo = new ModuloService(_context);
                }
                return _modulo;
            }
        }

        private IAvisoEmpresaService _avisoEmpresa;
        public IAvisoEmpresaService AvisoEmpresa
        {
            get
            {
                if (_avisoEmpresa == null)
                {
                    _avisoEmpresa = new AvisoEmpresaService(_context);
                }
                return _avisoEmpresa;
            }
        }

        private IAvisoService _avisoOperador;
        public IAvisoService Aviso
        {
            get
            {
                if (_avisoOperador == null)
                {
                    _avisoOperador = new AvisoService(_context);
                }
                return _avisoOperador;
            }
        }

        private IEnvioNotificacaoService _envioNotificao;
        public IEnvioNotificacaoService EnvioNotificacao
        {
            get
            {
                if (_envioNotificao == null)
                {
                    _envioNotificao = new EnvioNotificacaoService(_context);
                }
                return _envioNotificao;
            }
        }

        private IOperadorService _operador;
        public IOperadorService Operador
        {
            get
            {
                if (_operador == null)
                {
                    _operador = new OperadorService(_context);
                }
                return _operador;
            }
        }

        private IMoradorService _morador;
        public IMoradorService Morador
        {
            get
            {
                if (_morador == null)
                {
                    _morador = new MoradorService(_context);
                }
                return _morador;
            }
        }

        private IGrupoFamiliarService _grupoFamiliar;
        public IGrupoFamiliarService GrupoFamiliar
        {
            get
            {
                if (_grupoFamiliar == null)
                {
                    _grupoFamiliar = new GrupoFamiliarService(_context);
                }
                return _grupoFamiliar;
            }
        }
        private IUploadAPKService _apk;
        public IUploadAPKService UploadAPK
        {
            get
            {
                if (_apk == null)
                {
                    _apk = new UploadAPKService(_context);
                }
                return _apk;
            }
        }
        private INotificacaoAppService _notificacaoApp;
        public INotificacaoAppService NotificacaoApp
        {
            get
            {
                if (_notificacaoApp == null)
                {
                    _notificacaoApp = new NotificacaoAppService(_context);
                }
                return _notificacaoApp;
            }
        }

        private IZeladorClienteService _zeladorCliente;
        public IZeladorClienteService ZeladorCliente
        {
            get
            {
                if (_zeladorCliente == null)
                {
                    _zeladorCliente = new ZeladorClienteService(_context);
                }
                return _zeladorCliente;
            }
        }
        private IEquipamentoClienteService _equipamentoCliente;
        public IEquipamentoClienteService EquipamentoCliente
        {
            get
            {
                if (_equipamentoCliente == null)
                {
                    _equipamentoCliente = new EquipamentoClienteService(_context);
                }
                return _equipamentoCliente;
            }
        }

        private IPgmService _pgm;
        public IPgmService Pgm
        {
            get
            {
                if (_pgm == null)
                {
                    _pgm = new PgmService(_context);
                }
                return _pgm;
            }
        }

        private IPermissaoClienteService _permissaoCliente;
        public IPermissaoClienteService PermissaoCliente
        {
            get
            {
                if (_permissaoCliente == null)
                {
                    _permissaoCliente = new PermissaoClienteService(_context);
                }
                return _permissaoCliente;
            }
        }

        private ICabecalhoLayoutService _cabecalhoLaout;
        public ICabecalhoLayoutService CabecalhoLayout
        {
            get
            {
                if (_cabecalhoLaout == null)
                {
                    _cabecalhoLaout = new CabecalhoLayoutService(_context);
                }
                return _cabecalhoLaout;
            }
        }

        private IZoneamentoClienteService _zoneamentoCliente;
        public IZoneamentoClienteService ZoneamentoCliente
        {
            get
            {
                if (_zoneamentoCliente == null)
                {
                    _zoneamentoCliente = new ZoneamentoClienteService(_context);
                }
                return _zoneamentoCliente;
            }
        }

        private IVigilanteClienteService _vigilanteCliente;
        public IVigilanteClienteService VigilanteCliente
        {
            get
            {
                if (_vigilanteCliente == null)
                {
                    _vigilanteCliente = new VigilanteClienteService(_context);
                }
                return _vigilanteCliente;
            }
        }

        private IMotivoOcorrenciaService _motivoOcorrencia;
        public IMotivoOcorrenciaService MotivoOcorrencia
        {
            get
            {
                if (_motivoOcorrencia == null)
                {
                    _motivoOcorrencia = new MotivoOcorrenciaService(_context);
                }
                return _motivoOcorrencia;
            }
        }

        private IDispositivoCFTVService _dispositivoCFTV;
        public IDispositivoCFTVService DispositivoCFTV
        {
            get
            {
                if (_dispositivoCFTV == null)
                {
                    _dispositivoCFTV = new DispositivoCFTVService(_context);
                }
                return _dispositivoCFTV;
            }
        }

        private IRamalLayoutService _ramalLayout;
        public IRamalLayoutService RamalLayout
        {
            get
            {
                if (_ramalLayout == null)
                {
                    _ramalLayout = new RamalLayoutService(_context);
                }
                return _ramalLayout;
            }
        }

        private IPontosAcessoService _pontosAcesso;
        public IPontosAcessoService PontosAcesso
        {
            get
            {
                if (_pontosAcesso == null)
                {
                    _pontosAcesso = new PontosAcessoService(_context);
                }
                return _pontosAcesso;
            }
        }

        private IMapeamentoPontoAcessoService _mapeamentoPontoAcesso;
        public IMapeamentoPontoAcessoService MapeamentoPontoAcesso
        {
            get
            {
                if (_mapeamentoPontoAcesso == null)
                {
                    _mapeamentoPontoAcesso = new MapeamentoPontoAcessoService(_context);
                }
                return _mapeamentoPontoAcesso;
            }
        }


        private ILocalidadeClienteService _localidadeCliente;
        public ILocalidadeClienteService LocalidadeCliente
        {
            get
            {
                if (_localidadeCliente == null)
                {
                    _localidadeCliente = new LocalidadeClienteService(_context);
                }
                return _localidadeCliente;
            }
        }

        private ILicencasService _licencas;
        public ILicencasService Licencas
        {
            get
            {
                if (_licencas == null)
                {
                    _licencas = new LicencasService(_context);
                }
                return _licencas;
            }
        }
        private ILayoutService _layout;
        public ILayoutService Layout
        {
            get
            {
                if (_layout == null)
                {
                    _layout = new LayoutService(_context);
                }
                return _layout;
            }
        }

        private ICanalLayoutService _canalLayout;
        public ICanalLayoutService CanalLayout
        {
            get
            {
                if (_canalLayout == null)
                {
                    _canalLayout = new CanalLayoutService(_context);
                }
                return _canalLayout;
            }
        }

        private IEmailService _email;
        public IEmailService Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailService(_context);
                }
                return _email;
            }
        }

        private IMonitoramentoService _monitoramento;
        public IMonitoramentoService Monitoramento
        {
            get
            {
                if (_monitoramento == null)
                {
                    _monitoramento = new MonitoramentoService(_context);
                }
                return _monitoramento;
            }
        }

        private IDisparoPgmService _disparoPgm;
        public IDisparoPgmService DisparoPgm
        {
            get
            {
                if (_disparoPgm == null)
                {
                    _disparoPgm = new DisparoPgmService(_context);
                }
                return _disparoPgm;
            }
        }

        private IVisitanteService _visitante;
        public IVisitanteService Visitante
        {
            get
            {
                if (_visitante == null)
                {
                    _visitante = new VisitanteService(_context);
                }
                return _visitante;
            }
        }

        private IPrestadorServicoService _prestadorServico;
        public IPrestadorServicoService PrestadorServico
        {
            get
            {
                if (_prestadorServico == null)
                {
                    _prestadorServico = new PrestadorServicoService(_context);
                }
                return _prestadorServico;
            }
        }

        private IPessoaService _pessoa;
        public IPessoaService Pessoa
        {
            get
            {
                if (_pessoa == null)
                {
                    _pessoa = new PessoaService(_context);
                }
                return _pessoa;
            }
        }

        private IControladoraService _controladora;
        public IControladoraService Controladora
        {
            get
            {
                if (_controladora == null)
                {
                    _controladora = new ControladoraService(_context);
                }
                return _controladora;
            }
        }

        private IPerfilHorarioService _perfilHorario;
        public IPerfilHorarioService PerfilHorario
        {
            get
            {
                if (_perfilHorario == null)
                {
                    _perfilHorario = new PerfilHorarioService(_context);
                }
                return _perfilHorario;
            }
        }

        private IPermissoesGrupoService _permissoesGrupo;
        public IPermissoesGrupoService PermissoesGrupo
        {
            get
            {
                if (_permissoesGrupo == null)
                {
                    _permissoesGrupo = new PermissoesGrupoService(_context);
                }
                return _permissoesGrupo;
            }
        }

        private IResponsavelLocacaoService _responsavelLocacao;
        public IResponsavelLocacaoService ResponsavelLocacao
        {
            get
            {
                if (_responsavelLocacao == null)
                {
                    _responsavelLocacao = new ResponsavelLocacaoService(_context);
                }
                return _responsavelLocacao;
            }
        }

        private IAvisoGrupoFamiliarService _avisoGrupoFamiliar;
        public IAvisoGrupoFamiliarService AvisoGrupoFamiliar
        {
            get
            {
                if (_avisoGrupoFamiliar == null)
                {
                    _avisoGrupoFamiliar = new AvisoGrupoFamiliarService(_context);
                }
                return _avisoGrupoFamiliar;
            }
        }

        private IPetService _pet;
        public IPetService Pet
        {
            get
            {
                if (_pet == null)
                {
                    _pet = new PetService(_context);
                }
                return _pet;
            }
        }

        private IVeiculoService _veiculo;
        public IVeiculoService Veiculo
        {
            get
            {
                if (_veiculo == null)
                {
                    _veiculo = new VeiculoService(_context);
                }
                return _veiculo;
            }
        }

        private IDependenciasService _dependencias;
        public IDependenciasService Dependencias
        {
            get
            {
                if (_dependencias == null)
                {
                    _dependencias = new DependenciasService(_context);
                }
                return _dependencias;
            }
        }

        private IFotoDependenciaService _fotoDependencia;
        public IFotoDependenciaService FotoDependencia
        {
            get
            {
                if (_fotoDependencia == null)
                {
                    _fotoDependencia = new FotoDependenciaService(_context);
                }
                return _fotoDependencia;
            }
        }

        private IArquivoDependenciaService _arquivoDependencia;
        public IArquivoDependenciaService ArquivoDependencia
        {
            get
            {
                if (_arquivoDependencia == null)
                {
                    _arquivoDependencia = new ArquivoDependenciaService(_context);
                }
                return _arquivoDependencia;
            }
        }

        private IRegistroSalaoService _registroSalao;
        public IRegistroSalaoService RegistroSalao
        {
            get
            {
                if (_registroSalao == null)
                {
                    _registroSalao = new RegistroSalaoService(_context);
                }
                return _registroSalao;
            }
        }

        private IControleAcessoService _controleAcesso;
        public IControleAcessoService ControleAcesso
        {
            get
            {
                if (_controleAcesso == null)
                {
                    _controleAcesso = new ControleAcessoService(_context);
                }
                return _controleAcesso;
            }
        }

        private IHorarioService _horario;
        public IHorarioService Horario
        {
            get
            {
                if (_horario == null)
                {
                    _horario = new HorarioService(_context);
                }
                return _horario;
            }
        }

        private IMonitoramentoControleAcessoService _monitoramentoControleAcesso;
        public IMonitoramentoControleAcessoService MonitoramentoControleAcesso
        {
            get
            {
                if (_monitoramentoControleAcesso == null)
                {
                    _monitoramentoControleAcesso = new MonitoramentoControleAcessoService(_context);
                }
                return _monitoramentoControleAcesso;
            }
        }

        private ISolicitacaoAberturaRemotaService _solicitacaoAberturaRemota;
        public ISolicitacaoAberturaRemotaService SolicitacaoAberturaRemota
        {
            get
            {
                if (_solicitacaoAberturaRemota == null)
                {
                    _solicitacaoAberturaRemota = new SolicitacaoAberturaRemotaService(_context);
                }
                return _solicitacaoAberturaRemota;
            }
        }

        private IPessoasRecintoService _pessoasRecinto;
        public IPessoasRecintoService PessoasRecinto
        {
            get
            {
                if (_pessoasRecinto == null)
                {
                    _pessoasRecinto = new PessoasRecintoService(_context);
                }
                return _pessoasRecinto;
            }
        }

        private ISincronizacaoPlacasService _sincronizacaoPlacas;
        public ISincronizacaoPlacasService SincronizacaoPlacas
        {
            get
            {
                if (_sincronizacaoPlacas == null)
                {
                    _sincronizacaoPlacas = new SincronizacaoPlacasService(_context);
                }
                return _sincronizacaoPlacas;
            }
        }


        private IAfastamentoService _afastamento;
        public IAfastamentoService Afastamento
        {
            get
            {
                if (_afastamento == null)
                {
                    _afastamento = new AfastamentoService(_context);
                }
                return _afastamento;
            }
        }

        private IFotoService _foto;
        public IFotoService Foto
        {
            get
            {
                if (_foto == null)
                {
                    _foto = new FotoService(_context);
                }
                return _foto;
            }
        }

        private IFrotaService _frota;
        public IFrotaService Frota
        {
            get
            {
                if (_frota == null)
                {
                    _frota = new FrotaService(_context);
                }
                return _frota;
            }
        }

        private IMovimentacaoVeiculoService _movimentacaoVeiculo;
        public IMovimentacaoVeiculoService MovimentacaoVeiculo
        {
            get
            {
                if (_movimentacaoVeiculo == null)
                {
                    _movimentacaoVeiculo = new MovimentacaoVeiculoService(_context);
                }
                return _movimentacaoVeiculo;
            }
        }

        private IDocumentoService _documento;
        public IDocumentoService Documento
        {
            get
            {
                if (_documento == null)
                {
                    _documento = new DocumentoService(_context);
                }
                return _documento;
            }
        }

        private IDocumentoMoradorService _documentoMorador;
        public IDocumentoMoradorService DocumentoMorador
        {
            get
            {
                if (_documentoMorador == null)
                {
                    _documentoMorador = new DocumentoMoradorService(_context);
                }
                return _documentoMorador;
            }
        }

        private ISolicitarZeladorService _solicitarZelador;
        public ISolicitarZeladorService SolicitarZelador
        {
            get
            {
                if (_solicitarZelador == null)
                {
                    _solicitarZelador = new SolicitarZeladorService(_context);
                }
                return _solicitarZelador;
            }
        }

        private IInformacoesClienteService _informacoesCliente;
        public IInformacoesClienteService InformacoesCliente
        {
            get
            {
                if (_informacoesCliente == null)
                {
                    _informacoesCliente = new InformacoesClienteService(_context);
                }
                return _informacoesCliente;
            }
        }

        private IDuvidasAppService _duvidas;
        public IDuvidasAppService DuvidasApp
        {
            get
            {
                if (_duvidas == null)
                {
                    _duvidas = new DuvidasAppService(_context);
                }
                return _duvidas;
            }
        }

        private IAtendimentoService _atendimento;
        public IAtendimentoService Atendimento
        {
            get
            {
                if (_atendimento == null)
                {
                    _atendimento = new AtendimentoService(_context);
                }
                return _atendimento;
            }
        }

        private IDashboardService _dashboard;
        public IDashboardService Dashboard
        {
            get
            {
                if (_dashboard == null)
                {
                    _dashboard = new DashboardService(_context);
                }
                return _dashboard;
            }
        }

        private ISegurancaService _seguranca;
        public ISegurancaService SegurancaService
        {
            get
            {
                if (_seguranca == null)
                {
                    _seguranca = new SegurancaService(_context);
                }
                return _seguranca;
            }
        }

        private IUsuarioAppService _usuarioApp;
        public IUsuarioAppService UsuarioApp
        {
            get
            {
                if (_usuarioApp == null)
                {
                    _usuarioApp = new UsuarioAppService(_context);
                }
                return _usuarioApp;
            }
        }

        private IHistoricoLiberacaoService _historicoLiberacao;
        public IHistoricoLiberacaoService HistoricoLiberacao
        {
            get
            {
                if (_historicoLiberacao == null)
                {
                    _historicoLiberacao = new HistoricoLiberacaoService(_context);
                }
                return _historicoLiberacao;
            }
        }

        private INotificacaoService _notificacao;
        public INotificacaoService Notificacao
        {
            get
            {
                if (_notificacao == null)
                {
                    _notificacao = new NotificacaoService(_context);
                }
                return _notificacao;
            }
        }

        private ICatalogoService _catalogo;
        public ICatalogoService Catalogo
        {
            get
            {
                if (_catalogo == null)
                {
                    _catalogo = new CatalogoService(_context);
                }
                return _catalogo;
            }
        }

        private ICategoriaCatalogoService _categoriaCatalogo;
        public ICategoriaCatalogoService CategoriaCatalogo
        {
            get
            {
                if (_categoriaCatalogo == null)
                {
                    _categoriaCatalogo = new CategoriaCatalogoService(_context);
                }
                return _categoriaCatalogo;
            }
        }

        private IConnectionSignalRService _connectionSignalR;
        public IConnectionSignalRService ConnectionSignalR
        {
            get
            {
                if (_connectionSignalR == null)
                {
                    _connectionSignalR = new ConnectionSignalRService(_context);
                }
                return _connectionSignalR;
            }
        }

        private ISubCategoriaCatalogoService _subCategoriaCatalogo;
        public ISubCategoriaCatalogoService SubCategoriaCatalogo
        {
            get
            {
                if (_subCategoriaCatalogo == null)
                {
                    _subCategoriaCatalogo = new SubCategoriaCatalogoService(_context);
                }
                return _subCategoriaCatalogo;
            }
        }

        private IPrecosService _Precos;
        public IPrecosService Precos
        {
            get
            {
                if (_Precos == null)
                {
                    _Precos = new PrecosService(_context);
                }
                return _Precos;
            }
        }

        private IRefeicaoService _Refeicao;
        public IRefeicaoService Refeicao
        {
            get
            {
                if (_Refeicao == null)
                {
                    _Refeicao = new RefeicaoService(_context);
                }
                return _Refeicao;
            }
        }

        private IDistribuidorService _distribuidor;

        public IDistribuidorService Distribuidor
        {
            get
            {
                if (_distribuidor == null)
                {
                    _distribuidor = new DistribuidorService(_context);
                }
                return _distribuidor;
            }
        }

        private IAgendaService _agenda;
        public IAgendaService Agenda
        {
            get
            {
                if (_agenda == null)
                {
                    _agenda = new AgendaService(_context);
                }
                return _agenda;
            }
        }

        private IVisitanteAppService _uvisitasApp;
        public IVisitanteAppService VisitasApp
        {
            get
            {
                if (_uvisitasApp == null)
                {
                    _uvisitasApp = new VisitanteAppService(_context);
                }
                return _uvisitasApp;
            }
        }

        private IUsuarioSalaComercialService _usuarioSala;
        public IUsuarioSalaComercialService UsuarioSalaComercial
        {
            get
            {
                if (_usuarioSala == null)
                {
                    _usuarioSala = new UsuarioSalaComercialService(_context);
                }
                return _usuarioSala;
            }
        }

        private IAgenteComercialService _agenteComercial;

        public IAgenteComercialService AgenteComercial
        {
            get
            {
                if (_agenteComercial == null)
                {
                    _agenteComercial = new AgenteComercialService(_context);
                }
                return _agenteComercial;
            }
        }

        private ILocalidadeGrupoFamiliarService _localidadeGrupoFamiliar;
        public ILocalidadeGrupoFamiliarService LocalidadeGrupoFamiliar
        {
            get
            {
                if (_localidadeGrupoFamiliar == null)
                {
                    _localidadeGrupoFamiliar = new LocalidadeGrupoFamiliarService(_context);
                }
                return _localidadeGrupoFamiliar;
            }
        }

        private IParametrosEmpresaService _parametroEmpresa;

        public IParametrosEmpresaService ParametrosEmpresa
        {
            get
            {
                if (_parametroEmpresa == null)
                {
                    _parametroEmpresa = new ParametrosEmpresaService(_context);
                }
                return _parametroEmpresa;
            }
        }

        private IRamalOperadorService _ramalOperador;

        public IRamalOperadorService RamalOperador
        {
            get
            {
                if (_ramalOperador == null)
                {
                    _ramalOperador = new RamalOperadorService(_context);
                }
                return _ramalOperador;
            }
        }

        private IOcorrenciasOperadorService _ocorrenciasOperador;

        public IOcorrenciasOperadorService OcorrenciasOperador
        {
            get
            {
                if (_ocorrenciasOperador == null)
                {
                    _ocorrenciasOperador = new OcorrenciasOperadorService(_context);
                }
                return _ocorrenciasOperador;
            }
        }

        private IAjudaService _ajuda;

        public IAjudaService Ajuda
        {
            get
            {
                if (_ajuda == null)
                {
                    _ajuda = new AjudaService(_context);
                }
                return _ajuda;
            }
        }

        private ITopicosService _topicos;

        public ITopicosService Topicos
        {
            get
            {
                if (_topicos == null)
                {
                    _topicos = new TopicosService(_context);
                }
                return _topicos;
            }
        }
    }
}
