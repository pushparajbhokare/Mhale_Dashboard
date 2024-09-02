$(document)
    .ajaxStart(function () {
        $('#AjaxLoader').show();
    })
    .ajaxStop(function () {
        $('#AjaxLoader').hide();
    });

$(document).ready(function () {
    //*********************************Date filters ******************************/
    (function ($) {
        $('.tab ul.tabs').addClass('active').find('> li:eq(3)').addClass('current');

        $('.tab ul.tabs li a').click(function (g) {
            var tab = $(this).closest('.tab'),
                index = $(this).closest('li').index();

            tab.find('ul.tabs > li').removeClass('current');
            $(this).closest('li').addClass('current');


            g.preventDefault();
        });


    })(jQuery);

    $('#FromDate').datepicker({
        dateFormat: 'dd/mm/yy',
        onSelect: function (dateText, inst) {

            $('#ToDate').datepicker('option', 'minDate', new Date(dateText));
        }
    });
    $('#ToDate').datepicker({
        dateFormat: 'dd/mm/yy',
        onSelect: function (dateText, inst) {
            $('#FromDate').datepicker('option', 'maxDate', new Date(dateText));
        }
    });


    $("li.date-selection").click(function () {
        getFromDate($(this).find('a').html());
    });



    getFromDate('Custom')



});




var chartdata;

function getQueryStringValue(key) {
    return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}

function getIntervalTime() {
    let sec = 0;
    $.ajax({
        async: false,
        url: `/GetRefreshInterval`,
        type: 'get',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result)
            sec = result;
        },
        complete: function (result) {
            sec = result;
        },
        error: function (errormessage) {
            //
        }
    });

    return sec;

    //var getCall = new ApiGet(`/GetRefreshInterval`);
    //getCall.onComplete = (function onComplete(result) {
    //    alert(result);
    //    sec = result;
    //    //console.log('GetRefreshInterval', result)
    //});
    //getCall.call();
}

function linkWO(line, oper, FromDate, ToDate) {
    console.log('event Trigger')
    var url = "../oper_alarm/index.html?TEWERKSTATT=" + line + "&TEARBEITSGANG=" + oper + "&FromDate=" + FromDate + "&ToDate=" + ToDate;
    window.location.href = url;

}

function getFromDate(type) {
    console.log(type);

    $('#FromDate').attr("disabled", "disabled");
    $('#ToDate').attr("disabled", "disabled")

    if (type == '1D') {

        var format1 = moment().format('DD/MM/YYYY');

        $('#FromDate').val(format1);
        $('#ToDate').val(format1);

        var Dates = getDateValue();
        var FromDate = Dates.FromDate;
        var ToDate = Dates.ToDate;



    } else if (type == '1W') {
        var format1 = moment().subtract(6, 'd').format('DD/MM/YYYY');
        var format2 = moment().format('DD/MM/YYYY');

        $('#FromDate').val(format1);
        $('#ToDate').val(format2);
        var Dates = getDateValue();
        var FromDate = Dates.FromDate;
        var ToDate = Dates.ToDate;

        console.log('FromDate', FromDate, '\n ToDate', ToDate)

    } else if (type == '1M') {
        var format1 = moment().subtract(1, 'M').add(1, 'd').format('DD/MM/YYYY');
        var format2 = moment().format('DD/MM/YYYY');

        $('#FromDate').val(format1);
        $('#ToDate').val(format2);
        var Dates = getDateValue();
        var FromDate = Dates.FromDate;
        var ToDate = Dates.ToDate;

        console.log('FromDate', FromDate, '\n ToDate', ToDate)

    } else if (type == 'Custom') {
        $("#FromDate").removeAttr("disabled");
        $("#ToDate").removeAttr("disabled");

    }

}

function getDateValue() {
    //let FromDate = document.getElementById("FromDate").value;
    //let ToDate = document.getElementById("ToDate").value;
    let FromDate = moment(document.getElementById("FromDate").value, 'DD/MM/YYYY').format('MM/DD/YYYY');
    let ToDate = moment(document.getElementById("ToDate").value, 'DD/MM/YYYY').format('MM/DD/YYYY');
    //const date = '26-11-2019';
    return { FromDate, ToDate };
}

