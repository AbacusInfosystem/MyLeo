

$(function () {

    Get_Vendor_Contacts();

    $(document).on("click", "[name='Vendor_Contact_List']", function () {

        Get_Vendor_Contact_By_Id(this);

    });

    $(document).on('change', '[name="Vendor_Contact_List"]', function (event) {
        alert();
        if ($(this).prop('checked')) {
            $("#hdnVendorContact_Id").val(this.value);
        }
    });

    $("#btnVendorContact").click(function () {
        $("#frmVendorContact").attr("action", "/VendorContact/Get_Vendor_Contact_By_Id");
        $("#frmVendorContact").submit();
    });
        
    $("[name='Filter.Vendor_Contact_Name']").focusout(function () {

        Get_Vendor_Contacts();
    });

});






