$(function () {
    //document.getElementById("btnEditPurchaseInvoice").disabled = true;

    Get_Replacement();

    $(document).on('change', '[name="Replacement_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnReplacementId").val(this.value);
            //document.getElementById('btnEditPurchaseInvoice').disabled = false;
        }
    });

    $("[name='Filter.Replacement_No']").focusout(function () {
        Get_Replacement();
    });


    $("#btnCreateReplacement").click(function () {
        $("#frmReplacement").attr("action", "/Replacement/Index");
        $("#frmReplacement").submit();
    });

    //$("#btnEditPurchaseInvoice").click(function () {

    //});

});