function linkFor(line, oper, FromDate, ToDate) {
    console.log('FromDate..., ToDate...');
    console.log(FromDate, ToDate);
    var url = "../characteristics/index.html?TEWERKSTATT=" + line + "&TEARBEITSGANG=" + oper + "&FromDate=" + FromDate + "&ToDate=" + ToDate;
    window.location.href = url;
}

//********************************************* Guage Chart*********************** */
function guage_Chart(obj) {

   
    var nok = (obj == undefined) ? 100 : (Math.trunc(obj.not_ok_per) / 100);


    var dom1 = document.getElementById('guage_chart');
    var myChart = echarts.init(dom1, {
        renderer: 'canvas',
        useDirtyRect: false
    });
    var app = {};

    var option;
    option = {
        series: [
            {
                type: 'gauge',
                axisLine: {
                    lineStyle: {
                        width: 12,
                        color: [

                            [nok, '#f44335'],
                            [1, ' #4caf50']
                        ]
                    }
                },
                pointer: {
                    show: false,
                    itemStyle: {
                        color: 'inherit'
                    }
                },
                axisTick: {
                    distance: -15,
                    length: 8,
                    lineStyle: {
                        color: '#fff',
                        width: 0.5
                    }
                },
                splitLine: {
                    distance: -30,
                    length: 30,
                    lineStyle: {
                        color: '#fff',
                        width: 4
                    }
                },
                axisLabel: {
                    color: 'inherit',
                    distance: 15,
                    fontSize: 12,
                },
                detail: {
                    fontSize: 15,
                    valueAnimation: true,
                    formatter: '{value}%',
                    color: 'inherit'
                },
                data: [
                    {
                        name: obj == undefined ? 'no data found' : obj.line,

                        value: obj == undefined ? 0 : Math.trunc(obj.ok_per),

                        title: {
                            fontWeight: "bold",
                            //lineHeight: 2,
                            fontSize: 14,
                            offsetCenter: ["0", "0"]
                            //color: '#9B728E'
                        }
                    } , {
                        name: obj == undefined ? 'no data found' : obj.part_desc,

                        value: obj == undefined ? 0 : Math.trunc(obj.ok_per),

                        title: {
                            fontWeight: "600",
                            //lineHeight: 2,
                            
                            fontSize: 13,
                            offsetCenter: ["0", "80"],
                            color: '#002060'
                        }
                    }
                ]
                , center: ["50%", "50%"],
                radius: "90%"

            }
        ]
    };
    //option = {
    //    series: [
    //        {
    //            type: 'gauge',
    //            startAngle: 180,
    //            endAngle: 0,
    //            center: ['50%', '75%'],
    //            radius: '90%',
    //            min: 0,
    //            max: 100,
    //            splitNumber: 8,
    //            axisLine: {
    //                lineStyle: {
    //                    width: 6,
    //                    color: [
    //                        //[obj.not_ok_per, 'green'],
    //                        //[obj.ok_per, 'red']
    //                        [0.66, '#f44335'],
    //                        [1, '#4caf50']
    //                    ]
    //                }
    //            },
    //            pointer: {
    //                icon: 'path://M12.8,0.7l12,40.1H0.7L12.8,0.7z',
    //                length: '89%',
    //                width: 8,
    //                offsetCenter: [0, '-5%'],
    //                itemStyle: {
    //                    color: 'inherit'
    //                }
    //            },
    //            axisTick: {

    //                show: false,
    //            },
    //            splitLine: {
    //                length: 20,
    //                lineStyle: {
    //                    color: 'inherit',
    //                    width: 0.25
    //                }
    //            },
    //            axisLabel: {
    //                show: false,
    //            },
    //            title: {
    //                offsetCenter: [0, '25%'],
    //                fontSize: 13
    //            },
    //            detail: {
    //                fontSize: 12,
    //                offsetCenter: [0, '-35%'],
    //                valueAnimation: true,
    //                formatter: function (value) {
    //                    return value;
    //                },
    //                color: 'inherit'
    //            },
    //            data: [
    //                {
    //                    value: obj == undefined ? 0 : Math.trunc(obj.ok_per),
    //                    name: obj == undefined ? 'no data found' : obj.line + "  " + obj.part_desc + " " + Math.trunc(obj.ok_per) + "%"

    //                }
    //            ]
    //        }
    //    ]
    //};


    if (option && typeof option === 'object') {
        myChart.setOption(option);
    }

    window.addEventListener('resize', myChart.resize);


}



