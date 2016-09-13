

function Get_Customers()
{
	var cViewModel =
		{
			Filter: {

			    Customer_Name: $("[name='Filter.Customer_Name']").val(),

			    Customer_Mobile1: $("[name='Filter.Customer_Mobile1']").val()
			},
			Grid_Detail: {

				Pager: Set_Pager($("#divCustomerPager"))
			}
		}

	$.ajax({

	    url: "/Customer/Get_Customers",

		data: JSON.stringify(cViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{

			var obj = $.parseJSON(response);

			Bind_Grid(obj, "Customer_List");			

			$("#divCustomerPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
		}
	});
}




