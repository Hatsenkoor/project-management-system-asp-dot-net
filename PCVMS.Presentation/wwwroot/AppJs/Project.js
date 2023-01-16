$(document).ready(function () {
    $("#consultantStartDate").attr("data-toggle", "datepicker");
    $("#consultantEndDate").attr("data-toggle", "datepicker");

   // $("#ProjectStartDate").attr("data-toggle", "datepicker");
    $("#ProjectEndDate").attr("data-toggle", "datepicker");
    $("#RoyalDecreeDate").attr("data-toggle", "datepicker");

    $("#smartwizard-property-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-project-submitted").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });
    $("#smartwizard-project-progress").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-project-completed").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-project-approval").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-sitevisit-submitted").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-property-submitted").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-sitevisit-approval-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });
    $("#smartwizard-property-approval-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-SpecialCase-submitted").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-SpecialCase-Approval-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });
    $("#smartwizard-SpecialCase-approval").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-objection-approval").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-objection-submitted").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-objection-approval-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    $("#smartwizard-valuation-draft").smartWizard({
        selected: 0,
        transitionEffect: "fade",
        toolbarSettings: {
            toolbarPosition: "none",
        },
        anchorSettings: {
            enableAllAnchors: true, // Activates all anchors clickable all times
        },
    });

    // Datepicker for financial year
    $('[data-toggle="datepicker-trigger-projectstartdate"]').datepicker({
        trigger: ".datepicker-click-projectstartdate",
        autoPick: true,
        autoHide: true
    });
});

$(document).ready(function () {
   
    $("#SaveProject").click(function (e) {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "CreateProject", // Controller/View
                data: { //Passing data
                    ProjectName: $("#ProjectName").val(), //Reading text box values using Jquery
                    RoyalDecree: $("#RoyalDecree").val(),
                    ProjectEndDate: $("#ProjectEndDate").val(),
                    RoyalDecreeDate: $("#RoyalDecreeDate").val(),
                    ProjectStartDate: $("#ProjectStartDate").val(),
                    Remark: $("#Remark").val()
                },
                success: function (data) {

                    $("#ID").val(data.id);
                    $.unblockUI();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

        e.preventDefault();

    });

    $('#AddLocation').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddProjectLocation",
                data: {
                    ProjectID: $("#ID").val(), //Reading text box values using Jquery
                    GovernorateID: $("#GovernetId").val(),
                    Wilayat: $("#Wilayat").val(),
                    Village: $("#Village").val()
             },
                success: function (data1) {
                    $("#tbl-ProjectLocation > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr onclick=SelectRecord('" + data.userId + "')><td>" + (i + 1) + "</td><td>" + data.governorateName + "</td><td>" + data.wilayatName + "</td><td>" + data.villageName + "</td></tr>";
                        $("#tbl-ProjectLocation").append(markup);


                    }


                    $.unblockUI();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });
    });

    $('#AddGeometry').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddProjectGeometry",
                data: {
                    ID: $("#HiddenGeometryId").val(),
                    ProjectID: $("#ID").val(), 
                    GeometryId: $("#GeometryId").val(),
                    Easting: $("#EastingId").val(),
                    Northing: $("#Northing").val()

                },

                success: function (data1) {
                    $("#tbl-Geometry > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr onclick=SelectGeometry('" + data.id + "','" + data.geometryId + "','" + data.easting + "','" + data.northing+"')><td>" + data.geometryNameEn + "</td><td>" + (i + 1) + "</td><td>" + data.easting + "</td><td>" + data.northing + "</td></tr>";
                        $("#tbl-Geometry").append(markup);

                    }
                    $("#GeometryId").val('');
                    $("#EastingId").val('');
                    $("#Northing").val('');
                    $("#HiddenGeometryId").val('');

                    $.unblockUI();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });
    });

    $('#ProjectProfile').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddProjecProfile",
                data: {
                    ProfileId: $("#ProfileId").val(),
                    ProjectId: $("#ID").val()
                },

                success: function (data1) {
                    $("#tbl-Profile > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr onclick=SelectProfile('" + data.id + "')><td>" + data.cardId + "</td><td>" + data.name + "</td><td>" + data.registrationHQ  + "</td><td>" +"Edit" + "</td></tr>";
                        $("#tbl-Profile").append(markup);
                    }
                    $("#ProfileId").val('');

                    $.unblockUI();

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }
            });
    });

    $("#AddProperty").click(function (e) {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddProjectProperty",
                data: {
                    ProjectId: $("#ID").val(), //Reading text box values using Jquery
                    ID: $("#PropertyId").val(),
                    OwnerType: $("#PropertyType").val(),
                    CardId: $("#PrpertyCardId").val(),
                    Name: $("#PropertyName").val(),
                    PropertyNumber: $("#PropertyNumber").val(),
                    Email: $("#PropertyEmail").val(),

                    LandLine: $("#PropertyLandline").val(),
                    Mobile: $("#PropertyMobile").val(),

                    Fax: $("#PropertyFax").val(),
                    Remark: $("#PropertyRemark").val()

                },

                success: function (data1) {
                    $("#tbl-ProjectProperty > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr onclick='PropertyRecord(" + JSON.stringify(data) + ")'><td>" + data.nameEn + "</td><td>" + data.name + "</td><td>" + data.cardId + "</td><td>" + data.propertyNumber + "</td><td>Edit</td></tr>";
                        $("#tbl-ProjectProperty").append(markup);

                        $("#ProjectProperty").val(data.id);
                    }

                    $.unblockUI();

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

    });

    $("#ClearProject").click(function (e) {


        $('#ProjectDiv input:text').val('');


        e.preventDefault();

    });

    $("#ClearProperty").click(function (e) {


        $('#PropertyDiv input:text').val('')


        e.preventDefault();

    });

    $('#GovernetId').change(function () {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath() + "/API/LookUp/GetAllWilayat?Governorate=" + $('#GovernetId').val(), // Controller/View

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#Wilayat').html(html)

                }

            });

    });

    $('#Wilayat').change(function () {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath() + "/API/LookUp/GetAllVillage?Wilayat=" + $('#Wilayat').val(), // Controller/View

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#Village').html(html)

                }

            });
    });
});


