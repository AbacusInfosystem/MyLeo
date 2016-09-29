﻿

$(function () {
    $("#frmPay").validate({
        rules: {
            "Payable.Payament_Date": {
                required: true
            },

            "Payable.Person_Name": {
                required: true
            },

            "Payable.Discount_Percentage": {
                digits: true
            }
        },
        messages: {

            "Payable.Payament_Date": {
                required: "Payament Date is required."

            },

            "Payable.Person_Name": {
                required: "Person Name is required."
            },

            "Payable.Discount_Percentage": {
                digits: "Enter only Digits"
            }
        }
    });
});