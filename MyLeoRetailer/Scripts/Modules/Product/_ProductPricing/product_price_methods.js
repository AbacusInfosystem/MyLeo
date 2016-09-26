


function Bind_Colour_Grid(ColourId, Colour_Name) {

    var name = "Color_List";
    var div = $("#Color_Grid");
    var html = "";

    var i = ($(".block").find("a").length) - 1;

    var a = $("<a>", { href: "#", class: "list-group-item", name: name, });

    html += "<input type='text' id='txtVendorCode_" + ColourId + "' name = 'Vendor_Code' placeholder='Enter vendor code.'  class='form-control'>";

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

                Bind_Product_MRP_New_Color(data, obj);
            }
            else {
                $('.Product').hide();

                $("#" + Id).show();

            }
        }
    });
}

function Bind_Product_MRP_New_Color(data, obj) {
    var htmlText = "";
    var Vendor_Color_Code = $("#txtVendorCode_" + $(obj).attr("data-identity")).val();
    var c = $(obj).attr("id");

    if (data.ProductMRPs.length > 0) {

        htmlText += "<div id='" + $(obj).text().replace(/ /g, '') + "' class='Product' style='padding: 10px;'>";

        htmlText += "<div class='block' style='margin-bottom:0px;'>";

        htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";

        var length = data.ProductMRPs.length;
        for (i = 0; i < data.ProductMRPs.length - (length - 1); i++) {
            htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='' value='" + (data.ProductMRPs[i].Description == null ? '' : data.ProductMRPs[i].Description) + "' />";
        }

        htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

        htmlText += "<tbody>";

        htmlText += "<tr>";

        for (i = 0; i < data.ProductMRPs.length; i++) {
            htmlText += "<td>";

            htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductMRPs[i].Size_Name + "</span>"
            htmlText += "<input type='hidden' id='hdn_ProductId' class='form-control' name='Colors[" + c + "].ProductMRP_N_WSR[" + i + "].Product_Id' value='" + (data.ProductMRPs[i].Product_Id == 0 ? '' : data.ProductMRPs[i].Product_Id) + "'/>";
            htmlText += "<input type='hidden' id='hdn_ColourId' class='form-control' name='Colors[" + c + "].ProductMRP_N_WSR[" + i + "].Colour_Id' value='" + $(obj).attr("data-identity") + "'/>";
            htmlText += "<input type='hidden' id='hdn_SizeId' class='form-control' name='Colors[" + c + "].ProductMRP_N_WSR[" + i + "].Size_Id' value='" + (data.ProductMRPs[i].Size_Id == 0 ? '' : data.ProductMRPs[i].Size_Id) + "'/>";
            htmlText += "<input type='text' id='hdn_Vendor_Color_Code' class='form-control' name='Colors[" + c + "].ProductMRP_N_WSR[" + i + "].Vendor_Color_Code' value='" + Vendor_Color_Code + "'/>";
            htmlText += "<input type='text' id='hdn_Description' class='form-control' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='Colors[" + c + "].ProductMRPs[" + i + "].Description' value='" + (data.ProductMRPs[i].Description == null ? '' : data.ProductMRPs[i].Description) + "' />";

            htmlText += "</td>";
        }
        htmlText += "</tr>";

        htmlText += "<tr>";

        for (j = 0; j < data.ProductMRPs.length; j++) {

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='WSR.' name='Colors[" + c + "].ProductMRP_N_WSR[" + j + "].Purchase_Price' value='" + (data.ProductMRPs[j].Purchase_Price == null ? '' : data.ProductMRPs[j].Purchase_Price) + "' />";

            htmlText += "</td>";
        }

        htmlText += "</tr>";

        htmlText += "<tr>";

        for (k = 0; k < data.ProductMRPs.length; k++) {

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='MRP.' name='Colors[" + c + "].ProductMRP_N_WSR[" + k + "].MRP_Price' value='" + (data.ProductMRPs[k].MRP_Price == null ? '' : data.ProductMRPs[k].MRP_Price) + "' />";

            htmlText += "</td>";
        }
        htmlText += "</tr>";

        htmlText += "<tr>";

        for (l = 0; l < data.ProductMRPs.length; l++) {

            htmlText += "<td>";

            htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + (data.ProductMRPs[l].SKU_Code == null ? '' : data.ProductMRPs[l].SKU_Code) + "</span>";
            htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='colors[" + c + "].ProductMRP_N_WSR[" + l + "].SKU_Code' value='" + (data.ProductMRPs[l].SKU_Code == null ? '' : data.ProductMRPs[l].SKU_Code) + "'/>";

            htmlText += "</td>";
        }

        htmlText += "</tr>";

        htmlText += "<tr>";

        for (i = 0; i < data.ProductMRPs.length; i++) {

            htmlText += "<td>";

            htmlText += "<i class='fa fa-barcode fa-3x'></i>";

            htmlText += "</td>";
        }

        htmlText += "</tr>";

        htmlText += "</tbody>"

        htmlText += "</table>"

        htmlText += "<div class='block' style='margin-bottom:0px;'>"

        htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>"

        //htmlText += "<button type='button' class='btn btn-success active' id='btnAddMRP'>Add.</button>"


        htmlText += "</div>"

        htmlText += "</div>"

        htmlText += "</div>"
    }
        //}
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }


    $('#common_Product_MRP').append(htmlText);


    var Id = $(obj).text().replace(/ /g, '');

    $('.Product').hide();

    $("#" + Id).show();

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
            else {
                $('.Product').hide();

                $("#" + Id).show();

            }
        }
    });
}

