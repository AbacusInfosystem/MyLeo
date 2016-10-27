$(function () {

    $("#frmPurchaseReturn").validate({
        rules: {
            //"PurchaseReturn.Debit_Note_No": {
            //    required: true
            //},

            "PurchaseReturn.Vendor_Id": {
                required: true
            },

            "PurchaseReturn.Purchase_Invoice_Id": {
                required: true
            },

            "PurchaseReturn.Transporter_Id": {
                required: true
            },

            "PurchaseReturn.Lr_No": {
                required: true
            },

            "PurchaseReturn.Logistics_Person_Name": {
                required: true
            },

            "PurchaseReturn.Discount_Percentage": {
                required: true,
                number: true
            },

            //"PurchaseReturn.PurchaseReturns[0].Quantity": {
            //    required: true,
            //    digits: true
            //},

            //"PurchaseReturn.PurchaseReturns[0].SKU_Code": {
            //    required: true
            //}

        },
        messages: {

            //"PurchaseReturn.Debit_Note_No": {
            //    required: "Debit note no is required."
            //},

            "PurchaseReturn.Vendor_Id": {
                required: "Vendor name is required."
            },

            "PurchaseReturn.Transporter_Id": {
                required: "Transporter name is required."
            },

            "PurchaseReturn.Lr_No": {
                required: "LR No. is required."
            },

            "PurchaseReturn.Logistics_Person_Name": {
                required: "Logistics person name is required."
            },

            "PurchaseReturn.Discount_Percentage": {
                required: "Discount % is required.",
                number: "Enter only numbers"
            },

            "PurchaseReturn.Purchase_Invoice_Id": {
                required: "Purchase invoice no is required."
            },


            //"PurchaseReturn.PurchaseReturns[0].Quantity": {
            //    required: "Quantity is required.",
            //    digits: "Enter only digits"
            //},

            //"PurchaseReturn.PurchaseReturns[0].SKU_Code": {
            //    required: "SKU code is required.",
            //}

        }
    });

    jQuery.validator.addMethod("checkSKUExist", function (value, element) {
        var result = true;
        var id = $(element).attr('id')
        id = id.replace("hdnSKU_No_", "");

        $("#tblPurchaseReturnItems").find("[id^='PurchaseReturnItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#hdnSKU_No_" + j).val()) {
                result = false;
            }
        });

        return result;
    }, "Already mapped.");

    jQuery.validator.addMethod("checkBarcodeExist", function (value, element) {

        debugger;

        var result = true;

        var id = $(element).attr('id');

        id = id.replace("textBarcode_No_", "");

        $("#tblPurchaseReturnItems").find("[id^='PurchaseReturnItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#textBarcode_No_" + j).val()) {
                result = false;
            }
        });

        return result;

    }, "Already mapped.");

        

});