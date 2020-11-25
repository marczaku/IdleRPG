using NUnit.Framework;

namespace Currencies.Tests {

	public class CSharpTests {
		[Test]
		public void NewInstancesAreNotTheSame() {
			Assert.AreNotSame(new object(), new object());
		}
	}

	public class RandomTests {
		[Test]
		public void RangeMaxIsNotInclusive() {
			// write a test here that for example rolls 100 times (1-6) and tests, if 6 was included or not. 
		}
	}
	
	public class CurrencyTests {
		public class Multiply {
			[Test]
			public void Result() {
				var five = new Dollar(5);
				Assert.AreEqual(new Dollar(10), five.Times(2));
				Assert.AreEqual(new Dollar(15), five.Times(3));
			}
		
			[Test]
			public void DoesNotAffectOriginalInstance() {
				var five = new Dollar(5);
				five.Times(2);
				Assert.AreEqual(new Dollar(5), five);
			}
		}
		

		[Test]
		public void EqualsTests() {
			Assert.AreEqual(new Dollar(1), new Dollar(1));
			Assert.AreNotEqual(new Dollar(1), new Dollar(2));
			Assert.AreNotEqual(new Dollar(1), 1);
			Assert.False(new Dollar(1).Equals(null));
		}
		
		[Test]
		public void ToStringFormat() {
			Assert.AreEqual("5 Dollar", new Dollar(5).ToString());
		}

		[Test]
		public void MultiplySEK() {
			var five = new SEK(5);
			Assert.AreEqual(new SEK(10), five.Times(2)); 
			Assert.AreEqual(new SEK(15), five.Times(3));
		}
	}
}