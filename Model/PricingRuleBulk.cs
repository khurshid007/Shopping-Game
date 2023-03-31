using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{


	public class PricingRuleBulk : IPricingRule
	{
		private string SellSKU { get; }
		private int MinQty { get; }
		private double FixPrice { get; }

		public PricingRuleBulk(string _sellSKU, int MinQty, double FixPrice)
		{
			SellSKU = _sellSKU;
			this.MinQty = MinQty;
			this.FixPrice = FixPrice;
		}
		public void ApplyDiscount(List<Product> products)
		{
			var SellItem = products.Where(x => x.SKU == SellSKU).ToList();
			int numberOfItem = SellItem.Count();
			if (numberOfItem > MinQty)
				foreach (var item in SellItem)
				{
					item.Price = FixPrice;
				}
		}
	}
}
