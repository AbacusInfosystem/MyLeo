$(function () {

    Get_ProductWarehouse();

    //$(document).on('change', '[name="Replacement_List"]', function (event) {
    //    if ($(this).prop('checked')) {
    //        $("#hdnReplacementId").val(this.value);
    //        //document.getElementById('btnEditPurchaseInvoice').disabled = false;
    //    }
    //});

    $("[name='Filter.Product_SKU']").focusout(function () {
        Get_ProductWarehouse();
    });


});