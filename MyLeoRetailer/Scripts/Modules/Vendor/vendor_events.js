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
        //Added by vinod mane on 21/10/2016
        var hdnBrand =0;
        var hdnCategory = 0
        var hdnSubCategory = 0;

        var data_Brand = document.getElementById("tblBrandDetails").rows.length;
        if (data_Brand == 1) {

            hdnBrand = 1;
            $("#hdnBrand_Validation").show();
            $("#Brand_Message").html("Minimum one Brand is Required");
            
        }
        else {

            hdnBrand = 0;
            $("#hdnBrand_Validation").hide();
            $("#Brand_Message").html(" ");         
            
        }

        var data_Category = document.getElementById("tblCategoryDetails").rows.length;
        if (data_Category == 1) {

            hdnCategory = 1;
            $("#hdnCategory_Validation").show();           
            $("#Category_Message").html("Miminum One Category is Required");         
           
        }
        else {

            hdnCategory = 0;
            $("#hdnCategory_Validation").hide();
            $("#Category_Message").html(" ");           
        }

        var data_SubCategory = document.getElementById("tblSubCategoryDetails").rows.length;
        if (data_SubCategory == 1) {

            hdnSubCategory = 1;
            $("#hdnSubCategory_Validation").show();
            $("#SubCategory_Message").html("Miminum One Sub Category is Required");
            
        }
        else {
            hdnSubCategory = 0;
            $("#hdnSubCategory_Validation").hide();
            $("#SubCategory_Message").html(" ");
            
        }
        //End

        if ($("#frmVendor").valid()) {
            //if (($.trim($("#Brand_Message").text()) == "") && ($.trim($("#Category_Message").text()) == "") && ($.trim($("#SubCategory_Message").text()) == ""))//added by vinod mane on 21/10/2016
            if (hdnBrand == "0" && hdnCategory == "0" && hdnSubCategory == "0")
            {
                
                if ($("#hdf_Vendor_Id").val() == 0) {
                    $("#frmVendor").attr("action", "/Vendor/Insert_Vendor/");
                }
                else {
                    $("#frmVendor").attr("action", "/Vendor/Update_Vendor/");
                }

                $('#frmVendor').attr("method", "POST");
                $('#frmVendor').submit();
            }
        }
    });


    $(document).on("click", "[name='Size_Group_List']", function () {

        Get_Size_Group_Name_By_Id(this);

        //alert("Size");

        Get_Sizes();

    })

    //Added By Vinod Mane on 25/10/2016
    $("#btnCancel").click(function () {
        ResetVendor();
    });
    //End
});



