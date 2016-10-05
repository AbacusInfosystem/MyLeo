



$(document).ready(function () {

    Get_Receivable();

    $(document).on('change', '[name="Receivable_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdf_Sales_Invoice_Id").val(this.value);
            //document.getElementById('btnEditPurchaseOrder').disabled = false;
            //document.getElementById('btnViewPurchaseOrder').disabled = false;
            //document.getElementById('btnCreatePurchaseOrder').disabled = true;

        }
    });

    $("#btnSearchReceivable").click(function () {

        Get_Receivable();
    });

    $("#btnPay").click(function () {

        $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");

        $("#frmReceivable").submit();
    });



});