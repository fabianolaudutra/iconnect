using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Models;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Iconnect.Portal.IdentityServer
{
    public class ProfileService : IProfileService
    {
        private readonly IconnectCoreContext _context;
        private readonly IServiceWrapper _service;

        public ProfileService(IconnectCoreContext context, IServiceWrapper service)
        {
            _context = context;
            _service = service;
        }

        //Get user profile date in terms of claims when calling /connect/userinfo
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                //where and subject was set to my user id.
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Id);

                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    //get user from db (find user by user id)
                    var id = Convert.ToInt32(userId.Value);
                    //var usuario = await _context.Usuario.Where(w => w.IdUsuario == id).FirstOrDefaultAsync();
                    var usuario = _service.Acesso.Find(id);

                    // issue the claims for the user
                    if (usuario != null)
                    {
                        var claims = new List<Claim>() {
                                new Claim(JwtClaimTypes.Name, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.Subject, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.Email, usuario.emailUsuario ?? ""),
                                new Claim(JwtClaimTypes.NickName, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.GivenName, usuario.nomeUsuario ?? ""),
                                new Claim(JwtClaimTypes.Id, usuario.IdAcesso.ToString()),
                                new Claim(JwtClaimTypes.Role, usuario.Permissoes == null ? "" : string.Join("--", usuario.Permissoes))
                            };
                        context.IssuedClaims = context.Subject.Claims.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                //log your error
            }
        }

        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                ////get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                //var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");

                //if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                //{
                //    var user = await _userRepository.FindAsync(long.Parse(userId.Value));

                //    if (user != null)
                //    {
                //        if (user.IsActive)
                //        {
                //            context.IsActive = user.IsActive;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                //handle error logging
            }
        }
    }
}
