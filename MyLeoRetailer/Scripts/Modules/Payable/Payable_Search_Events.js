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
        document.getElementById('btnPay').disabled = true;//Added by vinod mane on 26/10/2016
        Get_Payable();
    });
   
    $("#btnResetPayable").click(function () {

        Reset_Payable();

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

 
    //$(document).on("change", "#hdnVendorName", function () {
    //    document.getElementById('btnPay').disabled = true;
    //    Get_Payable();
    //});
  

});