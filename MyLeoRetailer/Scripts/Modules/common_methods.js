
function Bind_Anchor_Grid(obj, name, div)
{
	$(div).html("");

	for (var i = 0; i < obj.Grid_Detail['Records'].length; i++)
	{
		for (var j = 0; j < obj.Grid_Detail['Show_Columns'].length; j++)
		{
			if (j <= obj.Grid_Detail['Show_Columns'].length)
			{
				var a = $("<a>", { href: "#", class: "list-group-item", name: name, });

				a.text(obj.Grid_Detail['Records'][i]['' + obj.Grid_Detail['Show_Columns'][j]]);

				a.attr("data-identity", obj.Grid_Detail['Records'][i]['' + obj.Grid_Detail['Identity_Columns'][j]]);

				a.appendTo(div);
			}
		}
	}
}

function Bind_Grid(obj, name)
{
	var table = $("<table>");

	Bind_Header(table, obj);

	Bind_Rows(table, obj, name);

	// Table 
	table.addClass("table").addClass("table-hover");

	table.css("margin-bottom", "0");

    //$("#divDynamicTable").html(table[0].innerHTML); //.html(table_str);

	$("#divDynamicTable").html(table); //.html(table_str);

	$("#divPager").html(obj.Grid_Detail['Pager']['PageHtmlString'])


}

function Bind_Header(table, obj)
{
	var header = $("<thead>").appendTo(table);

	var row = $("<tr>").appendTo(header);

	if (obj.Grid_Detail['Identity_Columns'].length > 0)
	{
		var th = $("<th>").appendTo(row);
	}

	for (var i = 0; i < obj.Grid_Detail['Show_Columns'].length; i++)
	{
	    var th = $("<th>").appendTo(row);

	    var Show_Coloumns = obj.Grid_Detail['Show_Columns'][i].replace("_", " ");

		th.text(Show_Coloumns);
	}
}

function Bind_Rows(table, obj, name)
{   
	var tbody = $("<tbody>").appendTo(table);

	for (var i = 0; i < obj.Grid_Detail['Records'].length; i++)
	{
		var row = $("<tr>").appendTo(tbody);

		if (obj.Grid_Detail['Identity_Columns'].length > 0)
		{
		    var td = $("<td>").appendTo(row);

		    var label = $("<label>", { class: "switch switch-small" }).appendTo(td);

		    label.css("margin", "0");

		    var radio = $("<input>", { type: "radio", value: obj.Grid_Detail['Records'][i]['' + obj.Grid_Detail['Identity_Columns'][0]], name: name }).appendTo(label);

		    $("<span>").appendTo(label);

			radio.addClass("rd-list");

			for (var j = 0; j < obj.Grid_Detail['Identity_Columns'].length; j++)
			{
			    $("<input>", { type: "hidden",  value: obj.Grid_Detail['Records'][i]['' + obj.Grid_Detail['Identity_Columns'][j]], name: obj.Grid_Detail['Identity_Columns'][j] }).appendTo(td);
			}
		}

		for (var j = 0; j < obj.Grid_Detail['Show_Columns'].length; j++)
		{
			if (j <= obj.Grid_Detail['Show_Columns'].length)
			{
				var td = $("<td>").appendTo(row);

				td.text(obj.Grid_Detail['Records'][i]['' + obj.Grid_Detail['Show_Columns'][j]]);
			}
		}
	}
}

function Page(page,obj, callback)
{
	$("#" + obj).find('.current-page').val(page);

	callback();
}

function MoveQuick(page,obj, callback)
{
	$("#" + obj).find('.quick-page').val(page);

	callback();
}

function Set_Pager(obj)
{
	var isFirst = false;

	var isPrevious = false;

	var isNext = false;

	var isLast = false;


	if ($(obj).find('.quick-page').val() == "First")
	{
		isFirst = true;
	}
	else if ($(obj).find('.quick-page').val() == "Previous")
	{
		isPrevious = true;
	}
	else if ($(obj).find('.quick-page').val() == "Next")
	{
		isNext = true;
	}
	else if ($(obj).find('.quick-page').val() == "Last")
	{
		isLast = true;
	}

	var Pager = {

		CurrentPage: $(obj).find('.current-page').val(),

		StartPage: $(obj).find('.start-page').val(),

		EndPage: $(obj).find('.end-page').val(),

		IsFirst: isFirst,

		IsPrevious: isPrevious,

		IsNext: isNext,

		IsLast: isLast,
	}

	return Pager;
}

function Friendly_Messages(obj)
{
	for (var i = 0; i < obj.FriendlyMessages.length; i++)
	{
		noty({
			text: obj.FriendlyMessages[i].Text,
			layout: 'topCenter',
			type: obj.FriendlyMessages[i].TypeStr.toLowerCase(),
			timeout: 5000,

			
		});
	}
}


