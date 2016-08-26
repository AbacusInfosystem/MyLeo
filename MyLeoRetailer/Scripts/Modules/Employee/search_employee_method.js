

function Get_Employees() {
    var eViewModel =
		{
		    Filter: {

		        Employee: $("[name='Filter.Employee']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divEmployeePager"))
		    }
		}

    $.ajax({

        url: "/Employee/Get_Employees",

        data: JSON.stringify(eViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Employee_List");

            //Reset_Employee();

            $("#divEmployeePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

