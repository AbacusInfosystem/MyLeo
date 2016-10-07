
$(function () {
    $("#frmProductMRP").validate({
        rules: {
            //"AllWSRPricesRequired": { AllPricesRequired: true, digits: true },

            //"Product.Vendor_Name": { required: true },

            //"Product.Launch_Start_Date": { required: true }, 

            //"Product.Launch_End_Date": { required: true },

            //"Product.Brand_Name": { required: true },

            //"Product.Category": { required: true },

            //"Product.Sub_Category": { required: true },

            //"Product.Size_Group_Name": { required: true },

            //"Product.Center_Size": { required: true, digits: true },

            //"Product.Size_Difference": { required: true, digits: true },

            //"Product.Purchase_Price": { required: true, digits: true },

            //"Product.MRP_Difference": { required: true, digits: true },

            //"Product.MRP_Percentage": { required: true, digits: true },

            //"Product.MRP_Price": { required: true, digits: true }, 

        },
        messages: {

            //"Product.Article_No": { required: "Article No is required." },

            //"Product.Vendor_Name": { required: "Vendor is required." },

            //"Product.Launch_Start_Date": { required: "Product Launch Date is required." },

            //"Product.Launch_End_Date": { required: " Product End Date is required." },

            //"Product.Brand_Name": { required: "Brand is required." },

            //"Product.Category": { required: "Category is required." },

            //"Product.Sub_Category": { required: "Sub Category is required." },

            //"Product.Size_Group_Name": { required: "Size Group is required." },

            //"AllWSRPricesRequired": { digits: "Enter Digits" },

            //"Product.Size_Difference": { required: "Size Difference is required.", digits: "Enter Digits" },

            //"Product.Purchase_Price": { required: "Purchase Price is required.", digits: "Enter Digits" },

            //"Product.MRP_Difference": { required: "MRP Difference is required." ,digits: "Enter Digits"},

            //"Product.MRP_Percentage": { required: "MRP Percentage is required.", digits: "Enter Digits" },

            //"Product.MRP_Price": { required: "MRP Price is required.", digits: "Enter Digits" }, 
        }
    });

    //jQuery.validator.addMethod("AllWSRPricesRequired", function (value, element) {

    //    //$(".Product:visible").find(".AllWSRPricesRequired").each(function () {

    //    //    var result = false;

    //    //    if (($("#txtProductWSR_" + element.id.split('_')[1]).val() != '' && $("#txtProductWSR_" + element.id.split('_')[1]).val() != undefined)) {
    //    //        result = true;
    //    //    }
    //    //    return result;
    //    //});

    //    $(element)

    //}, "Please enter purchase price.");

    //jQuery.validator.addMethod("AllMRPPricesRequired", function (value, element) {

    //    var result = false;
    //    if (($("#txtProductMRP_" + element.id.split('_')[1]).val() != '' && $("#txtProductMRP_" + element.id.split('_')[1]).val() != undefined)) {
    //        result = true;
    //    }
    //    return result; 

    //}, "Please enter MRP price.");

    //jQuery.validator.addMethod("Description", function (value, element) {

    //    var result = false;
    //    if (($("#txtProductDesc_" + element.id.split('_')[1]).val() != '' && $("#txtProductDesc_" + element.id.split('_')[1]).val() != undefined)) {
    //        result = true;
    //    }
    //    return result;

    //}, "Please enter product description.");

    //$(function () {
    //    $("#myform").validate();
    //    $("[name=field]").each(function () {
    //        $(this).rules("add", {
    //            required: true,
    //            email: true,
    //            messages: {
    //                required: "Specify a valid email"
    //            }
    //        });
    //    });
    //});


    $("#frmProductColor").validate({
        rules: {
            "Filter.Color": { required: true, ColorCodeExist: true },

            "ProductMRP.Vendor_Color_Code": { required: true },
        },
        messages: {

            "Filter.Color": { required: "Colour Code is required." },

            "ProductMRP.Vendor_Color_Code": { required: "Vendor Colour Code Required" },
        }
    });

    jQuery.validator.addMethod("ColorCodeExist", function (value, element) {

        var result = true;
        var Arr = [];

        $(".block").find("a").each(function () {
            Arr.push($(this).text());
        });

        if ($.inArray(value, Arr) > -1)
            result = false;
        else
            result = true;

        return result;

    }, "Colour Already Exists in List.");

});

