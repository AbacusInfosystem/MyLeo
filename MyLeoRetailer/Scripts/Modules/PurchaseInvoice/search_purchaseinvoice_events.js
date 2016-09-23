$(function () {
    document.getElementById("btnEditPurchaseInvoice").disabled = true;

    Get_Purchase_Invoices();

    $(document).on('change', '[name="Purchase_Invoice_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseInvoiceId").val(this.value);
            //document.getElementById('btnEditPurchaseInvoice').disabled = false;
        }
    });

    $("[name='Filter.Purchase_Invoice_No']").focusout(function () {
        Get_Purchase_Invoices();
    });


    $("#btnCreatePurchaseInvoice").click(function () {
        $("#frmPurchaseInvoice").attr("action", "/PurchaseInvoice/Index");
        $("#frmPurchaseInvoice").submit();
    });

    $("#btnEditPurchaseInvoice").click(function () {
       
    });

});