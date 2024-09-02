//// See https://aka.ms/new-console-template for more information
//using Kneo.Database.Single.Tenant;
using Kneo.Model.QDas;
using Kneo.Service.QDas;
using Microsoft.AspNetCore.Http;
using ServiceReference1;
using System;
using System.Reflection.Metadata;
using System.Xml;

Console.WriteLine("THIS IS MY TESTING PROJECT");

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


    //Console.Write("Enter Line: ");
    //string Line = Console.ReadLine();

    CreateFilterRequest requestChart3 = new CreateFilterRequest(response.Handle, 1, 1102, "LINE_4", 0);
    var resultChart3 = await ws.CreateFilterAsync(requestChart3);
    var filterHandleforline = resultChart3.FilterHandle;
    result = resultChart3.Result;


    //Console.Write("Enter Op: ");
    //string Operation = Console.ReadLine();

    CreateFilterRequest requestChart4 = new CreateFilterRequest(response.Handle, 1, 1086, "OP_120", 0);
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



    GetStatResultExRequest requestChart08 = new GetStatResultExRequest(response.Handle, 15100, 10, 8, 0, 1, 4, 0, 0, 0);
    var resultChart08 = await ws.GetStatResultExAsync(requestChart08);
    result = resultChart08.Result;
    var alarm = resultChart08.OutputCount;
    Console.WriteLine("alarmCOUNT......" + alarm);



    //*****************************************************************************************************************

    Allcharstatusinfo[] CharList = new Allcharstatusinfo[1];

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

    //  Console.WriteLine("CHAR_INFO......" + res1);





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

        // Console.WriteLine("char_info......" + res2);
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



    //var charNo_1;
    string xBar = "";
    string stdDev = "";
    string potIndex = "";
    string criticalIndex = "";

    for (int k = 0; k < char_count; k++)
    {
        var charNo_1 = k + 1;

        // Avg
        GetStatResultRequest requestChart18 = new GetStatResultRequest(response.Handle, 1000, 1, charNo_1, 0);
        var resultChart18 = await ws.GetStatResultAsync(requestChart18);
        var charResult = resultChart18.Result;
        var charInfo = resultChart18.StatResult_str;
        var charDbl = resultChart18.StatResult_dbl;
        xBar = charResult == 0 ? charInfo : "ERROR";
        CharList[k].xBar = charDbl;
        Console.WriteLine("AVG......" + xBar);

        // StdDev
        GetStatResultRequest requestChart19 = new GetStatResultRequest(response.Handle, 2100, 1, charNo_1, 0);
        var resultChart19 = await ws.GetStatResultAsync(requestChart19);
        charResult = resultChart19.Result;
        charInfo = resultChart19.StatResult_str;
        charDbl = resultChart19.StatResult_dbl;
        stdDev = charResult == 0 ? charInfo : "ERROR";
        CharList[k].stdDev = charDbl;
        Console.WriteLine("STDDEV......" + stdDev);

        // PP
        GetStatResultRequest requestChart20 = new GetStatResultRequest(response.Handle, 5210, 1, charNo_1, 0);
        var resultChart20 = await ws.GetStatResultAsync(requestChart20);
        charResult = resultChart20.Result;
        charInfo = resultChart20.StatResult_str;
        charDbl = resultChart20.StatResult_dbl;
        potIndex = charResult == 0 ? charInfo : "ERROR";
        CharList[k].potIndex = charDbl;
        Console.WriteLine("PP......" + potIndex);

        // PPK
        GetStatResultRequest requestChart21 = new GetStatResultRequest(response.Handle, 5220, 1, charNo_1, 0);
        var resultChart21 = await ws.GetStatResultAsync(requestChart21);
        charResult = resultChart21.Result;
        charInfo = resultChart21.StatResult_str;
        charDbl = resultChart21.StatResult_dbl;
        criticalIndex = charResult == 0 ? charInfo : "ERROR";
        CharList[k].criticalIndex = charDbl;
        Console.WriteLine("PPK......" + criticalIndex);
    }

    ws.ClientDisconnectAsync(handle);
}






