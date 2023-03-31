using ConsoleApp1.Interface;
using ConsoleApp1.Model;
public class Program
{
	public static void Main()
	{
		//Example 1
		IPricingRule rule = new PricingRuleBuyNGetN("atv", 2, 1);
		List<IPricingRule> rules = new List<IPricingRule>();
		rules.Add(rule);
		Checkout checkout = new Checkout(rules);
		checkout.scan("atv");
		checkout.scan("atv");
		checkout.scan("atv");
		checkout.scan("vga");
		Console.WriteLine("buy 2 get 1 atv total: " + checkout.total());

		//Example 2

		IPricingRule rule1 = new PricingRuleBulk("ipd",4,499.99);
		List<IPricingRule> rules1 = new List<IPricingRule>();
		rules1.Add(rule1);
		Checkout checkout1 = new Checkout(rules1);
		checkout1.scan("atv");
		checkout1.scan("ipd");
		checkout1.scan("ipd");
		checkout1.scan("atv");
		checkout1.scan("ipd");
		checkout1.scan("ipd");
		checkout1.scan("ipd");
		Console.WriteLine("bulk example total:-" + checkout1.total());


		//Example 3

		IPricingRule rule2 = new PricingRuleFree("mbp", "vga");
		List<IPricingRule> rules2 = new List<IPricingRule>();
		rules2.Add(rule2);
		Checkout checkout2 = new Checkout(rules2);

		checkout2.scan("mbp");
		checkout2.scan("vga");
		checkout2.scan("ipd");
		Console.WriteLine("buy mbp get vga total: " + checkout2.total());
		Console.ReadKey();
	}
}

