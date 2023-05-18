using System;
using Entities.Abstract;

namespace Entities.Concrete
{
	// çıplak Class kalmasın
	public class Category:IEntity
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }

	}
}

