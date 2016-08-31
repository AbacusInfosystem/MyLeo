function Save_Alteration() {

    var aViewModel=
        {
            Alteration: {

                Alteration_ID: $("[name='Alteration.Alteration_ID']").val(),

                Sales_Invoice_ID: $("[name='Alteration.Sales_Invoice_ID']").val(),

                Product_Name: $("[name='Alteration.Product_Name']").val(),

                Alteration_Date: $("[name='Alteration.Alteration_Date']").val(),

                Delivery_Date: $("[name='Alteration.Delivery_Date']").val(),

                Customer_Mobile_No: $("[name='Alteration.Customer_Mobile_No']").val(),

                Job_Assigned_To: $("[name='Alteration.Job_Assigned_To']").val(),

                Additional_Info: $("[name='Alteration.Additional_Info']").val(),

             
            }
        }

    var url = "";

   
    if ($("[name='Alteration.Alteration_ID']").val() == "" || $("[name='Alteration.Alteration_ID']").val() == 0) {

        url = "/Alteration/Insert_Alteration";
        }
        else {
        url = "/Alteration/Update_Alteration";
        }
 
    $.ajax({

        url: url,

        data: JSON.stringify(aViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Reset_Alteration();

            Friendly_Messages(obj);

        }
    });
}

function Reset_Alteration() {

    $("[name='Alteration.Alteration_Id']").val("");

    $("[name='Alteration.Sales_Invoice_ID']").val("");

    $("[name='Alteration.Customer_Mobile_No']").val("");

    $("[name='Alteration.Product_Name']").val("");

    $("[name='Alteration.Job_Assigned_To']").val("");

    $("[name='Alteration.Additional_Info']").val("");

    $("[name='Alteration.Alteration_Date']").val("");

    $("[name='Alteration.Delivery_Date']").val("");

   
}