$(document).ready(function () {

   // var node = document.getElementById("projectdraftstage").getElementsByTagName("li")[0];
   // node.setAttribute("class", "nav-item active");

    $("#step-12").show();
    $("#step-22").hide();
    $("#step-32").hide();
    $("#step-42").hide();

    $("#prev-btn").hide();

    $("#next-btn").click(function () {

        $("#prev-btn").show();
        ViewSubmit();
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

    $('#projectstage li').on('click', function () {

       if ($(this)[0].dataset.stage == "project-draft-stage") {

            var node = document.getElementById("projectdraftstage").getElementsByTagName("li")[1];
            node.setAttribute("class", "nav-item active");

            $("#step-12").show();
            $("#step-22").hide();
            $("#step-32").hide();
            $("#step-42").hide();
        }

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

    $('#projectdraftstage li').on('click', function () {

        if ($(this)[0].dataset.stage == "project-draft-stage-1") {

            var node = document.getElementById("projectdraftstage").getElementsByTagName("li")[0];
            node.setAttribute("class", "nav-item active");

            var node2 = document.getElementById("projectdraftstage").getElementsByTagName("li")[1];
            node2.prop('class', false);


            $("#step-12").show();
            $("#step-22").hide();
            $("#step-32").hide();
            $("#step-42").hide();
        }
        else if ($(this)[0].dataset.stage == "project-draft-stage-2") {

            var stage0 = document.getElementById("projectdraftstage").getElementsByTagName("li")[0];
            stage0.removeAttr("class");

            var node2 = document.getElementById("projectdraftstage").getElementsByTagName("li")[1];
            node2.setAttribute("class", "nav-item active");


            //.removeClass('current');


            $("#step-12").hide();
            $("#step-22").show();
            $("#step-32").hide();
            $("#step-42").hide();
        }

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
                var openlink = RootPath() + "/API/Upload/Download?DocumentId=" + data.id;
                var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.documentName + "</td><td> <a href='" + openlink + "'>Open Document</a></td></tr>";
                alert(markup);
                $("#tbl-ProjectDocument").append(markup);
               // $("#GroupId").val(data.groupID);
            }


        }
    });
}

$(document).ready(function () {


    $("#Submit").click(function (e) {
        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SubmitProject", // Controller/View
                data: { //Passing data

                    ProjectId: $("#ID").val()



                },
                success: function (data1) {

                 

                }

            });

        e.preventDefault();

    });

    $("#Accept").click(function (e) {
        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AcceptProject", // Controller/View
                data: { //Passing data

                    ProjectId: $("#ID").val()



                },
                success: function (data1) {



                }

            });

       

    });

});

