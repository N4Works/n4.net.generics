using NUnit.Framework;
using System;
using Moq;

namespace N4.Net.Generics.Test
{
	[TestFixture]
	public class BaseModelTest
	{
		/// <summary>
		/// Should be able to create Model.
		/// </summary>
		[Test]
		public void ShouldBeAbleToCreateModel()
		{
			var mockObject = new MockObject(string.Empty);
			Assert.NotNull(mockObject);
		}

		/// <summary>
		/// Should be able to get identifier.
		/// </summary>
		[Test]
		public void ShouldBeAbleToGetId()
		{
			var mockObject = new MockObject("1");
			Assert.NotNull(mockObject);
			Assert.AreEqual("1", mockObject.Id);
		}

		/// <summary>
		/// Should call before dispose on disposing.
		/// </summary>
		[Test]
		public void ShouldCallBeforeDisposeOnDisposing()
		{
			var mockCheckExecution = new Mock<ICheckExecution>();
			using (var mockObject = new MockObject(mockCheckExecution.Object))
			{
			}
			mockCheckExecution.Verify(m => m.Executed(), Times.Once);
		}

		/// <summary>
		/// Should not call before dispose on finalize.
		/// </summary>
		[Test]
		public void ShouldNotCallBeforeDisposeOnFinalize()
		{
			var mockCheckExecution = new Mock<ICheckExecution>();
			var mockObject = new MockObject(mockCheckExecution.Object);
			Assert.NotNull(mockObject);
			mockObject = null;
			GC.Collect();
			mockCheckExecution.Verify(m => m.Executed(), Times.Never);
		}
	}
}
