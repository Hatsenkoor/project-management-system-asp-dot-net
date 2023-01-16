$(document).ready(function () {
    $("#disputeStartDate").attr("data-toggle", "datepicker");
    $("#disputeEndDate").attr("data-toggle", "datepicker");
    $("#enquiryDate").attr("data-toggle", "datepicker");
    $("#complaintDate").attr("data-toggle", "datepicker");


    $("#smartwizard-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-folloup").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });
    
});


function uploadFiles(inputId) {
    var Id;
    var fileUpload = inputId;
    if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "ProjectFile1") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ProjectImage1').css('visibility', 'visible');
            $('#ProjectImage1').attr('src', e.target.result);

            $('#Step-2ProjectImage1').css('visibility', 'visible');
            $('#Step-2ProjectImage1').attr('src', e.target.result);

           
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image1").val();
    }
   else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "ProjectFile2") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ProjectImage2').css('visibility', 'visible');
            $('#ProjectImage2').attr('src', e.target.result);

            $('#Step-2ProjectImage2').css('visibility', 'visible');
            $('#Step-2ProjectImage2').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image2").val();
    }
    else if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "ProjectFile3") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ProjectImage3').css('visibility', 'visible');
            $('#ProjectImage3').attr('src', e.target.result);

            $('#Step-2ProjectImage3').css('visibility', 'visible');
            $('#Step-2ProjectImage3').attr('src', e.target.result);

        }
        reader.readAsDataURL(fileUpload.files[0]);
        Id = "&Id=" + $("#Image3").val();
    }
   



    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);

   
   


    $.ajax({
        url: RootPath()+"/Api/Upload/UploadProfileLogo?ProjectId=" + $("#ID").val() + Id,

        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {


            $("#tbl-ProjectDocument > tbody").empty();
            for (i = 0; i < data1.length; i++) {
                var data = data1[i];
                var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.documentName + "</td><td> <a href='" + RootPath()+"'/API/Upload/Download?DocumentId=" + data.id + ">Open Document</a></td></tr>";
                $("#tbl-ProjectDocument").append(markup);
               // $("#GroupId").val(data.groupID);
            }


        }
    });
}

