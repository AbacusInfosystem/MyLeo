$(document).ready(function () {

    Get_Product_Dispatch();

    $("[id='txtBranch_Name']").focusout(function () {
        Get_Product_Dispatch();
    });

    $(document).on("change", "#hdnBranchName", function () {
        Get_Product_Dispatch();
    });

    $("#drpStatus").change(function () {
       Get_Product_Dispatch();
    });

    $(document).on('change', '[name="ProductDispatch_List"]', function (event) {

        if ($(this).prop('checked')) {
            $("#hdnRequestId").val(this.value);

            var status = $(this).closest("td").find("[name='Status']").val();

            var sku = $(this).closest("td").find("[name='SKU_Code']").val();

            $("#hdnSKU").val(sku);

            if (status == "Pending" || status == "Partially Dispatch")
            {
                $('#btnDispatch').show();
                $("#btnView").hide();
            }
            else
            {
                $("#btnView").show();
                $('#btnDispatch').hide();

            }
        }
    });

    $('#btnDispatch').click(function () {

        $('#hdnIs_View').val(0);
        $("#frmProductDispatch").attr("action","/ProductDispatch/Index");
        $("#frmProductDispatch").attr("method","POST");
        $("#frmProductDispatch").submit();

    });


    $('#btnView').click(function () {

        $('#hdnIs_View').val(1);
        $("#frmProductDispatch").attr("action", "/ProductDispatch/Index");
        $("#frmProductDispatch").attr("method", "POST");
        $("#frmProductDispatch").submit();

    });


    // cause issue change event hit twise[Pending] //

    $("#txtFromRequestdate").change(function () {
        this.focus();
        this.blur();
        $("#txtFromRequestdate").datepicker({
            autoclose: true
        });
        alert();
    });

    $("#txtToRequestdate").change(function () {
        $("#txtToRequestdate").datepicker({
            autoclose: true
        });
        this.focus();
        this.blur();
    });

    //**********************************//

    $("#frmProductDispatch").validate({

        rules: {
            "fromDate":
            {
                validate_Date: true
            },

            "toDate":
          {
              validate_Date: true
          },

        },
        messages: {


        }
    });


});

jQuery.validator.addMethod("validate_Date", function (value, element) {
    var result = true;
    if ($("#txtFromRequestdate").val() != "" && $("#txtToRequestdate").val() != "") {

        var dateTime1 = new Date($("#txtFromRequestdate").val()).getTime(),
          dateTime2 = new Date($("#txtToRequestdate").val()).getTime();
        if (dateTime2 < dateTime1)
        {
            return false;
        }
        else
        {
            Get_Product_Dispatch();
        }

    }
    return result;

}, "To date can't be less than From date ");