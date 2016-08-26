

function Get_Categories()
{
	var cViewModel =
		{
			Filter: {

				Category: $("[name='Filter.Category']").val()
			},
			Grid_Detail: {

				Pager: Set_Pager($("#divCategoryPager"))
			}
		}

	$.ajax({

		url: "/Category/Get_Catgories",

		data: JSON.stringify(cViewModel),// data we are sending to server

		dataType: 'json',  //WHAT WE ARE EXPECTING

		type: 'POST',

		contentType: 'application/json', //WHAT WE ARE SENDING

		success: function (response)
		{

			var obj = $.parseJSON(response);

			Bind_Anchor_Grid(obj, "Category_List", $("#Category_Grid"));

			Reset_Category();

			$("#divCategoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
		}
	});
}

function Save_Category()
{
	var cViewModel =
		{
			Category: {

				Category: $("[name='Category.Category']").val(),

				Category_Id: $("[name='Category.Category_Id']").val()
			}
		}

	var url = "";

	if ($("[name='Category.Category_Id']").val() == "")
	{
		url = "/Category/Insert_Category";
	}
	else
	{
		url = "/Category/Update_Category";
	}

	$.ajax({

		url: url,

		data: JSON.stringify(cViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{
			var obj = $.parseJSON(response);

			Reset_Category();

			$("#dvSubCategory").html("");

			Get_Categories();

			Friendly_Messages(obj);
			
		}
	});


}

function Reset_Category()
{
	$("[name='Category.Category']").val("");

	$("[name='Category.Category_Id']").val("");

	$("#dvSubCategory").html("");
}

function Get_Category_By_Id(obj)
{
	$("[name='Category_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='Category.Category']").val($(obj).text());

	$("[name='Category.Category_Id']").val($(obj).attr("data-identity"));
}

function Get_SubCategories(obj)
{
	$("#dvSubCategory").load("/Category/Get_Sub_Category_By_Category_Id", { catgeory_Id: $(obj).attr("data-identity"), category: $(obj).text() });
}







