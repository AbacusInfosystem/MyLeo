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
                        },
                    "SalesReturn.Customer_Name":
                        {
                            required: true,
                        },
                    "SalesReturn.Total_Amount_Return_By_Cash":
                        {
                            required: true,
                        },
                    "SaleReturnItemList[0].SKU_Code":
                        {
                            required: true,
                        },
                    "SaleReturnItemList[0].Quantity":
                        {
                            required: true,
                        },
                    "SaleReturnItemList[0].Discount_Percentage":
                        {
                            required: true,
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
                        required: "Mobile No is required"
                    },
                "SalesReturn.Customer_Name":
                    {
                        required: "Customer Name is required",
                    },            
                "SalesReturn.Total_Amount_Return_By_Cash":
                    {
                        required: "Cash Amount is required",
                    },
                "SaleReturnItemList[0].SKU_Code":
                      {
                          required: "SKU Code is Required",
                      },
                "SaleReturnItemList[0].Quantity":
                    {
                        required: "Quantity Required",
                    },
                "SaleReturnItemList[0].Discount_Percentage":
                    {
                        required: "Discount % Required",
                    },

            }
        });
});
