var LookupData;
var ddltype;
$(document).ready(function () {


    $("#prev-btn").hide();

    $("#next-btn").click(function () {

        $("#prev-btn").show();
      
      
       

    });

    $("#prev-btn").click(function () {

       

    });

    $("#btn-finish").click(function () {

      

    });

    $("#SearchProperty").click(function (e) {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "GetPropertyByNumber?PropertyNumber=" + $("#PropertyNumber").val() , // Controller/View
                
                success: function (data) {
                    if (data == undefined) {
                        alert('No Property found');
                        return;
                    }
                    $("#PropertyName").val(data.propertyName);
                    $("#PropertyOwnerType").val(data.propertyOwnerTypeEn);
                    $("#PropertyCardId").val(data.propertyCardId);
                    $("#PropertyNumberDetail").val(data.propertyNumber);
                    $("#PropertyEmail").val(data.propertyEmail);
                    $("#PropertyLandline").val(data.propertyLandline);
                    $("#PropertyMobile").val(data.propertyMobile);
                    $("#PropertyFax").val(data.propertyFax);
                    $("#PropertyRemark").val(data.propertyRemark);
                    $("#PropertyId").val(data.id);
                    
                    retriveRecord();
                }

            });

        e.preventDefault();

    });
    $("#btn-finish").click(function (e) {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "SubmitProperty?PropertyId=" + $("#PropertyId").val(), // Controller/View

                success: function (data) {
                    if (data == undefined) {
                        alert('No Property found');
                        return;
                    }
                    $("#PropertyName").val(data.propertyName);
                    $("#PropertyOwnerType").val(data.propertyOwnerTypeEn);
                    $("#PropertyCardId").val(data.propertyCardId);
                    $("#PropertyNumberDetail").val(data.propertyNumber);
                    $("#PropertyEmail").val(data.propertyEmail);
                    $("#PropertyLandline").val(data.propertyLandline);
                    $("#PropertyMobile").val(data.propertyMobile);
                    $("#PropertyFax").val(data.propertyFax);
                    $("#PropertyRemark").val(data.propertyRemark);
                    $("#PropertyId").val(data.id);

                    retriveRecord();
                }

            });

        e.preventDefault();

    });
    $('#PropertyInfoSave').click(function () {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "SavePropertyInfo", // Controller/View
                data: {
                    ID: $("#ProjectInfoId").val(), //Reading text box values using Jquery
                    LandUse: $("#LandUse").val(),
                    SubLandUse: $("#SubLandUser").val(),
                    ActualLandUse: $("#ActualLandUser").val(),
                    TotalArea: $("#TotalArea").val(),
                    AffectedLandArea: $("#AffectedLandArea").val(),
                    RemainingLandArea: $("#RemainingLandArea").val(),

                    TotalBuildAre: $("#TotalBuildAre").val(),
                    AffectedBuildArea: $("#AffectedBuildArea").val(),
                    RemainingBuildArea: $("#RemainingBuildArea").val(),
                    Remark: $("#PropertyInfoRemark").val(),
                    PropertyId: $("#PropertyId").val()


                },
                success: function (data) {

                    $("#ProjectInfoId").val(data.id);
                }

            });

    });

    $("#SaveWells").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddPropertStorage", // Controller/View
                data: {
                    WellsCode: $("#WellsCode").val(), //Reading text box values using Jquery
                    Type: $("#WellType").val(),
                    Description: $("#WellDescription").val(),
                    Size: $("#WellSize").val(),
                    Cladding: $("#WellCladding").val(),

                    CladSize: $("#WellCladSize").val(),
                    SoilType: $("#WellSoilType").val(),
                    Status: $("#WellStatus").val(),
                    PropertyId: $("#PropertyId").val()


                },
                success: function (data1) {


                    $("#tbl-Well > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.wellCodeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.sizeEn + "</td><td>" + data.claddingNameEn + "</td><td>" + data.cladSizeEn + "</td><td>" + data.soilNameEn + "</td><td>" + data.statusAr + "</td> <td><a href='#' onclick=DeleteWell('" + data.id + "')>Delete</a></td></tr>";
                        $("#tbl-Well").append(markup);


                    }

                    //$('#CropDiv input:text').val('');

                    //$('#CropDiv').find("select").prop("selectedIndex", 0);
                }

            });

        e.preventDefault();

    });

    $("#SaveTank").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddPropertTank", // Controller/View
                data: {
                    TankCode: $("#TankCode").val(), //Reading text box values using Jquery
                    TankType: $("#TankType").val(),
                    TankDescription: $("#TankDescription").val(),
                    Size: $("#TankSize").val(),
                    Cladding: $("#TankCladding").val(),

                    CladSize: $("#TankCladSize").val(),
                    SoilType: $("#TankSoilType").val(),

                    PropertyId: $("#PropertyId").val()


                },
                success: function (data1) {


                    $("#tbl-Tank > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.sizeEn + "</td><td>" + data.claddingNameEn + "</td><td>" + data.cladSizeEn + "</td><td>" + data.soilNameEn + "</td><td>" + data.statusAr + "</td> <td><a href='#' onclick=DeleteTank('" + data.id + "')>Delete</a></td></tr>";
                        $("#tbl-Tank").append(markup);


                    }

                    //$('#CropDiv input:text').val('');

                    //$('#CropDiv').find("select").prop("selectedIndex", 0);
                }

            });

        e.preventDefault();

    });

    $("#SaveChannel").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddPropertChannel", // Controller/View
                data: {
                    ChannelCode: $("#ChannelCode").val(), //Reading text box values using Jquery
                    Type: $("#ChannelType").val(),
                    Description: $("#ChannelDescription").val(),
                    Cladding: $("#ChannelCladding").val(),
                    width: $("#ChannelWidth").val(),

                    Height: $("#ChannelHeight").val(),
                    Length: $("#ChannelLength").val(),

                    PropertyId: $("#PropertyId").val()


                },
                success: function (data1) {


                    $("#tbl-Channel > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.claddingNameEn + "</td><td>" + data.width + "</td><td>" + data.height + "</td><td>" + data.length + "</td> <td><a href='#' onclick=DeleteChannel('" + data.id + "')>Delete</a></td></tr>";
                        $("#tbl-Channel").append(markup);


                    }


                    //$('#CropDiv input:text').val('');

                    //$('#CropDiv').find("select").prop("selectedIndex", 0);
                }

            });

        e.preventDefault();

    });

    $("#SaveItem").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddPropertItem", // Controller/View
                data: {
                    ItemCode: $("#ItemCode").val(), //Reading text box values using Jquery
                    ItemType: $("#ItemType").val(),
                    ItemDescription: $("#ItemDescription").val(),
                    ItemNumber: $("#ItemNumber").val(),
                    ItemCondition: $("#ItemCondition").val(),



                    PropertyId: $("#PropertyId").val()


                },
                success: function (data1) {


                    $("#tbl-Item > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.number + "</td><td>" + data.conditionEn + "</td> <td><a href='#' onclick=DeleteItem('" + data.id + "')>Delete</a></td></tr>";
                        $("#tbl-Item").append(markup);


                    }

                    //$('#CropDiv input:text').val('');

                    //$('#CropDiv').find("select").prop("selectedIndex", 0);
                }

            });

        e.preventDefault();

    });
    $("#SaveTree").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddPropertTree", // Controller/View
                data: {
                    TreeCode: $("#TreeCode").val(), //Reading text box values using Jquery
                    TreeCategory: $("#TreeCategory").val(),
                    TreeType: $("#TreeType").val(),
                    TreeSize: $("#TreeSize").val(),
                    Number: $("#TreeNumber").val(),
                    PropertyId: $("#PropertyId").val()


                },
                success: function (data1) {


                    $("#tbl-Trees > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.treeCodeNameEn + "</td><td>" + data.categoryNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.sizeNameEn + "</td><td>" + data.number + "</td> <td><a href='#' onclick=DeleteTree('" + data.id + "')>Delete</a></td></tr>";
                        $("#tbl-Trees").append(markup);


                    }
                    $('#DivTree input:text').val('');
                    $('#DivTree').find("select").prop("selectedIndex", 0);

                }

            });

        e.preventDefault();

    });
    $("#SaveCrop").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "AddPropertCrop", // Controller/View
                data: {
                    CropCode: $("#CropCode").val(), //Reading text box values using Jquery
                    CropType: $("#CropType").val(),
                    CropName: $("#CropName").val(),
                    TotalArea: $("#CropArea").val(),
                    TotalProduction: $("#CropProduction").val(),
                    PropertyId: $("#PropertyId").val()


                },
                success: function (data1) {


                    $("#tbl-Crop > tbody").empty();
                    for (i = 0; i < data1.length; i++) {
                        var data = data1[i];
                        var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.cropNameEn + "</td><td>" + data.area + "</td><td>" + data.production + "</td> <td><a href='#' onclick=DeleteCrop('" + data.id + "')>Delete</a></td></tr>";
                        $("#tbl-Crop").append(markup);


                    }

                    $('#CropDiv input:text').val('');

                    $('#CropDiv').find("select").prop("selectedIndex", 0);
                }

            });

        e.preventDefault();

    });


    $('#LandUse').change(function () {
        //$(function () {
        //    $("#dialog").dialog();
        //});
        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/API/LookUp/GetSubLandUse?LandUse=" + $('#LandUse').val(), // Controller/View




                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#SubLandUser').html(html);

                    if ($("#SubLandUserHidden").val() != "") {
                        $("#SubLandUser").val($("#SubLandUserHidden").val());
                        $("#SubLandUser").change();
                    }

                }

            });



    });
    $('#SubLandUser').change(function () {
        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/API/LookUp/GetActualLandUse?SubLandUse=" + $('#SubLandUser').val(), // Controller/View




                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ActualLandUser').html(html)

                    

                    if ($("#ActualLandUserHidden").val() != "") {
                        $("#ActualLandUser").val($("#ActualLandUserHidden").val());
                      
                    }
                }

            });



    });
    $("#TreeCode").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TreeCode").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TreeCategory').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TreeCategory").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TreeCategory").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TreeType').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TreeType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TreeType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TreeSize').html(html)


                }

            });

        e.preventDefault();

    });
    $("#CropCode").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#CropCode").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#CropType').html(html)


                }

            });

        e.preventDefault();

    });
    
    $("#CropType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#CropType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#CropName').html(html)


                }

            });

        e.preventDefault();

    });


   
    $("#WellsCode").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellsCode").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellType').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellDescription').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellDescription").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellDescription").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellSize').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellDescription").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellDescription").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellSize').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellSize").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellSize").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellCladding').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellCladding").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellCladding").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellCladSize').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellCladSize").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellCladSize").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellSoilType').html(html)


                }

            });

        e.preventDefault();

    });
    $("#WellSoilType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#WellSoilType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#WellStatus').html(html)


                }

            });

        e.preventDefault();

    });

    $("#TankCode").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TankCode").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TankType').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TankType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TankType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TankDescription').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TankDescription").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TankDescription").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TankSize').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TankSize").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TankSize").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TankCladding').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TankCladding").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TankCladding").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TankCladSize').html(html)


                }

            });

        e.preventDefault();

    });
    $("#TankCladSize").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#TankCladSize").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#TankSoilType').html(html)


                }

            });

        e.preventDefault();

    });
    
    $("#ChannelCode").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#ChannelCode").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ChannelType').html(html)


                }

            });

        e.preventDefault();

    });
    $("#ChannelType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#ChannelType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ChannelDescription').html(html)


                }

            });

        e.preventDefault();

    });
    $("#ChannelDescription").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#ChannelDescription").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ChannelCladding').html(html)


                }

            });

        e.preventDefault();

    });

    $("#ItemCode").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#ItemCode").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ItemType').html(html)


                }

            });

        e.preventDefault();

    });
    $("#ItemType").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#ItemType").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ItemDescription').html(html)


                }

            });

        e.preventDefault();

    });
    $("#ItemDescription").change(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: RootPath()+"/Api/LookUp/GetLookUpList?Item=" + $("#ItemDescription").val(),

                success: function (data) {
                    var html = $.map(data, function (lcn) {
                        return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
                    }).join('');
                    html = "<option value=''></option> " + html;
                    $('#ItemCondition').html(html)


                }

            });

        e.preventDefault();

    });
});

