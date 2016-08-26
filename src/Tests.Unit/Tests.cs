using System.Collections.Generic;
using NUnit.Framework;

namespace Tests.Unit
{
	[TestFixture]
	public class Tests
	{
		[TestCase("", 0)]
		[TestCase("A", 50)]
		[TestCase("B", 30)]
		[TestCase("AB", 80)]
		[TestCase("CDBA", 115)]
		public void CalculatesPrice(string items, int total)
		{
			var checkout = new Checkout();

			Assert.That(checkout.Price(items), Is.EqualTo(total));
		}
	}

	public class Checkout
	{

		public int Price(string items)
		{
			if (string.IsNullOrEmpty(items))
				return 0;
			
			var total = 0;
			foreach (var item in items)
			{
				total += ItemPrice(item);
			}
			return total;
		}

		private readonly Dictionary<char, int> _prices = new Dictionary<char, int>()
			{
				{'A', 50},
				{'B', 30},
				{'C', 20},
				{'D', 15},
			};

		private int ItemPrice(char item)
		{
			int price;
			_prices.TryGetValue(item, out price);
			return price;
		}
	}
}
