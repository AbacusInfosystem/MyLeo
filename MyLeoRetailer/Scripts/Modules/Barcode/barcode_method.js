
function Get_Barcodes() {

    var bViewModel =
		{
		    Barcode: {

		        Product_SKU: $("[name='Barcode.Product_SKU']").val(),
		    },		    
		}

    $.ajax({

        url: "/Barcode/Get_Barcodes",

        data: JSON.stringify(bViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {           

            var data = $.parseJSON(response);

            Bind_Get_Barcodes_Data(data);
        }
    });
}

function Bind_Get_Barcodes_Data(data) {

    var tblHTML = "";

    $('#tblBarcode tbody tr').remove();

    if (data.Barcode.Barcodes.length > 0) {

        for (var i = 0; i < data.Barcode.Barcodes.length; i++) {

            tblHTML += "<tr id='trBarcode_" + i + "'>";

            if (data.Barcode.Barcodes[i].Is_Barcode_Printed == 1) {

                tblHTML += "<td><label class='switch'><input checked='' name='Barcode.Barcodes[" + i + "].Is_Barcode_Printed' id='Flag" + i + "' value='1' type='checkbox'><span></span></label>";
            }
            else {
                tblHTML += "<td><label class='switch'><input name='Barcode.Barcodes[" + i + "].Is_Barcode_Printed' id='Flag" + i + "' value='0' type='checkbox'><span></span></label>";
            }
                        
            tblHTML += "<input type='hidden' id='hdnId" + i + "' name='Barcode.Barcodes[" + i + "].Product_SKU_Barcode_Id' value='" + data.Barcode.Barcodes[i].Product_SKU_Barcode_Id + "' />";
            
            tblHTML += "</td>";

            tblHTML += "<input type='hidden' id='hdnId" + i + "' name='Barcode.Barcodes[" + i + "].Product_SKU' value='" + data.Barcode.Barcodes[i].Product_SKU + "' />";

            tblHTML += "</td>";
            
            tblHTML += "<input type='hidden' id='hdnId" + i + "' name='Barcode.Barcodes[" + i + "].Barcode_Image_Url' value='" + data.Barcode.Barcodes[i].Barcode_Image_Url + "' />";

            tblHTML += "</td>";

            tblHTML += "<td>" + data.Barcode.Barcodes[i].Product_SKU + "</td>";

            tblHTML += "<td>" + data.Barcode.Barcodes[i].Product_SKU_Id + "</td>";

            tblHTML += "<td>" + data.Barcode.Barcodes[i].Product_SKU_Id +"-"+ data.Barcode.Barcodes[i].Product_Barcode_Counter + "</td>";

            tblHTML += "<td>";
            
            tblHTML += "<img src='" + (data.Barcode.Barcodes[i].Barcode_Image_Url != null ? data.Barcode.Barcodes[i].Barcode_Image_Url : "") + "' style='width:150px'/>";
            
            tblHTML += "<input type='hidden' id='hdn_Barcode' class='form-control' name='Barcode.Barcodes[" + i + "].Product_Barcode' value='" + (data.Barcode.Barcodes[i].Product_Barcode == null ? '' : data.Barcode.Barcodes[i].Product_Barcode) + "' />";

            tblHTML += "</td>";
            
            tblHTML += "</tr>";

        }

    }
    else
    {
        tblHTML += "<tr>";

        tblHTML += "<td colspan='3' style='font-weight:bold'> No Records Found </td>";

        tblHTML += "</td>";
    }
      
    $('#tblBarcode tbody').append(tblHTML);

    Friendly_Messages(data);
}

function Print_All_Barcode()
{
    var temprowcount = $("#tblBarcode").find('[id^="trBarcode_"]').size();

    var x = temprowcount;
        
    for (var i = 0; i < x; i++) {
       
        $("#Flag" + i).val(1);

        document.getElementById('Flag' + i).checked = true;     
    }
}


