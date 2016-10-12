$(function () {


    $(".Details").hide();

    if ($("[name='PurchaseOrder.Purchase_Order_Id']").val() == "" || $("[name='PurchaseOrder.Purchase_Order_Id']").val() == 0) {
        document.getElementById("btnCanclePurchaseOrder").disabled = false;
    }
    else {
        document.getElementById('btnCanclePurchaseOrder').disabled = true;
    }

    $("#btnSavePurchaseOrder").click(function () {

        //Added by aditya [10102016] Start

        $('#drpSize_Group').rules("remove");
        $('#drpArticle_No').rules("remove");
        $('#drpCenter_Size').rules("remove");
        $('#drpBrand').rules("remove");
        $('#textPurchase_Price').rules("remove");
        $('#drpCategory').rules("remove");
        $('#textSize_Difference').rules("remove");
        $('#drpSubCategory').rules("remove");


        $("#frmPurchaseOrder").find('[id^="textTotal_Quantity_"]').each(function ()
        {
            if ($(this).text() == 0) {
                $("#hdnrecords_Validation").rules("add", "required");

                return false;
            }
            else {
                $('#hdnrecords_Validation').rules("remove");
            }

        });

        //Added by aditya [10102016] END

        if ($("#frmPurchaseOrder").valid()) {
            if ($("[name='PurchaseOrder.Purchase_Order_Id']").val() == "" || $("[name='PurchaseOrder.Purchase_Order_Id']").val() == 0) {
                $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Insert_Purchase_Order");
            }
            else {
                $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Update_Purchase_Order");
            }
            $('#frmPurchaseOrder').attr("method", "POST");
            $('#frmPurchaseOrder').submit();

        }
    });

    

    $("#btnAddSizesPurchaseOrder").click(function () {               
        Get_Sizes();

        document.getElementById("btnAddSizesPurchaseOrder").disabled = true;

        $(".Details").show();
    });

    $("#btnAddDetailsPurchaseOrder").click(function () {

        //Added by aditya [10102016] Start
        $("#drpSize_Group").rules("add", "required");
        $("#drpArticle_No").rules("add", "required");
        $('#drpCenter_Size').rules("add", "required");
        $('#drpBrand').rules("add", "required");
        $('#textPurchase_Price').rules("add", "required");
        $('#drpCategory').rules("add", "required");
        $('#textSize_Difference').rules("add", "required");
        $('#drpSubCategory').rules("add", "required");
        //Added by aditya [10102016] END

        if ($("#frmPurchaseOrder").valid()) {
            AddPurchaseOrderDetails();
        }
        //CalculateRowAmount();

    });
       
});