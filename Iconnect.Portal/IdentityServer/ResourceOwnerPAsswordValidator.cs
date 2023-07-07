using Iconnect.Aplicacao;
using Iconnect.Infraestrutura.Context;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Iconnect.Portal.IdentityServer
{
    public class ResourceOwnerPAsswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IconnectCoreContext _context;
        private readonly IServiceWrapper _service;

        public ResourceOwnerPAsswordValidator(IconnectCoreContext context, IServiceWrapper service)
        {
            _context = context;
            _service = service;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var usuario = _service.Acesso.Logar(context.UserName, context.Password);
               
                if (usuario == null || usuario.IdAcesso == null)
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Usuário ou senha incorretos, por favor tente novamente.");
                    return Task.FromResult(context.Result);
                }
                else
                {
                    context.Result = new GrantValidationResult(
                        subject: usuario.idUsuario.ToString(),
                        authenticationMethod: "custom",
                        claims: new List<Claim>() {
                                new Claim(JwtClaimTypes.Name, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.Subject, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.Email, usuario.emailUsuario ?? ""),
                                new Claim(JwtClaimTypes.NickName, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.GivenName, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.Id, usuario.IdAcesso.ToString()),
                                new Claim("idEmp", usuario.idEmpresa != null ? usuario.idEmpresa.ToString() : "0"),
                                new Claim("idUsuario", usuario.idUsuario != null ? usuario.idUsuario.ToString() : "0"),
                                new Claim("idsEmp", usuario.idsEmpresas ?? ""),
                                new Claim("idsCli", usuario.idsClientes ?? "NULL"),
                                new Claim("Perfil", usuario?.Perfil != null ? usuario.Perfil.ToString() : "NULL"),
                                new Claim("perfilOpe", usuario.perfilOpe != null ? usuario.perfilOpe.ToString() : "NULL"),
                                new Claim("perfilResLoc", usuario.PerfilResLoc != null ? usuario.PerfilResLoc.ToString() : "NULL"),
                                new Claim("permissoesEdicaoCliente", JsonConvert.SerializeObject(usuario?.PermissoesEdicaoCliente)),
                                new Claim(JwtClaimTypes.Role, usuario.Permissoes == null ? "" : string.Join("--", usuario.Permissoes)),
                                new Claim("PermissaoOpeLocal", usuario.PermissaoOpeLocal == null ? "NULL" : usuario.PermissaoOpeLocal),
                                new Claim("solicitaRamalOperador", usuario.solicitaRamalOperador.ToString()),
                        });

                    return Task.FromResult(context.Result);
                }
            }
            catch (Exception e)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, e.Message);
                return Task.FromResult(context.Result);
            }
        }

    }
}
