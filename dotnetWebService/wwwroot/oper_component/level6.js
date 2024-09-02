
var refInterval;
//var refrestInterval;
var interval;
$(document).ready(function () {

    var TEWERKSTATT= getQueryStringValue('TEWERKSTATT');
    var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');

    var FromDate = getQueryStringValue('FromDate');
    var ToDate = getQueryStringValue('ToDate');
    $('#FromDate').val(moment(FromDate, 'MM/DD/YYYY').format('DD/MM/YYYY'));
    $('#ToDate').val(moment(ToDate, 'MM/DD/YYYY').format('DD/MM/YYYY'));


    processRefresh();

    Interval_Ajax = getIntervalTime();
    interval = parseInt(Interval_Ajax.responseText);
    console.log(interval)
    var refInterval = setInterval(function () {
        processRefresh()
    }, interval)
    $("#daywise").on('click', function () {
        processRefresh();
        clearInterval(refInterval);
        refInterval = setInterval(function () {
            processRefresh()
        }, interval)
    });
    $("#weekwise").on('click', function () {
        processRefresh();
        clearInterval(refInterval);
        refInterval = setInterval(function () {
            processRefresh()
        }, interval)
    });
    $("#monthwise").on('click', function () {
        processRefresh();
        clearInterval(refInterval);
        refInterval = setInterval(function () {
            processRefresh()
        }, interval)
    });


    ////*************************************************  Timeline chart  **********************************************//
    //var getCall = new ApiGet(`/GetProcessPerformance?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetProcessPerformance', result)
    //    $('#plant-machine-desc').html(' ')
    //    for (var i = 0; i < result.length; i++) {


    //      showOper_Timechart(result[i],FromDate,ToDate)

    //    }

    //});
    //getCall.call();

    





    ////characteristics table

    //var getCall = new ApiGet(`/getCharacteristicsinfo?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('getCharacteristicsinfo', result)
    //    var data = result;
    //    console.log("characteristics table" + data);

    //    $('#characteristics_table').html(' ')
    //    if (data.length > 0) {
    //    for (i = 0; i < data.length; i++) {
    //        char_table(data[i])

    //    }
    //        GetChar_Chart(data[0].part, data[0].char_id);
    //    }
    //});
    //getCall.call();
  

    ////************************************************ for Guage **************************************************** */
    //var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetAllPartSummary', result)
    //    guage_Chart(result[0]);
    //});
    //getCall.call();
  
    ////************************************************ for PieChart **************************************************** */
    //var getCall = new ApiGet(`/GetPartSummary?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetPartSummary', result)
    //    PieChart(result[0]);
    //});
    //getCall.call();

  

    ////************************************************ for capsule **************************************************** */

    //var getCall = new ApiGet(`/GetOperationListWithFTT?TEWERKSTATT=${TEWERKSTATT}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetOperationListWithFTT', result)
    //    $('#machine-layout').html(' ');
    //    for (var i = 0; i < result.length; i++) {
    //        showAlarm(result[i], i);
    //    }
    //});
    //getCall.call();

  
    //$("#daywise").on('click', function () {
    //    PageRefresh();
    //});
    //$("#weekwise").on('click', function () {

    //    PageRefresh();
    //});
    //$("#monthwise").on('click', function () {
    //    PageRefresh();
    //});



});


