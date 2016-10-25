$(function () {

    Get_Inventories();

    Set_Branch_Id();

    $("#btnSearchInventory").click(function () {

        Get_Inventories();

    });


});