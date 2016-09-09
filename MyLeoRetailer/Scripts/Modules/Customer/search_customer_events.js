$(function () {
    document.getElementById("btnEditCustomer").disabled = true;

    Get_Customers();
    
    $(document).on('change', '[name="Customer_List"]', function (event) {        
        if ($(this).prop('checked')) {
            $("#hdnCustomer_Id").val(this.value);
            document.getElementById('btnEditCustomer').disabled = false;
            
        }
    });

    $("[name='Filter.Customer_Name']").focusout(function () {
        Get_Customers();
    });

    $("[name='Filter.Customer_Mobile1']").focusout(function () {
        Get_Customers();
    });

    $("#btnCreateCustomer").click(function () {       
        $("#frmCustomer").attr("action", "/Customer/Index");
        $("#frmCustomer").submit();
    });

    $("#btnEditCustomer").click(function () {       
        $("#frmCustomer").attr("action", "/Customer/Get_Customer_By_Id");
        $("#frmCustomer").submit();
    });

});