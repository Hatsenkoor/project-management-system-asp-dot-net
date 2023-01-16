
anychart.onDocumentReady(function () {
    initialize();
});
function initialize(){
    $.ajax({
        type: "GET",
        url: apiUrl,
        datatype:JSON,      
        data: { "path": "https://pf.maf.gov.om/pmsdemoapi/mobileapi.ashx?app=11&actn=172&id=1" },
        success: function (data) {
            jsonData = JSON.parse(data);
            gantt(jsonData.list);
        },
        error: function (data){
            alert(data);
        }
    });
    // jsString = '{"list":{"ProjectId":1,"ProjectName":"Harmanjeet PMS","ProjectPhase":[{"Id":1,"ProjectId":1,"Name":"Requirement Gathering","StartDate":"1/1/2023 12:00:00 AM","EndDate":"1/31/2023 12:00:00 AM","PercentageCompleted":0,"CurrentStatus":"on time","WorkDay":31,"CalendarDay":23,"PlannedStartDate":"1/1/2023 12:00:00 AM","PlannedEndDate":"1/31/2023 12:00:00 AM","Sort":1,"ProjectMileStone":[{"Id":1,"ProjectPhaseID":1,"Name":"Fertilizer Requirement","StartDate":"1/1/2023 12:00:00 AM","EndDate":"1/10/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"on time","WorkDay":10,"CalendarDay":7,"PlannedStartDate":"1/1/2023 12:00:00 AM","PlannedEndDate":"1/10/2023 12:00:00 AM","Sort":1,"ProjectTask":[{"Id":1,"ProjectMileStoneID":1,"Name":"Workshop 1","StartDate":"1/1/2023 12:00:00 AM","EndDate":"1/1/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":1,"CalendarDay":1,"PlannedStartDate":"1/1/2023 12:00:00 AM","PlannedEndDate":"1/1/2023 12:00:00 AM","Sort":1},{"Id":2,"ProjectMileStoneID":1,"Name":"Workshop2","StartDate":"1/2/2023 12:00:00 AM","EndDate":"1/2/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":1,"CalendarDay":1,"PlannedStartDate":"1/2/2023 12:00:00 AM","PlannedEndDate":"1/2/2023 12:00:00 AM","Sort":2},{"Id":3,"ProjectMileStoneID":1,"Name":"Writing BRD Document","StartDate":"1/3/2023 12:00:00 AM","EndDate":"1/4/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":2,"CalendarDay":2,"PlannedStartDate":"1/3/2023 12:00:00 AM","PlannedEndDate":"1/4/2023 12:00:00 AM","Sort":3},{"Id":4,"ProjectMileStoneID":1,"Name":"Review 0026 Approval","StartDate":"1/5/2023 12:00:00 AM","EndDate":"1/5/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":1,"CalendarDay":1,"PlannedStartDate":"1/5/2023 12:00:00 AM","PlannedEndDate":"1/5/2023 12:00:00 AM","Sort":4}]},{"Id":2,"ProjectPhaseID":1,"Name":"Pesticide Requirement","StartDate":"1/11/2023 12:00:00 AM","EndDate":"1/20/2023 12:00:00 AM","PercentageCompleted":50,"CurrentStatus":"on time","WorkDay":10,"CalendarDay":7,"PlannedStartDate":"1/11/2023 12:00:00 AM","PlannedEndDate":"1/20/2023 12:00:00 AM","Sort":2,"ProjectTask":[]},{"Id":4,"ProjectPhaseID":1,"Name":"Lab Sample Requirement","StartDate":"1/21/2023 12:00:00 AM","EndDate":"1/31/2023 12:00:00 AM","PercentageCompleted":0,"CurrentStatus":"delay","WorkDay":11,"CalendarDay":8,"PlannedStartDate":"1/21/2023 12:00:00 AM","PlannedEndDate":"1/31/2023 12:00:00 AM","Sort":3,"ProjectTask":[]}]},{"Id":3,"ProjectId":1,"Name":"Design","StartDate":"2/1/2023 12:00:00 AM","EndDate":"3/30/2023 12:00:00 AM","PercentageCompleted":25,"CurrentStatus":"on time","WorkDay":60,"CalendarDay":50,"PlannedStartDate":"2/1/2023 12:00:00 AM","PlannedEndDate":"3/30/2023 12:00:00 AM","Sort":2,"ProjectMileStone":[{"Id":5,"ProjectPhaseID":3,"Name":"Fertilizer Dersign","StartDate":"2/1/2023 12:00:00 AM","EndDate":"2/15/2023 12:00:00 AM","PercentageCompleted":33,"CurrentStatus":"on time","WorkDay":15,"CalendarDay":12,"PlannedStartDate":"2/1/2023 12:00:00 AM","PlannedEndDate":"2/15/2023 12:00:00 AM","Sort":1,"ProjectTask":[{"Id":5,"ProjectMileStoneID":5,"Name":"Screen Design","StartDate":"2/1/2023 12:00:00 AM","EndDate":"2/10/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":10,"CalendarDay":8,"PlannedStartDate":"2/1/2023 12:00:00 AM","PlannedEndDate":"2/10/2023 12:00:00 AM","Sort":1},{"Id":6,"ProjectMileStoneID":5,"Name":"Review","StartDate":"2/11/2023 12:00:00 AM","EndDate":"2/14/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":4,"CalendarDay":4,"PlannedStartDate":"2/11/2023 12:00:00 AM","PlannedEndDate":"2/14/2023 12:00:00 AM","Sort":2},{"Id":7,"ProjectMileStoneID":5,"Name":"Approval","StartDate":"2/15/2023 12:00:00 AM","EndDate":"2/15/2023 12:00:00 AM","PercentageCompleted":100,"CurrentStatus":"completed","WorkDay":1,"CalendarDay":1,"PlannedStartDate":"2/15/2023 12:00:00 AM","PlannedEndDate":"2/15/2023 12:00:00 AM","Sort":3}]},{"Id":7,"ProjectPhaseID":3,"Name":"Pesticide Design","StartDate":"2/16/2023 12:00:00 AM","EndDate":"2/28/2023 12:00:00 AM","PercentageCompleted":0,"CurrentStatus":"not started","WorkDay":12,"CalendarDay":10,"PlannedStartDate":"2/16/2023 12:00:00 AM","PlannedEndDate":"2/28/2023 12:00:00 AM","Sort":2,"ProjectTask":[]},{"Id":8,"ProjectPhaseID":3,"Name":"Lab Sample Design","StartDate":"3/1/2023 12:00:00 AM","EndDate":"3/31/2023 12:00:00 AM","PercentageCompleted":0,"CurrentStatus":"not started","WorkDay":31,"CalendarDay":25,"PlannedStartDate":"3/1/2023 12:00:00 AM","PlannedEndDate":"3/31/2023 12:00:00 AM","Sort":3,"ProjectTask":[]}]}]}}';

}
function gantt(data){
    var result = [];
    var count = 1;
    var _p = count;
    $.each(data.ProjectPhase, function(index, row){
        count++;
        var _ro = {          
            "id": count,
            "parent": _p,
            "name": row.Name,
            "progressValue": row.PercentageCompleted.toString()+'%',
            "actualStart": (new Date(row.StartDate)).getTime(),
            "actualEnd": (new Date(row.EndDate)).getTime(),
            "PercentageCompleted": row.PercentageCompleted,
            "CurrentStatus": row.CurrentStatus,
            "WorkDay": row.WorkDay,
            "CalendarDay": row.CalendarDay,
            "PlannedStartDate": (new Date(row.PlannedStartDate)).getTime(),
            "PlannedEndDate": (new Date(row.PlannedEndDate)).getTime(),
            "Sort": row.Sort,
        };

        result.push(_ro);
        var _pa = count;

        $.each(row.ProjectMileStone, function(inde, ro){
            count++;
            var _row = {          
                "id": count,
                "parent": _pa,
                "name": ro.Name,
                "progressValue": ro.PercentageCompleted.toString()+'%',
                "actualStart": (new Date(ro.StartDate)).getTime(),
                "actualEnd": (new Date(ro.EndDate)).getTime(),
                "PercentageCompleted": ro.PercentageCompleted,
                "CurrentStatus": ro.CurrentStatus,
                "WorkDay": ro.WorkDay,
                "CalendarDay": ro.CalendarDay,
                "PlannedStartDate": (new Date(ro.PlannedStartDate)).getTime(),
                "PlannedEndDate": (new Date(ro.PlannedEndDate)).getTime(),
                "Sort": ro.Sort,
            };

            result.push(_row);
            var _par = count;
            $.each(ro.ProjectTask, function(ind, r){
            count++;
            var _roww = {          
                "id": count,
                "parent": _par,
                "name": r.Name,
                "progressValue": r.PercentageCompleted.toString()+'%',
                "actualStart": (new Date(r.StartDate)).getTime(),
                "actualEnd": (new Date(r.EndDate)).getTime(),
                "PercentageCompleted": r.PercentageCompleted,
                "CurrentStatus": r.CurrentStatus,
                "WorkDay": r.WorkDay,
                "CalendarDay": r.CalendarDay,
                "PlannedStartDate": (new Date(r.PlannedStartDate)).getTime(),
                "PlannedEndDate": (new Date(r.PlannedEndDate)).getTime(),
                "Sort": r.Sort,
            };

            result.push(_roww);
            });
        }) 
    });
    startTime = Math.min(...result.map(o => o.actualStart));
    endTime = Math.max(...result.map(o => o.actualEnd));
    var _r = {
        "id": 1,
        "name": data.ProjectName,
        "progressValue": 0,
        "actualStart": startTime,
        "actualEnd": endTime
    };

    result.unshift(_r);
    var treeData;
    treeData = anychart.data.tree(result, 'as-table');

    var chart = anychart.ganttProject();
    chart.data(treeData);

    // set start splitter position settings
    chart.splitterPosition(700);

    // get chart data grid link to set column settings
    var dataGrid = chart.dataGrid();

    // set first column settings
    dataGrid
        .column(0)
        .title('#')
        .width(30)
        .labels({ hAlign: 'center' });

    // set second column settings
    dataGrid
        .column(1)
        .title('Project Name')
        .width(180)
        .labels()
        .hAlign('left')
        .format(function () {
        return this.item.ka.name;
        });

    // set third column settings
    dataGrid
        .column(2)
        .title('Start Date')
        .width(70)
        .labels()
        .hAlign('right')
        .format(function () {
        var date = new Date(this.item.ka.actualStart);
        var month = date.getUTCMonth() + 1;
        var strMonth = month > 9 ? month : '0' + month;
        var utcDate = date.getUTCDate();
        var strDate = utcDate > 9 ? utcDate : '0' + utcDate;
        return date.getUTCFullYear() + '.' + strMonth + '.' + strDate;
        });

    // set fourth column settings
    dataGrid
        .column(3)
        .title('End Date')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            var date = new Date(this.item.ka.actualEnd);
            var month = date.getUTCMonth() + 1;
            var strMonth = month > 9 ? month : '0' + month;
            var utcDate = date.getUTCDate();
            var strDate = utcDate > 9 ? utcDate : '0' + utcDate;
            return date.getUTCFullYear() + '.' + strMonth + '.' + strDate;
        });
    dataGrid
        .column(4)
        .title('Percentage Completed')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            return this.item.ka.PercentageCompleted;
        });
    dataGrid
        .column(5)
        .title('Current Status')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            return this.item.ka.CurrentStatus;
        });
    dataGrid
        .column(6)
        .title('Work Day')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            return this.item.ka.WorkDay;
        });
    dataGrid
        .column(7)
        .title('Calendar Day')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            return this.item.ka.CalendarDay;
        });
    dataGrid
        .column(8)
        .title('Planned Start Date')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            var date = new Date(this.item.ka.PlannedStartDate);
        var month = date.getUTCMonth() + 1;
        var strMonth = month > 9 ? month : '0' + month;
        var utcDate = date.getUTCDate();
        var strDate = utcDate > 9 ? utcDate : '0' + utcDate;
        return date.getUTCFullYear() + '.' + strMonth + '.' + strDate;
        });
    dataGrid
        .column(9)
        .title('Planned End Date')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            var date = new Date(this.item.ka.PlannedEndDate);
        var month = date.getUTCMonth() + 1;
        var strMonth = month > 9 ? month : '0' + month;
        var utcDate = date.getUTCDate();
        var strDate = utcDate > 9 ? utcDate : '0' + utcDate;
        return date.getUTCFullYear() + '.' + strMonth + '.' + strDate;
        });
    dataGrid
        .column(10)
        .title('Sort')
        .width(80)
        .labels()
        .hAlign('right')
        .format(function () {
            return this.item.ka.Sort;
        });
    // set container id for the chart
    chart.container('container');

    // initiate chart drawing
    chart.draw();

    // zoom chart to specified date
    chart.zoomTo(startTime, endTime);
}