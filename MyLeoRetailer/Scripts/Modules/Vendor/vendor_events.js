$(document).ready(function () {

  //Added by vinod mane on 13/10/2016
    //if ($("#hdf_Vendor_Id").val() != 0) {

    //    $("#btnCancel").attr('disabled', true);
    //}
    //end

    if ($("#hdf_Vendor_Id").val() == 0) {

        $("[name='Vendor.IsActive']").val(1);
        document.getElementById('Flag').checked = true;
    }


    $("input.mask_mobile_no").mask('(99) 99999-99999');

    //$('#dtpVendor_Vat_Effective_Date').datepicker({});

    //$('#dtpVendor_CST_Effective_Date').datepicker({});
   

    $("#btnAdd").click(function () {
        AddNewBankDetails();
    });

    // -- Code Added By Sushant

    $("#btnAddBrand").click(function () {
        AddBrandDetails();
    });

    //  -- Code Added By Sushant

    $("#btnAddCategory").click(function () {
        AddCategoryDetails();
    });


    $("#btnAddSubCategory").click(function () {
        AddSubCategoryDetails();
    });

  
});


$(function () {

    

    $("#btnSaveVendor").click(function () {

        //if ($("#frmVendor").valid())
        //{
            //Save_Vendor();
        // }

        //var data_Brand = document.getElementById("tblBrandDetails").rows.length;
        //if (data_Brand == 1) {
        //    $("#lblmsg").html("Miminum One Brand is Required");
        //    alert("Brand is Required");
        //}

        //var data_Category = document.getElementById("tblCategoryDetails").rows.length;
        //if (data_Category == 1) {
        //    $("#lblmsg").html("Miminum One Category is Required");
        //    alert("Category is Required");
        //}

        //var data_SubCategory = document.getElementById("tblSubCategoryDetails").rows.length;
        //if (data_SubCategory == 1) {
        //    $("#lblmsg").html("Miminum One Sub Category is Required");
        //    alert("Sub Category is Required");
        //}

        if ($("#frmVendor").valid())
        {

            if ($("#hdf_Vendor_Id").val() == 0)
            {
                $("#frmVendor").attr("action", "/Vendor/Insert_Vendor/");
            }
            else
            {
                $("#frmVendor").attr("action", "/Vendor/Update_Vendor/");
            }

            $('#frmVendor').attr("method", "POST");
            $('#frmVendor').submit();
        }
    });


    $(document).on("click", "[name='Size_Group_List']", function () {

        Get_Size_Group_Name_By_Id(this);

        //alert("Size");

        Get_Sizes();

    })


});



