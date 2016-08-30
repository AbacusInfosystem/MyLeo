$(function () {
    $("#frmTax").validate({
        rules: {
            "Tax.Tax_Name": { required: true }
        },
        messages: {

            "Tax.Tax_Name": { required: "Tax Name is required." }
        }
    });
});