
$(function () {
    $("#frmSubCategory").validate({
        rules: {
            "SubCategory.Sub_Category": { required: true },
        },
        messages: {

            "SubCategory.Sub_Category": { required: "Sub Category is required." }
        }
    });
});