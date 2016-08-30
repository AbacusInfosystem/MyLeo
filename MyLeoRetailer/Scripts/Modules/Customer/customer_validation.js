$(function () {
    $("#frmCustomerPrimaryInfo").validate({
        rules: {
            "Customer.First_Name": { required: true },

            "Customer.Last_Name": { required: true },
        },
        messages: {

            "Customer.First_Name": { required: "First Name is required." },

            "Customer.Last_Name": { required: "Last Name is required." }
        }
    });
});