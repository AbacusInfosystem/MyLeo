using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo
{
    public class QueryInfo
    {
        public string Table { get; set; }

        public List<SelectColumnInfo> Columns { get; set; }

        public bool All_Columns { get; set; }

        public List<WhereInfo> Input_Params { get; set; }

        public Pagination_Info Pager { get; set; }

		public QueryInfo()
		{
			Columns = new List<SelectColumnInfo>();

			Input_Params = new List<WhereInfo>();

			Pager = new Pagination_Info();
		}
    }

    public class SelectColumnInfo
    {
        public string Key { get; set; }

        public string Alias { get; set; }
    }

    public class WhereInfo
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public DataTypeCollection Type { get; set; }

		public string DataOperator
		{
			get;
			set;
		}
    }

	public enum DataOperator
	{
		Equal,
		Like,
		Greaterthan,
		Lessthan,
        In
	}

    public enum DataTypeCollection
    {
        Int,
        String,
        Datetime,
        Boolean
    }
}
