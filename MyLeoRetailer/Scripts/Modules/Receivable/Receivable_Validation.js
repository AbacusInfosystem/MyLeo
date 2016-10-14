

$(function () {
    $("#frmPay").validate({
        rules: {
            "Receivable.Payament_Date": {
                required: true
            },

            "Receivable.Cheque_Amount": {
                digits: true
            },

            "Receivable.Cash_Amount": {
                digits: true
            },

            "Receivable.Card_Amount": {
               digits: true
            },
            "Receivable.Cash_Amount": {
                checkBalanceamount: true
            },
            "Receivable.Cheque_Amount": {
             checkBalanceamount: true

            },
            "Receivable.Credit_Note_Amount": {
                checkBalanceamount: true

            },
            "Receivable.Card_Amount": {
                checkBalanceamount: true

            },

            "Receivable.Gift_Voucher_Amount": {
                checkBalanceamount: true

            },

            
        },
        messages: {

            "Receivable.Payament_Date": {
              required: "Payament Date is required."

            },

            "Receivable.Cheque_Amount": {
                digits: "Enter only Digits."
            },

            "Receivable.Cash_Amount": {
                digits: "Enter only Digits"
            },

            "Receivable.Card_Amount": {
                digits: "Enter only Digits"
            }
        }
    });

    jQuery.validator.addMethod("checkBalanceamount", function (value, element) {

        var result = true;
        var bal_amt = parseFloat($("#txtBalance_Amount").val());
        var paid_amt = parseFloat($("#txtPaid_Amount").val());

        if (bal_amt != "" && bal_amt != 0) {

            if (bal_amt >= paid_amt) {
                result = true;
                calculate(element);
            }
            else {

                result = false;
                calculate(element);
            }
        }
        return result;

    }, "Entered amount is greater than balance amount.");

});

