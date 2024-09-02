using Kneo.Model.QDas;
using Kneo.Service.QDas;
using Microsoft.AspNetCore.Http;
using ServiceReference1;
using System;
using System.Configuration;
using System.Xml;
using System;
using System.Threading.Tasks;

namespace App.RouteBindings
{


    public static class RouteMethodsQQD
    {
    
        public static IResult IndexMethod()
        {
            return Results.LocalRedirect("~/index.html", false, true);
        }

        public static IResult pageRedirect(HttpRequest request)
        {
            return Results.LocalRedirect($"~{request.Path}/index.html", false, true);
        }

        public static IResult pageRedirectWithParams(HttpRequest request)
        {
            var param = "serialNum";
            var val = request.Query[$"{param}"];
            return Results.LocalRedirect($"~{request.Path}/index.html?{param}={val}", false, true);
        }

        public static IResult MoveToHomeScreen(HttpRequest request)
        {
            return Results.LocalRedirect("~/Home", false, true);
        }

        public static IResult Level3Dashboard(HttpRequest request)
        {
            var param1 = "TEWERKSTATT";
            var param2 = "TEARBEITSGANG";
            var param3 = "FromDate";
            var param4 = "ToDate";

            var val1 = request.Query[$"{param1}"];
            var val2 = request.Query[$"{param2}"];
            var val3 = request.Query[$"{param3}"];
            var val4 = request.Query[$"{param4}"];

            return Results.LocalRedirect($"~{request.Path}/index.html?{param1}={val1}&{param2}={val2}&{param3}={val3}&{param4}={val4}", false, true);
        }

        //api calls
        //public static IResult GetLevel3DashboardData(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate,TEILService teilService)
        //{
        //    try
        //    {
        //        var data = teilService.GetLevel3DashboardData(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        //        return Results.Json(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Json(ex.Message + " " + ex.InnerException);
        //    }
        //}