function SaveMeterail(type,area,note) {
    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "AddUpdatePropertyMaterial", // Controller/View
            data: {
                Type: $("#" + type).val(), //Reading text box values using Jquery
                TotalArea: $("#"+area).val(),
                Note: $("#"+note).val(),
                PropertyId: $("#PropertyId").val()


            },
            success: function (data1) {

                $("#tbl-Meterial > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td>" + data.totalArea + "</td><td>" + data.note +"</td> <td><a href='#' onclick=DeleteMeterial('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Meterial").append(markup);


                }
            }

        });
}
function SavePropertyWall(type, Height, Thickness, Length, Line) {

    $.ajax(
        {
            type: "POST", //HTTP POST Method
            url: "AddPropertyWalls", // Controller/View
            data: {
                Type: $("#" + type).val(), //Reading text box values using Jquery
                Height: $("#" + Height).val(),
                Thickness: $("#" + Thickness).val(),
                Length: $("#" + Length).val(),
                Line: $("#" + Line).val(),
                PropertyId: $("#PropertyId").val()


            },
            success: function (data1) {

                $("#tbl-Walls > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td>" + data.height + "</td><td>" + data.thickness + "</td><td>" + data.length + "</td><td>" + data.line + "</td> <td><a href='#' onclick=DeleteWalls('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Walls").append(markup);


                }
                if (type == 'Walls') {
                    $('#DivWall input:text').val('');

                    $('#DivWall').find("select").prop("selectedIndex", 0);
                }
                else if (type == 'Parapet') {
                    $('#DivParapet input:text').val('');

                    $('#DivParapet').find("select").prop("selectedIndex", 0);
                }
                else if (type == 'Shades') {
                    $('#DivShades input:text').val('');

                    $('#DivShades').find("select").prop("selectedIndex", 0);
                }
                    
            }

        });
}
$(document).ready(function () {


    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: RootPath()+"/Api/LookUp/GetBuilindMaterialList?Screen=Property",

            success: function (data) {
                LookupData = data;
                var lookup = {};
                
                var result = [];

                for (var i = 0;i< data.length; i++) {
                    var name = data[i].typeName;

                    if (!(name in lookup)) {
                        lookup[name] = 1;
                        result.push(name);
                    }
                }
                ddltype = result;
                for (var j = 0; j < result.length; j++) {
                    var html ='';
                    for (var i = 0;i< data.length; i++) {

                        if (data[i].typeName == result[j]) {
                            html = html + '<option value="' + data[i].id + '">' + data[i].nameEn + '</option>'
                        }
                       
                       
                       
                    }
                    html = "<option value=''></option> " + html;
                    $('#' + result[j]).html(html)
                }
                $.unblockUI();
              //  $("select").each(function (item) {
              //      var html = $.map(data, function (lcn) {
              //          return '<option value="' + lcn.id + '">' + lcn.nameEn + '</option>'
               //     }).join('');
               //     html = "<option value=''></option> " + html;
               //     $('#SubLandUser').html(html)
               // });


            }

        });

});

