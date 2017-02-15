namespace N4.Net.Generics.Test
{
    public class MockObject : BaseModel
	{
		private ICheckExecution _checkExecution;

		public MockObject(ICheckExecution checkExecution)
		{
			this._checkExecution = checkExecution;
		}

		public MockObject(string id)
		{
			this.Id = id;
		}

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