function SelectGeometry(id, gemid, est, north) {

    $("#HiddenGeometryId").val(id);
    $("#GeometryId").val(gemid);
    $("#EastingId").val(est);
    $("#Northing").val(north);


}

function SelectProfile(id) {

    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: RootPath()+"/Profile/GetProfileUser",
            data: {
                ProfileId:id
            },

            success: function (data1) {
                $("#tbl-ProfileUser > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr onclick=SelectProfile('" + data.userId + "')><td>" + data.cardID + "</td><td>" + data.nameEn + "</td><td>" + (i+1) + "</td><td>" + "Edit" + "</td></tr>";
                    $("#tbl-ProfileUser").append(markup);
                }
               
            }

        });
}

function PropertyRecord(data) {

 
    $("#PropertyId").val(data.id);
    $("#PropertyType").val(data.propertyId);
    $("#PrpertyCardId").val(data.cardId);
    $("#PropertyName").val(data.name);
    $("#PropertyNumber").val(data.propertyNumber);
    $("#PropertyEmail").val(data.email);

    $("#PropertyLandline").val(data.landline);
    $("#PropertyEmail").val(data.mobile);

    $("#PropertyFax").val(data.fax);
    $("#PropertyRemark").val(data.remark);

                                
}
function ViewSubmit() {

    $("#step2-ProuectType").html($("#ProjectType").text());
    $("#Step-1ID").html($("#ID").val());
    $("#step-2RoyalDecree").html($("#RoyalDecree").val());
    $("#Step-2RoyalDecreeDate").html($("#RoyalDecreeDate").val());
    $("#Step-2ProjectName").html($("#ProjectName").val());
    $("#Step-2ProjectStartDate").html($("#ProjectStartDate").val());
    $("#Step-2ProjectEndDate").html($("#ProjectEndDate").val());
    $("#Step-2txtremark").html($("#txtremark").val());
    $("#Step-2ProjectImage1").html($("#ProjectImage1").val());
    $("#ViewMobile").html($("#Mobile").val());
    $("#ViewFax").html($("#Fax").val());
    $("#ViewRemark").html($("#Remark").val());
    $("#tbl-ViewUserList").html($("#tbl-UserList").html());
    $("#tbl-Viewdocuments").html($("#tbl-documents").html());
    $('#tbl-Step-2ProjectDocument').html($('#tbl-ProjectDocument').html());
    $('#tbl-Step2ProjectLocation').html($('#tbl-ProjectLocation').html());
    $('#tbl-Step-2Geometry').html($('#tbl-Geometry').html());
    $('#tbl-Step2Profile').html($('#tbl-Profile').html());
    $('#tbl-Step2ProfileUser').html($('#tbl-ProfileUser').html());
   
    $('#tbl-Step-2ProjectProperty').html($('#tbl-ProjectProperty').html());
    
    
    
    $('#Step3').html($('#step2').html());
    
}
