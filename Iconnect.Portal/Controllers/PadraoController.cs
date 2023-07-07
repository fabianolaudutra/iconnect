using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Iconnect.Portal.Controllers
{
    public class PadraoController : ControllerBase
    {
        private IHttpContextAccessor _accessor;

        public string UsuarioLogado { get { return User.Identity.Name ?? ""; } }
        public string IdUsuarioLogado { get { return User.Claims.FirstOrDefault(x => x.Type == "sub").Value ?? ""; } }
        public string PerfilLogado { get { return User.Claims.FirstOrDefault(x => x.Type == "Perfil").Value ?? ""; } }

        public ClaimsPrincipal Usuario => User;

        public PadraoController(IHttpContextAccessor acessor)
        {
            _accessor = acessor;
        }
    }
}