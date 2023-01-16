
$(document).ready(function () {



    getAllPaymentCertificate();

    $("#tbl-fertilizer-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        $('#fertilizer-certificate-payment').show();

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

        if (status === 'Approved')
            $("#pnlPayCertificateFee").show();
        else
            $("#pnlPayCertificateFee").hide();

    });

    //    $("#btnPayCertificateFee").click(function (e) {

    //        $.ajax(
    //            {
    //                type: "POST", //HTTP POST Method
    //                url: "CertificateFee", // Controller/View
    //                data: { //Passing data
    //                    Id: $("#ID").val(),
    //                    statusId: "Issued",
    //                    certificateFee: true
    //                },
    //                success: function (data) {
    //                    // Populate the Table with Fertilizer Certificate List
    //                    populateFertilizerGrid(data);                   
    //                },
    //                error: function (xhr) {
    //                    alert(xhr.responseText + xhr.statusText);
    //                }

    //            });

    //        e.preventDefault();

    //    });


    $("#btnPayCertificateFee").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePayment", // Controller/View
                data: { //Passing data
                    AppID: $("#ID").val(),
                    PaymentType: "Fertilizer_Certificate_Fee"
                },
                success: function (data) {

                    // window.location.href = RootPath() + "/Checkout/index?Id=556677881" + "&amount=" + $("#txtamount").text();
                    window.location.href = RootPath() + "/Checkout/index?Id=" + data + "&AppID=" + $("#ID").val() + "&amount=" + $("#txtamount").text() + "&paymentType=Fertilizer_Certificate_Fee";

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
      
        $('#fertilizer-certificate-payment').hide();
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

        if (data[i].statusId === 'Approved')
            $("#pnlPayCertificateFee").show();
        else
            $("#pnlPayCertificateFee").hide();
    }
}
