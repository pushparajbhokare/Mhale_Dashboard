var refInterval;
var interval;
var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');

$(document).ready(function () {
    // var TEWERKSTATT  = getQueryStringValue('TEWERKSTATT');
    //var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    var local_Data = GetLocal_Data()
    var FromDate = local_Data.FromDate;
    var ToDate = local_Data.ToDate;
    console.log('FromDate, ToDate');
    console.log(FromDate, ToDate);
    //let FromDate = moment(document.getElementById("FromDate").value


    $('#FromDate').val(moment(FromDate, 'MM/DD/YYYY').format('DD/MM/YYYY'));
    $('#ToDate').val(moment(ToDate, 'MM/DD/YYYY').format('DD/MM/YYYY'));



    ////*******************Guage Chart************** */



    //var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT =${TEWERKSTATT }&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetAllPartSummary', result)
    //    guage_Chart(result[0]);
    //});
    //getCall.call();



    ////*****************Time Chart ***************/




    //var getCall = new ApiGet(`/GetProcessPerformance?TEWERKSTATT =${TEWERKSTATT } &TEARBEITSGANG=&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetProcessPerformance', result)
    //    for (var i = 0; i < result.length; i++) {
    //        showTimechart(result[i], FromDate, ToDate)
    //    }
    //});
    //getCall.call();



    ////*****************************For Capsule************************************** *//
    //var getCall = new ApiGet(`/GetOperationListWithFTT?TEWERKSTATT =${TEWERKSTATT }&FromDate=${FromDate}&ToDate=${ToDate}`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    console.log('GetOperationListWithFTT', result)
    //    for (var i = 0; i < result.length; i++) {
    //        showAlarm(result[i], i);
    //    }
    //});
    //getCall.call();


    processRefresh();

    Interval_Ajax = getIntervalTime();
    interval = parseInt(Interval_Ajax.responseText);
    console.log(interval)
    var refInterval = setInterval(function () {
        processRefresh()
    }, interval)



    $("#daywise").on('click', function () {
        processRefresh()
        clearInterval(refInterval);
        refInterval = setInterval(function () {
            processRefresh()
        }, interval)
    });
    $("#weekwise").on('click', function () {

        processRefresh()
        clearInterval(refInterval);
        refInterval = setInterval(function () {
            processRefresh()
        }, interval)
    });
    $("#monthwise").on('click', function () {
        processRefresh()
        clearInterval(refInterval);
        refInterval = setInterval(function () {
            processRefresh()
        }, interval)
    });



});

function LinkFor_char(line, oper, FromDate, ToDate) {
    var url = "../oper_alarm/index.html?TEWERKSTATT=" + line + "&TEARBEITSGANG=" + oper + "&FromDate=" + FromDate + "&ToDate=" + ToDate;
    window.location.href = url;

}




function processRefresh() {
    //var TEWERKSTATT  = getQueryStringValue('TEWERKSTATT ');
    //var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    var Date = getDateValue();
    var FromDate = Date.FromDate;
    var ToDate = Date.ToDate;
    var type = $('li.date-selection.current a').html();

    SetLocal_Data(FromDate, ToDate, type);
    //var FromDate = getQueryStringValue('FromDate');
    //var ToDate = getQueryStringValue('ToDate');
    clearInterval(refInterval);
    PageRefresh(FromDate, ToDate);

    //window.clearInterval(refInterval);

}

function PageRefresh(fDate, tDate) {

    var FromDate = fDate;
    var ToDate = tDate;


    //*******************Guage Chart************** */
    var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT=${TEWERKSTATT}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetAllPartSummary', result)
        guage_Chart(result[0]);
    });
    getCall.call();



    //*****************Time Chart ***************/
    var getCall = new ApiGet(`/GetProcessPerformance?TEWERKSTATT=${TEWERKSTATT}&TEARBEITSGANG=&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetProcessPerformance', result)
        $('#plant-machine-desc').html(' ')
        for (var i = 0; i < result.length; i++) {
            showTimechart(result[i], FromDate, ToDate)
        }
    });
    getCall.call();



    //*****************************For Capsule************************************** *//
    var getCall = new ApiGet(`/GetOperationListWithFTT?TEWERKSTATT=${TEWERKSTATT}&FromDate=${FromDate}&ToDate=${ToDate}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetOperationListWithFTT', result)
        $('#machine-layout').html(' ');
        for (var i = 0; i < result.length; i++) {
            showAlarm(result[i], i);
        }
    });
    getCall.call();
}













