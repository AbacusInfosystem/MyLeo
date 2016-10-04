

//$(document).ready(function () {
//    Get_Receivables();
//});
$(document).ready(function () {

    Get_Receivable();

    if ($("#hdf_Sales_Credit_Note_Id").val()!= 0 || $("#hdf_Sales_Credit_Note_Id").val()!='') {
       Get_Receivables();
    }

    

    document.getElementById('btnPay').disabled = true;

    $(document).on('change', '[name="Get_Receivable_Search_Details_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdf_Sales_Invoice_Id").val(this.value);
            document.getElementById('btnPay').disabled = false;            
        }
    });

    if ($("#hdnPayment_Status1").val() == 1) {
        $("#btnSavePay").hide();

    }

    $("#btnSearchReceivable").click(function () {

        Get_Receivable();
    });


    $('[name = "Receivable.Sales_Credit_Note_Id"]').change(function () {

        Get_Credit_Note_Amount_By_Id($(this).val());

    });

    $('[name = "Receivable.Gift_Voucher_Id"]').change(function () {

        Get_Gift_Voucher_Amount_By_Id($(this).val());

    });

    $("#btnSavePay").click(function () {

        alert();
        if ($("#frmPay").valid()) {
            Save_Receivable_Data();
        }

    });

    $("#btnPay").click(function () {

        $("#frmReceivable").attr("action", "/Receivable/Pay");
        $("#frmReceivable").submit();
    });

});