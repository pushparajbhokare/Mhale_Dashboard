using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using App.Configurations;
using Microsoft.Extensions.Hosting; // to access type hostoption; BackgroundServiceExceptionBehavior  
using BackendStoreManager;
using FileHandler;
using PartDataManager;
using Microsoft.AspNetCore.Hosting; //to access WebHostEnvironment interface;
using Kneo.Service.QDas; // to acces teilService definition;
namespace BackendServices {

    public static class Services{

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder, SystemConfigurations configs ){
            //not to stop due to failure of background services
            builder.Services.Configure<HostOptions>(
                hostOptions=>
                {
                    hostOptions.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
                }
            );
            builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        policy =>
                        {
                            policy.AllowAnyOrigin();
                            policy.AllowAnyHeader();
                        });
                });
            builder.Services.AddSingleton<runTimeConfiguration>();
            builder.Services.AddSingleton<authKeeper>();
            builder.Services.AddScoped<TokenManager>();
            builder.Services.AddTransient<IFileHandler,ResultHandler>(sp=>new ResultHandler(configs.resultFile));
            builder.Services.AddSingleton<IpartDataHandler,PartDataHandler>(sp=> {
                   var webHostEnvironment = sp.GetRequiredService<IWebHostEnvironment>();
                 return new PartDataHandler(webHostEnvironment.ContentRootPath+"/"+configs.qdasConfig);
               });
            builder.Services.AddSingleton<TEILService>();//Kneo SQL Fetcher
            /* //NOTE: below services are used in another project 
            builder.Services.AddTransient<IFileHandler,ResultHandler>(
                sp=>{
                    var webHostEnvironment = sp.GetRequiredService<IWebHostEnvironment>();
                    return new ResultHandler(configs.storageDirectory, webHostEnvironment);
                    });
            builder.Services.AddTransient< IDataHandler, FormDataHandler>(
                sp=>{
                    var webHostEnvironment = sp.GetRequiredService<IWebHostEnvironment>();
                    return new FormDataHandler(configs.dataDirectory, webHostEnvironment);
                    });

            builder.Services.AddScoped<DbLayer>(sp=>{
                var opt = new dbOptions { //correctionPending
                dataSource = "localhost,1433",
                userID = "id", //qdas-Administrator           
                password = "password", //admin password    
                dbName="dbName" // value db name in qdas 
                    }; 
                return new DbLayer(opt);
            });
            */
            return builder;
        }
    }
}
