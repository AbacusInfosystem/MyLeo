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
                        strquery = "select distinct Sum(POIS.Quantity) as Quantity, PSM.SKU_Code ";
                        strquery += "from Product_SKU_Mapping PSM, Purchase_Order PO, Purchase_Order_Item POI,Purchase_Order_Item_Sizes POIS, Product P ";
                        strquery += "where ";
                        strquery += "PO.Purchase_Order_Id=POI.Purchase_Order_Id ";
                        strquery += "AND POIS.Purchase_Order_Id = POI.Purchase_Order_Id  ";
                        strquery += "AND POI.Article_No=P.Article_No  ";
                        strquery += "AND POIS.Purchase_Order_Item_Id =POI.Purchase_Order_Item_Id ";
                        strquery += "AND POI.Colour_Id=PSM.Colour_Id ";
                        strquery += "AND POIS.Size_Id=PSM.Size_Id ";
                        strquery += "AND P.Product_Id=PSM.Product_Id  ";                        
                        strquery += "AND PO.Purchase_Order_Id= @Purchase_Order_Id ";
                        strquery += "group by PO.Purchase_Order_Id, PSM.SKU_Code ";
                        paramList.Add(new SqlParameter("@Purchase_Order_Id", fieldValue));                       
                    }
                }

                if (table_Name == "Purchase_Invoice_Item")
                {
                    if (fieldName == "Purchase_Invoice_Id")
                    {
                        strquery = " Select Purchase_Invoice_Item.Purchase_Order_Id, Purchase_Invoice_Item.SKU_Code ";
                        strquery += "from Purchase_Invoice_Item ";
                        strquery += "where Purchase_Invoice_Item.Purchase_Invoice_Id = @Purchase_Invoice_Id";
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
