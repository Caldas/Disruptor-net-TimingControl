using System;
using System.Diagnostics;

namespace Disruptor.TimingControl
{
	public abstract class HandlerTimeMonitor
	{
		private Stopwatch stopwatch = null;

		private string metricName = string.Empty;

		protected long ElapsedMilliseconds
		{
			get
			{
				return stopwatch.ElapsedMilliseconds;
			}
		}

		internal HandlerTimeMonitor(string metricName)
		{
			this.stopwatch = new Stopwatch();
			this.metricName = metricName;
		}

		protected void StartMonitoring()
		{
			this.stopwatch.Restart();
		}

		protected void RegisterPoint(ITimeMonitored item)
		{
			item.HandlersExecutionTimes.Add(new Tuple<string, long>(this.metricName, this.stopwatch.ElapsedMilliseconds));
		}
	}
}