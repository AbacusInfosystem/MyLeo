$(function () {
    $("#frmPurchaseOrder").validate({
        rules: {
            "PurchaseOrder.Purchase_Order_No": {
                required: true
            },

            "PurchaseOrder.Vendor_Id": {
                required: true
            },

            "PurchaseOrder.Agent_Id": {
                required: true
            },

            "PurchaseOrder.Transporter_Id": {
                required: true
            },

            "PurchaseOrder.Shipping_Address": {
                required: true
            },

            "PurchaseOrder.Size_Group_Id": {
                required: true
            },

            "PurchaseOrder.Article_No": {
                required: true
            },

            "PurchaseOrder.Center_Size": {
                required: true
            },

            "PurchaseOrder.Brand_Id": {
                required: true
            },

            "PurchaseOrder.Category_Id": {
                required: true
            },

            "PurchaseOrder.SubCategory_Id": {
                required: true
            },

            "PurchaseOrder.Purchase_Price": {
                digits: true,
                required: true
            },

            "PurchaseOrder.Size_Difference": {
                digits: true,
                required: true
            }
        },
        messages: {

            "PurchaseOrder.Purchase_Order_No": {
                required: "Purchase Order No is required."
            },

            "PurchaseOrder.Vendor_Id": {
                required: "Vendor name is required."
            },

            "PurchaseOrder.Agent_Id": {
                required: "Agent name is required."
            },

            "PurchaseOrder.Transporter_Id": {
                required: "Transporter name is required."
            },

            "PurchaseOrder.Shipping_Address": {
                required: "Shipping address is required."
            },

            "PurchaseOrder.Size_Group_Id": {
                required: "Size Group is required."
            },

            "PurchaseOrder.Article_No": {
                required: "Article no. is required."
            },

            "PurchaseOrder.Center_Size": {
                required: "Center size is required."
            },

            "PurchaseOrder.Brand_Id": {
                required: "Brand name is required."
            },

            "PurchaseOrder.Category_Id": {
                required: "Category name is required."
            },

            "PurchaseOrder.SubCategory_Id": {
                required: "Sub Category name is required."
            },

            "PurchaseOrder.Purchase_Price": {
                required: "Base rate is required.",
                digits: "Enter only digits"
            },

            "PurchaseOrder.Size_Difference": {
                required: "Size difference is required.",
                digits: "Enter only digits"
            }

        }
    });

});