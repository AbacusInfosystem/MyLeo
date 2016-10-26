function Get_Vendor_Tax_Details_By_Id(value) {

    $('#tblPurchaseReturnItems tbody tr').remove();

    AddPurchaseReturnDetails();

    $.ajax({

        url: "/PurchaseReturn/Get_Vendor_Details_By_Id",

        data: { Vendor_Id: value },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#hdf_hdn_Tax_Percentage').val(data.Tax_Percentage);

            $('#textTaxPercentage_0').val(data.Tax_Percentage);

            $("#drpPurchase_Invoice_Id").html("");

            $("#drpPurchase_Invoice_Id").append("<option value=''>Select Invoice No.</option>");

            $("#drpPurchase_Invoice_Id").parents('.form-group').find('ul').html("");

            $("#drpPurchase_Invoice_Id").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Invoice No.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");
            
            if (data.PurchaseInvoices.length > 0) {

                //$("#drpPurchase_Invoice_Id").empty();

                for (var j = 0; j < data.PurchaseInvoices.length; j++) {


                    var i = j + 1;

                    $("#drpPurchase_Invoice_Id").append("<option value='" + data.PurchaseInvoices[j].Purchase_Invoice_Id + "'>" + data.PurchaseInvoices[j].Purchase_Invoice_No + "</option>");

                    $("#drpPurchase_Invoice_Id").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + data.PurchaseInvoices[j].Purchase_Invoice_No + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");
                }
            }

        }
    });
}

function Get_Purchase_Return_Items_By_SKU_Code(i) {

    

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

            Get_Purchase_Return_PO_By_POI(i);

        }
       
    });

    CalculateTotal();

    
}

