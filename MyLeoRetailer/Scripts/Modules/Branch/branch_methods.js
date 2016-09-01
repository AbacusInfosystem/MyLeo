
function Save_Branch() {
    

    var bViewModel =
		{
		    Branch: {

		        Branch_Name: $("[name='Branch.Branch_Name']").val(),

		        Branch_Address: $("[name='Branch.Branch_Address']").val(),

		        Branch_City: $("[name='Branch.Branch_City']").val(),

		        Branch_State: $("[name='Branch.Branch_State']").val(),

		        Branch_Country: $("[name='Branch.Branch_Country']").val(),

		        Branch_Pincode: $("[name='Branch.Branch_Pincode']").val(),

		        Branch_Landline1: $("[name='Branch.Branch_Landline1']").val(),

		        Branch_Landline2: $("[name='Branch.Branch_Landline2']").val(),

		        Near_Branch_Location_Pincode: $("[name='Branch.Near_Branch_Location_Pincode']").val(),

		        Far_Branch_Location_Pincode: $("[name='Branch.Far_Branch_Location_Pincode']").val(),
		       
		        IsActive: $("[name='Branch.IsActive']").val(),

		        Branch_ID: $("[name='Branch.Branch_ID']").val()
		    }
		}

    var url = "";

    if ($("[name='Branch.Branch_ID']").val() == "" || $("[name='Branch.Branch_ID']").val() == 0) {
        url = "/Branch/Insert_Branch";
    }
    else {
        url = "/Branch/Update_Branch";
    }

    $.ajax({

        url: url,

        data: JSON.stringify(bViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Reset_Branch();

            Friendly_Messages(obj);

        }
    });

}

function Reset_Branch() {
    $("[name='Branch.Branch_Name']").val("");   

    $("[name='Branch.Branch_Address']").val("");

    $("[name='Branch.Branch_City']").val("");

    $("[name='Branch.Branch_State']").val("");

    $("[name='Branch.Branch_Country']").val("");

    $("[name='Branch.Branch_Pincode']").val("");

    $("[name='Branch.Branch_Landline1']").val("");

    $("[name='Branch.Branch_Landline2']").val("");

    $("[name='Branch.IsActive']").val("");

    $("[name='Branch.Branch_ID']").val("");
    
    $("[name='Branch.Near_Branch_Location_Pincode']").val("");

    $("[name='Branch.Far_Branch_Location_Pincode']").val("");

}


//Near Location Information
function AddNearLocationDetails() {
    var rowID = $("#hdnRowIdspecific").val();
    var isEdit = $("#hdnIsEditNearDetails").val();
        
    var pincode = $("#txtNear_Location_Pincode").val();
    var statustring = "";

    if (isEdit == "false" || isEdit == false) {
        var trrow = $("#tblNearDetails").find('tr').size() - 1;

        var tr = "<tr id='tr" + trrow + "'>";
               
        tr += "<td>";
        tr += "<span id='trNear_Location_Pincode" + trrow + "'>" + pincode + "</span>";
        tr += "<input type='hidden' id='hdnpincode" + trrow + "' name='Branch.NearLocationDetailsList[" + trrow + "].Branch_Location_Pincode' value='" + pincode + "'>";
        tr += "</td>";

        tr += "<td class='edit'>";
        tr += "<button type='button' id='edit-near-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditNearLocationDetailsData(" + trrow + ")'><i class='fa fa-pencil' ></i></button>";
        tr += "<button type='button' id='delete-near-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteNearLocationDetailsData(" + trrow + ")'><i class='fa fa-times' ></i></button>";
        tr += "</td>";
        tr += "</tr>";

        $('#tblNearDetails tr:last').after(tr)
    }
    else {
        
        $("#trNear_Location_Pincode" + rowID).text(pincode);
        $("#hdnpincode" + rowID).val(pincode);

    }

    ResetNearLocationDetailsData();
}

function ResetNearLocationDetailsData() {

    $("#hdnRowIdspecific").val(0);

    $("#txtNear_Location_Pincode").val('');

    $("#hdnIsEditNearDetails").val(false);

}

function EditNearLocationDetailsData(rowId) {   

    var strPincode = $("#hdnpincode" + rowId).val();
    $("#txtNear_Location_Pincode").val(strPincode);

    $("#hdnRowIdspecific").val(rowId);
    $("#hdnIsEditNearDetails").val(true);

}

