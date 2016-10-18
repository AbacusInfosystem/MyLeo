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
    var result = true;
    if ($("#txtDispatch_Quantity").val() != "")
    {

        var balance_Qty = $("#txtBalance_Quantitya").val()
        if (parseInt(value) > parseInt(balance_Qty))
        {
            result = false;

            $("#txtDispatch_Quantity").val("");

            message = "Dispatch Quantity cannot be greater than Product Quantity.";
        }
        else 
        {
           
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
                        
                        $("#txtDispatch_Quantity").val("");
                    }
                    else
                    {
                        result = true;
                    }
                }
            });
        }
       
    }
    return result;

},function(){
    return message;
});