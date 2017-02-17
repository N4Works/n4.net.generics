using N4.Net.Generics.Model;

namespace N4.Net.Generics.Test.Mocks
{
    /// <summary>
    /// Class mock object.
    /// </summary>
    public class MockObject : BaseModel, IMockObject
    {
        private ICheckExecution _checkExecution;

        /// <summary>
        /// Instantiate a new instance of MockObject.
        /// </summary>
        /// <param name="checkExecution">Object to check execution.</param>
        public MockObject(ICheckExecution checkExecution)
        {
            this._checkExecution = checkExecution;
        }

        /// <summary>
        /// Instantiate a new instance of MockObject.
        /// </summary>
        /// <param name="dependency">Dependency object.</param>
        public MockObject(IMockDependency dependency)
        {
            this.Dependency = dependency;
        }

        /// <summary>
        /// Instantiate a new instance of MockObject.
        /// </summary>
        /// <param name="id">Identify</param>
        public MockObject(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Get the dependency object.
        /// </summary>
        public IMockDependency Dependency { get; private set; }

        /// <summary>
        /// Releases all resource created by developer.
        /// </summary>
        protected override void BeforeDispose()
        {
            if (this._checkExecution != null)
            {
                this._checkExecution.Executed();
            }
            base.BeforeDispose();
        }
    }
}
