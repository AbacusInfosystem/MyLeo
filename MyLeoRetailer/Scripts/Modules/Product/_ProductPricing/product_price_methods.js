


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
            //else {
            //    $('.Product').hide();

            //    $("#" + Id).show();

            //}
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
        }
    });
}

function Bind_Product_MRP_New_Color(data, obj, i) {
    var htmlText = "";
    var index = i;
    var Vendor_Color_Code = $("#txtVendorCode_" + $(obj).attr("data-identity")).val();
    //var Product_Description = $("#txtProductDesc_" + $(obj).attr("data-identity")).val();
    var c = $(obj).attr("id");

    if (data.ProductDescription.length > 0) {

        for (var p = 0 ; p < data.ProductDescription.length; p++) {

            //htmlText += "<div id='" + $(obj).text().replace(/ /g, '') + "' class='Product' style='padding: 10px;'>";
            htmlText += "<div id='" + $(obj).text().replace(/ /g, '') + "' class='Product' style='padding: 10px;'>";

            htmlText += "<div class='block' style='margin-bottom:0px;'>";

            htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";

            htmlText += "<input type='text' id='txtProductWSR_" + p + "' class='form-control Description' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='Colors[" + c + "].ProductDescription[" + p + "].Description' value='" + (data.ProductDescription[p].Description == null ? '' : data.ProductDescription[p].Description) + "' />";

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            for (n = index ; n < data.ProductDescription[p].ProductMRPs.length; n++) {
                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductDescription[p].ProductMRPs[n].Size_Name + "</span>"
                htmlText += "<input type='hidden' id='hdn_ProductId' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Product_Id' value='" + (data.ProductDescription[p].ProductMRPs[n].Product_Id == 0 ? '' : data.ProductDescription[p].ProductMRPs[n].Product_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + n + "].Product_MRP_Id' value='" + (data.ProductDescription[p].ProductMRPs[n].Product_MRP_Id == 0 ? '' : data.ProductDescription[p].ProductMRPs[n].Product_MRP_Id) + "'/>";
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

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='WSR.' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + j + "].Purchase_Price' value='" + (data.ProductDescription[p].ProductMRPs[j].Purchase_Price == null ? '' : data.ProductDescription[p].ProductMRPs[j].Purchase_Price) + "' />";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (k = index; k < data.ProductDescription[p].ProductMRPs.length; k++) {

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='MRP.' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + k + "].MRP_Price' value='" + (data.ProductDescription[p].ProductMRPs[k].MRP_Price == null ? '' : data.ProductDescription[p].ProductMRPs[k].MRP_Price) + "' />";

                htmlText += "</td>";
            }
            htmlText += "</tr>";

            htmlText += "<tr>";

            for (l = index; l < data.ProductDescription[p].ProductMRPs.length; l++) {

                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + (data.ProductDescription[p].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[p].ProductMRPs[l].SKU_Code) + "</span>";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + c + "].ProductDescription[" + p + "].ProductMRPs[" + l + "].SKU_Code' value='" + (data.ProductDescription[p].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[p].ProductMRPs[l].SKU_Code) + "'/>";
                htmlText += "<input type='hidden' id='hdn_length' class='form-control' name='length' value='" + data.ProductMRPs.length + "'/>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (m = index ; m < data.ProductDescription[p].ProductMRPs.length; m++) {

                htmlText += "<td>";

                htmlText += "<i class='fa fa-barcode fa-3x'></i>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>"

            htmlText += "<div class='block' style='margin-bottom:0px;'>"

            htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>"

            htmlText += "<button type='button' class='btn btn-success active' id='btnSale'>Sale.</button>"


            htmlText += "</div>"

            htmlText += "</div>"

            htmlText += "</div>"

            $('#common_Product_MRP').append(htmlText);
        }
    }
        //}
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
        }
    });
}

