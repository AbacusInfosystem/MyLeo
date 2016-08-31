

function Get_Colors()
{
	var cViewModel =
		{
			Filter: {

				Color: $("[name='Filter.Color']").val()
			},
			Grid_Detail: {

				Pager: Set_Pager($("#divColorPager"))
			}
		}

	$.ajax({

		url: "/Color/Get_Colors",

		data: JSON.stringify(cViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{ 
			var obj = $.parseJSON(response);

			Bind_Anchor_Grid(obj, "Color_List", $("#Color_Grid"));

			Reset_Color();

			$("#divColorPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
		}
	});
}

function Save_Color()
{
	var cViewModel =
		{
			Color: {

			    Colour: $("[name='Color.Colour']").val(),

			    Colour_Code: $("[name='Color.Colour_Code']").val(),

				Colour_Id: $("[name='Color.Colour_Id']").val()
			}
		}

	var url = "";

	if ($("[name='Color.Colour_Id']").val() == "")
	{
		url = "/Color/Insert_Color";
	}
	else
	{
		url = "/Color/Update_Color";
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

			Reset_Color(); 

			Get_Colors();

			Friendly_Messages(obj);
			
		}
	});


}

function Reset_Color()
{
    $("[name='Color.Colour']").val("");

    $("[name='Color.Colour_Code']").val("");

	$("[name='Color.Colour_Id']").val(""); 
}

function Get_Color_By_Id(obj)
{
	$("[name='Color_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='Color.Colour']").val($(obj).text()); 

	$("[name='Color.Colour_Id']").val($(obj).attr("data-identity"));

	var Color_Id = $("[name='Color.Colour_Id']").val();

	$.ajax({  
        
	    url: "/Color/Get_Colors_By_Id",

	    data: { Color_Id: Color_Id },  

	    type: 'POST', 

	    success: function (response) {

	        var obj = $.parseJSON(response);

	        $("[name='Color.Colour_Code']").val(obj.Color.Colour_Code);

	        document.getElementById('iRGBColor').style.backgroundColor = obj.Color.Colour_Code; //"rgb(" + randR + ", " + randG + ", " + randB + ")";

	        if (obj.Color.IsActive == true) {
	            $("[name='Color.IsActive']")[0].checked = true;
	            $("[name='Color.IsActive']").val(true);
	        }
	        else {
	            $("[name='Color.IsActive']")[0].checked = false;
	            $("[name='Color.IsActive']").val(false);
	        }
	    }
	});

} 
 



