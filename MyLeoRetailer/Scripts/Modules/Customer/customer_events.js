



$(function () {

    //Commented by Vinod Mane on 22/09/2016
    //if ($("[name='Customer.Customer_Id']").val() == "" || $("[name='Customer.Customer_Id']").val() == 0) {
    //    document.getElementById("btnCancleCustomer").disabled = false;
    //}
    //else {
    //    document.getElementById('btnCancleCustomer').disabled = true;
    //}
    //end

    //$(document).on('change', '[name="checkbox"]', function (event) {
    //    if ($(this).prop('checked')) {
    //        $("#hdncheckbox").val(this.value);
    //        //$("#btnEditCustomer").show();//added by Vinod Mane on 22/09/2016
    //        //document.getElementById('btnEditCustomer').disabled = false;

    //    }
    //});
    

    
    $("input.mask_phone_no").mask('(999) 9999-9999');
    $("input.mask_mobile_no").mask('(99) 99999-99999');

    // Added by Vinod Mane on 13/10/2016
    //if ($("#hdn_CustomerID").val() != 0) {
        
    //    $("#btnCancel").attr('disabled', true);
       
    //}
    //End

    if ($("[name='Customer.Customer_Id']").val() == "" || $("[name='Customer.Customer_Id']").val() == 0) {
        $("[name='Customer.IsActive']").val(1);
        document.getElementById('Flag').checked = true;
        //$("[name='customercheckbox']").val(0);
        //document.getElementById('txtcheckbox').checked = false;

    }

    //$("#btnCancel").click(function () {

    //    $("[name='customercheckbox']").val(0);
    //    document.getElementById('txtcheckbox').checked = false;

    //});
   

    $("#btnSaveCustomer").click(function () {

        debugger;

        if ($("#frmCustomer").valid()) {

            $("#hdnCreateCustomerFlag").val();

            //alert($("#hdnCreateCustomerFlag").val());

            if ($("[name='Customer.Customer_Id']").val() == "" || $("[name='Customer.Customer_Id']").val() == 0)
            {
                $("#frmCustomer").attr("action", "/Customer/Insert_Customer");               
            }
            else
            {
                $("#frmCustomer").attr("action", "/Customer/Update_Customer");
            }
            $('#frmCustomer').attr("method", "POST");

            $('#frmCustomer').submit();
           
        }
    });

    //$("#txtcheckbox").click(function () {

       
    //    if ($("[name='customercheckbox']").val() == 1) {
                
    //        handleClick();

    //        }

    //});

    $(document).on("change", "#txtcheckbox", function () {
        handleClick();
    });
    

    $("[name='Customer.Mobile']").focusout(function ()
    {
        Get_Customer_By_mobile();
    });
        
});