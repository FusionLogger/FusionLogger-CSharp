using System.Text;

namespace FusionLogger
{
	public class FusionLogFormatter(string format) : IFusionLogFormatter
	{

		private readonly List<IFormatToken> tokens = ParseFormat(format);


		private static List<IFormatToken> ParseFormat(string format)
		{
			List<IFormatToken> tokenList = [];
			int pos = 0;
			while (pos < format.Length)
			{
				int start = format.IndexOf('{', pos);
				if (start == -1) // Keine '{' daher vollstaendiges Literal
				{
					tokenList.Add(new LiteralToken(format.Substring(pos)));
					break;
				}

				if (start > pos) // Format erkannt: Alle char bis Formatindex sind Literale
				{
					tokenList.Add(new LiteralToken(format.Substring(pos, start - pos)));
				}

				int end = format.IndexOf('}', start);
				if (end == -1) // Keine '}' daher Rest vollstaendiges Literal
				{
					tokenList.Add(new LiteralToken(format.Substring(start)));
					break;
				}

				// Platzhalter extrahieren:
				string placeholder = format.Substring(start + 1, end - start - 1);
				string key;
				string? tokenFormat = null;
				int colonIndex = placeholder.IndexOf(':');
				if (colonIndex != -1)
				{
					key = placeholder.Substring(0, colonIndex);
					tokenFormat = placeholder.Substring(colonIndex + 1);
				}
				else
				{
					key = placeholder;
				}

				tokenList.Add(new PlaceholderToken(key, tokenFormat));
				pos = end + 1;
			}

			return tokenList;
		}


		public string Format(FusionLogRecord record)
		{
			StringBuilder sb = new StringBuilder();
			foreach (IFormatToken token in this.tokens)
			{
				token.Append(record, sb);
			}

			return sb.ToString();
		}
	}
}

