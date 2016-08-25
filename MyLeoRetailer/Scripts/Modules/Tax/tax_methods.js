﻿
function Get_Taxes() {
    var tViewModel =
		{
		    Filter: {

		        Tax_Name: $("[name='Filter.Tax_Name']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divTaxPager"))
		    }
		}

    $.ajax({

        url: "/Tax/Get_Taxes",

        data: JSON.stringify(tViewModel),// data we are sending to server

        dataType: 'json',  //WHAT WE ARE EXPECTING

        type: 'POST',

        contentType: 'application/json', //WHAT WE ARE SENDING

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Anchor_Grid(obj, "Tax_List", $("#Tax_Grid"));

            Reset_Tax();

            $("#divTaxPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Save_Tax() {
    var tViewModel =
		{
		    Tax: {

		        Tax_Name: $("[name='Tax.Tax_Name']").val(),

		        Tax_Value:$("[name='Tax.Tax_Value']").val(),

		        Tax_Id: $("[name='Tax.Tax_Id']").val()
		    }
		}

    var url = "";

    if ($("[name='Tax.Tax_Id']").val() == "") {
        url = "/Tax/Insert_Tax";
    }
    else {
        url = "/Tax/Update_Tax";
    }

    $.ajax({

        url: url,

        data: JSON.stringify(tViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Reset_Tax();

            Get_Taxes();

            Friendly_Messages(obj);

        }
    });


}

function Reset_Tax() {

    $("[name='Tax.Tax_name']").val("");

    $("[name='Tax.Tax_Value']").val("");

    $("[name='Tax.Tax_Id']").val("");

   
}

function Get_Tax_By_Id(obj) {
    $("[name='Tax_List']").removeClass("active");

    $(obj).addClass("active");

    $("[name='Tax.Tax_Name']").val($(obj).text());

    //$("[name='Color.Colour_Code']").val($(obj).text());

    $("[name='Tax.Tax_Id']").val($(obj).attr("data-identity"));

    var Tax_Id = $("[name='Tax.Tax_Id']").val();

    $.ajax({

        url: "/Tax/Get_Tax_By_Id",

        data: { Tax_Id: Tax_Id },//JSON.stringify({ Color_Id: $("[name='Color.Colour_Id']").val() }),

        //dataType: 'json',

        type: 'POST',

        //contentType: 'application/json',
        //contentType: 'application/json; charset=utf-8',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Tax.Tax_Value']").val(obj.Tax.Tax_Value);

            //document.getElementById('iRGBColor').style.backgroundColor = obj.Tax.Tax_Name; //"rgb(" + randR + ", " + randG + ", " + randB + ")";
        }
    });

}