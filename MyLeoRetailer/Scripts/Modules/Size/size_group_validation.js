
$(function () {

    $("#frmSizeGroup").validate({

        rules: {
            "SizeGroup.Size_Group_Name": { required: true },
        },
        messages: {

            "SizeGroup.Size_Group_Name": { required: "Size Group is required." }
        }
    });



    $("#frmSize").validate({

        rules: {
            "SizeGroup.Size1":
                {
                    validate_Textbox_Empty: true
                },
            "SizeGroup.Size2":
               {
                   validate_Textbox_Empty2: true
               },
            "SizeGroup.Size3":
              {
                  validate_Textbox_Empty3: true
              },
            "SizeGroup.Size4":
              {
                  validate_Textbox_Empty4: true
              },
            "SizeGroup.Size5":
              {
                  validate_Textbox_Empty5: true
              },
            "SizeGroup.Size6":
              {
                  validate_Textbox_Empty6: true
              },
            "SizeGroup.Size7":
              {
                  validate_Textbox_Empty7: true
              },
            "SizeGroup.Size8":
              {
                  validate_Textbox_Empty8: true
              },
            "SizeGroup.Size9":
              {
                  validate_Textbox_Empty9: true
              },
            "SizeGroup.Size10":
              {
                  validate_Textbox_Empty10: true
              },
            "SizeGroup.Size11":
              {
                  validate_Textbox_Empty11: true
              },
            "SizeGroup.Size12":
              {
                  validate_Textbox_Empty12: true
              },
            "SizeGroup.Size13":
              {
                  validate_Textbox_Empty13: true
              },
            "SizeGroup.Size14":
              {
                  validate_Textbox_Empty14: true
              },
        },
    });
});


jQuery.validator.addMethod("validate_Textbox_Empty", function (value, element) {

    var result = true;
 {

     if ($("#txtSize1").val() == '' && $("#txtSize2").val() != '')
     {
         result = false;
     }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty2", function (value, element) {

    var result = true;
    {        
        if ($("#txtSize2").val() == '' && $("#txtSize3").val() != '')
        {
            result = false;       
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty3", function (value, element) {

    var result = true;
    {
        if ($("#txtSize3").val() == '' && $("#txtSize4").val() != '')
        {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty4", function (value, element) {

    var result = true;
    {
        if ($("#txtSize4").val() == '' && $("#txtSize5").val() != '')
        {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty5", function (value, element) {

    var result = true;
    {
        if ($("#txtSize5").val() == '' && $("#txtSize6").val() != '')
        {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty6", function (value, element) {

    var result = true;
    {
        if ($("#txtSize6").val() == '' && $("#txtSize7").val() != '')
        {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty7", function (value, element) {

    var result = true;
    {
        if ($("#txtSize7").val() == '' && $("#txtSize8").val() != '')
        {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty8", function (value, element) {

    var result = true;
    {
        if ($("#txtSize8").val() == '' && $("#txtSize9").val() != '')
        {
            result = false;
        }
    }
    return result;

}, "Please Enter Size.");

jQuery.validator.addMethod("validate_Textbox_Empty9", function (value, element) {

    var result = true;
    {
        if ($("#txtSize9").val() == '' && $("#txtSize10").val() != '')
        {
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
