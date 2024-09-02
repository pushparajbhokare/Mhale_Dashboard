var redirectVal = getQueryStringValue("t");
$(document).ready(function () {
  console.log(redirectVal);
  $("#multiple-checkboxes").multiselect({
    allSelectedText: "All",
    includeSelectAllOption: true,
  });
  //   .multiselect('selectAll', false)
  //   .multiselect('updateButtonText');
  //   $('#multiple-checkboxes select option:first-child').prop("selected", true);
  //   $('#multiple-checkboxes').multiselect('refresh');
  if (redirectVal == 1) {
    var Dash_data = GetLocal_Data();
    console.log(Dash_data);
    var type = Dash_data.type;
    console.log("type", type);
    getFromDate(type);
    let z = { "1D": 0, "1W": 1, "1M": 2, Custom: 3 };

    $(".tab ul.tabs").addClass("active").find("li").removeClass("current");
    $(".tab ul.tabs")
      .addClass("active")
      .find(`li:eq(${z[type]})`)
      .addClass("current");

    $("#FromDate").val(
      moment(Dash_data.FromDate, "MM/DD/YYYY").format("DD/MM/YYYY")
    );
    $("#ToDate").val(
      moment(Dash_data.ToDate, "MM/DD/YYYY").format("DD/MM/YYYY")
    );
    PageRefresh();
  } else {
    $(".tab ul.tabs").addClass("active").find("li").removeClass("current");
    $(".tab ul.tabs").addClass("active").find("li:eq(0)").addClass("current");

    var getCall = new ApiGet(`/GetRefreshInterval`);
    getCall.onSuccess = function onSuccess(result) {
      //  Loaddata(result)
      console.log("GetRefreshInterval", result);
    };
    getCall.call();

    getFromDate("1D");
    PageRefresh();
    function Loaddata(sec) {
      var refInterval = window.setInterval("PageRefresh()", sec);
    }
  }

  $("#daywise,#weekwise,#monthwise").on("click", function () {
    PageRefresh();
  });
  //$("#weekwise").on('click', function () {
  //    PageRefresh();
  //});
  //$("#monthwise").on('click', function () {
  //    PageRefresh();
  //});
});
function linkFor_level3(line, FromDate, ToDate) {
    console.log("event Trigger");
    var Date = getDateValue();
    var FromDate = Date.FromDate;
    var ToDate = Date.ToDate;
    var type = $('li.date-selection.current a').html();

    SetLocal_Data(FromDate, ToDate, type);
  var url =
    "../LineTrace_Dash/index.html?TEWERKSTATT=" +
    line +
    "&FromDate=" +
    FromDate +
    "&ToDate=" +
    ToDate;
  window.location.href = url;
}

