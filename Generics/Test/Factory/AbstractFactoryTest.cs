using N4.Net.Generics.Factory;
using N4.Net.Generics.Test.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace N4.Net.Generics.Test.Factory
{
    /// <summary>
    /// Test class for factory.
    /// </summary>
    [TestFixture]
    public class AbstractFactoryTest
    {
        /// <summary>
        /// Should be able to register a contract to a class.
        /// </summary>
        [Test]
        public void ShouldBeAbleToRegisterAContractToAClass()
        {
            var factory = new AbstractFactory();
            factory.Register<IMockDependency, MockDependency>();
        }

        /// <summary>
        /// Should be able to register a contract to a class with dependencies.
        /// </summary>
        [Test]
        public void ShouldBeAbleToRegisterAContractToAClassWithDependencies()
        {
            var factory = new AbstractFactory();
            factory.Register<IMockObject, MockObject>(typeof(IMockDependency));
        }

        /// <summary>
        /// Should be able to create an instance from a register.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCreateAnInstanceFromARegister()
        {
            var factory = new AbstractFactory();
            factory.Register<IMockDependency, MockDependency>();
            var dependency = factory.Create<IMockDependency>();
            Assert.NotNull(dependency);
        }

        /// <summary>
        /// Should be able to create an instance from a register with dependencies.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCreateAnInstanceFromARegisterWithDependencies()
        {
            var factory = new AbstractFactory();
            factory.Register<IMockDependency, MockDependency>();
            factory.Register<IMockObject, MockObject>(typeof(IMockDependency));
            var mockObject = factory.Create<IMockObject>();
            Assert.NotNull(mockObject);
        }

        /// <summary>
        /// Should fail to create an instance from an unregistered contract.
        /// </summary>
        [Test]
        public void ShouldFailToCreateAnInstanceFromAnUnregisteredContract()
        {
            var factory = new AbstractFactory();
            Assert.Throws<KeyNotFoundException>(() => factory.Create<IMockObject>());
        }

        /// <summary>
        /// Should be able to create an instance from a register with dependencies.
        /// </summary>
        [Test]
        public void ShouldFailToCreateAnInstanceFromARegisteredContractWithoutDependenciesWhenConstructorDosentCombine()
        {
            var factory = new AbstractFactory();
            factory.Register<IMockObject, MockObject>();
            Assert.Throws<Exception>(() => factory.Create<IMockObject>());
        }

        /// <summary>
        /// Should be able to dispose a factory.
        /// </summary>
        [Test]
        public void ShouldBeAbleToDisposeAFactory()
        {
            var factory = new AbstractFactory();
            factory.Dispose();
        }

        /// <summary>
        /// Should be able to unregister a contract type.
        /// </summary>
        [Test]
        public void ShouldBeAbleToUnregisterAContract()
        {
            var factory = new AbstractFactory();
            factory.Register<IMockObject, MockObject>();
            factory.Unregister<IMockObject>();
            Assert.Throws<KeyNotFoundException>(() => factory.Create<IMockObject>());
        }
    }
}
