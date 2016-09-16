

$(function () {

    Get_Vendors();

    $(document).on('change', '[name="Vendor_List"]', function (event) {

        if ($(this).prop('checked'))
        {
            $("#hdnVendorID").val(this.value);
        }
    });

    $("#btnEdit").click(function () {

        $("#frmSearchVendor").attr("action", "/Vendor/Get_Vendor_By_Id");

        $("#frmSearchVendor").submit();
    });


    $("#btnCreate").click(function () {

        $("#frmSearchVendor").attr("action", "/Vendor/Index");

    });


    $("[name='Filter.Vendor_Name']").focusout(function () {

        Get_Vendors();

    });


});


