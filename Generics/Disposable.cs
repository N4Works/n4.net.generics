using System;

namespace N4.Net.Generics
{
    /// <summary>
    /// Class Disposable
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Releases all resource used by the <see cref="T:N4.Net.Generics.BaseModel"/> object.
        /// </summary>
        /// <remarks>Call Dispose when you are finished using the <see cref="T:N4.Net.Generics.BaseModel"/>. The
        /// Dispose method leaves the <see cref="T:N4.Net.Generics.BaseModel"/> in an unusable state. After
        /// calling Dispose, you must release all references to the <see cref="T:N4.Net.Generics.BaseModel"/> so
        /// the garbage collector can reclaim the memory that the <see cref="T:N4.Net.Generics.BaseModel"/> was occupying.</remarks>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases all resource created by developer.
        /// </summary>
        protected abstract void BeforeDispose();

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="T:N4.Net.Generics.Disposable"/> is reclaimed by garbage collection.
        /// </summary>
        ~Disposable()
        {
            this.Dispose(false);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        /// <param name="disposing">If set to <c>true</c>, runs BeforeDispose method.</param>
        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }
            this._disposed = true;
            if (disposing)
            {
                this.BeforeDispose();
            }
        }
    }
}
