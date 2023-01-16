
$(document).ready(function () {
    $("#RegistrationDate").attr("data-toggle", "datepicker");

});


$("#SaveProfile").click(function (e) {
   
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "AddProfile", // Controller/View
            data: { //Passing data
                Name: $("#Name").val(), //Reading text box values using Jquery
                CardId: $("#CardId").val(),
                RegistrationDate: $("#RegistrationDate").val(),
                RegistrationHQ: $("#RegistrationHQ").val(),
                PoBox: $("#PoBox").val(),
                PostalCode: $("#PostalCode").val(),
                Email: $("#Email").val(),
                LandLine: $("#LandLine").val(),
                Mobile: $("#Mobile").val(),
                Fax: $("#Fax").val(),
                Remark: $("#Remark").val(),
                ProfileId: $("#ProfileId").val(),
                Deleted:1, //$("#Deleted").val(),
                StatusId:1, // $("#StatusId").val()


            },
            success: function (data) {
                $("#ID").val(data.id);
              
                alert('Profile saved.');
            }

        });

    e.preventDefault();

});
$("#UserProfile").click(function (e) {
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "AddUserProfile", // Controller/View
            data: { //Passing data
                NameEn: $("#UserName").val(), //Reading text box values using Jquery
                CardId: $("#UserCardId").val(),
                Email: $("#UserEmail").val(),
                Mobile: $("#UserMobile").val(),
                JobTitle: $("#UserJob").val(),
                Department: $("#UserDepartment").val(),
                LandLine: $("#UserLandLine").val(),
                Fax: $("#UserFax").val(),
                Remark: $("#UserRemark").val(),
                ProfileId: $("#ID").val(),
                UserId:$("#UserId").val()


            },
            success: function (data1) {

                $("#tbl-UserList > tbody").empty();
                for (i = 0; i < data1.length; i++)
                {
                    var data = data1[i];
                    var markup = "<tr onclick=SelectRecord('" + data.userId + "')><td>" + data.nameEn + "</td><td>" + data.cardID + "</td><td>" + data.mobile + "</td><td>" + data.email + "</td></tr>";
                    $("#tbl-UserList").append(markup);
                    

             }
                    
                    
               
                ClearUserProfile();

            }

        });

    e.preventDefault();

});
function SelectRecord(id) {
    $("#UserId").val(id);
    $.ajax(
        {
            type: "Get", //HTTP POST Method
            url: RootPath()+"/User/GetUserById", // Controller/View
            data: { //Passing data
                UserId: id //Reading text box values using Jquery
                



            },
            success: function (data) {
                $("#UserName").val(data.nameEn); //Reading text box values using Jquery
                $("#UserCardId").val(data.cardID);
                $("#UserEmail").val(data.email);
                $("#UserMobile").val(data.mobile);
                $("#UserJob").val(data.jobTitle);
                $("#UserDepartment").val(data.department);
                $("#UserLandLine").val(data.landLine);
                $("#UserFax").val(data.fax);
                $("#UserRemark").val(data.remark);
                $("#UserId").val(data.userId);
                

            }

        });
}

$("#ClearUserProfile").click(function (e) {


    ClearUserProfile();


    e.preventDefault();

});

$("#ClearProfile").click(function (e) {



    $("#CardId").val(''); //Reading text box values using Jquery
    $("#ProfileId").val('');
    $("#Name").val('');
    $("#RegistrationDate").val('');
    $("#RegistrationHQ").val('');
    $("#PoBox").val('');
    $("#PostalCode").val('');
    $("#Email").val('');
    $("#LandLine").val('');
    $("#Mobile").val('');
    $("#Fax").val('');
    $("#Remark").val('');

    ClearUserProfile();
    $("#tbl-UserList > tbody").empty();

    e.preventDefault();

});
function ClearUserProfile() {

    $("#UserName").val(''); //Reading text box values using Jquery
    $("#UserCardId").val('');
    $("#UserEmail").val('');
    $("#UserMobile").val('');
    $("#UserJob").val('');
    $("#UserDepartment").val('');
    $("#UserLandLine").val('');
    $("#UserFax").val('');
    $("#UserRemark").val('');
    $("#UserId").val('');

}
function ViewSubmit() {

    $("#ViewCardId").html($("#CardId").val());
    $("#ViewProfileId").html($("#ProfileId").val());
    $("#ViewName").html($("#Name").val());
    $("#ViewRegistrationDate").html($("#RegistrationDate").val());
    $("#ViewRegistrationHQ").html($("#RegistrationHQ").val());
    $("#ViewPoBox").html($("#PoBox").val());
    $("#ViewPostalCode").html($("#PostalCode").val());
    $("#ViewEmail").html($("#Email").val());
    $("#ViewLandLine").html($("#LandLine").val());
    $("#ViewMobile").html($("#Mobile").val());
    $("#ViewFax").html($("#Fax").val());
    $("#ViewRemark").html($("#Remark").val());
    $("#tbl-ViewUserList").html($("#tbl-UserList").html());
    $("#tbl-Viewdocuments").html($("#tbl-documents").html());
}

