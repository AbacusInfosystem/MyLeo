
//function Save_Vendor_Contact() {

//    var First_Name = $("[name='VendorContact.First_Name']").val();

//    var Last_Name = $("[name='VendorContact.Last_Name']").val();

//    var Vendor_Contact_Name = First_Name + " " + Last_Name;

//    $("[name='VendorContact.Vendor_Contact_Name']").val(Vendor_Contact_Name);

    

//    var vcViewModel =
//		{
//		    VendorContact: {

//		        VendorContact_Id: $("[name='VendorContact.VendorContact_Id']").val(),

//		        Vendor_Id: $("[name='VendorContact.Vendor_Id']").val(),

//		        //First_Name: $("[name='VendorContact.First_Name']").val(),

//		        //Last_Name: $("[name='VendorContact.Last_Name']").val(),

//		        Vendor_Contact_Name: $("[name='VendorContact.Vendor_Contact_Name']").val(),

//		        Address: $("[name='VendorContact.Address']").val(),

//		        City: $("[name='VendorContact.City']").val(),

//		        State: $("[name='VendorContact.State']").val(),

//		        Country: $("[name='VendorContact.Country']").val(),

//		        Pincode: $("[name='VendorContact.Pincode']").val(),

//		        Mobile1: $("[name='VendorContact.Mobile1']").val(),

//		        Mobile2: $("[name='VendorContact.Mobile2']").val(),

//		        Email_Id: $("[name='VendorContact.Email_Id']").val(),

//		        IsActive: $("[name='VendorContact.IsActive']").val(),
//		    }
//		}

//    var url = "";
    
   
//        if ($("[name='VendorContact.VendorContact_Id']").val() == "" || $("[name='VendorContact.VendorContact_Id']").val() == 0) {

//            url = "/VendorContact/Insert_Vendor_Contact";
//        }
//        else {
//            url = "/VendorContact/Update_Vendor_Contact";
//        }
   
//    $.ajax({

//        url: url,

//        data: JSON.stringify(vcViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {
//            var obj = $.parseJSON(response);

//            Reset_Vendor_Contact();

//            Friendly_Messages(obj);

//        }
//    });


//}

//function Reset_Vendor_Contact() {

//    $("[name='VendorContact.VendorContact_Id']").val("");

//    $("[name='VendorContact.Vendor_Id']").val("");

//    $("[name='VendorContact.Vendor_Contact_Name']").val("");

//    $("[name='VendorContact.First_Name']").val("");

//    $("[name='VendorContact.Last_Name']").val("");

//    $("[name='VendorContact.Address']").val("");

//    $("[name='VendorContact.City']").val("");

//    $("[name='VendorContact.State']").val("");

//    $("[name='VendorContact.Country']").val("");

//    $("[name='VendorContact.Pincode']").val("");

//    $("[name='VendorContact.Mobile1']").val("");

//    $("[name='VendorContact.Mobile2']").val("");

//    $("[name='VendorContact.Email_Id']").val("");

//    $("[name='VendorContact.IsActive']").val("");

//    //$('#frmVendorContact').trigger("reset");
//}