function DeleteNearLocationDetailsData(rowId) {

    $("#tblNearDetails").find("[id='tr" + rowId + "']").remove();
    ReArrangeNearDetailsData();
}

function ReArrangeNearDetailsData() {
    $("#tblNearDetails").find("tr").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'tr' + (i - 1);

            var newTR = "#" + $(row)[0].id + " td";
                        
            if ($(newTR).find("[id^='hdnpincode']").length > 0) {
                $(newTR).find("[id^='hdnpincode']")[0].id = "hdnpincode" + (i - 1);
                $(newTR).find("[id^='trNear_Location_Pincode']")[0].id = "trNear_Location_Pincode" + (i - 1);
                $(newTR).find("[id^='hdnpincode']").attr("name", "Branch.NearLocationDetailsList[" + (i - 1) + "].Branch_Location_Pincode");
            }

            if ($(newTR).find("[id='edit-near-details']").length > 0) {
                $(newTR).find("[id='edit-near-details']").attr("onclick", "EditNearLocationDetailsData(" + (i - 1) + ")");
            }

            if ($(newTR).find("[id='delete-near-details']").length > 0) {
                $(newTR).find("[id='delete-near-details']").attr("onclick", "DeleteNearLocationDetailsData(" + (i - 1) + ")");
            }
        }
    });
}
//End


//Far Location Information
function AddFarLocationDetails() {
    var rowID = $("#hdnRowIdspecific2").val();
    var isEdit = $("#hdnIsEditFarDetails").val();

    var pincode = $("#txtFar_Location_Pincode").val();
    var statustring = "";

    if (isEdit == "false" || isEdit == false) {
        var trrow = $("#tblFarDetails").find('tr').size() - 1;

        var tr = "<tr id='tr" + trrow + "'>";

        tr += "<td>";
        tr += "<span id='trFar_Location_Pincode" + trrow + "'>" + pincode + "</span>";
        tr += "<input type='hidden' id='hdnpincode1" + trrow + "' name='Branch.FarLocationDetailsList[" + trrow + "].Branch_Location_Pincode' value='" + pincode + "'>";
        tr += "</td>";

        tr += "<td class='edit'>";
        tr += "<button type='button' id='edit-far-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditFarLocationDetailsData(" + trrow + ")'><i class='fa fa-pencil' ></i></button>";
        tr += "<button type='button' id='delete-far-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteFarLocationDetailsData(" + trrow + ")'><i class='fa fa-times' ></i></button>";
        tr += "</td>";
        tr += "</tr>";

        $('#tblFarDetails tr:last').after(tr)
    }
    else {

        $("#trFar_Location_Pincode" + rowID).text(pincode);
        $("#hdnpincode1" + rowID).val(pincode);

    }

    ResetFarLocationDetailsData();
}

function ResetFarLocationDetailsData() {

    $("#hdnRowIdspecific2").val(0);

    $("#txtFar_Location_Pincode").val('');

    $("#hdnIsEditFarDetails").val(false);

}

function EditFarLocationDetailsData(rowId) {

    var strPincode = $("#hdnpincode1" + rowId).val();
    $("#txtFar_Location_Pincode").val(strPincode);

    $("#hdnRowIdspecific2").val(rowId);
    $("#hdnIsEditFarDetails").val(true);

}

function DeleteFarLocationDetailsData(rowId) {

    $("#tblFarDetails").find("[id='tr" + rowId + "']").remove();
    ResetFarLocationDetailsData();
}

function ReArrangeFarDetailsData() {
    $("#tblFarDetails").find("tr").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'tr' + (i - 1);

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='hdnpincode1']").length > 0) {
                $(newTR).find("[id^='hdnpincode1']")[0].id = "hdnpincode1" + (i - 1);
                $(newTR).find("[id^='trFar_Location_Pincode']")[0].id = "trFar_Location_Pincode" + (i - 1);
                $(newTR).find("[id^='hdnpincode1']").attr("name", "Branch.FarLocationDetailsList[" + (i - 1) + "].Branch_Location_Pincode");
            }

            if ($(newTR).find("[id='edit-far-details']").length > 0) {
                $(newTR).find("[id='edit-far-details']").attr("onclick", "EditFarLocationDetailsData(" + (i - 1) + ")");
            }

            if ($(newTR).find("[id='delete-far-details']").length > 0) {
                $(newTR).find("[id='delete-far-details']").attr("onclick", "DeleteFarLocationDetailsData(" + (i - 1) + ")");
            }
        }
    });
}
//End

