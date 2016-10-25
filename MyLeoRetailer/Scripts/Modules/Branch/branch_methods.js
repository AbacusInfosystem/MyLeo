
//Near Location Information
function AddNearLocationDetails() {
    var rowID = $("#hdnRowIdspecific").val();
    var isEdit = $("#hdnIsEditNearDetails").val();
        
    var pincode = $("#txtNear_Location_Pincode").val();
    var statustring = "";

    if (isEdit == "false" || isEdit == false) {
        var trrow = $("#tblNearDetails").find('tr').size() - 1;

        var near_trrow = $("#tblNearDetails").find('tr').size() - 1;
        var far_trrow = $("#tblFarDetails").find('tr').size() - 1;
        var index = near_trrow + far_trrow;

        var tr = "<tr id='tr" + index + "'>";
               
        tr += "<td>";
        tr += "<span id='trNear_Location_Pincode" + index + "'>" + pincode + "</span>";
        tr += "<input type='hidden' id='hdnpincode" + index + "' name='Branch.LocationDetailsList[" + index + "].Branch_Location_Pincode' value='" + pincode + "'>";
        tr += "<input type='hidden' id='hdnFlag" + index + "' name='Branch.LocationDetailsList[" + index + "].Flag' value='True'/>";
        tr += "<input type='hidden' id='hdnNear_Branch_Location_Flag" + index + "' name='Branch.LocationDetailsList[" + index + "].Branch_Location_Flag' value='1'/>";
        tr += "<input type='hidden' id='hdnBranch_Id" + index + "' name='Branch.LocationDetailsList[" + index + "].Branch_Id' value='" + $("#hdnBranch_Id").val() + "'/>";
        tr += "</td>";

        tr += "<td class='edit'>";
        tr += "<button type='button' id='edit-near-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditNearLocationDetailsData(" + index + ")'><i class='fa fa-pencil' ></i></button>";
        tr += "<button type='button' id='delete-near-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteNearLocationDetailsData(" + index + ")'><i class='fa fa-times' ></i></button>";
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

    $("#tblNearDetails").find("[id='hdnFlag" + rowId + "']").val("False");
    $("#tblNearDetails").find("[id='tr" + rowId + "']").hide();
    //$("#tblNearDetails").find("[id='tr" + rowId + "']").remove();
    //ReArrangeNearDetailsData();
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

        var near_trrow = $("#tblNearDetails").find('tr').size() - 1;
        var far_trrow = $("#tblFarDetails").find('tr').size() - 1;
        var index = near_trrow + far_trrow;

        var tr = "<tr id='tr" + index + "'>";

        tr += "<td>";
        tr += "<span id='trFar_Location_Pincode" + index + "'>" + pincode + "</span>";
        tr += "<input type='hidden' id='hdnpincode1" + index + "' name='Branch.LocationDetailsList[" + index + "].Branch_Location_Pincode' value='" + pincode + "'>";
        tr += "<input type='hidden' id='hdnFlag" + index + "' name='Branch.LocationDetailsList[" + index + "].Flag' value='True'/>";
        tr += "<input type='hidden' id='hdnNear_Branch_Location_Flag" + index + "' name='Branch.LocationDetailsList[" + index + "].Branch_Location_Flag' value='2'/>";
        tr += "<input type='hidden' id='hdnBranch_Id" + index + "' name='Branch.LocationDetailsList[" + index + "].Branch_Id' value='" + $("#hdnBranch_Id").val() + "'/>";
        tr += "</td>";

        tr += "<td class='edit'>";
        tr += "<button type='button' id='edit-far-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditFarLocationDetailsData(" + index + ")'><i class='fa fa-pencil' ></i></button>";
        tr += "<button type='button' id='delete-far-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteFarLocationDetailsData(" + index + ")'><i class='fa fa-times' ></i></button>";
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

    $("#tblFarDetails").find("[id='hdnFlag" + rowId + "']").val("False");
    $("#tblFarDetails").find("[id='tr" + rowId + "']").hide();
    //$("#tblFarDetails").find("[id='tr" + rowId + "']").remove();
    //ResetFarLocationDetailsData();
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

function Reset_Branch() {
    
    //$('#tblPurchaseInvoiceItems tbody tr').remove();

    //$('#tblPurchaseInvoiceItems tbody tr').remove();

    $("#tblNearDetails").find('[id^="tr"]').remove();

    $("#tblFarDetails").find('[id^="tr"]').remove();

}
