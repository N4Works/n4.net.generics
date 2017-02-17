using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace N4.Net.Generics.Factory
{
    /// <summary>
    /// Class Factory.
    /// </summary>
    public class AbstractFactory : Disposable
    {
        private ConcurrentDictionary<Type, FactoryRegister> _registers;

        /// <summary>
        /// Instantiate a new AbstractFactory. 
        /// </summary>
        public AbstractFactory()
        {
            this._registers = new ConcurrentDictionary<Type, FactoryRegister>();
        }

        /// <summary>
        /// Register a contract to a class.
        /// </summary>
        /// <typeparam name="T">Contract type.</typeparam>
        /// <typeparam name="K">Class type.</typeparam>
        /// <param name="dependencies">List of dependencies.</param>
        public void Register<T, K>(params Type[] dependencies) where K : T
        {
            var register = new FactoryRegister(typeof(T), typeof(K), dependencies);
            _registers.TryAdd(typeof(T), register);
        }

        /// <summary>
        /// Unregister a contract.
        /// </summary>
        /// <typeparam name="T">Contract type.</typeparam>
        /// <returns>Factory register.</returns>
        public FactoryRegister Unregister<T>()
        {
            FactoryRegister register;
            _registers.TryRemove(typeof(T), out register);
            return register;
        }

        /// <summary>
        /// Instantiate a class from contract type.
        /// </summary>
        /// <typeparam name="T">Contract type</typeparam>
        /// <returns>Class object.</returns>
        public T Create<T>()  
        {
            return (T) this.Create(typeof(T));            
        }

        /// <summary>
        /// Instantiate a class from contract type.
        /// </summary>
        /// <param name="contractType">Contract type</param>
        /// <returns>Class object.</returns>
        public object Create(Type contractType)
        {
            FactoryRegister register;
            if (_registers.TryGetValue(contractType, out register))
            {
                return this.Resolve(register);
            }

            throw new KeyNotFoundException(string.Format("Register for '{0}' not found.", contractType.Name));
        }

        /// <summary>
        /// Resolve the instiation configured on register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>The instatiated class</returns>
        private object Resolve(FactoryRegister register)
        {
            object instance;
            if (this.TrySimpleResolve(register, out instance))
            {
                return instance;
            }

            if (this.TryDependencieResolve(register, out instance))
            {
                return instance;
            }

            throw new Exception(string.Format("It was not possible to instantiate '{0}' from contract '{1}'.", register.ClassType.Name, register.ContractType.Name));
        }

        /// <summary>
        /// Try to resolve the instantiation calling parameterless constructor.
        /// </summary>
        /// <param name="register">Factory register.</param>
        /// <param name="instance">The instance.</param>
        /// <returns>If set to <c>true</c>, instance was created.</returns>
        private bool TrySimpleResolve(FactoryRegister register, out object instance)
        {
            instance = null;
            if (register.Dependencies.Length == 0)
            {
                if (register.ClassType.GetConstructor(Type.EmptyTypes) == null)
                {
                    return false;
                }

                instance = Activator.CreateInstance(register.ClassType);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Try to resolve the instantiation calling constructor with dependencies.
        /// </summary>
        /// <param name="register">Factory register.</param>
        /// <param name="instance">The instance.</param>
        /// <returns>If set to <c>true</c>, instance was created.</returns>
        private bool TryDependencieResolve(FactoryRegister register, out object instance)
        {
            instance = null;
            var dependenciesInstances = new List<object>(register.Dependencies.Length);
            for (int i = 0; i < register.Dependencies.Length; i++)
            {
                dependenciesInstances.Add(this.Create(register.Dependencies[i]));
            }
            if (register.ClassType.GetConstructor(register.Dependencies) != null)
            {
                instance = Activator.CreateInstance(register.ClassType, dependenciesInstances.ToArray());
            }            
            return instance != null;
        }

        /// <summary>
        /// Releases all resource created by developer.
        /// </summary>
        protected override void BeforeDispose()
        {
            this._registers.Clear();
            this._registers = null;
        }
    }
}
