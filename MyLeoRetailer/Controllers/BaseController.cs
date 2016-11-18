using MyLeoRetailer.Common;
using MyLeoRetailerHelper;
using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Branch;
using MyLeoRetailerInfo.Category;
using MyLeoRetailerInfo.Common;
using MyLeoRetailerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyLeoRetailer.Controllers
{
    public class BaseController : Controller
    {

		//public CategoryInfo category = null;

		public GridInfo Set_Grid_Details(bool all_Columns, string show_Columns, string identity_Columns)
		{
			GridInfo grid = new GridInfo();

			grid.All_Columns = all_Columns;

			grid.Show_Columns = show_Columns.Split(',').ToList();

			grid.Identity_Columns = identity_Columns.Split(',').ToList();

			return grid;
		}

		public QueryInfo Set_Query_Details(bool all_Columns, string select_Columns, string columns_alias, string table_Name, string where_Columns, string where_Values, string data_Operators)
		{
			QueryInfo query = new QueryInfo();

			query.All_Columns = all_Columns;

			query.Table = table_Name;

			if(all_Columns == false)
			{
				List<string> selected_Column_List = select_Columns.Split(',').ToList();

				List<string> columns_alias_List = columns_alias.Split(',').ToList();

				if(selected_Column_List.Count == columns_alias_List.Count)
				{
					for(int i = 0; i < selected_Column_List.Count; i++)
					{
						query.Columns.Add(new SelectColumnInfo
						{
							Alias = columns_alias_List[i],
							Key = selected_Column_List[i]
						});
					}
				}
				else
				{
					for(int i = 0; i < selected_Column_List.Count; i++)
					{
						query.Columns.Add(new SelectColumnInfo
						{
							Alias = selected_Column_List[i],
							Key = selected_Column_List[i]
						});
					}
				}
			}

			if(!string.IsNullOrEmpty(where_Columns) && !string.IsNullOrEmpty(where_Values) && !string.IsNullOrEmpty(data_Operators))
			{
				List<string> where_Column_List = where_Columns.Split(',').ToList();

				List<string> where_Value_List = where_Values.Split(',').ToList();

				List<string> data_Operators_List = data_Operators.Split(',').ToList();

				if(where_Column_List.Count == where_Value_List.Count)
				{
					for(int i = 0; i < where_Column_List.Count; i++)
					{
						query.Input_Params.Add(new WhereInfo
						{
							Key = where_Column_List[i],
							Value = where_Value_List[i],
							DataOperator = data_Operators_List[i]
						});
					}

				}
			}


			return query;
		}

		public void Set_Date_Session(object obj)
		{
            LoginInfo Cookies = Utility.Get_Login_User("MyLeoLoginInfo", "MyLeoToken", "Branch_Ids");

			PropertyInfo prop = obj.GetType().GetProperty("Created_Date");

			prop.SetValue(obj, DateTime.Now);

			prop = obj.GetType().GetProperty("Updated_Date");

			prop.SetValue(obj, DateTime.Now);

            //Change by Gauravi 21-10-2016//

			prop = obj.GetType().GetProperty("Created_By");

            prop.SetValue(obj, Cookies.User_Id);

			prop = obj.GetType().GetProperty("Updated_By");

            prop.SetValue(obj, Cookies.User_Id);

            //END//
		}

		public void Set_Pagination(Pagination_Info pager, GridInfo grid)
		{
			if(grid.Records.Rows.Count != 0)
			{
				pager.TotalRecords = grid.Records.Rows.Count;
                
				pager.PageHtmlString = PageHelper.NumericPagerForAtlant(pager.TotalRecords, pager.CurrentPage, pager.PageSize, pager.PageLimit, pager.StartPage, pager.EndPage, pager.IsFirst, pager.IsPrevious, pager.IsNext, pager.IsLast, pager.IsPageAndRecordLabel, pager.DivObject, pager.CallBackMethod);

				if(grid.Records.Rows.Count > 0)
				{
					grid.Records = PageHelper.Skip_Take_Records(grid.Records, pager.CurrentPage, pager.PageSize);
				}
			}
		}
           
     
        public BranchInfo Set_Branch(string BranchIds)
        {
            BranchInfo Branch= new BranchInfo();

            BranchRepo branchRepo = new BranchRepo();

            string[] Ids = BranchIds.Split(',');

            if (Ids.Length == 1)
            {
                Branch.Branch_ID = Convert.ToInt32(Ids[0]);

                Branch = branchRepo.Get_Branch_By_Id(Branch.Branch_ID);               
            }

            return Branch;
        }

		//public void Set_Sestion()
		//{
		//	category = new CategoryInfo();

		//	category.Category_Id = 1;
		//}

    }
}
