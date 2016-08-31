$(function () {   

    $("#btnSaveCustomer").click(function () {
        if ($("#frmCustomerPrimaryInfo").valid()) {
            Save_Customer();
        }
    });

    $("[name='Customer.Mobile']").focusout(function () {
        Get_Customer_By_mobile();
    });
        
});