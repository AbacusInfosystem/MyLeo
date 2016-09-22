function AddNewBankDetails() {

    //$("#frmBankDetails").validate();
    //$("#frmBankDetails").find(".custom-mandatory").rules("add", { required: true, messages: { required: "Input is required." } });


    var rowID = $("#hdnRowIdspecific").val();
    var isEdit = $("#hdnIsEditBankDetails").val();

    var bank_Name = $("#txtBank_Name").val();
    var account_No = $("#txtAccount_No").val();
    var branch_Name = $("#txtBranch_Name").val();
    var ifsc_Code = $("#txtIFSC_Code").val();
    var statustring = "";


    //if ($("#frmBankDetails").valid()) {
    if (bank_Name != "" && account_No != "" && branch_Name != "" && ifsc_Code != "") {//Code Added by Vinod Mane on 20/09/2016
        if (isEdit == "false" || isEdit == false) {
            var trrow = $("#tblBankDetails").find('tr').size() - 1;

            var tr = "<tr id='tr" + trrow + "'>";

            tr += "<td>";
            tr += "<span id='trBankName" + trrow + "'>" + bank_Name + "</span>";
            tr += "<input type='hidden' id='hdnbank_Name" + trrow + "' name='Vendor.BankDetailsList[" + trrow + "].Bank_Name' value='" + bank_Name + "'>";
            tr += "</td>";

            tr += "<td>";
            tr += "<span id='trAccount_No" + trrow + "'>" + account_No + "</span>";
            tr += "<input type='hidden' id='hdnaccount_No" + trrow + "' name='Vendor.BankDetailsList[" + trrow + "].Account_No' value='" + account_No + "'>";
            tr += "</td>";

            tr += "<td>";
            tr += "<span id='trBranch_Name" + trrow + "'>" + branch_Name + "</span>";
            tr += "<input type='hidden' id='hdnbranch_Name" + trrow + "' name='Vendor.BankDetailsList[" + trrow + "].Branch_Name' value='" + branch_Name + "'>";
            tr += "</td>";

            tr += "<td>";
            tr += "<span id='trIfsc_Code" + trrow + "'>" + ifsc_Code + "</span>";
            tr += "<input type='hidden' id='hdnifsc_Code" + trrow + "' name='Vendor.BankDetailsList[" + trrow + "].Ifsc_Code' value='" + ifsc_Code + "'>";
            tr += "</td>";

            tr += "<td class='edit'>";
            tr += "<button type='button' id='edit-bank-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditBankDetailsData(" + trrow + ")'><i class='fa fa-pencil' ></i></button>";
            tr += "<button type='button' id='delete-bank-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteBankDetailsData(" + trrow + ")'><i class='fa fa-times' ></i></button>";
            tr += "</td>";
            tr += "</tr>";

            $('#tblBankDetails tr:last').after(tr)
        }
        else {
            $("#trBankName" + rowID).text(bank_Name);
            $("#hdnbank_Name" + rowID).val(bank_Name);
            $("#trAccount_No" + rowID).text(account_No);
            $("#hdnaccount_No" + rowID).val(account_No);
            $("#trBranch_Name" + rowID).text(branch_Name);
            $("#hdnbranch_Name" + rowID).val(branch_Name);
            $("#trIfsc_Code" + rowID).text(ifsc_Code);
            $("#hdnifsc_Code" + rowID).val(ifsc_Code)

        }
    }//End
    //}
    ResetBankDetailsData();
}

function ResetBankDetailsData() {

    $("#hdnRowIdspecific").val(0);

    $("#txtBank_Name").val('');

    $("#txtAccount_No").val('');

    $("#txtBranch_Name").val('');

    $("#txtIFSC_Code").val('');

    $("#hdnIsEditBankDetails").val(false);
}

function EditBankDetailsData(rowId) {

    var strBankDetails = $("#hdnbank_Name" + rowId).val();
    $("#txtBank_Name").val(strBankDetails);

    var strAccountNo = $("#hdnaccount_No" + rowId).val();
    $("#txtAccount_No").val(strAccountNo);

    var strBranchName = $("#hdnbranch_Name" + rowId).val();
    $("#txtBranch_Name").val(strBranchName);

    var strIFSCCode = $("#hdnifsc_Code" + rowId).val();
    $("#txtIFSC_Code").val(strIFSCCode);

    $("#hdnRowIdspecific").val(rowId);
    $("#hdnIsEditBankDetails").val(true);

}

