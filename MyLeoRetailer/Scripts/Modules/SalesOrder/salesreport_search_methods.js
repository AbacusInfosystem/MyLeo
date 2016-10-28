function Get_Sales_Report() 
{
    var siViewModel =
       {
           Filter: {

               Branch_Id: $("[name='Filter.Branch_Id']").val(),

               From_Date: $("[name='Filter.From_Date']").val(),

               To_Date: $("[name='Filter.To_Date']").val()

           },
           Grid_Detail: {

               Pager: Set_Pager($("#divSalesReportPager"))
           }
       }

    $.ajax({

        url: "/SalesOrder/Get_Sales_Report",

        data: JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Filter.Branch_Id']").val(obj.Filter.Branch_Id);

            $("[name='Filter.From_Date']").val(obj.Filter.From_Date.substring(0, 10));

            $("[name='Filter.To_Date']").val(obj.Filter.To_Date.substring(0, 10));

            
            Bind_Grid(obj, "SalesOrder_List");


           Reset_SalesOrder();
            
        
            $("#divSalesReportPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });


}

function call_back(data) {

    $('#div_Parent_Modal_Fade').modal('show');
    $("#div_Parent_Modal_Fade").find(".modal-title").text("Sales Order Details");

    $('#frm input[type="radio":checked]').each(function () {
        $(this).checked = false;
    });
}


function Reset_SalesOrder() {

    //$("[name='Filter.Sales_Invoice_No']").val("");

    $("[name='Filter.Sales_Invoice_Id']").val("");

    document.getElementById('btnDetails').disabled = true;

}
