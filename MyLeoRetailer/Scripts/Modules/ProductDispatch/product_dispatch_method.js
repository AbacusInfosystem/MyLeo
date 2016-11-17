function AddProductDispatch() {
    
    $("#txtDispatch_Quantity").val(parseInt($("#txtDispatch_Quantity").val()) + 1);

    $("#txtDispatch_Quantity").focus();
    $("#txtDispatch_Quantity").blur();

    if ($("#txtBalance_Quantitya").val() > 0 && $("#txtDispatch_Quantity").val() > 0) {

        if ($("#txtBalance_Quantitya").val() >= $("#txtDispatch_Quantity").val()) {
            $("#txtBalance_Quantitya").val($("#txtBalance_Quantitya").val() - $("#txtDispatch_Quantity").val());

            var currentdate = new Date();
            var datetime = (currentdate.getMonth() + 1) + "-"
                        + currentdate.getDate() + "-"
                        + currentdate.getFullYear();


            var tblHtml = '';

            var myTable = $("#tblProduct_Dispatch tbody");

            tblHtml += "<tr class='item-data-row'>";

            tblHtml += "<td>";
            tblHtml += "<label >" + $("#txtBarcode").val() + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm quantity' name='List_product_Dispatch[0].Barcode' value='" + $("#txtBarcode").val() + "' id=textBarcode_0'>";
            tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<label >" + $("#txtDispatch_Quantity").val() + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm quantity' name='List_product_Dispatch[0].Quantity' value='" + $("#txtDispatch_Quantity").val() + "' id=textQuantitya_0'>";
            tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<label >" + datetime + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm' name='List_product_Dispatch[0].Dispatch_Date' value='" + datetime + "' id=textDispatch_Date_0'>";
            tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<a class='btn btn-danger active' role='button' id='btnDispatch'  onclick='DeleteProduct_Dispatch(this)'>Delete</a>";
            tblHtml += "</td>";

            tblHtml += "</tr>";

            var newRow = $(tblHtml);

            myTable.append(newRow);

            $("#txtDispatch_Quantity").val(0);

            ReArrange_Index();

        }

    }
    else {

        $("#txtDispatch_Quantity").focus();
        $("#txtDispatch_Quantity").blur();

    }
    $("#txtDispatch_Quantity").val(0);
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

    if ($("#frmProductDispatch").find("[id^='textBarcode_']").length > 0) {
        var qtyLength = $("#frmProductDispatch").find("[id^='textBarcode_']").length;

        for (var i = 0; i < qtyLength; i++) {
            $("#frmProductDispatch").find("[id^='textBarcode_']")[i].id = "textBarcode_" + i;
            $("#frmProductDispatch").find("[id^='textBarcode_" + i + "']").attr("name", "List_product_Dispatch[" + i + "].Barcode");
        }

    }


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