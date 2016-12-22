
$(function () {
    $("#frmProduct").validate({
        rules: {
            "Product.Article_No": { required: true, validate_ArticleNo: true },

            "Product.Vendor_Name": { required: true },

            "Product.Launch_Start_Date": { required: true },

            "Product.Launch_End_Date": { required: true },

            "Product.Brand_Name": { required: true },

            "Product.Category": { required: true },

            "Product.Sub_Category": { required: true },

            "Product.Size_Group_Name": { required: true },

            "Product.Center_Size": { required: true, digits: true },

            "Product.Size_Difference": { number: true },//digits: true

            "Product.Purchase_Price": { required: true, digits: true },

            "Product.WSR": { required: true, number: true },

            "Product.MRP_Difference": { number: true },// digits: true

            "Product.MRP_Percentage": { number: true },

            "Product.MRP_Price": { required: true, digits: true },

            //"ProductImage.File": {
            //    required: true,
            //    extension: "jpeg|png|jpg|JPEG|PNG|JPG"
            //}

        },
        messages: {

            "Product.Article_No": { required: "Article No is required." },

            "Product.Vendor_Name": { required: "Vendor is required." },

            "Product.Launch_Start_Date": { required: "Product Launch Date is required." },

            "Product.Launch_End_Date": { required: " Product End Date is required." },

            "Product.Brand_Name": { required: "Brand is required." },

            "Product.Category": { required: "Category is required." },

            "Product.Sub_Category": { required: "Sub Category is required." },

            "Product.Size_Group_Name": { required: "Size Group is required." },

            "Product.Center_Size": { required: "Center Size is required.", digits: "Enter Digits" },

            "Product.Size_Difference": { required: "Size Difference is required.", number: "Enter Numbers" },//digits: "Enter Digits"

            "Product.Purchase_Price": { required: "Purchase Price is required.", digits: "Enter Digits" },

            "Product.WSR": { required: "WSR is required.", number: "Enter Numbers" },

            "Product.MRP_Difference": { required: "MRP Difference is required.", number: "Enter Numbers" },//digits: "Enter Digits"

            "Product.MRP_Percentage": { required: "MRP Percentage is required.", number: "Enter Numbers" },

            "Product.MRP_Price": { required: "MRP Price is required.", digits: "Enter Digits" },

            //"ProductImage.File": {
            //    required: "File is required.",
            //    extension: "Please upload jpeg/png/jpg file"
            //},
        }
    });

    jQuery.validator.addMethod("validate_ArticleNo", function (value, element) {
        var result = true;
        if ($("#hdn_ProductId").val() == 0) {
            if ($("#txtArticle_No").val() != "" && $("#txtArticle_No").val() != null) {
                $.ajax({
                    url: '/product/check-article-no',
                    data: { Article_No: $("#txtArticle_No").val() },
                    method: 'GET',
                    async: false,
                    success: function (data) {
                        if (data == true) {
                            result = false;
                        }
                    }
                });
            }
        }
        return result;

    }, "Article No is already exists.");

    jQuery.validator.addMethod('positiveNumber',
    function (value) {// /^-?\d{2}(\.\d+)?$/
        var match = (/^\-?[0-9]*\.?[0-9]+$/).exec(value);
        //alert(match);
        var result = false;
        if (match[0] > 0)
            return true;
    }, 'Enter a positive and greater than 0 number.');
});