﻿
$(function ()
{
    //$("#frmProductMRP").validate({
	//	rules: {
	//	    "Product.Article_No": { required: true },

	//	    "Product.Vendor_Name": { required: true },

	//	    "Product.Launch_Start_Date": { required: true }, 

	//	    "Product.Launch_End_Date": { required: true },

	//	    "Product.Brand_Name": { required: true },

	//	    "Product.Category": { required: true },

	//	    "Product.Sub_Category": { required: true },

	//	    "Product.Size_Group_Name": { required: true },

	//	    "Product.Center_Size": { required: true, digits: true },

	//	    "Product.Size_Difference": { required: true, digits: true },

	//	    "Product.Purchase_Price": { required: true, digits: true },

	//	    "Product.MRP_Difference": { required: true, digits: true },

	//	    "Product.MRP_Percentage": { required: true, digits: true },

	//	    "Product.MRP_Price": { required: true, digits: true }, 
            
	//	},
	//	messages: {

	//	    "Product.Article_No": { required: "Article No is required." },

	//	    "Product.Vendor_Name": { required: "Vendor is required." },

	//	    "Product.Launch_Start_Date": { required: "Product Launch Date is required." },

	//	    "Product.Launch_End_Date": { required: " Product End Date is required." },

	//	    "Product.Brand_Name": { required: "Brand is required." },

	//	    "Product.Category": { required: "Category is required." },

	//	    "Product.Sub_Category": { required: "Sub Category is required." },

	//	    "Product.Size_Group_Name": { required: "Size Group is required." },

	//	    "Product.Center_Size": { required: "Center Size is required.", digits: "Enter Digits" },

	//	    "Product.Size_Difference": { required: "Size Difference is required.", digits: "Enter Digits" },

	//	    "Product.Purchase_Price": { required: "Purchase Price is required.", digits: "Enter Digits" },

	//	    "Product.MRP_Difference": { required: "MRP Difference is required." ,digits: "Enter Digits"},

	//	    "Product.MRP_Percentage": { required: "MRP Percentage is required.", digits: "Enter Digits" },

	//	    "Product.MRP_Price": { required: "MRP Price is required.", digits: "Enter Digits" }, 
	//	}
    //});

    $("#frmProductColor").validate({
        rules: {
            "Product.Colour_Code": { required: true , ColorCode : true },  
        },
        messages: {

            "Product.Colour_Code": { required: "Colour Code is required." },  
        }
    });

    jQuery.validator.addMethod("ColorCode", function (value, element) {

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