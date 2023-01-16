$(document).ready(function () {

    //alert("Document.Ready");

    populatemasterFunding();
    populatemasterBudget();
    populatemasterBenefit();
    populatemasterMandate();
    populatemasterPopulation();
    populatemasterProjectType();
    populatemasterRisk();

    populatemasterprojecttyperank();
    populateprojecttypecategoryrank();
    populatepopulationrank();
    populatebudgetrank()
    populatemandaterank();
    populatebenefitrank();
    populateriskrank();
    populatefundingrank();

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

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    //If parent option is changed
    $("#iframe_main_container").on('change', 'select#project_type_selection', function () {
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

    function populatemasterprojecttyperank() {

        //Display 'loading' status in the state select list
        $("#project_type_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#project_type_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#project_type_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populateprojecttypecategoryrank() {

        //Display 'loading' status in the state select list
        $("#project_type_category_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#project_type_category_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#project_type_category_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatepopulationrank() {

        //Display 'loading' status in the state select list
        $("#population_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#population_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#population_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatebudgetrank() {

        //Display 'loading' status in the state select list
        $("#budget_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#budget_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#budget_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatemandaterank() {

        //Display 'loading' status in the state select list
        $("#mandate_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#mandate_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#mandate_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatebenefitrank() {

        //Display 'loading' status in the state select list
        $("#benefit_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#benefit_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#benefit_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populateriskrank() {

        //Display 'loading' status in the state select list
        $("#risk_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#risk_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#risk_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    function populatefundingrank() {

        //Display 'loading' status in the state select list
        $("#funding_rank_selection").html('<option value="">Loading...</option>');

        $.ajax({
            type: "GET",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 146
            },
            dataType: "xml",
            success: function (data) {
                $("#funding_rank_selection").html(""); //reset child options

                $(data).find('root result').each(function () { //populate child options 
                    var id = $(this).find('ID').text();
                    var name = $(this).find('Name').text();

                    $("#funding_rank_selection").append("<option value=\"" + id + "\">" + name + "</option>");
                });

            },
            error: function (xhr) {
                alert(xhr.responseText + xhr.statusText);
            }

        });
    }

    $('#iframe_main_container').on('click', '#btnprojecttype', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#project_type_selection :selected').text()),
            $('<rank />').text($('#project_type_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 153,
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

    $('#iframe_main_container').on('click', '#btnprojecttypecategory', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#project_type_category_selection :selected').text()),
            $('<rank />').text($('#project_type_category_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 154,
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

    $('#iframe_main_container').on('click', '#btnpopulation', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#population_selection :selected').text()),
            $('<rank />').text($('#population_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 152,
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

    $('#iframe_main_container').on('click', '#btnbudget', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#budget_selection :selected').text()),
            $('<rank />').text($('#budget_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 149,
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

    $('#iframe_main_container').on('click', '#btnmandate', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#mandate_selection :selected').text()),
            $('<rank />').text($('#mandate_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 151,
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

    $('#iframe_main_container').on('click', '#btnbenefit', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#benefit_selection :selected').text()),
            $('<rank />').text($('#benefit_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 148,
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

    $('#iframe_main_container').on('click', '#btnrisk', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#risk_selection :selected').text()),
            $('<rank />').text($('#risk_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 155,
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

    $('#iframe_main_container').on('click', '#btnfunding', function () {

        var $projecttype = $('<XMLDocument />');
        $projecttype.append(
            $('<type />').text($('#funding_selection :selected').text()),
            $('<rank />').text($('#funding_rank_selection :selected').text())
        );

        var $_postParams = $('<XMLDocument />');
        $_postParams.append($('<root />').append($('<priority />').append($projecttype.html())));
        alert($_postParams.html());

        $.ajax({
            type: "POST",
            url: "http://projectpriority.hermannsoftware.com",
            data: {
                app: 34,
                actn: 150,
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

});            //On Ready

