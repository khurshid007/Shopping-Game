using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
	public class PricingRuleBuyNGetN : IPricingRule
	{
		private string _sku { get; set; }
		private int _buy { get; set; }
		private int _get { get; set; }
		public PricingRuleBuyNGetN(string sku, int buy, int get)
		{
			_sku = sku;
			_buy = buy;
			_get = get;
		}
		public void ApplyDiscount(List<Product> products)
		{
			decimal discountPercentage = 100 / (_buy + _get);
			var items = products.Where(x => x.SKU == _sku).ToList();
			int i = 0;
			foreach (var item in items)
			{
				if (i == _buy)
				{
					item.Price = 0;
					i = 0;
				}
				else
					i++;
			}
		}
	}

}