function Bind_Product_MRP_Exist_Color(data, Color, index, Vendor_Code, ColorId) {
    var htmlText = "";
    //var Vendor_Color_Code = $("#txtVendorCode_" + $(obj).attr("data-identity")).val();
    //var c = $(obj).attr("id");

    if (data.ProductMRPs.length > 0) {

        htmlText += "<div id='" + Color.replace(/ /g, '') + "' class='Product' style='padding: 10px;'>";

        htmlText += "<div class='block' style='margin-bottom:0px;'>";

        htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";

        var length = data.ProductMRPs.length;
        for (i = 0; i < data.ProductMRPs.length - (length - 1) ; i++) {
            htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='' value='" + (data.ProductMRPs[i].Description == null ? '' : data.ProductMRPs[i].Description) + "' />";
        }

        htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

        htmlText += "<tbody>";

        htmlText += "<tr>";

        for (i = 0; i < data.ProductMRPs.length; i++) {
            htmlText += "<td>";

            htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductMRPs[i].Size_Name + "</span>"
            htmlText += "<input type='hidden' id='hdn_ProductId' class='form-control' name='Colors[" + index + "].ProductMRP_N_WSR[" + i + "].Product_Id' value='" + (data.ProductMRPs[i].Product_Id == 0 ? '' : data.ProductMRPs[i].Product_Id) + "'/>";
            htmlText += "<input type='hidden' id='hdn_ColourId' class='form-control' name='Colors[" + index + "].ProductMRP_N_WSR[" + i + "].Colour_Id' value='" + ColorId + "'/>";
            htmlText += "<input type='hidden' id='hdn_SizeId' class='form-control' name='Colors[" + index + "].ProductMRP_N_WSR[" + i + "].Size_Id' value='" + (data.ProductMRPs[i].Size_Id == 0 ? '' : data.ProductMRPs[i].Size_Id) + "'/>";
            htmlText += "<input type='hidden' id='hdn_Vendor_Color_Code' class='form-control' name='Colors[" + index + "].ProductMRP_N_WSR[" + i + "].Vendor_Color_Code' value='" + Vendor_Code + "'/>";
            htmlText += "<input type='text' id='hdn_Description' class='form-control' style='margin-top: -35px;margin-left:675px;width:200px' placeholder='description.' name='Colors[" + c + "].ProductMRPs[" + i + "].Description' value='" + (data.ProductMRPs[i].Description == null ? '' : data.ProductMRPs[i].Description) + "' />";
            htmlText += "</td>";
        }
        htmlText += "</tr>";

        htmlText += "<tr>";

        for (j = 0; j < data.ProductMRPs.length; j++) {

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='WSR.' name='Colors[" + index + "].ProductMRP_N_WSR[" + j + "].Purchase_Price' value='" + (data.ProductMRPs[j].Purchase_Price == null ? '' : data.ProductMRPs[j].Purchase_Price) + "' />";

            htmlText += "</td>";
        }

        htmlText += "</tr>";

        htmlText += "<tr>";

        for (k = 0; k < data.ProductMRPs.length; k++) {

            htmlText += "<td>";

            htmlText += "<input type='text' id='txtProductWSR_@i' class='form-control' placeholder='MRP.' name='Colors[" + index + "].ProductMRP_N_WSR[" + k + "].MRP_Price' value='" + (data.ProductMRPs[k].MRP_Price == null ? '' : data.ProductMRPs[k].MRP_Price) + "' />";

            htmlText += "</td>";
        }
        htmlText += "</tr>";

        htmlText += "<tr>";

        for (l = 0; l < data.ProductMRPs.length; l++) {

            htmlText += "<td>";

            htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + (data.ProductMRPs[l].SKU_Code == null ? '' : data.ProductMRPs[l].SKU_Code) + "</span>";
            htmlText += "<input type='hidden' id='hdn_SKUCode' class='form-control' name='colors[" + index + "].ProductMRP_N_WSR[" + l + "].SKU_Code' value='" + (data.ProductMRPs[l].SKU_Code == null ? '' : data.ProductMRPs[l].SKU_Code) + "'/>";

            htmlText += "</td>";
        }

        htmlText += "</tr>";

        htmlText += "<tr>";

        for (i = 0; i < data.ProductMRPs.length; i++) {

            htmlText += "<td>";

            htmlText += "<i class='fa fa-barcode fa-3x'></i>";

            htmlText += "</td>";
        }

        htmlText += "</tr>";

        htmlText += "</tbody>"

        htmlText += "</table>"

        htmlText += "<div class='block' style='margin-bottom:0px;'>"

        htmlText += "<button type='button' class='btn btn-success active'>Print all barcodes.</button>"

        //htmlText += "<button type='button' class='btn btn-success active' id='btnAddMRP'>Add.</button>"


        htmlText += "</div>"

        htmlText += "</div>"

        htmlText += "</div>"
    }
        //}
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'>";

        htmlText += "No record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }


    $('#common_Product_MRP').append(htmlText);


    var Id = Color.replace(/ /g, '');

    $('.Product').hide();

    $("#" + Id).show();

}


