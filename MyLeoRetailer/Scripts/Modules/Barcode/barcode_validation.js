$(document).ready(function () {

    $("#frmBarcodeGenerator").validate({

        rules: {

            "Barcode.Product_SKU": { required: true },

            "Barcode.SKU_Quantity": { required: true, digits: true, },
        },
        messages: {

            "Barcode.Product_SKU": { required: "SKU code is required." },

            "Barcode.SKU_Quantity": { required: "Qunantity is required.", digits: "Enter only digits" }
        }
    });
    
});