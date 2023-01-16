$(document).ready(function () {

    //alert("Document.Ready");
    populatemasterProjectType();
    populatemasterFunding();
    populatemasterBudget();
    populatemasterBenefit();
    populatemasterMandate();
    populatemasterPopulation();
   
    populatemasterRisk();

    // Not Working 
    $('#txtvalueid').prop('readonly', true);             // mark it as read only
    $('#txtvalueid').css('background-color', '#DEDEDE'); // change the background color  

    $("#iframe_main_container").on('click', '#expanderHeadProject', function () {
        $("#expanderContentProject").slideToggle();
        if ($("#expanderSignProject").text() == "-") {
            $("#expanderSignProject").html("+")
        }
        else {
            $("#expanderSignProject").text("-")
        }
    });

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

    $('#iframe_main_container').on('click', '#btnsaveproject', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<name />').text($('#txtvaluename').val()),
            $('<title />').text($('#txtvaluetitle').val()),
            $('<feature />').text($('#txtvaluefeture').val()),
            $('<description />').text($('#txtvaluedescription').val()),
            $('<priority />').text(0),
            $('<xrank />').text(0)
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<project />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 159,
                inputXml: escape($_postParams.html())
            },
            dataType: "xml",
            success: function (data) {
                $(data).find('root').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    $("#txtvalueid").val(id);
                    alert("Saved Successfully");
                });
            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }
        });
    });

    $('#iframe_main_container').on('click', '#btnsaverank', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<id />').text($('#txtvalueid').val()),
            $('<funding />').text($('#funding_selection :selected').val()),
            $('<budget />').text($('#budget_selection :selected').val()),
            $('<population />').text($('#population_selection :selected').val()),
            $('<risk />').text($('#risk_selection :selected').val()),
            $('<benefit />').text($('#benefit_selection :selected').val()),
            $('<mandate />').text($('#mandate_selection :selected').val()),
            $('<projecttype />').text($('#project_type_selection :selected').val()),
            $('<projecttypecategory />').text($('#project_type_category_selection :selected').val())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<rank />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 161,
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

    function populatemasterFunding() {

        //Display 'loading' status in the state select list
        $("#funding_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 138
            },
            dataType: "xml",
            success: function (data) {
                $("#funding_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#funding_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterBudget() {

        //Display 'loading' status in the state select list
        $("#budget_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 139
            },
            dataType: "xml",
            success: function (data) {
                $("#budget_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#budget_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterBenefit() {

        //Display 'loading' status in the state select list
        $("#benefit_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 140
            },
            dataType: "xml",
            success: function (data) {
                $("#benefit_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#benefit_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterMandate() {

        //Display 'loading' status in the state select list
        $("#mandate_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 141
            },
            dataType: "xml",
            success: function (data) {
                $("#mandate_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#mandate_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterPopulation() {

        //Display 'loading' status in the state select list
        $("#population_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 142
            },
            dataType: "xml",
            success: function (data) {
                $("#population_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#population_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterProjectType() {

        //Display 'loading' status in the state select list
        $("#project_type_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 143
            },
            dataType: "xml",
            success: function (data) {
                $("#project_type_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#project_type_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemasterRisk() {

        //Display 'loading' status in the state select list
        $("#risk_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 145
            },
            dataType: "xml",
            success: function (data) {
                $("#risk_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#risk_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    //If parent option is changed
    $("#projectype").on('change', 'select#project_type_selection', function () {
        var parent = $(this).val(); //get option value from parent 
        // This code will provide the Text of Selected Option
        var textParent = this.options[this.selectedIndex].innerHTML

        //Display 'loading' status in the state select list
        $("#project_type_category_selection").html('<option value="">Loading...</option>');

        populatemasterProjectTypeCategory(textParent);

    });

    function populatemasterProjectTypeCategory(projecttype) {

        //Display 'loading' status in the state select list
        $("#project_type_category_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 144,
                cat: projecttype
            },
            dataType: "xml",
            success: function (data) {
                $("#project_type_category_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#project_type_category_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });
                //populatespecificfunding("#project_funding_selection", data);

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    // NEW CODE FOR PROJECT PRIORITIZATION - END HERE     

});            //On Ready

