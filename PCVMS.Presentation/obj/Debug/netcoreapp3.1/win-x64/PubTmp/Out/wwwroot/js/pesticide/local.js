
$(document).ready(function () {

getAllCertificate("local");  

//#region General Section

    $("#btnSavePesticide").click(function (e) {

        autonumber();

        var error = validatedetailscreen();

        if (error.length > 0) {

            $('#validationresult').empty();

            $('#validationresult').html("<ul>" + error + "</ul>");

            $(".pop-outer").fadeIn("slow");

            return true;
        }
     
        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveCertificate", // Controller/View
                data: { //Passing data
                
                    Certificate_Type_ID: $("#CertificateMasterID").val(),
                    Certificate_Name: $("#CertificateMasterID option:selected").text(),
                    Pesticide_Use_ID: $("#PesticideUseMasterID").val(),
                    Pesticide_Use: $("#PesticideUseMasterID option:selected").text(),
                    Requested_Date: $("#txt_requested_date").val(), //Reading text box values using Jquery
                    Certificate_Request_No: $("#ID").val(),                  
                    ID: $("#ID").val(),
                    Local_Registration_No: $("#txt_local_registration_no").val(),
                    Trade_Name: $("#txt_trade_name").val(),
                    Chemical_Class: $("#txt_chemical_class").val(),                  
                    Type_Formulation_ID: $("#TypeFormulationMasterID").val(),
                    Type_Formulation: $("#TypeFormulationMasterID option:selected").text(),
                    Target_Pest: $("#txt_target_pest").val(),
                    WHO_Toxicity_Classification_ID: $("#WHOToxicityMasterID").val(),
                    WHO_Toxicity_Classification: $("#WHOToxicityMasterID option:selected").text(),
                    Target_Crops: $("#txt_target_crops").val(),
                    CR_Number: $("#txt_cr_number").val(),
                    Registered_Commercial_Activities: $("#txt_commercial_activities").val(), 
                    Manufacturer_Company: $("#txt_exporter_company").val(),
                    Local_Company: $("#txt_local_company").val(),
                    License_Number: $("#txt_license_number").val(),
                    Address: $("#txt_local_company_address").val(),
                    Remark: $("#txt_remark").val(),
                    Application_Type: "local"
                },
                success: function (data) {

                    if (data === 'failed') {
                        alert("failed, try again!!");
                        return false;
                    }                       

                    // Populate the Table with Fertilizer Certificate List
                    $("#ID").val(data);
                    getAllCertificate("local");
                    updateselection();
                    //clear the common name list blank
                    $("#commonnamemaster").val(-1);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $("#btnCommonNameMaster").click(function (e) {

        var error = validateCommonNameScreen();

        if (error.length > 0) {

            $('#validationresult').empty();

            $('#validationresult').html("<ul>" + error + "</ul>");

            $(".pop-outer").fadeIn("slow");

            return true;
        }

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "saveCommonName", // Controller/View
                data: { //Passing data
                    CertificateID: $("#ID").val(),
                    Common_Name_ID: $("#commonnamemaster").val(),
                    Common_Name: $("#commonnamemaster option:selected").text(),
                    Active_Ingredient: $("#txt_active_ingredient").val(),
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List                   
                    getAllCommonName($("#ID").val());

                    // to clear Common Name Section
                    $("#txt_active_ingredient").val('');
                    $("#commonnamemaster").val(-1);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    // to clear Common Name Section
                    $("#txt_active_ingredient").val('');
                    $("#commonnamemaster").val(-1);
                }

            });

        e.preventDefault();

    });

    $("#btnfinalSubmission").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SubmitCertificate", // Controller/View
                data: { //Passing data
                    Id: $("#ID").val(),
                    statusId: "Submitted"
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List

                   var length;

                    if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452' || $('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8')
                        length = 13;
                    else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061')
                        length = 10;
                    else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9')
                        length = 12;
                  

                    getAllCertificate("local");
                    finalsubmissionstatuschange(length, 'Submitted', 'edit');
                    paynowstatuschange($("#ID").val(), 'Submitted');                   
                    populateMandatoryDocument($("#ID").val(), 'Submitted', 'edit');

                    $("#Pesticide_Certificate_Details :input").attr("disabled", true);
                    $("#btnSavePesticide").prop("disabled", true);
                    $("#btnClear").prop("disabled", true);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    //$("#btnRegistrationFee").click(function (e) {

    //    $.ajax(
    //        {
    //            type: "POST", //HTTP POST Method
    //            url: "RegistrationFee", // Controller/View
    //            data: { //Passing data
    //                Id: $("#ID").val(),
    //                RegistrationFee: true,
    //                statusId: "Review Application"
    //            },
    //            success: function (data) {

    //                // Populate the Table with Fertilizer Certificate List
    //                getAllCertificate("local");
    //                paynowstatuschange($("#ID").val(), 'Review Application');
    //            },
    //            error: function (xhr) {
    //                alert(xhr.responseText + xhr.statusText);
    //            }

    //        });

    //    e.preventDefault();

    //});

    $("#btnRegistrationFee").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePayment", // Controller/View
                data: { //Passing data
                    AppID: $("#ID").val(),
                    PaymentType: "Pesticide_Local_Registration_Fee"
                },
                success: function (data) {

                    // window.location.href = RootPath() + "/Checkout/index?Id=556677881" + "&amount=" + $("#txtamount").text();
                    window.location.href = RootPath() + "/Checkout/index?Id=" + data + "&AppID=" + $("#ID").val() + "&amount=" + $("#txtamount").text() + "&paymentType=Pesticide_Local_Registration_Fee";

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                }

            });

        e.preventDefault();

    });

    //$('#tbl-pesticide-certificate-list tbody').on('click', 'tr', function () {
    //    if ($(this).hasClass('active')) {
    //        $(this).removeClass('active');
    //    } else {
    //        table.$('tr.active').removeClass('active');
    //        $(this).addClass('active');
    //    }
       
    //});
   
    $("#tbl-pesticide-certificate-list > tbody").on("click", "tr td i", function (evt) {

        
        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();

        // this is the code to make the selected row highlighted
        //start
        if ($(this).parent("tr").hasClass('active')) {
          
            $(this).parents("tr").removeClass("active");
        } else {
           
            $('#tbl-pesticide-certificate-list > tbody tr.active').removeClass('active');
            $(this).parents("tr").addClass("active");
        }
       //end

        if (event === 'view') {

            $("#Pesticide_Certificate_Details :input").attr("disabled", true);
            $("#btnSavePesticide").prop("disabled", true);
            $("#btnClear").prop("disabled", true);
              
        }
        else if (event === 'edit')
        {
            $("#Pesticide_Certificate_Details :input").attr("disabled", false);
            $("#btnSavePesticide").prop("disabled", false);
            $("#btnClear").prop("disabled", false);         
          
        }
        else if (event === 'delete')
        {
            alert("Delete: not allowed");
            return false;
        }

        var id = $(this).parents("tr").find("#tdid").html();
        var certificate_Type_ID = $(this).parents("tr").find("#tdcertificate_Type_ID").html();
        var certificate_Name = $(this).parents("tr").find("#tdcertificate_Name").html();
        var requested_Date = $(this).parents("tr").find("#tdRequested_Date").html();
        var certificate_Request_No = $(this).parents("tr").find("#tdcertificate_Request_No").html();
        var local_Registration_No = $(this).parents("tr").find("#tdlocal_Registration_No").html();       
        var trade_Name = $(this).parents("tr").find("#tdTrade_Name").html();  
        var chemical_Class = $(this).parents("tr").find("#tdchemical_Class").html();
        var pesticide_Use_ID = $(this).parents("tr").find("#tdpesticide_Use_ID").html();
        var pesticide_Use = $(this).parents("tr").find("#tdpesticide_Use").html();       
        var type_Formulation_ID = $(this).parents("tr").find("#tdtype_Formulation_ID").html();
        var target_Pest = $(this).parents("tr").find("#tdtarget_Pest").html();
        var wHO_Toxicity_Classification_ID = $(this).parents("tr").find("#tdwHO_Toxicity_Classification_ID").html();
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
       
        $("#txt_requested_date").val(requested_Date);
        $("#CertificateMasterID").val(certificate_Type_ID);
        $("#txt_local_registration_no").val(local_Registration_No);
        $("#txt_trade_name").val(trade_Name);
        $("#txt_chemical_class").val(chemical_Class);
        $("#PesticideUseMasterID").val(pesticide_Use_ID);
        $("#TypeFormulationMasterID").val(type_Formulation_ID);
        $("#ID").val(id);
        $("#txt_target_pest").val(target_Pest);
        $("#WHOToxicityMasterID").val(wHO_Toxicity_Classification_ID);
        $("#txt_target_crops").val(Target_Crops);
        $("#txt_cr_number").val(CR_Number);
        $("#txt_commercial_activities").val(registered_Commercial_Activities);
        $("#txt_exporter_company").val(manufacturer_Company);
        $("#txt_local_company").val(local_Company);
        $("#txt_license_number").val(license_Number);
        $("#txt_local_company_address").val(Address);
        $("#txt_remark").val(Remark);

        $('#additionalDocument').show();

        //need to check this function
        updateselection();
        getAllCommonName(id);
        populateMandatoryDocument(selected_id, status, event);       
        paynowstatuschange(id, status);
        populateRFCDetail();

        if (status === 'Review Application')
            $("#pnlreviewapproval").show();
        else
            $("#pnlreviewapproval").hide();

        // to clear Common Name Section
        $("#txt_active_ingredient").val('');
        $("#commonnamemaster").val(-1);
       
    });

