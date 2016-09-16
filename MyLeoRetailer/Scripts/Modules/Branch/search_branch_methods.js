
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