function Get_Purchase_Return_PO_By_POI(i) {

    

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

function Set_Purchase_Invoice_Id(value) {

    $('#hdf_Purchase_Invoice_Id').val(value);
}


function AddPurchaseReturnDetails() {

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseReturnItems");

    var temptablecount = $("#tblPurchaseReturnItems").find('[id^="PurchaseReturnItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='PurchaseReturnItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Item_Ids' id='hdnItem_Ids_" + i + "'' />";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Barcode' value='' id='textBarcode_No_" + i + "'>";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control input-sm' onchange='javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ");' name='PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code' value='' id='textSKU_No_" + i + "'>";
    //tblHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Purchase_Order_Id' id='hdnPurchase_Order_Id_" + i + "' />"
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' id='textSKU_No_" + i + "' placeholder='Enter SKU to search' value='' data-table='Purchase_Invoice_Item' data-col='Quantity,SKU_Code' data-headernames='SKU Code' data-param='hdf_Purchase_Invoice_Id' data-field='Purchase_Invoice_Id' />";
    tblHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnQuantity_" + i + "' value='' class='auto-complete-value'/>"; 
    tblHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='' name='PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code' class='auto-complete-label' onchange='javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ");'/>";
    tblHtml += "</div>";
    tblHtml += "<input type='hidden' id='hdnPurchase_Order_Id_" + i + "' value='' name='PurchaseReturn.PurchaseReturns[" + i + "].Purchase_Order_Id' />";
    tblHtml += "</div>";

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
    tblHtml += "<input type='text' class='form-control input-sm validate' name='PurchaseReturn.PurchaseReturns[" + i + "].Quantity' value='1'  onblur='Add_Validation(" + i + "); CalculateTotal()' id='textQuantity_" + i + "'>";
    //tblHtml += "<input class='form-control input-sm' type='hidden' name='' id='hdnQuantity_" + i + "' value='' /> ";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].WSR_Price' readonly value='0' id='textWSR_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Amount' readonly value='0' id='textAmount_" + i + "'>";
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

    Add_Validation(i);
    
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
    
    //Added by vinod mane on 12/10/2016
    if (fracPart >= 0.50) {
        netAmt_temp += 1;
    }
    //End
    
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

    CalculateTax();

}

function CalculateTotal() {

    

    var sumQuantity = 0;
    var sumWSRAmount = 0;

    var tr = $("#tblPurchaseReturnItems").find('[id^="PurchaseReturnItemRow_"]');


    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {
            if ($('[id="textQuantity_' + i + '"]').val() != 0 && $('[id="textQuantity_' + i + '"]').val() != '') {

                var Qty = parseFloat($("#tblPurchaseReturnItems").find('[id="textQuantity_' + i + '"]').val());
            var WSR = parseFloat($("#tblPurchaseReturnItems").find('[id="textWSR_Price_' + i + '"]').val());
            var Amount = parseFloat(WSR * Qty);
            $("#tblPurchaseReturnItems").find('[id="textAmount_' + i + '"]').val(Amount);

            sumQuantity = sumQuantity + Qty;
            sumWSRAmount = sumWSRAmount + Amount;
            }
        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textTotalAmount_0").val(sumWSRAmount.toFixed(2));

    CalculateDiscount();
}

function Add_Validation(i) {

    $("#tblPurchaseReturnItems").find(".validate").rules("add", { QuantityCheck: false });

    $("#textQuantity_" + i).rules("add", { required: true, QuantityCheck: true, digits: true, messages: { required: "Required field", digits: "Invalid quantity." } });

    $("#hdnSKU_No_" + i).rules("add", { required: true, checkSKUExist: true, messages: { required: "Required field", } });

    jQuery.validator.addMethod("QuantityCheck", function (value, element) {

        debugger;

        var result = true;
        var EnterQty = parseInt($('[id="textQuantity_' + i + '"]').val());
        var OrgQty = parseInt($("#hdnQuantity_" + i).val());

        if (isNaN($("#hdnQuantity_" + i).val()) || $("#hdnQuantity_" + i).val() == "") {
            result = true;
        }
        else {

            if (EnterQty != "" || $('[id="textQuantity_' + i + '"]').val() != '0') {

                if (OrgQty >= EnterQty) {

                    result = true;
                }
                else {
                    result = false;
                }

            }
            else {
                result = false;
            }
        }
        return result;


    }, "Quantity less than Invoice Quantity And Not Zero.");

}

function DeletePurchaseReturnDetailsData(i) {

    

    $("#tblPurchaseReturnItems").find("[id='PurchaseReturnItemRow_" + i + "']").remove();

    ReArrangePurchaseReturnDetailsData();

    var temptablecount = $("#tblPurchaseReturnItems").find('[id^="PurchaseReturnItemRow_"]').size();

    x = temptablecount;       

    if (x == 0) {
        AddPurchaseReturnDetails();
    }
    

    CalculateTotal();

    CalculateDiscount();

    CalculateTax();

}

function ReArrangePurchaseReturnDetailsData() {

    

    $("#tblPurchaseReturnItems").find("[id^='PurchaseReturnItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseReturnItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Barcode");
                $(newTR).find("[id^='hdnItem_Ids_']")[0].id = "hdnItem_Ids_" + i;
                $(newTR).find("[id^='hdnItem_Ids_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Item_Ids");
            }

            //if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
            //    $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
            //    $(newTR).find("[id^='textSKU_No_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code");
            //    $(newTR).find("[id^='textSKU_No_']").attr("onchange", "javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ")");
            //    $(newTR).find("[id^='hdnPurchase_Order_Id_']")[0].id = "hdnPurchase_Order_Id_" + i;
            //    $(newTR).find("[id^='hdnPurchase_Order_Id_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].Purchase_Order_Id");
            //}

            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='hdnQuantity_']")[0].id = "hdnQuantity_" + i;
                $(newTR).find("[id^='hdnSKU_No_']")[0].id = "hdnSKU_No_" + i;
                $(newTR).find("[id^='hdnSKU_No_']").attr("name", "PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code");
                $(newTR).find("[id^='hdnSKU_No_']").attr("onchange", "javascript: Get_Purchase_Return_Items_By_SKU_Code(" + i + ")");
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
                $(newTR).find("[id^='textQuantity_']").attr("onblur", "Add_Validation(" + i + ");");
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


function Get_Purchase_Return_Items()
{
    var vendor = $("[name='PurchaseReturn.Vendor_Id']").val();

    var pInvoice = $("[name='PurchaseReturn.Purchase_Invoice_Id']").val();

    $.ajax({

        url: "/PurchaseReturn/Get_Purchase_Return_Items_By_Vendor_And_PO",

        data: { Vendor_Id: vendor, Purchase_Invoice_Id: pInvoice },

        method: 'POST',

        async: false,

        success: function (data) {

            Bind_Purchase_Return_Items_Data(data);

        }
    });

    
}

function Bind_Purchase_Return_Items_Data(data)
{
    var trHtml = "";

    if (data.PurchaseReturns.length > 0)
    {
        //$("#tblPurchaseReturnItems").find("[id='PurchaseReturnItemRow_" + i + "']").remove();
        $('#tblPurchaseReturnItems tbody tr').remove();
       
        for (i = 0; i < data.PurchaseReturns.length; i++) {

            trHtml += "<tr id='PurchaseReturnItemRow_" + i + "' class='item-data-row'>";

            trHtml += "<td>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Item_Ids' value='" + data.PurchaseReturns[i].Item_Ids + "' id='hdnItem_Ids_" + i + "'' />";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Barcode' value='' id=textBarcode_No_" + i + "'>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<div class='form-group auto-complete'>";
            trHtml += "<div class='input-group'>";
            trHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' id='textSKU_No_" + i + "' placeholder='Enter SKU to search' value='" + data.PurchaseReturns[i].SKU_Code + "' data-table='Purchase_Invoice_Item' data-col='Purchase_Order_Id,SKU_Code' data-headernames='SKU Code' data-param='hdf_Purchase_Invoice_Id' data-field='Purchase_Invoice_Id' />";
            trHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
            trHtml += "<input type='hidden' id='hdnQuantity_" + i + "' value='" + data.PurchaseReturns[i].Quantity + "' class='auto-complete-value'/>";
            trHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='" + data.PurchaseReturns[i].SKU_Code + "' name='PurchaseReturn.PurchaseReturns[" + i + "].SKU_Code' class='auto-complete-label' onchange='javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ");' />";
            trHtml += "</div>";
            trHtml += "<input type='hidden' id='hdnPurchase_Order_Id_" + i + "' value='" + data.PurchaseReturns[i].Purchase_Order_Id + "' name='PurchaseReturn.PurchaseReturns[" + i + "].Purchase_Order_Id' />";
            trHtml += "</div>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Article_No' readonly value='" + data.PurchaseReturns[i].Article_No + "' id='textArticle_No_" + i + "'>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Color' readonly value='" + data.PurchaseReturns[i].Color + "' id='textColor_" + i + "'>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Color_Id' id='hdnColor_Id_" + i + "' value='" + data.PurchaseReturns[i].Color_Id + "'/>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Brand' readonly value='" + data.PurchaseReturns[i].Brand + "' id='textBrand_" + i + "'>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' value='" + data.PurchaseReturns[i].Brand_Id + "' />";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Category' readonly value='" + data.PurchaseReturns[i].Category + "' id='textCategory_" + i + "'>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' value='" + data.PurchaseReturns[i].Category_Id + "'/>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].SubCategory' readonly value='" + data.PurchaseReturns[i].SubCategory + "' id='textSub_Category_" + i + "'>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' value='" + data.PurchaseReturns[i].SubCategory_Id + "'/>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Group_Name' readonly value='" + data.PurchaseReturns[i].Size_Group_Name + "' id='textSize_Group_Name_" + i + "'>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' value='" + data.PurchaseReturns[i].Size_Group_Id + "'/>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Name' readonly value='" + data.PurchaseReturns[i].Size_Name + "' id='textSize_Name_" + i + "'>";
            trHtml += "<input type='hidden' name='PurchaseReturn.PurchaseReturns[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' value='" + data.PurchaseReturns[i].Size_Id + "'/>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm validate' name='PurchaseReturn.PurchaseReturns[" + i + "].Quantity' value='" + data.PurchaseReturns[i].Quantity + "' onblur='Add_Validation(" + i + "); CalculateTotal()' id='textQuantity_" + i + "'>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].WSR_Price' readonly value='" + data.PurchaseReturns[i].WSR_Price + "' id='textWSR_Price_" + i + "'>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturn.PurchaseReturns[" + i + "].Amount' readonly value='" + data.PurchaseReturns[i].Amount + "' id='textAmount_" + i + "'>";
            trHtml += "</td>";

            trHtml += "<td>";
            trHtml += "<div class='btn-group'>";
            trHtml += "<button type='button' id='addrow-Return-details' class='btn btn-success active' onclick='javascript: AddPurchaseReturnDetails();'>Add Row</button>";
            trHtml += "<button type='button' id='delete-Return-details' class='btn btn-danger active' onclick='javascript:DeletePurchaseReturnDetailsData(" + i + ");'>Delete</button>";
            trHtml += "</div>";
            trHtml += "</td>";

            trHtml += "</tr>";

        }

        $('#tblPurchaseReturnItems tbody').append(trHtml);

        for (i = 0; i < data.PurchaseReturns.length; i++) {
            Get_Purchase_Return_PO_By_POI(i);
        }
        CalculateTotal();

        var x = $("#tblPurchaseReturnItems").find('[id^="PurchaseReturnItemRow_"]').size();

        if (parseInt(x) == 0) {
            
            Add_Validation(0);

        }
        
    }
}