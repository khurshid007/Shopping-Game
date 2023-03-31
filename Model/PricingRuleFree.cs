using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
	public class PricingRuleFree : IPricingRule
	{
		private string _buy { get; set; }
		private string _get { get; set; }
		public PricingRuleFree(string buySKU, string getSKU)
		{
			_buy = buySKU;
			_get = getSKU;
		}
		public void ApplyDiscount(List<Product> products)
		{
			var SellItem = products.Where(x => x.SKU == _buy).ToList();
			var offerItem = products.Where(x => x.SKU == _get).ToList();
			int sellItemCount = SellItem.Count();
			int i=0;
			foreach (var item in offerItem)
            {
				if (i < sellItemCount)
					item.Price = 0;
				i++;
            }
		}
	}
}