//#endregion General Section

//#region Review Section

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
                    Remark: $("#txtReviewHistory").val(''),
                        populateReviewHistoryGrid(data);
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

//#endregion Review Section   

//#region MISC SECTION

    $("#btnClear").click(function (e) {

        clear();
    });

    // Datepicker for Pesticide Certificate
    $('[data-toggle="datepicker_trigger_txt_requested_date"]').datepicker({
        trigger: ".datepicker-click-pesticidecertificatedate",
        autoPick: true,
        autoHide: true
    });

    //#endregion

//#region AUTO NUMBER

    $(document).on('change', '.pesticide-number', function (e) {

        autonumber();

    });


//#endregion AUTO NUMBER


    $("#btncallmoci").click(function (e) {


        var crnumber = $('#txt_cr_number').val();

        if (!crnumber.match(/^\d+$/)) {

            alert("Please, enter valid CR Number");
            return false;
        }

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "GetMociCompany?CRNumber=" + $("#txt_cr_number").val(), // Controller/View
                success: function (data) {

                    if (data.mociCompanyRoot.wsResponseBody.companyOverview.address.state.nameEn.indexOf("Error") === -1) {

                        $("#txt_local_company").val(data.mociCompanyRoot.wsResponseBody.companyOverview.companyNameArabic);
                        // Populate the Table with Fertilizer Certificate List
                        var activities = data.mociCompanyRoot.wsResponseBody.companyOverview.declaredActivities.activity;

                        var html = $.map(activities, function (lcn) {
                            return '<option value="' + lcn.isicCode + '">' + lcn.nameEn + '</option>'
                        }).join('');

                        html = "<option value=''>select activity</option> " + html;

                        $('#txt_commercial_activities').html(html);
                    } else {
                        alert(data.mociCompanyRoot.wsResponseBody.companyOverview.address.state.nameEn);
                    }

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

});

//#region General Function

function getAllCertificate(Application_Type) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllCertificate?application_type=" + Application_Type, // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populatePesticideGrid(data);
               
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populatePesticideGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-pesticide-certificate-list > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdcertificate_Type_ID' name='tdcertificate_Type_ID'>" + data[i].certificate_Type_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdpesticide_Use_ID' name='tdpesticide_Use_ID'>" + data[i].pesticide_Use_ID + "</td>"
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
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>";

         if (data[i].statusId !== "Saved")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";
        else
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-pesticide-certificate-list > tbody:last-child").append(tempString);

    }
}

