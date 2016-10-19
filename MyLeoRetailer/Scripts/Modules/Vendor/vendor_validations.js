$(document).ready(function () {

    $("#frmVendor").validate(
        {
         //   errorClass: 'login-error',

            rules:
                {
                    //"tblBrandDetails":
                    //  {
                    //      validateTblBrand: true,
                    //  },
                    "Vendor.Vendor_Name":
                       {
                           required: true, validation_Vendor_name:true                        
                       },
                    "Vendor.Vendor_Email1":
                        {
                            required: true,
                            email: true,
                            checkemailid:true
                        },
                    "Vendor.Vendor_Email2":
                        {
                            //  required: true, Change by vinod mane on 20/09/2016
                            email: true,
                            checkemailid: true
                        },
                    "Vendor.Vendor_Address":
                        {
                            required: true,
                        },
                    "Vendor.Vendor_City":
                        {
                            required: true,
                        },
                    "Vendor.Vendor_State":
                        {
                            required: true,
                        },
                    "Vendor.Vendor_Country":
                        {
                            required: true, 
                        },
                    "Vendor.Vendor_Pincode":
                       {
                           required: true,
                           number: true,
                           maxlength: 6,
                       },
                    "Vendor.Vendor_Phone1":
                       {
                           required: true,
                           checkmobileno:true,
                       },
                    "Vendor.Vendor_Phone2":
                       {
                           //required: true, Change by vinod mane on 20/09/2016
                           checkmobileno:true,
                           
                       },
                    "Vendor.Vendor_Vat_No":
                       {
                           required: true,
                           number: true,
                       },
                    "Vendor.Vendor_Vat_Effective_Date":
                       {
                           required: true,
                       },
                    "Vendor.Vendor_Vat_Rate":
                       {
                           VendorVatRate : true,
                       },
                    "Vendor.Vendor_CST_No":
                        {
                            required: true,
                            number: true,
                        },
                    "Vendor.Vendor_CST_Rate":
                      {
                           VendorCstRate : true,
                      },
                    "Vendor.Vendor_CST_Effective_Date":
                      {
                          required: true,
                      }                
                },
            messages: {

                "Vendor.Vendor_Name":
                {
                    required: "Vendor Name is required."
                },
                "Vendor.Vendor_Email1":
                    {
                        required: "Email is required", 
                        email: "Invalid e-mail"
                    },
                "Vendor.Vendor_Email2":
                    {
                        // required: "Email is required", Change by vinod mane on 20/09/2016
                        email: "Invalid e-mail"
                    },
                "Vendor.Vendor_Address":
                    {
                        required: "Address is required",
                    },
                "Vendor.Vendor_City":
                    {
                        required: "City is required",  
                    },
                "Vendor.Vendor_State":
                    {
                        required: "State is required",       
                    },
                "Vendor.Vendor_Country":
                    {
                        required: "Country is required",                    
                    },
                "Vendor.Vendor_Pincode":
                    {
                        required: "Pincode is required",
                        required: "Enter Digits"                
                    },
                "Vendor.Vendor_Phone1":
                      {
                          required: "Phone No is required"
                          
                      },
                //"Vendor.Vendor_Phone2":
                //   {
                //       //required: "Phone No is required", Change by vinod mane on 20/09/2016
                //       required: "Enter Digits"
                //   },
                "Vendor.Vendor_Vat_No":
                   {
                       required: "Vendor Vat No is required",
                       required: "Enter Digits"
                   },
                "Vendor.Vendor_Vat_Effective_Date":
                   {
                       required: "Vat Effective Date is required",
                   },              
                "Vendor.Vendor_CST_No":
                    {
                        required: "Vendor CST No is required",
                        required: "Enter Digits"
                    },               
                "Vendor.Vendor_CST_Effective_Date":
                  {
                      required: "CST Effective Date is required",
                  },               

            }
        });
});


jQuery.validator.addMethod("checkmobileno", function (value, element) {

    var result = true;
    var mobile1 = $("#txtVendor_Phone1").val();
    var mobile2 = $("#txtVendor_Phone2").val();

    if (mobile1 != "" && mobile1 != 0 && mobile2 != "" && mobile2 != 0) {

        if (mobile1 == mobile2) {
            result = false;
            //calculate(element);
        }
        else {
            result = true;
        }
    }
    return result;

}, "You can not enter same Phone no.");

jQuery.validator.addMethod("checkemailid", function (value, element) {

    var result = true;
    var Email1 = ($("#txtVendor_Email1").val());
    var Email2 = ($("#txtVendor_Email2").val());

    if (Email1 != "" && Email2 != "") {

        if (Email1 == Email2) {
            result = false;
            //calculate(element);
        }
        else {
            result = true;
        }
    }
    return result;

}, "You can not enter same email id.");

jQuery.validator.addMethod("VendorVatRate", function (value, element) {
    var result = true;

    if ($("#drpVendor_Vat_Rate").val() == "0") {
        result = false;
    }

    return result;

}, "Vendor Vat Rate is Required.");



jQuery.validator.addMethod("VendorCstRate", function (value, element) {
    var result = true;

    if ($("#drpVendor_CST_Rate").val() == "0") {
        result = false;
    }

    return result;

}, "Vendor Cst Rate is Required.");

//Added by Vinod Mane on 28/09/2016
jQuery.validator.addMethod("validation_Vendor_name", function (value, element) {
    var result = true;

    if ($("#txtVendor_Name").val() != "" && $("#hdnVendorName").val() != $("#txtVendor_Name").val()) {
        $.ajax({
            url: '/vendor/check-vendor-name',
            data: { vendor_name: $("#txtVendor_Name").val() },
            method: 'GET',
            async: false,
            success: function (data) {
                if (data == true) {
                    result = false;
                }
            }
        });
    }
    return result;

}, "Vendor Name is already exists.");

//end

//jQuery.validator.addMethod("validateTblBrand", function (value, element) {
//    var result = true;

//    //var data_Brand = document.getElementById("tblBrandDetails").rows.length;
//    //if (data_Brand == 1) {
//    //    $("#lblmsg").html("Miminum One Brand is Required");
//    //    alert("Brand is Required");
//    //}
//   
//    var temptablecount = $("#tblBrandDetails").find('tr').size();
   

//    //i = temptablecount;//-1;

//    if ($("#tblBrandDetails").val() == "0") {
//        result = false;
//    }

//    return result;

//}, "Vendor Vat Rate is Required.");

//jQuery.validator.addMethod("validateTblBrand", function (value, element) {
//    var result = true;
   
//    var rowCount = $('#tblBrandDetails').rowCount();

//    if (rowCount == "0") {
//        result = false;
//    }

//    return result;

//}, "Brand is Required.");