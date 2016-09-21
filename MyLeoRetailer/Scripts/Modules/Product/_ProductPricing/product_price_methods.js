
 

function Bind_Colour_Grid(ColourId, Colour_Name) {
    var name = "Color_List";
    var div = $("#Color_Grid");
    var html = "";

    var i = ($(".block").find("a").length)-1;
    
    var a = $("<a>", { href: "#", class: "list-group-item", name: name, }); 

    html += "<input type='text' id='txtVendorCode_" + ColourId + "' name = 'Vendor_Code' placeholder='Enter vendor code.'  class='form-control'>";

    a.text(Colour_Name);

    a.attr("data-identity", ColourId);

    a.attr("id", i);

    a.appendTo(div);

    div.append(html);
    
}



function saveProductMRP(Product_Id,obj) {
    var pViewModel =
		{
		    Product: {
		        Product_Id: Product_Id,

		        Colour_Id : $(obj).attr("data-identity")
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

            Bind_Product_MRP_Div(data,obj);
        }
    });
}

function Bind_Product_MRP_Div(data,obj)
{
    var htmlText = "";
    var Vendor_Color_Code = $("#txtVendorCode_" + $(obj).attr("data-identity")).val();
    var c = $(obj).attr("id");
    //data.Colours[c].ProductMRP_N_WSR = data.Color.ProductMRP_N_WSR;
    if (data.ProductMRPs.length > 0)
        {
         
        htmlText += "<div id='"+$(obj).text()+"' style='padding: 10px;'>";
       
            htmlText += "<div class='block' style='margin-bottom:0px;'>";

            htmlText += "<h4 style='margin-top: 0px;'>Size details:</h4>";

            htmlText += "<table class='table table-bordered table-hover' id='tbl_ProductMRP'>";

            htmlText += "<tbody>";

            htmlText += "<tr>";

            for (i = 0; i < data.ProductMRPs.length; i++) {
                //data.colors[c].ProductMRP_N_WSR[i].Colour_Id = $(obj).attr("data-identity");
                //data.colors[c].ProductMRP_N_WSR[i].Size_Id = data.ProductMRPs[i].Size_Id;
                //data.colors[c].ProductMRP_N_WSR[i].Vendor_Color_Code = $("#txtVendorCode_" + $(obj).attr("data-identity")).val();
                htmlText += "<td>";

                htmlText += "<span class='label label-primary label-form' style='margin-bottom: 1px;'>" + data.ProductMRPs[i].Size_Name + "</span>"
                htmlText += "<input type='hidden' id='hdn_ProductId' class='form-control' name='colors[" + c + "].ProductMRP_N_WSR[" + i + "].Product_Id' value='" + (data.ProductMRPs[i].Product_Id == 0 ? '' : data.ProductMRPs[i].Product_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_ColourId' class='form-control' name='colors[" + c + "].ProductMRP_N_WSR[" + i + "].Colour_Id' value='" + $(obj).attr("data-identity") + "'/>";
                htmlText += "<input type='hidden' id='hdn_SizeId' class='form-control' name='colors[" + c + "].ProductMRP_N_WSR[" + i + "].Size_Id' value='" + (data.ProductMRPs[i].Size_Id == 0 ? '' : data.ProductMRPs[i].Size_Id) + "'/>";
                htmlText += "<input type='hidden' id='hdn_Vendor_Color_Code' class='form-control' name='colors[" + c + "].ProductMRP_N_WSR[" + i + "].Vendor_Color_Code' value='" + $("#txtVendorCode_" + $(obj).attr("data-identity")).val() + "'/>";

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

            htmlText += "<button type='button' class='btn btn-success active' id='btnAddMRP'>Add.</button>"
                       //"<button class='btn btn-success active' type='button' id='btnAddColour'>Add</button>"

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

    //$("#common_Product_MRP").find("tr:gt(0)").remove();

    $('#common_Product_MRP').append(htmlText);
}


