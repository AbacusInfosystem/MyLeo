using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeoRetailerInfo.Common
{
	public class ExceptionInfo
	{
		public ExceptionInfo()
		{

		}

		public string Code
		{
			get;
			set;
		}

		public MessageType Type
		{
			get;
			set;
		}

		public string Text
		{
			get;
			set;
		}

		public int TextLength
		{
			get
			{
				return Text.Length;
			}
		}

		public string ExceptionMessage
		{
			get;
			set;
		}

		public string StackTrace
		{
			get;
			set;
		}
	}
}
