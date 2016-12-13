
$(function () {

    Get_Barcodes();

    $(document).on('change', '[name="Barcode_List"]', function (event) {

        if ($(this).prop('checked')) {

            $("#hdf_BarcodeId").val(this.value);

        }
    });

    $("#btnGenerate").click(function () {

        if ($("#frmBarcodeGenerator").valid()) {

            $("#frmBarcodeGenerator").attr("action", "/Barcode/Insert_Barcode");

            $('#frmBarcodeGenerator').attr("method", "POST");

            $("#frmBarcodeGenerator").submit();
        }
    });

    $(document).on("change", "#hdnInventory_Id", function () {

        Get_Barcodes();

    });

    $("#btnPrint").click(function () { 
      
        $("#frmBarcodeGenerator").validate();

        $('#hdnProduct_SKU').rules("remove");

        $('#SKUQnty').rules("remove");
        
        if ($("#frmBarcodeGenerator").valid()) {

            $("#frmBarcodeGenerator").attr("action", "/Barcode/Print_Barcode");

            $('#frmBarcodeGenerator').attr("method", "POST");

            $("#frmBarcodeGenerator").submit();
        }
    });

        Get_Barcodes();

    });
});