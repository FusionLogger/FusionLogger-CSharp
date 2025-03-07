using System.Collections.Concurrent;

namespace FusionLogger
{
	public class FusionLogProcessor
	{

		private static FusionLogProcessor? _instance;

		public ConcurrentQueue<FusionLogRecord> Queue { get; private set; }

		private FusionLogProcessor()
		{
			this.Queue = new ConcurrentQueue<FusionLogRecord>();
		}

		public static FusionLogProcessor RegisterProcessor()
		{
			if (_instance == null)
			{
				_instance = new FusionLogProcessor();
				return _instance;
			}

			return _instance;
		}
	}
}
