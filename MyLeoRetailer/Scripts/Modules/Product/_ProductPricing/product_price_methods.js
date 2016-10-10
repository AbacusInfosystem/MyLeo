


function Bind_Colour_Grid(ColourId, Colour_Name, Vendor_Color_Code) {

    var name = "Color_List";
    var div = $("#Color_Grid");
    var html = "";

    var i = ($(".block").find("a").length) - 1;

    var a = $("<a>", { href: "#", class: "list-group-item", name: name, });

    html += "<input type='hidden' id='txtVendorCode_" + ColourId + "' name = 'Vendor_Code' placeholder='Enter vendor code.' value = '" + Vendor_Color_Code + "'  class='form-control'>";
    html += "<input type='hidden' id='hdnColorId_" + ColourId + "' name = 'Vendor_Code' placeholder='Enter vendor code.' value = '" + ColourId + "'  class='form-control'>";
    html += "<input type='hidden' id='hdnColorName_" + Colour_Name + "' name = 'Vendor_Code' placeholder='Enter vendor code.' value = '" + Colour_Name + "'  class='form-control'>";

    //html += "<input type='hidden' id='txtProductDesc_" + ColourId + "'  name = 'Product_Description' class='form-control' placeholder='product description.' />";

    a.text(Colour_Name);

    a.attr("data-identity", ColourId);

    a.attr("id", i);

    a.appendTo(div);

    div.append(html);

}


function showMRPByProductColor_New(Product_Id, obj) {
    var pViewModel =
		{
		    Product: {
		        Product_Id: Product_Id,

		        Colour_Id: $(obj).attr("data-identity")
		    },
		}

    $.ajax({
        url: "/Product/MRP-ProductPrizing",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var data = $.parseJSON(response);

            var Id = $(obj).text().replace(/ /g, '');

            if ($("#" + Id).length == 0) {

                var i = 0;

                Bind_Product_MRP_New_Color(data, obj, i);
            }

            $(".Product").each(function () {
                if (this.id != Id) {
                    //$("#" + this.id).hide();
                    $('[id="' + this.id + '"]').hide();
                }
                else {
                    //$('["#" + Id]').show();
                    $('[id="' + Id + '"]').show();
                }
            });

            for (var i = 0 ; i < data.ProductDescription.length; i++) {

                var fix = data.ProductDescription[i].Status;

                if (fix == false) {
                    document.getElementById('MrpStatus_' + data.ProductDescription[i].Description).checked = false;
                }
                else {
                    document.getElementById('MrpStatus_' + data.ProductDescription[i].Description).checked = true;
                }
            }
        }
    });
}

