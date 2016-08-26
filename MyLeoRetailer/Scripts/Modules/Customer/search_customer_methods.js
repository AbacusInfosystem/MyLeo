

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



function Get_Customer_By_Id(obj)
{
    $("[name='Customer_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='Customer.Customer_Name']").val($(obj).text());

	$("[name='Customer.Customer_Billing_Address']").val($(obj).text());

	$("[name='Customer.Customer_Billing_City']").val($(obj).text());

	$("[name='Customer.Customer_Billing_State']").val($(obj).text());

	$("[name='Customer.Customer_Billing_Country']").val($(obj).text());

	$("[name='Customer.Customer_Billing_Pincode']").val($(obj).text());

	$("[name='Customer.Customer_Mobile1']").val($(obj).text());

	$("[name='Customer.Customer_Mobile2']").val($(obj).text());

	$("[name='Customer.Customer_Landline1']").val($(obj).text());

	$("[name='Customer.Customer_Landline2']").val($(obj).text());

	$("[name='Customer.Customer_Gender']").val($(obj).text());

	$("[name='Customer.Customer_DOB']").val($(obj).text());

	$("[name='Customer.Customer_Child1_Name']").val($(obj).text());

	$("[name='Customer.Customer_Child2_Name']").val($(obj).text());

	$("[name='Customer.Customer_Child1_DOB']").val($(obj).text());

	$("[name='Customer.Customer_Child2_DOB']").val($(obj).text());

	$("[name='Customer.Customer_Wedding_Anniversary']").val($(obj).text());

	$("[name='Customer.Customer_Email1']").val($(obj).text());

	$("[name='Customer.Customer_Email2']").val($(obj).text());

	$("[name='Customer.Customer_Spouse_Name']").val($(obj).text());

	$("[name='Customer.Customer_Spouse_DOB']").val($(obj).text());

	$("[name='Customer.Is_Active']").val($(obj).text());


	$("[name='Customer.Customer_Id']").val($(obj).attr("data-identity"));

	$("#hdnCustomer_Id").val($(obj).attr("data-identity"));
}
