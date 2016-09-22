$(document).ready(function () {

    $('#txtReplacement_Date').datepicker({});

    $('#txtPayment_Due_Date').datepicker({});

    $("#btnSaveReplacement").click(function () {
        if ($("#frmPurchaseInvoice").valid()) {
            if ($("[name='Replacement.Replacement_No']").val() != "" || $("[name='Replacement.Replacement_No']").val() != 0) {
                $("#frmPurchaseInvoice").attr("action", "/Replacement/Insert");
                $('#frmPurchaseInvoice').attr("method", "POST");
                $('#frmPurchaseInvoice').submit();
            }
        }
    });

    $("#drpVendor_Id").change(function () {
        alert(this.value);

    });

});