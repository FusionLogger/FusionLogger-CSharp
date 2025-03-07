using System.Net;
using System.Runtime.CompilerServices;

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
		public IFusionLogFormatter Formatter { get; private set; } = new FusionLogFormatter("");


		// TODO: DOKUMENTATION
		private readonly string HostName = Dns.GetHostName();


		// TODO: DOKUMENTATION
		private readonly int ProcessID = Environment.ProcessId;


		// TODO: DOKUMENTATION
		private readonly string MachineName = Environment.MachineName;


		// TODO: DOKUMENTATION
		private readonly FusionLogProcessor Processor = FusionLogProcessor.GetInstance();


		#region Initialsation


		// TODO: DOKUMENTATION
		private FusionLogger()
		{
		}


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


		/// <inheritdoc/>
		public void Debug(string message, [CallerFilePath] string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1)
		{
			this.PushToQueue(FusionLogLevel.Debug, message, null, callerFile, callerMember, callerLine);
		}


		/// <inheritdoc/>
		public void Info(string message, [CallerFilePath] string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1)
		{
			this.PushToQueue(FusionLogLevel.Info, message, null, callerFile, callerMember, callerLine);
		}


		/// <inheritdoc/>
		public void Warning(string message, Exception? exception, [CallerFilePath] string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1)
		{
			this.PushToQueue(FusionLogLevel.Warning, message, null, callerFile, callerMember, callerLine);
		}


		/// <inheritdoc/>
		public void Critical(string message, Exception? exception, [CallerFilePath] string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1)
		{
			this.PushToQueue(FusionLogLevel.Critical, message, null, callerFile, callerMember, callerLine);
		}


		/// <inheritdoc/>
		public void BeginScope(string scope) => this.Scope = scope;


		/// <inheritdoc/>
		public void EndScope() => this.Scope = string.Empty;


		/// <inheritdoc/>
		public void SetMinLevel(FusionLogLevel fusionLogLevel) => this.MinLevel = fusionLogLevel;


		#endregion Fundamental Public Methods



		#region Internal Private Methods


		// TODO: DOKUMENTATION
		private bool IsEnabled(FusionLogLevel requested)
		{
			int eValueMinLevel = (int)this.MinLevel;
			int eValueRequested = (int)requested;
			return eValueMinLevel <= eValueRequested;
		}


		// TODO: DOKUMENTATION
		private void PushToQueue(FusionLogLevel level, string message, Exception? exception, string file, string method, int line)
		{
			if (this.IsEnabled(level))
			{
				FusionLogRecord item = new FusionLogRecord(
					Logger: this,
					Timestamp: DateTime.Now,
					Level: level,
					Message: message,
					ThreadId: Environment.CurrentManagedThreadId,
					ProcessId: this.ProcessID,
					ClassName: file,
					MethodName: method,
					MethodLine: line,
					HostName: this.HostName,
					Exception: exception
				);
				this.Processor.EnqueueLogRecord(item);
			}
		}


		#endregion Internal Private Methods
	}
}