function uploadFiles(inputId) {
    var Id;
    var fileUpload = inputId;
    if (fileUpload.files && fileUpload.files[0] && fileUpload.id == "files") {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#PropertyImage').css('visibility', 'visible');
            $('#PropertyImage').attr('src', e.target.result);

         


        }
        reader.readAsDataURL(fileUpload.files[0]);
       
    }
   



    var files = fileUpload.files;
    var formData = new FormData();
    formData.append(files[0].name, files[0]);





    $.ajax({
        url: RootPath()+"/Api/Upload/UploadPropertyDocument?PropertyId=" + $("#PropertyId").val() + "&Description=" + $("#PropertyDocument").val(),

        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data1) {


            $("#tbl-PropertyDocument > tbody").empty();
            for (i = 0; i < data1.length; i++) {
                var data = data1[i];
                var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.documentName + "</td><td>" + data.documentName.split('.')[1] + "</td><td>" + data.description + "</td><td> <a href='"+RootPath()+"/API/Upload/Download?DocumentId=" + data.id + "')>Open Document</a></td>" + "<td><a href='#' onclick=DeleteDocument('" + data.id + "')>Delete</a></td></tr>";;
                $("#tbl-PropertyDocument").append(markup);
                // $("#GroupId").val(data.groupID);



            }


        }
    });
}


