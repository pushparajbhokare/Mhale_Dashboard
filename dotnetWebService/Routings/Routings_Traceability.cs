using Microsoft.AspNetCore.Builder; //for classType:WebApplication 
using App.RouteBindings;
using App.Configurations;

namespace App.Routings
{
public static class Routes_Traceability{
    public static WebApplication Add_Traceability_Routing(this WebApplication app){
        var configs = new SystemConfigurations();
        //app.MapGet( "/" , RouteMethods.IndexMethod);
        //app.MapGet("/testPage", RouteMethods.testJsonData);
        //add key-link-reRerouting      
        app.MapGet("/TraceSearch", RouteMethodsTraceability.pageRedirect);
        app.MapGet("/LabReportDisplay", RouteMethodsTraceability.pageRedirectWithSerialParams);
        app.MapGet("/DemoDashboard", RouteMethodsTraceability.pageRedirect);
        app.MapGet("/MainDashboard", RouteMethodsTraceability.pageRedirectWithLineParams);
        app.MapGet("/LabEntry",RouteMethodsTraceability.pageRedirect);
        app.MapGet("/ManualEntry",RouteMethodsTraceability.pageRedirect);
        app.MapGet("/ManualDataEntry", RouteMethodsTraceability.pageRedirect);  
        app.MapGet("/LaserMarkingAuto",RouteMethodsTraceability.pageRedirect);
        app.MapGet("/instructions",RouteMethodsTraceability.pageRedirect);
        app.MapGet("/AutoScanEntry",RouteMethodsTraceability.pageRedirect);
        app.MapGet("/AdminLogin", RouteMethodsTraceability.pageRedirect);
        //
        
        app.MapGet("/testStart", RouteMethodsTraceability.TestStartPage);
        app.MapGet("/getAuthorization", RouteMethodsTraceability.getAuthorization);
        app.MapPost("/checkAuthorization", RouteMethodsTraceability.checkAuthorization);
        app.MapGet("/Jwt", RouteMethodsTraceability.getjWtoken);
        app.MapPost($"/{configs.jwt_url}", RouteMethodsTraceability.PostjWtoken);
        app.MapGet("/Results", RouteMethodsTraceability.ResultCandidates);
        app.MapPost("/PartData",RouteMethodsTraceability.PartData);
        app.MapPost("/LabData",RouteMethodsTraceability.LabUpload);
        app.MapPost("/ManualScanData",RouteMethodsTraceability.ManualScan);
        app.MapPost("/GetReportData",RouteMethodsTraceability.PDFReportData);
        app.MapPost("/GetReportList",RouteMethodsTraceability.PDFReportList);
            //add by pushparaj
           
        app.MapPost("/GetDashboardLines", RouteMethodsTraceability.DashboardLines );
        app.MapPost("/GetLabStations", RouteMethodsTraceability.getLabEntries );
        app.MapPost("/GetProductionLines",RouteMethodsTraceability.getAllProductionLines);
        app.MapPost("/OperationInProdLine",RouteMethodsTraceability.getAllOperationOfProductionLine);
        app.MapPost("/GetAllPartCodes",RouteMethodsTraceability.getAllPartCodesConfigured);
        app.MapPost("/SyncControlPlans", RouteMethodsTraceability.syncUpAllPartCodesConfigured);

        app.MapDelete("/DeleteReport", RouteMethodsTraceability.DeletePDFReport);

            //for DFQ save from Manual Forms
            app.MapPost("/ManualFormData",RouteMethodsTraceability.ManualFormData);
        return app;
    }
}  
}