function Get_Receivables() {

    var rViewModel =
		{
		    Receivable: {

		        Sales_Invoice_Id: $("#hdf_Sales_Invoice_Id").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divReceivablePager"))
		    }
		}

    $.ajax({

        url: "/Receivable/Get_Receivable_Details_By_Id",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Payable_Grid_Items(obj);

            Friendly_Messages(obj);
        }
    });

    //$("#hdf_Sales_Invoice_Id").val(Sales_Invoice_Id);
    
    //$("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");
    //$("#frmReceivable").submit();
}

function Get_Receivable() {
    var rViewModel =
		{
		    Receivable: {

		        From_Date: $("[name='Receivable.From_Date']").val(),

		        To_Date: $("[name='Receivable.To_Date']").val(),

		        Sales_Invoice_No: $("[name='Receivable.Sales_Invoice_No']").val(),

		        Customer_Name: $("[name='Receivable.Customer_Name']").val(),

		        Payment_Status: $("[name='Receivable.Payment_Status']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divReceivablePager"))
		    }
		}

    $.ajax({

        url: "/Receivable/Get_Receivable",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Get_Receivable_Search_Details_List");

            $("#divReceivablePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);
        }
    });
}

function Get_Receivables1(Sales_Invoice_Id, Sales_Credit_Note_Id) {

    $("#hdf_Sales_Invoice_Id").val(Sales_Invoice_Id);

    $("#hdf_Sales_Credit_Note_Id").val(Sales_Credit_Note_Id);

    //$("#hdf_Gift_Voucher_Id").val(Gift_Voucher_Id);

    $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");
    $("#frmReceivable").submit();
}

function Get_Credit_Note_Amount_By_Id(id) {

    debugger;

    var rViewModel =
        {
            Receivable: {

                Sales_Credit_Note_Id: id
            }
        }

    $.ajax({

        url: "/Receivable/Get_Credit_Note_Amount_By_Id",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {            

            var obj = $.parseJSON(response);

            $("[name='Receivable.Credit_Note_Amount']").val(obj.Receivable.Credit_Note_Amount);

            $("[name='Receivable.Credit_Note_Date']").val(obj.Receivable.Credit_Note_Date.substring(0, 10));

            //var dd1 = new Date(parseInt(obj.Receivable.Credit_Note_Date.replace('/Date(', '')));
            //$('#txtCredit_Note_Date').val(dd1.getDate().toString() + '-' + (dd1.getMonth() + 1).toString() + '-' + dd1.getFullYear().toString());

           // $("[name='Receivable.Credit_Note_Date']").val(ToJavaScriptDate(obj.Receivable.Credit_Note_Date));

        }
    });
}

function Get_Gift_Voucher_Amount_By_Id(id) {

    debugger;

    var rViewModel =
        {
            Receivable: {

                Gift_Voucher_Id: id
            }
        }

    $.ajax({

        url: "/Receivable/Get_Gift_Voucher_Amount_By_Id",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Receivable.Gift_Voucher_Amount']").val(obj.Receivable.Gift_Voucher_Amount);

            $("[name='Receivable.Gift_Voucher_No']").val(obj.Receivable.Gift_Voucher_No);

        }
    });
}

