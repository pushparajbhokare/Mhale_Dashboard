using Kneo.Model.QDas;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Kneo.QDas.DB
{
    public class TEILDB : HelperDAL
    {
        #region Variable
        #endregion

        #region Constructor
        #endregion

        #region Database Method
        //public List<TEIL> GetLevel3DashboardData(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        //{
        //    List<TEIL> objList = new List<TEIL>();
        //    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
        //    Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

        //    using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetLevel3DashboardData"))
        //    {
        //        try
        //        {
        //            db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
        //            db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
        //            db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
        //            db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

        //            using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
        //            {
        //                objList = ConvertTo<TEIL>(dataTable);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    return objList;
        //}

        public List<TEILSummary> GetPartSummary(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate, string MEMERKBEZ = "")
        {
            List<TEILSummary> objList = new List<TEILSummary>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetPartSummary"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);
                    db.AddInParameter(cmd, "@MEMERKBEZ", DbType.String, MEMERKBEZ);
                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<TEILSummary>(dataTable);
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        public List<CharSummary> GetCharacteristicsInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {

            List<CharSummary> objList = new List<CharSummary>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetCharacteristicsInfo"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<CharSummary>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        //public List<OperationStatusInfo> GetOperationStatusInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        //{

        //    List<OperationStatusInfo> objList = new List<OperationStatusInfo>();
        //    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
        //    Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

        //    using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetOperationStatusInfo"))
        //    {
        //        try
        //        {
        //            db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
        //            db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
        //            db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
        //            db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

        //            using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
        //            {
        //                objList = ConvertTo<OperationStatusInfo>(dataTable);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    return objList;
        //}

        public List<AllOperationStatusInfo> GetAllPartSummary(string TEWERKSTATT, DateTime @FromDate, DateTime @ToDate)
        {
            List<AllOperationStatusInfo> objList = new List<AllOperationStatusInfo>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetAllPartSummary"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<AllOperationStatusInfo>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        public List<Allcharstatusinfo> GetAllCharacteristicsInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            List<Allcharstatusinfo> objList = new List<Allcharstatusinfo>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetAllCharacteristicsInfo"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<Allcharstatusinfo>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        public List<AllProcessInfo> GetProcessPerformance(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            List<AllProcessInfo> objList = new List<AllProcessInfo>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetProcessPerformance"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<AllProcessInfo>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        public List<AllProcessInfoWithFtt> GetOperationListWithFTT(string TEWERKSTATT, DateTime FromDate, DateTime ToDate)
        {
            List<AllProcessInfoWithFtt> objList = new List<AllProcessInfoWithFtt>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetOperationListWithFTT"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<AllProcessInfoWithFtt>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        public List<AllProcessInfoWithFtt> GetDashboardAlarm( DateTime FromDate, DateTime ToDate)
        {
            List<AllProcessInfoWithFtt> objList = new List<AllProcessInfoWithFtt>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetDashboardAlarm"))
            {
                try
                {
                  
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<AllProcessInfoWithFtt>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }

        //public List<AllProcessInfoWithFtt> GetDashboardAlarmFTT(string TEWERKSTATT, DateTime FromDate, DateTime ToDate)
        //{
        //    List<AllProcessInfoWithFtt> objList = new List<AllProcessInfoWithFtt>();
        //    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
        //    Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

        //    using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetDashboardAlarmFTT"))
        //    {
        //        try
        //        {
        //            db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
        //            db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
        //            db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

        //            using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
        //            {
        //                objList = ConvertTo<AllProcessInfoWithFtt>(dataTable);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    return objList;
        //}

        public List<OperationPartStatus> GetOperationPartStatus(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            List<OperationPartStatus> objList = new List<OperationPartStatus>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetOperationPartStatus")) 
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@TEARBEITSGANG", DbType.String, TEARBEITSGANG);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<OperationPartStatus>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }
        //public List<SummaryData> GetDashboardSummaryData(DateTime FromDate, DateTime ToDate, Boolean Summary = false)
        //{
        //    List<SummaryData> objList = new List<SummaryData>();
        //    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
        //    Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

        //    using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetDashboardSummaryData"))
        //    {
        //        try
        //        {
        //            db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
        //            db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);
        //            db.AddInParameter(cmd, "@Summary", DbType.Boolean, Summary);

        //            using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
        //            {
        //                objList = ConvertTo<SummaryData>(dataTable);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    return objList;
        //}


        public List<AlarmSummary> GetAlarmDetails(string TEWERKSTATT,  DateTime FromDate, DateTime ToDate)
        {
            List<AlarmSummary> objList = new List<AlarmSummary>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("QDAS_DATAConnectionString");

            using (System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetAlarmDetails"))
            {
                try
                {
                    db.AddInParameter(cmd, "@TEWERKSTATT", DbType.String, TEWERKSTATT);
                    db.AddInParameter(cmd, "@FromDate", DbType.DateTime, FromDate);
                    db.AddInParameter(cmd, "@ToDate", DbType.DateTime, ToDate);
               

                    using (DataTable dataTable = db.ExecuteDataSet(cmd).Tables[0])
                    {
                        objList = ConvertTo<AlarmSummary>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return objList;
        }



        #endregion
    }
}
