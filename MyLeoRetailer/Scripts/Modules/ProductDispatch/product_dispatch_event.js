$(document).ready(function () {

    $("#btnSaveDispatch").click(function () {

        $('#txtDispatch_Date').rules("add", { required: false, messages: { required: "Dispatch date required." } });
        $('#txtDispatch_Quantity').rules("add", { required: false, number: false, validate_Quantity: false, messages: { required: "Quantity is required." } });

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


    $("#btnProductDispatch").click(function () {

        $("#frmProductDispatch").valid();

        $('#txtDispatch_Date').rules("add", { required: true, messages: {required: "Dispatch date required."} });

        $('#txtDispatch_Quantity').rules("add", { required: true, number: true, validate_Quantity: true, messages: { required: "Quantity is required." } });

        if ($("#frmProductDispatch").valid()) {
            AddProductDispatch();
            $('#txtDispatch_Date').rules("add", { required: false, messages: { required: "Dispatch date required." } }); 
            $('#txtDispatch_Quantity').rules("add", { required: false, number: false, validate_Quantity: false, messages: { required: "Quantity is required." } });
        } 
    });


    //$("#frmProductDispatch").validate({

    //    rules: {
    //        "product_Dispatch.Quantity":
    //        {
                
    //            number:true,
    //            validate_Quantity: true
    //        }

    //    },
    //    messages: {
    //        "product_Dispatch.Quantity": {
             
    //        },
           
    //    }
    //});


});

$(document).on('change', '#txtDispatch_Quantity', function (event) {
    var warehouseQty = 0;

    $("#tblProduct_Dispatch").find('.quantity').each(function () {
        warehouseQty = parseInt(warehouseQty) + parseInt(this.value);
    });

    //if (parseInt(warehouseQty) < parseInt($("#txtDispatch_Quantity").val())) {
    //    $("#lblWarehouseQty").hide();
    //} else {
    //    $("#lblWarehouseQty").show();
    //}
    if ($("#txtDispatch_Quantity").val() != "") {

        var balance_Qty = $("#txtBalance_Quantitya").val();
        if (parseInt($("#txtDispatch_Quantity").val()) > parseInt(balance_Qty)) {
            result = false;

            $("#txtDispatch_Quantity").val(""); 
            $("#lblproductQty").show();
            //message = "Dispatch Quantity cannot be greater than Product Quantity.";
        }
        else {

            $.ajax({

                url: "/ProductDispatch/Get_Product_Quantity_Warehouse",

                data: { sku: $("#txtSKU").val() },

                method: 'GET',

                async: false,

                success: function (data) {
                    if (warehouseQty == 0) {
                        if ($("#txtDispatch_Quantity").val() > data) {
                             
                            $("#lblWarehouseQty").show(); 
                            $("#txtDispatch_Quantity").val("");
                        }
                        else {
                             
                            $("#lblWarehouseQty").hide();
                        }
                    }
                    else {
                        var changewarehouseQty = parseInt(data) - parseInt(warehouseQty);
                        if ($("#txtDispatch_Quantity").val() > changewarehouseQty) {

                            $("#lblWarehouseQty").show();
                            $("#txtDispatch_Quantity").val("");
                        }
                        else {

                            $("#lblWarehouseQty").hide();
                        }
                    }
                }
            });
        }

    }

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