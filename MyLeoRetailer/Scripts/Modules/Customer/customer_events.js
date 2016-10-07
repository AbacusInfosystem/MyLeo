$(function () {

    //Commented by Vinod Mane on 22/09/2016
    //if ($("[name='Customer.Customer_Id']").val() == "" || $("[name='Customer.Customer_Id']").val() == 0) {
    //    document.getElementById("btnCancleCustomer").disabled = false;
    //}
    //else {
    //    document.getElementById('btnCancleCustomer').disabled = true;
    //}
    //end

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

    $("[name='Customer.Mobile']").focusout(function ()
    {
        Get_Customer_By_mobile();
    });
        
});