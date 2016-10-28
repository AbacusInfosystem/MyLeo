



$(document).ready(function () {

    //add_Validation();

    if ($("#hdnPayment_Status1").val() == 1)
    {
        $("#btnSavePay").hide();
        //$(".btn_edit").hide();
        //$("#edit-payable-details").parents('tr').find(".btn_edit").hide();
        $("#btnResetPay").hide();
    }

    //$("#btnSearchReceivable").click(function () {

    //    $("#frmReceivable").attr("action", "/Receivable/Get_Receivable");

    //    $("#frmReceivable").submit();
    //});


    $('[name = "Receivable.Sales_Credit_Note_Id"]').change(function () {

        Get_Credit_Note_Amount_By_Id($(this).val());
        
        

    });

    $('[name = "Receivable.Gift_Voucher_Id"]').change(function () {

        Get_Gift_Voucher_Amount_By_Id($(this).val());

        //Get_Balance_Amount_Using_Gift_Voucher_Amount();

    });

    $("#btnSavePay").click(function () { 
        if ($("#frmPay").valid()) {
            Save_Receivable_Data();
        }

    });

    $("#btnResetReceivable").click(function () {

        document.getElementById("txtCredit_Note_Amount").disabled = false;
    });

});