$(document).ready(function () {

    $("#prev-btn").hide();

    $("#next-btn").click(function () {

        $("#prev-btn").show();
        ViewSubmit();
        $("#step3html").html($("#step2html").html());
        var stage = $('ul#profilestage').find('li.active').data('stage');

        if (stage == "profile-approval-stage-3") {

            $("#next-btn").hide();
            $("#prev-btn").hide();
        }

    });

    $("#prev-btn").click(function () {

        var stage = $('ul#profilestage').find('li.active').data('stage');

        if (stage == "profile-submitted-stage-2") {

            $("#prev-btn").hide();
            ViewSubmit();
        }

    });

    $("#btn-finish").click(function () {

        var node = document.getElementById("profilestage").getElementsByTagName("li")[3];
        node.setAttribute("class", "done");

        $('#last-stage-message').html('');
        $('#last-stage-message').append("You are done!!");

    });

    $('#profilestage li').on('click', function () {

        if ($(this).hasClass("done") || $(this).hasClass("active")) {

            $("#prev-btn").show();
            $("#next-btn").show();

            if ($(this).data("stage") == "profile-draft-stage-1") {

                $("#prev-btn").hide();
            }
            if ($(this).data("stage") == "profile-finish-stage-4") {

                $("#prev-btn").hide();
                $("#next-btn").hide();
            }

        }
        else {

            alert("no action");
        }

    });

});

function uploadFiles(inputId) {

    var fileUpload = $("#" + inputId).get(0);
    if (fileUpload.files && fileUpload.files[0] && inputId == "files") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#stage-image1').css('visibility', 'visible');
            $('#stage-image1').attr('src', e.target.result);


            $('#stage-image2').css('visibility', 'visible');
            $('#stage-image2').attr('src', e.target.result);

            $('#stage-image3').css('visibility', 'visible');
            $('#stage-image3').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
    }
    else {

        var reader = new FileReader();
        reader.onload = function (e) {
           

            $('#stage-document1').css('visibility', 'visible');
            $('#stage-document1').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileUpload.files[0]);
    }


   
    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);
   
    var Id;
    if (inputId == "files") {
        Id = "&Id=" + $("#ImageId").val();
        
    }
    else {
        Id = "&Id=" + $("#documentId").val();
    }
   

    $.ajax({
        url: RootPath()+"/Api/Upload/UploadProfileLogo?Group=" + $("#GroupId").val() + Id,
       
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {


            $("#tbl-documents > tbody").empty();
            for (i = 0; i < data1.length; i++) {
                var data = data1[i];
                var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.documentName + "</td><td> <a href='" + RootPath() + "/API/Upload/Download?DocumentId=" + data.id + "&Name=" + data.documentName + "')>Open Document</a></td></tr>";
                $("#tbl-documents").append(markup);
                $("#GroupId").val(data.groupID);

                if (inputId == "files") {
                    $("#ImageId").val(data.id);

                }
                else {
                    $("#documentId").val(data.id);
                }

            }

           
        }
    });
}
function uploadExcelFiles() {

    if ($("#ID").val() == '') {
        alert('Please save Profile fist.');
        return;
    }
    var fileUpload = $("#Excel").get(0);

    var Id;
    



    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);

   


    $.ajax({
        url: RootPath()+"/Api/Upload/UploadExecl?ParentId=" + $("#GroupId").val() + '&Id=' + $("#ExcelId").val() ,

        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {


            $("#tbl-documents > tbody").empty();
            for (i = 0; i < data1.length; i++) {
                var data = data1[i];
                var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.documentName + "</td><td> <a href='" + RootPath()+"/API/Upload/Download?DocumentId=" + data.id + "')>Open Document</a></td></tr>";
                $("#tbl-documents").append(markup);
                $("#GroupId").val(data.groupID);

                
                    $("#ExcelId").val(data.id);

                
               

            }


        }
    });
}

function Opendocument(id) {
    var formData = new FormData();
    formData.append("id", id);
    $.ajax({
        url: RootPath()+'/Api/Upload/Getimage',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {


           
        }
    });
}

$("#Submit").click(function (e) {
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "SubmitProfile", // Controller/View
            data: { //Passing data
                GroupId: $("#GroupId").val(), //Reading text box values using Jquery
                ProfileId: $("#ID").val()
               


            },
            success: function (data1) {

                ClearUserProfile();

            }

        });

    e.preventDefault();

});


$("#Accept").click(function (e) {
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "AcceptProfile", // Controller/View
            data: { //Passing data
                GroupId: $("#GroupId").val(), //Reading text box values using Jquery
                ProfileId: $("#ID").val()



            },
            success: function (data1) {

               

            }

        });

    e.preventDefault();

});