function DeleteBankDetailsData(rowId) {

    $("#tblBankDetails").find("[id='tr" + rowId + "']").remove();
    ReArrangeBankDetailsData();
}

function ReArrangeBankDetailsData() {
    $("#tblBankDetails").find("tr").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'tr' + (i - 1);

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='hdnbank_Name']").length > 0) {
                $(newTR).find("[id^='hdnbank_Name']")[0].id = "hdnbank_Name" + (i - 1);
                $(newTR).find("[id^='trBankName']")[0].id = "trBankName" + (i - 1);
                $(newTR).find("[id^='hdnbank_Name']").attr("name", "Vendor.BankDetailsList[" + (i - 1) + "].Bank_Name");               
            }

            if ($(newTR).find("[id^='hdnaccount_No']").length > 0) {
                $(newTR).find("[id^='hdnaccount_No']")[0].id = "hdnaccount_No" + (i - 1);
                $(newTR).find("[id^='trAccount_No']")[0].id = "trAccount_No" + (i - 1);
                $(newTR).find("[id^='hdnaccount_No']").attr("name", "Vendor.BankDetailsList[" + (i - 1) + "].Account_No");
            }

            if ($(newTR).find("[id^='hdnbranch_Name']").length > 0) {
                $(newTR).find("[id^='hdnbranch_Name']")[0].id = "hdnbranch_Name" + (i - 1);
                $(newTR).find("[id^='trBranch_Name']")[0].id = "trBranch_Name" + (i - 1);
                $(newTR).find("[id^='hdnbranch_Name']").attr("name", "Vendor.BankDetailsList[" + (i - 1) + "].Branch_Name");
            }


            if ($(newTR).find("[id^='hdnifsc_Code']").length > 0) {
                $(newTR).find("[id^='hdnifsc_Code']")[0].id = "hdnifsc_Code" + (i - 1);
                $(newTR).find("[id^='trIfsc_Code']")[0].id = "trIfsc_Code" + (i - 1);
                $(newTR).find("[id^='hdnifsc_Code']").attr("name", "Vendor.BankDetailsList[" + (i - 1) + "].IFSC_Code");
            }


            if ($(newTR).find("[id='edit-bank-details']").length > 0) {
                $(newTR).find("[id='edit-bank-details']").attr("onclick", "EditBankDetailsData(" + (i - 1) + ")");
            }

            if ($(newTR).find("[id='delete-bank-details']").length > 0) {
                $(newTR).find("[id='delete-bank-details']").attr("onclick", "DeleteBankDetailsData(" + (i - 1) + ")");
            }
        }
    });
}



//Brand -- Code Added By Sushant

function AddBrandDetails() {

    var rowID = $("#hdnRowIdspecific").val();
    var isEdit = $("#hdnIsEditBrandDetails").val();

    var brand_Name = $("#drpBrand option:selected").text();
    var brand_Id = $("#drpBrand").val();
    var statustring = "";


    if (brand_Name != "Select Brand")// Code Added by Vinod Mane on 20/09/2016
    {
    if (isEdit == "false" || isEdit == false) {
        var trrow = $("#tblBrandDetails").find('tr').size() - 1;

        var tr = "<tr id='tr" + trrow + "'>";

        tr += "<td>";
        tr += "<span id='trBrandName" + trrow + "'>" + brand_Name + "</span>";
        tr += "<input type='hidden' id='hdnbrand_Name" + trrow + "' name='Vendor.BrandDetailsList[" + trrow + "].Brand_Detail_Id' value='" + brand_Id + "'>";
        //tr += "<input type='hidden' id='hdnVendor_Brand_Detail_Id" + trrow + "' name='Vendor.BrandDetailsList[" + trrow + "].Brand_Detail_Id' value=''>";
        tr += "</td>";

        tr += "<td class='edit'>";
        tr += "<button type='button' id='edit-brand-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditBrandDetailsData(" + trrow + ")'><i class='fa fa-pencil' ></i></button>";
        tr += "<button type='button' id='delete-brand-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteBrandDetailsData(" + trrow + ")'><i class='fa fa-times' ></i></button>";
        tr += "</td>";
        tr += "</tr>";

        $('#tblBrandDetails tr:last').after(tr)
    }
    else {
        $("#trBrandName" + rowID).text(brand_Name);
        $("#hdnbrand_Name" + rowID).val(brand_Name);
    }
}//End
    ResetBrandDetailsData();
}

