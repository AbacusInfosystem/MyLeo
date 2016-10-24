$(function () {

    Get_ProductWarehouse();

    $(document).on("change", "#hdnProduct_SKU", function () {
        Get_ProductWarehouse();
    });

});