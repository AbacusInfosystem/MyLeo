

function Get_Sales_Summary_Report() {


    var siViewModel =
        {
            Filter: {

                From_Date: $("[name='Filter.From_Date']").val(),

                To_Date: $("[name='Filter.To_Date']").val(),

                Brand_Name: $("[name='Filter.Brand_Name']").val(),

                Category: $("[name='Filter.Category']").val(),

                SalesMan_Id: $("[name='Filter.SalesMan_Id']").val()


            },

            //Grid_Detail: {

            //    Pager: Set_Pager($("#divSalesReportPager"))
            //}
        }

    $.ajax({

        url: "/SalesOrder/Get_Sales_Summary_Report",

        data: JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_custom_Grid(obj, "Sales_Summary_List", "Summaries", "");

            //Bind_Grid(obj, "Sales_Summary_List");

            // Reset_Payable();

          // $("#divPayablePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);

        }
    });
}