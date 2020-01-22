using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWpf
{
	class CpuTester
	{
		public static void UseTheCpu(int percent, int millisecondsToRun)
		{
			var stopTime = DateTime.Now.AddMilliseconds(millisecondsToRun);
			if (percent < 0) { percent = 0; }
			if (percent > 100) { percent = 100; }
			var watch = new Stopwatch();
			watch.Start();
			while (DateTime.Now < stopTime)
			{
				// loop runs for percent milliseconds
				// then sleeps for remaining percent

				if (watch.ElapsedMilliseconds > percent)
				{
					Task.Delay(100 - percent);
					watch.Reset();
					watch.Start();
				}
			}
		}
	}
}
