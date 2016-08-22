using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo
{
    public class GridInfo
    {
        public GridInfo()
        {
            Show_Columns = new List<string>();

            Records = new DataTable();

            Pager = new Pagination_Info();

			Identity_Columns = new List<string>();
        }

        public List<string> Show_Columns { get; set; }

        public bool All_Columns { get; set; }

        public DataTable Records { get; set; }

        public Pagination_Info Pager { get; set; }

		public List<string> Identity_Columns
		{
			get;
			set;
		}
    }
}
