$(document).ready(function () {

    $("#frmSalesOrder").validate(
        {
            errorClass: 'login-error',

            rules:
                {
                    "SalesInvoice.Sales_Invoice_No":
                       {
                           required: true,
                       },
                    "SalesInvoice.Invoice_Date":
                        {
                            required: true,                            
                        },
                    "SalesInvoice.Mobile":
                        {
                            required: true,
                            number: true
                        },
                    "SalesInvoice.Customer_Name":
                        {
                            required: true,
                        },
                    "SalesInvoice.Tax_Percentage":
                        {
                            required: true,
                            number: true
                        },
                    "SaleOrderItemList[0].SKU_Code":
                        {
                            required: true,
                        },
                    "SaleOrderItemList[0].Quantity":
                        {
                            required: true,
                            number: true
                        },
                    "SaleOrderItemList[0].Discount_Percentage":
                        {
                            required: true,
                            number: true
                        }
                },

            messages: {

                "SalesInvoice.Sales_Invoice_No":
                {
                    required: "Invoice No is required."
                },
                "SalesInvoice.Invoice_Date":
                    {
                        required: "Invoice Date is required"    
                    },
                "SalesInvoice.Mobile":
                    {
                        required: "Mobile No is required",
                        number: "Only numbers"
                    },
                "SalesInvoice.Customer_Name":
                    {
                        required: "Customer Name is required",
                    },
                "Vendor.Vendor_City":
                    {
                        required: "City is required",
                    },
                "SalesInvoice.Tax_Percentage":
                    {
                        required: "Tax Percentage is required",
                        number: "Only numbers"
                    },
                "SaleOrderItemList[0].SKU_Code":
                        {
                            required: "SKU Required",
                        },
                "SaleOrderItemList[0].Quantity":
                    {
                        required: "Quantity Required",
                        number: "Only numbers"
                    },
                "SaleOrderItemList[0].Discount_Percentage":
                    {
                        required: "Discount % Required",
                        number: "Only numbers"
                    },
               
            }
        });
});
