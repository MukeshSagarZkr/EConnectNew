
using System.Collections.Generic;

namespace WebApi.Models
{
	public class MenuItem
	{
		//public string MenuId { get; set; }
		public string name { get; set; }
		//public string Url { get; set; }
	   // public string icon { get; set; }
		public bool title { get; set; }
	   // public string ParentMenuId { get; set; }
	}

	public class ChildMenuItem
	{
		public string MenuId { get; set; }
		public string name { get; set; }
		public string url { get; set; }
		public bool title { get; set; }
		public bool read { get; set; }
		public bool write { get; set; }
		public bool delete { get; set; }
		public bool copydata { get; set; }
		public bool printdata { get; set; }
		public bool exportexcel { get; set; }
		public bool update { get; set; }

		public string icon { get; set; }
		public string ParentMenuId { get; set; }
		public IEnumerable<ChildMenuItem> children = null;
	}

	public class classtitle
	{
		public bool title { get; set; }
		public string name { get; set; }
	}

	public class classtitle2
	{
		public IEnumerable<classtitle> title = null;
		public IEnumerable<ChildMenuItem> ChildMenuItem = null;
	}

}