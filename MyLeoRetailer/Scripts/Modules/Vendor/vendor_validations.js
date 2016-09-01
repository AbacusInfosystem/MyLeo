$(document).ready(function () {

    $("#frmVendor").validate(
        {
            errorClass: 'login-error',

            rules:
                {
                    "Vendor.Vendor_Name":
                       {
                           required: true,                          
                       },
                    "Vendor.Vendor_Email1":
                        {
                            required: true,
                            email: true
                        },
                    "Vendor.Vendor_Email2":
                        {
                            required: true,
                            email: true
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
                           number: true,
                           maxlength: 12,
                       },
                    "Vendor.Vendor_Phone2":
                       {
                           required: true,
                           number: true,
                           maxlength: 12,
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
                    //"Vendor.Brand_Id":
                    //  {
                    //      required: true,
                    //  },
                    //"Vendor.Category_Id":
                    //  {
                    //      required: true,
                    //  },
                    //"Vendor.SubCategory_Id":
                    //  {
                    //      required: true,
                    //  }
                   
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
                        required: "Email is required",
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
                          required: "Phone No is required",
                          required: "Enter Digits"
                      },
                "Vendor.Vendor_Phone2":
                   {
                       required: "Phone No is required",
                       required: "Enter Digits"
                   },
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

