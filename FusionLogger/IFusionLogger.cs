using System.Runtime.CompilerServices;

namespace FusionLogger
{
	public interface IFusionLogger
	{

		/// <summary>
		/// Logs a Debug-level message.
		/// </summary>
		/// <param name="message">The log message.</param>
		/// <param name="callerFile">The source file of the caller (auto-populated).</param>
		/// <param name="callerMember">The calling member name (auto-populated).</param>
		/// <param name="callerLine">The line number in the source file (auto-populated).</param>
		abstract void Debug(string message, [CallerFilePath] string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1);


		/// <summary>
		/// Logs a Info-level message.
		/// </summary>
		/// <param name="message">The log message.</param>
		/// <param name="callerFile">The source file of the caller (auto-populated).</param>
		/// <param name="callerMember">The calling member name (auto-populated).</param>
		/// <param name="callerLine">The line number in the source file (auto-populated).</param>
		abstract void Info(string message, string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1);


		/// <summary>
		/// Logs a Warning-level message, optionally including an exception.
		/// </summary>
		/// <param name="message">The log message.</param>
		/// <param name="callerFile">The source file of the caller (auto-populated).</param>
		/// <param name="callerMember">The calling member name (auto-populated).</param>
		/// <param name="callerLine">The line number in the source file (auto-populated).</param>
		abstract void Warning(string message, Exception? exception, string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1);


		/// <summary>
		/// Logs a Critical-level message, optionally including an exception.
		/// </summary>
		/// <param name="message">The log message.</param>
		/// <param name="callerFile">The source file of the caller (auto-populated).</param>
		/// <param name="callerMember">The calling member name (auto-populated).</param>
		/// <param name="callerLine">The line number in the source file (auto-populated).</param>
		abstract void Critical(string message, Exception? exception, string callerFile = "",
			[CallerMemberName] string callerMember = "", [CallerLineNumber] int callerLine = -1);


		/// <summary>
		/// Begins a new logging scope.
		/// </summary>
		/// <param name="scope">The name of the new logging-scope.</param>
		abstract void BeginScope(string scope);


		/// <summary>
		/// Ends the current logging scope.
		/// </summary>
		abstract void EndScope();


		/// <summary>
		/// Sets the minimum logging level at runtime.
		/// </summary>
		/// <param name="fusionLogLevel"> The new minimum logging level.</param>
		abstract void SetMinLevel(FusionLogLevel fusionLogLevel);
	}
}