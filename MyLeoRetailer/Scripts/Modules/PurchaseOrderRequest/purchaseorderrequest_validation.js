$(function () {
    $("#frmPurchaseOrderRequest").validate({
        rules: {
            "PurchaseOrderRequest.Vendor_Id": {
                required: true
            },

            "PurchaseOrderRequest.Size_Group_Id": {
                required: true
            },

            "PurchaseOrderRequest.Article_No": {
                required: true
            },

            "PurchaseOrderRequest.Center_Size": {
                required: true
            },

            "PurchaseOrderRequest.Brand_Id": {
                required: true
            },

            "PurchaseOrderRequest.Category_Id": {
                required: true
            },

            "PurchaseOrderRequest.SubCategory_Id": {
                required: true
            },

            "PurchaseOrderRequest.Purchase_Price": {
                digits: true,
                required: true
            },

            "PurchaseOrderRequest.Size_Difference": {
                digits: true,
                required: true
            }
        },
        messages: {

            "PurchaseOrderRequest.Vendor_Id": {
                required: "Vendor name is required."
            },

            "PurchaseOrderRequest.Size_Group_Id": {
                required: "Size Group is required."
            },

            "PurchaseOrderRequest.Article_No": {
                required: "Article no. is required."
            },

            "PurchaseOrderRequest.Center_Size": {
                required: "Center size is required."
            },

            "PurchaseOrderRequest.Brand_Id": {
                required: "Brand name is required."
            },

            "PurchaseOrderRequest.Category_Id": {
                required: "Category name is required."
            },

            "PurchaseOrderRequest.SubCategory_Id": {
                required: "Sub Category name is required."
            },

            "PurchaseOrderRequest.Purchase_Price": {
                required: "Base rate is required.",
                digits: "Enter only digits"
            },

            "PurchaseOrderRequest.Size_Difference": {
                required: "Size difference is required.",
                digits: "Enter only digits"
            }

        }
    });

});