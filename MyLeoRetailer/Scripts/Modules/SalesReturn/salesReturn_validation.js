$(document).ready(function () {

    $("#frmSalesReturn").validate(
        {
            

            rules:
                {
                   
                    "SalesReturn.SalesReturn_Date":
                        {
                            required: true,
                        },
                    "SalesReturn.Mobile":
                        {
                            required: true,
                           
                            MobileNo: true
                        },
                   
                    "SalesReturn.Total_Amount_Return_By_Cash":
                        {
                            required: true,
                            number: true
                        },
                 
                    "SaleReturnItemList[0].Quantity":
                        {
                            required: true,
                            number: true,
                            QuantityCheck: true
                        },
                    "SaleReturnItemList[0].Discount_Percentage":
                        {
                            required: true,
                            number: true
                        }
                   
                },

            messages: {

               
                "SalesReturn.SalesReturn_Date":
                    {
                        required: "Sales Return Date is required"
                    },
                "SalesReturn.Mobile":
                    {
                        required: "Mobile No is required",
                        //number: "Only numbers"
                    },
                            
                "SalesReturn.Total_Amount_Return_By_Cash":
                    {
                        required: "Cash Amount is required"
                        
                    },  
                "SaleReturnItemList[0].Quantity":
                    {
                        required: "Quantity Required",
                        number: "Only numbers"
                    },
                "SaleReturnItemList[0].Discount_Percentage":
                    {
                        required: "Discount % Required",
                        number: "Only numbers"
                    },

            }
        });

    jQuery.validator.addMethod("checkSKUExist", function (value, element) {

        var result = true;

        var id = $(element).attr('id');

        id = id.replace("textSKU_No_", "");

        $("#tblSalesReturnItems").find("[id^='SalesReturnItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#textSKU_No_" + j).val()) {
                result = false;
            }
        });

        return result;

    }, "Already mapped.");


});

jQuery.validator.addMethod("MobileNo", function (value, element) {

    var result = true;

    if ($("#txtMobileNo").val() != "" && $("#hdnMobileNo").val() != $("#txtMobileNo").val()) {
        $.ajax({

            url: '/SalesOrder/Check_Mobile_No',
            data:
                {
                    MobileNo: value
                },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data == false) {
                    result = false;
                }
            }
        });
    }
    return result;

}, "Mobile Number does not exists.");


jQuery.validator.addMethod("QuantityCheck", function (value, element) {

    debugger;

    var result = true;

    if (($("#textQuantity_").val() != "" && $("#hdnQuantity").val() != $("#textQuantity_").val()) && ($("#textSKU_No_").val() != "" && $("#hdnSKU_No_" + $(element).closest("tr").index()).val() != $("#textSKU_No_").val()) && ($("#textSales_Branch_Name_0").val() != "" && $("#hdnBranchID").val() != $("#textSales_Branch_Name_0").val())) {
        $.ajax({

            url: '/SalesReturn/Check_Quantity',
            data:
                {
                    Quantity: value,
                    SKU_Code: $("#hdnSKU_No_" + $(element).closest("tr").index()).val(),
                    Branch_Id: $("#hdnBranchID").val()
                },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data == false) {
                    result = false;
                }
            }
        });
    }
    return result;

}, "Quantity does not exists.");


