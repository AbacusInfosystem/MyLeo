
var InitializeAutoComplete = function (elementObject) {

    $(elementObject).autocomplete({
        source: function (request, response) {

            var urlString = ''

            if ($(elementObject).attr("id") == 'txtBrand_Name') {
                urlString = "/brand/get-brand-list-by-name/" + $('#txtBrand_Name').val();
            }

            if ($(elementObject).attr("id") == 'txtColor_Name') {
                urlString = "/colour/get-color-list-by-name/" + $('#txtColor_Name').val();
            }

            $.ajax({
                url: urlString,
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Label,
                            value: item.Value
                        }
                    }));
                }
            });
        },

        minLength: 2,
        focus: function (event, ui) {
            $(this).val(ui.item.label);
            return false;
        },
        select: function (event, ui) {

            $(this).val(ui.item.label);
            
            $(this).parents('.form-group').find('input[type=text]').val("");
            $(this).parents('.form-group').find('.auto-complete-value').val(ui.item.value);
            $(this).parents('.form-group').find('.auto-complete-label').val(ui.item.label);

            $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
            $(this).parents('.form-group').find('.auto-complete-label').trigger('change');

            if ($(this).parents('.form-group').find(".border-bottom")[0]) {
                $(this).parents('.form-group').find('.border-bottom').remove();
            }

            //var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + ui.item.label + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";
            var htmlText = "<ul id='lookupUlAuto' class='list-group border-bottom'><li class='list-group-item'><span class='text'>" + ui.item.label + "<div class='pull-right'><i class='glyphicon glyphicon-remove'></i></div></li></ul>";

            if ($(this).parents('.form-group').find(".ui-menu")[0]) {
            //if ($(this).parents('.form-group').find('input[type=text]')[0]) {

                $(this).parents('.form-group').find('.text').html(ui.item.label);
            } else {

                $(this).parents('.form-group').append(htmlText);
            }

            $(this).parents('.form-group').find('.glyphicon-remove').click(function (event) {
                event.preventDefault();
                $(this).parents('.form-group').find('input[type=text]').val("");
                $(this).parents('.form-group').find('.auto-complete-value').val("");
                $(this).parents('.form-group').find('.auto-complete-label').val("");
                $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
                $(this).parents('.form-group').find('.auto-complete-label').trigger('change');
                $(this).parents('.form-group').find('.border-bottom').remove();
            });

            $('.ui-autocomplete').html("");
            return false;
        },
        open: function () {
            
            $(this).removeClass("ui-corner-all").addClass("ui-sortable");
        },
        close: function (event, ui) {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");

        }
    });

    $(elementObject).each(function () {

        if ($(this).parents('.form-group').find('.auto-complete-value').val() != 0) {

            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + $(this).parents('.form-group').find('.auto-complete-label').val() + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).parents('.form-group').find(".ui-menu")[0]) {

                $(this).parents('.form-group').find('.text').html(ui.item.label);
            } else {

                $(this).parents('.form-group').append(htmlText);
            }

            $(this).parents('.form-group').find('input[type=text]').val("");

            $(this).parents('.form-group').find('.glyphicon-remove').click(function (event) {
                event.preventDefault();
                $(this).parents('.form-group').find('input[type=text]').val("");
                $(this).parents('.form-group').find('.auto-complete-value').val("");
                $(this).parents('.form-group').find('.auto-complete-label').val("");
                $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
                $(this).parents('.form-group').find('.auto-complete-label').trigger('change');
                $(this).parents('.form-group').find('.border-bottom').remove();

            });
        }
        else {
            $(this).parents('.form-group').find('.border-bottom').remove();
        }
    });
}



