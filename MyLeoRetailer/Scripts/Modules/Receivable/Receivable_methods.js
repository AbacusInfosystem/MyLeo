

function Get_Receivables(Sales_Invoice_Id, Sales_Credit_Note_Id) {

    $("#hdf_Sales_Invoice_Id").val(Sales_Invoice_Id);

    $("#hdf_Sales_Credit_Note_Id").val(Sales_Credit_Note_Id);

    $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");
    $("#frmReceivable").submit();
}

function Get_Credit_Note_Amount_By_Id(id) {


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

        }
    });
}

function Get_Gift_Voucher_Amount_By_Id(id) {


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

        }
    });
}

