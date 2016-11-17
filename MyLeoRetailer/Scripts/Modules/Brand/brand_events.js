
$(document).ready(function () {
    Get_Brands();

    if ($("[name='Brand.Brand_Id']").val() == "" || $("[name='Brand.Brand_Id']").val() == 0) {
        $("[name='Brand.IsActive']").val(1);
        document.getElementById('Flag').checked = true;
    }

    $("#btnSaveBrand").click(function () {
        if ($("#frmBrand").valid()) {
            Save_Brand();
        }       
    });

    $(document).on("click", "[name='Brand_List']", function () {
        Get_Brand_By_Id(this);        
    });

    $("[name='Filter.Brand_Name']").focusout(function () {
        Get_Brands();
    });

    $(document).on("change", "#hdnBrandId", function () {
        Get_Brands();
    });

    //Added By Vinod Mane on 27/09/2016
    $(document).on("change", "#hdnBrandID", function () {
        Get_Brands();
    });
    //End

    $("#btnResetBrand").click(function () {
        Reset_Brand();
    });
});