function showOper_Timechart(obj,FromDate,ToDate) {
    var mytimeline = `
  <tr>
  <td class="text-align-center"> <div class="oper_desc">${obj.operation}</div>
    <div class=" timelineChart text-center" id="timeline-chart${obj.sr_no}"></div>
  </td>
  <td class="align-items-center"><div class="desc_statustotal text-center">${obj.total}</div></td>
  <td class="align-items-center"><div class="desc_statusok text-center">${obj.ok}</div></td>
  <td class="align-items-center"><div class="desc_statusnotok text-center">${obj.rework}</div></td>
 
</tr>`

    $('#plant-machine-desc').append(mytimeline)

    var FromDate = FromDate;
    var ToDate = ToDate;
    var index = obj.sr_no;
    var oper = obj.operation;

    var getCall = new ApiGet(`/GetOperationPartStatus?TEWERKSTATT=${obj.line}&TEARBEITSGANG=${obj.operation}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetOperationPartStatus', result)
        Quality_StackChart(result, index, oper, true);
    });
    getCall.call();

}

function processRefresh() {
    //var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
    //var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    var Date = getDateValue();
    var FromDate = Date.FromDate;
    var ToDate = Date.ToDate;
    clearInterval(refInterval);
    var type = $('li.date-selection.current a').html();
    SetLocal_Data(FromDate, ToDate, type);
    PageRefresh(FromDate, ToDate);

    //window.clearInterval(refInterval);

}
function PageRefresh(fDate, tDate) {
    var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
    var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    var FromDate = fDate;
    var ToDate = tDate;



    //*************************************************  Timeline chart  **********************************************//
    var getCall = new ApiGet(`/GetProcessPerformance?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        $('#plant-machine-desc').html(' ')
        console.log('GetProcessPerformance', result)
        for (var i = 0; i < result.length; i++) {

          showOper_Timechart(result[i],FromDate,ToDate)

  

        }

    });
    getCall.call();

    function showOper_Timechart(obj,fdate, tdate) {
        var mytimeline = `
         <tr>
  <td class="text-align-center"> <div class="oper_desc">${obj.operation}</div>
    <div class=" timelineChart text-center" id="timeline-chart${obj.sr_no}"></div>
  </td>
  <td class="align-items-center"><div class="desc_statustotal text-center">${obj.total}</div></td>
  <td class="align-items-center"><div class="desc_statusok text-center">${obj.ok}</div></td>
 
</tr>
 `
 //<td class="align-items-center"><div class="desc_statusnotok text-center">${obj.rework}</div></td>
          //  < td class="align-items-center pt-4" > <span class='mt-2'>-</span> </td >

        $('#plant-machine-desc').append(mytimeline)

           

        var FromDate = fdate;
        var ToDate = tdate;
        var index = obj.sr_no;
        var oper = obj.operation;

        var getCall = new ApiGet(`/GetOperationPartStatus?TEWERKSTATT=${obj.line}&TEARBEITSGANG=${obj.operation}&FromDate=${FromDate}&ToDate=${ToDate}`);
        getCall.onSuccess = (function onSuccess(result) {
            console.log('GetOperationPartStatus', result)
            Quality_StackChart(result, index, oper, true);
        });
        getCall.call();
      
    }


    


    //characteristics table

    var getCall = new ApiGet(`/getCharacteristicsinfo?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('getCharacteristicsinfo', result)
        var data = [...result];
        console.log("characteristics table" + data);
        $('#characteristics_table').html(' ')
        if (result.length > 0) {
            for (i = 0; i < data.length; i++) {
                char_table(data[i])

            }
            GetChar_Chart(data[0].part, data[0].char_id);
            PieChart_summary(data[0].char_name);
            
        }
    });
    getCall.call();

    //************************************************ for Guage **************************************************** */
    var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetAllPartSummary', result)
        guage_Chart(result[0]);
    });
    getCall.call();


    //************************************************ for PieChart **************************************************** */
    //function PieChart_summary(char_name) {
    //    var getCall = new ApiGet(`/GetPartSummary?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}&MEMERKBEZ=${char_name}`);
    //    getCall.onSuccess = (function onSuccess(result) {
    //        console.log('GetPartSummary', result)
    //        PieChart(result[0]);
    //    });
    //    getCall.call();
    //}



    //var getCall = new ApiGet(`/GetPartSummary?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}&MEMERKBEZ=WELCH PLUGE DIA`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetPartSummary', result)
    //    PieChart(result[0]);
    //});
    //getCall.call();

    //************************************************ for capsule **************************************************** */

    var getCall = new ApiGet(`/GetOperationListWithFTT?TEWERKSTATT=${TEWERKSTATT}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        $('#machine-layout').html(' ');
        console.log('GetOperationListWithFTT', result)
        for (var i = 0; i < result.length; i++) {
            showAlarm(result[i], i);
        }
    });
    getCall.call();







}

  


