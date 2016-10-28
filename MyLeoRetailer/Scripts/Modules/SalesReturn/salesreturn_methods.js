function Get_Customer_Name_By_Mobile_No() {

    $.ajax({

        url: "/SalesReturn/Get_Customer_Name_By_Mobile_No",

        data: { MobileNo: $("#txtMobileNo").val() },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#txtCustomer_Name').val(data.Customer_Name);

            $('#hdnCustomer_ID').val(data.Customer_Id);

        }
    });
}

function Get_Sales_Return_Items_By_SKU_Code(i) {

        $.ajax({

            url: "/SalesReturn/Get_Sales_Return_Items_By_SKU_Code",

            data: {

                Sales_Invoice_Id: $("[name='SaleReturnItemList[" + i + "].Sales_Invoice_Id']").val(),

                SKU_Code: $("[name='SaleReturnItemList[" + i + "].SKU_Code']").val()
                
            },

            method: 'GET',

            async: false,

            success: function (data) {

                $('#textArticle_No_' + i).val(data.Article_No);

                $('#textBrand_' + i).val(data.Brand);

                $('#textCategory_' + i).val(data.Category);

                $('#textSub_Category_' + i).val(data.SubCategory);

                $('#textSize_Name_' + i).val(data.Size_Name);

                $('#textColour_Name_' + i).val(data.Colour_Name);

                $('#textMRP_Price_' + i).val(data.MRP_Price);

                $('#textQuantity_' + i).val(data.Quantity);

                $('#textDiscount_Percentage_' + i).val(data.Discount_Percentage);

                CalculateTotal();

            }
        });
    
}

function Get_Sales_Return_Items_By_Barcode(i) {


    var barcode = $("[name='SaleReturnItemList[" + i + "].Barcode']").val().replace(/[$]/g, '-');

    $.ajax({

        url: "/SalesReturn/Get_Sales_Return_Items_By_SKU_Code",

        data: {

            Sales_Invoice_Id: $("[name='SaleReturnItemList[" + i + "].Sales_Invoice_Id']").val(),

            SKU_Code: barcode

        },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textBrand_' + i).val(data.Brand);

            $('#textCategory_' + i).val(data.Category);

            $('#textSub_Category_' + i).val(data.SubCategory);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#textColour_Name_' + i).val(data.Colour_Name);

            $('#textMRP_Price_' + i).val(data.MRP_Price);

            $('#textQuantity_' + i).val(data.Quantity);

            $('#textDiscount_Percentage_' + i).val(data.Discount_Percentage);

            CalculateTotal();

        }
    });

}

