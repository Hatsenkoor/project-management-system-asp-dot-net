
$(document).ready(function () {

    getAllCertificate();

    $('#veterinary-pesticide').hide();
    $('#bio-pesticide').hide();
    $('#agriculture-pesticide').hide();
    $('#public-health-pesticide').hide();   
    
    $('#pesticide-certificate-cancel-request :input').attr("disabled", true);

    $("#btnSavePesticide").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePesticideCertificate", // Controller/View
                data: { //Passing data

                    Certificate_Type_ID: $("#CertificateMasterID").val(),
                    Certificate_Name: $("#CertificateMasterID option:selected").text(),
                    Requested_Date: $("#Requested_Date").val(), //Reading text box values using Jquery
                    Certificate_Request_No: $("#ID").val(),
                    Local_Registration_No: $("#Local_Registration_No").val(),
                    Trade_Name: $("#Trade_Name").val(),
                    Comman_Name_ID: $("#CommanNameMasterID").val(),
                    Comman_Name: $("#CommanNameMasterID option:selected").text(),
                    CAS_RN_ID: $("#CASRNID").val(),
                    CAS_RN: $("#CASRNID option:selected").text(),
                    Chemical_Class_ID: $("#ChemicalClassMasterID").val(),
                    Chemical_Class: $("#ChemicalClassMasterID option:selected").text(),
                    Pesticide_Use_ID: $("#PesticideUseMasterID").val(),
                    Pesticide_Use: $("#PesticideUseMasterID option:selected").text(),
                    Concentration_Of_Active_Ingredient: $("#Concentration_Of_Active_Ingredient").val(), //Reading text box values using Jquery
                    Type_of_Formulation: $("#Type_of_Formulation").val(),
                    Target_Pest_ID: $("#TargetPestMasterID").val(),
                    Target_Pest: $("#TargetPestMasterID option:selected").text(),
                    WHO_Toxicity_Classification: $("#WHO_Toxicity_Classification").val(),
                    CR_Number: $("#CR_Number").val(),
                    Registered_Commercial_Activities: $("#Registered_Commercial_Activities").val(),
                    Manufacturer_Company: $("#Manufacturer_Company").val(),
                    Local_Company: $("#Local_Company").val(),
                    License_Number: $("#License_Number").val(),
                    Address: $("#Address").val(),                   
                    Remark: $("#txtremark").val()
                   
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List
                    $("#ID").val(data);
                    getAllCertificate();
                    updateselection();

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $("#tbl-pesticide-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();


        if (event === 'view') {

            $("#Pesticide_Certificate_Details :input").attr("disabled", true);
            $("#btnSavePesticide").prop("disabled", true);
            $("#btnFinalSubmission").prop("disabled", true);
            $("#btnClear").prop("disabled", true);
           $('#pnlSubmitCertificate').hide();
        }
        else if (event === 'edit') {
            $("#Pesticide_Certificate_Details :input").attr("disabled", false);
            $("#btnSavePesticide").prop("disabled", false);
            $("#btnFinalSubmission").prop("disabled", false);
            $("#btnClear").prop("disabled", false);         
        }
        else if (event === 'delete') {
            alert("Delete: not allowed");
            return false;
        }

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
        var tdcAS_RN = $(this).parents("tr").find("#tdcAS_RN").html();
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
        $("#CommanNameMasterID").val(comman_Name_ID);
        $("#CASRNID").val(cAS_RN_ID);
        $("#ChemicalClassMasterID").val(chemical_Class_ID);
        $("#PesticideUseMasterID").val(pesticide_Use_ID);
        $("#TargetPestMasterID").val(target_Pest_ID);
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

        updateselection();

        if (registrationFee)
            $('#pnlRegistrationFee').hide();
        else
            $('#pnlRegistrationFee').show();
      
        populateMandatoryDocument(selected_id);

    });

    $("#btnClear").click(function (e) {

        clear();
    });

    $("#btnfinalSubmission").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "finalSubmission", // Controller/View
                data: { //Passing data


                    Id: $("#ID").val(),
                    statusId: "Submitted"
                },
                success: function (data) {

                    // Populate the Table with Fertilizer Certificate List

                    populatePesticideGrid(data);

                    // show the payment panel for selected record
                    $('#panel-pesticide-payment-request').show();
                    $('#pnlSubmitCertificate').hide();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

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

                    populatePesticideGrid(data);

                    // show the payment panel for selected record
                    $('#pnlRegistrationFee').hide();

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });
});


