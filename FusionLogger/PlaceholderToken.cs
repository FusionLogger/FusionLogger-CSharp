using System.Text;

namespace FusionLogger
{
	// Platzhalter-Token: Ersetzt einen Schlüssel durch den entsprechenden Wert aus LogRecord
	public class PlaceholderToken : IFormatToken
	{
		public string Key { get; }
		public string? Format { get; } // Optional: z.B. Zeitformat

		public PlaceholderToken(string key, string? format = null)
		{
			this.Key = key;
			this.Format = format;
		}

		public override void Append(FusionLogRecord record, StringBuilder sb)
		{
			// Je nach Key holen wir den entsprechenden Wert:
			switch (this.Key)
			{
				case "Timestamp":
					sb.Append(record.Timestamp.ToString(this.Format ?? "o")); // "o" = ISO 8601
					break;
				case "Level":
					sb.Append(record.Level);
					break;
				case "LoggerName":
					sb.Append(record.Name);
					break;
				case "Message":
					sb.Append(record.Message);
					break;
				default:
					sb.Append($"{{Unknown:{this.Key}}}");
					break;
			}
		}
	}


}

