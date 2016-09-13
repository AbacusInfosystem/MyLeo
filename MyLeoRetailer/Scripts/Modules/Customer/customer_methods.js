
function Get_Customer_By_mobile() {

    
    var cViewModel =
		{
		    Customer: {

		        Mobile: $("[name='Customer.Mobile']").val()
		    }
		}

    $.ajax({

        url: "/Customer/Get_Customer_By_Mobile",

        data: JSON.stringify(cViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Set_Customer_Values(obj);
            
            //Set IsActive Button Status
            var fix = $("[name='Customer.IsActive']").val();

            if (fix == "0") {
                document.getElementById('Flag').checked = false;
            }
            else {
                document.getElementById('Flag').checked = true;
            }
            //End
        }
    });
}

function Set_Customer_Values(obj) {
    
    $("[name='Customer.Customer_Name']").val(obj.Customer.Customer_Name);

    $("[name='Customer.First_Name']").val(obj.Customer.First_Name);

    $("[name='Customer.Last_Name']").val(obj.Customer.Last_Name);

    $("[name='Customer.Customer_Billing_Address']").val(obj.Customer.Customer_Billing_Address);

    $("[name='Customer.Customer_Billing_City']").val(obj.Customer.Customer_Billing_City);

    $("[name='Customer.Customer_Billing_State']").val(obj.Customer.Customer_Billing_State);

    $("[name='Customer.Customer_Billing_Country']").val(obj.Customer.Customer_Billing_Country);

    $("[name='Customer.Customer_Billing_Pincode']").val(obj.Customer.Customer_Billing_Pincode);

    $("[name='Customer.Customer_Shipping_Address']").val(obj.Customer.Customer_Shipping_Address);

    $("[name='Customer.Customer_Shipping_City']").val(obj.Customer.Customer_Shipping_City);

    $("[name='Customer.Customer_Shipping_State']").val(obj.Customer.Customer_Shipping_State);

    $("[name='Customer.Customer_Shipping_Country']").val(obj.Customer.Customer_Shipping_Country);

    $("[name='Customer.Customer_Shipping_Pincode']").val(obj.Customer.Customer_Shipping_Pincode);

    $("[name='Customer.Customer_Mobile1']").val(obj.Customer.Customer_Mobile1);

    $("[name='Customer.Customer_Mobile2']").val(obj.Customer.Customer_Mobile2);

    $("[name='Customer.Customer_Landline1']").val(obj.Customer.Customer_Landline1);

    $("[name='Customer.Customer_Landline2']").val(obj.Customer.Customer_Landline2);

    $("[name='Customer.Customer_Gender']").val(obj.Customer.Customer_Gender);

    $("[name='Customer.Customer_Child1_Name']").val(obj.Customer.Customer_Child1_Name);

    $("[name='Customer.Customer_Child2_Name']").val(obj.Customer.Customer_Child2_Name);

    $("[name='Customer.Customer_Email1']").val(obj.Customer.Customer_Email1);

    $("[name='Customer.Customer_Email2']").val(obj.Customer.Customer_Email2);

    $("[name='Customer.Customer_Spouse_Name']").val(obj.Customer.Customer_Spouse_Name);

    $("[name='Customer.Customer_DOB']").val(obj.Customer.Customer_DOB);  

    $("[name='Customer.Customer_Child1_DOB']").val(obj.Customer.Customer_Child1_DOB);

    $("[name='Customer.Customer_Child2_DOB']").val(obj.Customer.Customer_Child2_DOB);

    $("[name='Customer.Customer_Wedding_Anniversary']").val(obj.Customer.Customer_Wedding_Anniversary);

    $("[name='Customer.Customer_Spouse_DOB']").val(obj.Customer.Customer_Spouse_DOB);

    $("[name='Customer.IsActive']").val(obj.Customer.IsActive);


    $("[name='Customer.Customer_Id']").val(obj.Customer.Customer_Id);
   
}


