

$(function () {
    $("#frmPay").validate({
        rules: {


            "Receivable.Branch_Name": {
                required: true
            },

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

            "Receivable.Branch_Name": {
                required: "Branch Name is required."

            },

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

        debugger;

        var result = true;

        var cash = 0;
        var credit = 0;
        var card = 0;
        var gift = 0;
        var check = 0;


        if ($("#txtCash_amount").val() != "") {
            cash = $("#txtCash_amount").val()
        }

        if ($("#txtCheque_Amount").val() != "") {
            credit = $("#txtCheque_Amount").val()
        }

        if ($("#txtCredit_Note_Amount").val() != "") {
            card = $("#txtCredit_Note_Amount").val()
        }

        if ($("#txtCard_Amount").val() != "") {
            gift = $("#txtCard_Amount").val()
        }

        if ($("#txtGift_Voucher_Amount").val() != "") {
            check = $("#txtGift_Voucher_Amount").val()
        }

        var bal_amt = parseFloat($("#txtBalance_Amount").val());

        var paid_amt = parseFloat($("#txtPaid_Amount").val());

        var total = parseInt(cash) + parseInt(credit) + parseInt(card) + parseInt(gift) + parseInt(check);

        //$("#txtPaid_Amount").val(parseInt(cash) + parseInt(credit) + parseInt(card) + parseInt(gift) + parseInt(check));

        if (bal_amt != "" && bal_amt != 0) {

            if (bal_amt >= total) {
                result = true;
                calculate(element);
            }
            else {

                result = false;
                calculate(element);
            }
        }
        return result;

    }, "Entered amount is greater than Balance Amount.");

});

