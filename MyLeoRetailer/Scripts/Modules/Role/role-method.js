//sdfsdfds
function Save_Role() {
    var activeFlg = false;
  
    if ($("[name='role.Is_Active']").val() == 1 || $("[name='role.Is_Active']").val() == "true") {
        activeFlg = true;
    }

    var rViewModel =
		{
		    role: {

		        Role_Name: $("[name='role.Role_Name']").val(),

		        Is_Active: activeFlg,

		        Role_Id: $("[name='role.Role_Id']").val(),
		    },
		    accessFunctions: Get_Value_Of_Access_Functions(),
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

            Reset_Role();

            Get_Roles();

            Get_RoleAccess_Functions(0);

            Friendly_Messages(obj);

        }
    });


}

function Get_Roles() {
    var rViewModel =
		{
		    Filter: {

		        Role: $("[name='Filter.Role']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divRolePager"))
		    }
		}

    $.ajax({

        url: "/role/get-roles",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Bind_Anchor_Grid(obj, "Role_List", $("#Role_Grid"));

            Reset_Role();

            $("#divRolePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Reset_Role() {
    $("[name='role.Role_Name']").val("");
    $("#hdnRole_Name").val("");

    $("[name='role.Role_Id']").val("");

    $("[name='role.Is_Active']")[0].checked = true;
    $("[name='role.Is_Active']").val(true);

    $("[name='Filter.Role']").val("");

    $("#spnRoleName").text("");
    Get_RoleAccess_Functions(0);

}

function Get_Role_By_Id(obj) {
    $("[name='Role_List']").removeClass("active");

    $(obj).addClass("active");

    //$("[name='role.Role_Name']").val($(obj).text());
    //$("#hdnRole_Name").val($(obj).text());

    //$("[name='role.Role_Id']").val($(obj).attr("data-identity"));

    //$("#spnRoleName").text($(obj).text());

    //var Role_Id = $("[name='role.Role_Id']").val();

    var Role_Id = $(obj).attr("data-identity");
    
    $.ajax({

        url: "/role/get-role-by-id",

        data: { role_Id: Role_Id },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            if (obj.role.Is_Active == true) {
                $("[name='role.Is_Active']")[0].checked = true;
                $("[name='role.Is_Active']").val(1);
            }
            else {
                $("[name='role.Is_Active']")[0].checked = false;
                $("[name='role.Is_Active']").val(0);
            }

            $("[name='role.Role_Name']").val(obj.role.Role_Name);
            $("#hdnRole_Name").val(obj.role.Role_Name);

            $("[name='role.Role_Id']").val(obj.role.Role_Id);

            $("#spnRoleName").text(obj.role.Role_Name);
            
            Get_RoleAccess_Functions(obj.role.Role_Id);
            
            Friendly_Messages(obj);

        }
    });

}

function Get_RoleAccess_Functions(Role_Id)
{

    $.ajax({

        url: "/role/get-role-access-functions",

        data: { role_Id: parseInt(Role_Id) },

        type: 'POST',

        success: function (obj) {

            $('#tblAccessFunction tbody').html("");
            var htmlText = "";

            var response = $.parseJSON(obj);

            if (response.accessFunctions.length > 0) {
                
                for (i = 0; i < response.accessFunctions.length; i++) {

                    htmlText += "<tr class='access-function'>";

                    htmlText += "<td>";

                    htmlText += response.accessFunctions[i].Access_Function_Name;

                    htmlText += "<input type='hidden' id='hdnAccess_Function_Id_" + i + "' value='" + response.accessFunctions[i].Access_Function_Id + "' />";
                    
                    htmlText += "<input type='hidden' id='hdnId_" + i + "' value='" + response.accessFunctions[i].Id + "' />";

                    htmlText += "</td>";
                    
                    htmlText += "<td>";
                    
                    htmlText += "<label class='switch'>";

                    if (response.accessFunctions[i].Is_Access == true){
                        htmlText += "<input type='checkbox' checked id='chkIs_Access_" + i + "' value='1' class='screen-access' />";
                    }
                    else {
                        htmlText += "<input type='checkbox' id='chkIs_Access_" + i + "' value='0' class='screen-access' />";
                    }

                    htmlText += "<span></span>";

                    htmlText += "</label>";

                    htmlText += "</td>";
                    
                    htmlText += "<td>";

                    htmlText += "<label class='switch'>";

                    if (response.accessFunctions[i].Is_Create == true) {
                        htmlText += "<input type='checkbox' checked id='chkIs_Create_" + i + "' value='1' class='screen-create' />";
                    }
                    else {
                        htmlText += "<input type='checkbox' id='chkIs_Create_" + i + "' value='0' class='screen-create' />";
                    }
                   
                    htmlText += "<span></span>";

                    htmlText += "</label>";

                    htmlText += "</td>";
                  
                    htmlText += "<td>";

                    htmlText += "<label class='switch'>";

                    if (response.accessFunctions[i].Is_Edit == true) {
                        htmlText += "<input type='checkbox' checked id='chkIs_Edit_" + i + "' value='1' class='screen-edit' />";
                    }
                    else {
                        htmlText += "<input type='checkbox' id='chkIs_Edit_" + i + "' value='0' class='screen-edit' />";
                    }
                    
                    htmlText += "<span></span>";

                    htmlText += "</label>";

                    htmlText += "</td>";
                    
                    htmlText += "<td>";

                    htmlText += "<label class='switch'>";

                    if (response.accessFunctions[i].Is_View == true) {
                        htmlText += "<input type='checkbox' checked id='chkIs_View_" + i + "' value='1' class='screen-view' />";
                    }
                    else {
                        htmlText += "<input type='checkbox' id='chkIs_View_" + i + "' value='0' class='screen-view' />";
                    }
                    
                    htmlText += "<span></span>";

                    htmlText += "</label>";

                    htmlText += "</td>";
                   
                    htmlText += "</tr>";
                }
            }

            $('#tblAccessFunction tbody').append(htmlText);

            $('.screen-edit').each(function () {
                if ($(this).val() == 1) {
                    $(this).parents(".access-function").find(".screen-view").attr("disabled", "disabled");
                }
            });

            $('.screen-edit').change(function () {
                
                if ($(this).val() == 1) {
                //if ($(this).parent().prop("class").indexOf("checked") == -1) {

                    $(this).parents(".access-function").find(".screen-view").removeAttr('checked');
                    $(this).parents(".access-function").find(".screen-view").val(0);
                    $(this).parents(".access-function").find(".screen-view").removeAttr("disabled");
                }
                else {

                    $(this).parents(".access-function").find(".screen-view").propAttr('checked', 'checked');
                    $(this).parents(".access-function").find(".screen-view").val(1);
                    $(this).parents(".access-function").find(".screen-view").attr("disabled", "disabled");
                   
                }

            });


        }
    });

}


//$(".screen-edit").on("ifChanged", function () {

//    if ($(this).prop('checked')) {

//        $(this).parents(".access-function").find(".screen-view").removeAttr("disabled");
//    }
//    else {
       
//        $(this).parents(".tr-screen-group").find(".screen-view").attr("disabled", "disabled");
//    }

//});


function Get_Value_Of_Access_Functions() {
    var functionList = [];
    var i = 0;

    $('.access-function').each(function () {
        
        var Access = false;
        var Create = false;
        var Edit = false;
        var View = false;

        if ($(this).find("#chkIs_Access_" + i).val() == 1){
            Access = true;
        }
        if ($(this).find("#chkIs_Create_" + i).val() == 1) {
            Create = true;
        }
        if ($(this).find("#chkIs_Edit_" + i).val() == 1) {
            Edit = true;
        }
        if ($(this).find("#chkIs_View_" + i).val() == 1) {
            View = true;
        }
      
        functionList.push({
            Id: $(this).find("#hdnId_" + i).val(),
            Access_Function_Id: $(this).find("#hdnAccess_Function_Id_" + i).val(),

            Is_Access: Access,
            Is_Create: Create,
            Is_Edit: Edit,
            Is_View: View,

        });

        i++;
    });

    return functionList;
}