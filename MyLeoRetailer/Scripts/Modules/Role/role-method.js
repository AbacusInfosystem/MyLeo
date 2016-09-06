function Save_Role() {
    var activeFlg = false;
    if ($("[name='role.Is_Active']").val() == 1) {
        activeFlg = true;
    }

    var rViewModel =
		{
		    role: {

		        Role_Name: $("[name='role.Role_Name']").val(),

		        Is_Active: activeFlg,

		        Role_Id: $("[name='role.Role_Id']").val()
		    }
		}

    var url = "";

    url = "/role/save-role";

    $.ajax({

        url: url,

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            //Reset_Role();

            //$("#dvAccessFunction").html("");

            //Get_Roles();

            Friendly_Messages(obj);

        }
    });


}