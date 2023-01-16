
$(document).ready(function () {

    getAllPaymentCertificate();
   
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
        var comman_Name_ID = $(this).parents("tr").find("#tdcomman_Name_ID").html();
        var comman_Name = $(this).parents("tr").find("#tdcomman_Name").html();
        var trade_Name = $(this).parents("tr").find("#tdTrade_Name").html();
        var cAS_RN_ID = $(this).parents("tr").find("#tdcAS_RN_ID").html();
        var cAS_RN = $(this).parents("tr").find("#tdcAS_RN").html();
        var chemical_Class_ID = $(this).parents("tr").find("#tdchemical_Class_ID").html();
        var chemical_Class = $(this).parents("tr").find("#tdchemical_Class").html();
        var pesticide_Use_ID = $(this).parents("tr").find("#tdpesticide_Use_ID").html();
        var pesticide_Use = $(this).parents("tr").find("#tdpesticide_Use").html();
        var concentration_Of_Active_Ingredient = $(this).parents("tr").find("#tdconcentration_Of_Active_Ingredient").html();
        var CR_Number = $(this).parents("tr").find("#tdCR_Number").html();
        var type_of_Formulation = $(this).parents("tr").find("#tdtype_of_Formulation").html();
        var target_Pest_ID = $(this).parents("tr").find("#tdtarget_Pest_ID").html();
        var target_Pest = $(this).parents("tr").find("#tdtarget_Pest").html();
        var wHO_Toxicity_Classification = $(this).parents("tr").find("#tdwHO_Toxicity_Classification").html();
        var Address = $(this).parents("tr").find("#tdAddress").html();
        var registered_Commercial_Activities = $(this).parents("tr").find("#tdRegistered_Commercial_Activities").html();
        var manufacturer_Company = $(this).parents("tr").find("#tdmanufacturer_Company").html();
        var license_Number = $(this).parents("tr").find("#tdlicense_Number").html();
        var Remark = $(this).parents("tr").find("#tdRemark").html();
        var local_Company = $(this).parents("tr").find("#tdlocal_Company").html();
        var status = $(this).parents("tr").find("#tdstatus").html();
        var registrationFee = $(this).parents("tr").find("#tdregistrationFee").html();
        var certificateFee = $(this).parents("tr").find("#tdcertificateFee").html();

        $("#Requested_Date").val(requested_Date);
        $("#CertificateMasterID").val(certificate_Type_ID);
        $("#Certificate_Name").val(certificate_Name);
        $("#CommanNameMasterID").val(comman_Name);
        $("#CASRNID").val(cAS_RN);
        $("#ChemicalClassMasterID").val(chemical_Class);
        $("#PesticideUseMasterID").val(pesticide_Use);
        $("#TargetPestMasterID").val(target_Pest);
        $("#ID").val(id);
        $("#Local_Registration_No").val(local_Registration_No);
        $("#Trade_Name").val(trade_Name);
        $("#Concentration_Of_Active_Ingredient").val(concentration_Of_Active_Ingredient);
        $("#Type_of_Formulation").val(type_of_Formulation);

        $("#WHO_Toxicity_Classification").val(wHO_Toxicity_Classification);
        $("#CR_Number").val(CR_Number);
        $("#Registered_Commercial_Activities").val(registered_Commercial_Activities);
        $("#Manufacturer_Company").val(manufacturer_Company);
        $("#Local_Company").val(local_Company);
        $("#License_Number").val(license_Number);
        $("#Address").val(Address);
        $("#txtremark").val(Remark);

        $("#ID").val(id);

        if (status === 'Approved')
            $("#pnlPayCertificateFee").show();
        else
            $("#pnlPayCertificateFee").hide();

    });

    //$("#btnPayCertificateFee").click(function (e) {

    //    $.ajax(
    //        {
    //            type: "POST", //HTTP POST Method
    //            url: "CertificateFee", // Controller/View
    //            data: { //Passing data
    //                Id: $("#ID").val(),
    //                statusId: "Issued",
    //                certificateFee: true
    //            },
    //            success: function (data) {
    //                // Populate the Table with Fertilizer Certificate List
    //                populatePesticideGrid(data);
    //            },
    //            error: function (xhr) {
    //                alert(xhr.responseText + xhr.statusText);
    //            }

    //        });

    //    e.preventDefault();

    //});



    $("#btnPayCertificateFee").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePayment", // Controller/View
                data: { //Passing data
                    AppID: $("#ID").val(),
                    PaymentType: "Pesticide_Certificate_Fee"
                },
                success: function (data) {

                    // window.location.href = RootPath() + "/Checkout/index?Id=556677881" + "&amount=" + $("#txtamount").text();
                    window.location.href = RootPath() + "/Checkout/index?Id=" + data + "&AppID=" + $("#ID").val() + "&amount=" + $("#txttotalamount").text() + "&paymentType=Pesticide_Certificate_Fee";

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                }

            });

        e.preventDefault();

    });

    $("#btnAddPayment").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePaymentPesticide", // Controller/View
                data: { //Passing data
                    AppID: $("#ID").val(),
                    Service_ID: $("#ServiceMasterID").val(),
                    ServiceType: $("#ServiceMasterID").val(),
                    amount: $("#txtamount").val(),
                    ServiceDescription: $("#txtdescription").val()
                },
                success: function (data) {

                    // window.location.href = RootPath() + "/Checkout/index?Id=556677881" + "&amount=" + $("#txtamount").text();
                    alert("Payment Saved!!");
                    GetPaymentPesticideByCertificateID($("#ID").val());
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                }

            });

        e.preventDefault();

    });

});


function getAllPaymentCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getAllPaymentCertificate", // Controller/View
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

    if (data.length > 0) {
        $('#no_record_screen').hide();     
    }
    else {      
        $('#no_record_screen').show();
        $('#record_screen').hide();
    }

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdcertificate_Type_ID' name='tdcertificate_Type_ID'>" + data[i].certificate_Type_ID + "</td>"

            + "<td style = 'display:none;' id = 'tdregistrationFee' name='tdregistrationFee'>" + data[i].registrationFee + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificateFee' name='tdcertificateFee'>" + data[i].certificateFee + "</td>"
            + "<td style = 'display:none;' id = 'tdRequested_Date' name = 'tdRequested_Date' style = 'text-align:center;'>" + data[i].requested_Date + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificate_Request_No' name = 'tdcertificate_Request_No' style = 'text-align:center;'>" + data[i].certificate_Request_No + "</td>"
            + "<td style ='display:none;'  id = 'tdlocal_Registration_No' name='tdlocal_Registration_No'>" + data[i].local_Registration_No + "</td>"
            + "<td style = 'display:none;' id = 'tdcomman_Name_ID' name = 'tdcomman_Name_ID' style = 'text-align:center;'>" + data[i].comman_Name_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdcomman_Name' name = 'tdcomman_Name' style = 'text-align:center;'>" + data[i].comman_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdTrade_Name' name = 'tdTrade_Name' style = 'text-align:center;'>" + data[i].trade_Name + "</td>"
            + "<td style ='display:none;'  id = 'tdcAS_RN_ID' name='tdcAS_RN_ID'>" + data[i].caS_RN_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdcAS_RN' name='tdcAS_RN'>" + data[i].caS_RN + "</td>"
            + "<td style = 'display:none;' id = 'tdchemical_Class_ID' name = 'tdchemical_Class_ID' style = 'text-align:center;'>" + data[i].chemical_Class_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdchemical_Class' name = 'tdchemical_Class' style = 'text-align:center;'>" + data[i].chemical_Class + "</td>"
            + "<td style = 'display:none;' id = 'tdpesticide_Use_ID' name = 'tdpesticide_Use_ID' style = 'text-align:center;'>" + data[i].pesticide_Use_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdpesticide_Use' name = 'tdpesticide_Use' style = 'text-align:center;'>" + data[i].pesticide_Use + "</td>"
            + "<td style='display:none;'   id = 'tdconcentration_Of_Active_Ingredient' name='tdconcentration_Of_Active_Ingredient'>" + data[i].concentration_Of_Active_Ingredient + "</td>"

            + "<td style = 'display:none;' id = 'tdtype_of_Formulation' name = 'tdtype_of_Formulation' style = 'text-align:center;'>" + data[i].type_of_Formulation + "</td>"
            + "<td style = 'display:none;' id = 'tdtarget_Pest_ID' name = 'tdtarget_Pest_ID' style = 'text-align:center;'>" + data[i].target_Pest_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdtarget_Pest' name = 'tdtarget_Pest' style = 'text-align:center;'>" + data[i].target_Pest + "</td>"
            + "<td style ='display:none;'  id = 'tdwHO_Toxicity_Classification' name='tdwHO_Toxicity_Classification'>" + data[i].whO_Toxicity_Classification + "</td>"
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


function GetPaymentPesticideByCertificateID(AppID) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPaymentPesticideByCertificateID?id=" + AppID, // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populatePaymentGrid(data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}


function populatePaymentGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-payment-list > tbody").html('');

    if (data.length > 0) {
        $('#no_record_screen').hide();
    }
    else {
        $('#no_record_screen').show();
        $('#record_screen').hide();
    }

    var amountTotal = 0;

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td id = 'tdServiceDescription' name='tdServiceDescription'>" + data[i].serviceDescription + "</td>"
            + "<td id ='tdamount' name='tdamount'>" + data[i].amount + "</td></tr>";           

        // addpend the final string
        $("#tbl-payment-list > tbody:last-child").append(tempString);
        
        amountTotal = amountTotal + data[i].amount;
        $("#txttotalamount").text(amountTotal);
    }
}