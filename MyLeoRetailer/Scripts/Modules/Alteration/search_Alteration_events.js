

$(function () {

    Get_Alterations();

    $("[name='Filter.Customer_Mobile_No']").focusout(function () {

        Get_Alterations();

    });

    $("#btnEditAlteration").click(function () {
        $("#frmAlteration").attr("action", "/Alteration/Get_Alteration_By_Id");
        $("#frmAlteration").attr("method", "post");
        $("#frmAlteration").submit();
    });

    $(document).on('change', '[name="Alteration_List"]', function (event) {

        if ($(this).prop('checked')) {
            $("#hdnAlteration_ID").val(this.value);
            $("#btnEditAlteration").show();
        }
    });


    $("#btncreateA").click(function () {

        $("#frmAlteration").attr("action", "/Alteration/Index");
        $("#frmAlteration").submit();

    });


    $("#btnEditAlteration").click(function () {
        $("#frmAlteration").attr("action", "/Alteration/Get_Alteration_By_Id");
        $("#frmAlteration").submit();
    });



    $(document).on("click", "[name='Alteration_List']", function () {

        Get_Alteration_By_Id(this);

    });

   

   

   



});

