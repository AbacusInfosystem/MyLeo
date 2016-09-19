function Get_Vendor_Tax_Details_By_Id(value) {

    $.ajax({

        url: "/PurchaseReturn/Get_Vendor_Details_By_Id",

        data: { Vendor_Id: value },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#hdf_hdn_Tax_Percentage').val(data.Tax_Percentage);

            $('#textTaxPercentage_0').val(data.Tax_Percentage);

            debugger;

            if (data.PurchaseInvoices.length > 0) {

                for (var j = 0; j < data.PurchaseInvoices.length; j++) {

                    $("#drpPurchase_Invoice_Id").append("<option value='" + data.PurchaseInvoices[j].Purchase_Invoice_Id + "'>" + data.PurchaseInvoices[j].Purchase_Invoice_No + "</option>");

                    //$('#drpPurchase_Invoice_Id').append(new Option(data.PurchaseInvoices[j].Purchase_Invoice_No, data.PurchaseInvoices[j].Purchase_Invoice_Id));
                }                
            }
        }
    });
}

function Get_Purchase_Return_Items_By_SKU_Code(i) {

    debugger;

    $.ajax({

        url: "/PurchaseReturn/Get_Purchase_Return_Items_By_SKU_Code",

        data: { SKU_Code: $("[name='PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code']").val() },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textColor_' + i).val(data.Color);

            $('#hdnColor_Id_' + i).val(data.Color_Id);

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

    Get_Purchase_Return_PO_By_POI(i);
}

function Get_Purchase_Return_PO_By_POI(i) {

    debugger;

    var purchase_invoice = document.getElementById("drpPurchase_Invoice_Id");
    var purchase_invoice_id = purchase_invoice.options[purchase_invoice.selectedIndex].value;

    $.ajax({

        url: "/PurchaseReturn/Get_Purchase_Return_PO_By_POI",

        data: { Purchase_Invoice_Id: purchase_invoice_id, SKU_Code: $("[name='PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code']").val() },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#hdnPurchase_Order_Id_' + i).val(data.Purchase_Order_Id);          
        }
    });
}

function AddPurchaseReturnDetails(i) {

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseReturnItems");

    var temptablecount = $("#tblPurchaseReturnItems").find('[id^="PurchaseReturnItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='PurchaseReturnItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Barcode' value='' id=textBarcode_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' onchange='javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ");' name='PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code' value='' id='textSKU_No_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Purchase_Order_Id' id='hdnPurchase_Order_Id_" + i + "' />"
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Color' readonly value='' id='textColor_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Color_Id' id='hdnColor_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Group_Name' readonly value='' id='textSize_Group_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Quantity' value='1' onblur='javascript:CalculateTotal();' id='textQuantity_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].WSR_Price' readonly value='' id='textWSR_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Amount' readonly value='' id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='addrow-Return-details' class='btn btn-success active' onclick='javascript: AddPurchaseReturnDetails();'>Add Row</button>";
    tblHtml += "<button type='button' id='delete-Return-details' class='btn btn-danger active' onclick='javascript:DeletePurchaseReturnDetailsData(" + i + ");'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";

    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

}



function CalculateTax() {

    var netAmt = 0;

    var tax = parseFloat($("#textTaxPercentage_0").val());
    var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());

    var taxAmt = (tax == "" || tax == undefined) ? 0 : parseFloat((sumGrossAmount * tax) / 100);
    $("#tblPurchaseReturnItems").find("textTaxAmount_0").val(taxAmt);

    var netAmt_temp = taxAmt + sumGrossAmount;

    var roundedDecimal = netAmt_temp.toFixed(2);

    var intPart = Math.floor(roundedDecimal);

    var fracPart = parseFloat((roundedDecimal - intPart), 2);

    alert(fracPart);

    if (fracPart == "" || fracPart == null) {
        fracPart = 0.00
    }

    var roundOff = parseFloat(netAmt_temp.toString().split(".")[1]);

    var netAmt = netAmt_temp - fracPart;

    $("#textTaxAmount_0").val(taxAmt.toFixed(2));

    $("#textRoundOff_0").val(fracPart.toFixed(2));

    $("#textNETAmount_0").val(Math.round(netAmt));


}

function CalculateDiscount() {

    var netAmt = 0;

    var discount = parseFloat($("#textDiscountPercentage_0").val());
    var sumtotalAmount = parseFloat($("#textTotalAmount_0").val());

    var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((sumtotalAmount * discount) / 100);
    $("#textDiscountAmount_0").val(discountAmt);

    var grossAmt = sumtotalAmount - discountAmt;

    $("#textGrossAmount_0").val(grossAmt.toFixed(2));


}

