$(function () {
    Get_Taxes();

    $("#btnSaveTax").click(function () {

        //if ($("#frmTax").valid()) {

            Save_Tax();
        
    });

    $(document).on("click", "[name='Tax_List']", function () {

        Get_Tax_By_Id(this);

    });

    $("[name='Filter.Tax_Name']").focusout(function () {

        Get_Taxes();
    });


});