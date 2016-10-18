

$(function () {


    if ($("#hdnPayament_Status1").val() == 1) {

        $("#btnSavePay").hide();
        //$(".btn_edit").hide();
        //$("#edit-payable-details").parents('tr').find(".btn_edit").hide();
        $("#btnResetPay").hide();

    }

    $('[name = "Payable.Payment_Mode"]').change(function () {

       
        if ($(this).val() == 0) {
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divPaidAmount").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
            //$("#divCreditnoteno").hide();
           // $("#divGiftvoucherno").hide();
           
        }

        else if ($(this).val() == 1) {

            $("#divPaidAmount").show();
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
            //$("#divCreditnoteno").hide();
            //$("#divGiftvoucherno").hide();

        }

        else if ($(this).val() == 2) {
            
            $("#divCreditcardno").show();
            $("#divPaidAmount").show();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
            //$("#divCreditnoteno").hide();
            //$("#divGiftvoucherno").hide();
           
        }

        else if ($(this).val() == 3) {
            $("#divDebitcardno").show();
            $("#divPaidAmount").show();
            $("#divCreditcardno").hide();
             $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
            //$("#divCreditnoteno").hide();
            //$("#divGiftvoucherno").hide();
        }

        else if ($(this).val() == 4) {
            $("#divChequedate").show();
            $("#divChequeno").show();
            $("#divBankName").show();
            $("#divPaidAmount").show();
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            //$("#divCreditnoteno").hide();
            //$("#divGiftvoucherno").hide();
        }

        else {
            //$("#divGiftvoucherno").hide();
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divPaidAmount").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
           // $("#divCreditnoteno").hide();
        }
    });


    $('[name = "Payable.Purchase_Credit_Note_Id"]').change(function () {

        Get_Credit_Note_Amount_By_Id($(this).val());

    });
    // $(element).is(":visible");

    $("#btnSavePay").click(function () {
        
        if ($("#frmPay").valid()) {
            if ($("#lblPaidPriceError").is(":visible") || $("#lblFinalPriceError").is(":visible")) {
            }
            else {
                Save_Payable_Data();
            }
        }

    });
});

function Get_Payable(id) {

    alert(id);

    $("#hdf_Purchase_Invoice_Id").val(id);

    $("#frmPayable").attr("action", "/Payable/Get_Payable_Details_By_Id");
    $("#frmPayable").submit();
}