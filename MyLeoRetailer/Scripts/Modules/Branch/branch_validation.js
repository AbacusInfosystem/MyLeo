
//Commented by vinod mane on 27/09/2016
//$(function () {
//    $("#frmBranch").validate({
//        rules: {
//            
//            //"Branch.Branch_Name": {
//            //    required: true
//            //},
//            //end
//            "Branch.Branch_Landline1": {
//                digits: true
//            },

//            "Branch.Branch_Landline2": {
//                digits: true
//            },

//            "Branch.Branch_Pincode": {
//                digits: true
//            },

//        },
//        messages: {

//            //Commented by vinod mane on 27/09/2016
//            //"Branch.Branch_Name": {
//            //    required: "Branch Name is required."
//            //},
//            

//            "Branch.Branch_Landline1": {
//                digits: "Enter only digits"
//            },

//            "Branch.Branch_Landline2": {
//                digits: "Enter only digits"
//            },

//            "Branch.Branch_Pincode": {
//                digits: "Enter only digits"
//            },


//        }
//    });
//});
//End

//added by vinod mane on 27/09/2016

$(document).ready(function () {

    $("#frmBranch").validate({
        rules: {
            "Branch.Branch_Name": { required: true, validate_Branch: true },

            "Branch.Branch_Landline1": {digits: true},

            "Branch.Branch_Landline2": {digits: true },

            "Branch.Branch_Pincode": { digits: true },

            "Branch.Branch_Landline2": { checkmobileno: true },

            "Branch.Branch_Landline1": { checkmobileno: true },
        },
        messages: {

            "Branch.Branch_Name": { required: "Branch Name is required." },
            "Branch.Branch_Landline1": {digits: "Enter only digits"},
            "Branch.Branch_Landline2": { digits: "Enter only digits"},
            "Branch.Branch_Pincode": {digits: "Enter only digits"},
        }
    });

    jQuery.validator.addMethod("validate_Branch", function (value, element) {
        var result = true;

        if ($("#txtBranch_Name").val() != "" && $("#hdnBranch_Name").val() != $("#txtBranch_Name").val()) {
            $.ajax({
                url: '/Branch/check-Branch-name',
                data: { Branch_Name: $("#txtBranch_Name").val() },
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

    }, "Branch Name is already exists.");

    jQuery.validator.addMethod("checkmobileno", function (value, element) {

        var result = true;
        var Landline1 = ($("#txtBranch_Landline1").val());
        var Landline2 = ($("#txtBranch_Landline2").val());

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

    }, "You can not enter same landline no.");

});
//End