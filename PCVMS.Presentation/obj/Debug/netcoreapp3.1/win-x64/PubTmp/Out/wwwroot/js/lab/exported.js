
$(document).ready(function () {

    

//# Region GENERAL PAGE

    $("#btnSaveImportExport").click(function (e) {

        var App_ID;
        var App_Name;
        if (e.target.name === 'ExportedAgriculture') {

            App_ID = '79D860E6-733E-4055-9D48-B8D519E8EBFA';
            App_Name = 'Exported-Agriculture';
        } else if (e.target.name === 'ExportedPesticide') {

            App_ID = 'FC9668C8-587E-43C0-870D-A9B04F2B6E48';
            App_Name = 'Exported-Pesticide';
        }
        else if (e.target.name === 'ExportedPest') {

            App_ID = '3FDECC37-C343-4322-8B73-0618EB919609';
            App_Name = 'Exported-Pest';
        } else if (e.target.name === 'ExportedFertilizerSoil') {

            App_ID = 'DFA2E027-F72B-41B9-BDE7-E95D03BA6BB1';
            App_Name = 'Exported-Fertilizer-Soil';
        }

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SaveImportExport", // Controller/View
                data: { //Passing data

                    Request_ID: $("#txtID").val(),
                    Payment_ID: $("#txtID").val(),
                    Collection_Date: $("#txtSampleCollectionDate").val(), //Reading text box values using Jquery
                    PC_Number: $("#txtPCNumber").val(),
                    App_ID: App_ID,
                    App_Name: App_Name,
                    Port_ID: $("#PortMasterID").val(),
                    Port_Name: $("#PortMasterID option:selected").text(),
                    Custom_Document_Number: $("#txtCustomDocumentNumber").val(),
                    Shipment_Document_Number: $("#txtShipmentDocumentNumber").val(), //Reading text box values using Jquery
                    Company_Name: $("#txtCompanyName").val(),
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

