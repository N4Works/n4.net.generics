using System;

namespace N4.Net.Generics.Factory
{
    /// <summary>
    /// Register class.
    /// </summary>
    public class FactoryRegister
    {
        private Type[] _dependencies;
        private Type _contractType;
        private Type _classType;

        /// <summary>
        /// Initialize a new instance for FactoryRegister.
        /// </summary>
        /// <param name="contractType">Contract type.</param>
        /// <param name="classType">Class type.</param>
        /// <param name="dependencies">List of dependencies</param>
        public FactoryRegister(Type contractType, Type classType, Type[] dependencies)
        {
            this._contractType = contractType;
            this._classType = classType;
            this._dependencies = dependencies;
            
        }


        /// <summary>
        /// Get the contract type.
        /// </summary>
        public Type ContractType {
            get
            {
                return this._contractType;
            }
        }

        /// <summary>
        /// Get the class Type.
        /// </summary>
        public Type ClassType {
            get
            {
                return this._classType;
            } 
        }

        /// <summary>
        /// Get the dependencies to constructor of Class type.
        /// </summary>
        public Type[] Dependencies {
            get
            {
                return this._dependencies;
            }
        }
    }
}
