
$(document).ready(function () {

    $('#fertilizer-certificate-cancellation-request :input').attr("disabled", true);
    $('#fertilizer-certificate-cancellation-request-hide').hide();
  
    getAllCancelCertificate();

    //# Region General Function

    $("#tbl-fertilizer-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        $('#fertilizer-certificate-cancellation-request-hide').show();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();

        var id = $(this).parents("tr").find("#tdid").html();
        var Requested_Date = $(this).parents("tr").find("#tdRequested_Date").html();
        var Registration_Request_No = $(this).parents("tr").find("#tdRegistration_Request_No").html();
        var Local_Certificate_Registration_No = $(this).parents("tr").find("#tdLocal_Certificate_Registration_No").html();
        var Scientific_Name = $(this).parents("tr").find("#tdScientific_Name").html();
        var Trade_Name = $(this).parents("tr").find("#tdTrade_Name").html();
        var Nature_Shape_ID = $(this).parents("tr").find("#tdNature_Shape_ID").html();
        var Nature_Shape = $(this).parents("tr").find("#tdNature_Shape").html();
        var Density_Concentration = $(this).parents("tr").find("#tdDensity_Concentration").html();
        var PH_Concentration = $(this).parents("tr").find("#tdPH_Concentration").html();
        var Manufacturer = $(this).parents("tr").find("#tdManufacturer").html();
        var Manufacturer_Address = $(this).parents("tr").find("#tdManufacturer_Address").html();
        var Exporting_Company = $(this).parents("tr").find("#tdExporting_Company").html();
        var Manufacturing_Country = $(this).parents("tr").find("#tdManufacturing_Country").html();
        var Exporting_Company_Address = $(this).parents("tr").find("#tdExporting_Company_Address").html();
        var CR_Number = $(this).parents("tr").find("#tdCR_Number").html();
        var Registered_Commercial_Activities = $(this).parents("tr").find("#tdRegistered_Commercial_Activities").html();
        var Import_Export_License_Number = $(this).parents("tr").find("#tdImport_Export_License_Number").html();
        var Address = $(this).parents("tr").find("#tdAddress").html();
        var Remark = $(this).parents("tr").find("#tdRemark").html();
        var Company_Licensed_Import_Export_Trade = $(this).parents("tr").find("#tdCompany_Licensed_Import_Export_Trade").html();
        var status = $(this).parents("tr").find("#tdstatus").html();
        var registrationFee = $(this).parents("tr").find("#tdregistrationFee").html();
        var application_Type = $(this).parents("tr").find("#tdapplication_Type").html();
        var CancelReason = $(this).parents("tr").find("#tdCancelReason").html();

        $("#txt_requested_date").val(Requested_Date);
        $("#ID").val(id);
        $("#txt_local_registration_no").val(Local_Certificate_Registration_No);
        $("#txt_scientific_name").val(Scientific_Name);
        $("#txt_trade_name").val(Trade_Name);
        $("#IsLiquidForm").val(Nature_Shape_ID);
        $("#txt_density_concentration").val(Density_Concentration);
        $("#txt_ph_concentration").val(PH_Concentration);
        $("#txt_manufacturer").val(Manufacturer);
        $("#txt_manufacturer_address").val(Manufacturer_Address);
        $("#txt_exporting_company").val(Exporting_Company);
        $("#txt_manufacturing_country").val(Manufacturing_Country);
        $("#txt_exporting_company_address").val(Exporting_Company_Address);
        $("#txt_cr_number").val(CR_Number);
        $("#txt_registered_commercial_activities").val(Registered_Commercial_Activities);
        $("#txt_company_licensed_import_export_trade").val(Company_Licensed_Import_Export_Trade);
        $("#txt_import_export_license_number").val(Import_Export_License_Number);
        $("#txt_address").val(Address);
        $("#txt_remark").val(Remark);
        $("#txtcancellationreason").val(CancelReason);
        $("#status").val(status);

        if (status === 'Issued')
        {
            $('#pnlCancelRequest').show();
            $('#txtcancellationreason').prop("disabled", false);           
        }
        else {
            $('#pnlCancelRequest').hide();
            $('#txtcancellationreason').prop("disabled", true);           
        }

        if (status === 'Request Certificate Cancel')
            $('#pnlreviewapproval').show();
        else
            $('#pnlreviewapproval').hide();



        if (application_Type === 'local')
            $('#imported_section').hide();
        else {

            $('#imported_section').show();
        }


        populateRFCDetail("cancel_certificate");

    });

    $("#btnRequestCertificateCancel").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "RequestCertificateCancel", // Controller/View
                data: { //Passing data
                    Id: $("#ID").val(),
                    CancelReason: $("#txtcancellationreason").val(),
                    statusId: "Request Certificate Cancel"
                },
                success: function (data) {
                    // Populate the Table with Fertilizer Certificate List
                    populateFertilizerGrid(data);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    //# end Region General Function 


    //# Region Cancel Certificate

    $("#tbl-review-history > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        var event = $(this)[0].title;
        var reviewid = $(this).parents("tr").find("#tdid").html();

        var remark = $(this).parents("tr").find("#tdremark").html();
        $("#ReviewID").val(reviewid);
        $("#txtReviewHistory").val(remark);

        populateReviewDocument(reviewid)

    });

    $("#btnRFCCertificate").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveRemark", // Controller/View
                data: { //Passing data
                    CertificateID: $("#ID").val(),
                    Remark: $("#txtReviewHistory").val(),
                    Remark_Type: "cancel_certificate"
                },
                success: function (data) {
                    // Populate the Table with Fertilizer Certificate List
                    Remark: $("#txtReviewHistory").val(''),
                        populateReviewHistoryGrid(data);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    //# end Region Cancel Cerificate

});

