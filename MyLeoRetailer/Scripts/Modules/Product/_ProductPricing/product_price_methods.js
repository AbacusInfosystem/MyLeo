
//function Get_Colour(ColourId) {
//    var pViewModel =
//		{
//		    Product: {

//		        Colour_Id: ColourId
//		    },
//		}

//    $.ajax({

//        url: "/Product/Get_Colours_By_ColourId",

//        data: JSON.stringify(pViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {

//            var obj = $.parseJSON(response);

//            Bind_Colour_Grid(obj, "Color_List", $("#Color_Grid"));
//        }
//    });
//}

function Bind_Colour_Grid(ColourCode) {
    var name = "Color_List";
    var div = $("#Color_Grid");
    var i = 0;

    var a = $("<a>", { href: "#", class: "list-group-item", name: name, });

    //var result_name = window.classifier.classify(ColourCode);

    a.text(ColourCode);

    a.attr("data-identity", ColourCode);

    a.attr("id", i++);

    a.appendTo(div);
}

function Get_ProductMRP(obj) {
    var Arr = [];

    var Colour_Name = $(obj).text();
    var id = $(obj).id;
    $(".divMRP").attr("id", id);
    $(".divMRP").show();

    Arr.push($(obj).text());
    if ($.inArray(Colour_Name, Arr) > -1) {
        $(".divMRP").clone();
        //$("#divProductMRP").attr("class", Colour_Name);
    }
}




