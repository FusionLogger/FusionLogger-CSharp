namespace FusionLogger
{
	public class FusionLogProcessor
	{
		private static FusionLogProcessor? instance;
		private readonly CancellationTokenSource tokenSource;
		private readonly CancellationToken cancellationToken;
		private readonly Queue<FusionLogRecord> queue;
		private readonly SemaphoreSlim Semaphore = new SemaphoreSlim(0);


		private FusionLogProcessor()
		{
			this.queue = new Queue<FusionLogRecord>();
			this.tokenSource = new CancellationTokenSource();
			this.cancellationToken = this.tokenSource.Token;
		}


		public static FusionLogProcessor GetInstance()
		{
			if (instance == null)
			{
				instance = new FusionLogProcessor();
				instance.Process();
				return instance;
			}

			return instance;
		}


		public void Cancel() => this.tokenSource.Cancel();


		private void Process()
		{
			Task.Run(() =>
			{
				// Prueft in Dauerschleife die Queue, blockiert wenn leer
				while (true)
				{
					FusionLogRecord record = this.DequeueLogRecord();
					string output = record.Logger.Formatter.Format(record);
					Console.WriteLine(output);
				}
			}, this.cancellationToken);
		}


		private FusionLogRecord DequeueLogRecord()
		{
			// Blockieren, wenn Queue leer
			this.Semaphore.Wait();

			// Res kann ignoriert werden, Queue.Size > 1 durch Semaphore sichergestellt.
			_ = this.queue.TryDequeue(out FusionLogRecord fusionLogRecord);
			return fusionLogRecord;

		}


		public void EnqueueLogRecord(FusionLogRecord fusionLogRecord)
		{
			// Element in Queue packen
			this.queue.Enqueue(fusionLogRecord);

			// Queue Semaphore für Processor öffnen
			this.Semaphore.Release();
		}
	}
}
