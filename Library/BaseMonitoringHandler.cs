using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disruptor.TimingControl
{
	public abstract class BaseMonitoringHandler<T> : HandlerTimeMonitor, IEventHandler<T> where T : ITimeMonitored
	{
		public BaseMonitoringHandler(string metricName) : base(metricName) { }

		public void OnNext(T data, long sequence, bool endOfBatch)
		{
			if (this.IsValid(data, sequence, endOfBatch))
			{
				base.StartMonitoring();
				this.OnTimedNext(data, sequence, endOfBatch);
				base.RegisterPoint(data);
			}
		}

		public abstract bool IsValid(T data, long sequence, bool endOfBatch);

		public abstract void OnTimedNext(T data, long sequence, bool endOfBatch);
	}
}