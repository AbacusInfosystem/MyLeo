function Get_Vendor_Details_By_Id(value) {

    $('#tblPurchaseInvoiceItems tbody tr').remove();

    AddPurchaseInvoiceDetails();

    CalculateTotal();

    

    $.ajax({

        url: "/PurchaseInvoice/Get_Vendor_Details_By_Id",

        data: { Vendor_Id: value },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#hdf_Vendor_Id').val(data.Vendor_Id);

            $('#txtVendor_Address').val(data.Vendor_Address);

            $('#txtVendor_VAT_No').val(data.Vendor_Vat_No);

            $('#hdf_hdn_Tax_Percentage').val(data.Tax_Percentage);

            $('#textTaxPercentage_0').val(data.Tax_Percentage);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
        }
    });
}

function Get_Purchase_Invoice_Items_By_SKU_Code(i) {

    

    $.ajax({

        url: "/PurchaseInvoice/Get_Purchase_Invoice_Items_By_SKU_Code",

        data: { SKU_Code: $("[name='PurchaseInvoice.PurchaseInvoices[" + i + "].SKU_Code']").val() },

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

    CalculateTotal();
}

function AddPurchaseInvoiceDetails() {

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseInvoiceItems");

    var temptablecount = $("#tblPurchaseInvoiceItems").find('[id^="PurchaseInvoiceItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='PurchaseInvoiceItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Barcode' value='' id=textBarcode_No_" + i + "'>";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control input-sm' onchange='javascript:Get_Purchase_Invoice_Items_By_SKU_Code(" + i + ");' name='PurchaseInvoice.PurchaseInvoices[" + i + "].SKU_Code' value='' id='textSKU_No_" + i + "'>";
    //tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' id='textInvoice_No_" + i + "' placeholder='Enter PO no. to search' value=''  data-table='Purchase_Order' data-col='Purchase_Order_Id,Purchase_Order_No' data-headernames='Purchase Order' data-param='hdf_Vendor_Id' data-field='Vendor_Id' />";
    tblHtml += "<span class='input-group-addon'> <a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnPurchase_Order_Id_" + i + "' value='' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_Id' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnPurchase_Order_No_" + i + "' value='' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_No' class='auto-complete-label' />";
    tblHtml += "</div>";
    tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' id='textSKU_No_" + i + "' placeholder='Enter SKU Code to search' value=''  data-table='Product_SKU_Mapping' data-col='Purchase_Order_Id,SKU_Code' data-headernames='SKU Code' data-param='hdnPurchase_Order_Id_" + i + "' data-field='Purchase_Order_Id' />";
    tblHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnQuantity_" + i + "' value='' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='' name='PurchaseInvoice.PurchaseInvoices[" + i + "].SKU_Code' class='auto-complete-label' onchange='javascript:Get_Purchase_Invoice_Items_By_SKU_Code(" + i + ");' />";
    tblHtml += "</div>";
    tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Color' readonly value='' id='textColor_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Color_Id' id='hdnColor_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseInvoice.PurchaseInvoices[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Group_Name' readonly value='' id='textSize_Group_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm validate' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Quantity' value='1' onblur='Add_Validation(" + i + "); CalculateTotal()' id='textQuantity_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].WSR_Price' readonly value='0' id='textWSR_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseInvoice.PurchaseInvoices[" + i + "].Amount' readonly value='0' id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='addrow-Return-details' class='btn btn-success active' onclick='javascript: AddPurchaseInvoiceDetails();'>Add Row</button>";
    tblHtml += "<button type='button' id='delete-invoice-details' class='btn btn-danger active' onclick='javascript:DeletePurchaseInvoiceDetailsData(" + i + ")'>Delete</button>";
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
    $("#tblPurchaseInvoice").find("textTaxAmount_0").val(taxAmt);

    var netAmt_temp = taxAmt + sumGrossAmount;

    var roundedDecimal = netAmt_temp.toFixed(2);

    var intPart = Math.floor(roundedDecimal);

    var fracPart = parseFloat((roundedDecimal - intPart), 2);
    //Added by vinod mane on 12/10/2016
    if (fracPart >= 0.50) {
        netAmt_temp += 1;
    }
    //End
       
    if (fracPart == "" || fracPart == null)
    {
        fracPart=0.00
    }
   
    var roundOff = parseFloat(netAmt_temp.toString().split(".")[1]);

    var netAmt = netAmt_temp - fracPart;

    $("#textTaxAmount_0").val(taxAmt.toFixed(2));

    $("#textRoundOff_0").val(fracPart.toFixed(2));

    $("#textNETAmount_0").val(Math.round(netAmt));

}

function CalculateDiscount() {
  
    var netAmt = 0;

   // var discount = parseFloat($("#textDiscountPercentage_0").val());

    //Added by vinod mane on 12/10/2016
    var discount = $("#textDiscountPercentage_0").val();

    if (discount == "" || discount == "NaN") {
        discount = 0;
        $("#textDiscountPercentage_0").val(0);
    }
    //End

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

    var tr = $("#tblPurchaseInvoiceItems").find('[id^="PurchaseInvoiceItemRow_"]');


    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {

            if ($('[id="textQuantity_' + i + '"]').val() != 0 && $('[id="textQuantity_' + i + '"]').val() != '') {
                var Qty = parseFloat($("#tblPurchaseInvoiceItems").find('[id="textQuantity_' + i + '"]').val());
            var WSR = parseFloat($("#tblPurchaseInvoiceItems").find('[id="textWSR_Price_' + i + '"]').val());
            var Amount = parseFloat(WSR * Qty);
            $("#tblPurchaseInvoiceItems").find('[id="textAmount_' + i + '"]').val(Amount);

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

    //$("#tblPurchaseInvoiceItems").find(".validate").rules("add", { QuantityCheck: false });

    $("#textQuantity_" + i).rules("add", { required: true, QuantityCheck: true, digits: true, messages: { required: "Quantity is required.", digits: "Enter only digits." } });

    $("#hdnSKU_No_" + i).rules("add", { required: true, checkSKUExist: true, messages: { required: "SKU Code is required.", } });

    $("[name='PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_No']").rules("add", { required: true, messages: { required: "PO No. is required.", } });


    jQuery.validator.addMethod("QuantityCheck", function (value, element) {

        debugger;

        var result = true;

        var id = $(element).attr('id')

        j = id.replace("textQuantity_", "");


        var EnterQty = parseInt($('[id="textQuantity_' + j + '"]').val());

        var OrgQty = parseInt($("#hdnQuantity_" + j).val());


        if (isNaN($("#hdnQuantity_" + j).val()) || $("#hdnQuantity_" + j).val() == "") {
            result = true;
        }
        else {

            if (EnterQty != "" || $('[id="textQuantity_' + j + '"]').val() != '0') {

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

function DeletePurchaseInvoiceDetailsData(i) {

    
           
    $("#tblPurchaseInvoiceItems").find("[id='PurchaseInvoiceItemRow_" + i + "']").remove();  

    ReArrangePurchaseInvoiceDetailsData();

    var temptablecount = $("#tblPurchaseInvoiceItems").find('[id^="PurchaseInvoiceItemRow_"]').size();

    x = temptablecount;
   
    if (x == 0) {
        AddPurchaseInvoiceDetails();
    }

    CalculateTotal();

    CalculateDiscount();

    CalculateTax();
}

function ReArrangePurchaseInvoiceDetailsData() {
       

    $("#tblPurchaseInvoiceItems").find("[id^='PurchaseInvoiceItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseInvoiceItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Barcode");
            }

            //if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
            //    $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
            //    $(newTR).find("[id^='textSKU_No_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].SKU_Code");
            //    $(newTR).find("[id^='textSKU_No_']").attr("onchange", "javascript:Get_Purchase_Invoice_Items_By_SKU_Code(" + i + ")");
            //}

            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='hdnQuantity_']").attr("onchange", "javascript: Get_Purchase_Invoice_Items_By_SKU_Code(" + i + ")");
                $(newTR).find("[id^='hdnQuantity_']")[0].id = "hdnQuantity_" + i;
                $(newTR).find("[id^='hdnSKU_No_']")[0].id = "hdnSKU_No_" + i;
                $(newTR).find("[id^='hdnSKU_No_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].SKU_Code");
            }

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='hdnColor_Id_']").length > 0) {
                $(newTR).find("[id^='hdnColor_Id_']")[0].id = "hdnColor_Id_" + i;
                $(newTR).find("[id^='hdnColor_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Color_Id");
                $(newTR).find("[id^='textColor_']")[0].id = "textColor_" + i;
                $(newTR).find("[id^='textColor_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Color");
            }

            if ($(newTR).find("[id^='hdnBrand_Id_']").length > 0) {
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Brand_Id");
                $(newTR).find("[id^='textBrand_']")[0].id = "textBrand_" + i;
                $(newTR).find("[id^='textBrand_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Brand");
            }

            if ($(newTR).find("[id^='hdnCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Category_Id");
                $(newTR).find("[id^='textCategory_']")[0].id = "textCategory_" + i;
                $(newTR).find("[id^='textCategory_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Category");
            }

            if ($(newTR).find("[id^='hdnSubCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSubCategory_Id_']")[0].id = "hdnSubCategory_Id_" + i;
                $(newTR).find("[id^='hdnSubCategory_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].SubCategory_Id");
                $(newTR).find("[id^='textSub_Category_']")[0].id = "textSub_Category_" + i;
                $(newTR).find("[id^='textSub_Category_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].SubCategory");
            }

            if ($(newTR).find("[id^='hdnSize_Group_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Group_Id");
                $(newTR).find("[id^='textSize_Group_Name_']")[0].id = "textSize_Group_Name_" + i;
                $(newTR).find("[id^='textSize_Group_Name_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Group_Name");
            }

            if ($(newTR).find("[id^='hdnSize_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Id_']")[0].id = "hdnSize_Id_" + i;
                $(newTR).find("[id^='hdnSize_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Id");
                $(newTR).find("[id^='textSize_Name_']")[0].id = "textSize_Name_" + i;
                $(newTR).find("[id^='textSize_Name_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Size_Name");
            }


            if ($(newTR).find("[id^='textQuantity_']").length > 0) {
                $(newTR).find("[id^='textQuantity_']")[0].id = "textQuantity_" + i;
                $(newTR).find("[id^='textQuantity_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Quantity");
                $(newTR).find("[id^='textQuantity_']").attr("onblur", "Add_Validation(" + i + ");");
            }

            if ($(newTR).find("[id^='textWSR_Price_']").length > 0) {
                $(newTR).find("[id^='textWSR_Price_']")[0].id = "textWSR_Price_" + i;
                $(newTR).find("[id^='textWSR_Price_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].WSR_Price");
            }


            if ($(newTR).find("[id^='textAmount_']").length > 0) {
                $(newTR).find("[id^='textAmount_']")[0].id = "textAmount_" + i;
                $(newTR).find("[id^='textAmount_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Amount");
            }

            //if ($(newTR).find("[id^='textPurchase_Order_Id_']").length > 0) {
            //    $(newTR).find("[id^='textPurchase_Order_Id_']")[0].id = "textAmount_" + i;
            //    $(newTR).find("[id^='textPurchase_Order_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_Id");
            //}

            if ($(newTR).find("[id^='textInvoice_No_']").length > 0) {
                $(newTR).find("[id^='textInvoice_No_']")[0].id = "textInvoice_No_" + i;
                $(newTR).find("[id^='textInvoice_No_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_No");
                $(newTR).find("[id^='hdnPurchase_Order_Id_']")[0].id = "hdnPurchase_Order_Id_" + i;
                $(newTR).find("[id^='hdnPurchase_Order_Id_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_Id");
                $(newTR).find("[id^='hdnPurchase_Order_No_']")[0].id = "hdnPurchase_Order_No_" + i;
                $(newTR).find("[id^='hdnPurchase_Order_No_']").attr("name", "PurchaseInvoice.PurchaseInvoices[" + i + "].Purchase_Order_No");
            }
           
            if ($(newTR).find("[id='delete-invoice-details']").length > 0) {
                $(newTR).find("[id='delete-invoice-details']").attr("onclick", "DeletePurchaseInvoiceDetailsData(" + i + ")");
            }
        }
    });
}

