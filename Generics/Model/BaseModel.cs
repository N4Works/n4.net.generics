namespace N4.Net.Generics.Model
{
    /// <summary>
    /// Base model.
    /// </summary>
    public class BaseModel : Disposable
    {
        private string _id;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id
        {
            get
            {
                return this._id;
            }
            protected set
            {
                this._id = value;
            }
        }

        /// <summary>
        /// Releases all resource created by developer.
        /// </summary>
        protected override void BeforeDispose()
        {
            this._id = null;
        }
    }
}
