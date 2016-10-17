

$(function () {
    $("#frmPay").validate({
        rules: {
            "Payable.Payament_Date": {
                required: true
            },

            "Payable.Employee": {
                required: true
            },

            "Payable.Payment_Mode": {
                PaymentMode: true
            },

            "Payable.Paid_Amount": {
                digits: true
            },

             "Payable.Discount_Percentage": {
                 digits: true
             },
            // //"Payable.Credit_Note_Amount": {
            // //     checkCreditnoteamount: true
            // //},
            "Payable.Discount_Amount": {
                digits: true
            }

        },
        messages: {

            "Payable.Payament_Date": {
                required: "Payament Date is required."

            },

            "Payable.Employee": {
                required: "Employee is required."
            },

            //"Payable.Payment_Mode": {
            //    required: "Select Payment Mode."
            //},

            "Payable.Paid_Amount": {
        digits: "Enter only digits."
            },

            "Payable.Discount_Amount": {
                digits: "Enter only digits."
            },

                "Payable.Discount_Percentage": {
                    digits: "Enter only Digits"
                }
        }
    });
});

jQuery.validator.addMethod("PaymentMode", function (value, element) {
    var result = true;

    if ($("#drpPayment_Mode").val() == "0") {
        result = false;
    }

    return result;

}, "Payment Mode is Required.");


