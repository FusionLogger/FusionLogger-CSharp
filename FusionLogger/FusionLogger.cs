namespace FusionLogger
{
	// TODO: DOKUMENTATION
	public class FusionLogger : IFusionLogger
	{

		// TODO: DOKUMENTATION
		public string Name { get; private set; } = nameof(FusionLogger);


		// TODO: DOKUMENTATION
		public string Scope { get; private set; } = string.Empty;


		// TODO: DOKUMENTATION
		public FusionLogLevel MinLevel { get; private set; } = FusionLogLevel.Info;


		// TODO: DOKUMENTATION
		public IFusionLogFormatter Formatter { get; private set; } = new FusionLogFormatter();



		#region Initialsation


		// TODO: DOKUMENTATION
		private FusionLogger() { }


		// TODO: DOKUMENTATION
		public class Builder
		{

			// TODO: DOKUMENTATION
			private readonly FusionLogger _fusionlogger = new FusionLogger();


			// TODO: DOKUMENTATION
			public Builder SetName(string name)
			{
				this._fusionlogger.Name = name;
				return this;
			}


			// TODO: DOKUMENTATION
			public Builder SetMinLevel(FusionLogLevel fusionLogLevel)
			{
				this._fusionlogger.MinLevel = fusionLogLevel;
				return this;
			}


			// TODO: DOKUMENTATION
			public Builder SetFormatter(IFusionLogFormatter formatter)
			{
				this._fusionlogger.Formatter = formatter;
				return this;
			}
		}


		#endregion Initialsation



		#region Fundamental Public Methods


		// TODO: DOKUMENTATION
		public void Debug(string message)
			=> throw new NotImplementedException();


		// TODO: DOKUMENTATION
		public void Info(string message)
			=> throw new NotImplementedException();


		// TODO: DOKUMENTATION
		public void Warning(string message, Exception? exception)
			=> throw new NotImplementedException();


		// TODO: DOKUMENTATION
		public void Critical(string message, Exception? exception)
			=> throw new NotImplementedException();


		// TODO: DOKUMENTATION
		public void BeginScope(string scope) => this.Scope = scope;


		// TODO: DOKUMENTATION
		public void EndScope() => this.Scope = string.Empty;


		// TODO: DOKUMENTATION
		public void SetMinLevel(FusionLogLevel fusionLogLevel) => this.MinLevel = fusionLogLevel;


		#endregion Fundamental Public Methods



		#region Internal Private Methods


		// TODO: DOKUMENTATION
		private bool IsEnabled(FusionLogLevel requested)
		=> throw new NotImplementedException();


		// TODO: DOKUMENTATION
		private void Log(string message, Exception? exception)
		=> throw new NotImplementedException();


		#endregion Internal Private Methods
	}
}
