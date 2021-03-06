﻿
function Get_Customer_By_mobile() {

    
    var cViewModel =
		{
		    Customer: {

		        Mobile: $("#txtMobileNo").val()
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
            //var fix = $("[name='Customer.IsActive']").val();

            //if (fix == "0") {
            //    document.getElementById('Flag').checked = false;
            //}
            //else {
            //    document.getElementById('Flag').checked = true;
            //}
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


    // $("[name='Customer.Customer_DOB']").val(obj.Customer.Customer_DOB);  //Commented by Vinod Mane on 23/09/2016

    //var showChequeDate = new Date(parseInt(obj.Customer.Customer_DOB))//.replace('/Date(', '')));    

    // showChequeDate = (showChequeDate.getMonth() + 1).toString() + "/" + (showChequeDate.getDate().toString() + "/" + showChequeDate.getFullYear());
    //End

    //Added By Vinod Mane on 23/09/2016
    var Customer_DOB = new Date(obj.Customer.Customer_DOB);
    Customer_DOB = (Customer_DOB.getDate().toString() + "-" + (Customer_DOB.getMonth() + 1).toString() + "-" + Customer_DOB.getFullYear());  
    $("[name='Customer.Customer_DOB']").val(Customer_DOB);
    //End
        
    // $("[name='Customer.Customer_Child1_DOB']").val(obj.Customer.Customer_Child1_DOB);

    //Added By Vinod Mane on 23/09/2016
    var Child1_DOB = new Date(obj.Customer.Customer_Child1_DOB);
    Child1_DOB = (Child1_DOB.getDate().toString() + "-" + (Child1_DOB.getMonth() + 1).toString() + "-" + Child1_DOB.getFullYear());
    $("[name='Customer.Customer_Child1_DOB']").val(Child1_DOB);
    //End

    //$("[name='Customer.Customer_Child2_DOB']").val(obj.Customer.Customer_Child2_DOB);

    //Added By Vinod Mane on 23/09/2016
    var Child2_DOB = new Date(obj.Customer.Customer_Child2_DOB);
    Child2_DOB = (Child2_DOB.getDate().toString() + "-" + (Child2_DOB.getMonth() + 1).toString() + "-" + Child2_DOB.getFullYear());
    $("[name='Customer.Customer_Child2_DOB']").val(Child2_DOB);
    //End

    //$("[name='Customer.Customer_Wedding_Anniversary']").val(obj.Customer.Customer_Wedding_Anniversary);

    //Added By Vinod Mane on 23/09/2016
    var Cus_Wed_Annisry = new Date(obj.Customer.Customer_Wedding_Anniversary);
    Cus_Wed_Annisry = (Cus_Wed_Annisry.getDate().toString() + "-" + (Cus_Wed_Annisry.getMonth() + 1).toString() + "-" + Cus_Wed_Annisry.getFullYear());
    $("[name='Customer.Customer_Wedding_Anniversary']").val(Cus_Wed_Annisry);
    //End

    //$("[name='Customer.Customer_Spouse_DOB']").val(obj.Customer.Customer_Spouse_DOB);

    //Added By Vinod Mane on 23/09/2016
    var Cus_Spouse_DOB = new Date(obj.Customer.Customer_Spouse_DOB);
    Cus_Spouse_DOB = (Cus_Spouse_DOB.getDate().toString() + "-" + (Cus_Spouse_DOB.getMonth() + 1).toString() + "-" + Cus_Spouse_DOB.getFullYear());
    $("[name='Customer.Customer_Spouse_DOB']").val(Cus_Spouse_DOB);
    //End

    $("[name='Customer.IsActive']").val(obj.Customer.IsActive);


    $("[name='Customer.Customer_Id']").val(obj.Customer.Customer_Id);
   
}

function handleClick() {

    var address = null;
    var city = null;
    var state = null;
    var country = null;
    var pincode = null;

     address = $("#txtCustomerBillingAddress").val();

     city = $("#txtCustomerBillingCity").val();

     state = $("#txtCustomerBillingState").val();

     country = $("#txtCustomerBillingCountry").val();

     pincode = $("#txtCustomerBillingPincode").val();

     if ($("#txtcheckbox").val() == 0) {

         $("#txtCustomerShippingAddress").val(address);

         $("#txtCustomerShippingCity").val(city);

         $("#txtCustomerShippingState").val(state);

         $("#txtCustomerShippingCountry").val(country);

         $("#txtCustomerShippingPincode").val(pincode);

     }

     else
    {
        $("#txtCustomerShippingAddress").val("");

        $("#txtCustomerShippingCity").val("");

        $("#txtCustomerShippingState").val("");

        $("#txtCustomerShippingCountry").val("");

        $("#txtCustomerShippingPincode").val("");
    }
       
  
   
   
}
