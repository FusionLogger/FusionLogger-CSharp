namespace FusionLogger
{
	public record struct FusionLogRecord(
		FusionLogger Logger,
		DateTime Timestamp,
		FusionLogLevel Level,
		string Message,
		int ThreadId,
		int ProcessId,
		string ClassName,
		string MethodName,
		int MethodLine,
		string HostName,
		Exception? Exception = null
	);
}