$(function () {

    if ($("#hdnSelecteddBranchId").val() != "") {

        $("#Branch").find(".autocomplete-text").trigger("focusout");
    }

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


        if ($("#hdnTotalQuantity").val() == 0) {
            $("#hdnrecords_Validation").show();
            $("#records_Message").html("Minimum one Record  is Required");

        }
        else {
            $("#hdnrecords_Validation").hide();
            $("#records_Message").html(" ");
        }

        $("#frmPurchaseOrderRequest").find('[id^="textTotal_Quantity_"]').each(function () {
            if ($(this).text() == 0) {
                $("#records_Message").html("Size quantity can not be Zero.");
                $("#hdnrecords_Validation").show();
            }
            else {
                $("#hdnrecords_Validation").hide();
                $("#records_Message").html(" ");
            }
        });

        if ($("#frmPurchaseOrderRequest").valid()) {
            if ($("#records_Message")[0].innerText == " ") //added by aditya
            {
            if ($("[name='PurchaseOrderRequest.Purchase_Order_Request_Id']").val() == "" || $("[name='PurchaseOrderRequest.Purchase_Order_Request_Id']").val() == 0) {
                $("#frmPurchaseOrderRequest").attr("action", "/PurchaseOrderRequest/Insert_Purchase_Order_Request/");
                $('#frmPurchaseOrderRequest').attr("method", "POST");
                $('#frmPurchaseOrderRequest').submit();
            }
        }
        }
    });
    
    $("#btnAddSizesPurchaseOrderRequest").click(function () {

        ValidateArticleSizeGroup();

        //$('#drpSize_Group').rules("remove");
        //$('#drpArticle_No').rules("remove");
        $('#drpCenter_Size').rules("remove");
        $('#drpBrand').rules("remove");
        $('#textPurchase_Price').rules("remove");
        $('#drpCategory').rules("remove");
        $('#textSize_Difference').rules("remove");
        $('#drpSubCategory').rules("remove");

        if ($("#frmPurchaseOrderRequest").valid()) {

            Get_Sizes();

            Disable_AddDetalis_Button();

            document.getElementById("btnAddSizesPurchaseOrderRequest").disabled = true;

            $(".Details").show();

        }
    });

    $("#btnResetPurchaseOrderRequest").click(function () {
        Reset_Details();
    });

    $("#btnAddDetailsPurchaseOrderRequest").click(function () {
       
        $("#drpSize_Group").rules("add", "required");
        $("#drpArticle_No").rules("add", "required");
        $('#drpCenter_Size').rules("add", "required");
        $('#drpBrand').rules("add", "required");
        $('#textPurchase_Price').rules("add", { required: true, digits:true});
        $('#drpCategory').rules("add", "required");
        $('#textSize_Difference').rules("add", { required: true, digits:true});
        $('#drpSubCategory').rules("add", "required");     

        if ($("#frmPurchaseOrderRequest").valid()) {
            AddPurchaseOrderRequestDetails();
        }
    });


});