function updateselection() {


    if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

        $('#veterinary-pesticide').hide();
        $('#bio-pesticide').hide();
        $('#agriculture-pesticide').show();
        $('#public-health-pesticide').hide();
        $('#additionalDocument').show();

    }
    else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

        $('#veterinary-pesticide').hide();
        $('#bio-pesticide').show();
        $('#agriculture-pesticide').hide();
        $('#public-health-pesticide').hide();
        $('#additionalDocument').show();

    }
    else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8' && $("#ID").val() !== undefined && $("#ID").val() !== '') {
        $('#veterinary-pesticide').show();
        $('#bio-pesticide').hide();
        $('#agriculture-pesticide').hide();
        $('#public-health-pesticide').hide();
        $('#additionalDocument').show();

    }
    else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9' && $("#ID").val() !== undefined && $("#ID").val() !== '') {

        $('#veterinary-pesticide').hide();
        $('#bio-pesticide').hide();
        $('#agriculture-pesticide').hide();
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

function paynowstatuschange(id, status)
{
    //check if payment is pending
   if ($("#ID").val() === id && status == "Submitted") {

        $("#pnlRegistrationFee").show();

    } else {
        $("#pnlRegistrationFee").hide();
    }
}

function finalsubmissionstatuschange(length, status, event) {

    if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452' && length === 13 && status === "Saved" && event === 'edit') {

        $('#pnlfinalSubmission').show();

    }
    else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061' && length === 10 && status === "Saved" && event === 'edit') {

        $('#pnlfinalSubmission').show();

    }
    else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8' && length === 13 && status === "Saved" && event === 'edit') {
        $('#pnlfinalSubmission').show();
    }
    else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9' && length === 12 && status === "Saved" && event === 'edit') {
        $('#pnlfinalSubmission').show();
    }
    else {
        $('#pnlfinalSubmission').hide();
    }

}

