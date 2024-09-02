using Microsoft.AspNetCore.Builder; //for classType:WebApplication 
using App.RouteBindings;
//using App.Configurations;

namespace App.Routings
{
public static class Routes{
    public static WebApplication AddRouting(this WebApplication app){
        
        app.MapGet("/Home",RouteMethods.pageRedirect);
        app.MapGet("/", RouteMethods.MoveToHomeScreen);
        app = app.Add_Traceability_Routing();
        app = app.Add_QQD_Routing();
        return app;
    }
}  
}