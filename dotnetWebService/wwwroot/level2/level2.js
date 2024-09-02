$(document).ready(function () {



    var data = [
        { line_name: "line-1", char_name: "line1-OP10", char_status: { total: 40, ok: 20, nok: 20 } },
        { line_name: "line-2", char_name: "line2-OP20", char_status: { total: 60, ok: 40, nok: 20 } },
        { line_name: "line-3", char_name: "line3-OP30", char_status: { total: 90, ok: 83, nok: 7 } },
        { line_name: "line-4", char_name: "line4-OP40", char_status: { total: 20, ok: 11, nok: 9 } },
        { line_name: "line-5", char_name: "line5-OP50", char_status: { total: 27, ok: 20, nok: 7 } },
        { line_name: "line-6", char_name: "line6-OP60", char_status: { total: 46, ok: 40, nok: 6 } },
        { line_name: "line-7", char_name: "line7-OP70", char_status: { total: 66, ok: 66, nok: 0 } },
        { line_name: "line-8", char_name: "line8-OP80", char_status: { total: 89, ok: 80, nok: 9 } },
    ]

    for (var i = 0; i < 8; i++) {

        var obj = {
            line_name: data[i].line_name,
            char_name: data[i].char_name,
            char_status: data[i].char_status,
        }

        showData(obj);
    }

    function showData(obj) {

        //display Guage chart
        var myvar = '<div class="col-sm-3"><a href="../LineTrace_Dash/index.html"><div class="chartClass" id="chart-container' + i + '"></div> </a></div> '

        $("#divChart").append(myvar)
        //Guage Chart starting
        var dom = document.getElementById('chart-container' + i);
        var myChart = echarts.init(dom, {
            renderer: 'canvas',
            useDirtyRect: false
        });
        var app = {};

        var option;

        option = {
            series: [
                {
                    type: 'gauge',
                    startAngle: 180,
                    endAngle: 0,
                    center: ['50%', '75%'],
                    radius: '90%',
                    min: 0,
                    max: 1,
                    splitNumber: 8,
                    axisLine: {
                        lineStyle: {
                            width: 6,
                            color: [
                                [0.5, '#367E18'],
                                [1, '#FF0303']
                            ]
                        }
                    },
                    pointer: {
                        icon: 'path://M12.8,0.7l12,40.1H0.7L12.8,0.7z',
                        length: '12%',
                        width: 20,
                        offsetCenter: [0, '-60%'],
                        itemStyle: {
                            color: 'inherit'
                        }
                    },
                    axisTick: {
                        show: false,

                    },
                    splitLine: {
                        length: 20,
                        lineStyle: {
                            color: 'inherit',
                            width: 5
                        }
                    },
                    axisLabel: {
                        show: false,

                    },
                    title: {
                        offsetCenter: [0, '-10%'],
                        fontSize: 12
                    },
                    detail: {
                        fontSize: 12,
                        offsetCenter: [0, '-35%'],
                        valueAnimation: true,
                        formatter: function (value) {
                            return Math.round(value * 100) + '';
                        },
                        color: 'inherit'
                    },
                    data: [
                        {
                            value: Math.random(),
                            name: obj.line_name
                        }
                    ]
                }
            ]
        };

        if (option && typeof option === 'object') {
            myChart.setOption(option);
        }

        window.addEventListener('resize', myChart.resize);

        //guage chart  end

        //Display Top Characteristics
        var mychar = ` 
<div class="col-sm-3 pt-4 ">
<a href="../oper_alarm/index.html">
<div class="alarm-head">
    <h5>${obj.char_name}</h5>
</div>
<div class="alarm-char"><span>characteristics</span></div>
<div class="alarmstatus">
    <span class="statustotal">Total-${obj.char_status.total}</span> <span class="statusok">Ok-${obj.char_status.ok}</span><span
        class="statusnotok">Not ok-${obj.char_status.nok}</span>
</div>
</a>
</div>
`
        $("#characteristics").append(mychar)



    }

});






