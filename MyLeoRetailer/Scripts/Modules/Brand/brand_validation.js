
$(function () {
    $("#frmBrand").validate({
        rules: {
            "Brand.Brand_Name": {
                required: true
            },
            "Brand.Brand_Code": {
                required: true
            },
        },
        messages: {

            "Brand.Brand_Name": {
                required: "Brand is required."
            },
            "Brand.Brand_Code": {
                required: "Brand Code is required."
            }
        }
    });
});