
$(document).ready(function () {

    getAllInoice();

    $("#tbl-payment-invoice-list > tbody").on("click", "tr td i", function (evt) {

        evt.preventDefault();

        // this is the code to make the selected row highlighted
        //start
        if ($(this).parent("tr").hasClass('active')) {

            $(this).parents("tr").removeClass("active");
        } else {

            $('#tbl-payment-invoice-list > tbody tr.active').removeClass('active');
            $(this).parents("tr").addClass("active");
        }
       //end

        var event = $(this)[0].title;
        var selected_id = $(this).parents("tr").find("#tdid").html();
        $("#ID").val(selected_id);

        if (event === 'pdf invoice' || event === 'print invoice' || event === 'view invoice') {

            alert('pdf certificate');

            generatepdf(selected_id);

        } else {

            alert('print certificate');

        } 

        

    });
   
});

function getAllInoice() {

    $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "getAllInoice", // Controller/View
            success: function (data) {

                // Populate the Table with Finance Income List

                populateInvoiceGrid(data);
               
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
}

function populateInvoiceGrid(data) {

    // Populate the Table with Finance Income List

    $("#tbl-payment-invoice-list > tbody").html('');

    if (data.length > 0) {
        $('#no_record_screen').hide();
    }
    else {
      
        $('#no_record_screen').show();
    }

    for (var i = 0; i < data.length; i++) {

        var tempString = "<tr>"
            + "<td style = 'display:none;' id = 'tdid' name = 'tdid' style = 'text-align:center;'>" + data[i].id + "</td>"
            + "<td style = 'display:none;' id = 'tdApp_id' name = 'tdApp_id' style = 'text-align:center;'>" + data[i].appID + "</td>"
            + "<td  id='tdPaymentType' name='tdPaymentType'>" + data[i].paymentType + "</td>"
            + "<td id = 'tdPayment_mode' name = 'tdPayment_mode' style = 'text-align:center;'>" + data[i].payment_mode  + "</td>"
            + "<td id ='tdAmount' name='tdAmount' style='text-align:center;'>" + data[i].amount + "</td>"
            + "<td id ='tdTrans_date' name='tdTrans_date' style='text-align:center;'>" + data[i].trans_date + "</td>"
            + "<td id ='tdRegistrationNo' name='tdRegistrationNo' style='text-align:center;'>" + data[i].registrationNo  + "</td>"
            + "<td class='text-center' id='tdAction' name='tdAction'><div class='position-relative'><i class='metismenu-icon lnr-license' style='cursor: pointer; margin-left: 10px;' title='view invoice'></i><i class='metismenu-icon lnr-printer' style='cursor: pointer; margin-left: 10px;' title='print invoice'></i><i class='metismenu-icon lnr-book' style='cursor: pointer; margin-left: 10px;' title='pdf invoice'></i></div></td></tr>";
          // addpend the final string
        $("#tbl-payment-invoice-list> tbody:last-child").append(tempString);
    }
}

function generatepdf(Id) {

   $.ajax(
        {
            type: "GET", //HTTP POST Method
            url: "InvoiceDesign?Id=" + Id, // Controller/View

            success: function (data) {

                window.open("http://localhost:5003" +data.url, '_blank');
             
            },
            error: function (xhr) {
         
                alert(xhr.responseText + xhr.statusText);
            }

        });
}
