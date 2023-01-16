$(document).ready(function () {  

    $.blockUI({ message: $('#customloader') });

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: RootPath() + "/Finance/InvoiceList", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                $("#tbl-invoice-history > tbody").html('');

                for (var i = 0; i < data.length; i++) {

                    $("#tbl-invoice-history > tbody:last-child").append("<tr><td id='tdid' name='tdid'>" + data[i].id + "</td><td id='tdname' name='tdname'>" + data[i].customer_Name + "</td><td id='tdvalue' name='tdvalue'>" + data[i].invoice_Date + "</td><td id='tdid' name='tdid'>" + data[i].invoice_Number + "</td><td id='tdid' name='tdid'>" + data[i].customer_Address + "</td> <td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>");

                }
                clear();
                $.unblockUI();
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);

                $.unblockUI();
            }

        });

    $("#SaveTransaction").click(function (e) {

        $.blockUI({ message: $('#customloader') });

        $.ajax(
            {
                type: "POST", //HTTP POST Method
                url: RootPath() + "/Finance/SaveResource", // Controller/View

                data: { //Passing data

                    Invoice_Number: $("#Invoice_Number").val(), //Reading text box values using Jquery
                    Invoice_Date: $("#Invoice_Date").val(),
                    Customer_Name: $("#Customer_Name").val(),
                    Customer_Address: $("#Customer_Address").val(), //Reading text box values using Jquery
                    LPO_Number: $("#LPO_Number").val(),
                    LPO_Date: $("#LPO_Date").val()
                },
                success: function (data) {

                    // Populate the Table with Finance Income List

                    $("#tbl-invoice-history > tbody").html('');

                    for (var i = 0; i < data.length; i++) {

                        $("#tbl-invoice-history > tbody:last-child").append("<tr><td id='tdid' name='tdid'>" + data[i].id + "</td><td id='tdname' name='tdname'>" + data[i].customer_Name + "</td><td id='tdvalue' name='tdvalue'>" + data[i].invoice_Date + "</td><td id='tdid' name='tdid'>" + data[i].invoice_Number + "</td><td id='tdid' name='tdid'>" + data[i].customer_Address + "</td> <td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='view'></i><i class='metismenu-icon lnr-pencil' style='cursor: pointer; margin-left: 10px;' title='edit'></i><i class='metismenu-icon lnr-trash' style='cursor: pointer; margin-left: 10px;' title='delete'></i></div></td></tr>");

                    }
                    clear();
                    $.unblockUI();
                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

        e.preventDefault();

    });

    $('#tbl-invoice-history').off().on('click', 'tbody tr td', function (e) {

        $.blockUI({ message: $('#customloader') });

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

        $.unblockUI();
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

        $.blockUI({ message: $('#customloader') });

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

                    $.unblockUI();

                },
                error: function (xhr) {
                    alert(xhr.responseText + xhr.statusText);

                    $.unblockUI();
                }

            });

    });

    $.unblockUI();

});