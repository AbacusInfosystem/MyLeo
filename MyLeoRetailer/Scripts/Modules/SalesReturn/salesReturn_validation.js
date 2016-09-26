$(document).ready(function () {

    $("#frmSalesReturn").validate(
        {
            errorClass: 'login-error',

            rules:
                {
                    "SalesReturn.Sales_Return_No":
                       {
                           required: true,
                       },
                    "SalesReturn.SalesReturn_Date":
                        {
                            required: true,
                        },
                    "SalesReturn.Mobile":
                        {
                            required: true,
                            number: true,
                            MobileNo: true
                        },
                    "SalesReturn.Customer_Name":
                        {
                            required: true,
                        },
                    "SalesReturn.Total_Amount_Return_By_Cash":
                        {
                            required: true,
                            number: true
                        },
                    "SaleReturnItemList[0].SKU_Code":
                        {
                            //required: true,
                        },
                    "SaleReturnItemList[0].Quantity":
                        {
                            required: true,
                            number: true
                        },
                    "SaleReturnItemList[0].Discount_Percentage":
                        {
                            required: true,
                            number: true
                        }
                   
                },

            messages: {

                "SalesReturn.Sales_Return_No":
                {
                    required: "Sales Return No is required."
                },
                "SalesReturn.SalesReturn_Date":
                    {
                        required: "Sales Return Date is required"
                    },
                "SalesReturn.Mobile":
                    {
                        required: "Mobile No is required",
                        number: "Only numbers"
                    },
                "SalesReturn.Customer_Name":
                    {
                        required: "Customer Name is required",
                    },            
                "SalesReturn.Total_Amount_Return_By_Cash":
                    {
                        required: "Cash Amount is required",
                        number: "Only numbers"
                    },
                "SaleReturnItemList[0].SKU_Code":
                      {
                          required: "SKU Code is Required",
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
