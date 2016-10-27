
$(function () {

    //$("#frmSizeGroup").validate({

    //    rules: {
    //        "SizeGroup.Size_Group_Name": { required: true },
    //    },
    //    messages: {

    //        "SizeGroup.Size_Group_Name": { required: "Size Group is required." }
    //    }
    //});



    $("#frmSize").validate({

        rules: {
            "SizeGroup.Size1":
                {
                    validate_Textbox_Empty: true,
                    positiveNumber: true
                },
            "SizeGroup.Size2":
               {
                   validate_Textbox_Empty2: true,
                   positiveNumber: true
               },
            "SizeGroup.Size3":
              {
                  validate_Textbox_Empty3: true,
                  positiveNumber: true
              },
            "SizeGroup.Size4":
              {
                  validate_Textbox_Empty4: true,
                  positiveNumber: true
              },
            "SizeGroup.Size5":
              {
                  validate_Textbox_Empty5: true,
                  positiveNumber: true
              },
            "SizeGroup.Size6":
              {
                  validate_Textbox_Empty6: true,
                  positiveNumber: true
              },
            "SizeGroup.Size7":
              {
                  validate_Textbox_Empty7: true,
                  positiveNumber: true
              },
            "SizeGroup.Size8":
              {
                  validate_Textbox_Empty8: true,
                  positiveNumber: true
              },
            "SizeGroup.Size9":
              {
                  validate_Textbox_Empty9: true,
                  positiveNumber: true
              },
            "SizeGroup.Size10":
              {
                  validate_Textbox_Empty10: true,
                  positiveNumber: true
              },
            "SizeGroup.Size11":
              {
                  validate_Textbox_Empty11: true,
                  positiveNumber: true
              },
            "SizeGroup.Size12":
              {
                  validate_Textbox_Empty12: true,
                  positiveNumber: true
              },
            "SizeGroup.Size13":
              {
                  validate_Textbox_Empty13: true,
                  positiveNumber: true
              },
            "SizeGroup.Size14":
              {
                  validate_Textbox_Empty14: true,
                  positiveNumber: true
              },
        },
    });
});


jQuery.validator.addMethod("validate_Textbox_Empty", function (value, element) {

    var result = true;
    {

        if ($("#txtSize1").val() == '' && $("#txtSize2").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty2", function (value, element) {

    var result = true;
    {
        if ($("#txtSize2").val() == '' && $("#txtSize3").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty3", function (value, element) {

    var result = true;
    {
        if ($("#txtSize3").val() == '' && $("#txtSize4").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty4", function (value, element) {

    var result = true;
    {
        if ($("#txtSize4").val() == '' && $("#txtSize5").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty5", function (value, element) {

    var result = true;
    {
        if ($("#txtSize5").val() == '' && $("#txtSize6").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty6", function (value, element) {

    var result = true;
    {
        if ($("#txtSize6").val() == '' && $("#txtSize7").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty7", function (value, element) {

    var result = true;
    {
        if ($("#txtSize7").val() == '' && $("#txtSize8").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty8", function (value, element) {

    var result = true;
    {
        if ($("#txtSize8").val() == '' && $("#txtSize9").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty9", function (value, element) {

    var result = true;
    {
        if ($("#txtSize9").val() == '' && $("#txtSize10").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty10", function (value, element) {

    var result = true;
    {

        if ($("#txtSize10").val() == '' && $("#txtSize11").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty11", function (value, element) {

    var result = true;
    {

        if ($("#txtSize11").val() == '' && $("#txtSize12").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty12", function (value, element) {

    var result = true;
    {

        if ($("#txtSize12").val() == '' && $("#txtSize13").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty13", function (value, element) {

    var result = true;
    {

        if ($("#txtSize13").val() == '' && $("#txtSize14").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty14", function (value, element) {

    var result = true;
    {

        if ($("#txtSize14").val() == '' && $("#txtSize15").val() != '') {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

//Added by Vinod Mane on 27/06/2016
$(document).ready(function () {

    $("#frmSizeGroup").validate({
        rules: {
            "SizeGroup.Size_Group_Name": { required: true, validate_Size: true },
        },
        messages: {

            "SizeGroup.Size_Group_Name": { required: "Size Group is required." }
        }
    });

    jQuery.validator.addMethod("validate_Size", function (value, element) {
        var result = true;

        if ($("#txtSize_Group_Name").val() != "" && $("#hdnSizeGroupName").val() != $("#txtSize_Group_Name").val()) {
            $.ajax({
                url: '/size/check-size-group-name',
                data: { size_group_name: $("#txtSize_Group_Name").val() },
                method: 'GET',
                async: false,
                success: function (data) {
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }
        return result;

    }, "Size Group is already exists.");

    jQuery.validator.addMethod('positiveNumber', function (value) {// /^-?\d{2}(\.\d+)?$/
        var result = false;
        if (!isNaN(value) && value != '') { 
            var match = (/^\-?[0-9]*\.?[0-9]+$/).exec(value);
            var char = (/^[a-zA-Z0-9]+$/).exec(value);
            if (!isNaN(match)) {
                if (match > 0)
                    return true;
            }

            if (char != null && char != 0) {
                return true;
            }
        }
        else {
            return true;
        }
        
    }, 'Enter a positive and greater than 0 number.');

});
//End