function CalculateDiscount() {

    debugger;


    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var chequeamount = parseFloat($("#txtCheque_Amount").val());

    var cashamount = parseFloat($("#txtCash_amount").val());

    var creditnoteamount = parseFloat($("#txtCredit_Note_Amount").val());

    var giftvoucheramount = parseFloat($("#txtGift_Voucher_Amount").val());

    var cardamount = parseFloat($("#txtCard_Amount").val());

    var total = 0;

    var PaidAmount = 0;

    total = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;

    //PaidAmount = oldbalanceamount - total;

    $("#txtPaid_Amount").val(total.toFixed(2));

    BalanceAmount();

    //if (cashamount == 0) {

    //    paidamount = chequeamount + creditnoteamount + giftvoucheramount + cardamount;

    //    //var newbalanceamount = oldbalanceamount - paidamount
    //}

    //else if (chequeamount == 0)
    //{
    //    paidamount = cashamount + creditnoteamount + giftvoucheramount + cardamount;

    //    //var newbalanceamount = oldbalanceamount - paidamount
    //}

    //else if (creditnoteamount == 0)
    //{

    //    paidamount = cashamount + chequeamount + giftvoucheramount + cardamount;

    //    //var newbalanceamount = oldbalanceamount - paidamount
    //}

    //else if (giftvoucheramount == 0) {

    //    paidamount = cashamount + chequeamount + creditnoteamount + cardamount;

    //    //var newbalanceamount = oldbalanceamount - paidamount
    //}

    //else if (cardamount == 0)
    //{

    //    paidamount = cashamount + chequeamount + creditnoteamount + giftvoucheramount;

       
    //}

    //else {

    //    paidamount = cashamount + chequeamount + creditnoteamount + cardamount + giftvoucheramount;

    //    var newbalanceamount = oldbalanceamount - paidamount

    //    //var newbalanceamount = oldbalanceamount - paidamount
    //}
   // var paidamount = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;

   

    //$("#txtBalance_Amount").val(newbalanceamount.toFixed(2));

    //$("#txtPaid_Amount").enabled = false;
    document.getElementById("txtPaid_Amount").disabled = true;
 
    

}

function BalanceAmount() {

    debugger;


    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var PaidAmount =  parseFloat($("#txtPaid_Amount").val());

    var newbalanceamount = oldbalanceamount - PaidAmount;

    $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));



}

function Cancle() {

    document.getElementById("txtPaid_Amount").disabled = false;

}

function Save_Receivable_Data() {

    debugger;

    var rViewModel =
		{
		    Receivable: {



		        Receivable_Item_Id: $("[name='Receivable.Receivable_Item_Id']").val(),

		        Receivable_Id: $("[name='Receivable.Receivable_Id']").val(),

		        Sales_Credit_Note_Id: $("[name='Receivable.Sales_Credit_Note_Id']").val(),

		        Gift_Voucher_Id: $("[name='Receivable.Gift_Voucher_Id']").val(),

		        Sales_Invoice_Id: $("[name='Receivable.Sales_Invoice_Id']").val(),

		        Payament_Date: $("[name='Receivable.Payament_Date']").val(),

		        Balance_Amount: $("[name='Receivable.Balance_Amount']").val(),

		        Gift_Voucher_No: $("[name='Receivable.Gift_Voucher_No']").val(),

		        Net_Amount: $("[name='Receivable.Net_Amount']").val(),

		        Paid_Amount: $("[name='Receivable.Paid_Amount']").val(),

		        Cash_Amount: $("[name='Receivable.Cash_Amount']").val(),

		        Cheque_Amount: $("[name='Receivable.Cheque_Amount']").val(),

		        Card_Amount: $("[name='Receivable.Card_Amount']").val(),

		        Gift_Voucher_Amount: $("[name='Receivable.Gift_Voucher_Amount']").val(),

		        Cheque_Date: $("[name='Receivable.Cheque_Date']").val(),

		        Branch_ID: $("[name='Receivable.Branch_ID']").val(),

		        Branch_Name: $("[name='Receivable.Branch_Name']").val(),

		        Cheque_No: $("[name='Receivable.Cheque_No']").val(),

		        Bank_Name: $("[name='Receivable.Bank_Name']").val(),

		        Credit_Card_No: $("[name='Receivable.Credit_Card_No']").val(),
		    }
		}

    var url = "";


    if ($("[name='Receivable.Receivable_Item_Id']").val() == "" || $("[name='Receivable.Receivable_Item_Id']").val() == 0) {

        url = "/Receivable/Insert_Receivable";
    }
    else {
        url = "/Receivable/Update_Receivable";
    }

    //alert(Receivable_Item_Id);

    $.ajax({

        url: url,

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            debugger;

            var obj = $.parseJSON(response);

            Bind_Payable_Grid_Items(obj);

            Friendly_Messages(obj);

            Cancle();

            //Friendly_Messages(obj);

        }
    });

}

