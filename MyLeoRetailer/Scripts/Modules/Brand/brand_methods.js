﻿

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

			var fix = $("[name='Brand.IsActive']").val(1);

			if (fix == 0) {
			    document.getElementById('Flag').checked = false;
			}
			else {
			    document.getElementById('Flag').checked = true;
			}
		}
	});
}

function Save_Brand()
{
	var bViewModel =
		{
		    Brand: {

		        Brand_Name: $("[name='Brand.Brand_Name']").val(),

		        Brand_Code: $("[name='Brand.Brand_Code']").val(),

		        IsActive: $("[name='Brand.IsActive']").val(),

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
		    debugger;

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

    $("[name='Brand.Brand_Code']").val("");

    $("[name='Brand.Brand_Id']").val("");

    $("[name='Brand.IsActive']").val(1);

    $("#hdnBrand_Name").val("");
    $("[name='Brand_List']").removeClass("active");//Added by vinod mane on 25/10/2016

    document.getElementById('Flag').checked = false;

   
}

function Get_Brand_By_Id(obj)
{
    $("[name='Brand_List']").removeClass("active");

    $(obj).addClass("active");

    $("[name='Brand.Brand_Name']").val($(obj).text());

    $("[name='Brand.Brand_Id']").val($(obj).attr("data-identity"));

    var Brand_Id = $("[name='Brand.Brand_Id']").val();

    $.ajax({

        url: "/Brand/Get_Brand_By_Id",

        data: { Brand_Id: Brand_Id },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Brand.IsActive']").val(obj.Brand.IsActive);

            $("[name='Brand.Brand_Code']").val(obj.Brand.Brand_Code);
            $("[name='Brand.Brand_Name']").val(obj.Brand.Brand_Name);
            $("#hdnBrand_Name").val(obj.Brand.Brand_Name);

            //Set IsActive Button Status
            var fix = $("[name='Brand.IsActive']").val();

            if (fix == 0) {
                document.getElementById('Flag').checked = false;
            }
            else {
                document.getElementById('Flag').checked = true;
            }
            //End

        }
    });

}
