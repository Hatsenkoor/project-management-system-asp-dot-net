
$(document).ready(function () {
    GetDashboardAnalysis();
});


function GetDashboardAnalysis() {
    $.ajax(
    {
        type: 'GET',
        url: apiUrl,
        datatype: JSON,
        data: { 'path': 'https://pf.maf.gov.om/pmsdemoapi/mobileapi.ashx?app=11&actn=116&delegateId=19286'},

        success: function (data) {

            var dashboardData = JSON.parse(data);

            var costData = dashboardData.mrmwr.project_remaining_cost;
            drawCostData(costData);

            var riskData = dashboardData.mrmwr.project_risk;
            drawRiskCart(riskData);

            var pendingData = dashboardData.mrmwr.project_completion_pending;
            drawPendingChart(pendingData);

            var cashData = dashboardData.mrmwr.cashflow;
            drawCashCart(cashData);

            var delayData = dashboardData.mrmwr.project_delay;
            drawDelayCart(delayData);

            var amtData = dashboardData.mrmwr.project_ret_amt;
            drawAmtCart(amtData);

            var wiseData = dashboardData.mrmwr.year_wise_project;
            drawWiseCart(wiseData);

            var departData = dashboardData.mrmwr.project_in_department;
            drawDepartCart(departData);

            var paymentData = dashboardData.mrmwr.project_progress_payment;
            drawPaymentTable(paymentData);
        },
        error: function (xhr) {
            alert(xhr.responseText + xhr.statusText);
        }

    });
}

function drawCostData(costData) {
    var data = costData.kpi;

    $('#total_project').text(data[0].Value);
    $('#remain_cost').text(data[1].Value);
}

function drawRiskCart(riskData){
    var data = riskData.doughnut;
    var colors= [];
    var labels=[];
    var values=[];
    for(let i=0;i<data.length;i++){
        colors.push('#'+Math.floor(Math.random()*16777215).toString(16));
        labels.push(data[i].Dir);
        values.push(data[i].Count);
    }

    var canvas = document.getElementById('rishCart');
    new Chart(canvas, {
        type: 'doughnut',    
        data: {
            labels: labels,
            datasets: [{
            data: values,
            backgroundColor: colors
            }]
        },
        options: {
            aspectRatio: 1,
            legend: {
                position: 'bottom',
                labels: {
                    fontSize: 8
                }
            },
            plugins: {                
                labels: {
                    render: function(args){
                        return args.value + '\n' + args.label;
                    },
                    fontColor: 'white'
                }
            }
        }
    });
}

function drawDepartCart(departData){
    var data = departData.pie;
    var colors= [];
    var labels=[];
    var values=[];
    for(let i=0;i<data.length;i++){
        colors.push('#'+Math.floor(Math.random()*16777215).toString(16));
        labels.push(data[i].Label);
        values.push(data[i].Count);
    }

    var canvas = document.getElementById('departCart');
    new Chart(canvas, {
        type: 'doughnut',    
        data: {
            labels: labels,
            datasets: [{
            data: values,
            backgroundColor: colors
            }]
        },
        options: {
            aspectRatio: 1,
            legend: {
                position: 'bottom',
                labels: {
                    fontSize: 8
                }
            },
            plugins: {                
                labels: {
                    render: function(args){
                        return args.value + '\n' + args.label;
                    },
                    fontColor: 'white'
                }
            }
        }
    });
}

function drawPendingChart(pendingData){
    var data = pendingData.bar_chart;
    var pendings = {};
    for(var i=0; i<data.length; i++)
    {
        var key = data[i].Label;
        if(pendings[key] === undefined) {
            pendings[key] = {}
            pendings[key]['key']=key;
        }

        pendings[key][data[i].XAxis] = data[i].Value;
    }

    var keys= Object.keys(pendings);

    var labels=[];
    var data1 =[];
    var data2 =[];
    for(i=0;i<keys.length;i++)
    {
        var row = pendings[keys[i]];

        labels.push(row.key);
        data1.push(row.Completed === undefined ? 0 : row.Completed);
        data2.push(row.Pending === undefined ? 0 : row.Pending);
    }

    var canvas = document.getElementById('pendingChart');
    new Chart(canvas, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Completed',
                backgroundColor: 'orange',
                data: data1
            },{
                label: 'Pending',
                backgroundColor: 'yellow',
                data: data2
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
                xAxes: [{
                    ticks: {
                        fontColor: "red",
                        fontSize: 10,
                        stepSize: 1,
                        beginAtZero: true
                    }
                }]
            },
            legend: {
                position: 'bottom'
            },
            "animation": {
                "duration": 1,
                "onComplete": function() {
                    var chartInstance = this.chart,
                    ctx = chartInstance.ctx;
            
                    ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                    ctx.textAlign = 'center';
                    ctx.textBaseline = 'bottom';
            
                    this.data.datasets.forEach(function(dataset, i) {
                    var meta = chartInstance.controller.getDatasetMeta(i);
                    meta.data.forEach(function(bar, index) {
                        var data = dataset.data[index];
                        ctx.fillText(data, bar._model.x, bar._model.y - 5);
                    });
                    });
                }
            },
            plugins: {
                labels: {
                  render: () => {}
                }
              }
        }
    });
}