function Bind_Payable_Grid_Items(data) {

    debugger;

    $("#tblReceivableItems").html("");

    var htmlText = "";

    $("#hdnReceivable_Item_Id").val(data.Receivable.Receivable_Item_Id),

    $("#hdnReceivable_Id").val(data.Receivable.Receivable_Id),

     $("#hdf_Sales_Credit_Note_Id").val(data.Receivable.Sales_Credit_Note_Id),

    $("#hdf_Gift_Voucher_Id").val(data.Receivable.Gift_Voucher_Id),

    $("#hdnSales_Invoice_Id").val(data.Receivable.Sales_Invoice_Id),

    $("#txtNet_Amount").val(data.Receivable.Net_Amount),

    $("#txtBalance_Amount").val(data.Receivable.Balance_Amount);

    if (data.Receivables.length > 0) {

        htmlText += "<tr>";

        htmlText += "<th>Paid Amount</th>";

        //htmlText += "<th>Total Amount</th>";

        htmlText += "<th>Cash Amount</th>";

        htmlText += "<th>Cheque Amount</th>";

        htmlText += "<th>Cheque No</th>";

        htmlText += "<th>Cheque Date</th>";

        htmlText += "<th>Bank Name</th>";

        htmlText += "<th>Credit note no</th>";

        htmlText += "<th>Credit note amount</th>";

        htmlText += "<th>Credit note date</th>";

        htmlText += "<th>Card no</th>";

        htmlText += "<th>Card amount</th>";

        htmlText += "<th>Gift voucher no</th>";

        htmlText += "<th>Gift voucher amount</th>";

    }

    htmlText += "</tr>";

    for (i = 0; i < data.Receivables.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Paid_Amount == null ? "" : data.Receivables[i].Paid_Amount;

        htmlText += "</td>";

        //htmlText += "<td>";

        //htmlText += data.Receivables[i].Total_MRP_Amount == null ? "" : data.Receivables[i].Total_MRP_Amount;

        //htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cash_Amount == null ? "" : data.Receivables[i].Cash_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_Amount == null ? "" : data.Receivables[i].Cheque_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_No == null ? "" : data.Receivables[i].Cheque_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_Date == "1/1/1999" ? "NA" : data.Receivables[i].Cheque_Date.substring(0, 10);

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Bank_Name == null ? "" : data.Receivables[i].Bank_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_No == null ? "" : data.Receivables[i].Credit_Note_No;

        htmlText += "</td>";


        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_Amount == null ? "" : data.Receivables[i].Credit_Note_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_Date == "1/1/1999" ? "NA" : data.Receivables[i].Credit_Note_Date.substring(0, 10);

        //Added By Vinod Mane on 23/09/2016
        //var Customer_DOB = new Date(obj.Customer.Customer_DOB);
        //Customer_DOB = (Customer_DOB.getDate().toString() + "-" + (Customer_DOB.getMonth() + 1).toString() + "-" + Customer_DOB.getFullYear());
        //$("[name='Customer.Customer_DOB']").val(Customer_DOB);
        //End

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Card_No == null ? "" : data.Receivables[i].Credit_Card_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Card_Amount == null ? "" : data.Receivables[i].Card_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Gift_Voucher_No == null ? "" : data.Receivables[i].Gift_Voucher_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Gift_Voucher_Amount == null ? "" : data.Receivables[i].Gift_Voucher_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        //htmlText += showPayableDate == null ? "" : showPayableDate;

        htmlText += "<input type='hidden' id='hdnPaid_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Paid_Amount + "'/>";

        //htmlText += "<input type='hidden' id='hdnTotal_MRP_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Total_MRP_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCash_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cash_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_Date + "'/>";

        htmlText += "<input type='hidden' id='hdnPayament_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivable.Payament_Date + "'/>";

        htmlText += "<input type='hidden' id='hdnBranchID" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivable.Branch_ID + "'/>";

        htmlText += "<input type='hidden' id='hdnBranchName" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivable.Branch_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnBank_Name" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Bank_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Sales_Credit_Note_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Note_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Note_Date + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Card_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCard_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Card_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnGift_Voucher_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Gift_Voucher_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnGift_Voucher_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Gift_Voucher_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnReceivable_Item_Id" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Receivable_Item_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnReceivable_Id" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Receivable_Id + "'/>";

        htmlText += "</td>";

        //if (data.Payable.Status != "Payment Done") {
        htmlText += "<td>";


        htmlText += "<button type='button' id='edit-Payable-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditReceivableData(" + data.Receivables[i].Receivable_Item_Id +")'><i class='fa fa-pencil' ></i></button>";

        //htmlText += "<button type='button' id='delete-Payable-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeletPayableData(" + data.Receivables[i].Receivable_Item_Id + ")'><i class='fa fa-times' ></i></button>";

        htmlText += "</td>";
        //}

        htmlText += "</tr>";
    }
  

    $('#tblReceivableItems').html(htmlText);

    //Friendly_Message(data);

    ClearReceivableData();


}

