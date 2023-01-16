
$(document).ready(function () {

    getAllCertificate("local");

    $('#pnlIsLiquidDensity :input').attr("disabled", true);
    $('#pnlIsLiquidPH :input').attr("disabled", true);
    $('#pnl_organic_analysis_extra :input').attr("disabled", true);
   

    $("#btnSaveFertilizerCertificate").click(function (e) {

        var error = validatedetailscreen();

        if (error.length > 0) {

            $('#validationresult').empty();

            $('#validationresult').html("<ul>" + error + "</ul>");

            $(".pop-outer").fadeIn("slow");

            return true;
        }

        autonumber();

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveCertificate", // Controller/View
                data: { //Passing data
                    Fertilizer_Type_ID: $("#FertilizerTypeMasterID").val(),
                    Fertilizer_Type: $("#FertilizerTypeMasterID option:selected").text(),
                    Fertilizer_Subcategory_ID: $("#SubCategoryMasterID").val(),
                    Fertilizer_Subcategory: $("#SubCategoryMasterID option:selected").text(),
                    Requested_Date: $("#txt_requested_date").val(), //Reading text box values using Jquery
                    Registration_Request_No: $("#ID").val(),
                    ID: $("#ID").val(),
                    Local_Certificate_Registration_No: $("#txt_local_registration_no").val(),
                    Scientific_Name: $("#txt_scientific_name").val(),
                    Trade_Name: $("#txt_trade_name").val(),
                    Nature_ID: $("#NatureMasterID").val(),
                    Nature: $("#NatureMasterID option:selected").text(),
                    Shape_ID: $("#ShapeMasterID").val(),
                    Shape: $("#ShapeMasterID option:selected").text(),
                    Density_Concentration: $("#txt_density_concentration").val(),
                    PH_Concentration: $("#txt_ph_concentration").val(),
                    Manufacturer: $("#txt_manufacturer").val(),
                    Manufacturer_Address: $("#txt_manufacturer_address").val(),
                    CR_Number: $("#txt_cr_number").val(),
                    Registered_Commercial_Activities: $("#txt_registered_commercial_activities").val(),
                    Remark: $("#txt_remark").val(),
                    Application_Type: "local"
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List
                    $("#ID").val(data);                   
                    getAllCertificate("local");
                    $('#pnlextra').show();
                 
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
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

                    getAllCertificate("local");
                    finalsubmissionstatuschange(7, 'Submitted', 'edit');
                    paynowstatuschange($("#ID").val(), 'Submitted');
                    populateMandatoryDocument($("#ID").val(), 'Submitted', 'edit');

                    $("#Fertilizer_Certificate_Details :input").attr("disabled", true);
                    $("#btnSaveFertilizerCertificate").prop("disabled", true);
                    $("#btnOrganicConcentration").prop("disabled", true);
                    $("#btnSaveChemicalDensity").prop("disabled", true);
                    $("#btnSaveChemicalConcentration").prop("disabled", true);
                    $("#btnSaveChemicalPercentage").prop("disabled", true);
                    $("#btnClear").prop("disabled", true);

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    /*
    $("#btnRegistrationFee").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "RegistrationFee", // Controller/View
                data: { //Passing data
                    Id: $("#ID").val(),
                    RegistrationFee: true,
                    statusId: "Review Application"
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List
                    getAllCertificate("local");
                    paynowstatuschange($("#ID").val(), 'Review Application');
               
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                   
                }

            });

        e.preventDefault();

    });
    */

    $("#btnRegistrationFee").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePayment", // Controller/View
                data: { //Passing data
                    AppID: $("#ID").val(),
                    PaymentType: "Fertilizer_Local_Registration_Fee"
                },
                success: function (data) {

                   // window.location.href = RootPath() + "/Checkout/index?Id=556677881" + "&amount=" + $("#txtamount").text();
                    window.location.href = RootPath() + "/Checkout/index?Id=" + data + "&AppID=" + $("#ID").val() + "&amount=" + $("#txtamount").text() + "&paymentType=Fertilizer_Local_Registration_Fee";

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                }

            });

        e.preventDefault();

    });
  
    $("#tbl-fertilizer-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();


        if (event === 'view') {

            $("#Fertilizer_Certificate_Details :input").attr("disabled", true);
            $("#btnSaveFertilizerCertificate").prop("disabled", true);
            $("#btnOrganicConcentration").prop("disabled", true);
            $("#btnSaveChemicalDensity").prop("disabled", true);
            $("#btnSaveChemicalConcentration").prop("disabled", true);
            $("#btnSaveChemicalPercentage").prop("disabled", true);         
            $("#btnClear").prop("disabled", true);
           // $("#panel-fertilizer-payment-request :input").attr("disabled", true);
           // $("#pnlPayNow").hide();  
            $(".readonly-enabled :input").attr("disabled", true);
        }
        else if (event === 'edit')
        {
            $("#Fertilizer_Certificate_Details :input").attr("disabled", false);
            $("#btnSaveFertilizerCertificate").prop("disabled", false);
            $("#btnOrganicConcentration").prop("disabled", false);
            $("#btnSaveChemicalDensity").prop("disabled", false);
            $("#btnSaveChemicalConcentration").prop("disabled", false);
            $("#btnSaveChemicalPercentage").prop("disabled", false);          
            $("#btnClear").prop("disabled", false);         
            //$("#panel-fertilizer-payment-request :input").attr("disabled", false);
            //$("#pnlPayNow").show();
            var status = $(this).parents("tr").find("#tdstatus").html();
            if (status === 'Submitted') {

                $("#panel-fertilizer-payment-request :input").attr("disabled", false);
            }

        }
        else if (event === 'delete')
        {
            alert("Delete: not allowed");
            return false;
        }

        var id = $(this).parents("tr").find("#tdid").html();

        var Fertilizer_Type_ID = $(this).parents("tr").find("#tdFertilizer_Type_ID").html();
        var FertilizerType = $(this).parents("tr").find("#tdFertilizer_Type").html();
        var Fertilizer_Subcategory_ID = $(this).parents("tr").find("#tdFertilizer_Subcategory_ID").html();
        var Fertilizer_Subcategory = $(this).parents("tr").find("#tdFertilizer_Subcategory").html();

        var Requested_Date = $(this).parents("tr").find("#tdRequested_Date").html();
        var Registration_Request_No = $(this).parents("tr").find("#tdRegistration_Request_No").html();
        var Local_Certificate_Registration_No = $(this).parents("tr").find("#tdLocal_Certificate_Registration_No").html();
        var Scientific_Name = $(this).parents("tr").find("#tdScientific_Name").html();
        var Trade_Name = $(this).parents("tr").find("#tdTrade_Name").html();
        var Nature_ID = $(this).parents("tr").find("#tdNature_ID").html();
        var Nature = $(this).parents("tr").find("#tdNature").html();
        var Shape_ID = $(this).parents("tr").find("#tdShape_ID").html();
        var Shape = $(this).parents("tr").find("#tdShape").html();
        var Density_Concentration = $(this).parents("tr").find("#tdDensity_Concentration").html();
        var PH_Concentration = $(this).parents("tr").find("#tdPH_Concentration").html();
        var Manufacturer = $(this).parents("tr").find("#tdManufacturer").html();
        var Manufacturer_Address = $(this).parents("tr").find("#tdManufacturer_Address").html();
        var Remark = $(this).parents("tr").find("#tdRemark").html();       
        var status = $(this).parents("tr").find("#tdstatus").html();      
        var registrationFee = $(this).parents("tr").find("#tdregistrationFee").html();
        var certificateFee = $(this).parents("tr").find("#tdcertificateFee").html();

        $("#FertilizerTypeMasterID").val(Fertilizer_Type_ID);
        $("#SubCategoryMasterID").val(Fertilizer_Subcategory_ID);
        $("#txt_requested_date").val(Requested_Date);
        $("#ID").val(id);
        $("#txt_local_registration_no").val(Local_Certificate_Registration_No);
        $("#txt_scientific_name").val(Scientific_Name);
        $("#txt_trade_name").val(Trade_Name);
        $("#NatureMasterID").val(Nature_ID);
        $("#ShapeMasterID").val(Shape_ID);
        $("#txt_density_concentration").val(Density_Concentration);
        $("#txt_ph_concentration").val(PH_Concentration);
        $("#txt_manufacturer").val(Manufacturer);
        $("#txt_manufacturer_address").val(Manufacturer_Address);
        $("#txt_remark").val(Remark);

        $('#pnlextra').show();
       
        GetOrganicAnalysisByCertificateID(selected_id);
        GetChemicalAnalysisByCertificateID(selected_id);

        populateMandatoryDocument(selected_id, status, event);

        paynowstatuschange(id, status);
        populateRFCDetail();

        if (status === 'Review Application')
            $("#pnlreviewapproval").show();
        else
            $("#pnlreviewapproval").hide();

       

    });

    $("#btnOrganicAnalysis").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveOrganicAnalysis", // Controller/View
                data: { //Passing data

                    CertificateID: $("#ID").val(), //Reading text box values using Jquery
                    AnalysisTypeMasterID: $("#OrganicAnalysisMasterID").val(),
                    AnalysisTypeMasterText: $("#OrganicAnalysisMasterID option:selected").text(),
                    Description: $("#organic_analysis_extra").val(),
                    Concentration: $("#organic_concentration").val(),
                    Source: $("#organic_source").val()
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List
                    populateOrganicAnalysisGrid(data);

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });   
   
    $(document).on('click', '.fertilizerAnalysis', function (e) {

        var certificateID = '';
        var elementMasterID = '';
        var elementMasterText = '';
        var formMasterID = '';
        var formMasterText = '';

        var concentration = '';
        var source = '';
        var type = '';

        if (e.target.title === 'secondary') {

            certificateID = $("#ID").val();
            elementMasterID = $("#SecondaryElementMasterID").val();
            elementMasterText = $("#SecondaryElementMasterID option:selected").text();
            formMasterID = 0;
            formMasterText = 0;
            concentration = $("#txtsecondaryconcentration").val();
            source = $("#ChemicalPercentageSource").val();
            type = e.target.title;
        }
        else if (e.target.title === 'major') {

            certificateID = $("#ID").val();
            elementMasterID = $("#MajorElementMasterID").val();
            elementMasterText = $("#MajorElementMasterID option:selected").text();
            formMasterID = $("#MajorElementFormMasterID").val();
            formMasterText = $("#MajorElementFormMasterID option:selected").text();
            concentration = $("#ChemicalDensityConcentration").val();
            source = $("#ChemicalDensitySource").val();
            type = e.target.title;
        }
        else if (e.target.title === 'trace') {

            certificateID = $("#ID").val();
            elementMasterID = $("#TraceElementMasterID").val();
            elementMasterText = $("#TraceElementMasterID option:selected").text();
            formMasterID = $("#TraceElementFormMasterID").val();
            formMasterText = $("#TraceElementFormMasterID option:selected").text();
            concentration = $("#txttraceconcentration").val();
            source = $("#txttracesource").val();
            type = e.target.title;
        }

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveChemicalAnalysis", // Controller/View
                data: { //Passing data

                    CertificateID: certificateID, //Reading text box values using Jquery
                    ElementMasterID:elementMasterID,
                    ElementMasterText:elementMasterText,
                    FormMasterID: formMasterID,
                    FormMasterText: formMasterText,
                    Concentration: concentration,
                    Source:source,
                    Type: type,

                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List
                    populateChemicalAnalysisGrid(data);

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $("#btnClear").click(function (e) {

        clear();
    });

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


    $('#NatureMasterID').change(function () {

        if ($('option:selected', this).text() !=='Solid') {
           
            $('#pnlIsLiquidDensity :input').attr("disabled", false);
            $('#pnlIsLiquidPH :input').attr("disabled", false);
        }
        else {

            $('#pnlIsLiquidDensity :input').attr("disabled", true);
            $('#pnlIsLiquidPH :input').attr("disabled", true);
        }
       
    });

    $(document).on('change', '.fertilizer-number', function (e) {

        autonumber();
    });

    $(document).on('change', '.organic-analysis-master', function (e) {       

        if ($("#OrganicAnalysisMasterID").val() === 'eb5aec37-0771-4b9e-afaf-b17e90849eb2' || $("#OrganicAnalysisMasterID").val() === 'b50cb697-a45e-4a03-8406-c9c6b10be62f' || $("#OrganicAnalysisMasterID").val() === 'c2e5ad20-8796-4d80-96e0-d5451976c775' || $("#OrganicAnalysisMasterID").val() === '7d7a8dd4-b84e-4387-aa64-8fddf2ad17c5')
        {
            $('#pnl_organic_analysis_extra :input').attr("disabled", false);
          
        }
        else {
            $('#pnl_organic_analysis_extra :input').attr("disabled", true);
            $("#organic_analysis_extra").val('');
        }
          
    });

    // Datepicker for Pesticide Certificate
    $('[data-toggle="datepicker_trigger_txt_requested_date"]').datepicker({
        trigger: ".datepicker-click-fertilizercertificatedate",
        autoPick: true,
        autoHide: true
    }); 


});

function getAllCertificate(application_type) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllCertificate?application_type=" + application_type,
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

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdFertilizer_Type_ID' name='tdFertilizer_Type_ID'>" + data[i].fertilizer_Type_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdFertilizer_Type' name='tdFertilizer_Type'>" + data[i].fertilizer_Type + "</td>"
            + "<td style = 'display:none;' id = 'tdFertilizer_Subcategory_ID' name='tdFertilizer_Subcategory_ID'>" + data[i].fertilizer_Subcategory_ID + "</td>"
            + "<td style = 'display:none;' id = 'tdFertilizer_Subcategory' name='tdFertilizer_Subcategory'>" + data[i].fertilizer_Subcategory + "</td>"

            + "<td style = 'display:none;' id = 'tdregistrationFee' name='tdregistrationFee'>" + data[i].registrationFee + "</td>"
            + "<td style = 'display:none;' id = 'tdcertificateFee' name='tdcertificateFee'>" + data[i].certificateFee + "</td>"
            + "<td style = 'display:none;' id = 'tdRequested_Date' name = 'tdRequested_Date' style = 'text-align:center;'>" + data[i].requested_Date + "</td>"
            + "<td style = 'display:none;' id = 'tdRegistration_Request_No' name = 'tdRegistration_Request_No' style = 'text-align:center;'>" + data[i].registration_Request_No + "</td>"
            + "<td style ='display:none;'  id = 'tdLocal_Certificate_Registration_No' name='tdLocal_Certificate_Registration_No'>" + data[i].local_Certificate_Registration_No + "</td>"
            + "<td style = 'display:none;' id = 'tdScientific_Name' name = 'tdScientific_Name' style = 'text-align:center;'>" + data[i].scientific_Name + "</td>"
            + "<td style = 'display:none;' id = 'tdTrade_Name' name = 'tdTrade_Name' style = 'text-align:center;'>" + data[i].trade_Name + "</td>"
            + "<td style ='display:none;'  id = 'tdNature_ID' name='tdNature_ID'>" + data[i].nature_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdNature' name='tdNature'>" + data[i].nature + "</td>"
            + "<td style ='display:none;'  id = 'tdShape_ID' name='tdShape_ID'>" + data[i].shape_ID + "</td>"
            + "<td style ='display:none;'  id = 'tdShape' name='tdShape'>" + data[i].shape + "</td>"
            + "<td style = 'display:none;' id = 'tdDensity_Concentration' name = 'tdDensity_Concentration' style = 'text-align:center;'>" + data[i].density_Concentration + "</td>"
            + "<td style = 'display:none;' id = 'tdPH_Concentration' name = 'tdPH_Concentration' style = 'text-align:center;'>" + data[i].pH_Concentration + "</td>"
            + "<td style='display:none;'   id = 'tdManufacturer_Address' name='tdManufacturer_Address'>" + data[i].manufacturer_Address + "</td>"
            + "<td style = 'display:none;' id = 'tdRemark' name = 'tdRemark' style = 'text-align:center;'>" + data[i].remark + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"         
            + "<td id = 'tdManufacturer' name = 'tdManufacturer' style = 'text-align:center;'>" + data[i].manufacturer + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>";

        if (data[i].statusId === "Saved")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>";
        else if (data[i].statusId === "Submitted")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i></div></td></tr>";
        else

            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-fertilizer-certificate-list > tbody:last-child").append(tempString);

    }
}

