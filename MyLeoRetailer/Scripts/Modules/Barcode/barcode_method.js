

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

            tblHTML += "<tr>";

            tblHTML += "<td><label class='switch'><input checked='' value='1' type='checkbox'><span></span></label>";
            
            tblHTML += "<input type='hidden' id='hdnId" + i + "' name='Barcode.Barcodes[" + i + "].Product_SKU_Barcode_Id' value='" + data.Barcode.Barcodes[i].Product_SKU_Barcode_Id + "' />";
            
            tblHTML += "</td>";

            tblHTML += "<td>" + data.Barcode.Barcodes[i].Product_SKU + "</td>";

            tblHTML += "<td>" + data.Barcode.Barcodes[i].Product_SKU +"-"+ data.Barcode.Barcodes[i].Product_Barcode_Counter + "</td>";

            tblHTML += "<td>";
            
            tblHTML += "<img src='" + (data.Barcode.Barcodes[i].Barcode_Image_Url != null ? data.Barcode.Barcodes[i].Barcode_Image_Url : "") + "' style='width:200px'/>";
            
            tblHTML += "<input type='hidden' id='hdn_Barcode' class='form-control' name='Barcode.Barcodes[" + i + "].Product_Barcode' value='" + (data.Barcode.Barcodes[i].Product_Barcode == null ? '' : data.Barcode.Barcodes[i].Product_Barcode) + "' />";

            tblHTML += "</td>";
            
            tblHTML += "</tr>";

        }

        $('#tblBarcode tbody').append(tblHTML);

    }
      
    Friendly_Messages(data);
}

