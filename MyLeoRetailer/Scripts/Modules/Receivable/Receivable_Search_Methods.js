function Get_Receivable() {

    var rViewModel =
        {
            Receivable: {

                From_Date: $("[name='Receivable.From_Date']").val(),

                To_Date: $("[name='Receivable.To_Date']").val(),

                Sales_Invoice_No: $("[name='Receivable.Sales_Invoice_No']").val(),

                Customer_Name: $("[name='Receivable.Customer_Name']").val(),

                Payment_Status: $("[name='Receivable.Payment_Status']").val()
            },

            Grid_Detail: {

                Pager: Set_Pager($("#divReceivablePager"))
            }
        }

    $.ajax({

        url: "/Receivable/Get_Receivable",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Receivable_List");

            $("#divReceivablePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);

        }
    });
}