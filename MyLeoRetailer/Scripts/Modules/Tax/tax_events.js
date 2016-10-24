$(function () {
    Get_Taxes();

    $("#btnSaveTax").click(function () {

        if ($("#frmTax").valid()) {

            Save_Tax();
        }
        
    });

    $(document).on("click", "[name='Tax_List']", function () {

        Get_Tax_By_Id(this);

    });

    $("[name='Filter.Tax_Name']").focusout(function () {

        Get_Taxes();
    });

    //Added By Vinod Mane on 22/09/2016
    $(document).on("change", "#hdnTax_Name", function () {
        Get_Taxes();
    });

    $("#btnReset").click(function () {       

        Reset_Tax();
    });

});