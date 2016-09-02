
$(function () {
    $("#frmBrand").validate({
        rules: {
            "Brand.Brand_Name": {
                required: true
            },
        },
        messages: {

            "Brand.Brand_Name": {
                required: "Brand is required."
            }
        }
    });
});