﻿
$(function () {

    Get_Barcodes();


    $(document).on('change', '[name="Barcode_List"]', function (event) {

        if ($(this).prop('checked')) {

            $("#hdf_BarcodeId").val(this.value);

        }
    });

    $("#btnGenerate").click(function () {

        $("#frmBarcodeGenerator").attr("action", "/Barcode/Insert_Barcode");

        $('#frmBarcodeGenerator').attr("method", "POST");

        $("#frmBarcodeGenerator").submit();

    });

    $(document).on("change", "#hdnInventory_Id", function () {

        Get_Barcodes();

    });


});