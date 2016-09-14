$(document).ready(function () {

    $("#frmRole").validate({
        rules: {
            "role.Role_Name": { required: true, validate_role:true },
        },
        messages: {

            "role.Role_Name": { required: "Role is required." }
        }
    });

    jQuery.validator.addMethod("validate_role", function (value, element) {
        var result = true;

        if ($("#txtRole_Name").val() != "" && $("#hdnRole_Name").val() != $("#txtRole_Name").val()) {
            $.ajax({
                url: '/role/check-role-name',
                data: { role_Name: $("#txtRole_Name").val() },
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

    }, "Role is already exists.");

});