

$(function () {
    $("#frmAlteration1").validate({
        rules: {
            "Alteration.Customer_Mobile_No": { required: true, },

            "Alteration.Sales_Invoice_ID": { SalesInvoiceID: true,}//Added by Vinod mane on 28/09/2016

        },
        messages: {

            "Alteration.Customer_Mobile_No": { required: "Mobile Number is required." }
            //"GiftVoucher.Person_Name": { required: "Person Name is required." }
            //"Branch.Far_Branch_Location_Pincode": { required: "Far Branch Pincode is required." }
        }
    });
});


jQuery.validator.addMethod("SalesInvoiceID", function (value, element) {
    var result = true;

    if ($("#drp_Sales_Invoice_no").val() == "") {
        result = false;
    }

    return result;

}, "Invoice no is Required.");
