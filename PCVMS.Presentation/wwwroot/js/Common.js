function RootPath() {

    return "http://localhost:55181"
}
$(document).ready(function () {

    $("#LanguageOM").click(function (e) {

        $.ajax(
            {
                type: "Get", //HTTP POST Method
                url: RootPath() + "/API/SetLanguage/SetLanguage?Language=ar-om",

                success: function (data1) {
                    window.location.reload(false)

                }

            });
    });
    $("#LanguageUS").click(function (e) {

        $.ajax(
            {
                type: "Get", //HTTP POST Method
                url: RootPath() + "/API/SetLanguage/SetLanguage?Language=en-us",

                success: function (data1) {

                    window.location.reload(false);
                }

            });
    });

    $.ajax({
        type: "GET", //HTTP POST Method
        url: RootPath() + "/User/GetUserPermission",

        success: function (data1) {

            var SideMenu1 = ' <li class="app-sidebar__heading"></li>'
            var submenu = '';
            // var MenuRow = [["SideMenu1"], ["SideMenu2"], ["SideMenu3"], ["SideMenu4"], ["SideMenu5"]]
            var UniqueNames = $.unique(data1.map(function (d) { return d.menuId; })); //.sort(m);
            var MenuRow = UniqueNames.filter(function (item, i, sites) {
                return i == sites.indexOf(item);
            });

            //# region Fertilizer Sub Menu

            var submenu3level3 = '';
            var submenu4level3 = '';
            var submenu5level1 = '';
            var submenu5level2 = '';
            var submenu5level3 = '';

            for (i = 0; i < data1.length; i++) {

                var data = data1[i];

                if (data.menuId === 'sidemenu3' && data.parentId !== null) {
                    submenu3level3 = submenu3level3 + "<li><a href='" + data.url + "'><i class='metismenu-icon'></i>" + data.nameEn + "</a></li>";
                }
                else if (data.menuId === 'sidemenu4' && data.parentId !== null) {
                    submenu4level3 = submenu4level3 + "<li><a href='" + data.url + "'><i class='metismenu-icon'></i>" + data.nameEn + "</a></li>";
                }
                else if (data.menuId === 'sidemenu5' && data.parentId === '55B420E4-B575-43C4-974B-887918A0F1DF') {
                    submenu5level1 = submenu5level1 + "<li><a href='" + data.url + "'><i class='metismenu-icon'></i>" + data.nameEn + "</a></li>";
                }
                else if (data.menuId === 'sidemenu5' && data.parentId === '8C1A125E-3287-46DB-AA56-9610B3EF586A') {
                    submenu5level2 = submenu5level2 + "<li><a href='" + data.url + "'><i class='metismenu-icon'></i>" + data.nameEn + "</a></li>";
                }
                else if (data.menuId === 'sidemenu5' && data.parentId === 'E57A942B-C119-4933-BD82-86E7CA85F55D') {
                    submenu5level3 = submenu5level3 + "<li><a href='" + data.url + "'><i class='metismenu-icon'></i>" + data.nameEn + "</a></li>";
                }

            }

            //# end region Fertilizer Sub Menu


            var MenuId = '';
            for (j = 0; j < MenuRow.length; j++) {
                MenuId = MenuRow[j];
                for (i = 0; i < data1.length; i++) {

                    var data = data1[i];
                    if (MenuId == data.menuId) {

                        if (submenu == '') {

                            submenu = submenu + '<li class=""><a href="#" aria-expanded="false">';
                            if (data.menuId == 'sidemenu2') {
                                submenu = submenu + '<i class="metismenu-icon pe-7s-key"></i>';
                            } else if (data.menuId == 'sidemenu3') {
                                submenu = submenu + '<i class="metismenu-icon pe-7s-leaf"></i>';
                            }
                            else if (data.menuId == 'sidemenu4') {
                                submenu = submenu + '<i class="metismenu-icon pe-7s-paint-bucket"></i>';
                            }
                            else if (data.menuId == 'sidemenu5') {

                                submenu = submenu + '<i class="metismenu-icon pe-7s-eyedropper"></i>';
                            }
                            else if (data.menuId == 'sidemenu6') {

                                submenu = submenu + '<i class="metismenu-icon pe-7s-graph3"></i>';
                            }
                            else {

                                submenu = submenu + '<i class="metismenu-icon pe-7s-help1"></i>';
                            }
                            submenu = submenu + data.menuName;
                            submenu = submenu + '<i class="metismenu-state-icon pe-7s-angle-down caret-left"></i></a>'
                            submenu = submenu + '<ul>';
                        }

                        if (data.menuId === 'sidemenu3' && data.nameEn === 'Application')
                        {
                            submenu = submenu + '<li class=""><a href="#" aria-expanded="false">'
                            submenu = submenu + '<i class="metismenu-icon pe-7s-leaf"></i>'
                            submenu = submenu + data.nameEn;
                            submenu = submenu + '<i class="metismenu-state-icon pe-7s-angle-down caret-left"></i></a>'
                           submenu = submenu + "<ul>" + submenu3level3 + "</ul>";
                        }
                        else if (data.menuId === 'sidemenu4' && data.nameEn === 'Application') {
                            submenu = submenu + '<li class=""><a href="#" aria-expanded="false">'
                            submenu = submenu + '<i class="metismenu-icon pe-7s-paint-bucket"></i>'
                            submenu = submenu + data.nameEn;
                            submenu = submenu + '<i class="metismenu-state-icon pe-7s-angle-down caret-left"></i></a>'
                            submenu = submenu + "<ul>" + submenu4level3 + "</ul>";
                        }
                        else if (data.menuId === 'sidemenu5' && data.nameEn === 'Imported') {
                            submenu = submenu + '<li class=""><a href="#" aria-expanded="false">'
                            submenu = submenu + '<i class="metismenu-icon pe-7s-eyedropper"></i>'
                            submenu = submenu + data.nameEn;
                            submenu = submenu + '<i class="metismenu-state-icon pe-7s-angle-down caret-left"></i></a>'
                            submenu = submenu + "<ul>" + submenu5level1 + "</ul>";
                        }
                        else if (data.menuId === 'sidemenu5' && data.nameEn === 'Local') {
                            submenu = submenu + '<li class=""><a href="#" aria-expanded="false">'
                            submenu = submenu + '<i class="metismenu-icon pe-7s-eyedropper"></i>'
                            submenu = submenu + data.nameEn;
                            submenu = submenu + '<i class="metismenu-state-icon pe-7s-angle-down caret-left"></i></a>'
                            submenu = submenu + "<ul>" + submenu5level2 + "</ul>";
                        }
                        else if (data.menuId === 'sidemenu5' && data.nameEn === 'Export') {
                            submenu = submenu + '<li class=""><a href="#" aria-expanded="false">'
                            submenu = submenu + '<i class="metismenu-icon pe-7s-eyedropper"></i>'
                            submenu = submenu + data.nameEn;
                            submenu = submenu + '<i class="metismenu-state-icon pe-7s-angle-down caret-left"></i></a>'
                            submenu = submenu + "<ul>" + submenu5level3 + "</ul>";
                        }
                        else if (data.level === 3 && data.parentId === null)
                        submenu = submenu + "<li><a href='" + data.url + "'><i class='metismenu-icon'></i>" + data.nameEn + "</a></li>";
                    }
                }
                if (submenu != '') {
                    submenu = submenu + '</ul > </li > ';
                    SideMenu1 = SideMenu1 + submenu;
                }
                submenu = '';
            }
            $('#SideMenu0').html(SideMenu1).fadeIn().delay(10000);

            //close sidebar menu
            resizeClass();
        }

    });

    $('#SideMenu0').off().on('click', 'a', function () {

        // alert($(this));

        //  $(this).attr('aria-expanded', true);

    });

    $("#followup-enquiry-view :input").attr("disabled", true);

    $("#folloup-complaint-view :input").attr("disabled", true);
    $("#pcvd-finance-view :input").attr("disabled", true);
    $("#smartwizard-payment-received-finance-view :input").attr("disabled", true);

    $("#eapayment-paid-to-pcvd :input").attr("disabled", true);
    $("#project-extension-view :input").attr("disabled", true);
    $("#site-visit-request-view :input").attr("disabled", true);

    $("#smartwizard-payment-received-ea-view :input").attr("disabled", true);
    $("#smartwizard-objection-approval-view :input").attr("disabled", true);
    $("#decision-draft-review-hide :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-12 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-22 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-32 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-42 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-52 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-62 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-72 :input").attr("disabled", true);
    $("#smartwizard-valuation-draft-82 :input").attr("disabled", true);

    $("#smartwizard-sitevisit-EA :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-22 :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-32 :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-42 :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-52 :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-62 :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-72 :input").attr("disabled", true);
    $("#smartwizard-cf-site-visit-view-82 :input").attr("disabled", true);


    $("#smartwizard-property-site-visit-view :input").attr("disabled", true);
    $("#smartwizard-property-registration-view :input").attr("disabled", true);
    $("#smartwizard-project-registration-view :input").attr("disabled", true);
    $("#smartwizard-consultant-registration-view :input").attr("disabled", true);
    $("#smartwizard-project-location-geometry-view :input").attr("disabled", true);


    $("#smartwizard-project1-view :input").attr("disabled", true);
    $("#smartwizard-project2-view :input").attr("disabled", true);
    $("#smartwizard-project3-view :input").attr("disabled", true);

    $("#smartwizard-project1-approve :input").attr("disabled", true);
    $("#smartwizard-project2-approve :input").attr("disabled", true);
    $("#smartwizard-project3-approve :input").attr("disabled", true);

    $("#smartwizard-project1-progress :input").attr("disabled", true);
    $("#smartwizard-project2-progress :input").attr("disabled", true);
    $("#smartwizard-project3-progress :input").attr("disabled", true);

    $("#smartwizard-project1-completed :input").attr("disabled", true);
    $("#smartwizard-project2-completed :input").attr("disabled", true);
    $("#smartwizard-project3-completed :input").attr("disabled", true);

    $("#smartwizard-decision-Detail-approval :input").attr("disabled", true);
    $("#smartwizard-decision-Detail :input").attr("disabled", true);
    $("#smartwizard-decision-approval-detail :input").attr("disabled", true);
    $("#smartwizard-property-sitevisit-pcvc :input").attr("disabled", true);

    $("#smartwizard-decision-submit :input").attr("disabled", true);

    $("#smartwizard-decision-Detail :input").attr("disabled", true);
    $("#smartwizard-decision-Add-Document :input").attr("disabled", true);


    $("#smartwizard-valuation-Property-Detail :input").attr("disabled", true);
    $("#smartwizard-valuation-Land-Price :input").attr("disabled", true);
    $("#smartwizard-valuation-Building-Material-Price :input").attr("disabled", true);
    $("#smartwizard-valuation-Walls-Parapet-Shades-Price :input").attr("disabled", true);
    $("#smartwizard-valuation-Trees-Crops-Price :input").attr("disabled", true);
    $("#smartwizard-valuation-Water-Storage-Price :input").attr("disabled", true);
    $("#smartwizard-valuation-Miscellaneous-Price :input").attr("disabled", true);
    $("#smartwizard-valuation-Add-Document :input").attr("disabled", true);

    $("#smartwizard-valuation-Property-Detail1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Land-Price1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Building-Material-Price1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Walls-Parapet-Shades-Price1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Trees-Crops-Price1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Water-Storage-Price1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Miscellaneous-Price1 :input").attr("disabled", true);
    $("#smartwizard-valuation-Add-Document1 :input").attr("disabled", true);

    $("#smartwizard-valuation-Property-Detail2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Land-Price2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Building-Material-Price2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Walls-Parapet-Shades-Price2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Trees-Crops-Price2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Water-Storage-Price2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Miscellaneous-Price2 :input").attr("disabled", true);
    $("#smartwizard-valuation-Add-Document2 :input").attr("disabled", true);

    $("#smartwizard-valuation-submit :input").attr("disabled", true);


    $("#EAPayment1 :input").attr("disabled", true);
    $("#EAPayment2 :input").attr("disabled", true);
    $("#EAPayment3 :input").attr("disabled", true);
    $("#EAPayment5 :input").attr("disabled", true);

    $("#smartwizard-objection-approval-draft :input").attr("disabled", true);
    $("#smartwizard-objection-submitted :input").attr("disabled", true);
    $("#objection-approval-1 :input").attr("disabled", true);
    $("#objection-approval-2 :input").attr("disabled", true);

    $("#smartwizard-SpecialCase-submitted :input").attr("disabled", true);
    $("#smartwizard-SpecialCase-Approval-draft :input").attr("disabled", true);

    $("#specialcaseapprovalid1 :input").attr("disabled", true);
    $("#smartwizard-sitevisit-approval-draft :input").attr("disabled", true);
    $("#smartwizard-property-approval :input").attr("disabled", true);
    $("#SelectProperty :input").attr("disabled", true);
    $("#PropertyDetails :input").attr("disabled", true);
    $("#Landinformation :input").attr("disabled", true);
    $("#BuildingMaterialDetail :input").attr("disabled", true);
    $("#WallsParapetShadesDetail :input").attr("disabled", true);
    $("#TreesCropsDetail :input").attr("disabled", true);
    $("#WaterStorageDetail :input").attr("disabled", true);
    $("#MiscellaneousItemsDetail :input").attr("disabled", true);
    $("#AddDocumentDetail :input").attr("disabled", true);

    $("#smartwizard-property-sitevisit-cf-engineer :input").attr("disabled", true);
    $("#smartwizard-property-sitevisit-cf-pcvc :input").attr("disabled", true);
    $("#smartwizard-property-sitevisit-engineer-pcvc :input").attr("disabled", true);
    $("#PropertyLocationId :input").attr("disabled", true);
    $("#PropertyInformationId :input").attr("disabled", true);
    $("#PropertyLocationId1 :input").attr("disabled", true);
    $("#PropertyInformationId1 :input").attr("disabled", true);
    $("#SiteVisitApprovalId :input").attr("disabled", true);
    $("#SiteVisitSubmitId :input").attr("disabled", true);

    $("#sitesurveyengineer1, #sitesurveyengineer2, #sitesurveyengineer3, #sitesurveyengineer4").click(function (e) {

        window.location.href = RootPath() + "/PCVDEngineer/SiteSurvey#step-12";
    });

    $("#sitesurveycf").click(function (e) {

        window.location.href = RootPath() + "/CF/SiteSurvey#step-1";
    });

    $("#propertyreturnedcf").click(function (e) {

        window.location.href = RootPath() + "/CF/Properties#step-1";
    });

    $("#showproject1, #showproject2, #showproject3, #showproject4").click(function (e) {

        window.location.href = RootPath() + "/Gis/Index";
    });

    $("#showproperty1, #showproperty2, #showproperty3, #showproperty4").click(function (e) {

        window.location.href = RootPath() + "/ResidentialPropertyRegistration/Residential";
    });

    $("#showpayment1, #showpayment2, #showpayment3, #showpayment4").click(function (e) {

        window.location.href = RootPath() + "/Finance/Index#step-1";
    });
    $("#showpaymentpaid1, #showpaymentpaid2, #showpaymentpaid3, #showpaymentpaid4").click(function (e) {

        window.location.href = RootPath() + "/Finance/Index#step-2";
    });
    $("#showchequeprint1, #showchequeprint2, #showchequeprint3, #showchequeprint4").click(function (e) {

        window.location.href = RootPath() + "/Finance/Index#step-3";
    });

    $("#showcomplaint1, #showcomplaint2, #showcomplaint3, #showcomplaint4").click(function (e) {

        window.location.href = RootPath() + "/FollowUp/Index#step-1";
    });
    $("#showenquiry1, #showenquiry2, #showenquiry3, #showenquiry4").click(function (e) {

        window.location.href = RootPath() + "/FollowUp/Index#step-2";
    });

    $("#showdispute1, #showdispute2, #showdispute3, #showdispute4").click(function (e) {

        window.location.href = RootPath() + "/FollowUp/Index#step-3";
    });

    // Responsive

    var resizeClass = function () {
        var win = document.body.clientWidth;
        if (win < 1250) {
            $('.app-container').addClass('closed-sidebar');

        } else {

            $('.app-container').addClass('closed-sidebar');
            //$('.app-container').removeClass('closed-sidebar-mobile closed-sidebar');
        }
    };


    $(window).on('resize', function () {
        resizeClass();
    });

    resizeClass();

    // Datepicker for financial year
    $('[data-toggle="datepicker-trigger-projectinspectiondate"]').datepicker({
        trigger: ".datepicker-click-projectinspectiondate",
        autoPick: true,
        autoHide: true
    });

    // Datepicker for financial year
    $('[data-toggle="datepicker-trigger-projectreleasedate"]').datepicker({
        trigger: ".datepicker-click-projectreleasedate",
        autoPick: true,
        autoHide: true
    });
});

function ShowLoader() {
    $.blockUI({ message: '<h1><img src="busy.gif" /> Just a moment...</h1>' });
}

