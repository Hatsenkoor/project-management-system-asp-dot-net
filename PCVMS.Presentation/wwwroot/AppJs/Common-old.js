function RootPath() {

    return "http://localhost:5001"
}
$(document).ready(function () {
   
    $("#LanguageOM").click(function (e) {

        $.ajax(
            {
                type: "Get", //HTTP POST Method
                url: RootPath()+"/API/SetLanguage/SetLanguage?Language=ar-om",

                success: function (data1) {
                    window.location.reload(false)

                }

            });


    });
    $("#LanguageUS").click(function (e) {

        $.ajax(
            {
                type: "Get", //HTTP POST Method
                url: RootPath()+"/API/SetLanguage/SetLanguage?Language=en-us",

                success: function (data1) {

                    window.location.reload(false);
                }

            });


    });


    $.ajax(
        {
            type: "Get", //HTTP POST Method
            url: RootPath()+"/User/GetUserPermission",

            success: function (data1) {
               
                var SideMenu1 = "";
                var SideMenu2 = "";
                var SideMenu3 = "";
                var SideMenu4 = "";
                $("#SideMenu1").parent().hide();
                $("#SideMenu2").parent().hide();
                $("#SideMenu3").parent().hide();
                $("#SideMenu4").parent().hide();

                for (i = 0; i < data1.length; i++) {
                    var data = data1[i];
                    if (data.menuId == 'SideMenu1') {

                        SideMenu1 = SideMenu1 + "<li><a href='" + data.url + "'><i class='metismenu - icon'></i>" + data.nameEn + "</a>  </li>";
                        $("#SideMenu1").parent().show();
                        $('#SideMenu1').css("visibility", "visible");
                    }
                    else if (data.menuId == 'SideMenu2') {
                        SideMenu2 = SideMenu2 + "<li><a href='" + data.url + "'><i class='metismenu - icon'></i>" + data.nameEn + "</a>  </li>";
                        $("#SideMenu2").parent().show();
                        $('#SideMenu2').css("visibility", "visible");
                    }
                    else if (data.menuId == 'SideMenu3') {
                        SideMenu3 = SideMenu3 + "<li><a href='" + data.url + "'><i class='metismenu - icon'></i>" + data.nameEn + "</a>  </li>";
                        $("#SideMenu3").parent().show();
                        $('#SideMenu3').css("visibility", "visible");
                    }
                    else if (data.menuId == 'SideMenu4') {
                        SideMenu4 = SideMenu3 + "<li><a href='" + data.url + "'><i class='metismenu - icon'></i>" + data.nameEn + "</a>  </li>";
                        $("#SideMenu4").parent().show();
                        $('#SideMenu4').css("visibility", "visible");
                    }
                }

                $('#SideMenu1').html(SideMenu1);
                $('#SideMenu2').html(SideMenu2);
                $('#SideMenu3').html(SideMenu3);
                $('#SideMenu4').html(SideMenu4);
               
               
                
              
                
            }

        });
    
   

});
function ShowLoader() {
    $.blockUI({ message: '<h1><img src="busy.gif" /> Just a moment...</h1>' });
}