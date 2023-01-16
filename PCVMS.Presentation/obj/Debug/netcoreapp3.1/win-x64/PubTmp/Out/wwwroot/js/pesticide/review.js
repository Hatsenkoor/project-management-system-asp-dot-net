
$(document).ready(function () {


    $('#pesticide-certificate-review :input').attr("disabled", true);
  
    getAllSectionHeadCertificate();

    $("#tbl-pesticide-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        // this is the code to make the selected row highlighted
        //start
        if ($(this).parent("tr").hasClass('active')) {

            $(this).parents("tr").removeClass("active");
        } else {

            $('#tbl-pesticide-certificate-list > tbody tr.active').removeClass('active');
            $(this).parents("tr").addClass("active");
        }
       //end

        $('#record_screen').show();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();
       
        var id = $(this).parents("tr").find("#tdid").html();
        var certificate_Type_ID = $(this).parents("tr").find("#tdcertificate_Type_ID").html();
        var certificate_Name = $(this).parents("tr").find("#tdcertificate_Name").html();
        var requested_Date = $(this).parents("tr").find("#tdRequested_Date").html();
        var certificate_Request_No = $(this).parents("tr").find("#tdcertificate_Request_No").html();
        var local_Registration_No = $(this).parents("tr").find("#tdlocal_Registration_No").html();
        var trade_Name = $(this).parents("tr").find("#tdTrade_Name").html();
        var chemical_Class = $(this).parents("tr").find("#tdchemical_Class").html();
        var pesticide_Use = $(this).parents("tr").find("#tdpesticide_Use").html();
        var type_Formulation_ID = $(this).parents("tr").find("#tdtype_Formulation_ID").html(); 
        var type_Formulation_Name = $(this).parents("tr").find("#tdtype_Formulation").html();
        var target_Pest = $(this).parents("tr").find("#tdtarget_Pest").html();
        var wHO_Toxicity_Classification_ID = $(this).parents("tr").find("#tdwHO_Toxicity_Classification_ID").html();
        var wHO_Toxicity_Classification_Name = $(this).parents("tr").find("#tdwHO_Toxicity_Classification").html();
        var Target_Crops = $(this).parents("tr").find("#tdTarget_Crops").html();
        var CR_Number = $(this).parents("tr").find("#tdCR_Number").html();
        var registered_Commercial_Activities = $(this).parents("tr").find("#tdRegistered_Commercial_Activities").html();
        var manufacturer_Company = $(this).parents("tr").find("#tdmanufacturer_Company").html();
        var license_Number = $(this).parents("tr").find("#tdlicense_Number").html();
        var Address = $(this).parents("tr").find("#tdAddress").html();
        var Remark = $(this).parents("tr").find("#tdRemark").html();
        var local_Company = $(this).parents("tr").find("#tdlocal_Company").html();
        var status = $(this).parents("tr").find("#tdstatus").html();
        var registrationFee = $(this).parents("tr").find("#tdregistrationFee").html();
        var certificateFee = $(this).parents("tr").find("#tdcertificateFee").html();
        var application_type = $(this).parents("tr").find("#tdapplicationType").html();

        $("#txt_requested_date").val(requested_Date);
        $("#CertificateMasterID").val(certificate_Type_ID);
        $("#Certificate_Name").val(certificate_Name);
        $("#txt_local_registration_no").val(local_Registration_No);
        $("#txt_trade_name").val(trade_Name);
        $("#txt_chemical_class").val(chemical_Class);
        $("#txt_pesticide_use").val(pesticide_Use);
        $("#TypeFormulationMasterID").val(type_Formulation_Name);
        $("#ID").val(id);
        $("#txt_target_pest").val(target_Pest);
        $("#WHOToxicityMasterID").val(wHO_Toxicity_Classification_Name);
        $("#txt_target_crops").val(Target_Crops);
        $("#txt_cr_number").val(CR_Number);
        $("#txt_commercial_activities").val(registered_Commercial_Activities);
        $("#txt_exporter_company").val(manufacturer_Company);
        $("#txt_local_company").val(local_Company);
        $("#txt_license_number").val(license_Number);
        $("#txt_local_company_address").val(Address);
        $("#txt_remark").val(Remark);
        $("#status").val(status);


        $('#additionalDocument').show();

        if (status === 'Director Review' || status === 'Review Application')
            $("#pnlreviewapproval").show();
        else
            $("#pnlreviewapproval").hide();

        if (application_type === 'imported') {

            $('#pnl_imported').show();
            $('#pnl_local').hide();

        }
        else if (application_type === 'local') {

            $('#pnl_imported').hide();
            $('#pnl_local').show();
        }

        getAllCommonName(id);
        //need to check this function
        updateselection(application_type);

        populateMandatoryDocument(selected_id, application_type);

        populateRFCDetail();

    });

    $("#btnApproveCertificate").click(function (e) {

        var nextStatus = "Committee Review";

        if ($("#status").val() === "Director Review")
            nextStatus = "Director Review";

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SectionHeadApproval", // Controller/View
                data: { //Passing data
                    Id: $("#ID").val(),
                    Remark: $("#txtReviewHistory").val(),
                    statusId: nextStatus,
                    // we are using Certificate_Name for Remark_Type
                    Certificate_Name: "application_review"
                },
                success: function (data) {
                    // Populate the Table with Fertilizer Certificate List
                    $("#pnlreviewapproval").hide();
                    populatePesticideGrid(data);
                    populateRFCDetail();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

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
                    Remark_Type: "application_review"
                },
                success: function (data) {
                    // Populate the Table with Fertilizer Certificate List
                    $("#txtReviewHistory").val(''),
                    populateReviewHistoryGrid(data);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });   

});


function getAllSectionHeadCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getAllSectionHeadCertificate", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populatePesticideGrid(data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function updateselection(application_type) {

    if (application_type === 'imported') {

        if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide').show();
            $('#bio-pesticide').hide();
            $('#veterinary-pesticide').hide();
            $('#public-health-pesticide').hide();
            $('#additionalDocument').show();

        }
        else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide').hide();
            $('#bio-pesticide').show();
            $('#veterinary-pesticide').hide();
            $('#public-health-pesticide').hide();
            $('#additionalDocument').show();


        }
        else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide').hide();
            $('#bio-pesticide').hide();
            $('#veterinary-pesticide').show();
            $('#public-health-pesticide').hide();
            $('#additionalDocument').show();


        }
        else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide').hide();
            $('#bio-pesticide').hide();
            $('#veterinary-pesticide').hide();
            $('#public-health-pesticide').show();
            $('#additionalDocument').show();

        }
        else {
            $('#veterinary-pesticide').hide();
            $('#bio-pesticide').hide();
            $('#agriculture-pesticide').hide();
            $('#public-health-pesticide').hide();
            $('#additionalDocument').hide();
        }
    }
    else if (application_type === 'local') {

        if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide-local').show();
            $('#bio-pesticide-local').hide();
            $('#veterinary-pesticide-local').hide();
            $('#public-health-pesticide-local').hide();
            $('#additionalDocument-local').show();

        }
        else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide-local').hide();
            $('#bio-pesticide-local').show();
            $('#veterinary-pesticide-local').hide();
            $('#public-health-pesticide-local').hide();
            $('#additionalDocument-local').show();

        }
        else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide-local').hide();
            $('#bio-pesticide-local').hide();
            $('#veterinary-pesticide-local').show();
            $('#public-health-pesticide-local').hide();
            $('#additionalDocument-local').show();

        }
        else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

            $('#agriculture-pesticide-local').hide();
            $('#bio-pesticide-local').hide();
            $('#veterinary-pesticide-local').hide();
            $('#public-health-pesticide-local').show();
            $('#additionalDocument-local').show();
        }
        else {
            $('#veterinary-pesticide-local').hide();
            $('#bio-pesticide-local').hide();
            $('#agriculture-pesticide-local').hide();
            $('#public-health-pesticide-local').hide();
            $('#additionalDocument-local').hide();
        }

    }
}
function populateMandatoryDocument(selected_id, application_type) {

    var keys = [];

    var keysDefault;

    if (application_type === 'imported') {

        if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452') {

            keysDefault = ["File1_agriculture", "File2_agriculture", "File3_agriculture", "File4_agriculture", "File5_agriculture", "File6_agriculture", "File7_agriculture", "File8_agriculture", "File9_agriculture", "File10_agriculture", "File11_agriculture", "File12_agriculture", "File13_agriculture", "File14_agriculture", "File15_agriculture", "File16_agriculture", "File17_agriculture", "File18_agriculture", "File19_agriculture", "File20_agriculture",
                "File21_agriculture", "File22_agriculture", "File23_agriculture", "File24_agriculture", "File25_agriculture", "File26_agriculture", "File27_agriculture", "File28_agriculture", "File29_agriculture", "File30_agriculture", "File31_agriculture", "File32_agriculture", "File33_agriculture", "File34_agriculture", "File35_agriculture", "File36_agriculture", "File37_agriculture", "File38_agriculture", "File39_agriculture", "File40_agriculture"];


        } else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061') {

            keysDefault = ["File1_bio", "File2_bio", "File3_bio", "File4_bio", "File5_bio", "File6_bio", "File7_bio", "File8_bio", "File9_bio", "File10_bio", "File11_bio", "File12_bio", "File13_bio", "File14_bio", "File15_bio", "File16_bio"];
        }
        else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8') {

            keysDefault = ["File1_veterinary", "File2_veterinary", "File3_veterinary", "File4_veterinary", "File5_veterinary", "File6_veterinary", "File7_veterinary", "File8_veterinary", "File9_veterinary", "File10_veterinary", "File11_veterinary", "File12_veterinary", "File13_veterinary", "File14_veterinary", "File15_veterinary", "File16_veterinary", "File17_veterinary", "File18_veterinary", "File19_veterinary", "File20_veterinary", "File21_veterinary"];

                 }
        else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9') {

            keysDefault = ["File1_health", "File2_health", "File3_health", "File4_health", "File5_health", "File6_health", "File7_health", "File8_health", "File9_health", "File10_health", "File11_health", "File12_health", "File13_health", "File14_health", "File15_health", "File16_health", "File17_health", "File18_health", "File19_health"];
        }

    }
    else if (application_type === 'local') {

        if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452') {

            keysDefault = ["File1_agriculture", "File2_agriculture", "File3_agriculture", "File4_agriculture", "File5_agriculture", "File6_agriculture", "File7_agriculture", "File8_agriculture", "File9_agriculture", "File10_agriculture", "File11_agriculture", "File12_agriculture", "File13_agriculture"];

        }
        else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061') {

            keysDefault = ["File1_bio", "File2_bio", "File3_bio", "File4_bio", "File5_bio", "File6_bio", "File7_bio", "File8_bio", "File9_bio", "File10_bio"];
        }
        else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8') {
            keysDefault = ["File1_veterinary", "File2_veterinary", "File3_veterinary", "File4_veterinary", "File5_veterinary", "File6_veterinary", "File7_veterinary", "File8_veterinary", "File9_veterinary", "File10_veterinary", "File11_veterinary", "File12_veterinary", "File13_veterinary"];

               }
        else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9') {

            keysDefault = ["File1_health", "File2_health", "File3_health", "File4_health", "File5_health", "File6_health", "File7_health", "File8_health", "File9_health", "File10_health", "File11_health", "File12_health"];
        }
    }


    $.ajax({
        url: RootPath() + "/Api/Upload/GetDocumentByParent?id=" + selected_id,
        type: 'GET',
        success: function (data1) {

            if (application_type === 'imported') {

                //# Region Imported Section

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

                        var upload = "";
                        $('#' + value + '_upload').append(upload);

                        var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                        $('#' + value + '_success').append(markup);


                    }
                });

                //# Region Imported Section
            }
            else if (application_type === 'local') {

                //# Region Local Section

                for (i = 0; i < data1.length; i++) {

                    keys.push(data1[i].documentType);

                    $('#' + data1[i].documentType + '_local_success').empty();

                    var data = data1[i];
                    var openlink = RootPath() + "/API/Upload/Download?DocumentId=" + data.id + "&Name=" + data.documentName;

                    var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                    $('#' + data1[i].documentType + '_local_success').append(markup);

                }
                keysDefault.forEach(function (value) {

                    if (keys.indexOf(value) === -1) {

                        $('#' + value + '_local_success').empty();

                        var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                        $('#' + value + '_local_success').append(markup);


                    }
                });

                //# Region Local Section
            }
        }
    });

}

function populatePesticideGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-pesticide-certificate-list > tbody").html('');

    if (data.length > 0) {
        $('#no_record_screen').hide();   
    }
    else {
        $('#record_screen').hide()
        $('#no_record_screen').show();
    }

    for (var i = 0; i < data.length; i++) {
        

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdapplicationType' name='tdapplicationType'>" + data[i].application_Type + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificate_Type_ID' name='tdcertificate_Type_ID'>" + data[i].certificate_Type_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdregistrationFee' name='tdregistrationFee'>" + data[i].registrationFee + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificateFee' name='tdcertificateFee'>" + data[i].certificateFee + "</td>"
            + "<td style = 'display:none;' id = 'tdRequested_Date' name = 'tdRequested_Date' style = 'text-align:center;'>" + data[i].requested_Date + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificate_Request_No' name = 'tdcertificate_Request_No' style = 'text-align:center;'>" + data[i].certificate_Request_No + "</td>"
            + "<td style ='display:none;'  id = 'tdlocal_Registration_No' name='tdlocal_Registration_No'>" + data[i].local_Registration_No + "</td>"
            + "<td style = 'display:none;' id = 'tdTrade_Name' name = 'tdTrade_Name' style = 'text-align:center;'>" + data[i].trade_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdchemical_Class' name = 'tdchemical_Class' style = 'text-align:center;'>" + data[i].chemical_Class + "</td>"
            + "<td style = 'display:none;' id = 'tdpesticide_Use' name = 'tdpesticide_Use' style = 'text-align:center;'>" + data[i].pesticide_Use + "</td>"
            + "<td style = 'display:none;' id = 'tdtype_Formulation_ID' name = 'tdtype_of_Formulation_ID' style = 'text-align:center;'>" + data[i].type_Formulation_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdtype_Formulation' name = 'tdtype_of_Formulation' style = 'text-align:center;'>" + data[i].type_Formulation + "</td>"
            + "<td style = 'display:none;' id = 'tdtarget_Pest' name = 'tdtarget_Pest' style = 'text-align:center;'>" + data[i].target_Pest + "</td>"
            + "<td style ='display:none;'  id = 'tdwHO_Toxicity_Classification_ID' name='tdwHO_Toxicity_Classification_ID'>" + data[i].whO_Toxicity_Classification_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdwHO_Toxicity_Classification' name='tdwHO_Toxicity_Classification'>" + data[i].whO_Toxicity_Classification + "</td>"
            + "<td style = 'display:none;' id = 'tdTarget_Crops' name = 'tdTarget_Crops' style = 'text-align:center;'>" + data[i].target_Crops + "</td>"
            + "<td style = 'display:none;' id = 'tdCR_Number' name = 'tdCR_Number' style = 'text-align:center;'>" + data[i].cR_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistered_Commercial_Activities' name = 'tdRegistered_Commercial_Activities' style = 'text-align:center;'>" + data[i].registered_Commercial_Activities + "</td>"
            + "<td style = 'display:none;' id = 'tdmanufacturer_Company' name = 'tdmanufacturer_Company' style = 'text-align:center;'>" + data[i].manufacturer_Company + "</td>"
            + "<td style = 'display:none;' id = 'tdlicense_Number' name = 'tdlicense_Number' style = 'text-align:center;'>" + data[i].license_Number + "</td>"
            + "<td style = 'display:none;' id = 'tdAddress' name = 'tdAddress' style = 'text-align:center;'>" + data[i].address + "</td>"
            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td id = 'tdcertificate_Name' name='tdcertificate_Name'>" + data[i].certificate_Name + "</td>"
            + "<td id ='tdlocal_Company' name='tdlocal_Company'>" + data[i].local_Company + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"
            + "<td class='text-left' id = 'tdAction' name = 'tdAction'> <div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td ></tr>";

            // addpend the final string
            $("#tbl-pesticide-certificate-list > tbody:last-child").append(tempString);

    }
}

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
                $("#txtReviewHistory").val(''),
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

function getAllCommonName(ID) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getAllCommonName", // Controller/View
            data: { //Passing data
                CertificateID: $("#ID").val()
            },
            success: function (data) {
                // Populate the Table with Fertilizer Certificate List
                populateCommonNameGrid(data);
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateCommonNameGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-common-name-concentration > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        $("#tbl-common-name-concentration > tbody:last-child").append("<tr>"

            + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;' > " + data[i].certificateID + "</td >"
            + "<td style = 'display:none;' id='created_by_name' name='created_by_name'>" + data[i].created_by_Name + "</td>"
            + "<td style = 'display:none;' id ='tdcreateddate' name='tdcreateddate' style='text-align:center;'>" + data[i].created_date + "</td>"
            + "<td style = 'display:none;' id ='tdCommon_Name_ID' name='tdCommon_Name_ID'>" + data[i].common_Name_ID + "</td>"
            + "<td id = 'tdid' name = 'tdid'>" + data[i].id + "</td>"
            + "<td id='tdCommon_Name' name='tdCommon_Name'>" + data[i].common_Name + "</td>"
            + "<td id='tdActive_Ingredient' name='tdActive_Ingredient'>" + data[i].active_Ingredient + "</td>"
            + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>");
    }
}