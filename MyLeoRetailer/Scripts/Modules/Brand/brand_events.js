

$(function () {
    Get_Brands();

    $("#btnSaveBrand").click(function () {
        Save_Brand();
    });

    $(document).on("click", "[name='Brand_List']", function () {
        Get_Brand_By_Id(this);        
    });

    $("[name='Filter.Brand_Name']").focusout(function () {
        Get_Brands();
    });
});