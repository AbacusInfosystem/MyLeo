function Get_Replacement() {
    var rViewmodel =
		{
		    Filter: {

		        Replacement_No: $("[name='Filter.Replacement_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divReplacementPager"))
		    }
		}

    $.ajax({

        url: "/Replacement/Get_Replacemant",

        data: JSON.stringify(rViewmodel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Replacement_List");

            $("#divReplacementPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}