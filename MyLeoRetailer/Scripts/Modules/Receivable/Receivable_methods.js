

function Get_Payable(Sales_Invoice_Id, Sales_Credit_Note_Id) {

    $("#hdf_Sales_Invoice_Id").val(Sales_Invoice_Id);

    $("#hdf_Sales_Credit_Note_Id").val(Sales_Credit_Note_Id);

    $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");
    $("#frmReceivable").submit();
}