function AddSalesReturnDetails(i)
{

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblSalesReturnItems");

    //var temptablecount = $("#tblSalesOrderItems tr").length;

    var temptablecount = $("#tblSalesReturnItems").find('[id^="SalesReturnItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='SalesReturnItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' name='SaleReturnItemList[" + i + "].Sales_Invoice_No' id='textSales_Invoice_No_" + i + "' placeholder='Enter invoice to search' value='' data-table='Sales_Invoice' data-col='Sales_Invoice_Id,Sales_Invoice_No' data-headernames='Sales Invoice'>";
    tblHtml += "<span class='input-group-addon'> <a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnSalesInvoiceID_" + i + "' value='' name='SaleReturnItemList[" + i + "].Sales_Invoice_Id' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnSalesInvoiceNo_" + i + "' value='' name='SaleReturnItemList[" + i + "].Sales_Invoice_No' class='auto-complete-label' />";
    tblHtml += "</div>";                                               
    tblHtml += "</div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Barcode No' name='SaleReturnItemList[" + i + "].Barcode' onblur='javascript: Get_Sales_Return_Items_By_Barcode(" + i + ");' value='' id='textBarcode_No_" + i + "'>";
    tblHtml += "</td>";
                                            
    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' id='textSKU_No_" + i + "' onblur='javascript:Get_Sales_Return_Items_By_SKU_Code(" + i + ");' placeholder='SKU Code' value=''  data-table='Sales_Invoice_Item' data-col='Sales_Invoice_Id,SKU_Code' data-headernames='SKU_Code' name='SKU_Code_" + i + "' data-param='hdnSalesInvoiceID_" + i + "' data-field='Sales_Invoice_Id' />";
    tblHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnProduct_Id_" + i + "' value='' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='' name='SaleReturnItemList[" + i + "].SKU_Code' class='auto-complete-label' />";
    tblHtml += "</div>";
    tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Article No' name='SaleReturnItemList[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Brand' name='SaleReturnItemList[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleReturnItemList[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Category' name='SaleReturnItemList[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleReturnItemList[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='SubCategory' name='SaleReturnItemList[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleReturnItemList[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Size' name='SaleReturnItemList[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleReturnItemList[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Colour' name='SaleReturnItemList[" + i + "].Colour_Name' readonly value='' id='textColour_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleReturnItemList[" + i + "].Colour_Id' id='hdnColour_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Quantity' name='SaleReturnItemList[" + i + "].Quantity' value='' onblur='javascript: CalculateTotal();' id='textQuantity_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='MRP' name='SaleReturnItemList[" + i + "].MRP_Price' readonly value='' id='textMRP_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Discount %' name='SaleReturnItemList[" + i + "].Discount_Percentage' value='0'  onblur='javascript: CalculateTotal();' id='textDiscount_Percentage_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='D Amt' name='SaleReturnItemList[" + i + "].SalesReturn_Discount_Amount' readonly value='' id='textSalesReturn_Discount_Amount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Amt' name='SaleReturnItemList[" + i + "].Amount' readonly id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Return Reason' name='SaleReturnItemList[" + i + "].Return_Reason' value='' id='textReturn_Reason_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='btnAddInputRow' class='btn btn-success active' onclick='javascript:AddSalesReturnDetails();'>+</button>";
    tblHtml += "<button type='button' id='delete-salesreturn-details' class='btn btn-danger active' onclick='javascript:DeleteSalesReturnDetailsData(" + i + ")'>x</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    Add_Validation(i);

}

function DeleteSalesReturnDetailsData(i)
{

    $("#tblSalesReturnItems").find("[id='SalesReturnItemRow_" + i + "']").remove();

    ReArrangeSalesReturnDetailsData();

    CalculateTotal();

    CalculateCreditNoteAmt();

    Add_Validation(i);

}

function ReArrangeSalesReturnDetailsData()
{

    $("#tblSalesReturnItems").find("[id^='SalesReturnItemRow_']").each(function (i, row) {

        if ($(row)[0].id != 'tblHeading') {

            //$(row)[0].id = 'SalesReturnItemRow_' + $(row)[0].id.split('_')[2];

            $(row)[0].id = 'SalesReturnItemRow_' + i;

            var newTR = "#" + $(row)[0].id + " td";


            if ($(newTR).find("[id^='textSales_Invoice_No_']").length > 0) {
                $(newTR).find("[id^='textSales_Invoice_No_']")[0].id = "textSales_Invoice_No_" + i;
                $(newTR).find("[id^='textSales_Invoice_No_']").attr("name", "SaleReturnItemList[" + i + "].Sales_Invoice_No");
                $(newTR).find("[id^='hdnSalesInvoiceID_']")[0].id = "hdnSalesInvoiceID_" + i;
                $(newTR).find("[id^='hdnSalesInvoiceID_']").attr("name", "SaleReturnItemList[" + i + "].Sales_Invoice_Id");
                $(newTR).find("[id^='hdnSalesInvoiceNo_']")[0].id = "hdnSalesInvoiceNo_" + i;
                $(newTR).find("[id^='hdnSalesInvoiceNo_']").attr("name", "SaleReturnItemList[" + i + "].Sales_Invoice_No");
                
            }

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "SaleReturnItemList[" + i + "].Barcode");
            }


            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='textSKU_No_']").attr("name", "SaleReturnItemList[" + i + "].SKU_Code", "onblur", "javascript: Get_Sales_Return_Items_By_SKU_Code(" + i + ")");
                $(newTR).find("[id^='hdnProduct_Id_']")[0].id = "hdnProduct_Id_" + i;
                $(newTR).find("[id^='hdnSKU_No_']")[0].id = "hdnSKU_No_" + i;
                $(newTR).find("[id^='hdnSKU_No_']").attr("name", "SaleReturnItemList[" + i + "].SKU_Code");

            }

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "SaleReturnItemList[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='hdnBrand_Id_']").length > 0) {
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "SaleReturnItemList[" + i + "].Brand_Id");
                $(newTR).find("[id^='textBrand_']")[0].id = "textBrand_" + i;
                $(newTR).find("[id^='textBrand_']").attr("name", "SaleReturnItemList[" + i + "].Brand");
            }

            if ($(newTR).find("[id^='hdnCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "SaleReturnItemList[" + i + "].Category_Id");
                $(newTR).find("[id^='textCategory_']")[0].id = "textCategory_" + i;
                $(newTR).find("[id^='textCategory_']").attr("name", "SaleReturnItemList[" + i + "].Category");
            }

            if ($(newTR).find("[id^='hdnSubCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSubCategory_Id_']")[0].id = "hdnSubCategory_Id_" + i;
                $(newTR).find("[id^='hdnSubCategory_Id_']").attr("name", "SaleReturnItemList[" + i + "].SubCategory_Id");
                $(newTR).find("[id^='textSub_Category_']")[0].id = "textSub_Category_" + i;
                $(newTR).find("[id^='textSub_Category_']").attr("name", "SaleReturnItemList[" + i + "].SubCategory");
            }


            if ($(newTR).find("[id^='hdnSize_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Id_']")[0].id = "hdnSize_Id_" + i;
                $(newTR).find("[id^='hdnSize_Id_']").attr("name", "SaleReturnItemList[" + i + "].Size_Id");
                $(newTR).find("[id^='textSize_Name_']")[0].id = "textSize_Name_" + i;
                $(newTR).find("[id^='textSize_Name_']").attr("name", "SaleReturnItemList[" + i + "].Size_Name");
            }


            if ($(newTR).find("[id^='hdnColour_Id_']").length > 0) {
                $(newTR).find("[id^='hdnColour_Id_']")[0].id = "hdnColour_Id_" + i;
                $(newTR).find("[id^='hdnColour_Id_']").attr("name", "SaleReturnItemList[" + i + "].Colour_Id");
                $(newTR).find("[id^='textColour_Name_']")[0].id = "textColour_Name_" + i;
                $(newTR).find("[id^='textColour_Name_']").attr("name", "SaleReturnItemList[" + i + "].Colour_Name");
            }

            if ($(newTR).find("[id^='textQuantity_']").length > 0) {
                $(newTR).find("[id^='textQuantity_']")[0].id = "textQuantity_" + i;
                $(newTR).find("[id^='textQuantity_']").attr("name", "SaleReturnItemList[" + i + "].Quantity");
               
            }

            if ($(newTR).find("[id^='textMRP_Price_']").length > 0) {
                $(newTR).find("[id^='textMRP_Price_']")[0].id = "textMRP_Price_" + i;
                $(newTR).find("[id^='textMRP_Price_']").attr("name", "SaleReturnItemList[" + i + "].MRP_Price");
            }

            if ($(newTR).find("[id^='textDiscount_Percentage_']").length > 0) {
                $(newTR).find("[id^='textDiscount_Percentage_']")[0].id = "textDiscount_Percentage_" + i;
                $(newTR).find("[id^='textDiscount_Percentage_']").attr("name", "SaleReturnItemList[" + i + "].Discount_Percentage");
            }

            if ($(newTR).find("[id^='textSalesReturn_Discount_Amount_']").length > 0) {
                $(newTR).find("[id^='textSalesReturn_Discount_Amount_']")[0].id = "textSalesReturn_Discount_Amount_" + i;
                $(newTR).find("[id^='textSalesReturn_Discount_Amount_']").attr("name", "SaleReturnItemList[" + i + "].SalesReturn_Discount_Amount");
            }


            if ($(newTR).find("[id^='textAmount_']").length > 0) {
                $(newTR).find("[id^='textAmount_']")[0].id = "textAmount_" + i;
                $(newTR).find("[id^='textAmount_']").attr("name", "SaleReturnItemList[" + i + "].Amount");
            }

            if ($(newTR).find("[id^='textReturn_Reason_']").length > 0) {
                $(newTR).find("[id^='textReturn_Reason_']")[0].id = "textReturn_Reason_" + i;
                $(newTR).find("[id^='textReturn_Reason_']").attr("name", "SaleReturnItemList[" + i + "].Return_Reason");
            }

            if ($(newTR).find("[id='delete-salesreturn-details']").length > 0) {
                $(newTR).find("[id='delete-salesreturn-details']").attr("onclick", "DeleteSalesReturnDetailsData(" + i + ")");
            }
          
        }
    });
}

function Add_Validation(i) {

    $("#textQuantity_" + i).rules("add", { required: true, QuantityCheck: true, digits: true, messages: { required: "Quantity", digits: "Invalid quantity." } });

    $("#textSKU_No_" + i).rules("add", { required: true, checkSKUExist: true, messages: { required: "SKU Required", } });

    $("#textBarcode_No_" + i).rules("add", { checkBarcodeExist: true, messages: { checkBarcodeExist: "Already Mapped" } });

}
