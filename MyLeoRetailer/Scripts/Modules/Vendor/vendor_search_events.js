

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

    //$("#btnSaveSizeGroup").click(function () {

    //    if ($("#frmSizeGroup").valid()) {

    //        Save_SizeGroup();
    //    }
    //});

    //$(document).on("click", "[name='Size_Group_List']", function () {

    //    Get_Size_Group_Name_By_Id(this);

    //    alert("Size");

    //    Get_Sizes();

    //});


    //$("#btnSaveSize").click(function () {

    //    alert();

    //    if ($("#frmSize").valid()) {

    //        Save_Size();

    //    }

    //});



    $("[name='Filter.Vendor_Name']").focusout(function () {

        Get_Vendors();

    });


});


