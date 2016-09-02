using MyLeoRetailerInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerRepo.Utility
{
	public class SQL_Repo
	{
		private string _sqlCon = string.Empty;

		public SQL_Repo()
		{
			_sqlCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
		}

		public SQL_Repo(string con)
		{
			_sqlCon = ConfigurationManager.ConnectionStrings[con].ToString();
		}

		public DataSet ExecuteDataSet(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
		{
			DataSet ds = new DataSet();
			try
			{
				using(SqlConnection con = new SqlConnection(_sqlCon))
				{
					using(SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
					{

						//SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
						sqlCmd.CommandType = cmdType;
						sqlCmd.CommandTimeout = 300;
						if(sqlParams != null)
						{
							foreach(SqlParameter sqlPrm in sqlParams)
							{
								if(sqlPrm.Value == null)
									sqlPrm.Value = DBNull.Value;
							}
							sqlCmd.Parameters.AddRange(sqlParams.ToArray());
						}

						SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
						sqlDA.Fill(ds);
					}
				}
			}
			catch(SqlException sqlEx)
			{
				throw sqlEx;
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return ds;
		}

		public DataTable ExecuteDataTable(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
		{
			DataTable dt = new DataTable();
			try
			{
				using(SqlConnection con = new SqlConnection(_sqlCon))
				{
					using(SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
					{

						//SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
						sqlCmd.CommandType = cmdType;
						sqlCmd.CommandTimeout = 300;
						if(sqlParams != null)
						{
							foreach(SqlParameter sqlPrm in sqlParams)
							{
								if(sqlPrm.Value == null)
									sqlPrm.Value = DBNull.Value;
							}
							sqlCmd.Parameters.AddRange(sqlParams.ToArray());
						}

						SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
						sqlDA.Fill(dt);
					}
				}
			}
			catch(SqlException sqlEx)
			{
				throw sqlEx;
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return dt;
		}

		public SqlDataReader ExecuteDataReader(SqlConnection con, List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
		{
			SqlDataReader dr;

			try
			{
				using(con)
				{
					//con.Open();
					SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
					sqlCmd.CommandType = cmdType;
					sqlCmd.CommandTimeout = 300;

					if(sqlParams != null)
					{
						foreach(SqlParameter sqlPrm in sqlParams)
						{
							if(sqlPrm.Value == null)
								sqlPrm.Value = DBNull.Value;
						}
						sqlCmd.Parameters.AddRange(sqlParams.ToArray());
					}

					dr = sqlCmd.ExecuteReader();
					//con.Close();
				}
			}
			catch(SqlException sqlEx)
			{
				if(con != null)
					con.Close();

				throw sqlEx;
			}
			catch(Exception ex)
			{
				if(con != null)
					con.Close();

				throw ex;
			}

			return dr;
		}

		public void ExecuteNonQuery(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
		{
			SqlConnection con = new SqlConnection();
			try
			{
				using(con = new SqlConnection(_sqlCon))
				{
					con.Open();
					using(SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
					{

						//SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
						sqlCmd.CommandType = cmdType;

						if(sqlParams != null)
						{
							foreach(SqlParameter sqlPrm in sqlParams)
							{
								if(sqlPrm.Value == null)
									sqlPrm.Value = DBNull.Value;
							}
							sqlCmd.Parameters.AddRange(sqlParams.ToArray());
						}

						sqlCmd.ExecuteNonQuery();
						con.Close();
					}
				}
			}
			catch(SqlException sqlEx)
			{
				if(con != null)
					con.Close();

				throw sqlEx;
			}
			catch(Exception ex)
			{
				if(con != null)
					con.Close();

				throw ex;
			}
		}

		public object ExecuteScalerObj(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
		{
			SqlConnection con = new SqlConnection();

			object result = 0;
			try
			{
				using(con = new SqlConnection(_sqlCon))
				{
					con.Open();
					using(SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
					{

						//SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
						sqlCmd.CommandType = cmdType;

						if(sqlParams != null)
						{
							foreach(SqlParameter sqlPrm in sqlParams)
							{
								if(sqlPrm.Value == null)
									sqlPrm.Value = DBNull.Value;
							}
							sqlCmd.Parameters.AddRange(sqlParams.ToArray());
						}

						result = sqlCmd.ExecuteScalar();
						con.Close();
					}
				}
			}
			catch(SqlException sqlEx)
			{
				if(con != null)
					con.Close();

				throw sqlEx;
			}
			catch(Exception ex)
			{
				if(con != null)
					con.Close();

				throw ex;
			}
			return result;
		}

		public void ExecuteNonQueryWithTransaction(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType, SqlTransaction transaction, SqlConnection con)
		{
			try
			{
				SqlCommand sqlCmd = new SqlCommand(sqlQuery, con, transaction);

				sqlCmd.CommandType = cmdType;

				if(sqlParams != null)
				{
					foreach(SqlParameter sqlPrm in sqlParams)
					{
						if(sqlPrm.Value == null)
							sqlPrm.Value = DBNull.Value;
					}
					sqlCmd.Parameters.AddRange(sqlParams.ToArray());
				}

				sqlCmd.ExecuteNonQuery();
			}
			catch(SqlException sqlEx)
			{
				if(con != null)
					throw sqlEx;
			}
			catch(Exception ex)
			{
				if(con != null)
					throw ex;
			}
		}

		public object ExecuteScalerObjWithTransaction(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType, SqlTransaction transaction, SqlConnection con)
		{

			object result = 0;

			try
			{
				SqlCommand sqlCmd = new SqlCommand(sqlQuery, con, transaction);

				sqlCmd.CommandType = cmdType;

				if(sqlParams != null)
				{
					foreach(SqlParameter sqlPrm in sqlParams)
					{
						if(sqlPrm.Value == null)
							sqlPrm.Value = DBNull.Value;
					}
					sqlCmd.Parameters.AddRange(sqlParams.ToArray());
				}

				result = sqlCmd.ExecuteScalar();
			}
			catch(SqlException sqlEx)
			{
				if(con != null)
					throw sqlEx;
			}
			catch(Exception ex)
			{
				if(con != null)
					throw ex;
			}

			return result;
		}

		public DataTable Get_Table(QueryInfo query_Details)
		{
			DataTable dt = null;

			if(query_Details.All_Columns)
			{
				dt = this.ExecuteDataTable(null, "SELECT * FROM " + query_Details.Table, CommandType.Text);
			}
			else
			{
				StringBuilder query = new StringBuilder();

				query.Append("SELECT ");

				foreach(var item in query_Details.Columns)
				{
					query.Append(item.Key + " ");

					if(!string.IsNullOrEmpty(item.Alias))
					{
						query.Append("AS " + item.Alias + ", ");
					}
				}

				query.Append(query.Remove(query.Length - 2, 2));

				query.Append("FROM " + query_Details.Table);

				dt = this.ExecuteDataTable(null, query.ToString(), CommandType.Text);
			}


			return dt;
		}

		public DataTable Get_Table_With_Where(QueryInfo query_Details)
		{
			DataTable dt = null;

			StringBuilder query = new StringBuilder();

			if(query_Details.All_Columns)
			{
				query.Append("SELECT * FROM " + query_Details.Table + " ");
			}
			else
			{
				query.Append("SELECT ");

				foreach(var item in query_Details.Columns)
				{
					query.Append(item.Key + " ");

					if(!string.IsNullOrEmpty(item.Alias))
					{
						query.Append("AS " + item.Alias + ", ");
					}
				}

				//query.Append(query.Remove(query.Length - 2, 2));

				query = query.Remove(query.Length - 2, 1);

				query.Append("FROM " + query_Details.Table + " ");

			}

			if(query_Details.Input_Params.Count > 0)
			{
				query.Append("WHERE ");

				foreach(var item in query_Details.Input_Params)
				{
					if(!string.IsNullOrEmpty(item.Value))
					{
						if(item.DataOperator == DataOperator.Like.ToString())
						{
							query.Append("" + item.Key + " like '%" + item.Value + "%' AND ");
						}
						else if(item.DataOperator == DataOperator.Equal.ToString())
						{
							query.Append("" + item.Key + " = '" + item.Value + "' AND ");
						}
						else if(item.DataOperator == DataOperator.Lessthan.ToString())
						{
							query.Append("" + item.Key + " < '" + item.Value + "' AND ");
						}
						else if(item.DataOperator == DataOperator.Greaterthan.ToString())
						{
							query.Append("" + item.Key + " > '" + item.Value + "' AND ");
						}
					}
				}

				query = query.Remove(query.ToString().Length - 4, 4);
			}

			//dt = this.ExecuteDataTable(null, query.ToString().Remove(query.ToString().Length - 4, 4), CommandType.Text);

			dt = this.ExecuteDataTable(null, query.ToString(), CommandType.Text);

			return dt;
		}

	}
}
