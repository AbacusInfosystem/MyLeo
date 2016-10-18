using MyLeoRetailerInfo;
using MyLeoRetailerRepo.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerRepo
{
    public class AutocompleteLookupRepo
    {
        SQL_Repo sqlHelper = null;

        public AutocompleteLookupRepo()
        {
            sqlHelper = new SQL_Repo();
        }

        public DataTable Get_Lookup_Data(string table_Name, string[] cols, ref Pagination_Info pager, string fieldValue, string fieldName, int entity_Id)
        {
            string strquery = "";

            strquery = "select ";

            for (int i = 0; i < cols.Length; i++)
            {
                strquery += cols[i] + ",";
            }

            char[] removeCh = { ',', ' ' };

            strquery = strquery.TrimEnd(removeCh);

            strquery += " from " + table_Name;


            List<SqlParameter> paramList = new List<SqlParameter>();

            if (fieldValue != "0" && !string.IsNullOrEmpty(fieldValue))
            {

                if (table_Name == "Employee")
                {
                    if (fieldName == "Role_Id")
                    {
                        strquery = " Select Employee.Employee_Id , Employee.Employee_Name  ";
                        strquery += "from Employee inner join Role on Employee.Role_Id=Role.Role_Id ";
                        strquery += "where Role.Role_Id= @Role_Id";
                        paramList.Add(new SqlParameter("@Role_Id", fieldValue));
                    }
                    if (fieldName == "Sales_Invoice")
                    {
                        strquery = " Select Employee.Employee_Id , Employee.Employee_Name  ";
                        strquery += "from Employee inner join Role on Employee.Role_Id=Role.Role_Id ";
                        strquery += "where Role.Role_Name like '" + fieldValue + "%'";
                        //paramList.Add(new SqlParameter("@Role_Name", fieldValue));
                    } 
                }

                if (table_Name == "Purchase_Order")
                {
                    if (fieldName == "Vendor_Id")
                    {
                        strquery = " Select Purchase_Order.Purchase_Order_Id, Purchase_Order.Purchase_Order_No ";
                        strquery += "from Purchase_Order ";
                        strquery += "where Purchase_Order.Vendor_Id = @Vendor_Id";
                        paramList.Add(new SqlParameter("@Vendor_Id", fieldValue));
                    }
                }

                if (table_Name == "Product_SKU_Mapping")
                {
                    if (fieldName == "Purchase_Order_Id")
                    {                       
                        strquery = "IF OBJECT_ID('tempdb..#Temp1') IS NOT NULL " +
                                    "DROP TABLE #Temp1 " +

                                    "IF OBJECT_ID('tempdb..#Temp2') IS NOT NULL " +
                                    "DROP TABLE #Temp2 " +

                                    "IF OBJECT_ID('tempdb..#Temp3') IS NOT NULL " +
                                    "DROP TABLE #Temp3 " +

                                    "create table #Temp1(    POI int,     SKU Varchar(50),     Qty int ) " +
                                    "create table #Temp2(    POI int,     SKU Varchar(50),     Qty int ) " +
                                    "create table #Temp3(    POI int,     SKU Varchar(50),     Qty int ) " +

                                    "insert into #Temp1 " +

                                    "select distinct PO.Purchase_Order_Id, PSM.SKU_Code,Sum(POIS.Quantity) as Quantity " +
                                    "from Product_SKU_Mapping PSM, Purchase_Order PO, Purchase_Order_Item POI,Purchase_Order_Item_Sizes POIS, Product P " +
                                    "where PO.Purchase_Order_Id=POI.Purchase_Order_Id " +
                                    "AND POIS.Purchase_Order_Id = POI.Purchase_Order_Id " +
                                    "AND POI.Article_No=P.Article_No " +
                                    "AND POIS.Purchase_Order_Item_Id =POI.Purchase_Order_Item_Id " +
                                    "AND POI.Colour_Id=PSM.Colour_Id " +
                                    "AND POIS.Size_Id=PSM.Size_Id " +
                                    "AND P.Product_Id=PSM.Product_Id " +
                                    "AND PO.Purchase_Order_Id= @Purchase_Order_Id " +
                                    "group by PSM.SKU_Code, PO.Purchase_Order_Id " +

                                    "insert into #Temp2  " +
                                    "select t.POI,t.SKU,t.Qty-poi.Quantity as Qty from  Purchase_Invoice_Item poi,#temp1 t " +
                                    "where t.POI=poi.Purchase_Order_Id and   t.SKU=poi.SKU_Code " +
                                    
                                    "insert into #Temp3 " +
                                    "SELECT t1.POI,t1.SKU, " +
                                    "case " +
                                    "when t2.Qty is not null then t2.Qty " +
                                    "when t2.Qty is null then t1.Qty " +
                                    "end " +
                                    "as Qty " +
                                    "FROM #Temp1 t1 " +
                                    "LEFT JOIN #Temp2 t2 " +
                                    "ON t1.POI=t2.POI and t1.SKU=t2.SKU " +
                                    "ORDER BY t1.SKU; " +
                                    "select Qty as Quantity, SKU as SKU_Code from #Temp3 where Qty!=0 ";
                        paramList.Add(new SqlParameter("@Purchase_Order_Id", fieldValue));                       
                    }
                }

                if (table_Name == "Purchase_Invoice_Item")
                {
                    if (fieldName == "Purchase_Invoice_Id")
                    {
                        //strquery = " Select Purchase_Invoice_Item.Purchase_Order_Id, Purchase_Invoice_Item.SKU_Code ";
                        //strquery += "from Purchase_Invoice_Item ";
                        //strquery += "where Purchase_Invoice_Item.Purchase_Invoice_Id = @Purchase_Invoice_Id";
                        strquery = "IF OBJECT_ID('tempdb..#Temp1') IS NOT NULL " +
                                    "DROP TABLE #Temp1 " +
                                    "IF OBJECT_ID('tempdb..#Temp2') IS NOT NULL " +
                                    "DROP TABLE #Temp2 " +
                                    "IF OBJECT_ID('tempdb..#Temp3') IS NOT NULL " +
                                    "DROP TABLE #Temp3 " +

                                    "CREATE TABLE #Temp1(    invoice_Id int,    SKU Varchar(50),     Qty int ) " +
                                    "CREATE TABLE #Temp2(    invoice_Id int,    SKU Varchar(50),     Qty int ) " +
                                    "CREATE TABLE #Temp3(    SKU_Code Varchar(50),     Quantity int ) " +

                                    "INSERT INTO #Temp1 " +

                                    "SELECT PII.Purchase_Invoice_Id, PII.SKU_Code, SUM(PRRI.Quantity) AS bal  " +
                                    "FROM Purchase_Invoice_Item PII " +
                                    "JOIN Purchase_Return PRR ON PII.Purchase_Invoice_Id=PRR.Purchase_Invoice_Id " +
                                    "JOIN Purchase_Return_Item PRRI ON PRR.Purchase_Return_Id=PRRI.Purchase_Return_Id " +
                                    "AND PII.SKU_Code=PRRI.SKU_Code AND PII.Purchase_Invoice_Id=@Purchase_Invoice_Id " +
                                    "GROUP BY PII.Purchase_Invoice_Id,PII.SKU_Code,PII.Quantity " +

                                    "INSERT  INTO #Temp2 " +
                                    "SELECT PII.Purchase_Invoice_Id,PII.SKU_Code, SUM(PRRI.Quantity) AS bal " +
                                    "FROM Purchase_Invoice_Item PII " +
                                    "JOIN Purchase_Return_Request PRR ON PII.Purchase_Invoice_Id=PRR.Purchase_Invoice_Id " +
                                    "JOIN Purchase_Return_Request_Item PRRI ON PRR.Purchase_Return_Request_Id=PRRI.Purchase_Return_Request_Id " +
                                    "AND PII.SKU_Code=PRRI.SKU_Code AND PII.Purchase_Invoice_Id=@Purchase_Invoice_Id  AND PRRI.Status=0 " +
                                    "GROUP BY PII.Purchase_Invoice_Id,PII.SKU_Code,PII.Quantity " +

                                    "declare @table1 int, @table2 int "+


                                    "set @table1=(select case when exists (select 1 from #Temp1) then 1 else 0 end) "+

                                    "set @table2=(select case when exists (select 1 from #Temp2) then 1 else 0 end) "+


                                    " IF(@table1=1 and @table2=0 ) "+
                                    "BEGIN "+
                                    "INSERT INTO #Temp3 "+
                                    "SELECT t1.SKU,PII.Quantity-t1.Qty AS Qty "+
                                    "FROM #Temp1 t1,Purchase_Invoice_Item PII WHERE PII.Purchase_Invoice_Id=t1.invoice_Id "+
                                    "END "+


                                    "IF(@table1=0 and @table2=1 ) "+
                                    "BEGIN "+
                                    "INSERT INTO #Temp3 "+
                                    "SELECT t2.SKU,PII.Quantity-t2.Qty AS Qty "+
                                    "FROM #Temp2 t2,Purchase_Invoice_Item PII WHERE PII.Purchase_Invoice_Id=t2.invoice_Id  "+
                                    "END "+


                                    "IF(@table1=1 and @table2=1 ) "+
                                    "BEGIN "+
                                    "INSERT INTO #Temp3 "+
                                    "SELECT t1.SKU,PII.Quantity-(t1.Qty+t2.Qty)AS Qty "+
                                    "FROM #Temp1 t1,#Temp2 t2,Purchase_Invoice_Item PII WHERE PII.Purchase_Invoice_Id=t1.invoice_Id and t2.invoice_Id=t1.invoice_Id "+
                                    "END "+


                                    "IF ((SELECT count(*) FROM #Temp3)>0) " +
                                    "BEGIN " +
                                    "SELECT Quantity, SKU_Code FROM #Temp3 " +
                                    "END " +


                                    "IF @@ROWCOUNT=0 and (SELECT COUNT(*) FROM Purchase_Return WHERE Purchase_Invoice_Id=@Purchase_Invoice_Id )=0 and  ( SELECT COUNT(*) FROM Purchase_Return_Request WHERE Purchase_Invoice_Id=@Purchase_Invoice_Id )=0 " +
                                    "BEGIN " +
                                    "SELECT Quantity, SKU_Code FROM Purchase_Invoice_Item WHERE Purchase_Invoice_Id=@Purchase_Invoice_Id " +
                                    "END " +
                                    "ELSE IF ((SELECT count(*) FROM #Temp1)!=0) " +
                                    "BEGIN " +
                                    "SELECT Quantity, SKU_Code FROM #Temp1 " +
                                    "END "+
                                    "ELSE IF ((SELECT count(*) FROM #Temp2) !=0) " +
                                    "BEGIN " +
                                    "SELECT Quantity, SKU_Code FROM #Temp2 " +
                                    "END "+
                                    "ELSE IF ((SELECT count(*) FROM #Temp3)=0) " +
                                    "BEGIN " +
                                    "SELECT Quantity, SKU_Code FROM #Temp3 " +
                                    "END ";
                        paramList.Add(new SqlParameter("@Purchase_Invoice_Id", fieldValue));
                    }
                }


                if (table_Name == "Sales_Invoice_Item")
                {
                    if (fieldName == "Sales_Invoice_Id")
                    {
                        strquery = " Select Sales_Invoice_Item.Sales_Invoice_Id, Sales_Invoice_Item.SKU_Code ";
                        strquery += "from Sales_Invoice_Item ";
                        strquery += "where Sales_Invoice_Item.Sales_Invoice_Id = @Sales_Invoice_Id";
                        paramList.Add(new SqlParameter("@Sales_Invoice_Id", fieldValue));
                    }
                }


                if (table_Name == "Branch")
                {
                    if (fieldName == "Branch_ID")
                    {
                        strquery += " where Branch_ID in (" + fieldValue + ")";
                        //paramList.Add(new SqlParameter("@Branch_Ids", fieldValue));
                    }
                }

                if (table_Name == "Inventory")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = " Select distinct Inventory.Branch_Id, Branch.Branch_Name ";
                        strquery += "from Inventory inner join Branch on Inventory.Branch_Id=Branch.Branch_ID ";
                    }
                }

                if (table_Name == "Inventorys")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = " Select distinct Inventory.Branch_Id, Inventory.Product_SKU ";
                        strquery += "from Inventory inner join Branch on Inventory.Branch_Id=Branch.Branch_ID where Inventory.Branch_Id in (SELECT * FROM dbo.CSVToTable( '"+ fieldValue +"'))";
                        //strquery += "AND Product_SKU NOT IN (Select Distinct SKU_Code from Sales_Invoice_Item, Sales_Invoice WHERE Sales_Invoice.Sales_Invoice_Id = Sales_Invoice_Item.Sales_Invoice_Id AND Sales_Invoice.Branch_ID IN (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "')))";
                    }
                }


                if (table_Name == "Assign_Branches")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = "select Branch_ID,Branch_Name";
                        strquery += " from Branch where Branch_ID in (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "'))";
                        //strquery += "AND Product_SKU NOT IN (Select Distinct SKU_Code from Sales_Invoice_Item, Sales_Invoice WHERE Sales_Invoice.Sales_Invoice_Id = Sales_Invoice_Item.Sales_Invoice_Id AND Sales_Invoice.Branch_ID IN (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "')))";
                    }
                }

                if (table_Name == "Inventorys")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = " Select distinct Inventory.Branch_Id, Inventory.Product_SKU ";
                        strquery += "from Inventory inner join Branch on Inventory.Branch_Id=Branch.Branch_ID where Inventory.Branch_Id in (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "'))";
                        //strquery += "AND Product_SKU NOT IN (Select Distinct SKU_Code from Sales_Invoice_Item, Sales_Invoice WHERE Sales_Invoice.Sales_Invoice_Id = Sales_Invoice_Item.Sales_Invoice_Id AND Sales_Invoice.Branch_ID IN (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "')))";
                    }
                }

                if (table_Name == "Sales_Invoice")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = " Select distinct Sales_Invoice.Branch_Id, Sales_Invoice.Sales_Invoice_No ";
                        strquery += "from Sales_Invoice inner join Branch on Sales_Invoice.Branch_Id=Branch.Branch_ID where Sales_Invoice.Branch_Id in (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "'))";
                        //strquery += "AND Product_SKU NOT IN (Select Distinct SKU_Code from Sales_Invoice_Item, Sales_Invoice WHERE Sales_Invoice.Sales_Invoice_Id = Sales_Invoice_Item.Sales_Invoice_Id AND Sales_Invoice.Branch_ID IN (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "')))";
                    }
                }

                if (table_Name == "Sales_Return")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = " Select distinct Sales_Return.Branch_Id, Sales_Return.Sales_Return_No ";
                        strquery += "from Sales_Return inner join Branch on Sales_Return.Branch_Id=Branch.Branch_ID where Sales_Return.Branch_Id in (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "'))";
                        //strquery += "AND Product_SKU NOT IN (Select Distinct SKU_Code from Sales_Invoice_Item, Sales_Invoice WHERE Sales_Invoice.Sales_Invoice_Id = Sales_Invoice_Item.Sales_Invoice_Id AND Sales_Invoice.Branch_ID IN (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "')))";
                    }
                }

               

                if (table_Name == "Sales_Invoices")
                {
                    if (fieldName == "Branch_Id")
                    {
                        strquery = " select Sales_Invoice.Sales_Invoice_Id,Sales_Invoice.Sales_Invoice_No  ";
                        strquery += "from Sales_Invoice left JOIN Receivable  ON Receivable.Sales_Invoice_Id=Sales_Invoice.Sales_Invoice_Id";
                        strquery += " left join Branch  on Branch.Branch_Id=Receivable.Branch_ID  where Receivable.Branch_ID in (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "'))";
                        //strquery += "AND Product_SKU NOT IN (Select Distinct SKU_Code from Sales_Invoice_Item, Sales_Invoice WHERE Sales_Invoice.Sales_Invoice_Id = Sales_Invoice_Item.Sales_Invoice_Id AND Sales_Invoice.Branch_ID IN (SELECT * FROM dbo.CSVToTable( '" + fieldValue + "')))";
                    }
                }

               
                //if (table_Name == "Purchase_Invoice")
                //{
                //    if (fieldName == "Purchase_Invoice_Id")
                //    {
                //        strquery = " Select distinct Purchase_Invoice.Vendor_Id,Vendor.Vendor_Name ";
                //        strquery += "from Purchase_Invoice inner join Vendor on Purchase_Invoice.Vendor_Id=Vendor.Vendor_Id";

                      

                //    }
                //}
               
                              
            }

            DataTable dt = sqlHelper.ExecuteDataTable(paramList, strquery, CommandType.Text);

            return dt;
        }

        public string Get_Lookup_Data_Add_For_Subcategory(string field_Value, string table_Name, string[] columns)
        {
            string Value = "";

            string strquery = "";

            string col_Id = "";

            string col_Value = "";

            strquery = "select ";

            for (int i = 0; i < columns.Length; i++)
            {
                strquery += columns[i] + ",";

                col_Id = columns[0].ToString();

                col_Value = columns[1].ToString();
            }

            char[] removeCh = { ',', ' ' };

            strquery = strquery.TrimEnd(removeCh);

            strquery += " from " + table_Name;

            strquery += " where " + table_Name + "." + col_Id + "=" + Convert.ToInt32(field_Value);

            DataTable dt = sqlHelper.ExecuteDataTable(null, strquery, CommandType.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    Value = Convert.ToString(dr[col_Value]);
                }
            }

            return Value;
        }


    }
}
