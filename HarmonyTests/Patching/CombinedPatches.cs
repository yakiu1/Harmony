using HarmonyLib;
using HarmonyLibTests.Assets;
using NUnit.Framework;
using System.Collections.Generic;

namespace HarmonyLibTests
{
	[TestFixture]
	public class CombinedPatches
	{
		[Test]
		public void Test_ManyFinalizers()
		{
			var originalClass = typeof(Assets.CombinedPatchClass);
			Assert.IsNotNull(originalClass);
			var patchClass = typeof(Assets.CombinedPatchClass_Patch_1);
			Assert.IsNotNull(patchClass);

			var harmonyInstance = new Harmony("test");
			Assert.IsNotNull(harmonyInstance);

			var processor = harmonyInstance.ProcessorForAnnotatedClass(patchClass);
			Assert.IsNotNull(processor);
			Assert.IsNotNull(processor.Patch());

			CombinedPatchClass_Patch_1.counter = 0;
			var instance = new CombinedPatchClass();
			instance.Method1();
			Assert.AreEqual("tested", instance.Method2("test"));
			instance.Method3(123);
			Assert.AreEqual(4, CombinedPatchClass_Patch_1.counter);
		}

		[Test]
		public static void Test_Method11()
		{
			var originalClass = typeof(Class14);
			Assert.IsNotNull(originalClass);
			var patchClass = typeof(Class14Patch);
			Assert.IsNotNull(patchClass);

			var harmonyInstance = new Harmony("test");
			Assert.IsNotNull(harmonyInstance);

			var processor = harmonyInstance.ProcessorForAnnotatedClass(patchClass);
			Assert.IsNotNull(processor);
			Assert.IsNotNull(processor.Patch());

			_ = new Class14().Test("Test1", new KeyValuePair<string, int>("1", 1));
			_ = new Class14().Test("Test2", new KeyValuePair<string, int>("1", 1), new KeyValuePair<string, int>("2", 2));

			Assert.AreEqual("Prefix0", Class14.state[0]);
			Assert.AreEqual("Test1", Class14.state[1]);
			Assert.AreEqual("Postfix0", Class14.state[2]);
			Assert.AreEqual("Prefix1", Class14.state[3]);
			Assert.AreEqual("Test2", Class14.state[4]);
			Assert.AreEqual("Postfix1", Class14.state[5]);
		}
	}
}