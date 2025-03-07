using System.Text;

namespace FusionLogger
{
	public interface IFormatToken
	{
		abstract void Append(FusionLogRecord record, StringBuilder sb);
	}


}

