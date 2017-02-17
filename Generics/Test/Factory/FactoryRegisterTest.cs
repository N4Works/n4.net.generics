using N4.Net.Generics.Factory;
using N4.Net.Generics.Test.Mocks;
using NUnit.Framework;
using System;
using System.Linq;

namespace N4.Net.Generics.Test.Factory
{
    /// <summary>
    /// Factory Register Test Class.
    /// </summary>
    [TestFixture]
    class FactoryRegisterTest
    {
        /// <summary>
        /// Should be able to create a new instance of FactoryRegister.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCreateAFactoryRegister()
        {
            var register = new FactoryRegister(typeof(IMockObject), typeof(MockObject), new Type[] { typeof(IMockDependency) });
            Assert.NotNull(register);
        }

        /// <summary>
        /// Should be able to read FactoryRegister properties.
        /// </summary>
        [Test]
        public void ShouldBeAbleToReadProperties()
        {
            var register = new FactoryRegister(typeof(IMockObject), typeof(MockObject), new Type[] { typeof(IMockDependency) });
            Assert.AreEqual(typeof(IMockObject), register.ContractType);
            Assert.AreEqual(typeof(MockObject), register.ClassType);
            Assert.AreEqual(1, register.Dependencies.Length);
            Assert.AreEqual(typeof(IMockDependency), register.Dependencies.First());
        }
    }
}
