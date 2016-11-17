

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

           // Reset_Payable();

            $("#divPayablePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);

        }
    });
}
//commented by vinod mane on 26/10/2016

//function Reset_Payable() {

//    $("[name='Payable.From_Date']").val("");

//    $("[name='Payable.To_Date']").val("");

//    $("[name='Payable.Vendor_Name']").val("");

//    $("[name='Payable.Payament_Status']").val("");

//    document.getElementById("btnPay").disabled = true;
//    $("#lookupUlLookup").val("");
   

//    Get_Payable();
//}

//End