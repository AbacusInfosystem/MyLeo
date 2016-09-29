//$(document).ready(function () {

//    $('#txtPurchase_Invoice_Date').datepicker({});

//    $('#txtChallan_Date').datepicker({});

//    $('#txtAgainst_Form_Date').datepicker({});

//    $('#txtPurchase_Packing_Date').datepicker({});

//    $('#txtPayment_Due_Date').datepicker({});

//    $('#txtLr_Date').datepicker({});

//});


$(function () {
    
    $("#btnSavePurchaseInvoice").click(function () {
        alert(11);
        if ($("#frmPurchaseInvoice").valid()) {
            if ($("[name='PurchaseInvoice.Purchase_Invoice_Id']").val() == "" || $("[name='PurchaseInvoice.Purchase_Invoice_Id']").val() == 0) {
                $("#frmPurchaseInvoice").attr("action", "/PurchaseInvoice/Insert_Purchase_Invoice");
                $('#frmPurchaseInvoice').attr("method", "POST");
                $('#frmPurchaseInvoice').submit();
            } 
        }
    });

   
});

