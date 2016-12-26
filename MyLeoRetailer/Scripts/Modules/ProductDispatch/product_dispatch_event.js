$(document).ready(function () {
    var row_Count = document.getElementById("tblProduct_Dispatch").children[1].rows.length;
    if ($("#hdn_request_Id").val() == 0 && row_Count==0) {
        $("#txtBalance_Quantitya").attr("readonly", false);
      //  $("#txtBalance_Quantitya").attr('title', 'Entered quantity must ne dispatch Completely');
    }

    $("#btnSaveDispatch").click(function () {

        var row_Count = document.getElementById("tblProduct_Dispatch").children[1].rows.length;
        if ($("#hdn_request_Id").val() != 0) {
            if (row_Count > 0) {

                $("#lbl_Records_Required").hide();

                Save();

            
            }
            else {
                $("#lbl_Records_Required").show();
            }
        }
        else {
            if (row_Count == $("#hdn_Quantity").val()) {
               
                $("#lbl_Prod_Dispatch").hide();

                $("#lbl_Records_Required").hide();

                Save();
            }
            else if (row_Count != $("#hdn_Quantity").val() && row_Count > 0) {
                $("#lbl_Records_Required").hide();

                $("#lbl_Prod_Dispatch").show();
            }
            else if (row_Count == 0)
            {
                $("#lbl_Records_Required").show();

                $("#lbl_Prod_Dispatch").hide();
            }
        }
    });

    var e = jQuery.Event("keypress");
    e.which = 13; //choose the one you want
    e.keyCode = 13;
    $("#txtBarcode").trigger(e);

    $('#txtBarcode').keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            AddProductDispatch();
            return false;
        }
       
    });


    $("#frmProductDispatch").validate({

        rules: {
            "product_Dispatch.Quantity":
            {

                number: true,
                //validate_Quantity: true
            },

            "product_Dispatch.Balance_Quantitya":
            {

                number: true,
                //validateBal_Quantity: true
            }
        },
        messages: {

        }
    });


});

var message = "";

jQuery.validator.addMethod("validate_Quantity", function (value, element) {

    var result = true;
    var balance_Qty = $("#txtBalance_Quantitya").val();
    if (parseInt(balance_Qty) == 0 && $("#txtDispatch_Quantity").val()==1) {
        result = false;

        $("#txtDispatch_Quantity").val(0);

        message = "Cannot Dispatch as the Product quantity is 0.";
    }

    if ($("#txtDispatch_Quantity").val() > 0) {
        

        if (parseInt(value) > parseInt(balance_Qty) && parseInt(balance_Qty) > 0) {
            result = false;

            $("#txtDispatch_Quantity").val(0);

            message = "Dispatch Quantity cannot be greater than Product Quantity.";
        }


        $.ajax({

            url: "/ProductDispatch/Get_Product_Quantity_Warehouse",

            data: { barcode: $("#txtBarcode").val() },

            method: 'GET',

            async: false,

            success: function (data) {
                if (value > data) {

                    result = false;

                    message = "Dispatch is Cancel as the Quantity of these product in Warehouse is " + data + ".";

                    $("#txtDispatch_Quantity").val(0);
                }

            }
        });

    }
    return result;

}, function () {
    return message;
});


jQuery.validator.addMethod("validateBal_Quantity", function (value, element) {

    var result = true;

        $.ajax({

            url: "/ProductDispatch/Get_Product_Quantity_Warehouse",

            data: { barcode: $("#txtBarcode").val() },

            method: 'GET',

            async: false,

            success: function (data) {
                if (value > data) {

                    result = false;

                    message = "Quantity of these product in Warehouse is " + data + ".";

                    $("#txtDispatch_Quantity").val(0);
                }

            }
        });
        var row_Count = document.getElementById("tblProduct_Dispatch").children[1].rows.length;
        if (row_Count == 0) {
            $("#hdn_Quantity").val($("#txtBalance_Quantitya").val());
        }
    
    return result;
    
}, function () {
    return message;
});


function Save()
{
    $("#frmProductDispatch").attr("action", "/ProductDispatch/Insert");

    $("#frmProductDispatch").attr("Method", "Post");

    $("#frmProductDispatch").submit();
}