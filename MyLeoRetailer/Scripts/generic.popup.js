﻿//$(function () {
$(document).ready(function () {

    //$(document).on("click", ".glyphicon-remove", function (event) {
    //    alert();
    //    event.preventDefault();
        
    //    if (!$(this).parents(".form-group").find(".form-control").is(":disabled"))
    //    {
    //    	$(this).parents('.form-group').find('input[type=text]').val("");

    //    	$(this).parents('.form-group').find('.lookup-hidden').val("");

    //    	$(this).parents('.form-group').find('.lookup-hidden').trigger("change");

    //    	$(this).parents('.form-group').find('.todo-list').remove();
    //    }
    //});

    $(document).on("click", ".text-muted", function () {
        Get_Autocomplete_Lookup(true,$(this), false);
    });

    $(document).on("focusout", ".lookup-text", function (event) {
 
        Get_Autocomplete_Lookup(false, $(this), false);
    });

    $('#div_Parent_Modal_Fade').on('hidden.bs.modal', function (e) {

        if ($("#div_Parent_Modal_Fade").find(".modal-dialog").hasClass("modal-lg"))
            $("#div_Parent_Modal_Fade").find(".modal-dialog").removeClass("modal-lg");

        if ($("#" + $('#div_Parent_Modal_Fade').find(".modal-title").attr("data-obj")).length) {

            Close_Pop_Up(true,this);
        }
        else {

            Close_Pop_Up(false, this);
        }
    });

    $('#div_Child_Modal_Fade').on('hidden.bs.modal', function (e) {

        Close_Pop_Up(false, this);
    });

});


