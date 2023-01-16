function Edit(Name, value) {
    $('#txtName').val(Name);
    $('#txtKey').val(value);
}
function EditFromJs(data) {
    $('#txtName').val(data.name);
    $('#txtKey').val(data.value);
}

$(document).ready(function () {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "Resource/getResourceList",
            success: function (data) {

                // Populate the Table with Finance Income List

                $("#tbl-resource-history > tbody").html('');

                for (var i = 0; i < data.length; i++) {

                    $("#tbl-resource-history > tbody:last-child").append("<tr><td id='tdid' name='tdid'>" + data[i].key + "</td><td id='tdname' name='tdname'>" + data[i].name + "</td><td id='tdvalue' name='tdvalue'>" + data[i].value + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>");

                }
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });

    $("#SaveTransaction").click(function (e) {

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: "Resource/SaveResource", // Controller/View

                data: { //Passing data

                    Key: $("#txtid").val(), //Reading text box values using Jquery
                    Name: $("#txtName").val(),
                    Value: $("#txtValue").val(),
                },
                success: function (data) {

                    // Populate the Table with Finance Income List

                    $("#tbl-resource-history > tbody").html('');

                    for (var i = 0; i < data.length; i++) {

                        $("#tbl-resource-history > tbody:last-child").append("<tr><td id='tdid' name='tdid'>" + data[i].key + "</td><td id='tdname' name='tdname'>" + data[i].name + "</td><td id='tdvalue' name='tdvalue'>" + data[i].value + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>");

                    }
                    clear();
                 
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

        e.preventDefault();

    });

    $('#tbl-resource-history').off().on('click', 'tbody tr td', function (e) {

        var $checked = $(this).parents("tr").find(":radio:checked");
        if ($checked.length) {

            var id = $(this).parents("tr").find("#tdid").html();
            var name = $(this).parents("tr").find("#tdname").html();
            var value = $(this).parents("tr").find("#tdvalue").html();

            $("#txtid").val(id);
            $("#txtName").val(name);
            $("#txtValue").val(value);
            $("#txtValue").focus();
        }

    });

    $('#txtValue').focus(function () {

        var center = $(window).height() / 2;
        var top = $(this).offset().top;
        $(window).scrollTop(10);
        //if (top > center) {
        //    $(window).scrollTop(top - center);
        //}
    });
    $("#btnClear").click(function (e) {

        clear();
    });
    function clear() {
        $("#txtid").val('');
        $("#txtName").val('');
        $("#txtValue").val('');

        var $checked = $('#tbl-resource-history').find(":radio:checked");
        if ($checked.length) {

            $($checked).prop('checked', false);
        }

    }

    $("#SearchTransaction").click(function (e) {

        $.ajax(
            {
                type: "GET", //HTTP GET Method
                url: "GetResourceHistory", // Controller/View
                data:
                {
                    Company: $('#txt-filter-english').val(),
                    Lawyer: $('#txt-filter-arabic').val()
                },
                success: function (data) {

                    $("#tbl-resource-history > tbody").html('');

                    for (var i = 0; i < data.length; i++) {

                        $("#tbl-resource-history > tbody:last-child").append("<tr><td id='tdid' name='tdid'>" + data[i].key + "</td><td id='tdname' name='tdname'>" + data[i].name + "</td><td id='tdvalue' name='tdvalue'>" + data[i].value + "</td><td id='tdAction' name='tdAction'><div class='position-relative form-check'><input name='radiobtnselection' id='radiobtnselection' type='radio' class='form-check-input'></div></td></tr>");

                    }
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);
                }

            });

    });

});