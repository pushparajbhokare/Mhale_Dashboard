using Microsoft.AspNetCore.Builder; //for classType:WebApplication 
using App.RouteBindings;
using App.Configurations;
using System.Configuration;
//using Kneo.Database.Single.Tenant;

namespace App.Routings
{
    public static class Routes_QQD
    {
        public static WebApplication Add_QQD_Routing(this WebApplication app)
        {
            //var configs = new SystemConfigurations(); //suggestedChange // not required
            //TenantAdapter.StartUp("Server=qdasTestSetup\\QDASDB001;Database=QDAS_DATA;User Id=qdas;Password=qdas1234;KneoDB=SQLSERVER");

            //app.MapGet("/", RouteMethodsQQD.MoveToHomeScreen);
            //app.MapGet("/Home", RouteMethodsQQD.pageRedirect);
            app.MapGet("/Dashboard", RouteMethodsQQD.pageRedirect);
            app.MapGet("/Level3", RouteMethodsQQD.Level3Dashboard);
            //app.MapGet("/GetLevel3DashboardData", RouteMethodsQQD.GetLevel3DashboardData);
            app.MapGet("/GetPartSummary", RouteMethodsQQD.GetPartSummary);
            app.MapGet("/GetCharacteristicsInfo", RouteMethodsQQD.GetCharacteristicsInfo);
            //app.MapGet("/GetOperationStatusInfo", RouteMethodsQQD.GetOperationStatusInfo);
            app.MapGet("/GetAllPartSummary", RouteMethodsQQD.GetAllPartSummary);
            app.MapGet("/GetAllCharacteristicsInfo", RouteMethodsQQD.GetAllCharacteristicsInfo);
            app.MapGet("/GetProcessPerformance", RouteMethodsQQD.GetProcessPerformance);
            app.MapGet("/GetOperationListWithFTT", RouteMethodsQQD.GetOperationListWithFTT);
            app.MapGet("/GetDashboardAlarm", RouteMethodsQQD.GetDashboardAlarm);
            //app.MapGet("/GetDashboardAlarmFTT", RouteMethodsQQD.GetDashboardAlarmFTT);
            app.MapGet("/GetOperationPartStatus", RouteMethodsQQD.GetOperationPartStatus);
            //app.MapGet("/GetDashboardSummaryData", RouteMethodsQQD.GetDashboardSummaryData);
            app.MapGet("/GetAlarmDetails", RouteMethodsQQD.GetAlarmDetails);
            app.MapGet("/GetCharCharts", RouteMethodsQQD.GetCharCharts);
            app.MapGet("/GetCharDetails", RouteMethodsQQD.GetCharDetails);
            app.MapGet("/GetRefreshInterval", RouteMethodsQQD.GetRefreshInterval);
            return app;
        }
    }
}