function ResetBrandDetailsData() {

    $("#hdnRowIdspecific").val(0);

    $("#drpBrand").val(0);

    $("#hdnIsEditBrandDetails").val(false);

}

function EditBrandDetailsData(rowId) {

    var strBrandDetails = $("#hdnbrand_Name" + rowId).val();
    $("#drpBrand").val(strBrandDetails);

    $("#hdnRowIdspecific").val(rowId);
    $("#hdnIsEditBrandDetails").val(true);

}

function DeleteBrandDetailsData(rowId) {

    $("#tblBrandDetails").find("[id='tr" + rowId + "']").remove();
    ReArrangeBrandDetailsData();
}


function ReArrangeBrandDetailsData() {
    $("#tblBrandDetails").find("tr").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'tr' + (i - 1);

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='hdnbrand_Name']").length > 0) {
                $(newTR).find("[id^='hdnbrand_Name']")[0].id = "hdnbrand_Name" + (i - 1);
                $(newTR).find("[id^='trBrandName']")[0].id = "trBrandName" + (i - 1);
                $(newTR).find("[id^='hdnbrand_Name']").attr("name", "Vendor.BrandDetailsList[" + (i - 1) + "].Brand_Detail_Id");
                //$(newTR).find("[id^='hdnVendor_Brand_Detail_Id']").attr("name", "Vendor.BrandDetailsList[" + (i - 1) + "].Brand_Detail_Id");
            }

            if ($(newTR).find("[id='edit-brand-details']").length > 0) {
                $(newTR).find("[id='edit-brand-details']").attr("onclick", "EditBrandDetailsData(" + (i - 1) + ")");
            }

            if ($(newTR).find("[id='delete-brand-details']").length > 0) {
                $(newTR).find("[id='delete-brand-details']").attr("onclick", "DeleteBrandDetailsData(" + (i - 1) + ")");
            }
        }
    });
}


//Category  -- Code Added By Sushant

function AddCategoryDetails() {

    var rowID = $("#hdnRowIdspecific").val();
    var isEdit = $("#hdnIsEditCategoryDetails").val();

    var category_Name = $("#drpCategory option:selected").text();
    var category_Id = $("#drpCategory").val();
    var statustring = "";

    if (category_Name != "Select Category") {//Code Added by Vinod Mane on 20/09/2016
        if (isEdit == "false" || isEdit == false) {
            var trrow = $("#tblCategoryDetails").find('tr').size() - 1;

            var tr = "<tr id='tr" + trrow + "'>";

            tr += "<td>";
            tr += "<span id='trCategoryName" + trrow + "'>" + category_Name + "</span>";
            tr += "<input type='hidden' id='hdncategory_Name" + trrow + "' name='Vendor.CategoryDetailsList[" + trrow + "].Category_Detail_Id' value='" + category_Id + "'>";
            //tr += "<input type='hidden' id='hdnVendor_Category_Detail_Id" + trrow + "' name='Vendor.CategoryDetailsList[" + trrow + "].Category_Detail_Id' value=''>";
            tr += "</td>";

            tr += "<td class='edit'>";
            tr += "<button type='button' id='edit-category-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditCategoryDetailsData(" + trrow + ")'><i class='fa fa-pencil' ></i></button>";
            tr += "<button type='button' id='delete-category-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteCategoryDetailsData(" + trrow + ")'><i class='fa fa-times' ></i></button>";
            tr += "</td>";
            tr += "</tr>";

            $('#tblCategoryDetails tr:last').after(tr)
        }
        else {
            $("#trCategoryName" + rowID).text(category_Name);
            $("#hdncategory_Name" + rowID).val(category_Name);
        }
    }//End
    ResetCategoryDetailsData();
}

function ResetCategoryDetailsData() {

    $("#hdnRowIdspecific").val(0);

    $("#drpCategory").val(0);

    $("#hdnIsEditCategoryDetails").val(false);

}

function EditCategoryDetailsData(rowId) {

    var strCategoryDetails = $("#hdncategory_Name" + rowId).val();

    $("#drpCategory").val(strCategoryDetails);

    $("#hdnRowIdspecific").val(rowId);

    $("#hdnIsEditCategoryDetails").val(true);

}

