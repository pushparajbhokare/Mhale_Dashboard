using Kneo.Model.QDas;
using Kneo.QDas.DB;

namespace Kneo.Service.QDas
{
    public class TEILService
    {
        private readonly TEILDB TEILDB;

        public TEILService()
        {
            TEILDB = new();
        }

        public object GetTotalCountDB { get; private set; }

        //public List<TEIL> GetLevel3DashboardData(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        //{
        //    return TEILDB.GetLevel3DashboardData(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        //}

        public List<TEILSummary> GetPartSummary(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate, string MEMERKBEZ = "")
        {
            return TEILDB.GetPartSummary(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate, MEMERKBEZ);
        }

        public List<CharSummary> GetCharacteristicsInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetCharacteristicsInfo(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        }

        //public List<OperationStatusInfo> GetOperationStatusInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        //{
        //    return TEILDB.GetOperationStatusInfo(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        //}

        public List<AllOperationStatusInfo> GetAllPartSummary(string TEWERKSTATT, DateTime @FromDate, DateTime @ToDate)
        {
            return TEILDB.GetAllPartSummary(TEWERKSTATT, @FromDate, @ToDate);
        }

        public List<Allcharstatusinfo> GetAllCharacteristicsInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetAllCharacteristicsInfo(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        }

        public List<AllProcessInfo> GetProcessPerformance(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetProcessPerformance(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        }

        public List<AllProcessInfoWithFtt> GetOperationListWithFTT(string TEWERKSTATT, DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetOperationListWithFTT(TEWERKSTATT, FromDate, ToDate);
        }

        public List<AllProcessInfoWithFtt> GetDashboardAlarm( DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetDashboardAlarm(FromDate, ToDate);
        }

        //public List<AllProcessInfoWithFtt> GetDashboardAlarmFTT(string TEWERKSTATT, DateTime FromDate, DateTime ToDate)
        //{
        //    return TEILDB.GetDashboardAlarmFTT(TEWERKSTATT, FromDate, ToDate);
        //}

        public List<OperationPartStatus> GetOperationPartStatus(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetOperationPartStatus(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        }
        //public List<SummaryData> GetDashboardSummaryData(DateTime FromDate, DateTime ToDate, Boolean Summary)
        //{
        //    return TEILDB.GetDashboardSummaryData(FromDate, ToDate, Summary);
        //}


        public List<AlarmSummary> GetAlarmDetails(string TEWERKSTATT, DateTime FromDate, DateTime ToDate)
        {
            return TEILDB.GetAlarmDetails(TEWERKSTATT, FromDate, ToDate);
        }
    }
}