function ClearReceivableData() {

    $("#txtPaid_Amount").val('');

    $("#txtCash_amount").val('');

    $("#txtCheque_Amount").val('');

    $("#txtCheque_No").val('');

    $("#txtCheque_Date").val('');

    $("#txtPayament_Date").val('');

    $("#txtBank_Name").val('');

    $("#drpCredit_Note_No").val('');

    $("#txtCredit_Note_Amount").val('');

    $("#txtCredit_Card_No").val('');

    $("#txtCredit_Note_Date").val('');

    $("#txtCard_Amount").val('');

    $("#drpGift_Voucher_No").val('');

    $("#txtGift_Voucher_Amount").val('');

}

function EditReceivableData(id) {

    alert("12");

    debugger;

    var Balance_amount = 0;
    var paid_amount = 0;
    var total_bal_amount = 0;
   

    $("#txtPaid_Amount").val($("#hdnPaid_Amount" + id).val());

    //$("#txtTotal_MRP_Amount").val($("#hdnTotal_MRP_Amount" + id).val());

    $("#txtCash_amount").val($("#hdnCash_Amount" + id).val());

    $("#txtCheque_Amount").val($("#hdnCheque_Amount" + id).val());

    $("#txtCheque_No").val($("#hdnCheque_No" + id).val());

    $("#a123").val($("#hdnCheque_Date" + id).val());

    $("#txtCheque_Date").val($("#hdnCheque_Date" + id).val());

    $("#txtPayament_Date").val($("#hdnPayament_Date" + id).val());

    $("#txtBank_Name").val($("#hdnBank_Name" + id).val());

    $("#txtCredit_Note_Amount").val($("#hdnCredit_Note_Amount" + id).val());

    $("#txtCredit_Card_No").val($("#hdnCredit_Card_No" + id).val());

    $("#txtCredit_Note_Date").val($("#hdnCredit_Note_Date" + id).val());

    $("#txtCard_Amount").val($("#hdnCard_Amount" + id).val());

    $("#txtGift_Voucher_Amount").val($("#hdnGift_Voucher_Amount" + id).val());

    $("#hdnReceivable_Item_Id").val($("#hdnReceivable_Item_Id" + id).val());

    $('[name = "Receivable.Sales_Credit_Note_Id"]').val($("#hdnCredit_Note_No" + id).val());

    $('[name = "Receivable.Gift_Voucher_Id"]').val($("#hdnGift_Voucher_No" + id).val());

    $("#hdnReceivable_Id").val($("#hdnReceivable_Id" + id).val());


    //edited by sushant for Branch

    $("#text_Branch_Name").val($("#hdnBranchName" + id).val());

    $("#hdnBranchID").val($("#hdnBranchID" + id).val());


    if ($('#text_Branch_Name').val() != 0)

        $("#divBranch").find(".autocomplete-text").trigger("focusout");


    Balance_amount = $("#txtBalance_Amount").val();

    paid_amount = $("#txtPaid_Amount").val();

    total_bal_amount = parseFloat(Balance_amount) + parseFloat(paid_amount);

    $("#txtBalance_Amount").val(total_bal_amount);


}

