

$(function ()
{
    if ($("#hdnVendorId").val() != 0) {
        $("#dvVendor").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnBrandId").val() != 0) {
        $("#dvBrand").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnCategoryId").val() != 0) {
        $("#dvCatergory").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnSubcategoryId").val() != 0) {
        $("#dvSubC").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnSizeGroupId").val() != 0) {
        $("#dvSizeG").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdn_ProductId").val() != 0) {
        $("#txtArticle_No").attr('readonly', true);
        $("#btnCancel").attr('disabled', true);
        $("#btnProductMRP").show();
    }
 
    $("#btnProductSave").click(function () {
        if ($("#frmProduct").valid()) {
            if ($("#hdn_ProductId").val() == 0) {
                $("#frmProduct").attr("action", "/Product/Insert_Product/");
            }
            else {
                $("#frmProduct").attr("action", "/Product/Update_Product/");
            }
            $('#frmProduct').attr("method", "POST");
            $('#frmProduct').submit();
        }
    });

    $("#btnProductMRP").click(function () {

        $("#frmProduct").attr("action", "/Product/serch-ProductPrizing/");

        $("#frmProduct").attr("method", "post");

        $("#frmProduct").submit();
    });

    $("#btnUploadImage").click(function () {
        UploadImage();
    });
	 
});