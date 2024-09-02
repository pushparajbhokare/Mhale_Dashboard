using System;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace Kneo.Model.QDas
{
    public class TEIL
    {
        public int sr_no { get; set; }
        public int teteil { get; set; }
        public int meteil { get; set; }
        public string tewerkstatt { get; set; }
        public string tebezeich { get; set; }
        public string tearbeitsgang { get; set; }
        public int memerknr { get; set; }
        public int meugw { get; set; }
        public float? meogw { get; set; }
        public float? wvwert { get; set; }
        public string mestatus { get; set; }
    }
    // To get single opearion status
    public class TEILSummary
    {
        public int sr_no { get; set; }
        public string operation { get; set; }
      
        public int? total { get; set; }
        public int? ok { get; set; }
        public int not_ok { get; set; }
    }
    //to get characteristics info
    public class CharSummary
    {
        public int sr_no { get; set; }
        public string part { get; set; }
        public string operation { get; set; }
        public int char_id { get; set; }
        public string char_name { get; set; }
        public int ok { get; set; }
        public int not_ok { get; set; }
        public int total { get; set; }
        public string mclass { get; set; }
    }

    //public class PartParameter
    //{
    //    public int teil { get; set; }
    //    public int merkmal { get; set; }
    //}
    //to get single operation status
    public class OperationStatusInfo
    {
        public int sr_no { get; set; }
        public string line { get; set; }
        public string part_desc { get; set; }
        public string operation { get; set; }
        public float ok_per { get; set; }
        public float not_ok_per { get; set; }
    }
    //To get
    //all operation status for each line
    public class AllOperationStatusInfo
    {
        public int sr_no { get; set; }
        public string line { get; set; }
        public string part_desc { get; set; }
        public string operation { get; set; }
        public float ok_per { get; set; }
        public float not_ok_per { get; set; }
    }

    public class Allcharstatusinfo
    {
        public int sr_no { get; set; }
        public string line { get; set; }
        public string operation { get; set; }
        public string part_desc { get; set; }
        public int parameter { get; set; }
        public string parameter_desc { get; set; }
        public string mclass { get; set; }
        public double xBar { get; set; }
        public double range { get; set; }

        public double stdDev { get; set; }
       
        public string potindex { get; set; }
       
        public string criticalIndex { get; set; }
       
    }



    public class AllProcessInfo
    {
        public int sr_no { get; set; }
        public string line { get; set; }
        public string operation { get; set; }
        public string part_name { get; set; }
        public string part_desc { get; set; }
        public float ftt { get; set; }
        public int total { get; set; }
        public int ok { get; set; }
        public int alarm { get; set; }
        public int rework { get; set; }

    }
    public class AllProcessInfoWithFtt
    {
        //this class use for 3 api
        public int sr_no { get; set; }
        public string line { get; set; }
        public string part_desc { get; set; }
        public string operation { get; set; }
        public int total { get; set; }
        public int accepted { get; set; }
        public int warning { get; set; }
        public int rejected { get; set; }
        public int ok { get; set; }
        public int not_ok { get; set; }
        public float accepted_per { get; set; }
        public float warning_per { get; set; }
        public float rejected_per { get; set; }
        public float ok_per { get; set; }
        public float not_ok_per { get; set; }
        public string op_status { get; set; }
        public int char_no_count { get; set; }
        public int char_desc_count { get; set; }
    }

    public class OperationPartStatus
    {
        public int sr_no { get; set; }
        public int count { get; set; }
        public string status { get; set; }
        public string line { get; set; }
        public string operation { get; set; }
        public string model { get; set; }
    }


    public class CharModel
    {
        public string modelType { get; set; }
        public string productNr { get; set; }
        public string productType { get; set; }
        public string description { get; set; }
        public string partList { get; set; }
        public string OpNo { get; set; }
        public string partID { get; set; }
        public string potIndex { get; set; }
        public string criticalIndex { get; set; }
        public string xBar { get; set; }
        public string stdDev { get; set; }
        public string riskLevel { get; set; }
        public string CharClass { get; set; }
        public string CharDesc { get; set; }
        public string charNr { get; set; }
        public string valueChartImg { get; set; }
        public string qccChartImg { get; set; }
        public string histChartImg { get; set; }
    }

    public class SummaryData
    {
        public int hourproduction { get; set; }
        public int dayproduction { get; set; }
        public int weekproduction { get; set; }
        public int totalcount { get; set; }
        public int okcount { get; set; }
        public int notokcount { get; set; }
        public float ftt { get; set; }
        public float reworkppm { get; set; }
        public float rejectionppm { get; set; }
 
    }


    public class AlarmSummary
    {
        public string line { get; set; }
        public string  characteristics { get; set; }
        public string part { get; set; }
        public int alarm_ew { get; set; }
        public string  alarm { get; set; }

        public string status { get; set; }

    }
}
