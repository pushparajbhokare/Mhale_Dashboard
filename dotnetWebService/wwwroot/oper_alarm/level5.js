var refInterval;
//var refrestInterval;
var interval;

var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
$(document).ready(function () {
    
   
    var FromDate = getQueryStringValue('FromDate');
    var ToDate = getQueryStringValue('ToDate');
    var chartdata = '';
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

     $('#characteristics_table').on('click', 'tr', function (event) {
        $(this).addClass('highlight').siblings().removeClass('highlight');
    });

   

    ////****************Timeline*********************************//

    //var getCall = new ApiGet(`/GetProcessPerformance?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetProcessPerformance', result)
    //    $('#plant-machine-desc').html(' ')
    //    for (var i = 0; i < result.length; i++) {

    //        showOperationData(result[i], FromDate,ToDate)

    //    }

    //});
    //getCall.call();

    
    ////**********************************pie chart***********************//
    //var getCall = new ApiGet(`/GetPartSummary?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetPartSummary', result)
    //    PieChart(result[0]);
    //});
    //getCall.call();

    
    ////************************characteristics table*******************//
    //var getCall = new ApiGet(`/GetCharacteristicsInfo?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetCharacteristicsInfo', result)
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

    ////********************Guage******************************//


    //var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT=${TEWERKSTATT } &TEARBEITSGANG=${ TEARBEITSGANG}&FromDate=${ FromDate }&ToDate=${ ToDate}` );
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetAllPartSummary', result)
    //    guage_Chart(result[0]);
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


//************************* Timeline chart for level 5******************************/

function showOperationData(obj,FromDate,ToDate) {
    var mytimeline = `
  <tr>
  <td><div class="desc_statustotal text-center mt-2">${obj.operation}</div>

    <div class=" timelineChart text-center" id="timeline-chart${obj.sr_no}"></div>
  </td>
  <td class="align-items-center"><div class="desc_statustotal text-center mt-2 px-0">Total-${obj.total}</div></td>
  <td class="align-items-center"><div class="desc_statusok text-center mt-2 px-0">OK-${obj.ok}</div></td>
  <td class="align-items-center"><div class="desc_statusnotok text-center mt-2 px-0">NOK-${obj.rework}</div></td>
</tr>`

    $('#plant-machine-desc').append(mytimeline)

    var FromDate = FromDate;
    var ToDate = ToDate;
    var index = obj.sr_no;
    var oper = obj.operation;



    var getCall = new ApiGet(`/GetOperationPartStatus?TEWERKSTATT=${obj.line}&TEARBEITSGANG=${obj.operation}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetOperationPartStatus', result)
        Quality_StackChart(result, index, oper, false);
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


function PageRefresh(fDate,tDate) {
    //var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
   
    //var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    var Date = getDateValue();
    var FromDate = fDate;   
    var ToDate = tDate;

    console.log('TEWERKSTATT', TEWERKSTATT);
    //****************Timeline*********************************//

    var getCall = new ApiGet(`/GetProcessPerformance?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetProcessPerformance', result)
        $('#plant-machine-desc').html(' ')

        for (var i = 0; i < result.length; i++) {

            showOperationData(result[i],FromDate, ToDate)

        }

    });
    getCall.call();


    //**********************************pie chart***********************//
    //var getCall = new ApiGet(`/GetPartSummary?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetPartSummary', result)
    //    PieChart(result[0]);
    //});
    //getCall.call();


    //************************characteristics table*******************//
    var getCall = new ApiGet(`/GetCharacteristicsInfo?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetCharacteristicsInfo', result)
        var data = result ;
        console.log("characteristics table" + data);
        $('#characteristics_table').html(' ')
        if (data.length > 0) {
            for (i = 0; i < data.length; i++) {
                char_table(data[i])

            }
            GetChar_Chart(data[0].part, data[0].char_id);
    $($('#characteristics_table tr')[0]).click();

        }
    });
    getCall.call();



    //********************Guage******************************//


    var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetAllPartSummary', result)
        guage_Chart(result[0]);
    });
    getCall.call();




}


//************************* Timeline chart for level 5******************************/

function showOperationData(obj, FromDate, ToDate) {
    console.log('object', obj)
    var mytimeline = `
  <tr>
  <td ><div class="desc_statustotal text-center mt-0 py-0">${obj.operation}</div></td>
  <td class="text-align-center py-0"> 
    <div class=" timelineChart text-center " id="timeline-chart${obj.sr_no}"></div>
  </td>
  <td class="align-items-center"><div class="desc_statustotal text-center mt-0 py-0">Total-${obj.total}</div></td>
  <td class="align-items-center"><div class="desc_statusok text-center mt-0 py-0">OK-${obj.ok}</div></td>
  <td class="align-items-center"><div class="desc_statusnotok text-center mt-0 py-0">NOK-${obj.rework}</div></td>
</tr>`

    $('#plant-machine-desc').append(mytimeline)

    //var FromDate = '2023-03-08';
    //var ToDate = '2023-03-17';
    var index = obj.sr_no;
    var oper = obj.operation;
    var line = obj.line;
    



    var getCall = new ApiGet(`/GetOperationPartStatus?TEWERKSTATT=${line}&TEARBEITSGANG=${obj.operation}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetOperationPartStatus', result)
        Quality_StackChart(result, index, oper, false);
    });
    getCall.call();
}