function Bind_Product_MRP_Exist_Color(data, Color, index, Vendor_Code, ColorId) {
    var htmlText = ""; 

    if (data.ProductDescription.length > 0) {

        for (var i = 0 ; i < data.ProductDescription.length; i++) {

            var htmlText = "";

            //htmlText += "<div id='" + Color.replace(/ /g, '') + "' class='Product' style='padding: 10px;'>";
            htmlText += "<div id='" + Color.replace(/ /g, '') + "' class='Product' style='padding: 10px;display:none;'>";

            htmlText += "<div class='block' style='margin-bottom:0px;'>";

            htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";

            htmlText += "<input type='text' id='txtProductWSR_" + i + "' class='form-control  Description' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='Colors[" + index + "].ProductDescription[" + i + "].Description' value='" + data.ProductDescription[i].Description + "' />";//(data.ProductMRPs[i].Description == null ? '' : data.ProductMRPs[i].Description)

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            for (m = 0; m < data.ProductDescription[i].ProductMRPs.length; m++) {
                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductDescription[i].ProductMRPs[m].Size_Name + "</span>"
                htmlText += "<input type='hidden' id='hdn_ProductId_Exist' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Product_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Product_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Product_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Product_MRP_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Product_MRP_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Product_MRP_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnColourIdExist_"+ ColorId +"' class='form-control ColorId' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Colour_Id' value='" + ColorId + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId_Exist' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Size_Id' value='" + (data.ProductDescription[i].ProductMRPs[m].Size_Id == 0 ? '' : data.ProductDescription[i].ProductMRPs[m].Size_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdnVendorColorCodeExist_" + Vendor_Code + "' class='form-control VendorCode' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Vendor_Color_Code' value='" + Vendor_Code + "'/>";
                htmlText += "<input type='hidden' id='hdn_Description_Exist' class='form-control' placeholder='description.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + m + "].Description' value='" + data.ProductDescription[i].Description + "' />";
                htmlText += "<input type='hidden' id='hdnColorIndexExist_" + index + "' class='form-control ColorIndex' placeholder='description.' name='Color_Index' value='" + index + "' />";
                htmlText += "<input type='hidden' id='hdnColorNameExist_" + Color + "' class='form-control ColorName' placeholder='description.' name='Color_Name' value='" + Color + "' />";
                htmlText += "</td>";
            }
            htmlText += "</tr>";

            htmlText += "<tr>";

            for (j = 0; j < data.ProductDescription[i].ProductMRPs.length; j++) {

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='WSR.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + j + "].Purchase_Price' value='" + (data.ProductDescription[i].ProductMRPs[j].Purchase_Price == null ? '' : data.ProductDescription[i].ProductMRPs[j].Purchase_Price) + "' />";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (k = 0; k < data.ProductDescription[i].ProductMRPs.length; k++) {

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='MRP.' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + k + "].MRP_Price' value='" + (data.ProductDescription[i].ProductMRPs[k].MRP_Price == null ? '' : data.ProductDescription[i].ProductMRPs[k].MRP_Price) + "' />";

                htmlText += "</td>";
            }
            htmlText += "</tr>";

            htmlText += "<tr>";

            for (l = 0; l < data.ProductDescription[i].ProductMRPs.length; l++) {

                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + (data.ProductDescription[i].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[i].ProductMRPs[l].SKU_Code) + "</span>";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + index + "].ProductDescription[" + i + "].ProductMRPs[" + l + "].SKU_Code' value='" + (data.ProductDescription[i].ProductMRPs[l].SKU_Code == null ? '' : data.ProductDescription[i].ProductMRPs[l].SKU_Code) + "'/>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (n = 0; n < data.ProductDescription[i].ProductMRPs.length; n++) {

                htmlText += "<td>";

                htmlText += "<i class='fa fa-barcode fa-3x'></i>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>"

            htmlText += "<div class='block' style='margin-bottom:0px;'>"

            htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>"

            htmlText += "<button type='button' class='btn btn-success active' id='btnSale'>Sale.</button>"

            htmlText += "</div>"

            htmlText += "</div>"

            htmlText += "</div>"

            $('#common_Product_MRP').append(htmlText);
        }
    }
        //}
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

            Bind_MRPNWSR_Sale_Grid(data, Color_Index,  Color_Name, Color_Id, Vendor_Color_Code, DescLength);
        }
    });
}

