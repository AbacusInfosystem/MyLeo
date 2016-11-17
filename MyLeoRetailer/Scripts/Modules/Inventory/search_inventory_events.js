$(function () {

    Get_Inventories();

    Set_Branch_Id();

    Set_Brand_Code();

    Set_Category_Code();

    $("#btnSearchInventory").click(function () {

        Get_Inventories();

    });


});