function Bind_Product_MRP_New_Color(data, obj, i) {
    var htmlText = "";
    var index = i;
    var Vendor_Color_Code = $("#txtVendorCode_" + $(obj).attr("data-identity")).val();
    var c = $(obj).attr("id");

    if (data.ProductDescription.length > 0) {

        for (var p = 0 ; p < data.ProductDescription.length; p++) {

            htmlText += "<div id='" + $(obj).text().replace(/ /g, '') + "' class='Product' style='padding: 10px;'>";

            htmlText += "<div class='block' style='margin-bottom:0px;'>";

            htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>"; 

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            for (l = index; l < data.ProductDescription[p].ProductMRPs.length; l++) {

                if (l == index) {
                    htmlText += "<td>";
                    htmlText += "<h5 >SKU:</h5>";
                    htmlText += "</td>";
                }
                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + (data.ProductDescription[p].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[p].ProductMRPs[l].SKU_Code) + "</span>";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + l + "].SKU_Code' value='" + (data.ProductDescription[p].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[p].ProductMRPs[l].SKU_Code) + "'/>";
                htmlText += "<input type='hidden' id='hdn_length' class='form-control' name='length' value='" + data.ProductMRPs.length + "'/>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (m = index ; m < data.ProductDescription[p].ProductMRPs.length; m++) {

                if (m == index) {
                    htmlText += "<td>";
                    htmlText += "<h5 >Barcode:</h5>";
                    htmlText += "</td>";
                }
                htmlText += "<td>";

                //htmlText += "<i class='fa fa-barcode fa-3x'></i>";
                htmlText += "<img src='" + (data.ProductDescription[p].ProductMRPs[m].Barcode_Image_Url != null ? data.ProductDescription[p].ProductMRPs[m].Barcode_Image_Url : "") + "' style='width:100%'/>";
                htmlText += "<input type='hidden' id='hdn_Barcode' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + m + "].Product_Barcode' value='" + (data.ProductDescription[p].ProductMRPs[m].Product_Barcode == null ? '' : data.ProductDescription[p].ProductMRPs[m].Product_Barcode) + "' />";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (n = index ; n < data.ProductDescription[p].ProductMRPs.length; n++) {

                if (n == index) {
                    htmlText += "<td>";
                    htmlText += "<h5>Size:</h5>";
                    htmlText += "</td>";
                }
                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductDescription[p].ProductMRPs[n].Size_Name + "</span>"
                htmlText += "<input type='hidden' id='hdn_ProductId' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Product_Id' value='" + (data.ProductDescription[p].ProductMRPs[n].Product_Id == 0 ? '' : data.ProductDescription[p].ProductMRPs[n].Product_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Product_SKU_Map_Id' value='" + (data.ProductDescription[p].ProductMRPs[n].Product_SKU_Map_Id == 0 ? '' : data.ProductDescription[p].ProductMRPs[n].Product_SKU_Map_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnColourId_" + $(obj).attr("data-identity") + "' class='form-control ColorId' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Colour_Id' value='" + $(obj).attr("data-identity") + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Size_Id' value='" + (data.ProductDescription[p].ProductMRPs[n].Size_Id == 0 ? '' : data.ProductDescription[p].ProductMRPs[n].Size_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnVendorColorCode_" + Vendor_Color_Code + "' class='form-control VendorCode' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Vendor_Color_Code' value='" + Vendor_Color_Code + "'/>";
                htmlText += "<input type='hidden' id='hdnColorName_" + $(obj).text() + "' class='form-control ColorName' placeholder='description.' name='Color_Name' value='" + $(obj).text() + "' />";
                htmlText += "<input type='hidden' id='hdnColorIndex_" + c + "' class='form-control ColorIndex' placeholder='description.' name='Color_Index' value='" + $(obj).attr("id") + "' />";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (j = index; j < data.ProductDescription[p].ProductMRPs.length; j++) {

                if (j == index) {
                    htmlText += "<td>";
                    htmlText += "<h5>WSR:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_" + j + "' class='form-control AllWSRPricesRequired' placeholder='WSR.' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + j + "].Purchase_Price' value='" + (data.ProductDescription[p].ProductMRPs[j].Purchase_Price == null ? '' : data.ProductDescription[p].ProductMRPs[j].Purchase_Price) + "' />";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>" 

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            htmlText += "<td>";
            htmlText += "<h5>Description:</h5>";
            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductDesc_" + p + "' class='form-control Description' style='' placeholder='description.' name='Colors[" + c + "].ProductDescription[" + p + "].Description' value='" + (data.ProductDescription[p].Description == null ? '' : data.ProductDescription[p].Description) + "' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<label class='switch switch-small'>";

            htmlText += "<input type='radio' id='MrpStatus_" + data.ProductDescription[p].Description + "' name='MRP_Status' class='rd-list'>";
             
            htmlText += "<span style='margin-left:40px'>";
            htmlText += "</span>";
            htmlText += "</label>";
            htmlText += "</td>";

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (k = index; k < data.ProductDescription[p].ProductMRPs.length; k++) {

                if (k == index) {
                    htmlText += "<td>";
                    htmlText += "<h5>MRP:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductMRP_" + k + "' class='form-control AllMRPPricesRequired' placeholder='MRP.' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + k + "].MRP_Price' value='" + (data.ProductDescription[p].ProductMRPs[k].MRP_Price == null ? '' : data.ProductDescription[p].ProductMRPs[k].MRP_Price) + "' />";
                htmlText += "<input type='hidden' id='hdnMrpStatus' name='Colors[" + c + "].ProductDescription[" + p + "].Status' class='form-control' value='" + data.ProductDescription[p].Description + "'>";
                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>" 

            htmlText += "<div class='block' style='margin-left:685px;'>"

            htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>"

            htmlText += "<button type='button' class='btn btn-success active' id='btnSale'>Sale.</button>"

            htmlText += "</div>"


            htmlText += "</div>"

            htmlText += "</div>"

            $('#common_Product_MRP').append(htmlText); 
      
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }

}

function showMRPByProductColor_Exist(ColorId, Color, ProductId, index, Vendor_Code) {
    var pViewModel =
		{
		    Product: {
		        Product_Id: ProductId,

		        Colour_Id: ColorId
		    },
		}

    $.ajax({
        url: "/Product/MRP-ProductPrizing",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var data = $.parseJSON(response);

            var Id = Color.replace(/ /g, '');

            if ($("#" + Id).length == 0) {

                Bind_Product_MRP_Exist_Color(data, Color, index, Vendor_Code, ColorId);

            }

            for (var i = 0 ; i < data.ProductDescription.length; i++) {

                var fix = data.ProductDescription[i].Status;

                if (fix == false) {
                    document.getElementById('MrpStatus_' + data.ProductDescription[i].Description).checked = false;
                }
                else {
                    document.getElementById('MrpStatus_' + data.ProductDescription[i].Description).checked = true;
                }
            }
        }
    });
}

function Bind_Product_MRP_Exist_Color(data, Color, index, Vendor_Code, ColorId) {
    var htmlText = "";
    
    htmlText += "<div id='" + Color.replace(/ /g, '') + "' class='Product' style='padding: 10px;display:none;'>";

    htmlText += "<div class='block' style='margin-bottom:0px;'>";

    if (data.ProductDescription.length > 0) {

        for (var i = 0 ; i < 1; i++) {

            
            htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";
             

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";
             

            for (l = 0; l < data.ProductDescription[i].ProductMRPs.length; l++) {

                if (l == 0) {
                    htmlText += "<td>";
                    htmlText += "<h5>SKU:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + (data.ProductDescription[i].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[i].ProductMRPs[l].SKU_Code) + "</span>";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + l + "].SKU_Code' value='" + (data.ProductDescription[i].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[i].ProductMRPs[l].SKU_Code) + "'/>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (n = 0; n < data.ProductDescription[i].ProductMRPs.length; n++) {

                if (n == 0) {
                    htmlText += "<td>";
                    htmlText += "<h5>Barcode:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>"; 
                htmlText += "<img src='" + (data.ProductDescription[i].ProductMRPs[n].Barcode_Image_Url != null ? data.ProductDescription[i].ProductMRPs[n].Barcode_Image_Url : "") + "' style='width:100%'/>";
                htmlText += "<input type='hidden' id='hdn_Barcode' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + n + "].Product_Barcode' value='" + (data.ProductDescription[i].ProductMRPs[n].Product_Barcode == null ? '' : data.ProductDescription[i].ProductMRPs[n].Product_Barcode) + "' />";
                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (m = 0; m < data.ProductDescription[i].ProductMRPs.length; m++) {
                if (m == 0) {
                    htmlText += "<td>";
                    htmlText += "<h5>Size:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductDescription[i].ProductMRPs[m].Size_Name + "</span>"
                htmlText += "<input type='hidden' id='hdn_ProductId_Exist' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Product_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Product_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Product_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Product_MRP_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Product_MRP_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Product_MRP_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Product_SKU_Map_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Product_SKU_Map_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Product_SKU_Map_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnColourIdExist_" + ColorId + "' class='form-control ColorId' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Colour_Id' value='" + ColorId + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId_Exist' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Size_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Size_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Size_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnVendorColorCodeExist_" + Vendor_Code + "' class='form-control VendorCode' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Vendor_Color_Code' value='" + Vendor_Code + "'/>";
                //htmlText += "<input type='hidden' id='hdn_PurchasePrice' class='form-control' placeholder='WSR.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Purchase_Price' value='" + (data.ProductDescription[i].ProductMRPs[m].Purchase_Price == null ? '' : data.ProductDescription[i].ProductMRPs[m].Purchase_Price) + "' />";
                htmlText += "<input type='hidden' id='hdn_Description_Exist' class='form-control' placeholder='description.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Description' value='" + data.ProductDescription[i].Description + "' />";
                htmlText += "<input type='hidden' id='hdnColorIndexExist_" + index + "' class='form-control ColorIndex' placeholder='description.' name='Color_Index' value='" + index + "' />";
                htmlText += "<input type='hidden' id='hdnColorNameExist_" + Color + "' class='form-control ColorName' placeholder='description.' name='Color_Name' value='" + Color + "' />";
                
                htmlText += "</td>";
            }
            htmlText += "</tr>";

            htmlText += "<tr>";

            for (j = 0; j < data.ProductDescription[i].ProductMRPs.length; j++) {
                if (j == 0) {
                    htmlText += "<td>";
                    htmlText += "<h5>WSR:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_" + j + "' class='form-control AllWSRPricesRequired' placeholder='WSR.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + j + "].Purchase_Price' value='" + (data.ProductDescription[i].ProductMRPs[j].Purchase_Price == 0 ? '' : data.ProductDescription[i].ProductMRPs[j].Purchase_Price) + "' />";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>"
             

            htmlText += "<div class='block' style='margin-left:685px;'>";

            htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>";

            htmlText += "<button type='button' class='btn btn-success active' id='btnSale'>Sale.</button>";

            htmlText += "</div>";

           
        } 

        for (var i = 0 ; i < data.ProductDescription.length; i++) {  

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            htmlText += "<td>";
            htmlText += "<h5>Description:</h5>";
            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductDesc_" + i + "' class='form-control  Description' style='' placeholder='description.' name='Colors[" + index + "].ProductDescription[" + i + "].Description' value='" + data.ProductDescription[i].Description + "' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<label class='switch switch-small'>";

            htmlText += "<input type='radio' id='MrpStatus_" + data.ProductDescription[i].Description + "' name='MRP_Status' class='rd-list'>";
            htmlText += "<span style='margin-left:40px'>";
            htmlText += "</span>";
            htmlText += "</label>";
            htmlText += "</td>";

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (k = 0; k < data.ProductDescription[i].ProductMRPs.length; k++) {

                if (k == 0) {
                    htmlText += "<td>";
                    htmlText += "<h5>MRP:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductMRP_" + k + "' class='form-control AllMRPPricesRequired' placeholder='MRP.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].MRP_Price' value='" + (data.ProductDescription[i].ProductMRPs[k].MRP_Price == null ? '' : data.ProductDescription[i].ProductMRPs[k].MRP_Price) + "' />";
                htmlText += "<input type='hidden' id='hdn_ProductId_Exist' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Product_Id' value='" + (data.ProductDescription[i].ProductMRPs[k].Product_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[k].Product_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnMrpStatus' name='Colors[" + index + "].ProductDescription[" + i + "].Status' class='form-control' value='" + data.ProductDescription[i].Status + "'>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Product_MRP_Id' value='" + (data.ProductDescription[i].ProductMRPs[k].Product_MRP_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[k].Product_MRP_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPSKUId' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Product_SKU_Map_Id' value='" + (data.ProductDescription[i].ProductMRPs[k].Product_SKU_Map_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[k].Product_SKU_Map_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnColourIdExist_" + ColorId + "' class='form-control ColorId' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Colour_Id' value='" + ColorId + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId_Exist' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Size_Id' value='" + (data.ProductDescription[i].ProductMRPs[k].Size_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[k].Size_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnVendorColorCodeExist_" + Vendor_Code + "' class='form-control VendorCode' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Vendor_Color_Code' value='" + Vendor_Code + "'/>";
                htmlText += "<input type='hidden' id='hdn_PurchasePrice' class='form-control' placeholder='WSR.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].Purchase_Price' value='" + (data.ProductDescription[i].ProductMRPs[k].Purchase_Price == null ? '' : data.ProductDescription[i].ProductMRPs[k].Purchase_Price) + "' />";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].SKU_Code' value='" + (data.ProductDescription[i].ProductMRPs[k].SKU_Code == null ? '' : data.ProductDescription[i].ProductMRPs[k].SKU_Code) + "'/>";
                htmlText += "</td>";
            }
            htmlText += "</tr>";

            htmlText += "</tbody>";

            htmlText += "</table>"; 

        }
        htmlText += "</div>";

        htmlText += "</div>";

        $('#common_Product_MRP').append(htmlText); 
         
  
    } 
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }

}

function Bind_MRP_Sale_Grid(Color_Id, Color_Name, Vendor_Color_Code, Product_Id, Color_Index, DescLength) {
    var pViewModel =
		{
		    Product: {
		        Product_Id: Product_Id,

		        Colour_Id: Color_Id
		    },
		}

    $.ajax({
        url: "/Product/MRP-ProductPrizing",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var data = $.parseJSON(response);

            Bind_MRPNWSR_Sale_Grid(data, Color_Index, Color_Name, Color_Id, Vendor_Color_Code, DescLength);
        }
    });
}

function Bind_MRPNWSR_Sale_Grid(data, Color_Index, Color_Name, Color_Id, Vendor_Color_Code, DescLength) {
    var htmlText = "";
    var Length = parseInt(DescLength);
    var index = Length + 1;
    var r = 0;
    var c = Color_Index;

    if (data.ProductDescription.length > 0) {

        htmlText += "<div id='" + Color_Name + "' class='Product' style='padding: 10px;'>";

        htmlText += "<div class='block' style='margin-bottom:0px;'>";

        for (var i = index ; i < index + 1; i++) { 

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            htmlText += "<td>";
            htmlText += "<h5>Description:</h5>";
            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductDesc_" + index + "' class='form-control  Description' style='' placeholder='description.' name='Colors[" + c + "].ProductDescription[" + index + "].Description' value='' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += "<label class='switch switch-small'>";

            htmlText += "<input type='radio' id='MrpStatus_" + data.ProductDescription[r].Description + "' name='MRP_Status' class='rd-list'>";
            htmlText += "<span style='margin-left:40px'>";
            htmlText += "</span>";
            htmlText += "</label>";
            htmlText += "</td>";

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (k = 0; k < data.ProductDescription[r].ProductMRPs.length; k++) {

                if (k == 0) {
                    htmlText += "<td>";
                    htmlText += "<h5>MRP:</h5>";
                    htmlText += "</td>";
                }

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductMRP_" + k + "' class='form-control AllMRPSalePricesRequired' placeholder='MRP.' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].MRP_Price' value='' />";
                htmlText += "<input type='hidden' id='hdnMrpStatus' name='Colors[" + c + "].ProductDescription[" + index + "].Status' class='form-control' value='" + data.ProductDescription[r].Status + "'>";
                htmlText += "<input type='hidden' id='hdn_ProductId_Sale' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Product_Id' value=' " + data.ProductDescription[r].ProductMRPs[k].Product_Id + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Product_MRP_Id' value='" + 0 + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Product_SKU_Map_Id' value='" + (data.ProductDescription[r].ProductMRPs[k].Product_SKU_Map_Id == 0 ? '' : data.ProductDescription[r].ProductMRPs[k].Product_SKU_Map_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnColourIdSale_" + Color_Id + "' class='form-control ColorId' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Colour_Id' value=' " + Color_Id + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId_Sale' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Size_Id' value='" + data.ProductDescription[r].ProductMRPs[k].Size_Id + "'/>";
                htmlText += "<input type='hidden' id='hdnVendorColorCodeSale_" + Vendor_Color_Code + "' class='form-control VendorCode' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Vendor_Color_Code' value='" + Vendor_Color_Code + "'/>";
                htmlText += "<input type='hidden' id='hdnPurchasePrice' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Purchase_Price' value='" + (data.ProductDescription[r].ProductMRPs[k].Purchase_Price == null ? '' : data.ProductDescription[r].ProductMRPs[k].Purchase_Price) + "'/>";
                htmlText += "<input type='hidden' id='hdnColorNameSale_" + Color_Name + "' class='form-control ColorName' placeholder='description.' name='Color_Name' value='" + Color_Name + "' />";
                htmlText += "<input type='hidden' id='hdnColorIndexSale_" + Color_Index + "' class='form-control ColorIndex' placeholder='description.' name='Color_Index' value='" + Color_Index + "' />";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].SKU_Code' value='" + data.ProductDescription[r].ProductMRPs[k].SKU_Code + "'/>";
                htmlText += "<input type='hidden' id='hdn_Barcode' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].Product_Barcode' value='" + (data.ProductDescription[r].ProductMRPs[k].Product_Barcode == null ? '' : data.ProductDescription[r].ProductMRPs[k].Product_Barcode) + "' />";
                htmlText += "</td>";
            }
            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>" 
         
        }
        htmlText += "</div>"

        htmlText += "</div>"
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }


    $('#common_Product_MRP').append(htmlText);  
}

