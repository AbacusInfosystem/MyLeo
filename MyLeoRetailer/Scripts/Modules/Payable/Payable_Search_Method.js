﻿

function Get_Payable() {


    var pViewModel =
        {
            Payable: {

                From_Date: $("[name='Payable.From_Date']").val(),

                To_Date: $("[name='Payable.To_Date']").val(),

                Vendor_Name: $("[name='Payable.Vendor_Name']").val(),

                Payament_Status: $("[name='Payable.Payament_Status']").val()

               
            },

            Grid_Detail: {

                Pager: Set_Pager($("#divPayablePager"))
            }
        }

    $.ajax({

        url: "/Payable/Get_Payable",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Payable_List");

            $("#divPayablePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);

        }
    });
}