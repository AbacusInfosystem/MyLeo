

$(function () {

    Get_Alterations();

    $(document).on("click", "[name='Alteration_List']", function () {

        Get_Alteration_By_Id(this);

    });

    $(document).on('change', '[name="Alteration_List"]', function (event) {
        alert();
        if ($(this).prop('checked')) {
            $("#hdnAlteration_ID").val(this.value);
        }
    });

    $("#btnEditAlteration").click(function () {
        $("#frmAlteration").attr("action", "/Alteration/Get_Alteration_By_Id");
        $("#frmAlteration").submit();
    });

    $("[name='Filter.Customer_Mobile_No']").focusout(function () {

        Get_Alterations();
        
    });




});

