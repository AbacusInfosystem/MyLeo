

$(function () {

    Get_Vendor_Contacts();

    $("[name='Filter.Vendor_Contact_Name']").focusout(function () {

        Get_Vendor_Contacts();
    });


    $("#btnVendorContact").click(function () {
        $("#frmVendorContact").attr("action", "/VendorContact/Get_Vendor_Contact_By_Id");
        $("#frmVendorContact").attr("method", "post");
        $("#frmVendorContact").submit();
    });


    $(document).on('change', '[name="Vendor_Contact_List"]', function (event) {
        alert();
        if ($(this).prop('checked')) {
            $("#hdnVendorContact_Id").val(this.value);
            $("#btnVendorContact").show();
        }
    });


    $("#btncreateVC").click(function () {

        $("#frmVendorContact").attr("action", "/VendorContact/Index");
        $("#frmVendorContact").submit();

    });


    $("#btnVendorContact").click(function () {
        $("#frmVendorContact").attr("action", "/VendorContact/Get_Vendor_Contact_By_Id");
        $("#frmVendorContact").submit();
    });

    //$(document).on("click", "[name='Vendor_Contact_List']", function () {

    //    Get_Vendor_Contact_By_Id(this);

    //});

   

   
        
  


   

});






