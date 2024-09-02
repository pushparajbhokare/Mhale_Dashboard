var chartDom1 = document.getElementById('Line1Stat');
var chartDom2 = document.getElementById('Line2Stat');
var myChart1 = echarts.init(chartDom1);
var myChart2 = echarts.init(chartDom2);
var optionChart;

optionChart = {
  series: [
    {
      type: 'gauge',
      min : 0,
      max: 150,
      axisLine: {
        lineStyle: {
          width: 30,
          color: [
            [0.5, '#008450'],
            [0.7, '#EFB700'],
            [1, '#B81D13']
          ]
        }
      },
      pointer: {
        itemStyle: {
          color: 'inherit'
        }
      },
      axisTick: {
        distance: -30,
        length: 8,
        lineStyle: {
          color: '#fff',
          width: 2
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
        distance: 40,
        fontSize: 20
      },
      detail: {
        valueAnimation: true,
        formatter: '{value} % PIST',
        color: 'inherit'
      },
      data: [
        {
          value: 1.4
        }
      ]
    }
  ]
};
setInterval(function () {
  myChart1.setOption({
    series: [
      {
        data: [
          {
            value: +(75+(Math.random() * 50)).toFixed(2)
          }
        ]
      }
    ]
  });
}, 2000);

optionChart && myChart1.setOption(optionChart);
optionChart && myChart2.setOption(optionChart);