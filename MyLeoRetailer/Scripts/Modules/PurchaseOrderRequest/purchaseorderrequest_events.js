$(function () {

    $(".Details").hide();
        
    $("#btnSavePurchaseOrderRequest").click(function () {

        $('#drpSize_Group').rules("remove");
        $('#drpArticle_No').rules("remove");
        $('#drpCenter_Size').rules("remove");
        $('#drpBrand').rules("remove");
        $('#textPurchase_Price').rules("remove");
        $('#drpCategory').rules("remove");
        $('#textSize_Difference').rules("remove");
        $('#drpSubCategory').rules("remove");


        $("#frmPurchaseOrderRequest").find('[id^="textTotal_Quantity_"]').each(function () {
            if ($(this).text() == 0) {
                $("#hdnrecords_Validation").rules("add", "required");

                return false;
            }
            else {
                $('#hdnrecords_Validation').rules("remove");
            }

        });

        if ($("#frmPurchaseOrderRequest").valid()) {
            if ($("[name='PurchaseOrderRequest.Purchase_Order_Request_Id']").val() == "" || $("[name='PurchaseOrderRequest.Purchase_Order_Request_Id']").val() == 0) {
                $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Insert_Purchase_Order_Request");
                $('#frmPurchaseOrderRequest').attr("method", "POST");
                $('#frmPurchaseOrderRequest').submit();
            }
        }
    });
    
    $("#btnAddSizesPurchaseOrderRequest").click(function () {
        Get_Sizes();

        document.getElementById("btnAddSizesPurchaseOrderRequest").disabled = true;

        $(".Details").show();
    });

    $("#btnResetPurchaseOrderRequest").click(function () {
        Reset_Details();
    });

    $("#btnAddDetailsPurchaseOrderRequest").click(function () {
       
        $("#drpSize_Group").rules("add", "required");
        $("#drpArticle_No").rules("add", "required");
        $('#drpCenter_Size').rules("add", "required");
        $('#drpBrand').rules("add", "required");
        $('#textPurchase_Price').rules("add", "required");
        $('#drpCategory').rules("add", "required");
        $('#textSize_Difference').rules("add", "required");
        $('#drpSubCategory').rules("add", "required");     

        if ($("#frmPurchaseOrderRequest").valid()) {
            AddPurchaseOrderRequestDetails();
        }
    });


});