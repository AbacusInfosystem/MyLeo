$(function () {

    $.validator.setDefaults({
        ignore: [],
        errorElement: "span",
        errorClass: "help-block",
        highlight: function (element, errorClass, validClass) {

            $(element).closest('.form-group').addClass('has-error');
            // 
            $(element).parent().addClass('has-error');
            //
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': '#A94442', 'background-color': '#F2DEDE', 'border-color': '#A94442' });

            if ($(element).closest('.form-group').find(".ignore").prop("class") != undefined)
            {
                if($(element).closest('.form-group').find(".ignore").prop("class").indexOf("ignore") != -1)
                {
                    $(element).parent().removeClass('has-error');

                    $(element).parent().addClass('has-warning');
                }
            }
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
            // 
            $(element).parent().removeClass('has-error'); 
            //
            $(element).closest('.form-group').find('.input-group-addon').css({ 'color': 'black', 'background-color': '#FFF', 'border-color': '#D2D6DE' });

            $(element).parent().removeClass('has-warning');
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length || element.prop('type') === 'checkbox' || element.prop('type') === 'radio') {
                error.insertAfter(element.parent());
            }
                //
            else if (element.parent('.auto-complete').length)
            {
                if (element.parent('.auto-complete').parent('.input-group').length) {
                    error.insertAfter(element.parent('.auto-complete').parent());
                }
                else
                {
                    error.insertAfter(element.parent('.auto-complete'));
                }
            }
             //
            else {
                error.insertAfter(element);
            }
        },

    	onkeyup: false,

    	onclick: false,
    	

    });

    jQuery.validator.addMethod("validate_telephone_number", function (value, element) {
        var result = false;

        var tnre = /^\+?[0-9-]+$/;
        var val = $(element).val();

        if (tnre.test(val))
        {
            result = true;
        }

        if ($(element).val() == "")
        {
        	result = true;
        }

        return result;

    }, "Please enter a valid phone number.");

    jQuery.validator.addMethod("validate_fax_number", function (value, element) {
        var result = false;

        var tnre = /^\+?[0-9-]+$/;
        var val = $(element).val();

        if (tnre.test(val)) {
            result = true;
        }

        return result;

    }, "Please enter a valid fax number.");

    jQuery.validator.addMethod("validate_file_size", function (value, element) {
        var result = true;

        if ($(element).data('max-size') != undefined)
            if ($(element)[0].files[0].size > $(element).data('max-size') * (1024 * 1024))
                return false;

        return result;
    });

});

function Set_Mandetory_Validation(name) {
    $("[name='" + name + "']").rules("add", {
        required: true
    });
}

function Set_Email_Validation(name) {
    $("[name='" + name + "']").rules("add", {
        email: true,
    });
}

function Set_Telephone_Validation(name) {
    $("[name='" + name + "']").rules("add", { validate_telephone_number: true });
}

function Set_Fax_Validation(name) {
    $("[name='" + name + "']").rules("add", { validate_fax_number: true });
}

function Remove_Validations(name) {
    $("[name='" + name + "']").rules("remove");
}

function Set_File_Size_Validation(name) {
    $("[name='" + name + "']").rules("add", {
        validate_file_size: true, messages: { validate_file_size: "File size should not be greater than " + $("[name='" + name + "']").data('max-size') + " MB." }
    });
}

