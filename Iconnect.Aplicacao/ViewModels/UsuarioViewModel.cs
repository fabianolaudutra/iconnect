using System.Collections.Generic;

namespace Iconnect.Aplicacao.ViewModel
{
    public class UsuarioViewModel
    {
        public int? idUsuario { get; set; }
        public int? IdAcesso { get; set; }
        public string nomeUsuario { get; set; }
        public string emailUsuario { get; set; }
        public int? idEmpresa { get; set; }
        public string idsClientes { get; set; }
        public string idsEmpresas { get; set; }
        public int? idDistribuidor { get; set; }
        public List<string> Permissoes { get; set; }
        public int? Perfil { get; set; }
        public int? perfilOpe { get; set; }
        public string PerfilResLoc { get; set; }
        public string PermissaoOpeLocal { get; set; }
        public IDictionary<int, bool> PermissoesEdicaoCliente { get; set; }
        public bool status { get; set; }
        public bool solicitaRamalOperador { get; set; }
    }
}

