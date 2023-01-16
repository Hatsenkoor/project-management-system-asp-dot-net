$(document).ready(function () {

    //alert("Document.Ready");

    populatemasterpriority();
    populatemasteractive();
    populatemasterpriorityweight();

    // Not Working 
    $('#txtdealid').prop('readonly', true);             // mark it as read only
    $('#txtdealid').css('background-color', '#DEDEDE'); // change the background color  

    $("#iframe_main_container").on('click', '#expanderHeadPriority', function () {
        $("#expanderContentPriority").slideToggle();
        if ($("#expanderSignPriority").text() == "-") {
            $("#expanderSignPriority").html("+")
        }
        else {
            $("#expanderSignPriority").text("-")
        }
    });

    // NEW CODE FOR PROJECT PRIORITIZATION - START HERE

    function populatemasterpriority() {

        //Display 'loading' status in the state select list
        $("#priority_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 158
            },
            dataType: "xml",
            success: function (data) {
                $("#priority_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#priority_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterpriorityweight() {

        //Display 'loading' status in the state select list
        $("#weight_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 147
            },
            dataType: "xml",
            success: function (data) {
                $("#weight_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#weight_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasteractive() {

        //Display 'loading' status in the state select list
        $("#activation_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 156
            },
            dataType: "xml",
            success: function (data) {
                $("#activation_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#activation_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    $('#iframe_main_container').on('click', '#btnpriority', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#priority_selection :selected').text()),
            $('<weight />').text($('#weight_selection :selected').val()),
            $('<active />').text($('#activation_selection :selected').val())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<activation />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 157,
                inputXml: escape($_postParams.html())
            },
            dataType: "xml",
            success: function (data) {
                $(data).find('root').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    alert("Saved Successfully");
                });
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }
        });
    });


    // NEW CODE FOR PROJECT PRIORITIZATION - END HERE     

});             //On Ready

