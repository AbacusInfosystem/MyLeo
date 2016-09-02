$(function () {
    $("#frmCustomer").validate({
        rules: {
            "Customer.First_Name": {
                required: true
            },

            "Customer.Last_Name": {
                required: true
            },

            "Customer.Mobile": {
                digits: true
            },

            "Customer.Customer_Billing_Pincode": {
                digits: true,
            },

            "Customer.Customer_Shipping_Pincode": {
                digits: true,
            },

            "Customer.Customer_Mobile1": {
                digits: true,
            },

            "Customer.Customer_Mobile2": {
                digits: true,
            },

            "Customer.Customer_Landline1": {
                digits: true,
            },

            "Customer.Customer_Landline2": {
                digits: true,
            },

            "Customer.Customer_Email1": {
                email: true,
            }

        },
        messages: {

            "Customer.First_Name": {
                required: "First Name is required."
            },

            "Customer.Last_Name": {
                required: "Last Name is required."
            },

            "Customer.Mobile": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Billing_Pincode": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Shipping_Pincode": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Mobile1": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Mobile2": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Landline1": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Landline2": {
                digits: "Enter only digits"
            },

            "Customer.Customer_Landline2": {
                email: "Invalide e-mail"
            }
        }
    });
    
});