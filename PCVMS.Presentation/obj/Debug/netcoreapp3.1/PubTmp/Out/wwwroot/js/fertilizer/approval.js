
$(document).ready(function () {

    //# Region Page Download Section

    getAllApprovedCertificate();

    //# endRegion Page Download Section

    $("#tbl-fertilizer-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        $('#record_screen').show();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();

        var id = $(this).parents("tr").find("#tdid").html();
        var Requested_Date = $(this).parents("tr").find("#tdRequested_Date").html();
        var Registration_Request_No = $(this).parents("tr").find("#tdRegistration_Request_No").html();
        var Local_Certificate_Registration_No = $(this).parents("tr").find("#tdLocal_Certificate_Registration_No").html();
        var Scientific_Name = $(this).parents("tr").find("#tdScientific_Name").html();
        var Trade_Name = $(this).parents("tr").find("#tdTrade_Name").html();
        var Nature_Shape_Color_of_fertilizer = $(this).parents("tr").find("#tdNature_Shape_Color_of_fertilizer").html();
        var Container_specification = $(this).parents("tr").find("#tdContainer_specification").html();
        var Manufacturer = $(this).parents("tr").find("#tdManufacturer").html();
        var Manufacturer_Address = $(this).parents("tr").find("#tdManufacturer_Address").html();
        var Exporting_Company = $(this).parents("tr").find("#tdExporting_Company").html();
        var Manufacturing_Country = $(this).parents("tr").find("#tdManufacturing_Country").html();
        var Exporting_Company_Address = $(this).parents("tr").find("#tdExporting_Company_Address").html();
        var CR_Number = $(this).parents("tr").find("#tdCR_Number").html();
        var Registered_Commercial_Activities = $(this).parents("tr").find("#tdRegistered_Commercial_Activities").html();
        var Import_Export_License_Number = $(this).parents("tr").find("#tdImport_Export_License_Number").html();
        var Address = $(this).parents("tr").find("#tdAddress").html();
        var Possibility_to_mix_Fertilizer = $(this).parents("tr").find("#tdPossibility_to_mix_Fertilizer").html();
        var Possibility_to_mix_Pesticide = $(this).parents("tr").find("#tdPossibility_to_mix_Pesticide").html();
        var Remark = $(this).parents("tr").find("#tdRemark").html();
        var Company_Licensed_Import_Export_Trade = $(this).parents("tr").find("#tdCompany_Licensed_Import_Export_Trade").html();
        var status = $(this).parents("tr").find("#tdstatus").html();
        var registrationFee = $(this).parents("tr").find("#tdregistrationFee").html();

        $("#ID").val(id);

        if (status === 'Director Review')
            $("#pnlreviewapproval").show();
        else
            $("#pnlreviewapproval").hide();


        populateRFCDetail();

    });


    //# Region Review Section

    $("#tbl-review-history > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        var event = $(this)[0].title;
        var reviewid = $(this).parents("tr").find("#tdid").html();

        var remark = $(this).parents("tr").find("#tdremark").html();
        $("#ReviewID").val(reviewid);
        $("#txtReviewHistory").val(remark);

        populateReviewDocument(reviewid)

    });

    $("#btnApproveCertificate").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "DirectorApproval", // Controller/View
                data: { //Passing data
                    Id: $("#ID").val(),
                    Remark: $("#txtReviewHistory").val(),
                    statusId: "Approved",
                    // we are using Application_Type for Remark_Type
                    Application_Type: "application_review"
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

    $("#btnRFCCertificate").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveRemark", // Controller/View
                data: { //Passing data
                    CertificateID: $("#ID").val(),
                    Remark: $("#txtReviewHistory").val(),
                    Remark_Type: "application_review"
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

    //# endRegion Review Section

});

//# Region Page Download Section

function getAllApprovedCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getAllApprovedCertificate", // Controller/View
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
            + "<td style ='display:none;'  id = 'tdNature_Shape_Color_of_fertilizer' name='tdNature_Shape_Color_of_fertilizer'>" + data[i].nature_Shape_Color_of_fertilizer + "</td>"
            + "<td style = 'display:none;' id = 'tdContainer_specification' name = 'tdContainer_specification' style = 'text-align:center;'>" + data[i].container_specification + "</td>"
            + "<td style='display:none;'   id = 'tdManufacturer_Address' name='tdManufacturer_Address'>" + data[i].manufacturer_Address + "</td>"

            + "<td style = 'display:none;' id = 'tdExporting_Company' name = 'tdExporting_Company' style = 'text-align:center;'>" + data[i].exporting_Company + "</td>"
            + "<td style = 'display:none;' id = 'tdManufacturing_Country' name = 'tdManufacturing_Country' style = 'text-align:center;'>" + data[i].manufacturing_Country + "</td>"
            + "<td style ='display:none;'  id = 'tdExporting_Company_Address' name='tdExporting_Company_Address'>" + data[i].exporting_Company_Address + "</td>"
            + "<td style = 'display:none;' id = 'tdCR_Number' name = 'tdCR_Number' style = 'text-align:center;'>" + data[i].cR_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistered_Commercial_Activities' name = 'tdRegistered_Commercial_Activities' style = 'text-align:center;'>" + data[i].registered_Commercial_Activities + "</td>"


            + "<td style = 'display:none;' id = 'tdImport_Export_License_Number' name = 'tdImport_Export_License_Number' style = 'text-align:center;'>" + data[i].import_Export_License_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdAddress' name = 'tdAddress' style = 'text-align:center;'>" + data[i].address + "</td>"
            + "<td style ='display:none;'  id ='tdPossibility_to_mix_Fertilizer' name='tdPossibility_to_mix_Fertilizer'>" + data[i].possibility_to_mix_Fertilizer + "</td>"
            + "<td style = 'display:none;' id = 'tdPossibility_to_mix_Pesticide' name = 'tdPossibility_to_mix_Pesticide' style = 'text-align:center;'>" + data[i].possibility_to_mix_Pesticide + "</td>"
            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].company_Licensed_Import_Export_Trade + "</td>"
            + "<td id = 'tdManufacturer' name = 'tdManufacturer' style = 'text-align:center;'>" + data[i].manufacturer + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"
            + "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-fertilizer-certificate-list > tbody:last-child").append(tempString);
    }
}

//# endRegion Page Download Section


//# Region Approval Section

function populateRFCDetail() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllRemark", // Controller/View
            data: { //Passing data
                CertificateID: $("#ID").val(),
                Remark_Type: "application_review"
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

//# endRegion Approval Section