function retriveRecord() {

    this.BuldingMeterialList();
    this.GetPropertyWallsList();
    this.GetPropertyTreeList();
    this.GetPropertyCropList();
    this.GetPropertyWellList();
    this.GetPropertyTankList();
    this.GetPropertyChannelList();
    this.GetPropertyItemList();
    this.GetPropertyDocumentList();
    this.GetPropertyLandInfo();
}
function BuldingMeterialList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyMeterial?PropertyId=" + $("#PropertyId").val(), // Controller/View
           
            success: function (data1) {

                $("#tbl-Meterial > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td>" + data.totalArea + "</td><td>" + data.note + "</td> <td><a href='#' onclick=DeleteMeterial('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Meterial").append(markup);


                }
            }

        });

}
function GetPropertyWallsList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyWalls?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Walls > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.nameEn + "</td><td>" + data.height + "</td><td>" + data.thickness + "</td><td>" + data.length + "</td><td>" + data.line + "</td> <td><a href='#' onclick=DeleteWalls('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Walls").append(markup);


                }
            }

        });

}
function GetPropertyTreeList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyTreeList?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Trees > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.treeCodeNameEn + "</td><td>" + data.categoryNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.sizeNameEn + "</td><td>" + data.number + "</td> <td><a href='#' onclick=DeleteTree('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Trees").append(markup);


                }
            }

        });

}
function GetPropertyCropList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyCropList?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Crop > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.cropNameEn + "</td><td>" + data.area + "</td><td>" + data.production + "</td> <td><a href='#' onclick=DeleteCrop('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Crop").append(markup);


                }
            }

        });

}
function GetPropertyWellList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyWells?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Well > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.wellCodeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.sizeEn + "</td><td>" + data.claddingNameEn + "</td><td>" + data.cladSizeEn + "</td><td>" + data.soilNameEn + "</td><td>" + data.statusAr + "</td> <td><a href='#' onclick=DeleteWell('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Well").append(markup);


                }
            }

        });

}
function GetPropertyTankList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyTank?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Tank > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.sizeEn + "</td><td>" + data.claddingNameEn + "</td><td>" + data.cladSizeEn + "</td><td>" + data.soilNameEn + "</td><td>" + data.statusAr + "</td> <td><a href='#' onclick=DeleteTank('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Tank").append(markup);


                }
            }

        });

}
function GetPropertyChannelList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyChannel?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Channel > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.claddingNameEn + "</td><td>" + data.width + "</td><td>" + data.height + "</td><td>" + data.length + "</td> <td><a href='#' onclick=DeleteChannel('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Channel").append(markup);


                }

            }

        });

}
function GetPropertyItemList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyItem?PropertyId=" + $("#PropertyId").val(), // Controller/View

            success: function (data1) {

                $("#tbl-Item > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.codeNameEn + "</td><td>" + data.typeNameEn + "</td><td>" + data.descriptionEn + "</td><td>" + data.number + "</td><td>" + data.conditionEn + "</td> <td><a href='#' onclick=DeleteItem('" + data.id + "')>Delete</a></td></tr>";
                    $("#tbl-Item").append(markup);


                }

            }

        });

}
function GetPropertyDocumentList() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: RootPath()+"/Api/Upload/GetDocumentByParent?id=" + $("#PropertyId").val(),

            success: function (data1) {

                $("#tbl-PropertyDocument > tbody").empty();
                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    var markup = "<tr><td>" + (i + 1) + "</td><td>" + data.documentName + "</td><td>" + data.documentName.split('.')[1] + "</td><td>" + data.description + "</td><td> <a href='"+RootPath()+"'/API/Upload/Download?DocumentId=" + data.id + "')>Open Document</a></td>" + "<td><a href='#' onclick=DeleteDocument('" + data.id + "')>Delete</a></td></tr>";;;
                    $("#tbl-PropertyDocument").append(markup);
                    // $("#GroupId").val(data.groupID);



                }

            }

        });

}

