
$(document).ready(function () {

    

//# Region GENERAL PAGE

    $("#btnSaveImportExport").click(function (e) {

        var App_ID;
        var App_Name;
        if (e.target.name === 'ImportedAgriculture') {

            App_ID = '73BCDF38-84EC-492B-843B-0FD205047565';
            App_Name = 'Imported-Agriculture';
        } else if (e.target.name === 'ImportedPesticide') {

            App_ID = '30621807-B943-4E3D-A76F-9CE8320A4A87';
            App_Name = 'Imported-Pesticide';
        }
        else if (e.target.name === 'ImportedPest') {

            App_ID = 'FBCDE2D6-BCDD-4692-AE71-E9731F67E002';
            App_Name = 'Imported-Pest';
        } else if (e.target.name === 'ImportedFertilizerSoil') {

            App_ID = '12B50F01-8338-4A60-9B20-00A89BD6ABE5';
            App_Name = 'Imported-Fertilizer-Soil';
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
                    Importer_Name: $("#txtImporter").val(),
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