//#endregion General Fucntion

//#region Misc Section

function clear() {
    
    $("#txt_requested_date").val(today());
    $("#CertificateMasterID").val(-1);
    $("#txt_local_registration_no").val('');
    $("#txt_trade_name").val('');
    $("#txt_chemical_class").val('');
    $("#PesticideUseMasterID").val(-1); 
    $("#TypeFormulationMasterID").val(-1);
    $("#ID").val(0);
    $("#txt_target_pest").val('');
    $("#WHOToxicityMasterID").val(-1);
    $("#txt_target_crops").val('');
    $("#txt_cr_number").val('');
    $("#txt_commercial_activities").val('');
    $("#txt_exporter_company").val('');
    $("#txt_local_company").val('');
    $("#txt_license_number").val('');
    $("#txt_local_company_address").val('');
    $("#txt_remark").val('');
    $("#txt_active_ingredient").val('');
    $("#commonnamemaster").val(-1);
    
    $('#veterinary-pesticide').hide();
    $('#bio-pesticide').hide();
    $('#agriculture-pesticide').hide();
    $('#public-health-pesticide').hide();
    $('#additionalDocument').hide();
}

function today() {

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    return today = mm + '/' + dd + '/' + yyyy;
}

function autonumber()
{
    var substring = $("#PesticideUseMasterID option:selected").text();
    var today = new Date();
    var yyyy = today.getFullYear();
    var certificate = '';

    if ($("#CertificateMasterID").val() === 'f63e1520-fa16-491b-82d3-7daa486fa452')
        certificate = 'A';
    else if ($("#CertificateMasterID").val() === 'a3cb9d3c-bccd-400e-99e8-a353edb2e061')
        certificate = 'B';
    else if ($("#CertificateMasterID").val() === '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8')
        certificate = 'V';
    else if ($("#CertificateMasterID").val() === 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9')
        certificate = 'P';


    var temp = certificate + '-' + substring.substring(substring.indexOf("-") + 1) + '-' + yyyy;
    $('#txt_local_registration_no').val(temp);

}

//#endregion Misc Section

//#region Review Section

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

    if (data.length > 0)
        $('#pesticide-certificate-review-approval').show();
    else
        $('#pesticide-certificate-review-approval').hide();



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

function uploadReviewFiles(inputId) {

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
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + data1[i].documentType + " name=" + data1[i].documentType + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadReviewFiles(this);'/>";
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
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + value + " name=" + value + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadReviewFiles(this);'/>";
                    $('#' + value + '_upload').append(upload);

                    var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                    $('#' + value + '_success').append(markup);

                }
            });
        }
    });

}

//#endregion Review Section

//#region Document File upload