function Get_Autocomplete_Lookup(openModal,elementObj, modalExist) {
   
   
    $("#hdnLookupLabelId").val(elementObj.parents(".auto-complete").find(".autocomplete-text").prop("id"));

    $("#hdnLookupHiddenId").val(elementObj.parents(".auto-complete").find(".auto-complete-value").prop("id"));

    $("#hdnLookupHiddenValue").val(elementObj.parents(".auto-complete").find(".auto-complete-label").prop("id"));

    var tableName = $("#" + $("#hdnLookupLabelId").val()).data("table");

    var column = $("#" + $("#hdnLookupLabelId").val()).data("col");

    var headerNames = $("#" + $("#hdnLookupLabelId").val()).data("headernames");

    var model = "div_Parent_Modal_Fade";

    var editValue = $("#hdnEditLookupValue").val();

    //Employee

    var filterField = $("#" + $("#hdnLookupLabelId").val()).data("param");
     
    var fieldValue = $('#' + filterField).val();
    
    var fieldName = $("#" + $("#hdnLookupLabelId").val()).data("field");     

    if (modalExist == false) {

        page = 0;
    }
    else {

        page = $("#hdfCurrentPage").val();
    }

    if (openModal) {

        $("#" + model).find(".modal-body").load("/autocomplete/autocomplete-get-lookup-data/", { table_Name: tableName, columns: column, headerNames: headerNames, page: page, editValue: editValue, fieldValue: fieldValue, fieldName: fieldName },
            function () {

                $("#" + model).find(".modal-title").text($("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find(".lookup-title").text() + " List");

                $('#div_Parent_Modal_Fade').modal('toggle');
            }
            );
    }
    else
    {

        var fieldValue = $("#" + $("#hdnLookupLabelId").val()).val();


        if ($("#" + $("#hdnLookupLabelId").val()).val() != "") {

            $.ajax({

                url: '/autocompleteLookup/get-lookup-data-by-id',

                data: { field_Value: fieldValue, table_Name: tableName, columns: column },

                method: 'GET',

                async: false,

                success: function (data) {

                    if (data != null) {

                        Bind_Selected_Item_Data(data);
                    }
                }
            });
        }
        else {

            $("#" + $("#hdnLookupHiddenId").val()).val("");

            $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find('.todo-list').remove();  
            
        }
    }
   
}

function Bind_Selected_Item(data) {

    var htmltext = "";

    $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find('.todo-list').remove();

    if (data != null) {

        $("#" + $("#hdnLookupHiddenId").val()).val($("#" + $("#hdnLookupLabelId").val()).val());

        //htmltext = "<ul id='lookupUlLookup' class='todo-list ui-sortable'><li ><span class='text'>" + data + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";
        htmltext = "<ul id='lookupUlLookup' class='list-group border-bottom'><li class='list-group-item'><span class='text'>"+ data +"</span><div class='pull-right'><i class='glyphicon glyphicon-remove'></i></div></li></ul>"
    }
    else {

        $("#" + $("#hdnLookupHiddenId").val()).val("");

        //htmltext = "<ul id='lookupUlLookup' class='todo-list ui-sortable'><li ><span class='text'>" + $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find(".lookup-title").text() + " does not exist</span><div class='tools'><i class='fa fa-remove'></i>";
        htmltext = "<ul id='lookupUlLookup' class='list-group border-bottom'><li ><span class='text'>" + $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find(".lookup-title").text() + " does not exist</span><div class='pull-right'><i class='glyphicon glyphicon-remove'></i>";
    }

    $("#" + $("#hdnLookupLabelId").val()).val("");

    $("#hdnEditLookupValue").val(data);

    $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').append(htmltext);

    $("#" + $("#hdnLookupHiddenId").val()).trigger("change");
}

function Bind_Selected_Item_Data(data) {

    var Loookupdata = data.split("_");

    var Id = Loookupdata[1];
    
    var Value = Loookupdata[0];
   
    var htmltext = "";

    $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find('.todo-list').remove();

    if (data != null) {

        $("#" + $("#hdnLookupHiddenId").val()).val(Id);

        //htmltext = "<ul id='lookupUlLookup' class='todo-list ui-sortable'><li ><span class='text'>" + data + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";
        htmltext = "<ul id='lookupUlLookup' class='list-group border-bottom'><li class='list-group-item'><span class='text'>" + Value + "</span><div class='pull-right'><i class='glyphicon glyphicon-remove'></i></div></li></ul>"
    }
    else {

        $("#" + $("#hdnLookupHiddenId").val()).val("");

        //htmltext = "<ul id='lookupUlLookup' class='todo-list ui-sortable'><li ><span class='text'>" + $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find(".lookup-title").text() + " does not exist</span><div class='tools'><i class='fa fa-remove'></i>";
        htmltext = "<ul id='lookupUlLookup' class='list-group border-bottom'><li ><span class='text'>" + $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').find(".lookup-title").text() + " does not exist</span><div class='pull-right'><i class='glyphicon glyphicon-remove'></i>";
    }

    $("#" + $("#hdnLookupLabelId").val()).val(Value);

    $("#hdnEditLookupValue").val(data);
        
    $("#" + $("#hdnLookupLabelId").val()).parents('.form-group').append(htmltext);

    $("#" + $("#hdnLookupHiddenId").val()).trigger("change");

    $("#" + $("#hdnLookupHiddenId").val()).parents('.form-group').find('.glyphicon-remove').click(function (event) {
        event.preventDefault();
        $(this).parents('.form-group').find('input[type=text]').val("");
        $(this).parents('.form-group').find('.auto-complete-value').val("");
        $(this).parents('.form-group').find('.auto-complete-label').val("");
        $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
        //$(this).parents('.form-group').find('.auto-complete-label').trigger('change');
        $(this).parents('.form-group').find('#lookupUlLookup').remove();
    });

}

function Close_Pop_Up(cloneObj,elementObj) {

    if (cloneObj) {

        var obj = $("#" + $(elementObj).find(".modal-title").attr("data-obj"));

        $(elementObj).find(".modal-body").find("input").each(function () {

            $(this).attr("value", $(this).val());

        });

        $(elementObj).find(".modal-body").find("input").each(function () {

            $(this).iCheck('destroy');

        });

        obj.html($(elementObj).find(".modal-body").find("#" + $('#div_Parent_Modal_Fade').find(".modal-title").attr("data-obj")).html());
    }

    $("#hdfCurrentPage").val(0);

    $(elementObj).find(".modal-title").removeAttr("data-obj");

    $(elementObj).find(".modal-body").html("");

    $(elementObj).find(".modal-title").html("");
}

//function call_back(data) {

//    $('#div_Parent_Modal_Fade').modal('show');

//    $("#div_Parent_Modal_Fade").find(".modal-title").text("Employees");

//}