        public static IResult GetPartSummary(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate, TEILService teilService, string MEMERKBEZ = "")
        {
            try
            {

                var data = teilService.GetPartSummary(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate, MEMERKBEZ);
                return Results.Json(data);

            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        public static IResult GetCharacteristicsInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate,TEILService teilService)
        {
            try
            {
                var data = teilService.GetCharacteristicsInfo(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
                return Results.Json(data);

            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        //public static IResult GetOperationStatusInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate, TEILService teilService)
        //{
        //    try
        //    {
        //        var data = teilService.GetOperationStatusInfo(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
        //        return Results.Json(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Json(ex.Message + " " + ex.InnerException);
        //    }
        //}

        public static IResult GetAllPartSummary(string TEWERKSTATT, DateTime FromDate, DateTime ToDate,TEILService teilService)
        {
            try
            {
                var data = teilService.GetAllPartSummary(TEWERKSTATT, FromDate, ToDate);
                return Results.Json(data);
            }
            catch (Exception ex)
            {

                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        public static IResult GetAllCharacteristicsInfo(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate,TEILService teilService)
        {
            try
            {
                var data = teilService.GetAllCharacteristicsInfo(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
                return Results.Json(data);

            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);

            }
        }

        public static IResult GetProcessPerformance(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate,TEILService teilService)
        {
            try
            {
                var data = teilService.GetProcessPerformance(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
                return Results.Json(data);

            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        public static IResult GetOperationListWithFTT(string TEWERKSTATT, DateTime FromDate, DateTime ToDate,TEILService teilService)
        {
            try
            {
                var data = teilService.GetOperationListWithFTT(TEWERKSTATT, FromDate, ToDate);
                return Results.Json(data);
            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        public static IResult GetDashboardAlarm( DateTime FromDate, DateTime ToDate,TEILService teilService)
        {
            try
            {
                var data = teilService.GetDashboardAlarm(FromDate, ToDate);
                return Results.Json(data);

            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        //public static IResult GetDashboardAlarmFTT(string TEWERKSTATT, DateTime FromDate, DateTime ToDate, TEILService teilService)
        //{
        //    try
        //    {
        //        var data = teilService.GetDashboardAlarmFTT(TEWERKSTATT, FromDate, ToDate);
        //        return Results.Json(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Json(ex.Message + " " + ex.InnerException);
        //    }
        //}

        public static IResult GetOperationPartStatus(string TEWERKSTATT, string TEARBEITSGANG, DateTime FromDate, DateTime ToDate , TEILService teilService)
        {
            try
            {
                var data = teilService.GetOperationPartStatus(TEWERKSTATT, TEARBEITSGANG, FromDate, ToDate);
                return Results.Json(data);
            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }

        //public static IResult GetDashboardSummaryData(DateTime FromDate, DateTime ToDate, TEILService teilService, Boolean Summary = false)
        //{
        //    try
        //    {
        //        var data = teilService.GetDashboardSummaryData(FromDate, ToDate, Summary);
        //        return Results.Json(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Json(ex.Message + " " + ex.InnerException);
        //    }
        //}



        public static IResult GetAlarmDetails(string TEWERKSTATT, DateTime FromDate, DateTime ToDate, TEILService teilService)
        {
            try
            {
                var data = teilService.GetAlarmDetails(TEWERKSTATT, FromDate, ToDate);
                return Results.Json(data);
            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }
        public static IResult GetRefreshInterval()
        {
            try
            {
                //System.Console.WriteLine(ConfigurationManager.AppSettings["RefreshInterval"]!);
                //System.Console.WriteLine(ConfigurationManager.ConnectionStrings["QDAS_DATAConnectionString"]);
                int RefreshInterval = int.Parse(ConfigurationManager.AppSettings["RefreshInterval"]!);
                return Results.Json(RefreshInterval);
            }
            catch (Exception ex)
            {
                return Results.Json(ex.Message + " " + ex.InnerException);
            }
        }





        public async static Task<CharModel> GetCharCharts(String partList, String partID, String charID)
        {
            String lastNValues = "125";
            CharModel charModel = new CharModel();
            WebConnectRequest request = new WebConnectRequest(20, 44, "superuser", "superuser", "");
            Qdas_Web_ServiceClient ws = new Qdas_Web_ServiceClient();
            WebConnectResponse response = ws.WebConnectAsync(request).GetAwaiter().GetResult();
            System.Type myType = response.GetType();
            System.Console.WriteLine(ws.Endpoint.Name);
            System.Console.WriteLine(response.Handle);

            int handle = -1;
            int result = -1;

            handle = response.Handle;

            String FieldList = "";

            int queryHandle = -1;
            int SQLHandle = -1;
            int filterHandle = -1;

            //if (result != -1)
            if (response.Result != -1)
            {
                String partListStr = "<Part key = '" + partID + "'><Char key='" + charID + "'/></Part>";

                //result = ws.CreateQueryAsync(handle, out queryHandle);
                CreateQueryRequest requestChart1 = new CreateQueryRequest(response.Handle);
                var graphicQR = await ws.CreateQueryAsync(requestChart1);
                queryHandle = graphicQR.QueryHandle;
                result = graphicQR.Result;


                //result = ws.CreateFilter(handle, 1, 0, lastNValues, 129, out filterHandle);
                //CreateFilterResponse requestChart2 = new CreateFilterResponse(handle, 1, 0, lastNValues, 129);
                //CreateFilterRequest requestChart2 = new CreateFilterRequest(result, requestChart1.Handle);
                CreateFilterRequest requestChart2 = new CreateFilterRequest(response.Handle, 1, 0, lastNValues, 129);
                var resultChart2 = await ws.CreateFilterAsync(requestChart2);
                filterHandle = resultChart2.FilterHandle;
                result = resultChart2.Result;

                //if (result == 0)
                if (resultChart2.Result == 0)
                {
                    //result = ws.AddFilterToQuery(handle, queryHandle, filterHandle, 2, 0, 0);
                    var resultChart3 = await ws.AddFilterToQueryAsync(response.Handle, graphicQR.QueryHandle, resultChart2.FilterHandle, 2, 0, 0);
                    result = resultChart3.Result;

                    //if (result == 0)
                    if (resultChart3.Result == 0)
                    {
                        String partListXML = "<PartCharList>" + partListStr + "</PartCharList>";

                        //result = ws.ExecuteQuery_Ext(handle, queryHandle, partListXML, false, true);
                        var resultChart4 = await ws.ExecuteQuery_ExtAsync(response.Handle, graphicQR.QueryHandle, partListXML, false, true);
                        result = resultChart4.Result;

                        //result = ws.EvaluateAllChars(handle);
                        var resultChart5 = await ws.EvaluateAllCharsAsync(response.Handle);
                        result = resultChart5.Result;

                        int partCount = -1;
                        int charCount = -1;

                        //result = ws.GetGlobalInfo(handle, 0, 0, 1, out partCount);
                        GetGlobalInfoRequest requestChart6 = new GetGlobalInfoRequest(response.Handle, 0, 0, 1);
                        var resultChart6 = await ws.GetGlobalInfoAsync(requestChart6);
                        result = resultChart6.Result;
                        partCount = resultChart6.ret;       //???

                        string StatResult_str1 = "";
                        //Get Cp Value

                        if (partCount == 1)
                        {
                            //result = ws.GetGlobalInfo(handle, 1, 0, 2, out charCount);
                            GetGlobalInfoRequest requestChart7 = new GetGlobalInfoRequest(response.Handle, 0, 0, 1);
                            var resultChart7 = await ws.GetGlobalInfoAsync(requestChart7);
                            result = resultChart7.Result;
                            charCount = resultChart7.ret;       //???


                            // Get Characteristics Eval Data

                            string partNr = "";
                            string partDesc = "";
                            string partOp = "";

                            string modelType = "";
                            string productType = "";

                            //result = ws.GetGlobalInfo(handle, 1, 0, 2, out charCount);
                            GetGlobalInfoRequest requestChart8 = new GetGlobalInfoRequest(response.Handle, 1, 0, 2);
                            var resultChart8 = await ws.GetGlobalInfoAsync(requestChart8);
                            result = resultChart8.Result;
                            charCount = resultChart8.ret;       //???

                            //result = ws.GetPartInfo(handle, 1001, 1, 0, out partNr);
                            GetPartInfoRequest requestChart9 = new GetPartInfoRequest(response.Handle, 1001, 1, 0);
                            var resultChart9 = await ws.GetPartInfoAsync(requestChart9);
                            result = resultChart9.Result;
                            partNr = resultChart9.KFieldValue;       //???

                            //result = ws.GetPartInfo(handle, 1002, 1, 0, out partDesc);
                            GetPartInfoRequest requestChart10 = new GetPartInfoRequest(response.Handle, 1002, 1, 0);
                            var resultChart10 = await ws.GetPartInfoAsync(requestChart10);
                            result = resultChart10.Result;
                            partDesc = resultChart10.KFieldValue;       //???

                            //result = ws.GetPartInfo(handle, 1005, 1, 0, out productType);
                            GetPartInfoRequest requestChart11 = new GetPartInfoRequest(response.Handle, 1005, 1, 0);
                            var resultChart11 = await ws.GetPartInfoAsync(requestChart11);
                            result = resultChart11.Result;
                            productType = resultChart11.KFieldValue;       //???

                            //result = ws.GetPartInfo(handle, 1008, 1, 0, out modelType);
                            GetPartInfoRequest requestChart12 = new GetPartInfoRequest(response.Handle, 1008, 1, 0);
                            var resultChart12 = await ws.GetPartInfoAsync(requestChart12);
                            result = resultChart12.Result;
                            modelType = resultChart12.KFieldValue;       //???

                            //result = ws.GetPartInfo(handle, 1086, 1, 0, out partOp);
                            GetPartInfoRequest requestChart13 = new GetPartInfoRequest(response.Handle, 1086, 1, 0);
                            var resultChart13 = await ws.GetPartInfoAsync(requestChart13);
                            result = resultChart13.Result;
                            partOp = resultChart13.KFieldValue;       //???


                            //if (resultChart7.Result == 1)
                            if (charCount == 1)
                            //Try alternate if needed
                            //if (resultChart7.ret == 1)
                            {
                                String charInfo = "";
                                double charDbl = 0.0;
                                int charResult = -1;

                                String classStr = "";

                                //charResult = ws.GetCharInfo(handle, 2005, 1, 1, out charInfo);
                                GetCharInfoRequest requestChart14 = new GetCharInfoRequest(response.Handle, 2005, 1, 1);
                                var resultChart14 = await ws.GetCharInfoAsync(requestChart14);
                                charResult = resultChart14.Result;
                                charInfo = resultChart14.KFieldValue;       //???

                                classStr = charResult == 0 ? charInfo : "ERROR";

                                String riskStr = "";

                                //charResult = ws.GetStatResult(handle, 20030, 1, 1, 0, out charInfo, out charDbl);
                                GetStatResultRequest requestChart15 = new GetStatResultRequest(response.Handle, 20030, 2, 1, 0);
                                var resultChart15 = await ws.GetStatResultAsync(requestChart15);
                                charResult = resultChart15.Result;
                                charInfo = resultChart15.StatResult_str;
                                charDbl = resultChart15.StatResult_dbl;

                                riskStr = charResult == 0 ? charInfo : "ERROR";

                                String charNr = "";

                                //charResult = ws.GetCharInfo(handle, 2001, 1, 1, out charInfo);
                                GetCharInfoRequest requestChart16 = new GetCharInfoRequest(response.Handle, 2001, 1, 1);
                                var resultChart16 = await ws.GetCharInfoAsync(requestChart16);
                                charResult = resultChart16.Result;
                                charInfo = resultChart16.KFieldValue;

                                charNr = charResult == 0 ? charInfo : "ERROR";


                                String charDesc = "";

                                //charResult = ws.GetCharInfo(handle, 2002, 1, 1, out charInfo);
                                GetCharInfoRequest requestChart17 = new GetCharInfoRequest(response.Handle, 2002, 1, 1);
                                var resultChart17 = await ws.GetCharInfoAsync(requestChart17);
                                charResult = resultChart16.Result;
                                charInfo = resultChart16.KFieldValue;


                                charDesc = charResult == 0 ? charInfo : "ERROR";


                                String xBar = "";

                                //charResult = ws.GetStatResult(handle, 1000, 1, 1, 0, out charInfo, out charDbl);
                                GetStatResultRequest requestChart18 = new GetStatResultRequest(response.Handle, 1000, 1, 1, 0);
                                var resultChart18 = await ws.GetStatResultAsync(requestChart18);
                                charResult = resultChart18.Result;
                                charInfo = resultChart18.StatResult_str;
                                charDbl = resultChart18.StatResult_dbl;

                                xBar = charResult == 0 ? charInfo : "ERROR";

                                String stdDev = "";

                                //charResult = ws.GetStatResult(handle, 2100, 1, 1, 0, out charInfo, out charDbl);
                                GetStatResultRequest requestChart19 = new GetStatResultRequest(response.Handle, 2100, 1, 1, 0);
                                var resultChart19 = await ws.GetStatResultAsync(requestChart19);
                                charResult = resultChart19.Result;
                                charInfo = resultChart19.StatResult_str;
                                charDbl = resultChart19.StatResult_dbl;

                                stdDev = charResult == 0 ? charInfo : "ERROR";


                                String potIndex = "";

                                //charResult = ws.GetStatResult(handle, 5210, 1, 1, 0, out charInfo, out charDbl);
                                GetStatResultRequest requestChart20 = new GetStatResultRequest(response.Handle, 5210, 1, 1, 0);
                                var resultChart20 = await ws.GetStatResultAsync(requestChart20);
                                charResult = resultChart20.Result;
                                charInfo = resultChart20.StatResult_str;
                                charDbl = resultChart20.StatResult_dbl;

                                potIndex = charResult == 0 ? charInfo : "ERROR";


                                String criticalIndex = "";

                                //charResult = ws.GetStatResult(handle, 5220, 1, 1, 0, out charInfo, out charDbl);
                                GetStatResultRequest requestChart21 = new GetStatResultRequest(response.Handle, 5220, 1, 1, 0);
                                var resultChart21 = await ws.GetStatResultAsync(requestChart21);
                                charResult = resultChart21.Result;
                                charInfo = resultChart21.StatResult_str;
                                charDbl = resultChart21.StatResult_dbl;

                                criticalIndex = charResult == 0 ? charInfo : "ERROR";

                                String valGraphicStr = "";

                                string valueChartImg = string.Empty;
                                string qccChartImg = string.Empty;
                                string histChartImg = string.Empty;

                                //charResult = ws.GetGraphic(handle, 3100, 1, 1, 500, 300, out valGraphicStr);
                                GetGraphicRequest requestChart22 = new GetGraphicRequest(response.Handle, 3100, 1, 1, 500, 300);

                                try
                                {
                                    var resultChart22 = await ws.GetGraphicAsync(requestChart22);
                                    charResult = resultChart22.Result;
                                    valGraphicStr = resultChart22.GraphicStr;
                                    Console.WriteLine("charResult....." + charResult);
                                    if (charResult == 0)
                                    {
                                        var xmlDocument = new XmlDocument();
                                        xmlDocument.LoadXml(valGraphicStr);

                                        charModel.valueChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
                                        valueChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
                                        //  File.WriteAllText(@"D:\qdasQualityDashboard\ConsoleApp1\valueChartImg.txt", valueChartImg);
                                    }
                                }
                                catch (Exception E)
                                {

                                    Console.WriteLine("exce....." + E.Message);
                                }



                                String qccGraphicStr = "";

                                //charResult = ws.GetGraphic(handle, 6110, 1, 1, 500, 300, out qccGraphicStr);
                                GetGraphicRequest requestChart23 = new GetGraphicRequest(response.Handle, 6110, 1, 1, 500, 300);
                                var resultChart23 = await ws.GetGraphicAsync(requestChart23);
                                charResult = resultChart23.Result;
                                qccGraphicStr = resultChart23.GraphicStr;

                                if (charResult == 0)
                                {
                                    var xmlDocument = new XmlDocument();
                                    xmlDocument.LoadXml(qccGraphicStr);

                                    charModel.qccChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
                                    qccChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
                                    //    File.WriteAllText(@"D:\qdasQualityDashboard\ConsoleApp1\qccChartImg.txt", qccChartImg);
                                }


                                String histGraphicStr = "";

                                //charResult = ws.GetGraphic(handle, 3300, 1, 1, 250, 300, out histGraphicStr);
                                GetGraphicRequest requestChart24 = new GetGraphicRequest(response.Handle, 3300, 1, 1, 250, 300);
                                var resultChart24 = await ws.GetGraphicAsync(requestChart24);
                                charResult = resultChart24.Result;
                                histGraphicStr = resultChart24.GraphicStr;

                                if (charResult == 0)
                                {
                                    var xmlDocument = new XmlDocument();
                                    xmlDocument.LoadXml(histGraphicStr);

                                    charModel.histChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
                                    histChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
                                    //  File.WriteAllText(@"D:\qdasQualityDashboard\ConsoleApp1\histChartImg.txt", histChartImg);
                                }

                                charModel.modelType = modelType;
                                charModel.productNr = partNr;
                                charModel.productType = productType;
                                charModel.description = partDesc;
                                charModel.partList = partList;
                                charModel.OpNo = partOp;
                                charModel.partID = partID;
                                charModel.potIndex = potIndex;
                                charModel.criticalIndex = criticalIndex;
                                charModel.xBar = xBar;
                                charModel.stdDev = stdDev;
                                charModel.riskLevel = riskStr;
                                charModel.CharClass = classStr;
                                charModel.CharDesc = charDesc;
                                charModel.charNr = charNr;
                            }
                        }
                    }
                }

                _ = ws.ClientDisconnectAsync(handle); //suggestedChange, underscore to remove warning by compiler
            }

            return charModel;
        }





        public async static Task<Allcharstatusinfo[]> GetCharDetails(String line, String operation)
        {

            Allcharstatusinfo[] CharList = new Allcharstatusinfo[1];

            WebConnectRequest request = new WebConnectRequest(20, 44, "superuser", "superuser", "");
            Qdas_Web_ServiceClient ws = new Qdas_Web_ServiceClient();
            WebConnectResponse response = ws.WebConnectAsync(request).GetAwaiter().GetResult();
            System.Type myType = response.GetType();
            System.Console.WriteLine(ws.Endpoint.Name);
            System.Console.WriteLine(response.Handle);

            String partList1 = string.Empty;

            String partID1 = "";
            String charID1 = "";
            String lastNValues = "125";
            int handle = -1;
            int result = -1;
            handle = response.Handle;

            String FieldList = "";

            int queryHandle = -1;
            int SQLHandle = -1;
            int filterHandle = -1;


            if (response.Result != -1)
            {

                String partListStr = "<Part key = '" + partID1 + "'><Char key='" + charID1 + "'/></Part>";

                CreateQueryRequest requestChart1 = new CreateQueryRequest(response.Handle);
                var graphicQR = await ws.CreateQueryAsync(requestChart1);
                queryHandle = graphicQR.QueryHandle;
                result = graphicQR.Result;



                CreateFilterRequest requestChart3 = new CreateFilterRequest(response.Handle, 1, 1102, line, 0);
                var resultChart3 = await ws.CreateFilterAsync(requestChart3);
                var filterHandleforline = resultChart3.FilterHandle;
                result = resultChart3.Result;


                CreateFilterRequest requestChart4 = new CreateFilterRequest(response.Handle, 1, 1086, operation, 0);
                var resultChart4 = await ws.CreateFilterAsync(requestChart4);
                var filterHandleforoperation = resultChart4.FilterHandle;
                result = resultChart4.Result;


                AddFilterToQueryRequest requestChart5 = new AddFilterToQueryRequest();
                var resultChart5 = await ws.AddFilterToQueryAsync(response.Handle, queryHandle, filterHandleforline, 0, 0, 0);
                result = resultChart5.Result;


                AddFilterToQueryRequest requestChart6 = new AddFilterToQueryRequest();
                var resultChart6 = await ws.AddFilterToQueryAsync(response.Handle, queryHandle, filterHandleforoperation, 0, 0, 0);
                result = resultChart6.Result;


                ExecuteQueryRequest requestChart7 = new ExecuteQueryRequest();
                var resultChart7 = await ws.ExecuteQueryAsync(response.Handle, queryHandle, partListStr);
                result = resultChart7.Result;


                CreateFilterRequest requestChart77 = new CreateFilterRequest();
                var resultChart77 = await ws.EvaluateAllCharsAsync(response.Handle);
                var result2 = resultChart77.Result;



                GetPartInfoRequest requestChart80 = new GetPartInfoRequest(response.Handle, 1000, 1, 0);
                var resultChart80 = await ws.GetPartInfoAsync(requestChart80);
                var res = resultChart80.KFieldValue;

                Console.WriteLine("PART_NUMBER....." + res);


                GetGlobalInfoRequest requestChart8 = new GetGlobalInfoRequest(response.Handle, 1, 0, 1);
                var resultChart8 = await ws.GetGlobalInfoAsync(requestChart8);
                result = resultChart8.Result;
                var partCount = resultChart8.ret;
                Console.WriteLine("PART_COUNT......" + partCount);


                GetGlobalInfoRequest requestChart88 = new GetGlobalInfoRequest(response.Handle, 1, 0, 2);
                var resultChart88 = await ws.GetGlobalInfoAsync(requestChart88);
                result = resultChart88.Result;
                var char_count = resultChart88.ret;
                Console.WriteLine("CHAR_COUNT......" + char_count);



                string xmlstring = "<FieldList><Field key=\"2001\"/><Field key=\"2002\"/></FieldList>";
                GetFirstCharQueryRequest requestchart32 = new GetFirstCharQueryRequest(response.Handle, queryHandle, Convert.ToInt32(res), xmlstring);
                var resultchart32 = await ws.GetFirstCharQueryAsync(requestchart32);
                var res1 = resultchart32.KResultList;
                string xmlstring1 = res1;
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlstring1);
                var values = xmlDocument.DocumentElement.SelectNodes("//Field/@value");

                int counter = 0;
                //Get Char No.
                CharList[0] = new Allcharstatusinfo();

                foreach (XmlNode valueNode in values)
                {
                    counter++;
                    if (counter % 2 == 1)
                    {
                        CharList[0].parameter = Convert.ToInt32(valueNode.InnerText);
                    }
                    else
                    {
                        CharList[0].parameter_desc = valueNode.InnerText;
                    }

                    Console.WriteLine("Value: " + valueNode.InnerText);
                }






                for (int i = 1; i < char_count; i++)

                {
                    GetNextCharQueryRequest requestchart33 = new GetNextCharQueryRequest(response.Handle, queryHandle);
                    var resultchart33 = await ws.GetNextCharQueryAsync(requestchart33);
                    var res2 = resultchart33.KResultList;

                    string xmlstring2 = res2;
                    var xmlDocument1 = new XmlDocument();
                    xmlDocument.LoadXml(xmlstring2);
                    var values1 = xmlDocument.DocumentElement.SelectNodes("//Field/@value");

                    Array.Resize(ref CharList, i + 1);
                    CharList[i] = new Allcharstatusinfo();

                    foreach (XmlNode valueNode in values1)
                    {
                        counter++;
                        if (counter % 2 == 1)
                        {
                            CharList[i].parameter = Convert.ToInt32(valueNode.InnerText);
                        }
                        else
                        {
                            CharList[i].parameter_desc = valueNode.InnerText;
                        }

                        Console.WriteLine("Value: " + valueNode.InnerText);
                    }


                }


                for (int j = 0; j < char_count; j++)
                {
                    int charNo = j;
                    GetCharInfoRequest requestChart75 = new GetCharInfoRequest(response.Handle, 2005, 1, charNo);
                    var resultchart75 = await ws.GetCharInfoAsync(requestChart75);
                    var res3 = resultchart75.KFieldValue;
                    CharList[j].mclass = res3;

                    Console.WriteLine("CHAR_STATUS......" + res3);
                }



                string xBar = "";
                string stdDev = "";
                string range = "";
                string potIndex = "";
                string criticalIndex = "";

                for (int k = 0; k < char_count; k++)
                {
                    var charNo_1 = k + 1;


                    GetStatResultRequest requestChart21 = new GetStatResultRequest(response.Handle, 1000, 1, charNo_1, 0);
                    var resultChart21 = await ws.GetStatResultAsync(requestChart21);
                    var charResult = resultChart21.Result;
                    var charInfo = resultChart21.StatResult_str;
                    var charDbl = resultChart21.StatResult_dbl;
                    criticalIndex = charResult == 0 ? charInfo : "ERROR";

                    string Avg = Convert.ToString(charDbl);

                    CharList[k].xBar = Convert.ToDouble(Avg);


                    GetStatResultRequest requestChart19 = new GetStatResultRequest(response.Handle, 2100, 1, charNo_1, 0);
                    var resultChart19 = await ws.GetStatResultAsync(requestChart19);
                    charResult = resultChart19.Result;
                    charInfo = resultChart19.StatResult_str;
                    charDbl = resultChart19.StatResult_dbl;
                    stdDev = charResult == 0 ? charInfo : "ERROR";

                    string stddev = Convert.ToString(charDbl);

                    CharList[k].stdDev = Convert.ToDouble(stdDev);



                    GetStatResultRequest requestChart22 = new GetStatResultRequest(response.Handle, 2300, 1, charNo_1, 0);
                    var resultChart22 = await ws.GetStatResultAsync(requestChart22);
                    charResult = resultChart22.Result;
                    charInfo = resultChart22.StatResult_str;
                    charDbl = resultChart22.StatResult_dbl;
                    range = charResult == 0 ? charInfo : "ERROR";

                    Console.WriteLine("PP......" + potIndex);


                    string RANGE = Convert.ToString(charDbl);

                    CharList[k].range = Convert.ToDouble(RANGE);



                    GetStatResultExRequest requestChartE = new GetStatResultExRequest(response.Handle, 5210, 0, 1, charNo_1, 0, 2, 1, 0, 0);
                    var resultChartE = await ws.GetStatResultExAsync(requestChartE);
                    var charResultE = resultChartE.Result;
                    var charInfoE = resultChartE.StatResult_str1;
                    // PP
                    GetStatResultRequest requestChart20 = new GetStatResultRequest(response.Handle, 5210, 1, charNo_1, 0);
                    var resultChart20 = await ws.GetStatResultAsync(requestChart20);
                    charResult = resultChart20.Result;
                    charInfo = resultChart20.StatResult_str;
                    charDbl = resultChart20.StatResult_dbl;
                    potIndex = charResult == 0 ? charInfo : "ERROR";

                    Console.WriteLine("PP......" + potIndex);

                    double pp = charDbl;

                    CharList[k].potindex = charInfoE + " = " + (Convert.ToString(pp));




                    GetStatResultExRequest requestChartJ = new GetStatResultExRequest(response.Handle, 5220, 20, 1, charNo_1, 0, 2, 1, 0, 0);
                    var resultChartJ = await ws.GetStatResultExAsync(requestChartJ);
                    var charResultJ = resultChartJ.Result;
                    var charInfoJ = resultChartJ.StatResult_str1;

                    // PPK
                    GetStatResultRequest requestChart28 = new GetStatResultRequest(response.Handle, 5220, 1, charNo_1, 0);
                    var resultChart28 = await ws.GetStatResultAsync(requestChart28);
                    charResult = resultChart28.Result;
                    charInfo = resultChart28.StatResult_str;
                    charDbl = resultChart28.StatResult_dbl;
                    criticalIndex = charResult == 0 ? charInfo : "ERROR";

                    double cpk = charDbl;
                    CharList[k].criticalIndex = charInfoJ + " = " + (Convert.ToString(cpk));
                }
                ws.ClientDisconnectAsync(handle);


            }
            return CharList;
        }
    }
}