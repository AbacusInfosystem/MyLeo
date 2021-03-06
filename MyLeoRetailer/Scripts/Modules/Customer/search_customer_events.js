﻿$(function () {
    document.getElementById("btnEditCustomer").disabled = true;

    Get_Customers();
    
    $(document).on('change', '[name="Customer_List"]', function (event) {        
        if ($(this).prop('checked')) {
            $("#hdnCustomer_Id").val(this.value);
            //$("#btnEditCustomer").show();//added by Vinod Mane on 22/09/2016
           document.getElementById('btnEditCustomer').disabled = false;
            
        }
    });

    $("[name='Filter.Customer_Name']").focusout(function () {
        document.getElementById("btnEditCustomer").disabled = true;//Added by vinod mane on 25/10/2016
        Get_Customers();
    });

    $("[name='Filter.Customer_Mobile1']").focusout(function () {
        document.getElementById("btnEditCustomer").disabled = true;//Added by vinod mane on 25/10/2016
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

    //Added By Vinod Mane on 22/09/2016
    $(document).on("change", "#hdnCustomerId", function () {
        document.getElementById("btnEditCustomer").disabled = true;//Added by vinod mane on 25/10/2016
        Get_Customers();
    });

    $(document).on("change", "#hdnCustomer_Mobile1", function () {
        document.getElementById("btnEditCustomer").disabled = true;//Added by vinod mane on 25/10/2016
        Get_Customers();
    });
    //End
});