$(function () {
    $("#frmTax").validate({
        rules: {
            "Tax.Tax_Name": {
                required: true
            },

            "Tax.Tax_Value": {
                number: true
            },
        },
        messages: {

            "Tax.Tax_Name": {
                required: "Tax Name is required."
            },

            "Tax.Tax_Value": {
                digits: "Enter Only Digits"
            },
        }
    });
});