//************************************Show Alarm(Capsule)***************************************** *//
function showAlarm(obj, index) {
    var op_status = obj.op_status
    var Date = getDateValue();
    var FromDate = Date.FromDate;
    var ToDate = Date.ToDate;

    var myvar = `<a href="#" onclick="linkFor('${obj.line}','${obj.operation}','${FromDate}','${ToDate}')">
    <div class="line-layout"><span class="line-machine">${obj.operation}</span>
      <div class="overall-status"></div>
      <div class = "wrap">
          <span class="split-green" title="${obj.accepted}" style="width:${obj.accepted_per}%;">${obj.accepted}</span>
          <span class="split-yellow" title="${obj.warning}" style="width:${obj.warning_per}%;">${obj.warning}</span>
          <span class="split-red"  title="${obj.rejected}" style="width:${obj.rejected_per}%;">${obj.rejected}</span>
        </div>
  </div>
</a>
  `
    $("#machine-layout").append(myvar);

    // write your code here

    var op_status_ele = $('.overall-status')[index];

    if (op_status == "REJECTED") {
        $(op_status_ele).css("background-color", "#f44335");
    } else
        if (op_status == "WARNING") {
            $(op_status_ele).css("background-color", "#fb8c00");
        }
        else {
            $(op_status_ele).css("background-color", "#4caf50");
        }
}