function uploadFiles(inputId) {

    var Id;
    var fileUpload = inputId;

    if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File2") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage2').css('visibility', 'visible');
            $('#FileImage2').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image2").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File3") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage3').css('visibility', 'visible');
            $('#FileImage3').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image3").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File4") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage4').css('visibility', 'visible');
            $('#FileImage4').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image4").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File5") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage5').css('visibility', 'visible');
            $('#FileImage5').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image5").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File6") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage6').css('visibility', 'visible');
            $('#FileImage6').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image6").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File7") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage7').css('visibility', 'visible');
            $('#FileImage7').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image7").val();
    }
   else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File9") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage9').css('visibility', 'visible');
            $('#FileImage9').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image9").val();
    }

    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);

    $.ajax({
        url: RootPath() + "/Api/Upload/UploadProfileLogo?ProjectId=" + $("#ID").val() + Id +"&DocumentType=" +inputId.id,
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
    var keysDefault = ["File2", "File3", "File4", "File5", "File6", "File7", "File9"];

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
                    
                    var upload = "<div class='position-relative'> <label for=" + data1[i].documentType+ "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + data1[i].documentType + " name=" + data1[i].documentType+ " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                    $('#' + data1[i].documentType + '_upload').append(upload);

                    var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                    $('#' + data1[i].documentType + '_success').append(markup);


                } else if (event === 'view' || status !=='Saved') {

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
                        upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + value  + " name=" +value+ " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
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


    if (length === 7 && status === "Saved" && event === 'edit') {

        $('#pnlfinalSubmission').show();

    } else {
        $('#pnlfinalSubmission').hide();
    }

}

function populateOrganicAnalysisGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-organic-concentration > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        $("#tbl-organic-concentration > tbody:last-child").append("<tr>"

            + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;' > " + data[i].certificateID + "</td >"
            + "<td style = 'display:none;' id = 'tdtdAnalysisTypeMasterIDo' name = 'tdAnalysisTypeMasterIDo' style = 'text-align:center;' > " + data[i].analysisTypeMasterID + "</td >"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].analysisTypeMasterText + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].concentration + "</td>"
            + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr > ");
    }
}

function populateChemicalAnalysisGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-chemical-major > tbody").html('');
    $("#tbl-chemical-secondary > tbody").html('');
    $("#tbl-chemical-trace > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        if (data[i].type === 'major') {

            $("#tbl-chemical-major > tbody:last-child").append("<tr>"

                + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;' > " + data[i].certificateID + "</td >"
                + "<td style = 'display:none;' id = 'tdChemicalDensityMasterID' name = 'tdChemicalDensityMasterID' style = 'text-align:center;' > " + data[i].elementMasterID + "</td >"
                + "<td style = 'display:none;' id = 'tdChemicalDensityFormMasterID' name = 'tdChemicalDensityFormMasterID' style = 'text-align:center;' > " + data[i].formMasterID + "</td >"
                + "<td style = 'display:none;' id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
                + "<td id='tdChemicalDensityMasterText' name='tdChemicalDensityMasterText'>" + data[i].elementMasterText + "</td>"
                + "<td id='tdChemicalDensityFormMasterText' name='tdChemicalDensityFormMasterText'>" + data[i].formMasterText + "</td>"
                + "<td id='tdConcentration' name='tdConcentration'>" + data[i].concentration + "</td>"
                + "<td id ='tdsource' name='tdsource' style='text-align:center;'>" + data[i].source + "</td>"
                + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr > ");
        }
        else if (data[i].type === 'secondary') {

            $("#tbl-chemical-secondary > tbody:last-child").append("<tr>"

                + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;' > " + data[i].certificateID + "</td >"
                + "<td style = 'display:none;' id = 'tdChemicalDensityMasterID' name = 'tdChemicalDensityMasterID' style = 'text-align:center;' > " + data[i].elementMasterID + "</td >"
                + "<td style = 'display:none;' id = 'tdChemicalDensityFormMasterID' name = 'tdChemicalDensityFormMasterID' style = 'text-align:center;' > " + data[i].formMasterID + "</td >"
                + "<td style = 'display:none;' id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
                + "<td id='tdChemicalDensityMasterText' name='tdChemicalDensityMasterText'>" + data[i].elementMasterText + "</td>"
                + "<td style = 'display:none;' id='tdChemicalDensityFormMasterText' name='tdChemicalDensityFormMasterText'>" + data[i].formMasterText + "</td>"
                + "<td id='tdConcentration' name='tdConcentration'>" + data[i].concentration + "</td>"
                + "<td id ='tdsource' name='tdsource' style='text-align:center;'>" + data[i].source + "</td>"
                + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr > ");

        }
        else if (data[i].type === 'trace') {

            $("#tbl-chemical-trace > tbody:last-child").append("<tr>"

                + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;' > " + data[i].certificateID + "</td >"
                + "<td style = 'display:none;' id = 'tdChemicalDensityMasterID' name = 'tdChemicalDensityMasterID' style = 'text-align:center;' > " + data[i].elementMasterID + "</td >"
                + "<td style = 'display:none;' id = 'tdChemicalDensityFormMasterID' name = 'tdChemicalDensityFormMasterID' style = 'text-align:center;' > " + data[i].formMasterID + "</td >"
                + "<td style = 'display:none;' id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
                + "<td id='tdChemicalDensityMasterText' name='tdChemicalDensityMasterText'>" + data[i].elementMasterText + "</td>"
                + "<td id='tdChemicalDensityFormMasterText' name='tdChemicalDensityFormMasterText'>" + data[i].formMasterText + "</td>"
                + "<td id='tdConcentration' name='tdConcentration'>" + data[i].concentration + "</td>"
                + "<td id ='tdsource' name='tdsource' style='text-align:center;'>" + data[i].source + "</td>"
                + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr > ");

        }

    }
}

function GetOrganicAnalysisByCertificateID(Registration_Request_No) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetOrganicAnalysisByCertificateID", // Controller/View
            data: { //Passing data

                CertificateID: Registration_Request_No //Reading text box values using Jquery
            },
            success: function (data) {

                // Populate the Table with Fertilizer Certificate List
                populateOrganicAnalysisGrid(data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function GetChemicalAnalysisByCertificateID(Registration_Request_No) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetChemicalAnalysisByCertificateID", // Controller/View
            data: { //Passing data

                CertificateID: Registration_Request_No //Reading text box values using Jquery
            },
            success: function (data) {

                // Populate the Table with Fertilizer Certificate List
                populateChemicalAnalysisGrid(data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function clear() {

    $("#FertilizerTypeMasterID").val(-1);
    $("#SubCategoryMasterID").val(-1);
    $("#txt_requested_date").val(today());
    $("#ID").val('');
    $("#txt_local_registration_no").val('');
    $("#txt_scientific_name").val('');
    $("#txt_trade_name").val('');
    $("#NatureMasterID").val(-1);
    $("#ShapeMasterID").val(-1);
    $("#txt_density_concentration").val('');
    $("#txt_ph_concentration").val('');
    $("#txt_manufacturer").val('');
    $("#txt_manufacturer_address").val('');   
    $("#txt_remark").val('');

    $('#pnlextra').hide();
  
}

function today() {

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    return today = mm + '/' + dd + '/' + yyyy;
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

    if(data.length > 0)
        $('#fertilizer-certificate-review-approval').show();
    else
        $('#fertilizer-certificate-review-approval').hide();



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


function validatedetailscreen() {

    var validationControl = '';

    if ($('#txt_requested_date').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Requested date</li>';
    }
    if ($('#txt_scientific_name').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Scientific name</li>';
    }
    if ($('#txt_trade_name').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Trade Name</li>';
    } 
    if ($('#txt_manufacturer').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Manufaturer</li>';
    }    
    if ($('#txt_manufacturer_address').val() === '') {

        validationControl = validationControl + '<li><i class="metismenu-state-icon pe-7s-ticket" style="margin-right: 10px;"></i>Please, enter value of Manufaturer address</li>';
    }    
    return validationControl;
}

function validateCommonNameScreen() {

    var validationControl = '';

    if ($('#ID').val() === '') {

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

function autonumber() {

    var substring = $("#SubCategoryMasterID option:selected").text();
    var today = new Date();
    var yyyy = today.getFullYear();
    var certificate = 'F';

    if ($("#FertilizerTypeMasterID").val() === '2c7d1dab-7d2e-4ff5-a909-3166f3c8bc73')
        certificate = 'S';

    var temp = certificate + '-' + substring.substring(substring.indexOf("-") + 1) + '-' + yyyy;
    $('#txt_local_registration_no').val(temp);

}