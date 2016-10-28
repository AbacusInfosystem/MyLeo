$(function () {

    $("#frmProductDispatch").validate({

        rules: {

            "product_Dispatch.Dispatch_Date": {
                required: true
            },

            "Quantity": {
                number: true,
                required: true,
                validate_Quantity: true
            },
           
            "product_Dispatch.Quantity": {              
                
            }

        },
        messages: {
            "product_Dispatch.Dispatch_Date": {
                required: "Dispatch date is required."
            },

            "Quantity": {
                required: "Quantity is required.",
                number: "Enter only numbers"
            },

            "product_Dispatch.Quantity": {                
              
            },
          
        },
        

    });
  
       
});