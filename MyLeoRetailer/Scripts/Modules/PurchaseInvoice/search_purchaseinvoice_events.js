$(document).ready(function () {

    //document.getElementById("btnViewPurchaseInvoice").disabled = true;

    Get_Purchase_Invoices();

    $(document).on('change', '[name="Purchase_Invoice_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseInvoiceId").val(this.value);
            document.getElementById('btnViewPurchaseInvoice').disabled = false;
            document.getElementById('btnCreatePurchaseInvoice').disabled = true;
        }
    });

    $("[name='Filter.Purchase_Invoice_No']").focusout(function () {
        Get_Purchase_Invoices();
    });


    $("#btnCreatePurchaseInvoice").click(function () {
        $("#frmPurchaseInvoice").attr("action", "/PurchaseInvoice/Index");
        $("#frmPurchaseInvoice").submit();
    });

    $("#btnViewPurchaseInvoice").click(function () {
       
    });


    $("#btnViewPurchaseInvoice").click(function () {
        $("#frmPurchaseInvoice").attr("action", "/PurchaseInvoice/Get_Purchase_Invoice_Details_By_Id");
        $("#frmPurchaseInvoice").submit();
    });


   
});