function Get_Purchase_Invoice_Items_By_SKU_Code(i) {

    $.ajax({

        url: "/PurchaseInvoice/Get_Purchase_Invoice_Items_By_SKU_Code",

        data: { SKU_Code: $("[name='Replacements[" + i + "].SKU_Code']").val() },

        method: 'GET',

        async: false,

        success: function (data) {


            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textBrand_' + i).val(data.Brand);

            $('#hdnBrand_Id_' + i).val(data.Brand_Id);

            $('#textCategory_' + i).val(data.Category);

            $('#hdnCategory_Id_' + i).val(data.Category_Id);

            $('#textSub_Category_' + i).val(data.SubCategory);

            $('#hdnSubCategory_Id_' + i).val(data.SubCategory_Id);

            $('#textSize_Group_Name_' + i).val(data.Size_Group_Name);

            $('#hdnSize_Group_Id_' + i).val(data.Size_Group_Id);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#hdnSize_Id_' + i).val(data.Size_Id);

            $('#textWSR_Price_' + i).val(data.WSR_Price);

        }
    });

    CalculateTotal();
}

function AddPurchaseInvoiceDetails(i) {

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseInvoiceItems");

    var temptablecount = $("#tblPurchaseInvoiceItems").find('[id^="PurchaseInvoiceItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='PurchaseInvoiceItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:150px' name='Replacements[" + i + "].Barcode' value='' id=textBarcode_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:150px' onchange='javascript:Get_Purchase_Invoice_Items_By_SKU_Code(" + i + ");' name='Replacements[" + i + "].SKU_Code' value='' id='textSKU_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:70px' name='Replacements[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += " <input class='form-control input-sm' type='text' name='Replacements["+i+"].Color' id='textColor_"+i+"' readonly />";
    tblHtml += " <input type='hidden' name='Replacements["+i+"].Color_Id' id='hdnColor_Id_"+i+"' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:100px' name='Replacements[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='Replacements[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:100px' name='Replacements[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='Replacements[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:100px' name='Replacements[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='Replacements[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:100px' name='Replacements[" + i + "].Size_Group_Name' readonly value='' id='textSize_Group_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='Replacements[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' name='Replacements[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='Replacements[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' name='Replacements[" + i + "].Quantity' value='1' onblur='javascript:CalculateTotal();' id='textQuantity_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' name='Replacements[" + i + "].WSR_Price' readonly value='' id='textWSR_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' name='Replacements[" + i + "].Amount' readonly value='' id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<div class='form-group auto-complete'>";
    //tblHtml += "<div class='input-group'>";
    //tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' name='Replacements[" + i + "].Purchase_Order_Id' id='textInvoice_No_" + i + "' placeholder='Enter PO no. to search' value=''  data-table='Purchase_Order' data-col='Purchase_Order_Id,Purchase_Order_No' data-headernames='Purchase Order'>";
    //tblHtml += "<span class='input-group-addon'> <a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    //tblHtml += "<input type='hidden' id='hdnPurchase_Order_Id_" + i + "' value='' name='Replacements[" + i + "].Purchase_Order_Id' class='auto-complete-value'/>";
    //tblHtml += "<input type='hidden' id='hdnPurchase_Order_No_" + i + "' value='' name='Replacements[" + i + "].Purchase_Order_No' class='auto-complete-label' />";
    //tblHtml += "</div>";
    //tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<button type='button' id='delete-invoice-details' class='btn btn-danger active' onclick='javascript:DeletePurchaseInvoiceDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</td>";

    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

}

function CalculateTotal() {

    var sumQuantity = 0;
    var sumWSRAmount = 0;

    var tr = $("#tblPurchaseInvoiceItems").find('[id^="PurchaseInvoiceItemRow_"]');


    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {
            var Qty = parseFloat($("#tblPurchaseInvoiceItems").find('[id="textQuantity_' + i + '"]').val());
            var WSR = parseFloat($("#tblPurchaseInvoiceItems").find('[id="textWSR_Price_' + i + '"]').val());
            var Amount = parseFloat(WSR * Qty);
            $("#tblPurchaseInvoiceItems").find('[id="textAmount_' + i + '"]').val(Amount);

            sumQuantity = sumQuantity + Qty;
            sumWSRAmount = sumWSRAmount + Amount;

        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textTotalAmount_0").val(sumWSRAmount.toFixed(2));

}

function DeletePurchaseInvoiceDetailsData(i) {

    debugger;

    $("#tblPurchaseInvoiceItems").find("[id='PurchaseInvoiceItemRow_" + i + "']").remove();

    ReArrangePurchaseInvoiceDetailsData();

    CalculateTotal();

}

function ReArrangePurchaseInvoiceDetailsData() {
    $("#tblPurchaseInvoiceItems").find("[id^='PurchaseInvoiceItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseInvoiceItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "Replacements[" + i + "].Barcode");
            }

            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='textSKU_No_']").attr("name", "Replacements[" + i + "].SKU_Code");
                $(newTR).find("[id^='textSKU_No_']").attr("onchange", "javascript:Get_Purchase_Invoice_Items_By_SKU_Code(" + i + ")");
            }

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "Replacements[" + i + "].Article_No");
            }


            if ($(newTR).find("[id^='hdnColor_Id_']").length > 0) {
                $(newTR).find("[id^='hdnColor_Id_']")[0].id = "hdnColor_Id_" + i;
                $(newTR).find("[id^='hdnColor_Id_']").attr("name", "Replacements[" + i + "].Color_Id");
                $(newTR).find("[id^='textColor_']")[0].id = "textColor_" + i;
                $(newTR).find("[id^='textColor_']").attr("name", "Replacements[" + i + "].Color");
            }

            if ($(newTR).find("[id^='hdnBrand_Id_']").length > 0) {
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "Replacements[" + i + "].Brand_Id");
                $(newTR).find("[id^='textBrand_']")[0].id = "textBrand_" + i;
                $(newTR).find("[id^='textBrand_']").attr("name", "Replacements[" + i + "].Brand");
            }

            if ($(newTR).find("[id^='hdnCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "Replacements[" + i + "].Category_Id");
                $(newTR).find("[id^='textCategory_']")[0].id = "textCategory_" + i;
                $(newTR).find("[id^='textCategory_']").attr("name", "Replacements[" + i + "].Category");
            }

            if ($(newTR).find("[id^='hdnSubCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSubCategory_Id_']")[0].id = "hdnSubCategory_Id_" + i;
                $(newTR).find("[id^='hdnSubCategory_Id_']").attr("name", "Replacements[" + i + "].SubCategory_Id");
                $(newTR).find("[id^='textSub_Category_']")[0].id = "textSub_Category_" + i;
                $(newTR).find("[id^='textSub_Category_']").attr("name", "Replacements[" + i + "].SubCategory");
            }

            if ($(newTR).find("[id^='hdnSize_Group_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "Replacements[" + i + "].Size_Group_Id");
                $(newTR).find("[id^='textSize_Group_Name_']")[0].id = "textSize_Group_Name_" + i;
                $(newTR).find("[id^='textSize_Group_Name_']").attr("name", "Replacements[" + i + "].Size_Group_Name");
            }

            if ($(newTR).find("[id^='hdnSize_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Id_']")[0].id = "hdnSize_Id_" + i;
                $(newTR).find("[id^='hdnSize_Id_']").attr("name", "Replacements[" + i + "].Size_Id");
                $(newTR).find("[id^='textSize_Name_']")[0].id = "textSize_Name_" + i;
                $(newTR).find("[id^='textSize_Name_']").attr("name", "Replacements[" + i + "].Size_Name");
            }


            if ($(newTR).find("[id^='textQuantity_']").length > 0) {
                $(newTR).find("[id^='textQuantity_']")[0].id = "textQuantity_" + i;
                $(newTR).find("[id^='textQuantity_']").attr("name", "Replacements[" + i + "].Quantity");
                //$(newTR).find("[id^='textQuantity_']").attr("onchange", "javascript:textQuantity_(" + i + ")");
            }

            if ($(newTR).find("[id^='textWSR_Price_']").length > 0) {
                $(newTR).find("[id^='textWSR_Price_']")[0].id = "textWSR_Price_" + i;
                $(newTR).find("[id^='textWSR_Price_']").attr("name", "Replacements[" + i + "].WSR_Price");
            }


            if ($(newTR).find("[id^='textAmount_']").length > 0) {
                $(newTR).find("[id^='textAmount_']")[0].id = "textAmount_" + i;
                $(newTR).find("[id^='textAmount_']").attr("name", "Replacements[" + i + "].Amount");
            }

            //if ($(newTR).find("[id^='textPurchase_Order_Id_']").length > 0) {
            //    $(newTR).find("[id^='textPurchase_Order_Id_']")[0].id = "textAmount_" + i;
            //    $(newTR).find("[id^='textPurchase_Order_Id_']").attr("name", "Replacements[" + i + "].Purchase_Order_Id");
            //}

           

            if ($(newTR).find("[id='delete-invoice-details']").length > 0) {
                $(newTR).find("[id='delete-invoice-details']").attr("onclick", "DeletePurchaseInvoiceDetailsData(" + i + ")");
            }
        }
    });
}