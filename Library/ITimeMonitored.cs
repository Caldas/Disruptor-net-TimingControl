using System;
using System.Collections.Concurrent;

namespace Disruptor.TimingControl
{
	public interface ITimeMonitored
	{
		ConcurrentBag<Tuple<string, long>> HandlersExecutionTimes { get; }
	}
}