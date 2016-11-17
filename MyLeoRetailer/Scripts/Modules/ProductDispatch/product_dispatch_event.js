$(document).ready(function () {

    $("#btnSaveDispatch").click(function () {

           var row_Count=document.getElementById("tblProduct_Dispatch").children[1].rows.length;

           if (row_Count > 0) {
               $("#frmProductDispatch").attr("action", "/ProductDispatch/Insert");

               $("#frmProductDispatch").attr("Method", "Post");

               $("#frmProductDispatch").submit();

               $("#lbl_Records_Required").hide();
           }
           else {
               $("#lbl_Records_Required").show();
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
                
                number:true,
                validate_Quantity: true
            }

        },
        messages: {
           
        }
    });


});

var message = "";

jQuery.validator.addMethod("validate_Quantity", function (value, element){
   
    if ($("#txtDispatch_Quantity").val() > 0)
    {
        var result = true;

        var balance_Qty = $("#txtBalance_Quantitya").val()

        if (parseInt(balance_Qty)==0) {
            result = false;

            $("#txtDispatch_Quantity").val(0);

            message = "Cannot Dispatch as the Product quantity is 0.";
        }

        if (parseInt(value) > parseInt(balance_Qty) && parseInt(balance_Qty) > 0)
        {
            result = false;

            $("#txtDispatch_Quantity").val(0);

            message = "Dispatch Quantity cannot be greater than Product Quantity.";
        }
     
           
            $.ajax({

                url: "/ProductDispatch/Get_Product_Quantity_Warehouse",

                data: { sku: $("#txtSKU").val() },

                method: 'GET',

                async: false,

                success: function (data)
                {
                    if (value > data) {

                        result = false;

                        message ="Dispatch is Cancel as the Quantity of these product in Warehouse is " + data + ".";
                        
                        $("#txtDispatch_Quantity").val(0);
                    }
                   
                }
            });
    
    }
    return result;

},function(){
    return message;
});