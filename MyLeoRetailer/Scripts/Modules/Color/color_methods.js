

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

		    //*************//
			$("[name='Color.IsActive']").val(1);

		    //Set IsActive Button Status
			var fix = $("[name='Color.IsActive']").val();

			if (fix == 0) {
			    document.getElementById('Flag').checked = false;
			}
			else {
			    document.getElementById('Flag').checked = true;
			}
		    //End
		    //*************//
		}
	});
}

function Save_Color()
{
	var cViewModel =
		{
			Color: {

			    Colour: $("[name='Color.Colour']").val(),

			    Color_Code: $("[name='Color.Color_Code']").val(),

			    Colour_Code: $("[name='Color.Colour_Code']").val(),

			    IsActive: $("[name='Color.IsActive']").val(),

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

    $("[name='Color.Color_Code']").val("");

    $("[name='Color.Colour_Code']").val("");

    $("[name='Color.Colour_Id']").val("");
    $("#hdnColour_Name").val("");

    var fix = $("[name='Color.IsActive']").val(1);

    if (fix == 0) {
        document.getElementById('Flag').checked = false;
    }
    else {
        document.getElementById('Flag').checked = true;
    }
    
    $("[name='Color_List']").removeClass("active");//Added by vinod mane on 24/10/2016

}

function Get_Color_By_Id(obj)
{
	$("[name='Color_List']").removeClass("active");

	$(obj).addClass("active");

	//$("[name='Color.Colour']").val($(obj).text()); 

	//$("[name='Color.Colour_Id']").val($(obj).attr("data-identity"));

    //var Color_Id = $("[name='Color.Colour_Id']").val();

	var Color_Id = $(obj).attr("data-identity");

	$.ajax({  
        
	    url: "/Color/Get_Colors_By_Id",

	    data: { Color_Id: Color_Id },  

	    type: 'POST', 

	    success: function (response) {

	        var obj = $.parseJSON(response);

	        $("[name='Color.Colour_Code']").val(obj.Color.Colour_Code);

	        $("[name='Color.Color_Code']").val(obj.Color.Color_Code);

	        document.getElementById('iRGBColor').style.backgroundColor = obj.Color.Colour_Code; //"rgb(" + randR + ", " + randG + ", " + randB + ")";

	        if (obj.Color.IsActive == 1) {
	            $("[name='Color.IsActive']")[0].checked = true;
	            $("[name='Color.IsActive']").val(1);
	        }
	        else {
	            $("[name='Color.IsActive']")[0].checked = false;
	            $("[name='Color.IsActive']").val(0);
	        }
	        
	        $("[name='Color.Colour']").val(obj.Color.Colour);
	        $("#hdnColour_Name").val(obj.Color.Colour);

	        $("[name='Color.Colour_Id']").val(obj.Color.Colour_Id);

	        Friendly_Messages(obj);

	    }
	});

}

function ResetForm() {
    $('#frmColor').each(function () {
        this.reset();
    });
}
 



