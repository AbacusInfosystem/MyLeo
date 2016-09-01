$(function () {   

    $("#btnSaveCustomer").click(function () {
        if ($("#frmCustomer").valid()) {
            Save_Customer();
        }
    });

    $("[name='Customer.Mobile']").focusout(function () {
        Get_Customer_By_mobile();
    });
        
});