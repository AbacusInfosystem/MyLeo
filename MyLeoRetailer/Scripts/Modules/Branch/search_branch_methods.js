
function Get_Branchs() {
    var bViewModel =
		{
		    Filter: {

		        Branch_Name: $("[name='Filter.Branch_Name']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divBranchPager"))
		    }
		}

    $.ajax({

        url: "/Branch/Get_Branchs",

        data: JSON.stringify(bViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Branch_List");

            $("#divBranchPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}


function Get_Branch_By_Id(obj) {
    $("[name='Branch_List']").removeClass("active");

    $(obj).addClass("active");

    $("[name='Branch.Branch_Name']").val($(obj).text());

    $("[name='Branch.Branch_Address']").val($(obj).text());

    $("[name='Branch.Branch_City']").val($(obj).text());

    $("[name='Branch.Branch_State']").val($(obj).text());

    $("[name='Branch.Branch_Country']").val($(obj).text());

    $("[name='Branch.Branch_Pincode']").val($(obj).text());

    $("[name='Branch.Branch_Landline1']").val($(obj).text());

    $("[name='Branch.Branch_Landline2']").val($(obj).text());

    $("[name='Branch.Is_Active']").val($(obj).text());

    $("[name='Branch.Branch_ID']").val($(obj).attr("data-identity"));

    $("#hdnBranch_ID").val($(obj).attr("data-identity"));
}
