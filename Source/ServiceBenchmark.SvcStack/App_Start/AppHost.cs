using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using ServiceBenchmark.Common;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ServiceBenchmark.SvcStack.App_Start.AppHost), "Start")]


/**
 * Entire ServiceStack Starter Template configured with a 'Hello' Web Service and a 'Todo' Rest Service.
 *
 * Auto-Generated Metadata API page at: /metadata
 * See other complete web service examples at: https://github.com/ServiceStack/ServiceStack.Examples
 */

namespace ServiceBenchmark.SvcStack.App_Start
{
    public class AppHost
        : AppHostBase
    {		
        public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("StarterTemplate ASP.NET Host", typeof(ItemService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
        
            //Configure User Defined REST Paths
            Routes.Add<ItemRequest>("/Item/{ItemID}");

            //Uncomment to change the default ServiceStack configuration
            //SetConfig(new EndpointHostConfig {
            //    DebugMode = true, //Show StackTraces when developing
            //});

            //Enable Authentication
            //ConfigureAuth(container);
        }

        /* Uncomment to enable ServiceStack Authentication and CustomUserSession
        private void ConfigureAuth(Funq.Container container)
        {
            var appSettings = new AppSettings();

            //Default route: /auth/{provider}
            Plugins.Add(new AuthFeature(this, () => new CustomUserSession(),
                new IAuthProvider[] {
                    new CredentialsAuthProvider(appSettings), 
                    new FacebookAuthProvider(appSettings), 
                    new TwitterAuthProvider(appSettings), 
                    new BasicAuthProvider(appSettings), 
                })); 

            //Default route: /register
            Plugins.Add(new RegistrationFeature()); 

            //Requires ConnectionString configured in Web.Config
            var connectionString = ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
            container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance));

            container.Register<IUserAuthRepository>(c =>
                new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
            authRepo.CreateMissingTables();
        }
        */

        public static void Start()
        {
            new AppHost().Init();
        }
    }
}