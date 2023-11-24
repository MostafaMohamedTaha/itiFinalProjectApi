using System.Collections.Generic;

namespace Talabat.Core.Entities
{
	public class Basket : BaseEntity
	{
		public List<BasketItem> Items { get; set; }
	}
}
