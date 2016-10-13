$(document).ready(function () {

    $("#frmSalesOrder").validate(
        {
            //errorClass: 'login-error',

            rules:
                {
                    "SalesInvoice.Branch_Name":
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
                            number: true,
                            MobileNo : true
                        },
                    //"SalesInvoice.Customer_Name":
                    //    {
                    //        required: true,
                    //    },
                    "SalesInvoice.Tax_Percentage":
                        {
                            required: true,
                            number: true
                        },
                    //"SaleOrderItemList[0].SKU_Code":
                    //    {
                    //        required: true,
                    //    },
                    "SaleOrderItemList[0].Quantity":
                        {
                            required: true,
                            number: true,
                            QuantityCheck : true
                        },
                    "SaleOrderItemList[0].Discount_Percentage":
                        {
                            //required: true,
                            number: true
                        }
                },

            messages: {

                "SalesInvoice.Branch_Name":
                {
                    required: "Branch Name is required."
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
                        required: "",
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
                        required: "Required field",
                        number: "Only numbers"
                    },
               
            }
        });


    jQuery.validator.addMethod("checkSKUExist", function (value, element) {

        var result = true;

        var id = $(element).attr('id');

        id = id.replace("textSKU_No_", "");

        $("#tblSalesOrderItems").find("[id^='SalesOrderItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#textSKU_No_" + j).val())
            {
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

    alert(this.id);

    var result = true;

    if (($("#textQuantity_").val() != "" && $("#hdnQuantity").val() != $("#textQuantity_").val()) && ($("#textSKU_No_").val() != "" && $("#hdnSKU_No_" + $(element).closest("tr").index()).val() != $("#textSKU_No_").val()) && ($("#textSales_Branch_Name_0").val() != "" && $("#hdnBranchID").val() != $("#textSales_Branch_Name_0").val())) {
        $.ajax({

            url: '/SalesOrder/Check_Quantity',
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