// *************************************** pie Chart **********************************************\\
function PieChart_summary(char_name) {
    var TEWERKSTATT = getQueryStringValue('TEWERKSTATT');
    var TEARBEITSGANG = getQueryStringValue('TEARBEITSGANG');
    var FromDate = getQueryStringValue('FromDate');
    var ToDate = getQueryStringValue('ToDate');
    var getCall = new ApiGet(`/GetPartSummary?TEWERKSTATT=${TEWERKSTATT} &TEARBEITSGANG=${TEARBEITSGANG}&FromDate=${FromDate}&ToDate=${ToDate}&MEMERKBEZ=${char_name}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetPartSummary', result)
        PieChart(result[0]);
    });
    getCall.call();
}

function PieChart(obj) {
    //console.log(obj,"objwct")
    
    var dom = document.getElementById('pie-chart-container');
    var myChart = echarts.init(dom, null, {
        renderer: 'canvas',
        useDirtyRect: false
    });
    var app = {};

    var option;
    var colorPalette = ['#4caf50', '#f44335']


    option = {

        tooltip: {
            trigger: 'item'
        },
        legend: {
            orient: 'vertical',
            left: 'left'
        },
        series: [
            {
                name: 'Access From',
                type: 'pie',
                radius: '50%',
                cursor: "auto",
                data: [
                    { value: obj == undefined ? null : obj.ok, name: 'OK' },
                    { value: obj == undefined ? null : obj.not_ok, name: 'Not Ok' },

                ],
                label: {
                    position: 'inner',
                    fontSize: 10,
                    formatter: function (val) {
                        console
                        return val.percent + '% (' + val.data.value + ')';
                    }
                },


                emphasis: {
                    itemStyle: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    },
                },
                color: colorPalette,
            },
        ],


    };

    if (option && typeof option === 'object') {
        myChart.setOption(option);
    }
    //  if (obj == undefined)
    //? $('#pie-chart-container').

    window.addEventListener('resize', myChart.resize);




}


// ***************************************  time Chart **********************************************\\
function GetBarColor(status) {
    switch (status) {
        case 'ACCEPTED':
            return '#4caf50';
            break;
        case 'REJECTED':
            return '#f44335';
            break;
        case 'WARNING':
            return '#fb8c00';
            break;
    }

}


function showTimechart(obj, FromDate, ToDate) {
    var mytimeline = `
  <tr  onclick="LinkFor_char('${obj.line}','${obj.operation}', '${FromDate}','${ToDate}')"  style="cursor: pointer;">
  <td class="text-align-center"> <a href="#""><div class="oper_desc">${obj.operation}</div>
    <div class=" timelineChart text-center" id="timeline-chart${obj.sr_no}"></div></a>
  </td>
  <td class="align-items-center"><div class="desc_statustotal text-center">Total-${obj.total}</div></td>
  <td class="align-items-center"><div class="desc_statusok text-center">OK-${obj.ok}</div></td>
  <td class="align-items-center"> <div class="desc_statusnotok text-center">NOK-${obj.rework}</div></td>
 
</tr>`

    //
    //    <td class="align-items-center"><div class="desc_statustotal text-center">${obj.ftt}</div> </td>
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

function Quality_StackChart(obj, index, oper, showYAxis) {
    var barseries = [];

    $.each(obj, function (key, item) {
        var dataitem = [];
        dataitem.push(item.count);
        var series =
        {
            name: item.model,
            type: "bar",
            stack: "count",
            label: {
                show: false
            },
            emphasis: {
                focus: "series"
            },
            data: dataitem,
            itemStyle: {
                color: GetBarColor(item.status),
                borderWidth: 0.5,
                borderColor: '#fff'
            },
        };
        barseries.push(series);
    });

    console.log(barseries);


    // GetOperationPartStatus
    var dom = document.getElementById(`timeline-chart${index}`);
    var myChart = echarts.init(dom, null, {
        renderer: "svg",
        useDirtyRect: false
    });



    var app = {};
    var option;

    option = {
        tooltip: {
            position: 'top',
            confine: true,
            extraCssText: 'z-index:1000',
            textStyle: {
                overflow: 'breakAll',
                width: 40,
                fontSize: 10,
                height: 2,
            },
            formatter: function (params) {
                return params.marker + params.seriesName ;

            },
            axisPointer: {
                // Use axis to trigger tooltip
                type: "shadow" // 'shadow' as default; can also be 'line' or 'shadow'
            },
        },

        // legend: {},
        grid: {
            height: 60,
            left: 100,
            top: 0,
            right: 0,
            bottom: 0,
            containLabel: false
        },
        xAxis: {
            type: "value",
            show: false
        },
        yAxis: {
            type: "category",
            data: [oper],
            show: showYAxis
        },
        series: barseries,
    };

    if (option && typeof option === "object") {
        myChart.setOption(option);
    }

    window.addEventListener("resize", myChart.resize);
}

// ***************************************  Characteristic Table **********************************************\\
function char_table(val) {
    //PieChart_summary('${val.char_name}');
    var htmltable = `<tr style="cursor:pointer;" onclick="GetChar_Chart(${val.part},${val.char_id});">
                                    <td>${val.char_id}</td>
                                    <td>${val.char_name}</td>
                                    <td class="text-center">${getClassification(val.mclass)}</td>
                                </tr>`;
    $('#characteristics_table').append(htmltable);


}
//function onChartChange(val) {

//}
function GetChar_Chart(part, char_id) {

    var getCall = new ApiGet(`/GetCharCharts?partList=&partID=${part}&charID=${char_id}`);
    getCall.onSuccess = (function onSuccess(result) {
        console.log('GetCharCharts', result)
        chartdata = result;
        console.log(chartdata);
        Show_CharChart();
    });
    getCall.call();


}


//*************************************** Base64 Image Converter ******************************//
function Base_Converter(base64) {
    'use strict';

    function fixBinary(bin) {
        var length = bin.length;
        var buf = new ArrayBuffer(length);
        var arr = new Uint8Array(buf);
        for (var i = 0; i < length; i++) {
            arr[i] = bin.charCodeAt(i);
        }
        return buf;
    }

    var display = document.getElementById('display');
    display.innerHTML = (display.innerHTML || '');
    function log(text) {
        display.innerHTML += "\n" + text;
    }

    var binary = fixBinary(atob(base64));
    var blob = new Blob([binary], { type: 'image/jpeg' });
    var url = URL.createObjectURL(blob);
    $("display").html('');
    $("#display").html($('<img>').attr('src', url));



    var xhr = new XMLHttpRequest();
    xhr.open('GET', url);
    xhr.responseType = 'arraybuffer';
    xhr.onreadystatechange = function () {
        if (xhr.readyState !== 4) {
            return;
        }

        var returnedBlob = new Blob([xhr.response], { type: 'image/png' });
        var reader = new FileReader();
        reader.onload = function (e) {
            var returnedURL = e.target.result;
            var returnedBase64 = returnedURL.replace(/^[^,]+,/, '');

        };
        reader.readAsDataURL(blob); //Convert the blob from clipboard to base64
    };
    xhr.send();
}

function Show_CharChart() {
    //$('#value_chart').click(function () {
    if ($('#value_chart').is(':checked')) {
        Base_Converter(chartdata.valueChartImg)
    }
    //});

    //$('#qcc_chart').click(function () {
    if ($('#qcc_chart').is(':checked')) {
        Base_Converter(chartdata.qccChartImg)
    }
    //});
    //$('#histo_chart').click(function () {
    if ($('#histo_chart').is(':checked')) {
        Base_Converter(chartdata.histChartImg)
    }
    //});
}
//*********************************Class images******************* */
function getClassification(mclass) {
    if (mclass == 2) {
        return `<img title="" class="display" src="../img/emptyCircle.svg" />`;
    }
    else if (mclass == 3) {
        return '<img title="" class="display" src="../img/halfCircle.svg" />';
    }
    else if (mclass == 4) {
        return `<img title="" class="display" src="../img/fullCircle.svg" />`;
    }
    return `<img title="" class="display" src="../img/emptyCircle.svg" />`;
}

//function roundNumber(inputString) {
    //let string = num.toString();
    //var value = Number(num);
    //var res = num.split(".");
    //if (res.length == 1 || (res[1].length > 0)) {

    //    var value = res[0].replace(/[.*+?^${}()#%tnOB|[\]\\]/g, '') + "." + res[1].slice(0, 2); // $& means the whole matched string

    //}
    //return value;
    //var match = inputString.match(/\d+\.\d+/); // Extract the decimal number from the input string
    //if (match) {
    //    var num = parseFloat(match[0]); // Convert the matched string to a floating-point number
    //    var roundedNum = num.toFixed(2); // Round the number to two decimal places
    //    return roundedNum;
    //}
//}
function roundNumberString(num) {
    let value = num.replace(/[*+?^${}()#%tnOB|\[\]\\]/g, '');
    if(value.includes("."))
    {
        let res =value.split(".");
        value = res[0]+"."+res[1].slice(0,2);
    }
    return value;
}
function roundNumber(num) {
    const numericValue = parseFloat(num);

    if (!isNaN(numericValue)) {
        const roundedValue = numericValue.toFixed(2);
        return roundedValue;
    }

    return num; // Return an error message or handle the invalid input case
}
function DashboardRedirect() {
    
    var url = "/Dashboard/index.html?t=1"
    window.location.href = url;
}   

function HomeRedirect(){
    var url = "/Home"
    window.location.href = url;
}



/***************************************** localStorage *******************************************/
function SetLocal_Data(FromDate, ToDate, type) {
    var Dash_Info = {
        FromDate: FromDate,
        ToDate: ToDate,
        type: type,
    }
       
        // var Line_Select={
        //     selected_line: obj
        // }
   console.log(Dash_Info);
    var jsonDash_Info = JSON.stringify(Dash_Info);
    console.log(jsonDash_Info);
    window.localStorage.setItem("Dash_Info", jsonDash_Info);


}

function GetLocal_Data() {
    var getItem = localStorage.getItem("Dash_Info");
    if (getItem) {
        var item = JSON.parse(getItem);
        return item;
    }
    
}
