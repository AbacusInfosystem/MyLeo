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


        if ($("#hdnTotalQuantity").val() == 0) {
            $("#hdnrecords_Validation").show();
            $("#records_Message").html("Minimum one Record  is Required");

        }
        else {
            $("#hdnrecords_Validation").hide();
            $("#records_Message").html(" ");
        }

        $("#frmPurchaseOrder").find('[id^="textTotal_Quantity_"]').each(function () {

            if ($(this).text() == 0) {
                $("#records_Message").html("Size quantity can not be Zero.");
                $("#hdnrecords_Validation").show();
            }
            else {
                $("#hdnrecords_Validation").hide();
                $("#records_Message").html(" ");
            }

        });
        //Added by aditya [10102016] END

        if ($("#frmPurchaseOrder").valid()) {
            if ($("#records_Message")[0].innerText == " ") //added by aditya
            {
                if ($("[name='PurchaseOrder.Purchase_Order_Id']").val() == "" || $("[name='PurchaseOrder.Purchase_Order_Id']").val() == 0) {
                    $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Insert_Purchase_Order");
                }
                else {
                    $("#frmPurchaseOrder").attr("action", "/PurchaseOrder/Update_Purchase_Order");
                }
                $('#frmPurchaseOrder').attr("method", "POST");
                $('#frmPurchaseOrder').submit();
            }
        }
    });

    $("#btnAddSizesPurchaseOrder").click(function () {

        $('#drpSize_Group').rules("remove");
        $('#drpArticle_No').rules("remove");
        $('#drpCenter_Size').rules("remove");
        $('#drpBrand').rules("remove");
        $('#textPurchase_Price').rules("remove");
        $('#drpCategory').rules("remove");
        $('#textSize_Difference').rules("remove");
        $('#drpSubCategory').rules("remove");

        ValidateArticleSizeGroup();

        if ($("#frmPurchaseOrder").valid()) {

            Get_Sizes();

            Disable_AddDetalis_Button();

            document.getElementById("btnAddSizesPurchaseOrder").disabled = true;

            $(".Details").show();

        }
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