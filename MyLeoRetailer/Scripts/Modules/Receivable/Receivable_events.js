﻿

$(function () {

    $("#btnSearchReceivable").click(function () {

        $("#frmReceivable").attr("action", "/Receivable/Get_Receivable");

        $("#frmReceivable").submit();
    });


    $('[name = "Receivable.Sales_Credit_Note_Id"]').change(function () {

        Get_Credit_Note_Amount_By_Id($(this).val());

    });

    $('[name = "Receivable.Gift_Voucher_No"]').change(function () {

        Get_Gift_Voucher_Amount_By_Id($(this).val());

    });

});