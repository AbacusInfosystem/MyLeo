

function Get_Brands()
{
	var bViewModel =
		{
			Filter: {

			    Brand_Name: $("[name='Filter.Brand_Name']").val()
			},
			Grid_Detail: {

				Pager: Set_Pager($("#divBrandPager"))
			}
		}

	$.ajax({

	    url: "/Brand/Get_Barnds",

		data: JSON.stringify(bViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{

			var obj = $.parseJSON(response);

			Bind_Anchor_Grid(obj, "Brand_List", $("#Brand_Grid"));

			Reset_Brand();

			$("#divBrandPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
		}
	});
}

function Save_Brand()
{
	var bViewModel =
		{
		    Brand: {

			    Brand_Name: $("[name='Brand.Brand_Name']").val(),

			    Brand_Id: $("[name='Brand.Brand_Id']").val()
			}
		}

	var url = "";

	if ($("[name='Brand.Brand_Id']").val() == "" || $("[name='Brand.Brand_Id']").val() == 0)
	{
	    url = "/Brand/Insert_Brand";
	}
	else
	{
	    url = "/Brand/Update_Brand";
	}

	$.ajax({

		url: url,

		data: JSON.stringify(bViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{
			var obj = $.parseJSON(response);

			Reset_Brand();

			Get_Brands();

			Friendly_Messages(obj);
			
		}
	});
    
}

function Reset_Brand()
{
    $("[name='Brand.Brand_Name']").val("");

    $("[name='Brand.Brand_Id']").val("");
}

function Get_Brand_By_Id(obj)
{
    $("[name='Brand_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='Brand.Brand_Name']").val($(obj).text());

	$("[name='Brand.Brand_Id']").val($(obj).attr("data-identity"));
}
