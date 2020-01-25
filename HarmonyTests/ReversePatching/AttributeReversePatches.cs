using HarmonyLib;
using HarmonyLibTests.Assets;
using NUnit.Framework;

namespace HarmonyLibTests
{
	[TestFixture]
	public class AttributeReversePatches
	{
		[Test]
		public void Test_ReversePatchingWithAttributes()
		{
			var test = new Class1Reverse();

			var result1 = test.Method("Foo", 123);
			Assert.AreEqual("FooExtra123", result1);

			//Harmony.DEBUG = true;
			var instance = new Harmony("test");
			Assert.IsNotNull(instance);

			var processor = instance.ProcessorForAnnotatedClass(typeof(Class1ReversePatch));
			Assert.IsNotNull(processor);
			Assert.IsNotNull(processor.Patch());

			var result2 = test.Method("Bar", 456);
			Assert.AreEqual("PrefixedExtra456Bar", result2);
		}
	}
}