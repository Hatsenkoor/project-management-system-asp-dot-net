
$(document).ready(function () {

    getAllLabSample("Exported-Agriculture");

    $('#ReceivingatLab').hide();
    $('#AnalysisandTesting').hide();
    $('#SampleReportApproval').hide();   

//# Region GENERAL PAGE
    $("#btnSaveImportExport").click(function (e) {

        var App_ID;
        var App_Name;
        if (e.target.name === 'ExportedAgriculture') {

            App_ID = '79D860E6-733E-4055-9D48-B8D519E8EBFA';
            App_Name = 'Exported-Agriculture';
        } else if (e.target.name === 'ExportedPesticide') {

            App_ID = 'FC9668C8-587E-43C0-870D-A9B04F2B6E48';
            App_Name = 'Exported-Pesticide';
        }
        else if (e.target.name === 'ExportedPest') {

            App_ID = '3FDECC37-C343-4322-8B73-0618EB919609';
            App_Name = 'Exported-Pest';
        } else if (e.target.name === 'ExportedFertilizerSoil') {

            App_ID = 'DFA2E027-F72B-41B9-BDE7-E95D03BA6BB1';
            App_Name = 'Exported-Fertilizer-Soil';
        }

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveImportExport", // Controller/View
                data: { //Passing data

                    Request_ID: $("#txtID").val(),
                    Payment_ID: $("#txtID").val(),
                    Collection_Date: $("#txtSampleCollectionDate").val(), //Reading text box values using Jquery
                    PC_Number: $("#txtPCNumber").val(),
                    App_ID: App_ID,
                    App_Name: App_Name,
                    Port_ID: $("#PortMasterID").val(),
                    Port_Name: $("#PortMasterID option:selected").text(),
                    Custom_Document_Number: $("#txtCustomDocumentNumber").val(),
                    Shipment_Document_Number: $("#txtShipmentDocumentNumber").val(), //Reading text box values using Jquery
                    Company_Name: $("#txtCompanyName").val(),
                    Country_Origin_ID: $("#CountryOriginMasterID").val(),
                    Country_Origin_Name: $("#CountryOriginMasterID option:selected").text(),
                    Country_Export_ID: $("#CountryExportMasterID").val(),
                    Country_Export_Name: $("#CountryExportMasterID option:selected").text(), //Reading text box values using Jquery
                    Sample_Type_ID: $("#SampleMasterID").val(),
                    Sample_Type_Name: $("#SampleMasterID option:selected").text(),
                    Sample_Source_ID: $("#SampleSourceMasterID").val(),
                    Sample_Source_Name: $("#SampleSourceMasterID option:selected").text(),
                    Analysis_Type_ID: $("#AnalysisMasterID").val(),
                    Analysis_Type_Name: $("#AnalysisMasterID option:selected").text(),
                    Importer_Name: $("#txtExporter").val(),
                    Importer_Contact_Detail: $("#txtContactDetail").val(),
                    Testing_Lab_ID: $("#LabMasterID").val(),
                    Testing_Lab_Name: $("#LabMasterID option:selected").text(),
                    Remark: $("#txtremark").val(),
                    StatusId: "Saved"

                },
                success: function (data) {

                    // Populate the Table with Sample List
                    $("#txtID").val(data);
                    // Populate the Table with Sample List
                    getAllLabSample("Exported-Agriculture");

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $("#btnSaveSampleDetails").click(function (e) {
        var now = '11/11/2022';

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveSampleDetails", // Controller/View
                data: { //Passing data

                    ID: 0,
                    Sample_ID: $("#txtID").val(),
                    Expected_Harvest_Date: now, //Reading text box values using Jquery
                    Production_Date: now,
                    Expiry_Date: now,
                    Date_Symptoms_On_Set: now,
                    Commodity_Type_ID: $("#CommodityTypeID").val(),
                    Commodity_Type_Name: $("#CommodityTypeID option:selected").text(),
                    Commodity_Name_ID: $("#CommodityNameID").val(),
                    Commodity_Name: $("#CommodityNameID option:selected").text(),
                    Weight_Units: $("#txtWeight_Units").val(),                   
                    StatusId: "Saved"

                },
                success: function (data) {

                    // Populate the Table with Sample List
                    getSampleDetailsByID($("#txtID").val(), "Saved");

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $("#btnSaveLabAnalysis").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveLabAnalysis", // Controller/View
                data: { //Passing data

                    ID: 0,
                    Sample_ID: $("#txtID").val(),
                    Receiving_Date: $("#txtReceivingDate").val(), //Reading text box values using Jquery
                    Collected_From: $("#txtCollectedFrom").val(),
                    Delivered_By: $("#txtDeliveredBy").val(),                  
                    Packaging_Type_ID: $("#PackagingTypeID").val(),
                    Packaging_Type_Name: $("#PackagingTypeID option:selected").text(),
                    Packaging_Condition_ID: $("#PackagingConditionID").val(),
                    Packaging_Condition_Name: $("#PackagingConditionID option:selected").text(),
                    Sample_Quantity: $("#txtSampleQuantity").val(),
                    Sample_Temperature: $("#txtSampleTemperature").val(),
                    Sample_Type_ID: $("#SampleTypeID").val(),
                    Sample_Type_Name: $("#SampleTypeID option:selected").text(),
                    Commodity: $("#txtCommodity").val(),
                    TestMethod: $("#txtTestMethod").val(),
                    Payment_Type_ID: $("#PaymentTypeID").val(),
                    Payment_Type_Name: $("#PaymentTypeID option:selected").text(),
                    Formulation_Type_Name: $("#txtFormulationTypeName").val(),
                    InstrumentsForAnalysis: $("#txtInstrumentsForAnalysis").val(),
                    Remark: $("#txtRemark").val(),
                    StatusId: "Saved"

                },
                success: function (data) {

                    // Populate the Table with Sample List
                    statusChange("In Progress");

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $("#btnSaveLabResult").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveLabResult", // Controller/View
                data: { //Passing data

                    ID: 0,
                    Sample_ID: $("#txtID").val(),
                    Report_ID: $("#txtReportID").val(), //Reading text box values using Jquery
                    Analysis_Date: $("#txtAnalysisDate").val(),
                    Analyzed_By: $("#txtAnalyzedBy").val(),
                    Finding_ID: $("#FindingTypeID").val(),
                    Finding_Name: $("#FindingTypeID option:selected").text(),                   
                    Remark: $("#txtRemark").val(),
                    StatusId: "Saved"

                },
                success: function (data) {

                    // Populate the Table with Sample List
                    statusChange("Approval pending");

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });
//# end Region GENERAL PAGE

    $("#tbl-lab-sample-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();
        // this is the code to make the selected row highlighted
        //start

        $('#step-1').show();
        $('#step-2').hide();
        $('#step-3').hide();
        $('#step-4').hide();
        $('#step-5').hide();

        if ($(this).parent("tr").hasClass('active')) {

            $(this).parents("tr").removeClass("active");
        } else {

            $('#tbl-lab-sample-list > tbody tr.active').removeClass('active');
            $(this).parents("tr").addClass("active");
        }
        //end
        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();


        if (event === 'view') {

            $("#step-1 :input").attr("disabled", true);
            $("#step-2 :input").attr("disabled", true);
            $("#step-3 :input").attr("disabled", true);
            $("#step-4 :input").attr("disabled", true);
        }
        else if (event === 'edit') {
            $("#step-1 :input").attr("disabled", false);           
            $("#step-2 :input").attr("disabled", false);
            $("#step-3 :input").attr("disabled", false);
            $("#step-4 :input").attr("disabled", false);
        }
        else if (event === 'delete') {
            alert("Delete: not allowed");
            return false;
        }

        $("#txtID").val($(this).parents("tr").find("#tdid").html());
        $("#txtSampleCollectionDate").val($(this).parents("tr").find("#tdCollection_Date").html()); //Reading text box values using Jquery
        $("#txtCompanyName").val($(this).parents("tr").find("#tdCompany_Name").html());
        $("#GovernorateID").val($(this).parents("tr").find("#tdGovernorate_ID").html());
        $("#txtVillage").val($(this).parents("tr").find("#tdVillage").html());
        $("#txtAgriculturalHoldingNumber").val($(this).parents("tr").find("#tdAgriculturalHoldingNumber").html());
        $("#txtlatitude").val($(this).parents("tr").find("#tdwgs84_latitude").html());
        $("#txtlongitude").val($(this).parents("tr").find("#tdwgs84_longitude").html());
        $("#SampleMasterID").val($(this).parents("tr").find("#tdSample_Type_ID").html());
        $("#SampleSourceMasterID").val($(this).parents("tr").find("#tdSample_Source_ID").html());
        $("#AnalysisMasterID").val($(this).parents("tr").find("#tdAnalysis_Type_ID").html());
        $("#FarmTypeID").val($(this).parents("tr").find("#tdFarm_Type_ID").html());
        $("#txtFarmerName").val($(this).parents("tr").find("#tdFarm_Owner_Name").html());
        $("#LabMasterID").val($(this).parents("tr").find("#tdTesting_Lab_ID").html());
        $("#txtremark").val($(this).parents("tr").find("#tdRemark").html());

        var status = $(this).parents("tr").find("#tdstatus").html();

        if (status === 'Submitted') {
            $('#ReceivingatLab').show();
            $('#AnalysisandTesting').hide();
            $('#SampleReportApproval').hide();
        }else if (status === 'In Progress'){
            $('#ReceivingatLab').show();
            $('#AnalysisandTesting').show();
            $('#SampleReportApproval').hide();
        }else if (status === 'Approval pending' || status ==='Approved') {
            $('#ReceivingatLab').show();
            $('#AnalysisandTesting').show();
            $('#SampleReportApproval').show();
        }else {
            $('#ReceivingatLab').hide();
            $('#AnalysisandTesting').hide();
            $('#SampleReportApproval').hide();
        }

        getSampleDetailsByID($("#txtID").val(), status);
        GetSampleAnalysisByID($("#txtID").val(), status);
        GetSampleResultByID($("#txtID").val(), status);
        populateDocument($("#txtID").val());
        populateRFCDetail();
    });

    $("#btnfinalSubmission").click(function (e) {

        statusChange("Submitted");
        e.preventDefault();

    });

    // Datepicker for Pesticide Certificate
    $('[data-toggle="datepicker_trigger_txtSampleCollectionDate"]').datepicker({
        trigger: ".datepicker-click-SampleCollectionDate",
        autoPick: true,
        autoHide: true
    });

    // Datepicker for Pesticide Certificate
    $('[data-toggle="datepicker_trigger_txtExpected_Harvest_Date"]').datepicker({
        trigger: ".datepicker-click-ExpectedHarvestDate",
        autoPick: true,
        autoHide: true
    });

    // Datepicker for Pesticide Certificate
    $('[data-toggle="datepicker_trigger_txtReceivingDate"]').datepicker({
        trigger: ".datepicker-click-ReceivingDate",
        autoPick: true,
        autoHide: true
    });

    // Datepicker for Pesticide Certificate
    $('[data-toggle="datepicker_trigger_txtAnalyzedDate"]').datepicker({
        trigger: ".datepicker-click-AnalyzedDate",
        autoPick: true,
        autoHide: true
    });

    //# Region Review Section

    $("#tbl-review-history > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        // this is the code to make the selected row highlighted
        //start
        if ($(this).parent("tr").hasClass('active')) {

            $(this).parents("tr").removeClass("active");
        } else {

            $('#tbl-review-history > tbody tr.active').removeClass('active');
            $(this).parents("tr").addClass("active");
        }
        //end

        var event = $(this)[0].title;
        var reviewid = $(this).parents("tr").find("#tdid").html();

        var remark = $(this).parents("tr").find("#tdremark").html();
        $("#ReviewID").val(reviewid);
        $("#txtReviewHistory").val(remark);

        populateDocument(reviewid)

    });

    $("#btnApproveLabSample").click(function (e) {

        saveRemark("Approved", "Approved");

        e.preventDefault();

    });

    $("#btnRFCLabSample").click(function (e) {

        saveRemark("Approval pending", $("#txtReviewHistory").val());
      
        e.preventDefault();

    });

    //# endRegion Review Section

});

function statusChange(status) {

    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "SubmitSample", // Controller/View
            data: { //Passing data
                Id: $("#txtID").val(),
                statusId: status
            },
            success: function (data) {

                if (status === 'Submitted') {
                    $('#ReceivingatLab').show();
                    $('#AnalysisandTesting').hide();
                    $('#SampleReportApproval').hide();
                } else if (status === 'In Progress') {
                    $('#ReceivingatLab').show();
                    $('#AnalysisandTesting').show();
                    $('#SampleReportApproval').hide();
                } else if (status === 'Approval pending' || status === 'Approved') {
                    $('#ReceivingatLab').show();
                    $('#AnalysisandTesting').show();
                    $('#SampleReportApproval').show();
                } else {
                    $('#ReceivingatLab').hide();
                    $('#AnalysisandTesting').hide();
                    $('#SampleReportApproval').hide();
                }
                getAllLabSample("Exported-Agriculture");
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });

}

function saveRemark(status, remark) {

    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "SaveRemark", // Controller/View
            data: { //Passing data
                CertificateID: $("#txtID").val(),
                Remark: remark,
                Remark_Type: "lab_sample"
            },
            success: function (data) {
                Remark: $("#txtReviewHistory").val(''),
                // Populate the Table with Sample List
                statusChange(status);
                populateReviewHistoryGrid(data);
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });


}

function getAllLabSample(application_type) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllLabSample?application_type=" + application_type,
            success: function (data) {

                // Populate the Table with Finance Income List

                populateLabSampleGrid(data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateLabSampleGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-lab-sample-list > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdApp_ID' name='tdApp_ID'>" + data[i].app_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdApp_Name' name='tdApp_Name'>" + data[i].App_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdRequest_ID' name='tdRequest_ID'>" + data[i].request_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdPayment_ID' name='tdPayment_ID'>" + data[i].payment_ID + "</td>"

            + "<td style = 'display:none;' id = 'tdGovernorate_ID' name = 'tdGovernorate_ID' style = 'text-align:center;'>" + data[i].governorate_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdVillage' name='tdVillage'>" + data[i].village + "</td>"
            + "<td style = 'display:none;' id = 'tdAgriculturalHoldingNumber' name = 'tdAgriculturalHoldingNumber' style = 'text-align:center;'>" + data[i].agriculturalHoldingNumber + "</td>"
            + "<td style = 'display:none;' id = 'tdwgs84_latitude' name = 'tdwgs84_latitude' style = 'text-align:center;'>" + data[i].wgs84_latitude + "</td>"
            + "<td style ='display:none;'  id = 'tdwgs84_longitude' name='tdwgs84_longitude'>" + data[i].wgs84_longitude + "</td>"
            + "<td style ='display:none;'  id = 'tdSample_Type_ID' name='tdSample_Type_ID'>" + data[i].sample_Type_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdSample_Type_Name' name='tdSample_Type_Name'>" + data[i].sample_Type_Name + "</td>"
            + "<td style ='display:none;'  id = 'tdSample_Source_ID' name='tdSample_Source_ID'>" + data[i].sample_Source_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdSample_Source_Name' name = 'tdSample_Source_Name' style = 'text-align:center;'>" + data[i].sample_Source_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdAnalysis_Type_ID' name = 'tdAnalysis_Type_ID' style = 'text-align:center;'>" + data[i].analysis_Type_ID + "</td>"
            + "<td style='display:none;'   id = 'tdAnalysis_Type_Name' name='tdAnalysis_Type_Name'>" + data[i].analysis_Type_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdFarm_Type_ID' name = 'tdFarm_Type_ID' style = 'text-align:center;'>" + data[i].farm_Type_ID + "</td>"
            + "<td style='display:none;'   id = 'tdFarm_Type' name='tdFarm_Type'>" + data[i].farm_Type + "</td>"
            + "<td style = 'display:none;' id = 'tdTesting_Lab_ID' name = 'tdTesting_Lab_ID' style = 'text-align:center;'>" + data[i].testing_Lab_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdFarm_Owner_Name' name = 'tdFarm_Owner_Name' style = 'text-align:center;'>" + data[i].farm_Owner_Name + "</td>"

            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td style = 'display:none;' id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td id = 'tdCompany_Name' name='tdCompany_Name'>" + data[i].company_Name + "</td>"
            + "<td id = 'tdTesting_Lab_Name' name='tdTesting_Lab_Name'>" + data[i].testing_Lab_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdGovernorate' name = 'tdGovernorate' style = 'text-align:center;'>" + data[i].governorate + "</td>"
            + "<td  id = 'tdCollection_Date' name='tdCollection_Date'>" + data[i].collection_Date + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"

        if (data[i].statusId !== "Approved")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>";
        else

            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-lab-sample-list > tbody:last-child").append(tempString);

        
    }

    if ($("#txtID").val() !== 0) {

        $('#tbl-lab-sample-list > tbody  > tr').each(function (index, tr) {

            var selected_row = tr.cells["tdid"].textContent;
           
            if (selected_row === $("#txtID").val()) {

                if ($(this).parent("tr").hasClass('active')) {

                    $(this).parents("tr").removeClass("active");
                } else {

                    $('#tbl-lab-sample-list > tbody tr.active').removeClass('active');
                    $(this).addClass("active");
                }
            }

        });
    }
}


function getSampleDetailsByID(ID, status) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getSampleDetailsByID?ID=" + ID,
            success: function (data) {

                // Populate the Table with Finance Income List
                populateLabSampleDetailsGrid(data, status);
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}
function GetSampleAnalysisByID(id, status) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetSampleAnalysisByID?ID=" + $("#txtID").val(),
            success: function (data) {

                // Populate the Table with Finance Income List

                $("#txtReceivingDate").val(data.receiving_Date);//Reading text box values using Jquery
                $("#txtCollectedFrom").val(data.collected_From);
                $("#txtDeliveredBy").val(data.delivered_By);
                $("#PackagingTypeID").val(data.packaging_Type_ID);             
                $("#PackagingConditionID").val(data.packaging_Condition_ID);              
                $("#txtSampleQuantity").val(data.sample_Quantity);
                $("#txtSampleTemperature").val(data.sample_Temperature);
                $("#SampleTypeID").val(data.sample_Type_ID);            
                $("#txtCommodity").val(data.commodity);
                $("#txtTestMethod").val(data.testMethod);
                $("#PaymentTypeID").val(data.payment_ID);           
                $("#txtFormulationTypeName").val(data.formulation_Type_Name);
                $("#txtInstrumentsForAnalysis").val(data.instrumentsForAnalysis);
                $("#txtRemark").val(data.remark);

                
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function GetSampleResultByID(ID, status) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetSampleResultByID?ID=" + $("#txtID").val(),
            success: function (data) {

                // Populate the Table with Finance Income List
                
                $("#txtReportID").val(data.report_ID); //Reading text box values using Jquery
                $("#txtAnalysisDate").val(data.analysis_Date);
                $("#txtAnalyzedBy").val(data.analyzed_By);
                $("#FindingTypeID").val(data.finding_ID);                                
                $("#txtRemark").val(data.remark);
                  
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateLabSampleDetailsGrid(data, status) {

    // Populate the Table with Finance Income List

    $("#tbl-sample-details > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td id = 'tdid' name='tdid'>" + data[i].id + "</td>"
            + "<td id = 'tdCommodity_Type_Name' name = 'tdCommodity_Type_Name' style = 'text-align:center;'>" + data[i].commodity_Type_Name + "</td>"
            + "<td id = 'tdCommodity_Name' name = 'tdCommodity_Name' style = 'text-align:center;'>" + data[i].commodity_Name + "</td>"
            + "<td  id = 'tdWeight_Units' name='tdWeight_Units'>" + data[i].weight_Units + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"

        if (data[i].statusId === "Saved")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>";
        else if (data[i].statusId === "Submitted")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i></div></td></tr>";
        else

            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-sample-details > tbody:last-child").append(tempString);

    }

    if ($("#tbl-sample-details > tbody > tr").length > 0 && status === 'Saved') {

        $('#pnlfinalSubmission').show();

    } else {
        $('#pnlfinalSubmission').hide();
    }

}

function clear() {

    $("#txtID").val('');
    $("#txtSampleCollectionDate").val(''); //Reading text box values using Jquery
    $("#txtCompanyName").val('');
    $("#GovernorateID").val(-1);
    $("#txtVillage").val('');
    $("#txtAgriculturalHoldingNumber").val('');
    $("#txtlatitude").val('');
    $("#txtlongitude").val('');
    $("#SampleMasterID").val(-1);
    $("#SampleSourceMasterID").val(-1);
    $("#AnalysisMasterID").val(-1);
    $("#FarmTypeID").val(-1);
    $("#txtFarmerName").val('');
    $("#LabMasterID").val(-1);
    $("#txtremark").val('');
    $("#tbl-sample-details > tbody").html('');
}

$("#btnClear").click(function (e) {

    clear();
});

//# Region Approval Section

function populateRFCDetail() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllRemark", // Controller/View
            data: { //Passing data
                CertificateID: $("#txtID").val(),
                Remark_Type: "lab_sample"
            },
            success: function (data) {
                // Populate the Table with Fertilizer Certificate List
                populateReviewHistoryGrid(data);
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateReviewHistoryGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-review-history > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        $("#tbl-review-history > tbody:last-child").append("<tr>"

            + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;' > " + data[i].certificateID + "</td >"
            + "<td style = 'display:none;' id = 'tdid' name = 'tdid'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id ='tdcreateddate' name='tdcreateddate'>" + data[i].created_by + "</td>"
            + "<td id='tdremark' name='tdremark'>" + data[i].remark + "</td>"
            + "<td id='tdremark_type' name='tdremark_type'>" + data[i].remark_Type + "</td>"
            + "<td id='created_by_name' name='created_by_name'>" + data[i].created_by_Name + "</td>"
            + "<td id ='tdcreateddate' name='tdcreateddate' style='text-align:center;'>" + data[i].created_date + "</td>"
            + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>");
    }
}

function uploadFiles(inputId) {

    var Id;
    var fileUpload = inputId;

    if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File1_review") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage1_review').css('visibility', 'visible');
            $('#FileImage1_review').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);        
    }

    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);

    if (inputId.id === 'File1_review')
        Id = $("#ReviewID").val();
    else
        Id = $("#txtID").val();

    $.ajax({
        url: RootPath() + "/Api/Upload/UploadProfileLogo?ProjectId=" + Id + "&DocumentType=" + inputId.id,
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {

            if (data1 === undefined) {

                alert("Please, select record to attach docuement");
                return false;

            } else {

                for (i = 0; i < data1.length; i++) {

                    $('#' + data1[i].documentType + '_upload').empty();
                    $('#' + data1[i].documentType + '_success').empty();

                    var data = data1[i];
                    var openlink = RootPath() + "/API/Upload/Download?DocumentId=" + data.id + "&Name=" + data.documentName;

                    var upload = "<div class='position-relative'> <label for=" + data1[i].documentType + "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + data1[i].documentType + " name=" + data1[i].documentType + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                    $('#' + data1[i].documentType + '_upload').append(upload);

                    var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                    $('#' + data1[i].documentType + '_success').append(markup);

                }
            }
        }
    });


}

function populateDocument(id) {

    var keys = [];
    var keysDefault = ["File1_review"];

    $.ajax({
        url: RootPath() + "/Api/Upload/GetDocumentByParent?id=" + id,
        type: 'GET',
        success: function (data1) {

            for (i = 0; i < data1.length; i++) {

                keys.push(data1[i].documentType);

                $('#' + data1[i].documentType + '_upload').empty();
                $('#' + data1[i].documentType + '_success').empty();

                var data = data1[i];
                var openlink = RootPath() + "/API/Upload/Download?DocumentId=" + data.id + "&Name=" + data.documentName;

                var upload = "";
                $('#' + data1[i].documentType + '_upload').append(upload);

                var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                $('#' + data1[i].documentType + '_success').append(markup);

            }
            keysDefault.forEach(function (value) {

                if (keys.indexOf(value) === -1) {

                    $('#' + value + '_upload').empty();
                    $('#' + value + '_success').empty();

                    var upload = "<div class='position-relative'> <label for=" + value + "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + value + " name=" + value + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                    $('#' + value + '_upload').append(upload);

                    var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                    $('#' + value + '_success').append(markup);

                }
            });
        }
    });

}

//# endRegion Approval Section