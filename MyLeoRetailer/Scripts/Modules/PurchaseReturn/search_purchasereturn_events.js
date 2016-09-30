$(document).ready(function () {

    document.getElementById('btnEditPurchaseReturn').disabled = false;
   
    Get_Purchase_Returns();

    $(document).on('change', '[name="Purchase_Return_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseReturnId").val(this.value);
            document.getElementById('btnEditPurchaseReturn').disabled = false;
            document.getElementById('btnCreatePurchaseReturn').disabled = true;
        }
    });

    $("[name='Filter.Debit_Note_No']").focusout(function () {
        Get_Purchase_Returns();
    });


    $("#btnCreatePurchaseReturn").click(function () {
        $("#frmPurchaseReturn").attr("action", "/PurchaseReturn/Index");
        $("#frmPurchaseReturn").submit();
    });

});