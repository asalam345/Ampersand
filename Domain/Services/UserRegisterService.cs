using Domain.Aggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using RapidFireLib.Lib.Core;
using RapidFireLib.View.Models.Identity;
using RapidFireLib.View.UserInfo;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Domain.Services
{
    public class UserRegisterService
    {
        private readonly IJSRuntime js;
        private readonly IConfig config;
        private readonly IUserInfo _userInfo;
        private readonly Db _db;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        public UserRegisterService(IJSRuntime js, IConfig config, IUserInfo userInfo, UserManager<AspNetUsers> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<AspNetUsers> signInManager)
        {
            this.config = config;
            this.js = js;
            _db = new Db(this.config);
            _userInfo = userInfo;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> Register(Register registerModel, string OrgName, CancellationToken cancellationToken)
        {
            try
            {
                int userId = 0;
                var user = new AspNetUsers
                {
                    UserName = OrgName.Replace(" ", ""),
                    FullName = OrgName,
                    Email = registerModel.Email.ToString(),
                    IsActive = true,
                    PasswordHash = registerModel.Password
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    const string PartnerRoleId = "6b88f140-7a19-4009-ae3f-4bcbe536e2b7"; // Partner Role Id set from AspNetRoles Table
                    userId = _db.Get<AspNetUsers>(x => x.Email == user.Email).Select(x => x.UserId).FirstOrDefault();
                    string aspNetId = _db.Get<AspNetUsers>(x => x.Email == user.Email).Select(x => x.Id).FirstOrDefault();
                    if (userId != 0)
                    {
                        _db.ExecuteSQL($@"INSERT INTO AspNetUserRoles (UserId, RoleId,AppUserId) VALUES ('{aspNetId}', '{PartnerRoleId}','{userId}')");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