function GetPropertyLandInfo() {
    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "GetPropertyLandInfo?PropertyId=" + $("#PropertyId").val(),

            success: function (data) {
                ID: $("#ProjectInfoId").val(data.id); //Reading text box values using Jquery
                $("#LandUse").val(data.landUse);
                $("#LandUse").change();
                $("#SubLandUserHidden").val(data.subLandUse);
                $("#ActualLandUserHidden").val(data.actualLandUse);
                $("#TotalArea").val(data.totalArea);
                $("#AffectedLandArea").val(data.affectedLandArea);
                $("#RemainingLandArea").val(data.remainingLandArea);

                $("#TotalBuildAre").val(data.totalBuildAre);
                $("#AffectedBuildArea").val(data.affectedBuildArea);
                $("#RemainingBuildArea").val(data.remainingBuildArea);
                $("#PropertyInfoRemark").val(data.remark);
                                                           

            }

        });

}
function DeleteMeterial(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyMeterial",
            data: {
                Id: id //Reading text box values using Jquery
                


            },
            success: function (data) {
               
                BuldingMeterialList();

            }

        });

}
function DeleteWalls(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyWalls",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyWallsList();

            }

        });

}
function DeleteTree(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyTree",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyTreeList();

            }

        });

}
function DeleteCrop(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyCrop",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyCropList();

            }

        });

}
function DeleteWell(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyWells",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyWellList();

            }

        });

}
function DeleteTank(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyTank",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyTankList();

            }

        });

}
function DeleteChannel(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyChannel",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyChannelList();

            }

        });

}
function DeleteItem(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: "DeletePropertyItem",
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyItemList();

            }

        });

}

function DeleteDocument(id) {
    $.ajax(
        {
            type: "DELETE", //HTTP POST Method
            url: RootPath()+"/Api/Upload/DeleteDocument?Id=" + id,
            data: {
                Id: id //Reading text box values using Jquery



            },
            success: function (data) {

                GetPropertyDocumentList();

            }

        });

}
