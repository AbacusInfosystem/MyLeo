﻿$(document).ready(function () {

   
    document.getElementById('btnEditPurchaseReturn').disabled = true;

    document.getElementById('btnUpdatePurchaseReturn').disabled = true;
   
    Get_Purchase_Returns();

    $(document).on('change', '[name="Purchase_Return_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseReturnId").val(this.value);
            document.getElementById('btnEditPurchaseReturn').disabled = false;
            document.getElementById('btnUpdatePurchaseReturn').disabled = false;
        }
    });

    $("#txtDebit_Note_No").focusout(function () {
        Get_Purchase_Returns();

        $("[name='Filter.Debit_Note_No']").val('');

        $("[name='Filter.Purchase_Return_Id']").val('');
    });

  
    $(document).on('change', '#txtDebit_Note_No', function (event) {

        var dbono = $("#txtDebit_Note_No").val();      

        $("[name='Filter.Debit_Note_No']").val(dbono);

        Get_Purchase_Returns();

       


    });

    //$(document).on('change', '[name="Filter.Debit_Note_No"]', function (event) {
    //    Get_Purchase_Returns();
    //});



    $("#btnCreatePurchaseReturn").click(function () {
        $("#frmPurchaseReturn").attr("action", "/PurchaseReturn/Index/");

        $('#frmPurchaseReturn').attr("method", "POST");

        $("#frmPurchaseReturn").submit();
    });

    $("#btnEditPurchaseReturn").click(function () {

        $("#frmPurchaseReturn").attr("action", "/PurchaseReturn/Get_Purchase_Return_Details_By_Id/");

        $('#frmPurchaseReturn').attr("method", "POST");

        $('#frmPurchaseReturn').submit();

    });
       

});

$(function () {


    $("#btnUpdatePurchaseReturn").click(function (event) {

        var PurchaeReturnId = $('#hdnPurchaseReturnId').val();
        $("#div_Parent_Modal_Fade").find(".modal-body").load("/PurchaseReturn/Update_GR_No", { Id: PurchaeReturnId }, call_back);

        document.getElementById('btnUpdatePurchaseReturn').disabled = true;

    });

    //Added By Vinod Mane on 26/10/2016
    $(document).on("change", "#hdnPurchaseReturnId", function () {
       
        Get_Purchase_Returns();
    });
    //End
});