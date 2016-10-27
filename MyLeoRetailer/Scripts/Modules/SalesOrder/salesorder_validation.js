$(document).ready(function () {

    $("#frmSalesOrder").validate(
        {

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
                            MobileNo : true
                        },
                  
                    "SalesInvoice.Tax_Percentage":
                        {
                            required: true,
                            number: true
                        },
                   
                    "SaleOrderItemList[0].Quantity":
                        {
                            required: true,
                            number: true,
                            QuantityCheck : true
                        },
                    "SaleOrderItemList[0].Discount_Percentage":
                        {
                            number: true
                        },
                    "SalesInvoice.Payament_Date": {
                        required: true
                    },

                    "SalesInvoice.Cheque_Amount": {
                        digits: true,
                        checkBalanceamount: true
                    },

                    "SalesInvoice.Cash_Amount": {
                        digits: true,
                        checkBalanceamount: true
                    },

                    "SalesInvoice.Card_Amount": {
                        digits: true,
                        checkBalanceamount: true
                    },

                    "SalesInvoice.Credit_Note_Amount": {
                        checkBalanceamount: true
                    },
                    "SalesInvoice.Gift_Voucher_Amount": {
                        checkBalanceamount: true

                    },
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
                "SalesInvoice.Payament_Date": {
                    required: "Payament Date is required."

                },

                "SalesInvoice.Cheque_Amount": {
                    digits: "Enter only Digits."
                },

                "SalesInvoice.Cash_Amount": {
                    digits: "Enter only Digits"
                },

                "SalesInvoice.Card_Amount": {
                    digits: "Enter only Digits"
                }
               
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

    jQuery.validator.addMethod("checkBarcodeExist", function (value, element) {

        debugger;

        var result = true;

        var id = $(element).attr('id');

        id = id.replace("textBarcode_No_", "");

        $("#tblSalesOrderItems").find("[id^='SalesOrderItemRow_']").each(function (j, row) {

            if (id != j && $(element).val() == $("#textBarcode_No_" + j).val()) {
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

   // alert(this.id);

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


jQuery.validator.addMethod("checkBalanceamount", function (value, element) {

  
    var result = true;

    var total_amt = parseFloat($("#textTotalAmount").val());
     
    var paid_amt = parseFloat($("#txtPaid_Amount").val());
    var cashamt = parseInt($("#txtCash_amount").val());
    var chequeamt = parseInt($("#txtCheque_Amount").val());
    var crdnoteamt = parseInt($("#txtCredit_Note_Amount").val());
    var cardamt = parseInt($("#txtCard_Amount").val());
    var gift_amt = parseInt($("#txtGift_Voucher_Amount").val());

    if (isNaN(paid_amt))
        paid_amt = 0;
    if (isNaN(cashamt))
        cashamt = 0;
    if (isNaN(chequeamt))
        chequeamt = 0;
    if (isNaN(crdnoteamt))
        crdnoteamt = 0;
    if (isNaN(cardamt))
        cardamt = 0;
    if (isNaN(gift_amt))
        gift_amt = 0;

    var total =  cashamt + chequeamt + crdnoteamt + cardamt + gift_amt;



    if (total_amt != "" && total_amt != 0) {

        if (total_amt >= total) {
            result = true;
            calculate();
        }
        else {
            result = false;
        }
    }
    return result;

}, "Entered amount is greater than Total Amount.");