function getAllCertificate() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetAllCertificate", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populatePesticideGrid(data);

                if ($("#ID").val() !== undefined && $("#ID").val() !== '') {

                    $('#mandatoryDocument').show();
                    $('#additionalDocument').show();

                } else {

                    $('#mandatoryDocument').hide();
                    $('#additionalDocument').hide();
                }
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

        if (data[i].statusId === "Submitted")
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";
        else
            tempString += "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>";

        // addpend the final string
        $("#tbl-pesticide-certificate-list > tbody:last-child").append(tempString);
    }
}

function uploadFiles(inputId) {

    var Id;
    var fileUpload = inputId;

    if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File1") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage1').css('visibility', 'visible');
            $('#FileImage1').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image1").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File2") {

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
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File8") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage8').css('visibility', 'visible');
            $('#FileImage8').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image8").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File9") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage9').css('visibility', 'visible');
            $('#FileImage9').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image9").val();
    } else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File10") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage10').css('visibility', 'visible');
            $('#FileImage10').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image10").val();
    } else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File11") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage11').css('visibility', 'visible');
            $('#FileImage11').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image11").val();
    } else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File12") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage12').css('visibility', 'visible');
            $('#FileImage12').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image12").val();
    } else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File13") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage13').css('visibility', 'visible');
            $('#FileImage13').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image13").val();
    } else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File14") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage14').css('visibility', 'visible');
            $('#FileImage14').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image14").val();
    } else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "File15") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#FileImage15').css('visibility', 'visible');
            $('#FileImage15').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image15").val();
    }

    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);

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

function populateMandatoryDocument(selected_id) {

    var keys = [];
    var keysDefault = ["File1", "File2", "File3", "File4", "File5", "File6", "File7", "File8", "File9", "File10", "File11", "File12", "File13", "File14", "File15"];

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

                if (event === 'edit') {

                    var upload = "<div class='position-relative'> <label for=" + data1[i].documentType + "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                    upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + data1[i].documentType + " name=" + data1[i].documentType + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                    $('#' + data1[i].documentType + '_upload').append(upload);

                    var markup = "<a class='metismenu-icon' href='" + openlink + "'><i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer;margin-left: 10px; color:#00ff00;font-weight:bolder' title='view'></i></a>";
                    $('#' + data1[i].documentType + '_success').append(markup);


                } else if (event === 'view') {

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

                    if (event === 'edit') {

                        var upload = "<div class='position-relative'> <label for=" + value + "><i class='metismenu-icon lnr-upload' style='cursor: pointer;margin-left: 10px;' title='upload'></i></label></div>"
                        upload += "<input style='cursor:pointer; display:none;' title='Choose file automatically uploaded to system' id=" + value + " name=" + value + " accept='.jpg,.jpeg' type='file' size='1' multiple onchange='uploadFiles(this);'/>";
                        $('#' + value + '_upload').append(upload);

                        var markup = "<i class='metismenu-icon lnr-thumbs-up' style='cursor:pointer; margin-left:10px;' title='success'></i>";
                        $('#' + value + '_success').append(markup);

                    }
                    else if (event === 'view') {

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

function updateselection() {


    if ($('#pesticide-certificate-type').val() == 1) {

        $('#veterinary-pesticide').show();
        $('#bio-pesticide').hide();
        $('#agriculture-pesticide').hide();
        $('#public-health-pesticide').hide();

    } else if ($('#pesticide-certificate-type').val() == 2) {

        $('#veterinary-pesticide').hide();
        $('#bio-pesticide').show();
        $('#agriculture-pesticide').hide();
        $('#public-health-pesticide').hide();

    }
    else if ($('#pesticide-certificate-type').val() == 3) {
        $('#veterinary-pesticide').hide();
        $('#bio-pesticide').hide();
        $('#agriculture-pesticide').show();
        $('#public-health-pesticide').hide();

    }
    else if ($('#pesticide-certificate-type').val() == 4) {

        $('#veterinary-pesticide').hide();
        $('#bio-pesticide').hide();
        $('#agriculture-pesticide').hide();
        $('#public-health-pesticide').show();
    }
}