function Bind_MRPNWSR_Sale_Grid(data, Color_Index,  Color_Name, Color_Id, Vendor_Color_Code, DescLength) {
    var htmlText = "";
    var Length = parseInt(DescLength);
    var index = Length + 1;
    var r = 0;
    var c = Color_Index;

    if (data.ProductDescription.length > 0) {

        for (var i = index ; i < index + 1; i++) {

            htmlText += "<div id='" + Color_Name + "' class='Product' style='padding: 10px;'>";

            htmlText += "<div class='block' style='margin-bottom:0px;'>";

            htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";

            htmlText += "<input type='text' id='txtProductWSR_" + index + "' class='form-control  Description' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='Colors[" + c + "].ProductDescription["+i+"].Description' value='' />";

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            
            for (n = 0 ; n < data.ProductDescription[r].ProductMRPs.length ; n++) {

                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductDescription[r].ProductMRPs[n].Size_Name + "</span>"
                htmlText += "<input type='hidden' id='hdn_ProductId_Sale' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + n + "].Product_Id' value=' " + data.ProductDescription[r].ProductMRPs[n].Product_Id + "'/>";
                htmlText += "<input type='hidden' id='hdn_ProductMRPId' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + n + "].Product_MRP_Id' value='" + 0 + "'/>";
                htmlText += "<input type='hidden' id='hdnColourIdSale_" + Color_Id + "' class='form-control ColorId' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + n + "].Colour_Id' value=' " + Color_Id + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId_Sale' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + n + "].Size_Id' value='" + data.ProductDescription[r].ProductMRPs[n].Size_Id + "'/>";
                htmlText += "<input type='hidden' id='hdnVendorColorCodeSale_" + Vendor_Color_Code + "' class='form-control VendorCode' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + n + "].Vendor_Color_Code' value='" + Vendor_Color_Code + "'/>";
                htmlText += "<input type='hidden' id='hdnColorNameSale_" + Color_Name + "' class='form-control ColorName' placeholder='description.' name='Color_Name' value='" + Color_Name + "' />";
                htmlText += "<input type='hidden' id='hdnColorIndexSale_" + Color_Index + "' class='form-control ColorIndex' placeholder='description.' name='Color_Index' value='" + Color_Index + "' />";
                htmlText += "</td>";
 
            }
            htmlText += "</tr>";

            htmlText += "<tr>";

         
            for (j = 0; j < data.ProductDescription[r].ProductMRPs.length ; j++) {

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='WSR.' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + j + "].Purchase_Price' value='' />";

                htmlText += "</td>";
                
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            
            for (k = 0; k < data.ProductDescription[r].ProductMRPs.length ; k++) {

                htmlText += "<td>";

                htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='MRP.' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + k + "].MRP_Price' value='' />";

                htmlText += "</td>";
                 
            }
            htmlText += "</tr>";

            htmlText += "<tr>";

             
            for (l = 0; l < data.ProductDescription[r].ProductMRPs.length ; l++) {

                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'></span>";
                htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='Colors[" + c + "].ProductDescription[" + index + "].ProductMRPs[" + l + "].SKU_Code' value=''/>";
                //htmlText += "<input type='hidden' id='hdn_length' class='form-control' name='length' value='" + New_length + "'/>";

                htmlText += "</td>";
               
            }

            htmlText += "</tr>";

            htmlText += "<tr>";

            for (m = 0 ; m < data.ProductDescription[r].ProductMRPs.length ; m++) {

                htmlText += "<td>";

                htmlText += "<i class='fa fa-barcode fa-3x'></i>";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

            htmlText += "</tbody>"

            htmlText += "</table>"

            htmlText += "<div class='block' style='margin-bottom:0px;'>"

            htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>"

            htmlText += "<button type='button' class='btn btn-success active' id='btnSale'>Sale.</button>"


            htmlText += "</div>"

            htmlText += "</div>"

            htmlText += "</div>"
        }
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