function drawDelayCart(delayData){
    var data = delayData.column;
    var pendings = {};
    for(var i=0; i<data.length; i++)
    {
        var key = data[i].XAxis;
        if(pendings[key] === undefined) {
            pendings[key] = {}
            pendings[key]['key']=key;
        }

        pendings[key][data[i].Label] = data[i].Value;
    }

    var keys= Object.keys(pendings);
    var labels=[];
    var dataKeys = [];
    for(i=0;i<keys.length;i++)
    {
        var row = pendings[keys[i]];
        labels.push(row.key);
        var sKeys = Object.keys(row);
        for(j=0;j<sKeys.length;j++)
        {
            var key = sKeys[j];
            if(key!="key" && dataKeys[key] === undefined) {
                dataKeys[key] = {}
                dataKeys[key]['key']=key;
            }
        }
    }

    var keysa= Object.keys(dataKeys);
    var columns = {};
    for(i=0;i<keysa.length;i++)
    {
        var key=keysa[i];
        if(columns[key] === undefined)
        {
            columns[key] = {}
            columns[key]['key']=key;
            columns[key]['data']=[];
        }

        for(j=0;j<keys.length;j++){
            columns[key]['data'].push(pendings[keys[j]][keysa[i]] === undefined ? 0 : pendings[keys[j]][keysa[i]]);
        }
    }

    keys= Object.keys(columns);
    dataSet = [];
    for(i=0;i<keys.length;i++)
    {
        var key = keys[i];
        var color = '#'+Math.floor(Math.random()*16777215).toString(16);
        row = {
            label: key,
            backgroundColor: color,
            data: columns[key]['data']
        }

        dataSet.push(row);
    }

    var canvas = document.getElementById('delayChart');
    new Chart(canvas, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: dataSet
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
                xAxes: [{
                    ticks: {
                        fontSize: 10,
                        stepSize: 1,
                        beginAtZero: true
                    }
                }]
            },
            legend: {
                position: 'bottom'
            },
            "animation": {
                "duration": 1,
                "onComplete": function() {
                    var chartInstance = this.chart,
                    ctx = chartInstance.ctx;
            
                    ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                    ctx.textAlign = 'center';
                    ctx.textBaseline = 'bottom';
            
                    this.data.datasets.forEach(function(dataset, i) {
                    var meta = chartInstance.controller.getDatasetMeta(i);
                    meta.data.forEach(function(bar, index) {
                        var data = dataset.data[index];
                        ctx.fillText(data, bar._model.x, bar._model.y - 5);
                    });
                    });
                }
            },
            plugins: {
                labels: {
                  render: () => {}
                }
              }
        }
    });
}

function drawWiseCart(wiseData){
    var data = wiseData.line_chart;
    var pendings = {};

    for(var i=0; i<data.length; i++)
    {
        var key = data[i].XAxis;
        if(pendings[key] === undefined) {
            pendings[key] = {}
            pendings[key]['key']=key;
        }

        pendings[key][data[i].Label] = data[i].Count;
    }

    var keys= Object.keys(pendings);
    var labels=[];
    var dataKeys = [];
    for(i=0;i<keys.length;i++)
    {
        var row = pendings[keys[i]];
        labels.push(row.key);
        var sKeys = Object.keys(row);
        for(j=0;j<sKeys.length;j++)
        {
            var key = sKeys[j];
            if(key!="key" && dataKeys[key] === undefined) {
                dataKeys[key] = {}
                dataKeys[key]['key']=key;
            }
        }
    }

    var keysa= Object.keys(dataKeys);
    var columns = {};
    for(i=0;i<keysa.length;i++)
    {
        var key=keysa[i];
        if(columns[key] === undefined)
        {
            columns[key] = {}
            columns[key]['key']=key;
            columns[key]['data']=[];
        }

        for(j=0;j<keys.length;j++){
            columns[key]['data'].push(pendings[keys[j]][keysa[i]] === undefined ? 0 : pendings[keys[j]][keysa[i]]);
        }
    }

    keys= Object.keys(columns);
    dataSet = [];
    for(i=0;i<keys.length;i++)
    {
        var key = keys[i];
        var color = '#'+Math.floor(Math.random()*16777215).toString(16);
        row = {
            label: key,
            backgroundColor: color,
            data: columns[key]['data']
        }

        dataSet.push(row);
    }

    var canvas = document.getElementById('wiseCart');
    new Chart(canvas, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: dataSet
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
                xAxes: [{
                    ticks: {
                        fontColor: "red",
                        fontSize: 10,
                        stepSize: 1,
                        beginAtZero: true
                    }
                }]
            },
            legend: {
                position: 'bottom'
            },
            "animation": {
                "duration": 1,
                "onComplete": function() {
                    var chartInstance = this.chart,
                    ctx = chartInstance.ctx;
            
                    ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                    ctx.textAlign = 'center';
                    ctx.textBaseline = 'bottom';
            
                    this.data.datasets.forEach(function(dataset, i) {
                    var meta = chartInstance.controller.getDatasetMeta(i);
                    meta.data.forEach(function(bar, index) {
                        var data = dataset.data[index];
                        ctx.fillText(data, bar._model.x, bar._model.y - 5);
                    });
                    });
                }
            },
            plugins: {
                labels: {
                  render: () => {}
                }
              }
        }
    });
}

