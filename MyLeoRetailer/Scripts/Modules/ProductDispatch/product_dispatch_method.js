function AddProductDispatch() {
    if ($("#txtBalance_Quantitya").val() > 0 && $("#txtDispatch_Date").val() != "" && $("#txtDispatch_Quantity").val() != "") {
        var tblHtml = '';

        var myTable = $("#tblProduct_Dispatch tbody");

        tblHtml += "<tr class='item-data-row'>";

        tblHtml += "<td>";
        tblHtml += "<label >" + $("#txtSKU").val() + "</label>";
        tblHtml += "</td>";

        tblHtml += "<td>";
        tblHtml += "<label >" + $("#txtDispatch_Quantity").val() + "</label>";
        tblHtml += "<input type='hidden' class='form-control input-sm quantity' name='List_product_Dispatch[0].Quantity' value='" + $("#txtDispatch_Quantity").val() + "' id=textQuantitya_0'>";
        tblHtml += "</td>";

        tblHtml += "<td>";
        tblHtml += "<label >" + $("#txtDispatch_Date").val() + "</label>";
        tblHtml += "<input type='hidden' class='form-control input-sm' name='List_product_Dispatch[0].Dispatch_Date' value='" + $("#txtDispatch_Date").val() + "' id=textDispatch_Date_0'>";
        tblHtml += "</td>";

        tblHtml += "<td>";
        tblHtml += "<a class='btn btn-danger active' role='button' id='btnDispatch'  onclick='DeleteProduct_Dispatch(this)'>Delete</a>";
        tblHtml += "</td>";

        tblHtml += "</tr>";

        var newRow = $(tblHtml);

        myTable.append(newRow);

        $("#txtBalance_Quantitya").val($("#txtBalance_Quantitya").val() - $("#txtDispatch_Quantity").val());

        $("#txtDispatch_Quantity").val("")

        ReArrange_Index();
    }

}

function DeleteProduct_Dispatch(elem) {
    var addBackQty = parseInt(elem.closest("tr").children[1].innerText);
    var Quantity = parseInt($("#txtBalance_Quantitya").val());
    $("#txtBalance_Quantitya").val(Quantity + addBackQty)
    elem.closest("tr").remove();
    ReArrange_Index();
}

function Delete_Dispatch_Product(elem) {

    var r = confirm("Do you want to Delete the Record permanently!");
    if (r == true) {
    var DeleteProduct = elem.closest("tr").children[0].firstElementChild.value;

    var addBackQty = parseInt(elem.closest("tr").children[1].innerText);

    Delect_Dispatched_Product(DeleteProduct, addBackQty);

    $(elem).closest("tr").remove();
    }
}

function ReArrange_Index() {
    if ($("#frmProductDispatch").find("[id^='textQuantitya_']").length > 0) {
        var qtyLength = $("#frmProductDispatch").find("[id^='textQuantitya_']").length;

        for (var i = 0; i < qtyLength; i++) {
            $("#frmProductDispatch").find("[id^='textQuantitya_']")[i].id = "textQuantitya_" + i;
            $("#frmProductDispatch").find("[id^='textQuantitya_" + i + "']").attr("name", "List_product_Dispatch[" + i + "].Quantity");
        }

    }

    if ($("#frmProductDispatch").find("[id^='textDispatch_Date_']").length > 0) {
        var dateLength = $("#frmProductDispatch").find("[id^='textDispatch_Date_']").length;

        for (var i = 0; i < qtyLength; i++) {
            $("#frmProductDispatch").find("[id^='textDispatch_Date_']")[i].id = "textDispatch_Date_" + i;
            $("#frmProductDispatch").find("[id^='textDispatch_Date_" + i + "']").attr("name", "List_product_Dispatch[" + i + "].Dispatch_Date");
        }

    }

}

function Delect_Dispatched_Product(DeleteProduct, addBackQty) {

   
    var Quantity = parseInt($("#txtBalance_Quantitya").val());

    $("#txtBalance_Quantitya").val(Quantity + addBackQty);

    var pViewModel =
		{
		    product_Dispatch: {

		        Dispatch_Item_Id: DeleteProduct,

		        Balance_Quantitya: addBackQty,

		        Request_Id: $("[id='hdn_request_Id']").val(),

		        SKU: $("[id='txtSKU']").val(),

		        Quantity: $("[id='hdn_Quantity']").val(),
		    }
		}

    $.ajax({

        url: "/ProductDispatch/Delete_Dispatch_Product",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
        }
    });
}