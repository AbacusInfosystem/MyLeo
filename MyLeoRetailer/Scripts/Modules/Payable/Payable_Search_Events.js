$(document).ready(function () {

    Get_Payable();

    $(document).on('change', '[name="Payable_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdf_Purchase_Invoice_Id").val(this.value);
            //document.getElementById('btnEditPurchaseOrder').disabled = false;
            //document.getElementById('btnViewPurchaseOrder').disabled = false;
            //document.getElementById('btnCreatePurchaseOrder').disabled = true;

        }
    });

    $("#btnSearchPayable").click(function () {

        Get_Payable();
    });

    $("#btnResetPayable").click(function () {

        Get_Payable();
    });

    $("#btnPay").click(function () {

        $("#frmPayable").attr("action", "/Payable/Get_Payable_Details_By_Id");

        $("#frmPayable").submit();
    });



});