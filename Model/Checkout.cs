using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
	public class Checkout
	{

        private List<Product> _product { get; set; } = new List<Product>();
		private List<IPricingRule> Rules { get; }
		private List<Product> Items { get; set; } = new List<Product>() { 
			new Product(){ Name="Super iPad",SKU="ipd",Price= 549.99},
		new Product(){ Name="Macbook Pro",SKU="mbp",Price= 1399.99},
		new Product(){ Name="Apple Tv",SKU="atv",Price= 109.50},
		new Product(){ Name="VGA Adapter",SKU="vga",Price= 30},
		};

		public Checkout(List<IPricingRule> rules)
		{
			Rules = rules;
		}
		public void scan(string sku)
		{
			var item = Items.FirstOrDefault(x => x.SKU == sku);
			if(item != null)
			_product.Add(new Product() {Name =item.Name,Price =item.Price,SKU =item.SKU });
		}
		public double total()
		{
			foreach (IPricingRule r in Rules)
			{
				r.ApplyDiscount(_product);
			}
			double result = 0;
			foreach (var item in _product)
			{
				result += item.Price;
			}
			return result;
		}
	}
}
