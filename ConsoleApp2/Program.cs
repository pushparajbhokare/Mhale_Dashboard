using Kneo.Model.QDas;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using Kneo.QDas.DB;
using Kneo.Service.QDas;
using Microsoft.AspNetCore.Http;
using System.Configuration;

Console.WriteLine("Hello, World!");
TestMySqlDataSet();


static void updateConfigs(){
    //ref: https://stackoverflow.com/questions/360024/how-do-i-set-a-connection-string-config-programmatically-in-net
    //ref: https://stackoverflow.com/questions/11644800/update-connectionstring-in-app-config-file-at-run-time-in-c-sharp
    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    config.ConnectionStrings.ConnectionStrings.Remove("New_QDAS_DATAConnectionString");
    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("New_QDAS_DATAConnectionString",String.Format("Server={0};Database={1};User Id={2};Password={3};","127.0.0.1,1433", "QDAS_VALUE_DATABASE","qdas" ,"qdas1234"),"System.Data.SqlClient"));
    config.Save(ConfigurationSaveMode.Modified, true);
    ConfigurationManager.RefreshSection("connectionStrings");
}


//GetCharacteristicsInfo("LINE  20", "OP11");

//GetCharacteristicsInfoAPI("LINE  20", "OP11");

//GetOperationStatusInfo("LINE 1", "OP10");

static void TestMySqlDataSet()
{
    updateConfigs();
    const string sqlCmd = @"Select * from TEIL";
    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
    Database db = DatabaseFactory.CreateDatabase("New_QDAS_DATAConnectionString");
    using (DbCommand cmd = db.GetSqlStringCommand(sqlCmd))
    {
        try
        {
            var dataset = db.ExecuteDataSet(cmd);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
//static List<CharSummary> GetCharacteristicsInfo(string TE_1087, string TEARBEITSGANG)
//{

//    List<CharSummary> objList = new List<CharSummary>();
//    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
//    Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

//    using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetCharacteristicsInfo"))
//    {
//        try
//        {
//            db.AddInParameter(cmd, "@TE_1087", DbType.String, TE_1087);
//            db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);

//            using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
//            {
//                //   objList = ConvertTo<CharSummary>(dataTable);
//            }
//        }
//        catch (Exception ex)
//        {
//            throw;
//        }
//    }
//    return objList;
//}

//static IResult GetCharacteristicsInfoAPI(string TE_1087, string TEARBEITSGANG)
//{
//    TEILService teilService = new TEILService();
//        var data = teilService.GetCharacteristicsInfo(TE_1087, TEARBEITSGANG);
//        return Results.Json(data);
   
//}