function uploadFiles(inputId) {

    var Id;
    var fileUpload = inputId;

    if ($('#CertificateMasterID').val() == 'f63e1520-fa16-491b-82d3-7daa486fa452') {
        if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File1_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage1_agriculture').css('visibility', 'visible');
                $('#FileImage1_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image1_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File2_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage2_agriculture').css('visibility', 'visible');
                $('#FileImage2_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image2_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File3_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage3_agriculture').css('visibility', 'visible');
                $('#FileImage3_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image3_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File4_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage4_agriculture').css('visibility', 'visible');
                $('#FileImage4_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image4_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File5_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage5_agriculture').css('visibility', 'visible');
                $('#FileImage5_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image5_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File6_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage6_agriculture').css('visibility', 'visible');
                $('#FileImage6_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image6_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File7_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage7_agriculture').css('visibility', 'visible');
                $('#FileImage7_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image7_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File8_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage8_agriculture').css('visibility', 'visible');
                $('#FileImage8_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image8_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File9_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage9_agriculture').css('visibility', 'visible');
                $('#FileImage9_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image9_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File10_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage10_agriculture').css('visibility', 'visible');
                $('#FileImage10_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image10_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File11_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage11_agriculture').css('visibility', 'visible');
                $('#FileImage11_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image11_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File12_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage12_agriculture').css('visibility', 'visible');
                $('#FileImage12_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image12_agriculture").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File13_agriculture") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage13_agriculture').css('visibility', 'visible');
                $('#FileImage13_agriculture').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image13_agriculture").val();
        }

        // Total 13 records
        var files = fileUpload.files;
        var formData = new FormData();
        formData.append(files[0].name, files[0]);
    }
    else if ($('#CertificateMasterID').val() == 'a3cb9d3c-bccd-400e-99e8-a353edb2e061') {

        if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File1_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage1_bio').css('visibility', 'visible');
                $('#FileImage1_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image1_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File2_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage2_bio').css('visibility', 'visible');
                $('#FileImage2_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image2_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File3_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage3_bio').css('visibility', 'visible');
                $('#FileImage3_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image3_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File4_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage4_bio').css('visibility', 'visible');
                $('#FileImage4_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image4_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File5_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage5_bio').css('visibility', 'visible');
                $('#FileImage5_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image5_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File6_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage6_bio').css('visibility', 'visible');
                $('#FileImage6_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image6_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File7_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage7_bio').css('visibility', 'visible');
                $('#FileImage7_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image7_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File8_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage8_bio').css('visibility', 'visible');
                $('#FileImage8_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image8_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File9_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage9_bio').css('visibility', 'visible');
                $('#FileImage9_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image9_bio").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File10_bio") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage10_bio').css('visibility', 'visible');
                $('#FileImage10_bio').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image10_bio").val();
        }

        // Total 10 records
        var files = fileUpload.files;
        var formData = new FormData();
        formData.append(files[0].name, files[0]);

    }
    else if ($('#CertificateMasterID').val() == '754d31ba-f0f1-40c1-8102-aaaf5e3ce0b8') {

        if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File1_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage1_veterinary').css('visibility', 'visible');
                $('#FileImage1_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image1_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File2_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage2_veterinary').css('visibility', 'visible');
                $('#FileImage2_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image2_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File3_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage3_veterinary').css('visibility', 'visible');
                $('#FileImage3_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image3_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File4_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage4_veterinary').css('visibility', 'visible');
                $('#FileImage4_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image4_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File5_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage5_veterinary').css('visibility', 'visible');
                $('#FileImage5_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image5_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File6_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage6_veterinary').css('visibility', 'visible');
                $('#FileImage6_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image6_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File7_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage7_veterinary').css('visibility', 'visible');
                $('#FileImage7_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image7_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File8_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage8_veterinary').css('visibility', 'visible');
                $('#FileImage8_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image8_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File9_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage9_veterinary').css('visibility', 'visible');
                $('#FileImage9_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image9_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File10_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage10_veterinary').css('visibility', 'visible');
                $('#FileImage10_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image10_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File11_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage11_veterinary').css('visibility', 'visible');
                $('#FileImage11_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image11_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File12_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage12_veterinary').css('visibility', 'visible');
                $('#FileImage12_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image12_veterinary").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File13_veterinary") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage13_veterinary').css('visibility', 'visible');
                $('#FileImage13_veterinary').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image13_veterinary").val();
        }
        //Total 13 records
        var files = fileUpload.files;
        var formData = new FormData();
        formData.append(files[0].name, files[0]);

    }
    else if ($('#CertificateMasterID').val() == 'ede0fcb0-541f-4a55-a68a-e2ad01e257f9') {

        if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File1_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage1_health').css('visibility', 'visible');
                $('#FileImage1_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image1_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File2_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage2_health').css('visibility', 'visible');
                $('#FileImage2_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image2_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File3_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage3_health').css('visibility', 'visible');
                $('#FileImage3_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image3_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File4_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage4_health').css('visibility', 'visible');
                $('#FileImage4_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image4_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File5_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage5_health').css('visibility', 'visible');
                $('#FileImage5_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image5_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File6_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage6_health').css('visibility', 'visible');
                $('#FileImage6_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image6_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File7_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage7_health').css('visibility', 'visible');
                $('#FileImage7_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image7_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File8_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage8_health').css('visibility', 'visible');
                $('#FileImage8_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image8_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File9_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage9_health').css('visibility', 'visible');
                $('#FileImage9_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image9_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File10_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage10_health').css('visibility', 'visible');
                $('#FileImage10_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image10_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File11_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage11_health').css('visibility', 'visible');
                $('#FileImage11_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image11_health").val();
        }
        else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File12_health") {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#FileImage12_health').css('visibility', 'visible');
                $('#FileImage12_health').attr('src', e.target.result);
            }
            reader.readAsDataURL(fileUpload.files[0]);
            Id = "&Id=" + $("#Image12_health").val();
        }
        // Total 12 records
        var files = fileUpload.files;
        var formData = new FormData();
        formData.append(files[0].name, files[0]);
    }


    $.ajax({
        url: RootPath() + "/Api/Upload/UploadProfileLogo?ProjectId=" + $("#ID").val() + Id + "&DocumentType=" + inputId.id,
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {

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

            finalsubmissionstatuschange(data1.length, 'Saved', 'edit');
        }
    });


}

