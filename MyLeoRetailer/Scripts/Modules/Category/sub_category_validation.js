
$(function () {
    $("#frmSubCategory").validate({
        rules: {
            "SubCategory.Sub_Category": { required: true },

            "SubCategory.Sub_Category_Code": { required: true },
        },
        messages: {

            "SubCategory.Sub_Category": { required: "Sub Category is required." },

            "SubCategory.Sub_Category_Code": { required: "Sub Category Code is required." }
        }
    });
});