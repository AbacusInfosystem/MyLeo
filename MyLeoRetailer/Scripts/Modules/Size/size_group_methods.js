function Get_SizeGroups() {

    var sgViewModel =
		{
		    Filter: {

		        Size_Group_Name: $("[name='Filter.Size_Group_Name']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divSizeGroupPager"))
		    }
		}

    $.ajax({

        url: "/Size/Get_SizeGroups",

        data: JSON.stringify(sgViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Anchor_Grid(obj, "Size_Group_List", $("#Size_Group_Name_Grid"));

            Reset_SizeGroup();

            $("#divSizeGroupPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            var fix = $("[name='SizeGroup.IsActive']").val(1);

            if (fix == "0") {
                document.getElementById('Flag').checked = false;
            }
            else {
                document.getElementById('Flag').checked = true;
            }
        }
    });
}

function Get_Sizes(Size_Group_Id) {

    var Size_Group_Id = Size_Group_Id;

    $.ajax({

        url: "/Size/Get_Sizes",

        //data: JSON.stringify(sgViewModel),

        data: { size_group_Id: Size_Group_Id },

        //dataType: 'json',

        type: 'POST',

        //contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);
       
            if (obj.SizeList.length > 0) {

            debugger;

                for (var i = 0; i < obj.SizeList.length; i++) {

                    $("#hdnSize" + (i + 1)).val(obj.SizeList[i].Size_Id);

                    $("#txtSize" + (i + 1)).val(obj.SizeList[i].Size_Name);

                }
            }
        }
    });

    
}

function Save_SizeGroup()
{

    var sgViewModel =
		{
		    SizeGroup: {

		        Size_Group_Name: $("[name='SizeGroup.Size_Group_Name']").val(),

		        Size_Group_Id: $("[name='SizeGroup.Size_Group_Id']").val(),

		        IsActive: $("[name='SizeGroup.IsActive']").val()
		    }
		}

    var url = "";
    
    if ($("[name='SizeGroup.Size_Group_Id']").val() == "") {
        
        url = "/Size/Insert_Size_Group";
    }
    else {
        url = "/Size/Update_Size_Group";
    }

    $.ajax({
        
        url: url,

        data: JSON.stringify(sgViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response)
        {
            var obj = $.parseJSON(response);

            Reset_SizeGroup();

            $("#divSize").hide();

            Get_SizeGroups();

            Friendly_Messages(obj);

        }
    });


}



function Save_Size() {
    
    var list = [];

    for (var i = 1; i < 16; i++)
    {

        if($("#txtSize" + i).val() != "")
        {
            var demo = {

                Size_Name: $("#txtSize" + i).val(),

                Size_Group_Id: $("#hdnSizeGroupID").val(),

                Size_Id: $("#hdnSize"+i).val()
            }

            list.push(demo);
        }

    }

    var sgViewModel = 
            {

                SizeList: list,
                SizeGroup: {

                    Size_Group_Id: $("[name='SizeGroup.Size_Group_Id']").val(),
                }
            }
        

    var url = "";

    if (list.length > 0) {
        if (list[0].Size_Id > 0) {
            url = "/Size/Update_Size";
        }
        else {
            url = "/Size/Insert_Size";
        }

        $.ajax({

            url: url,

            data: JSON.stringify(sgViewModel),

            dataType: 'json',

            type: 'POST',

            contentType: 'application/json',

            success: function (response) {

                var obj = $.parseJSON(response);

                Reset_SizeGroup();

                Get_SizeGroups();

                Friendly_Messages(obj);

            }
        });
    }
    
}


function Reset_SizeGroup() {

    $("[name='SizeGroup.Size_Group_Name']").val("");

    $("[name='SizeGroup.Size_Group_Id']").val("");
    $("#hdnSizeGroupName").val("");//Added By Vinod Mane on 27/09/2016
    $("#divSize").hide();
   


function Get_SizeGroup_By_Id(obj) {

    $("[name='Size_Group_List']").removeClass("active");

    $(obj).addClass("active");

    //var Size_Group_Name = $(obj).text();
    //$("[name='SizeGroup.Size_Group_Name']").val($(obj).text());

    var Size_Group_Id = $(obj).attr("data-identity");
    //$("[name='SizeGroup.Size_Group_Id']").val($(obj).attr("data-identity"));

    $('input[id*="txtSize"]').each(function () {
        $(this).val('');
    });

    $.ajax({
        
        url: "/Size/Get_SizeGroup_By_Id",

        data: { size_group_Id: Size_Group_Id },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='SizeGroup.IsActive']").val(obj.SizeGroup.IsActive);

            //Set IsActive Button Status

            var fix = $("[name='SizeGroup.IsActive']").val();

            if (fix == "0") {
                document.getElementById('Flag').checked = false;
            }
            else {
                document.getElementById('Flag').checked = true;
            }
            //End

            $("[name='SizeGroup.Size_Group_Name']").val(obj.SizeGroup.Size_Group_Name);
            $("#hdnSizeGroupName").val(obj.SizeGroup.Size_Group_Name);//Added By Vinod Mane on 27/09/2016

            $("[name='SizeGroup.Size_Group_Id']").val(obj.SizeGroup.Size_Group_Id);

            if (obj.SizeGroup.Size_Group_Id != 0)
            {
                $("#divSize").show();
            }
            
            Friendly_Messages(obj);

            Get_Sizes(obj.SizeGroup.Size_Group_Id); //added by aditya 
          
        }
    });
}






