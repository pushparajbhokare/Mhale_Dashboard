
var refInterval;
//var refrestInterval;
var interval;

$(document).ready(function () {
    //var FromDate = getQueryStringValue('FromDate');
    //var ToDate = getQueryStringValue('ToDate');
    var local_Data = GetLocal_Data()
    var FromDate = local_Data.FromDate;
    var ToDate = local_Data.ToDate;
    $('#FromDate').val(moment(FromDate, 'MM/DD/YYYY').format('DD/MM/YYYY'));
    $('#ToDate').val(moment(ToDate, 'MM/DD/YYYY').format('DD/MM/YYYY'));

    processRefresh();

    Interval_Ajax = getIntervalTime();
    interval = parseInt(Interval_Ajax.responseText);
    console.log(interval)
    var refInterval = setInterval(function () {
        processRefresh()
    }, interval)

    //var getCall = new ApiGet(`/GetRefreshInterval`);
    //getCall.onSuccess = (function onSuccess(result) {
    //    Loaddata(result);
    //    console.log('GetRefreshInterval', result);
    //});
    //getCall.call();

    //    function Loaddata(sec) {
    //    interval = sec;
    //        clearInterval(refInterval);

    //        var refInterval = setInterval(function () {
    //            processRefresh()
    //        }, sec)


    //}


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

});

function processRefresh() {
    var Date = getDateValue();
    var FromDate = Date.FromDate;
    var ToDate = Date.ToDate;
    clearInterval(refInterval);
    Refresh(FromDate, ToDate);
    var type = $('li.date-selection.current a').html();
    $('#plant-char-desc').html('')
    SetLocal_Data(FromDate, ToDate, type);
    //window.clearInterval(refInterval);

}

function Refresh(fDate, tDate) {
    clearInterval(refInterval);

    $('#machine-layout').html('')


    var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
    var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    //var Date = getDateValue();
    //var FromDate = Date.FromDate;
    //var ToDate = Date.ToDate;

    var FromDate = fDate;
    var ToDate = tDate;

    //***********************************Operations Characterictics*********************************** */
    //var getCall = new ApiGet(`/GetAllCharacteristicsInfo?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}`);

    var getCall = new ApiGet(`/GetCharDetails?line=${TEWERKSTATT}&operation=${TEARBEITSGANG}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetCharDetails', result)

        $('#plant-char-desc').html('')
        if (result.length > 0) {
            for (i = 0; i < result.length; i++) {
                var id = i;

                showCharacteristic(result[i], FromDate, ToDate, TEWERKSTATT, TEARBEITSGANG)
            }
        }
    });
    getCall.call();


    //*******************************Guage Chart******************** */

    var getCall = new ApiGet(`/GetAllPartSummary?TEWERKSTATT=${TEWERKSTATT} &FromDate=${FromDate}&ToDate=${ToDate}`);

    getCall.onSuccess = (function onSuccess(result) {

        console.log('GetAllPartSummary', result)

        //if (result.length > 0) {

        guage_Chart(result[0]);

        //} else {
        //    $('#guage_chart').html(' ')
        //}
    });
    getCall.call();


    //***************************** Capsules Alarm************************** */
    var getCall = new ApiGet(`/GetOperationListWithFTT?TEWERKSTATT=${TEWERKSTATT}&FromDate=${FromDate}&ToDate=${ToDate}`);

    getCall.onSuccess = (function onSuccess(result) {

        console.log('GetOperationListWithFTT', result)

        for (var i = 0; i < result.length; i++) {
            showAlarm(result[i], i);
        }
    });
    getCall.call();

}

function showCharacteristic(value, FromDate, ToDate,line,oper) {
    var mychar = `
  <tr style="cursor:pointer;" onclick="linkWO('${line}','${oper}','${FromDate}','${ToDate}');" >
  <td class="text-center">${value.parameter}
  </td>
  <td>${value.parameter_desc}</td>
  <td>${oper}</td>
  <td class="text-center">${getClassification(value.mclass)}</td>
  <td class="text-center">${roundNumber(value.xBar)}</td>
   <td class="text-center">${roundNumber(value.range)}</td>
  <td class="text-center">${roundNumber(value.stdDev)}</td>
  <td class="text-center">${roundNumberString(value.potindex)}</td>
  <td class="text-center">${roundNumberString(value.criticalIndex)}</td>
</tr>`


    return $('#plant-char-desc').append(mychar)

}