//# Region GENERAL Function
function getAllCancelCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getAllCancelCertificate", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populateFertilizerGrid(data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateFertilizerGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-fertilizer-certificate-list > tbody").html('');

    if (data.length > 0) {
        $('#no_record_screen').hide();
        $('#record_screen').show();
    }
    else {

        $('#record_screen').hide();
        $('#no_record_screen').show();
    }


    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
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

            + "<td style = 'display:none;' id = 'tdCancelReason' name = 'tdCancelReason' style = 'text-align:center;'>" + data[i].cancelReason + "</td>"

            + "<td style = 'display:none;' id = 'tdImport_Export_License_Number' name = 'tdImport_Export_License_Number' style = 'text-align:center;'>" + data[i].import_Export_License_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdAddress' name = 'tdAddress' style = 'text-align:center;'>" + data[i].address + "</td>"
            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].company_Licensed_Import_Export_Trade + "</td>"
            + "<td id = 'tdManufacturer' name = 'tdManufacturer' style = 'text-align:center;'>" + data[i].manufacturer + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"
            + "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

          // addpend the final string
        $("#tbl-fertilizer-certificate-list > tbody:last-child").append(tempString);

        if (data[i].statusId === 'Issued') {
            $('#pnlCancelRequest').show();
            $('#txtcancellationreason').prop("disabled", false);
        }
        else {
            $('#pnlCancelRequest').hide();
            $('#txtcancellationreason').prop("disabled", true);
        }

        if (data[i].application_Type === 'local')
            $('#imported_section').hide();
        else {

            $('#imported_section').show();
        }

    }
}

//# endRegion GENERAL FUNCTION

//# Region Cancel Approval Section

function populateRFCDetail(remark_type) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllRemark", // Controller/View
            data: { //Passing data
                CertificateID: $("#ID").val(),
                Remark_Type: remark_type
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

    if (data.length > 0)
        $('#fertilizer-certificate-cancel-approval').show();
    else
        $('#fertilizer-certificate-cancel-approval').hide();

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
        Id = "&Id=" + $("#Image1_review").val();
    }

    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);

    $.ajax({
        url: RootPath() + "/Api/Upload/UploadProfileLogo?ProjectId=" + $("#ReviewID").val() + "&DocumentType=" + inputId.id,
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

function populateReviewDocument(reviewid) {

    var keys = [];
    var keysDefault = ["File1_review"];

    $.ajax({
        url: RootPath() + "/Api/Upload/GetDocumentByParent?id=" + reviewid,
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

//# endRegion Cancel Approval Section
