

$(function () {
    $("#frmAlteration").validate({
        rules: {
            "Alteration.Customer_Mobile_No": { required: true }

        },
        messages: {

            "Alteration.Customer_Mobile_No": { required: "Mobile Number is required." }
            //"GiftVoucher.Person_Name": { required: "Person Name is required." }
            //"Branch.Far_Branch_Location_Pincode": { required: "Far Branch Pincode is required." }
        }
    });
});