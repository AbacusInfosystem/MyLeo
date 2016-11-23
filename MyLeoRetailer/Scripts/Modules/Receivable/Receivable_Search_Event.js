
$(document).ready(function () {

    document.getElementById('btnPay').disabled = true;

    Get_Receivable();

    $(document).on('change', '[name="Receivable_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#btnPay").show();
            $("#hdf_Sales_Invoice_Id").val(this.value);

            document.getElementById('btnPay').disabled = false;

        }
    });

    $("#btnSearchReceivable").click(function () {
        document.getElementById('btnPay').disabled = true;//Added by vinod mane on 26/10/2016
        Get_Receivable();
    });

    $("#btnPay").click(function () {

        $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id/");

        $('#frmReceivable').attr("method", "POST");

        $("#frmReceivable").submit();

    });

    $("#btnResetReceivable").click(function () {

        Reset_Receivable();

        Get_Receivable();
    });

    //$(document).on("change", "#hdnSalesInvoiceNo", function () {
    //    document.getElementById('btnPay').disabled = true;
    //    Get_Receivable();
    //});

  
});