function DeleteCategoryDetailsData(rowId) {

    $("#tblCategoryDetails").find("[id='tr" + rowId + "']").remove();
    ReArrangeCategoryDetailsData();
}


function ReArrangeCategoryDetailsData() {
    $("#tblCategoryDetails").find("tr").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'tr' + (i - 1);

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='hdncategory_Name']").length > 0) {
                $(newTR).find("[id^='hdncategory_Name']")[0].id = "hdncategory_Name" + (i - 1);
                $(newTR).find("[id^='trCategoryName']")[0].id = "trCategoryName" + (i - 1);
                $(newTR).find("[id^='hdncategory_Name']").attr("name", "Vendor.CategoryDetailsList[" + (i - 1) + "].Category_Detail_Id");
                //$(newTR).find("[id^='hdnVendor_Category_Detail_Id']").attr("name", "Vendor.CategoryDetailsList[" + (i - 1) + "].Category_Detail_Id");
            }

            if ($(newTR).find("[id='edit-category-details']").length > 0) {
                $(newTR).find("[id='edit-category-details']").attr("onclick", "EditCategoryDetailsData(" + (i - 1) + ")");
            }

            if ($(newTR).find("[id='delete-category-details']").length > 0) {
                $(newTR).find("[id='delete-category-details']").attr("onclick", "DeleteCategoryDetailsData(" + (i - 1) + ")");
            }
        }
    });
}


//Sub Category  -- Code Added By Sushant

function AddSubCategoryDetails() {

    var rowID = $("#hdnRowIdspecific").val();
    var isEdit = $("#hdnIsEditSubCategoryDetails").val();

    var subcategory_Name = $("#drpSubCategory option:selected").text();
    var subcategory_Id = $("#drpSubCategory").val();

    var statustring = "";

    if (subcategory_Name != "Select Sub Category") {//Code Added by Vinod Mane on 20/09/2016
        if (isEdit == "false" || isEdit == false) {
            var trrow = $("#tblSubCategoryDetails").find('tr').size() - 1;

            var tr = "<tr id='tr" + trrow + "'>";

            tr += "<td>";
            tr += "<span id='trSubCategoryName" + trrow + "'>" + subcategory_Name + "</span>";
            tr += "<input type='hidden' id='hdnsubcategory_Name" + trrow + "' name='Vendor.SubCategoryDetailsList[" + trrow + "].SubCategory_Id' value='" + subcategory_Id + "'>";
            tr += "</td>";

            tr += "<td class='edit'>";
            tr += "<button type='button' id='edit-subcategory-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditSubCategoryDetailsData(" + trrow + ")'><i class='fa fa-pencil' ></i></button>";
            tr += "<button type='button' id='delete-subcategory-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeleteSubCategoryDetailsData(" + trrow + ")'><i class='fa fa-times' ></i></button>";
            tr += "</td>";
            tr += "</tr>";

            $('#tblSubCategoryDetails tr:last').after(tr)
        }
        else {
            $("#trSubCategoryName" + rowID).text(subcategory_Name);
            $("#hdnsubcategory_Name" + rowID).val(subcategory_Name);
        }
    }//End
    ResetSubCategoryDetailsData();
}

function ResetSubCategoryDetailsData() {

    $("#hdnRowIdspecific").val(0);

    $("#drpSubCategory").val(0);

    $("#hdnIsEditSubCategoryDetails").val(false);

}

function EditSubCategoryDetailsData(rowId) {

    var strSubCategoryDetails = $("#hdnsubcategory_Name" + rowId).val();
    $("#drpSubCategory").val(strSubCategoryDetails);

    $("#hdnRowIdspecific").val(rowId);
    $("#hdnIsEditSubCategoryDetails").val(true);

}

function DeleteSubCategoryDetailsData(rowId) {

    $("#tblSubCategoryDetails").find("[id='tr" + rowId + "']").remove();
    ReArrangeSubCategoryDetailsData();
}


