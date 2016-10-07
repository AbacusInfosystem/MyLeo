$(function () {
    $("#frmCustomer").validate({
        rules: {
            "Customer.First_Name": {
                required: true, validation_FirstName:true
            },

            "Customer.Last_Name": {
                required: true, validation_LastName: true
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
            },
            "Customer.Customer_Email2": {
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

            //Commented by Vinod Mane on 23/09/2016
            //"Customer.Customer_Landline2": {
            //    email: "Invalide e-mail"
            //}
            //End

            //Added By Vinod Mane on 23/09/2016
            "Customer.Customer_Email1": {
                email: "Invalide e-mail"
            },
            //end
            //Added By Vinod Mane on 23/09/2016
            "Customer.Customer_Email2": {
              email: "Invalide e-mail"
             }
            //end

        }
    });

    //Added by Vinod Mane on 28/09/2016
    jQuery.validator.addMethod("validation_FirstName", function (value, element) {
        var result = true;

        if ($("#txtFirstName").val() != "" && $("#hdnFirstName").val() != $("#txtFirstName").val() && $("#txtLastName").val() != "" && $("#hdnLast_Name").val() != $("#txtLastName").val()) {

            var customer_name = $("#txtFirstName").val() + " " + $("#txtLastName").val();
            $.ajax({
                url: '/customer/check-customer-name',
                data: { customer_name: customer_name },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Customer is already exists.");

    jQuery.validator.addMethod("validation_LastName",function (value, element) {
        var result = true;

        if ($("#txtFirstName").val() != "" && $("#hdnFirstName").val() != $("#txtFirstName").val() && $("#txtLastName").val() != "" && $("#hdnLast_Name").val() != $("#txtLastName").val()) {

            var customer_name = $("#txtFirstName").val() + " " + $("#txtLastName").val();
            $.ajax({
                url: '/customer/check-customer-name',
                data: { customer_name: customer_name },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Customer is already exists.");
});
//End