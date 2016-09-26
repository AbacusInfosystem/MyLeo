$(function () {


    $("#txtUser_Name").focusout(function () {

        $(".scroll-bar").html("");
        $.ajax({
            url: '/login/get-employee-branches',
            data: { user_Name: $(this).val() },
            method: 'POST',
            async: false,
            success: function (response) {

                var htmlText = "";
                var objList = $.parseJSON(response);

                if (objList.length > 0) {

                    htmlText += "<div class='col-md-12'>";
                    htmlText += "<div class='col-md-8'>";
                    htmlText += "<label style='color:white;'>Select All</label>";
                    htmlText += "</div>";
                    htmlText += "<div class='col-md-4'>";
                    htmlText += "<label class='switch'>";
                    htmlText += "<input checked='true' value='1' id='chkAllBrand' type='checkbox'>";
                    htmlText += "<span></span>";
                    htmlText += "</label>";
                    htmlText += "</div>";
                    htmlText += "</div>";

                    for (i = 0; i < objList.length; i++) {

                        htmlText += "<div class='col-md-12'>";
                        htmlText += "<div class='col-md-8'>";
                        htmlText += "<label style='color:white;'>" + objList[i].Branch_Name + "</label>";
                        htmlText += "</div>";
                        htmlText += "<div class='col-md-4'>";
                        htmlText += "<label class='switch'>";
                        htmlText += "<input checked class='brands' value='" + objList[i].Branch_ID + "' id='chkBrand_" + i + "' type='checkbox'>";
                        htmlText += "<span></span>";
                        htmlText += "</label>";
                        htmlText += "</div>";
                        htmlText += "</div>";

                    }
                }
                $(".scroll-bar").html(htmlText);
            }
        });

    });


    $(document).on("change", "#chkAllBrand", function () {

        if ($(this).prop('checked')) {
            
            $(".brands").propAttr('checked', 'checked');

        }
        else {
            $(".brands").removeAttr('checked');
         
        }

    });


    $("#btnLogin").click(function () {

        var Ids = "";

        $(".brands").each(function () {

            if ($(this).prop('checked')) {
             
                Ids += $(this).val() + ",";
              
            }

        });

        Ids = Ids.slice(0, -1);
        $("#hdnBranch_Ids").val(Ids);
        
        if ($("#frmLogin").valid())
        {
            var divHTML = "";
            divHTML = $('.scroll-bar').html();
            
            if (divHTML == "") {
                $("#lblBranchError").show();
                
            }
            else {
                $("#lblBranchError").hide();
               
                $("#frmLogin").attr("action", "/Login/Authenticate");
                $("#frmLogin").submit();
            }
            
        }

    });


    



    $("#frmLogin").validate({
        rules: {

            "Cookies.User_Name": { required: true },

            "Cookies.Password": { required: true },
        },
        messages: {

            "Cookies.User_Name": { required: "User Name is required." },

            "Cookies.Password": { required: "Password is required." },

        }
    });





});