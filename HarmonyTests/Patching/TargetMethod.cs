using HarmonyLib;
using HarmonyLibTests.Assets;
using NUnit.Framework;
using System;

namespace HarmonyLibTests
{
	[TestFixture]
	public class TargetMethod
	{
		[Test]
		public void Test_TargetMethod_Returns_Null()
		{
			var patchClass = typeof(Class15Patch);
			Assert.NotNull(patchClass);

			var harmonyInstance = new Harmony("test");
			Assert.NotNull(harmonyInstance);

			var processor = harmonyInstance.ProcessorForAnnotatedClass(patchClass);
			Assert.NotNull(processor);

			Exception exception = null;
			try
			{
				Assert.NotNull(processor.Patch());
			}
			catch (Exception ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
			Assert.True(exception.Message.Contains("returned an unexpected result: null"));
		}

		[Test]
		public void Test_TargetMethod_Returns_Wrong_Type()
		{
			var patchClass = typeof(Class16Patch);
			Assert.NotNull(patchClass);

			var harmonyInstance = new Harmony("test");
			Assert.NotNull(harmonyInstance);

			var processor = harmonyInstance.ProcessorForAnnotatedClass(patchClass);
			Assert.NotNull(processor);

			Exception exception = null;
			try
			{
				Assert.NotNull(processor.Patch());
			}
			catch (Exception ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
			Assert.True(exception.Message.Contains("has wrong return type"));
		}

		[Test]
		public void Test_TargetMethods_Returns_Null()
		{
			var patchClass = typeof(Class17Patch);
			Assert.NotNull(patchClass);

			var harmonyInstance = new Harmony("test");
			Assert.NotNull(harmonyInstance);

			var processor = harmonyInstance.ProcessorForAnnotatedClass(patchClass);
			Assert.NotNull(processor);

			Exception exception = null;
			try
			{
				Assert.NotNull(processor.Patch());
			}
			catch (Exception ex)
			{
				exception = ex;
			}
			Assert.NotNull(exception);
			Assert.True(exception.Message.Contains("returned an unexpected result: some element was null"));
		}
	}
}