using Disruptor.TimingControl;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		internal class Item : ITimeMonitored
		{
			public Guid Id { get; set; }
			public ConcurrentBag<Tuple<string, long>> HandlersExecutionTimes { get; set; }
		}

		internal class TestHandler : BaseMonitoringHandler<Item>
		{
			public TestHandler() : base("Test Handler") { }

			public override bool IsValid(Item data, long sequence, bool endOfBatch)
			{
				//Checa se é valido os dados para execução, assim o tempo só é contabilizado se o for uma execução válida
				return true;
			}

			public override void OnTimedNext(Item data, long sequence, bool endOfBatch)
			{
				//TODO: Aqui vai o código de negócios
			}
		}
	}
}