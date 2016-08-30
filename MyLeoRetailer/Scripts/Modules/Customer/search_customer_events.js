$(function () {
    Get_Customers();

    $(document).on("click", "[name='Customer_List']", function () {
        Get_Customer_By_Id(this);

       
    });

    $(document).on('change', '[name="Customer_List"]', function (event) {
        alert();
        if ($(this).prop('checked')) {
            $("#hdnCustomer_Id").val(this.value);
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