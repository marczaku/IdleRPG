using NUnit.Framework;
using UnityEngine;

namespace Currencies.Tests {
	// case 1: only one class in a namespace => make the namespace to a class
	/*
	 * before:
	 * namespace Multiply {
	 *    class Tests {
	 *    }
	 * }
	 */
	public class Multiply {
		[Test]
		public void Result() {
			var five = Money.Dollar(5);
			Assert.AreEqual(Money.Dollar(10), five.Times(2));
			Assert.AreEqual(Money.Dollar(15), five.Times(3));
		}

		[Test]
		public void ResultWithSEK() {
			var five = Money.SEK(5);
			Assert.AreEqual(Money.SEK(10), five.Times(2)); 
			Assert.AreEqual(Money.SEK(15), five.Times(3));
		}
	
		[Test]
		public void DoesNotAffectOriginalInstance() {
			var five = Money.Dollar(5);
			five.Times(2);
			Assert.AreEqual(Money.Dollar(5), five);
		}
	}

	public class Add {
		// requirement testing
		// acceptance testing
		
		[Test]
		public void ResultForSameCurrencies() {
			var five = Money.Dollar(5);
			Assert.AreEqual(Money.Dollar(10), five.Add(five));
		}
		
		[Test]
		public void DoesNotAffectOriginalInstance() {
			var five = Money.Dollar(5);
			five.Add(five);
			Assert.AreEqual(Money.Dollar(5), five);
		}
		
		[Test]
		public void ResultForDifferentCurrencies() {
			var exchangeRate = 10f;
			var bank = new Bank(exchangeRate);
			var fiveDollars = Money.Dollar(5);
			var hundredSek = Money.SEK(100);
			var sum = fiveDollars.Add(hundredSek); // Wallet || MoneyExpression (it is 5$ & 100 SEK)
			var dollars = bank.ExchangeToDollar(sum); // Bank takes Wallet || MoneyExpression
			Assert.AreEqual(Money.Dollar(15), dollars);
		}
		/*
		// Exercise 3:
		this will require Add to work with IMoney, not only with Money.
		this again will mean, that the wallet works with IMoney instead of Money.
		Hint:
		
		There will be two wallets:
		First: Wallet(5USD, 100SEK)
		Second: Wallet(FirstWallet, 10EUR) 
		[Test]
		public void ResultForMultipleCurrencies() {
			var exchangeRates = ??; // euro -> usd 2:1 sek -> usd 10:1
			var bank = new Bank(exchangeRates);
			var fiveDollars = Money.Dollar(5);
			var hundredSek = Money.SEK(100);
			var twentyEuros = Money.Euro(10);
			var sum = fiveDollars.Add(hundredSek); // Wallet || MoneyExpression (it is 5$ & 100 SEK)
			sum = sum.Add(twentyEuros);
			var dollars = bank.ExchangeToDollar(sum); // Bank takes Wallet || MoneyExpression
			Assert.AreEqual(Money.Dollar(25), dollars);
		}
		
		// TODO 4:
		this will require Add and Times to work with IMoney, not only with Money.
		this again will mean, that the wallet works with IMoney instead of Money.
		(($5 + 100SEK) + 10 EUR) => USD
		(($5 + 100SEK) + 10 EUR) => EUR
		(($5 + 100SEK) + 10 EUR) => SEK
		(($5 + 100SEK) * 2) => EUR
		
		*/
		
		
		
		
		// maybe you want to change new Bank(exchangeRates) to:
		// new Bank(); bank.AddExchangeRate(from: "Dollar", to: "Euro", rate: 2.0);
	}

	

	// case 1: multiple classes in one namespace
	namespace Equal {
		public class SameType {
			[Test]
			public void SameCurrencyAmountsAreEqual() {
				Assert.AreEqual(Money.Dollar(1), Money.Dollar(1));
			}
		
			[Test]
			public void DifferentAmountsAreInEqual() {
				Assert.AreNotEqual(Money.Dollar(1), Money.Dollar(2));
			}
		
			[Test]
			public void DifferentCurrenciesAreUnEqual() {
				Assert.AreNotEqual(Money.Dollar(1), Money.SEK(1));
			}
		}
		public class DifferentType {
			[Test]
			public void OtherTypesAreUnEqual() {
				Assert.AreNotEqual(Money.Dollar(1), 1);
				Assert.False(Money.Dollar(1).Equals(null));
			}
		}
	}
	public class General {
		[Test]
		public void ToStringFormat() {
			Assert.AreEqual("5 Dollar", Money.Dollar(5).ToString());
			Assert.AreEqual("5 SEK", Money.SEK(5).ToString());
		}
	}
}