function drawCashCart(cashData){
    var data = cashData.area_chart;
    var pendings = {};
    for(var i=0; i<data.length; i++)
    {
        var key = data[i].XAxis;
        if(pendings[key] === undefined) {
            pendings[key] = {}
            pendings[key]['key']=key;
        }

        pendings[key][data[i].Label] = data[i].Value;
    }
    var keys= Object.keys(pendings);
    var labels=[];
    var data1 =[];
    var data2 =[];
    for(i=0;i<keys.length;i++)
    {
        var row = pendings[keys[i]];

        labels.push(row.key);
        data1.push(row['Milestone'] === undefined ? 0 : row['Milestone']);
        data2.push(row['Actual Paid'] === undefined ? 0 : row['Actual Paid']);
    }

    var canvas = document.getElementById('cashChart');
    new Chart(canvas, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Milestone', // Name the series
                data: data1, // Specify the data values array
                fill: true,
                borderColor: 'yellow', // Add custom color border (Line)
                backgroundColor: 'rgba(38, 185, 154, 0.31)', // Add custom color background (Points and Fill)
                borderWidth: 1 // Specify bar border width
            },
                      {
                label: 'Actual Paid', // Name the series
                data: data2, // Specify the data values array
                fill: true,
                borderColor: 'red', // Add custom color border (Line)
                backgroundColor: 'rgba(3, 88, 106, 0.3)', // Add custom color background (Points and Fill)
                borderWidth: 1 // Specify bar border width
            }]
        },
        options: {
            legend: {
                display: false
            },
        }
    });
}

function drawAmtCart(amtData)
{
    var data = amtData.column;

    var labels = [];
    var column = [];
    var colors= [];

    for(var i=0;i<data.length;i++)
    {
        labels.push(data[i].Label);
        column.push(data[i].Value);
        colors.push('#'+Math.floor(Math.random()*16777215).toString(16));
    }

    var canvas = document.getElementById('amtCart');
    new Chart(canvas, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Completed',
                backgroundColor: colors,
                data: column
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }],
                xAxes: [{
                    ticks: {
                        fontSize: 10,
                        stepSize: 1,
                        beginAtZero: true
                    }
                }]
            },
            legend: {
                display: false
            },
            "animation": {
                "duration": 1,
                "onComplete": function() {
                    var chartInstance = this.chart,
                    ctx = chartInstance.ctx;
            
                    ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                    ctx.textAlign = 'center';
                    ctx.textBaseline = 'bottom';
            
                    this.data.datasets.forEach(function(dataset, i) {
                    var meta = chartInstance.controller.getDatasetMeta(i);
                    meta.data.forEach(function(bar, index) {
                        var data = dataset.data[index];
                        ctx.fillText(data, bar._model.x, bar._model.y - 5);
                    });
                    });
                }
            },
            plugins: {
                labels: {
                  render: () => {}
                }
              }
        }
    });
}

function drawPaymentTable(paymentData){
    var data = paymentData.kpi;
    var html = "";
    for(var i=0;i<data.length;i++)
    {
        html += '<tr style="height:50px;">';
        html += '<td><span class="badge">' + (parseInt(i)+1) + '</span></td>';
        html += '<td>' + data[i].Department + '</td>';
        html += '<td style="text-align:center;">' + data[i].Progress + '%</td>';
        html += '<td style="text-align:center;">' + data[i].Payment + '</td>';
        html += '<td style="text-align:center;"> - </td>';
        html += '</tr>';
    }

    $('#paymentTable').html(html);
}