﻿$(document).ready(function () {

    $('#txtPurchase_Return_Date').datepicker({});

    $('#txtLr_Date').datepicker({});

});


$(function () {

    $("#btnSavePurchaseReturn").click(function () {
        if ($("#frmPurchaseReturn").valid()) {
            if ($("[name='PurchaseReturn.Purchase_Return_Id']").val() == "" || $("[name='PurchaseReturn.Purchase_Return_Id']").val() == 0) {
                $("#frmPurchaseReturn").attr("action", "/PurchaseReturn/Insert_Purchase_Return");
                $('#frmPurchaseReturn').attr("method", "POST");
                $('#frmPurchaseReturn').submit();
            }
        }
    });

    
    $("[name='PurchaseReturn.Purchase_Invoice_Id']").change(function () {

        Get_Purchase_Return_Items();

    });

});