function ReArrangeSubCategoryDetailsData() {
    $("#tblSubCategoryDetails").find("tr").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'tr' + (i - 1);

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='hdnsubcategory_Name']").length > 0) {
                $(newTR).find("[id^='hdnsubcategory_Name']")[0].id = "hdnsubcategory_Name" + (i - 1);
                $(newTR).find("[id^='trSubCategoryName']")[0].id = "trSubCategoryName" + (i - 1);
                $(newTR).find("[id^='hdnsubcategory_Name']").attr("name", "Vendor.SubCategoryDetailsList[" + (i - 1) + "].SubCategory_Id");
                //$(newTR).find("[id^='hdnVendor_SubCategory_Detail_Id']").attr("name", "Vendor.SubCategoryDetailsList[" + (i - 1) + "].SubCategory_Detail_Id");
            }

            if ($(newTR).find("[id='edit-subcategory-details']").length > 0) {
                $(newTR).find("[id='edit-subcategory-details']").attr("onclick", "EditSubCategoryDetailsData(" + (i - 1) + ")");
            }

            if ($(newTR).find("[id='delete-subcategory-details']").length > 0) {
                $(newTR).find("[id='delete-subcategory-details']").attr("onclick", "DeleteSubCategoryDetailsData(" + (i - 1) + ")");
            }
        }
    });
}


//Save Vendor


function Save_Vendor() {

    var vViewModel =
		{
		    Vendor: {

		        Vendor_Name: $("[name='Vendor.Vendor_Name']").val(),

		        Vendor_Type: $("[name='Vendor.Vendor_Type']").val(),

		        Vendor_Email1: $("[name='Vendor.Vendor_Email1']").val(),

		        Vendor_Email2: $("[name='Vendor.Vendor_Email2']").val(),

		        Vendor_Address: $("[name='Vendor.Vendor_Address']").val(),

		        Vendor_City: $("[name='Vendor.Vendor_City']").val(),

		        Vendor_State: $("[name='Vendor.Vendor_State']").val(),

		        Vendor_Country: $("[name='Vendor.Vendor_Country']").val(),

		        Vendor_Pincode: $("[name='Vendor.Vendor_Pincode']").val(),

		        Vendor_Phone1: $("[name='Vendor.Vendor_Phone1']").val(),

		        Vendor_Phone2: $("[name='Vendor.Vendor_Phone2']").val(),

		        Vendor_Vat_No: $("[name='Vendor.Vendor_Vat_No']").val(),

		        Vendor_Vat_Rate: $("#drpVendor_Vat_Rate").val(),

		        Vendor_Vat_Effective_Date: $("[name='Vendor.Vendor_Vat_Effective_Date']").val(),

		        Vendor_CST_No: $("[name='Vendor.Vendor_CST_No']").val(),

		        Vendor_CST_Rate: $("#drpVendor_CST_Rate").val(),

		        Vendor_CST_Effective_Date: $("[name='Vendor.Vendor_CST_Effective_Date']").val(),

		        Brand_Id: $("#drpBrand").val(),

		        Category_Id: $("#drpCategory").val(),

		        SubCategory_Id: $("#drpSubCategory").val(),

		        Bank_Name: $("#txtBank_Name").val(),

		        Account_No: $("#txtAccount_No").val(),

		        Branch_Name: $("#txtBranch_Name").val(),

		        Ifsc_Code: $("#txtIFSC_Code").val(),


		        Vendor_Id: $("#hdf_Vendor_Id").val()
		    }
		}

    var url = "";

    url = "/Vendor/Insert_Vendor";

    //if ($("[name='Vendor.Vendor_Id']").val() == "") {

    //    url = "/Vendor/Insert_Vendor";
    //}
    //else {
    //    url = "/Vendor/Update_Vendor";
    //}

    $.ajax({

        url: url,

        data: JSON.stringify(vViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            //Reset_Vendor();

            Get_Vendors();

            Friendly_Messages(obj);

        }
    });


}

//Added By Vinod Mane on 21/09/2016
function Get_SubCategorylist(Caterory_id)
{

    cache: false,
         $.post('/Vendor/Get_SubCategorylist', { 'Caterory_id': Caterory_id },
              function (result) {
                  var options = '';
                  var arr = new Array();
                  for (var i = 0; i < result.length; i++) {
                      arr.push(result[i]);
                  }
                  options += '<option value="' + "" + '">' + "Select Sub Category" + '</option>';
                  for (var i = 0; i < arr.length; i++) {
                      options += '<option  value="' + arr[i].SubCategory_Id + '">' + arr[i].SubCategory_Name + '</option>';
                  }
                  $('#drpSubCategory').empty().append(options);
              });

}
//end