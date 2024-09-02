        // GET: CharCharts
        public ActionResult CharCharts(String partList, String partID, String charID)
        {
            string resultString = "";

            CharEvalData charModel = new CharEvalData();

            Console.WriteLine("Start Getting charts " + DateTime.Now.ToString());


            try
            {


                String lastNValues = "125";


                HttpCookie reqCookies = Request.Cookies["QDAS_Filter"];
                if (reqCookies != null)
                {

                    lastNValues = Request.Cookies["QDAS_Filter"].Value;
                }

                IQdas_Web_Serviceservice ws = new IQdas_Web_Serviceservice();
                int handle = -1;
                int result = -1;

                if (ws != null)
                {
                    result = ws.WebConnect(20, 44, "superuser", "superuser", "", out handle);
                }


                String FieldList = "";

                int queryHandle = -1;
                int SQLHandle = -1;
                int filterHandle = -1;



                // TEBEREICH Plant
                // TEERZEUGNIS Product
                // [TEARBEITSGANG] Operation
                // [TEMASCHINEBEZ] Machine
                // [TEMASCHINENR] Pallet
                // [TETYP] Model
                // [TEBEZEICH] Description
                // [TEWERKSTATT] Component

                if (result != -1)
                {
                    //String partListStr = "<Part key = '" + partID + "' />";

                    String partListStr = "<Part key = '" + partID + "'><Char key='" + charID + "'/></Part>";

                    result = ws.CreateQuery(handle, out queryHandle);

                    result = ws.CreateFilter(handle, 1, 0, lastNValues, 129, out filterHandle);

                    if (result == 0)
                    {
                        result = ws.AddFilterToQuery(handle, queryHandle, filterHandle, 2, 0, 0);

                        if (result == 0)
                        {

                            String partListXML = "<PartCharList>" + partListStr + "</PartCharList>";


                            result = ws.ExecuteQuery_Ext(handle, queryHandle, partListXML, false, true);
                            result = ws.EvaluateAllChars(handle);

                            int partCount = -1;
                            int charCount = -1;
                            result = ws.GetGlobalInfo(handle, 0, 0, 1, out partCount);

                            string StatResult_str1 = "";
                            //Get Cp Value

                            if (partCount  == 1)
                            {

                                result = ws.GetGlobalInfo(handle, 1, 0, 2, out charCount);

                                // Get Characteristics Eval Data

                                string partNr = "";
                                string partDesc = "";
                                string partOp = "";

                                string modelType = "";
                                string productType = "";

                                result = ws.GetGlobalInfo(handle, 1, 0, 2, out charCount);
                                result = ws.GetPartInfo(handle, 1001, 1, 0, out partNr);
                                result = ws.GetPartInfo(handle, 1002, 1, 0, out partDesc);
                                result = ws.GetPartInfo(handle, 1005, 1, 0, out productType);
                                result = ws.GetPartInfo(handle, 1008, 1, 0, out modelType);
                                result = ws.GetPartInfo(handle, 1086, 1, 0, out partOp);


                                if (charCount == 1)
                                {
                                    String charInfo = "";
                                    double charDbl = 0.0;
                                    int charResult = -1;

                                    String classStr = "";
                                    charResult = ws.GetCharInfo(handle, 2005, 1, 1, out charInfo);
                                    classStr = charResult == 0 ? charInfo : "ERROR";

                                    String riskStr = "";
                                    charResult = ws.GetStatResult(handle, 20030, 1, 1, 0, out charInfo, out charDbl);
                                    riskStr = charResult == 0 ? charInfo : "ERROR";

                                    String charNr = "";
                                    charResult = ws.GetCharInfo(handle, 2001, 1, 1, out charInfo);
                                    charNr = charResult == 0 ? charInfo : "ERROR";

                                    String charDesc = "";
                                    charResult = ws.GetCharInfo(handle, 2002, 1, 1, out charInfo);
                                    charDesc = charResult == 0 ? charInfo : "ERROR";


                                    String xBar = "";
                                    charResult = ws.GetStatResult(handle, 1000, 1, 1, 0, out charInfo, out charDbl);
                                    xBar = charResult == 0 ? charInfo : "ERROR";

                                    String stdDev = "";
                                    charResult = ws.GetStatResult(handle, 2100, 1, 1, 0, out charInfo, out charDbl);
                                    stdDev = charResult == 0 ? charInfo : "ERROR";

                                    String potIndex = "";
                                    charResult = ws.GetStatResult(handle, 5210, 1, 1, 0, out charInfo, out charDbl);
                                    potIndex = charResult == 0 ? charInfo : "ERROR";

                                    String criticalIndex = "";
                                    charResult = ws.GetStatResult(handle, 5220, 1, 1, 0, out charInfo, out charDbl);
                                    criticalIndex = charResult == 0 ? charInfo : "ERROR";

                                    String valGraphicStr = "";
                                    charResult = ws.GetGraphic(handle, 3100, 1, 1, 500, 300, out valGraphicStr);
                                    if (charResult == 0)
                                    {
                                        var xmlDocument = new XmlDocument();
                                        xmlDocument.LoadXml(valGraphicStr);

                                        charModel.valueChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;

                                    }

                                    String qccGraphicStr = "";
                                    charResult = ws.GetGraphic(handle, 6110, 1, 1, 500, 300, out qccGraphicStr);
                                    if (charResult == 0)
                                    {
                                        var xmlDocument = new XmlDocument();
                                        xmlDocument.LoadXml(qccGraphicStr);

                                        charModel.qccChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;

                                    }


                                    String histGraphicStr = "";
                                    charResult = ws.GetGraphic(handle, 3300, 1, 1, 250, 300, out histGraphicStr); 
                                    if (charResult == 0)
                                    {
                                        var xmlDocument = new XmlDocument();
                                        xmlDocument.LoadXml(histGraphicStr);

                                        charModel.histChartImg = xmlDocument.SelectSingleNode("/Test/Image").InnerText;
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
                    ws.ClientDisconnect(handle);
                }

            }
            catch (Exception ex)
            {
            }

            return View(charModel);
        }
