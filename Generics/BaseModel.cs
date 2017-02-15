using System;

namespace N4.Net.Generics
{
	/// <summary>
	/// Base model.
	/// </summary>
	public class BaseModel : IDisposable
	{
		private bool _disposed;
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
		/// Releases all resource used by the <see cref="T:N4.Net.Generics.BaseModel"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:N4.Net.Generics.BaseModel"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:N4.Net.Generics.BaseModel"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="T:N4.Net.Generics.BaseModel"/> so
		/// the garbage collector can reclaim the memory that the <see cref="T:N4.Net.Generics.BaseModel"/> was occupying.</remarks>
		public void Dispose()
		{
			this.Dispose(true);
		}

		/// <summary>
		/// Releases all resource created by developer.
		/// </summary>
		protected virtual void BeforeDispose()
		{
			this._id = null;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="T:N4.Net.Generics.BaseModel"/> is reclaimed by garbage collection.
		/// </summary>
		~BaseModel()
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
				this._id = null;
			}
		}
	}
}
