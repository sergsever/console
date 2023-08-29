using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.data
{
	public class Item
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public Item() { }
		public override string ToString()
		{
			return "item: " + Id.ToString() + " " + Name;
		}
	}
}
