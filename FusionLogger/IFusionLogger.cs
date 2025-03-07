namespace FusionLogger
{
	public interface IFusionLogger
	{

		// TODO: DOKUMENTATION
		abstract void Debug(string message);


		// TODO: DOKUMENTATION
		abstract void Info(string message);


		// TODO: DOKUMENTATION
		abstract void Warning(string message, Exception? exception);


		// TODO: DOKUMENTATION
		abstract void Critical(string message, Exception? exception);


		// TODO: DOKUMENTATION
		abstract void BeginScope(string scope);


		// TODO: DOKUMENTATION
		abstract void EndScope();


		// TODO: DOKUMENTATION
		abstract void SetMinLevel(FusionLogLevel fusionLogLevel);
	}
}