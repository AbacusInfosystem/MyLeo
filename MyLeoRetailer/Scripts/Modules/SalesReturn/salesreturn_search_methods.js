function Get_SalesReturns() {

    var srViewModel =
		{
		    Filter: {

		        Sales_Return_No: $("[name='Filter.Sales_Return_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divSalesReturnPager"))
		    }
		}

    $.ajax({

        url: "/SalesReturn/Get_SalesReturn",

        data: JSON.stringify(srViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "SalesReturn_List");

           // Reset_SalesReturn();

            $("#divSalesReturnPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Reset_SalesReturn()
{

    $("[name='Filter.Sales_Return_No']").val("");

    $("[name='Filter.Sales_Return_Id']").val("");

}