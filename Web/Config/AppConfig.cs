using Domain.Contexts;
using Domain.Handlers;
using RapidFireLib.Lib.Core;
using RapidFireUI.Style;
using System.Linq.Expressions;

namespace Web.Config
{
    public class AppConfig : IConfig
    {
        public void Configure(Configuration configuration)
        {
            //APP
            configuration.APP.BusinessModuleName = "Domain";
            configuration.APP.RootDomain = "localhost";
            configuration.APP.EnableCSP = false;
            configuration.APP.AttachmentStorageConfig = AttachmentStorageConfig.FileSystem("files");
            configuration.APP.AppTitle = "Ampersand";
            configuration.APP.AppSlogan = "TecHHub Family Business";
            configuration.APP.AppLogo = "ampersand-logo.png";
            configuration.APP.LoginHomeImage = "bg-4.jpg";
            configuration.APP.AppVersion = "1.0";
            configuration.APP.EnableRegistrationInLoginPage = false;

            //Style
            configuration.APP.AppStyle = new AppStyleRF()
            {
                AppTheme = AppThemeRF.Classic,
                AppStyle = new AppStyle()
            };
            //Authentication
            configuration.Authentication.LoginType = RapidFireLib.Lib.Authintication.LoginType.LoginDB;
            //DB
            configuration.DB.DefaultDbContext = new DefaultContext(SAASType.NoSaas);
            configuration.DB.CheckTablePermission = false;
            configuration.DB.DynamicViewModelHandlers = new IDbHandler[] { new UpdateCommonFields() };


            configuration.Messaging.Email = new ConfigEmailAuth
            {
                Username = "email@mail.com",
                Password = "epass"
            };
        }

        public void ConfigureGlobalFilter<TEntity>(ref Expression<Func<TEntity, bool>> exp, RFCoreDbContext ctx) where TEntity : class
        {

        }

        public void ConfigureSetting(AppSettings appSettings)
        {

        }
    }
}