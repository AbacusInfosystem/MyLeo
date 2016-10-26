$(document).ready(function () {

    document.getElementById('btnPay').disabled = true;

    Get_Payable();

    $(document).on('change', '[name="Payable_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdf_Purchase_Invoice_Id").val(this.value);

            document.getElementById('btnPay').disabled = false;

        }
    });

    $("#btnSearchPayable").click(function () {

        Get_Payable();
    });

    $("#btnResetPayable").click(function () {

        Get_Payable();
    });

    $("#btnPay").click(function () {

        $("#frmPayable").attr("action", "/Payable/Get_Payable_Details_By_Id/");

        $('#frmPayable').attr("method", "POST");

        $("#frmPayable").submit();
    });

    //$(document).on('change', '[name="Payable_List"]', function (event) {
    //    if ($(this).prop('checked')) {
    //        //$("#hdf_ProductId").val(this.value);
    //        //$("#hdf_SizeGroupId").val($('[name="Size_Group_Id"]').val());
    //        document.getElementById('btnPay').disabled = true;
    //        //$("#btnEdit").show();
    //    }
    //});

   


});