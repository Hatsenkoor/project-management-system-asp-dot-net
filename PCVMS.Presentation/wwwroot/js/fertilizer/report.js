
$(document).ready(function () {

    $('#fertilizer-certificate-review :input').attr("disabled", true);
   
    GetAllCertificateDefault();

    $("#tbl-fertilizer-certificate-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        // this is the code to make the selected row highlighted
        //start
        if ($(this).parent("tr").hasClass('active')) {

            $(this).parents("tr").removeClass("active");
        } else {

            $('#tbl-fertilizer-certificate-list > tbody tr.active').removeClass('active');
            $(this).parents("tr").addClass("active");
        }
       //end

        $('#record_screen').show();
       

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
        var application_Type = $(this).parents("tr").find("#tdapplicationType").html();

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

        if (status === 'Director Review' || status === 'Review Application')
            $("#pnlreviewapproval").show();
        else
            $("#pnlreviewapproval").hide();

        GetOrganicAnalysisByCertificateID(selected_id);
        GetChemicalAnalysisByCertificateID(selected_id);

        populateMandatoryDocument(selected_id, application_Type);
        populateRFCDetail();

        if (application_Type === 'local')
            $('#imported_section').hide();
        else {

            $('#imported_section').show();
        }


       // populateRFCDocument(selected_id);
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

});

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

function GetAllCertificateDefault() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: RootPath() + "/FertilizerCertificate/GetAllCertificateDefault", // Controller/View
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
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].company_Licensed_Import_Export_Trade + "</td>"
            + "<td id = 'tdManufacturer' name = 'tdManufacturer' style = 'text-align:center;'>" + data[i].manufacturer + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].statusId + "</td>"
            + "<td class='text-left' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i></div></td></tr>";

          // addpend the final string
        $("#tbl-fertilizer-certificate-list > tbody:last-child").append(tempString);

        if (data[i].application_Type === 'local')
            $('#imported_section').hide();
        else {

            $('#imported_section').show();
        }
    }
}

function GetOrganicAnalysisByCertificateID(Registration_Request_No) {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: RootPath() + "/FertilizerCertificate/GetOrganicAnalysisByCertificateID", // Controller/View
            data: { //Passing data

                CertificateID: Registration_Request_No, //Reading text box values using Jquery
            },
            success: function (data) {

                // Populate the Table with Fertilizer Certificate List
                populateOrganicConcentrationGrid(data);

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
            url: RootPath() + "/FertilizerCertificate/GetChemicalAnalysisByCertificateID", // Controller/View
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

function populateRFCDetail() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: RootPath() + "/FertilizerCertificate/GetAllRemark", // Controller/View
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

function populateMandatoryDocument(selected_id, application_Type) {

    var keys = [];
    var keysDefault = [];

    if (application_Type === 'local') {

        keysDefault = ["File2", "File3", "File4", "File5", "File6", "File7", "File9"];
        $("#txdoc1").hide();
        $("#txdoc8").hide();

    } else {

        keysDefault = ["File1", "File2", "File3", "File4", "File5", "File6", "File7", "File8", "File9"];
        $("#txdoc1").show();
        $("#txdoc8").show();
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
        }
    });

}

function populateOrganicConcentrationGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-organic-concentration > tbody").html('');

    for (var i = 0; i < data.length; i++) {

        $("#tbl-organic-concentration > tbody:last-child").append("<tr>"

            + "<td style = 'display:none;' id = 'tdCertificateID' name = 'tdCertificateID' style = 'text-align:center;'> " + data[i].certificateID + "</td>"
            + "<td style = 'display:none;' id = 'tdtdAnalysisTypeMasterIDo' name = 'tdAnalysisTypeMasterIDo' style = 'text-align:center;'> " + data[i].analysisTypeMasterID + "</td>"
            + "<td id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td id='tdCompany_Licensed_Import_Export_Trade' name='tdCompany_Licensed_Import_Export_Trade'>" + data[i].analysisTypeMasterText + "</td>"
            + "<td id ='tdstatus' name='tdstatus' style='text-align:center;'>" + data[i].concentration + "</td>"
            + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'></div></td></tr>");
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


function today() {

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    return today = mm + '/' + dd + '/' + yyyy;
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

