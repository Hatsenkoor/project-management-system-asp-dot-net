
$(document).ready(function () {

    

//# Region GENERAL PAGE

    $("#btnSaveImportExport").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveImportExport", // Controller/View
                data: { //Passing data

                    Request_ID: $("#txtID").val(),
                    Payment_ID: $("#txtID").val(),
                    Collection_Date: $("#txtSampleCollectionDate").val(), //Reading text box values using Jquery
                    PC_Number: $("#txtPCNumber").val(),
                    Port_ID: $("#PortMasterID").val(),
                    Port_Name: $("#PortMasterID option:selected").text(),
                    Custom_Document_Number: $("#txCustomDocumentNumber").val(),
                    Shipment_Document_Number: $("#txShipmentDocumentNumber").val(), //Reading text box values using Jquery
                    Company_Name: $("#txCompanyName").val(),
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
                   
                 
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });  

//# end Region GENERAL PAGE


});

