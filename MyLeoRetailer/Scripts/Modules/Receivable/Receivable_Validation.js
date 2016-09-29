

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
            }

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
});