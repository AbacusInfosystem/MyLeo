

$(function () {
    $("#frmPay").validate({
        rules: {
            "Payable.Payament_Date": {
                required: true
            },

            "Payable.Person_Name": {
                required: true
            },

            "Payable.Discount_Percentage": {
                digits: true
            },
            //"Payable.Credit_Note_Amount": {
            //     checkCreditnoteamount: true
            //},
            "Payable.Discount_Amount": {
                checkdiscountamt: true
           }

        },
        messages: {

            "Payable.Payament_Date": {
                required: "Payament Date is required."

            },

            "Payable.Person_Name": {
                required: "Person Name is required."
            },

            "Payable.Discount_Percentage": {
                digits: "Enter only Digits"
            }
        }
    });
});



jQuery.validator.addMethod("checkdiscountamt", function (value, element) {

    var result = true;
    var final_amt = parseFloat($("#txtFinal_amount").val());
    var discount_amt = parseFloat($("#txtDiscount_amount").val());

    if (final_amt != "" && final_amt != 0) {

        if (final_amt >= discount_amt) {
            result = true;
            //calculate(element);
        }
        else {
            result = false;
        }
    }
    return result;

}, "Entered amount is greater than final amount.");