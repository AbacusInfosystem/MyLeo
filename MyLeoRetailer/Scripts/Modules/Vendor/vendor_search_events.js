

$(function () {

    Get_Vendors();

    $(document).on('change', '[name="Vendor_List"]', function (event) {

        if ($(this).prop('checked'))
        {
            $("#hdnVendorID").val(this.value);
            $("#btnedit").show(); //Added by Vinod Mane on 19/09/2016
        }
    });

  

    $("#btnedit").click(function () { //btnEdit to btnedit change by Vinod Mane on 20/09/2016

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


