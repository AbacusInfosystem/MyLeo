$(function () {
    $("#frmCustomer").validate({
        rules: {
            "Customer.First_Name": {
                required: true, validation_FirstName:true
            },

            "Customer.Last_Name": {
                required: true, validation_LastName: true
            },

            //"Customer.Mobile": {
            //    digits: true
            //},

            "Customer.Customer_Billing_Pincode": {
                digits: true,
            },

            "Customer.Customer_Shipping_Pincode": {
                digits: true,
            },

            "Customer.Customer_Mobile1": {
                
                checkmobileno: true,
            },

            "Customer.Customer_Mobile2": {
                
                checkmobileno: true,
            },

            "Customer.Customer_Landline1": {
                
                checklandlineno: true,
            },

            "Customer.Customer_Landline2": {
                
                checklandlineno: true,
            },

            "Customer.Customer_Email1": {
                email: true,
                checkemailid: true,
            },
            "Customer.Customer_Email2": {
                email: true,
                checkemailid: true,
            },
            
            //Added by vinod mane on 17/10/2016
            "Customer.Customer_DOB": {
               
                chkdate: true
            },
            
            "Customer.Customer_Spouse_DOB": {
               
                chkSpousebirth: true
            },

            "Customer.Customer_Wedding_Anniversary": {

                chk_Wedding_Anniversary: true
            },
            
            "Customer.Customer_Child1_DOB": {

                     chk_Child1_DOB: true
             },
            "Customer.Customer_Child2_DOB": {

                chk_Child2_DOB: true
            },
            //end


        },
        messages: {

            "Customer.First_Name": {
                required: "First Name is required."
            },

            "Customer.Last_Name": {
                required: "Last Name is required."
            },

            //"Customer.Mobile": {
            //    digits: "Enter only digits"
            //},

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
             },
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

    jQuery.validator.addMethod("checkmobileno", function (value, element) {

        var result = true;
        var mobile1 = $("#txtCustomer_Mobile1").val();
        var mobile2 = $("#txtCustomer_Mobile2").val();

        if (mobile1 != "" && mobile1 != 0 && mobile2 != "" && mobile2 != 0) {

            if (mobile1 == mobile2) {
                result = false;
                //calculate(element);
            }
            else {
                result = true;
            }
        }
        return result;

    }, "You can not enter same mobile no.");

    jQuery.validator.addMethod("checklandlineno", function (value, element) {

        var result = true;
        var Landline1 = $("#txtCustomer_Landline1").val();
        var Landline2 = $("#txtCustomer_Landline2").val();

        if (Landline1 != "" && Landline1 != 0 && Landline2 != "" && Landline2 != 0) {

            if (Landline1 == Landline2) {
                result = false;
                //calculate(element);
            }
            else {
                result = true;
            }
        }
        return result;

    }, "You can not enter same land-line no.");

    jQuery.validator.addMethod("checkemailid", function (value, element) {

        var result = true;
        var Email1 = ($("#txtCustomer_Email1").val());
        var Email2 = ($("#txtCustomer_Email2").val());

        if (Email1 != ""  && Email2 != "" ) {

            if (Email1 == Email2) {
                result = false;
                //calculate(element);
            }
            else {
                result = true;
            }
        }
        return result;

    }, "You can not enter same email id.");

    //Added by vinod mane on 17/10/2016
    $.validator.addMethod('chkdate', function (value) {

        var result = true;

        var DOB_Date = $("#txt_DOB").val();
        
        if (DOB_Date != '') {

            var ServiceUrl = "/Customer/Compare_Dates";
            $.ajax({
                data: { DOB_Date: DOB_Date },
                url: ServiceUrl,
                type: "POST",
                dataType: "json",
                async: false,
                success: function (data) {
                    result = data;                    
                }
            });
        }
        return result;

    }, 'Please Select valid Birth Date');

   
    $.validator.addMethod('chkSpousebirth', function (value) {

        var result = true;

        var DOB_Date = $("#dtp_Spousebirth").val();

        if (DOB_Date != '') {

            var ServiceUrl = "/Customer/Compare_Dates";
            $.ajax({
                data: { DOB_Date: DOB_Date },
                url: ServiceUrl,
                type: "POST",
                dataType: "json",
                async: false,
                success: function (data) {
                    result = data;
                }
            });
        }
        return result;

    }, 'Please Select valid Spouse Birth Date');

   
    $.validator.addMethod('chk_Wedding_Anniversary', function (value) {

        var result = true;

        var DOB_Date = $("#dtp_Weddingannniv").val();

        if (DOB_Date != '') {

            var ServiceUrl = "/Customer/Compare_Dates";
            $.ajax({
                data: { DOB_Date: DOB_Date },
                url: ServiceUrl,
                type: "POST",
                dataType: "json",
                async: false,
                success: function (data) {
                    result = data;
                }
            });
        }
        return result;

    }, 'Please Select valid Wedding annniversary date');

    $.validator.addMethod('chk_Child1_DOB', function (value) {

        var result = true;

        var DOB_Date = $("#dtp_Child1_DOB").val();

        if (DOB_Date != '') {

            var ServiceUrl = "/Customer/Compare_Dates";
            $.ajax({
                data: { DOB_Date: DOB_Date },
                url: ServiceUrl,
                type: "POST",
                dataType: "json",
                async: false,
                success: function (data) {
                    result = data;
                }
            });
        }
        return result;

    }, 'Please Select valid Child 1 Birth Date');

   $.validator.addMethod('chk_Child2_DOB', function (value) {

        var result = true;

        var DOB_Date = $("#dtp_Child2_DOB").val();

        if (DOB_Date != '') {

            var ServiceUrl = "/Customer/Compare_Dates";
            $.ajax({
                data: { DOB_Date: DOB_Date },
                url: ServiceUrl,
                type: "POST",
                dataType: "json",
                async: false,
                success: function (data) {
                    result = data;
                }
            });
        }
        return result;

   }, 'Please Select valid  Child 2 Birth Date');

    //End

});
//End