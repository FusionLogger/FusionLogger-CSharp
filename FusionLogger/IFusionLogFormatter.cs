namespace FusionLogger
{
	public interface IFusionLogFormatter
	{
		string Format(FusionLogRecord record);
	}
}