$(document).ready(function () {

    //if ($("#hdnIs_View").val() == 1)
    //{
    //    $("#txtDispatch_Quantity").prop("readonly", true);

    //    $("#txtDispatch_Date").prop('disabled', true);

    //    $("#btnProductDispatch").hide();

    //    $("#btnSaveDispatch").hide();

    //    $("#btnCancelDispatch").hide();

    //    $("#frmProductDispatch").find("[id='btnDispatch']").hide();

    //    $("th", event.delegateTarget).remove(":nth-child(4)");
    //    $("td", event.delegateTarget).remove(":nth-child(4)");

    //}

    $("#btnSaveDispatch").click(function () {

        $("#frmProductDispatch").attr("action", "/ProductDispatch/Insert");

        $("#frmProductDispatch").attr("Method","Post");

        $("#frmProductDispatch").submit();

    });

    $("#frmProductDispatch").validate({

        rules: {
            "product_Dispatch.Quantity":
            {
                validate_Quantity: true
            }

        },
        messages: {


        }
    });


});

jQuery.validator.addMethod("validate_Quantity", function (value, element) {
    var result = true;
    if ($("#txtDispatch_Quantity").val() != "") {

        var dateTime1 = new Date($("#txtBalance_Quantitya").val()).getTime(),
          dateTime2 = new Date($("#txtDispatch_Quantity").val()).getTime();
        if (dateTime2 > dateTime1) {
            return false;
        }
    }
    return result;

}, "Dispatch Quantity is greater than Product Quantity");