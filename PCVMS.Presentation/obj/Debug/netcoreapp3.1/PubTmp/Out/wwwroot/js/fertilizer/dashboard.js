
$(document).ready(function () {
  
    getReviewPendingCertificate();
    getApprovalPendingCertificate();  
   GetCertificateAnalysis();
  

    $("#tbl-fertilizer-certificate-approval-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();

        var id = $(this).parents("tr").find("#tdid").html();    
        var application_Type = $(this).parents("tr").find("#tdapplicationType").html();

        //if (application_Type === 'local') {

        //    window.location.href = RootPath() + "/FertilizerCertificate/local?CertificateId=" + id;
        //}
        //else {

        //    window.location.href = RootPath() + "/FertilizerCertificate/imported?CertificateId=" + id;
        //}  

        window.location.href = RootPath() + "/FertilizerCertificate/approval?CertificateId=" + id;

    });

    $("#tbl-fertilizer-certificate-review-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();

        var id = $(this).parents("tr").find("#tdid").html();
        var application_Type = $(this).parents("tr").find("#tdapplicationType").html();

        window.location.href = RootPath() + "/FertilizerCertificate/review?CertificateId=" + id;

    });

});

function getReviewPendingCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getReviewPendingCertificate", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populateReviewGrid(data);
               
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateReviewGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-fertilizer-certificate-review-list > tbody").html('');

    if (data.length > 0) {
        $('#no_record_screen').hide();     
    }
    else {

        $('#record_screen').hide();
        $('#no_record_screen').show();
    }


    for (var i = 0; i < data.length; i++) {
        

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdapplicationType' name='tdapplicationType'>" + data[i].application_Type + "</td>"
            + "<td style = 'display:none;' id = 'tdregistrationFee' name='tdregistrationFee'>" + data[i].registrationFee + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificateFee' name='tdcertificateFee'>" + data[i].certificateFee + "</td>"
            + "<td style = 'display:none;' id = 'tdRequested_Date' name = 'tdRequested_Date' style = 'text-align:center;'>" + data[i].requested_Date + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistration_Request_No' name = 'tdRegistration_Request_No' style = 'text-align:center;'>" + data[i].registration_Request_No + "</td>"
            + "<td style ='display:none;'  id = 'tdLocal_Certificate_Registration_No' name='tdLocal_Certificate_Registration_No'>" + data[i].local_Certificate_Registration_No + "</td>"
            + "<td style = 'display:none;' id = 'tdScientific_Name' name = 'tdScientific_Name' style = 'text-align:center;'>" + data[i].scientific_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdTrade_Name' name = 'tdTrade_Name' style = 'text-align:center;'>" + data[i].trade_Name + "</td>"
            + "<td style ='display:none;'  id = 'tdNature_Shape_ID' name='tdNature_Shape_ID'>" + data[i].nature_Shape_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdNature_Shape' name='tdNature_Shape'>" + data[i].nature_Shape + "</td>"
            + "<td style = 'display:none;' id = 'tdDensity_Concentration' name = 'tdDensity_Concentration' style = 'text-align:center;'>" + data[i].density_Concentration + "</td>"
            + "<td style = 'display:none;' id = 'tdPH_Concentration' name = 'tdPH_Concentration' style = 'text-align:center;'>" + data[i].pH_Concentration + "</td>"

            + "<td style='display:none;'   id = 'tdManufacturer_Address' name='tdManufacturer_Address'>" + data[i].manufacturer_Address + "</td>"

            + "<td style = 'display:none;' id = 'tdExporting_Company' name = 'tdExporting_Company' style = 'text-align:center;'>" + data[i].exporting_Company + "</td>"
            + "<td style = 'display:none;' id = 'tdManufacturing_Country' name = 'tdManufacturing_Country' style = 'text-align:center;'>" + data[i].manufacturing_Country + "</td>"
            + "<td style ='display:none;'  id = 'tdExporting_Company_Address' name='tdExporting_Company_Address'>" + data[i].exporting_Company_Address + "</td>"
            + "<td style = 'display:none;' id = 'tdCR_Number' name = 'tdCR_Number' style = 'text-align:center;'>" + data[i].cR_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistered_Commercial_Activities' name = 'tdRegistered_Commercial_Activities' style = 'text-align:center;'>" + data[i].registered_Commercial_Activities + "</td>"


            + "<td style = 'display:none;' id = 'tdImport_Export_License_Number' name = 'tdImport_Export_License_Number' style = 'text-align:center;'>" + data[i].import_Export_License_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdAddress' name = 'tdAddress' style = 'text-align:center;'>" + data[i].address + "</td>"
            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'display:none; text-align:center;'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].company_Licensed_Import_Export_Trade + "</td>"
            + "<td id = 'tdManufacturer' name = 'tdManufacturer' style = 'text-align:center;'>" + data[i].manufacturer + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"
            + "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

          // addpend the final string
        $("#tbl-fertilizer-certificate-review-list > tbody:last-child").append(tempString);
      
    }
}


function getApprovalPendingCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getApprovalPendingCertificate", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List
              
                populateApprovalGrid(data);
               

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateApprovalGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-fertilizer-certificate-approval-list > tbody").html('');

    if (data.length > 0) {
        $('#no_record_screen').hide();
    }
    else {

        $('#record_screen').hide();
        $('#no_record_screen').show();
    }


    for (var i = 0; i < data.length; i++) {


        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdapplicationType' name='tdapplicationType'>" + data[i].application_Type + "</td>"
            + "<td style = 'display:none;' id = 'tdregistrationFee' name='tdregistrationFee'>" + data[i].registrationFee + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificateFee' name='tdcertificateFee'>" + data[i].certificateFee + "</td>"
            + "<td style = 'display:none;' id = 'tdRequested_Date' name = 'tdRequested_Date' style = 'text-align:center;'>" + data[i].requested_Date + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistration_Request_No' name = 'tdRegistration_Request_No' style = 'text-align:center;'>" + data[i].registration_Request_No + "</td>"
            + "<td style ='display:none;'  id = 'tdLocal_Certificate_Registration_No' name='tdLocal_Certificate_Registration_No'>" + data[i].local_Certificate_Registration_No + "</td>"
            + "<td style = 'display:none;' id = 'tdScientific_Name' name = 'tdScientific_Name' style = 'text-align:center;'>" + data[i].scientific_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdTrade_Name' name = 'tdTrade_Name' style = 'text-align:center;'>" + data[i].trade_Name + "</td>"
            + "<td style ='display:none;'  id = 'tdNature_Shape_ID' name='tdNature_Shape_ID'>" + data[i].nature_Shape_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdNature_Shape' name='tdNature_Shape'>" + data[i].nature_Shape + "</td>"
            + "<td style = 'display:none;' id = 'tdDensity_Concentration' name = 'tdDensity_Concentration' style = 'text-align:center;'>" + data[i].density_Concentration + "</td>"
            + "<td style = 'display:none;' id = 'tdPH_Concentration' name = 'tdPH_Concentration' style = 'text-align:center;'>" + data[i].pH_Concentration + "</td>"

            + "<td style='display:none;'   id = 'tdManufacturer_Address' name='tdManufacturer_Address'>" + data[i].manufacturer_Address + "</td>"

            + "<td style = 'display:none;' id = 'tdExporting_Company' name = 'tdExporting_Company' style = 'text-align:center;'>" + data[i].exporting_Company + "</td>"
            + "<td style = 'display:none;' id = 'tdManufacturing_Country' name = 'tdManufacturing_Country' style = 'text-align:center;'>" + data[i].manufacturing_Country + "</td>"
            + "<td style ='display:none;'  id = 'tdExporting_Company_Address' name='tdExporting_Company_Address'>" + data[i].exporting_Company_Address + "</td>"
            + "<td style = 'display:none;' id = 'tdCR_Number' name = 'tdCR_Number' style = 'text-align:center;'>" + data[i].cR_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistered_Commercial_Activities' name = 'tdRegistered_Commercial_Activities' style = 'text-align:center;'>" + data[i].registered_Commercial_Activities + "</td>"


            + "<td style = 'display:none;' id = 'tdImport_Export_License_Number' name = 'tdImport_Export_License_Number' style = 'text-align:center;'>" + data[i].import_Export_License_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdAddress' name = 'tdAddress' style = 'text-align:center;'>" + data[i].address + "</td>"
            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'display:none; text-align:center;'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].company_Licensed_Import_Export_Trade + "</td>"
            + "<td id = 'tdManufacturer' name = 'tdManufacturer' style = 'text-align:center;'>" + data[i].manufacturer + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"
            + "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-fertilizer-certificate-approval-list > tbody:last-child").append(tempString);

    }
}

function GetCertificateAnalysis() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetCertificateAnalysis", // Controller/View
            success: function (data1) {

                for (var i = 0; i < data1.length; i++) {

                    var data = data1[i];

                    if (data.status === 'Approved') {

                        $("#lbl_total_certificate").text(data.local + data.imported);
                    }
                    else if (data.status === 'Cancelled') {

                        $("#lbl_total_cancelled_certificate").text(data.local + data.imported);
                    }
                    else if (data.status === 'Request Certificate Cancel') {
                       
                        $("#lbl_total_cancel_certificate").text(data.local + data.imported);
                    }
                    else if (data.status === 'Director Review') {

                        $("#lbl_total_certificate_approval_pending").text(data.local + data.imported);
                    }
                }

                // Use Morris.Bar
                var colormanpower = ["#ff4b65", "#540020", "#128a08", "#144182", "#f0bf30", "#9d0000", "#f46500", "#1F3F49", "#484848"];
                Morris.Bar({
                    element: 'barchartlocal',                  
                    data: data1,
                    //data: [
                    //    { x: 'Save', y: 5, z: 1 },
                    //    { x: 'Submitted', y: 1, z: 3 },
                    //    { x: 'Review', y: 2, z: 1 },
                    //    { x: 'Committee', y: 8, z: 0 },
                    //    { x: 'Director Approval', y: 3, z: 6 },
                    //    { x: 'Payment', y: 4, z: 4 },
                    //    { x: 'Issue', y: 5, z: 5 },
                    //    { x: 'Cancel Request', y: 6, z: 8 },
                    //    { x: 'Cancel', y: 7, z: 2 }

                    //],
                    barColors: function (row, series, type) {
                        if (series.index == 0) return colormanpower[0];
                        else if (series.index == 1) return colormanpower[1];                  

                    },
                    xkey: 'status',
                    ykeys: ['local','imported'],
                    labels: ['Fertilizer Certificate'],
                    xLabelAngle: 43,
                    dataLabels: true,
                    resize: true,                  
                    hideHover: 'always'              
                });

                var legendcertificate = ['local', 'imported'];

                $('#barchartlocal_legend').empty(); // empty the div before fetching and adding new data

                for (var i = 0; i < 2; i++) {
                    var node = document.createElement('span');
                    node.innerHTML += '<span style="color:' + colormanpower[i] + '"><i style="margin-left: 15px;" class="fas fa-square"></i> ' + legendcertificate[i] + '</span>';
                    document.getElementById("barchartlocal_legend").appendChild(node);
                }
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}