function CalculateTotal() {

    debugger;

    var sumQuantity = 0;
    var sumWSRAmount = 0;

    var tr = $("#tblPurchaseReturnItems").find('[id^="PurchaseReturnItemRow_"]');


    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {
            var Qty = parseFloat($("#tblPurchaseReturnItems").find('[id="textQuantity_' + i + '"]').val());
            var WSR = parseFloat($("#tblPurchaseReturnItems").find('[id="textWSR_Price_' + i + '"]').val());
            var Amount = parseFloat(WSR * Qty);
            $("#tblPurchaseReturnItems").find('[id="textAmount_' + i + '"]').val(Amount);

            sumQuantity = sumQuantity + Qty;
            sumWSRAmount = sumWSRAmount + Amount;

        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textTotalAmount_0").val(sumWSRAmount.toFixed(2));

}



function DeletePurchaseReturnDetailsData(i) {

    debugger;

    $("#tblPurchaseReturnItems").find("[id='PurchaseReturnItemRow_" + i + "']").remove();

    ReArrangePurchaseReturnDetailsData();

    CalculateTotal();

    CalculateDiscount();

    CalculateTax();
}

function ReArrangePurchaseReturnDetailsData() {

    debugger;

    $("#tblPurchaseReturnItems").find("[id^='PurchaseReturnItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseReturnItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Barcode");
            }

            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='textSKU_No_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code");
                $(newTR).find("[id^='textSKU_No_']").attr("onchange", "javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ")");
                $(newTR).find("[id^='hdnPurchase_Order_Id_']")[0].id = "hdnPurchase_Order_Id_" + i;
                $(newTR).find("[id^='hdnPurchase_Order_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Purchase_Order_Id");
            }

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='hdnColor_Id_']").length > 0) {
                $(newTR).find("[id^='hdnColor_Id_']")[0].id = "hdnColor_Id_" + i;
                $(newTR).find("[id^='hdnColor_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Color_Id");
                $(newTR).find("[id^='textColor_']")[0].id = "textColor_" + i;
                $(newTR).find("[id^='textColor_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Color");
            }

            if ($(newTR).find("[id^='hdnBrand_Id_']").length > 0) {
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Brand_Id");
                $(newTR).find("[id^='textBrand_']")[0].id = "textBrand_" + i;
                $(newTR).find("[id^='textBrand_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Brand");
            }

            if ($(newTR).find("[id^='hdnCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Category_Id");
                $(newTR).find("[id^='textCategory_']")[0].id = "textCategory_" + i;
                $(newTR).find("[id^='textCategory_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Category");
            }

            if ($(newTR).find("[id^='hdnSubCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSubCategory_Id_']")[0].id = "hdnSubCategory_Id_" + i;
                $(newTR).find("[id^='hdnSubCategory_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].SubCategory_Id");
                $(newTR).find("[id^='textSub_Category_']")[0].id = "textSub_Category_" + i;
                $(newTR).find("[id^='textSub_Category_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].SubCategory");
            }

            if ($(newTR).find("[id^='hdnSize_Group_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Size_Group_Id");
                $(newTR).find("[id^='textSize_Group_Name_']")[0].id = "textSize_Group_Name_" + i;
                $(newTR).find("[id^='textSize_Group_Name_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Size_Group_Name");
            }

            if ($(newTR).find("[id^='hdnSize_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Id_']")[0].id = "hdnSize_Id_" + i;
                $(newTR).find("[id^='hdnSize_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Size_Id");
                $(newTR).find("[id^='textSize_Name_']")[0].id = "textSize_Name_" + i;
                $(newTR).find("[id^='textSize_Name_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Size_Name");
            }


            if ($(newTR).find("[id^='textQuantity_']").length > 0) {
                $(newTR).find("[id^='textQuantity_']")[0].id = "textQuantity_" + i;
                $(newTR).find("[id^='textQuantity_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Quantity");
            }

            if ($(newTR).find("[id^='textWSR_Price_']").length > 0) {
                $(newTR).find("[id^='textWSR_Price_']")[0].id = "textWSR_Price_" + i;
                $(newTR).find("[id^='textWSR_Price_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].WSR_Price");
            }


            if ($(newTR).find("[id^='textAmount_']").length > 0) {
                $(newTR).find("[id^='textAmount_']")[0].id = "textAmount_" + i;
                $(newTR).find("[id^='textAmount_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Amount");
            }
          
            if ($(newTR).find("[id='delete-Return-details']").length > 0) {
                $(newTR).find("[id='delete-Return-details']").attr("onclick", "DeletePurchaseReturnDetailsData(" + i + ")");
            }
        }
    });
}