$(document).ready(function () {
    $("#FromDate").attr("data-toggle", "datepicker");
    $("#EndDate").attr("data-toggle", "datepicker");
});

function Show(id) {

    $("#First").hide();
    $("#Second").hide();
    $("#Third").hide();
    $("#Fourth").hide();
    $("#Fifth").hide();
    $("#Sixth").hide();
    $("#Seventh").hide();
    $("#Eighth").hide();
    $("#Nineth").hide();
    $("#" + id).show();
}
$(document).ready(function () {
    $("#First").show();
    $("#Second").hide();
    $("#Third").hide();
    $("#Fourth").hide();
    $("#Fifth").hide();
    $("#Sixth").hide();
    $("#Seventh").hide();
    $("#Eighth").hide();
    $("#Nineth").hide();
    GetAllRole();
    GetAllScheme();
    GetAllProject();
    GetAllUser();
    GetAllUserGroupName();

    $('#CreateUser').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "User/CreateUser",
                data: {
                    NameEn: $("#UserNameEn").val(),
                    Password: $("#UserPassword").val(),
                    Email: $("#Email").val(),
                    Mobile: $("#Mobile").val()

                },
                success: function (data1) {
                    var html = $.map(data1, function (lcn) {
                        return '<option value="' + lcn.userId + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#AssignRoleModel_UserId').html(html)
                    $('#PCVMS_User_Group_Name_Model_UserId').html(html)
                    
                    $("#tbl-UserList > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i+1) + "</td><td>" + data.nameEn + "</td><td>" + data.email + "</td></tr>";
                        $("#tbl-UserList").append(markup);
                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }
            });



    });
    $('#SaveRole').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "Role/SaveRole",
                data: {
                    NameEn: $("#Roles_Modle_NameEn").val(),
                    PCVMS_Permission_MasterID: $("#Roles_Modle_PCVMS_Permission_MasterID").val()

                },
                success: function (data1) {
                   
                    var html = $.map(data1, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#AssignRoleModel_RoleId').html(html);
                    $('#RolePermissionModel_RoleId').html(html);
                    $('#PCVMS_Project_Model_RoleId').html(html);
                    
                    
                    $("#tbl-RoleList > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i+1) + "</td><td>" + data.nameEn + "</td></tr>";
                        $("#tbl-RoleList").append(markup);


                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
    $('#SaveUserRole').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AssignRole/Index",
                data: {
                    RoleId: $("#AssignRoleModel_RoleId").val(),
                    UserId: $("#AssignRoleModel_UserId").val(),
                    UserGroupId: $("#AssignRoleModel_UserGroupId").val(),
                    FromDate: $("#FromDate").val(),
                    EndDate: $("#EndDate").val()
                },

                success: function (data1) {

                    $.unblockUI();
                    alert("Record saved successfully!!");

                    $('#AssignRoleModel_UserId').change();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
    $('#RolePermission').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "RolePermission/SaveRolePermission",
                data: {
                    RoleId: $("#RolePermissionModel_RoleId").val(),
                    PermissionId: $("#RolePermissionModel_PermissionId").val()
                    
                },
                success: function (data1) {

                    $("#tbl-RolePermission > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i+1) + "</td><td>" + data.nameEn + "</td></tr>";
                        $("#tbl-RolePermission").append(markup);
                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
    $('#CreateScheme').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "Project/CreateScheme",
                data: {
                    NameEn: $("#SchemeName").val()
                   

                },

                success: function (data1) {
                    var html = $.map(data1, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#PCVMS_Project_Model_SchemeId').html(html);
                    $('#PCVMS_Project_Model_PermissionSchemeId').html(html);
                    $("#tbl-SchemeList > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td></tr>";
                        $("#tbl-SchemeList").append(markup);
                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });

    $('#CreateProject').click(function ()
    {
        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "Project/CreateProject",
                data: {
                    ProjectName: $("#ProjectName").val()
                },

                success: function (data1) {

                    $("#tbl-ProjectList > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td></tr>";
                        $("#tbl-ProjectList").append(markup);
                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }
            });
    });


   
$('#CreateUserGroup').click(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "UserGroup/CreaseUserGroup",
                data: {
                    NameEn: $("#UserGroupNameEn").val()


                },



                success: function (data1) {

                    var html = $.map(data1, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#AssignRoleModel_UserGroupId').html(html);
                    $('#PCVMS_User_Group_Name_Model_GroupId').html(html);
                    
                    $("#tbl-UserGroupName > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td></tr>";
                        $("#tbl-UserGroupName").append(markup);


                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
$('#AssignScheme').click(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "Project/AssignScheme",
                data: {
                    ProjectId: $("#PCVMS_Project_Model_ProjectId").val(),
                    SchemeId: $("#PCVMS_Project_Model_SchemeId").val(),
                    RoleId: $("#PCVMS_Project_Model_RoleId").val()

                },



                success: function (data1) {

                    $("#tbl-ProjectScheems > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.projectName + "</td><td>" + data.schemeName + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-ProjectScheems").append(markup);


                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
$('#SchemePermission').click(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "Project/AssignSchemePermission",
                data: {
                    PermissionId: $("#PCVMS_Project_Model_PermissionId").val(),
                    PermissionSchemeId: $("#PCVMS_Project_Model_PermissionSchemeId").val()
                    

                },



                success: function (data1) {

                    $("#tbl-ScheemPermission > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn  + "</td></tr>";
                        $("#tbl-ScheemPermission").append(markup);


                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
$('#AssignGroup').click(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "UserGroup/AssignUserGroup",
                data: {
                    UserId: $("#PCVMS_User_Group_Name_Model_UserId").val(),
                    GroupId: $("#PCVMS_User_Group_Name_Model_GroupId").val()


                },



                success: function (data1) {

                   
                    
                    $("#tbl-UserGroupList > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-UserGroupList").append(markup);


                    }

                    $.unblockUI();
                    alert("Record saved successfully!!");
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });
$('#PCVMS_User_Group_Name_Model_UserId').change(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "UserGroup/GetUserGroupName?UserId=" + $('#PCVMS_User_Group_Name_Model_UserId').val(), // Controller/View
                success: function (data1) {
                    $("#tbl-UserGroupList > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-UserGroupList").append(markup);


                    }
                    $.unblockUI();
                
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

    });
    $('#AssignRoleModel_UserId').change(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "User/GetUserRole?UserId=" + $('#AssignRoleModel_UserId').val(), // Controller/View
                success: function (data1) {
                    $("#tbl-UseRole > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-UseRole").append(markup);
                    }

                    $.unblockUI();
                
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "User/GetUserRoleGroup?UserId=" + $('#AssignRoleModel_UserId').val(), // Controller/View
                success: function (data1) {

                    $("#tbl-UserGroup > tbody").empty();
                    if (data1 != undefined) {
                        for (i = 0; i < data1.length; i++) {
                            var data = data1[i];
                            var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td></tr>";
                            $("#tbl-UserGroup").append(markup);


                        }
                    }
                    $.unblockUI();
                
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });



    });

$('#RolePermissionModel_RoleId').change(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "RolePermission/GetRolePermission?RoleId=" + $("#RolePermissionModel_RoleId").val(), // Controller/View




                success: function (data1) {
                    $("#tbl-RolePermission > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-RolePermission").append(markup);


                    }

                    $.unblockUI();
               
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

        



    });
    
    
$('#PCVMS_Project_Model_ProjectId').change(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "Project/GetProjectSchema?ProjectId=" + $('#PCVMS_Project_Model_ProjectId').val(),




                success: function (data1) {

                    $("#tbl-ProjectScheems > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.projectName + "</td><td>" + data.schemeName + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-ProjectScheems").append(markup);


                    }

                    $.unblockUI();
                 
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });




    });
$('#PCVMS_Project_Model_PermissionSchemeId').change(function () {

    $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "Project/GetSchemaPermission?SchemaId=" + $('#PCVMS_Project_Model_PermissionSchemeId').val(),




                success: function (data1) {


                    $("#tbl-ScheemPermission > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                        $("#tbl-ScheemPermission").append(markup);


                    }

                    $.unblockUI();
                 
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });




    });

    
});

function GetAllRole() {

    $.blockUI({ message: $('#customloader') });

    $.ajax(
        {
            type: "Get", //HTTP POST Method
            url: "Role/GetAllRoles",
           



            success: function (data1) {
                $("#tbl-RoleList > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                    $("#tbl-RoleList").append(markup);


                }
                $.unblockUI();
             
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);

                $.unblockUI();
            }

        });
}
function GetAllScheme() {

    $.blockUI({ message: $('#customloader') });

    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "Project/GetAllScheme",
            



            success: function (data1) {

                $("#tbl-SchemeList > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                    $("#tbl-SchemeList").append(markup);


                }

                $.unblockUI();
             
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);

                $.unblockUI();
            }
        });
}
function GetAllProject() {

    $.blockUI({ message: $('#customloader') });

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "Project/GetAllProject",




            success: function (data1) {

                $("#tbl-ProjectList > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td></tr>";
                    $("#tbl-ProjectList").append(markup);


                }

                $.unblockUI();
            
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);

                $.unblockUI();
            }

        });
}

function GetAllUser() {

    $.blockUI({ message: $('#customloader') });

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "User/GetAllUsersForGrid",




            success: function (data1) {

                $("#tbl-UserList > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td>" + data.email + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                    $("#tbl-UserList").append(markup);


                }

                $.unblockUI();
             
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);

                $.unblockUI();
            }

        });
}

function GetAllUserGroupName() {

    $.blockUI({ message: $('#customloader') });

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "UserGroup/GetAllUserGroupName",




            success: function (data1) {

                $("#tbl-UserGroupName > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>";
                    $("#tbl-UserGroupName").append(markup);


                }

                $.unblockUI();
              
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);

                $.unblockUI();
            }

        });
}