function PageRefresh() {
  Dates = "";
  var Dates = getDateValue();
  var FromDate = Dates.FromDate;
  var ToDate = Dates.ToDate;
  console.log("FromDate, ToDate");
  console.log(FromDate, ToDate);
  var type = $("li.date-selection.current a").html();
   SetLocal_Data(FromDate, ToDate, type);

  // SetLocal_Data(FromDate, ToDate, type);
  //var TEWERKSTATT  = 'Line 1';
  //var TEARBEITSGANG='OP10'

  //****************GetDashboardSummaryDate*****************/

  var getCall = new ApiGet(
    `/GetDashboardSummaryData?TEWERKSTATT=&FromDate=${FromDate}&ToDate=${ToDate}`
  );
  getCall.onSuccess = function onSuccess(result) {
    console.log("GetDashboardSummaryData", result);
    $("#Production").html(" ");
    $("#Production_ftt").html(" ");
    if (result.length > 0) {
      ProductionSummary(result[0]);
    } else {
      console.log("No data found for this  date range");
    }
  };
  getCall.call();

  //****************Guage Line*****************/Gu

  let randNum = Math.floor(Math.random() * 100);
  var getCall = new ApiGet(
    `/GetAllPartSummary?TEWERKSTATT=&FromDate=${FromDate}&ToDate=${ToDate}&p=${randNum}`
  );
  getCall.onSuccess = function onSuccess(result) {
    console.log("GetAllPartSummary", result);
    $("#divChart").html(" ");
    var getItem = JSON.parse(localStorage.getItem("Line_Select"));
    var line = new Set(result.map((ele) => ele.line));
    console.log("line", line);
    $("#multiple-checkboxes").html("");

    line.forEach((ele, index) => {
      $("#multiple-checkboxes").append(
        `<option value="${ele}" >${ele}</option>`
      );
      $("#multiple-checkboxes").multiselect("rebuild");
    });
    $("#multiple-checkboxes")
      .multiselect({
        allSelectedText: "All",
        includeSelectAllOption: true,
      })
      .multiselect("updateButtonText");
    console.log(getItem);
    if (getItem) {
      // $("#multiple-checkboxes")
      //   .multiselect("selectAll", false)
      //   .multiselect("updateButtonText");
      for (var i in getItem) {
        $("#multiple-checkboxes").val(getItem);
      }
      $("#multiple-checkboxes").multiselect("refresh");
    }else {
      $("#multiple-checkboxes")
        .multiselect("selectAll", false)
        .multiselect("updateButtonText");

      $("#multiple-checkboxes").multiselect("refresh");
    }
    selectedFunction();

    $("#multiple-checkboxes").change(function () {
      $("#divChart").html(" ");

      selectedFunction();
    });
    function selectedFunction() {
      var obj = [];

      var selected_line = $("#multiple-checkboxes").val();
      console.log("Line : ", selected_line);
      selected_line &&
        selected_line.forEach((line, index) => {
          var filterResult = result.filter((ele) => ele.line == line);
          obj.push(...filterResult);

          // showGuageline(result[i]);
        });

      window.localStorage.setItem("Line_Select", JSON.stringify(selected_line));
      console.log(obj);
      for (var i = 0; i < obj.length; i++) {
        showGuageline(obj[i]);
      }
    }
    // if (redirectVal == 1) {
    //   var localResult = GetLocal_Data();

    //   for (var i = 0; i < result.length; i++) {
    //     showGuageline(result[i]);
    //   }
    // }
  };
  getCall.call();

  //**************** Alarm Characteristics ******************* */
  const today = moment().format("MM/DD/YYYY");
  // const today = '06/23/2023'
  var getCall = new ApiGet(
    "/GetDashboardAlarm?TEWERKSTATT=" +
      " " +
      "&FromDate=" +
      today +
      "&ToDate=" +
      today
  );
  getCall.onSuccess = function onSuccess(result) {
    console.log("GetDashboardAlarm", result);
    $("#characteristics").html(" ");
    if (result.length == 0) {
      $("#characteristics").append(`
            <div class="empty-state__content">
                <div class="empty-state__icon">
                    <img src="../img/no_alarmimg.png" />

                 </div>
                <div class="empty-state__message">No Alarms</div>
            </div>
                `);
    } else {
      for (var i = 0; i < result.length; i++) {
        showAlarmChar(result[i]);
      }
    }
  };
  getCall.call();
  //***************************************** show Guage chart **********************************************//

  function showGuageline(data) {
    var myvar = `
        <div class="row align-items-center" ><div class="col-sm-4" ><a href="#"  onclick="linkFor_level3('${data.line}','${FromDate}','${ToDate}');">
    
        <div class="chartClass" style="cursor:pointer !important;"  id="chart-container${data.sr_no}"></div>
       
       </a></div>
        <div  class="col-sm-8"> <div class="row align-items-center line-status-container" id="machine-line-id${data.sr_no}"></div></div></div>`;

    //<span style="display: flex; justify-content: center;">${data.line}</span>
    $("#divChart").append(myvar);
    guageChart(data);
    var index = data.sr_no;

    var getCall = new ApiGet(
      `/GetOperationListWithFTT?TEWERKSTATT=${data.line}&FromDate=${FromDate}&ToDate=${ToDate}`
    );
    getCall.onSuccess = function onSuccess(result) {
      console.log("GetOperationListWithFTT", result);
      $(`#machine-line-id${index}`).html("");
      for (var i = 0; i < result.length; i++) {
        display_alarm(result[i], index, i);
      }
    };
    getCall.call();
  }

  function ProductionSummary(val) {
    var production_data = ` <tr>
                                      <td>${val.hourproduction}</td>
                                    <td>${val.dayproduction}</td>
                                    <td>${val.weekproduction}</td>
                                </tr>`;

    $(`#Production`).append(production_data);
    var ftt_data = ` <tr>
                                    <td>${roundNumber(val.ftt, 4)}</td>
                                    <td>${roundNumber(val.reworkppm, 4)}</td>
                                    <td>${roundNumber(val.rejectionppm, 4)}</td>
                                </tr>`;

    $(`#Production_ftt`).append(ftt_data);
  }

  function display_alarm(obj, index, i) {
    var machine_linedata = `
        <div class="col-sm-4">
        <a href="#" onclick="linkFor('${obj.line}','${obj.operation}','${FromDate}','${ToDate}')">
                <div class="line-layout"><span class="line-machine">${obj.operation}</span>
                 <div   class="overall-status"></div>
                  <div class = "wrap">
                              <span class="split-green" title="${obj.accepted}" style="width:${obj.accepted_per}%;">${obj.accepted}</span>
                              <span class="split-yellow" title="${obj.warning}" style="width:${obj.warning_per}%;">${obj.warning}</span>
                              <span class="split-red"  title="${obj.rejected}" style="width:${obj.rejected_per}%;">${obj.rejected}</span>
                    </div>
              </div>
</a>
</div>
  `;

    $(`#machine-line-id${index}`).append(machine_linedata);

    //var op_status_ele = $('.overall-status')[i];
    var op_status_ele = $(`#machine-line-id${index}`).find(".overall-status")[
      i
    ];

    var op_status = obj.op_status;

    if (op_status == "REJECTED") {
      $(op_status_ele).css("background-color", "#f44335");
    } else if (op_status == "WARNING") {
      $(op_status_ele).css("background-color", "#fb8c00");
    } else {
      $(op_status_ele).css("background-color", "#4caf50");
    }
  }

  //*************************************Guage Chart *********************************************//

  function guageChart(obj) {
    //Guage chart Starting
    var dom = document.getElementById("chart-container" + obj.sr_no);
    var myChart = echarts.init(dom, {
      renderer: "svg",
      useDirtyRect: false,
    });

    $(dom).attr("guage_chart_sr_no", obj.sr_no);
    var nok = obj == undefined ? 100 : Math.trunc(obj.not_ok_per) / 100;

    var app = {};
    var option;

    option = {
      series: [
        {
          type: "gauge",
          axisLine: {
            lineStyle: {
              width: 12,
              color: [
                [nok, "#f44335"],
                [1, " #4caf50"],
              ],
            },
          },
          pointer: {
            show: false,
            itemStyle: {
              color: "inherit",
            },
          },
          axisTick: {
            distance: -15,
            length: 8,
            lineStyle: {
              color: "#fff",
              width: 0.5,
            },
          },
          splitLine: {
            distance: -30,
            length: 30,
            lineStyle: {
              color: "#fff",
              width: 4,
            },
          },
          axisLabel: {
            color: "inherit",
            distance: 15,
            fontSize: 12,
          },
          detail: {
            fontSize: 15,
            valueAnimation: true,
            formatter: "{value}%",
            color: "inherit",
          },
          data: [
            {
              name: obj == undefined ? "no data found" : obj.line,

              value: obj == undefined ? 0 : Math.trunc(obj.ok_per),

              title: {
                fontWeight: "bold",
                //lineHeight: 2,
                fontSize: 14,
                offsetCenter: ["0", "0"],
                //color: '#9B728E'
              },
            },
            {
              name: obj == undefined ? "no data found" : obj.part_desc,

              value: obj == undefined ? 0 : Math.trunc(obj.ok_per),

              title: {
                fontWeight: "600",
                //lineHeight: 2,

                fontSize: 13,
                offsetCenter: ["0", "80"],
                color: "#002060",
              },
            },
          ],
          center: ["50%", "50%"],
          radius: "90%",
        },
      ],
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
    //                    value: Math.trunc(obj.ok_per),

    //                    name:truncate(obj.line + "  " + (obj.part_desc || '') + " " + Math.trunc(obj.ok_per) + "%"),

    //                }
    //            ]
    //        }
    //    ]

    //};

    if (option && typeof option === "object") {
      myChart.setOption(option);
    }
    window.addEventListener("resize", myChart.resize);

    // Guage chart End
  }

  function truncate(string) {
    if (string.length > 10) return string.substring(0, 10) + "...";
    else return string;
  }

  //***************************************** show Characteristics **********************************************//

  function showAlarmChar(data) {
    //<a href="#" style="width:100%;" onclick="linkWO('${data.line}','${data.operation}','${FromDate}','${ToDate}');" > </a>
    const today = moment().format("MM/DD/YYYY");
    // const today='06/23/2023'

    var mychar = ` 
            
        <div class="row align-items-center" >
          

 <div class="col-sm-12 py-3 border border-secondary" onclick="GetAlarmDetails('${data.line}','${today}')"  data-toggle="modal" data-target="#exampleModal" style="cursor: pointer;">
      <div class="alarm-head" data-bs-toggle="modal">
          <h5>${data.line}</h5>
      </div>
      <div class="alarm-char" hidden><span>characteristics</span></div>
      <div class="alarmstatus" style="width:100%;">
         
          <span class="statusok">OK-${data.ok}</span>
          <span class="statusnotok">NOK-${data.not_ok}</span>
      </div>
  </div>
</div>
`;
    //< span class="statustotal" > Total - ${ data.total }</span >

    $("#characteristics").append(mychar);
  }
}
function GetAlarmDetails(line, date) {
  var getCall = new ApiGet(
    `/GetAlarmDetails?TEWERKSTATT=${line}&FromDate=${date}&ToDate=${date}`
  );
  getCall.onSuccess = function onSuccess(result) {
    console.log("GetAlarmDetails", result);
    $("#detail_characteristics").html("");
    var color = {
      ACCEPTED: "var(--green)",
      WARNING: "var(--yellow)",
      REJECTED: "var(--red)",
    };
    for (i in result) {
      var html = `
    <div class="col-sm-12 alarm_details p-2"  style="background-color:${
      color[result[i].status]
    }">
             <div class="d-flex justify-content-around"><span>Line:</span> <span class="detail_chardesc">${
               result[i].line
             }<span></div>
             <div class="d-flex justify-content-around"><span>Part:</span> <span class="detail_chardesc">${
               result[i].part
             }</span></div>
             <div class="d-flex justify-content-around"><span>Char:</span> <span class="detail_chardesc">${
               result[i].characteristics
             }</span></div>
             <div class="d-flex justify-content-around"><span>Alarm:</span> <span class="detail_chardesc">${
               result[i].alarm
             }</span></div>

      </div>
    `;
      $("#detail_characteristics").append(html);
    }
  };
  getCall.call();
}

//console.log(getItem);