function populateMandatoryDocument(selected_id, status, event) {

    var keys = [];

    var keysDefault;

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

    $.ajax({
        url: RootPath() + "/Api/Upload/GetDocumentByParent?id=" + selected_id,
        type: 'GET',
        success: function (data1) {

            for (i = 0; i < data1.length; i++) {

                keys.push(data1[i].documentType);

                $('#' + data1[i].documentType + '_upload').empty();
                $('#' + data1[i].documentType + '_success').empty();

                var data = data1[i];
                var openlink = RootPath() + "/API/Upload/Download?DocumentId=" + data.id + "&Name=" + data.documentName;

                if (event === 'edit' && status === 'Saved') {

                    var upload = "<div class='position-relative'> <label for=" + data1[i].documentType + "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + data1[i].documentType + " name=" + data1[i].documentType + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                    $('#' + data1[i].documentType + '_upload').append(upload);

                    var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                    $('#' + data1[i].documentType + '_success').append(markup);


                } else if (event === 'view' || status !== 'Saved') {

                    var upload = "";
                    $('#' + data1[i].documentType + '_upload').append(upload);

                    var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                    $('#' + data1[i].documentType + '_success').append(markup);
                }
            }
            keysDefault.forEach(function (value) {

                if (keys.indexOf(value) === -1) {

                    $('#' + value + '_upload').empty();
                    $('#' + value + '_success').empty();

                    if (event === 'edit' && status === 'Saved') {

                        var upload = "<div class='position-relative'> <label for=" + value + "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                        upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + value + " name=" + value + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                        $('#' + value + '_upload').append(upload);

                        var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                        $('#' + value + '_success').append(markup);

                    }
                    else if (event === 'view' || status !== 'Saved') {

                        var upload = "";
                        $('#' + value + '_upload').append(upload);

                        var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                        $('#' + value + '_success').append(markup);

                    }
                }
            });

            finalsubmissionstatuschange(data1.length, status, event);
        }
    });

}

//#endregion Document Files upload

//#region COMMON NAME SECTION

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

//#endregion

//#region SCREEN Validation 
function validatedetailscreen() {

    var validationControl = '';

    if ($("#CertificateMasterID option:selected").text() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, select value of Certificate type</li>';
    }
    if ($('#txt_requested_date').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Requested date</li>';
    }
    if ($('#txt_trade_name').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Trade Name</li>';
    }
    if ($('#txt_chemical_class').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Chemical class</li>';
    }
    if ($('#txt_pesticide_use').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Pesticide use</li>';
    }
    if ($("#TypeFormulationMasterID option:selected").text() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Type of Formulation</li>';
    }
    if ($('#txt_target_pest').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Target pest</li>';
    }
    if ($("#WHOToxicityMasterID option:selected").text() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of WHO Toxicity</li>';
    }
    if ($('#txt_target_crops').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Target crops</li>';
    }
    if ($('#txt_cr_number').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of CR number</li>';
    }
    if ($('#txt_commercial_activities').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Commercial activities</li>';
    }
    if ($('#txt_exporter_company').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Exporter company</li>';
    }
    if ($('#txt_local_company').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Local company</li>';
    }
    if ($('#txt_license_number').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of License number</li>';
    }
    if ($('#txt_local_company_address').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Address</li>';
    }  

    return validationControl;
}

function validateCommonNameScreen() {

    var validationControl = '';

    if ($('#ID').val() === '' || $('#ID').val() === '0') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, select Certificate </li>';
    }
    if ($("#commonnamemaster option:selected").text() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, select value of Common name</li>';
    }
    if ($('#txt_active_ingredient').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Active ingredient</li>';
    }
    
    return validationControl;
}

//#endregion 