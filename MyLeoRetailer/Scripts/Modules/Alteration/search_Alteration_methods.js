

function Get_Alterations() {
    var aViewModel =
		{
		    Filter: {

		        Customer_Mobile_No: $("[name='Filter.Customer_Mobile_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divAlterationPager"))
		    }
		}

    $.ajax({

        url: "/Alteration/Get_Alterations",

        data: JSON.stringify(aViewModel),// data we are sending to server

        dataType: 'json',  //WHAT WE ARE EXPECTING

        type: 'POST',

        contentType: 'application/json', //WHAT WE ARE SENDING

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Alteration_List");

            Reset_Alteration();

            $("#divAlterationPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Reset_Alteration()
{
    //$("[name='Filter.Customer_Mobile_No']").val("");

    //$("[name='Filter.Alteration_ID']").val("");

    document.getElementById("btnEditAlteration").disabled = true;
}

function Get_Alteration_By_Id(obj) {

    $("[name='Alteration_List']").removeClass("active");

    $(obj).addClass("active");

    $("[name='Alteration.Sales_Invoice_ID']").val($(obj).text());

    $("[name='Alteration.Product_Name']").val($(obj).text());

    $("[name='Alteration.Alteration_Date']").val($(obj).text());

    $("[name='Alteration.Delivery_Date']").val($(obj).text());

    $("[name='Alteration.Customer_Mobile_No']").val($(obj).text());

    $("[name='Alteration.Job_Assigned_To']").val($(obj).text());

    $("[name='Alteration.Additional_Info']").val($(obj).text());

    $("[name='Alteration.Alteration_ID']").val($(obj).attr("data-identity"));

    $("#hdnAlteration_ID").val($(obj).attr("data-identity"));
}