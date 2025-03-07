using System.Text;

namespace FusionLogger
{
	// Literal-Token: Fester Text
	public class LiteralToken : IFormatToken
	{
		private readonly string literal;
		public LiteralToken(string literal) { this.literal = literal; }
		public override void Append(FusionLogRecord record, StringBuilder sb)
		{
			sb.Append(this.literal);
		}
	}


}

