$(function () {
    $("#frmBranch").validate({
        rules: {
            "Branch.Branch_Name": {
                required: true
            },

            //"Branch.Near_Branch_Location_Pincode": {
            //    required: true
            //},

            //"Branch.Far_Branch_Location_Pincode": {
            //    required: true
            //}
        },
        messages: {

            "Branch.Branch_Name": {
                required: "Branch Name is required."
            },

            //"Branch.Near_Branch_Location_Pincode": {
            //    required: "Near Branch Pincode is required."
            //},

            //"Branch.Far_Branch_Location_Pincode": {
            //    required: "Far Branch Pincode is required."
            //}
        }
    });
});