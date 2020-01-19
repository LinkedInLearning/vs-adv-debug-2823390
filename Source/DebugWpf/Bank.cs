using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWpf.Financial
{
	internal class OnlineServices
	{
		static Random _ran = new Random();
		static long _counter = 0;
		// simulated service
		static OnlineServices()
		{
			 _counter = -1;
		}
		public static Decimal GetBankRateFromSystem()
		{
			_counter += 1;
			if (_counter % 3 == 1)
			{
				throw new System.Net.HttpListenerException(errorCode: 422, "Cannot start HTTP listener");
			}
			else if (_counter % 3 == 2)
			{
				throw new System.Net.Http.HttpRequestException("There is trouble with the HTTP request.");
			}
			var currentRate = (decimal)_ran.NextDouble() * 4;
			return currentRate;
		}
		public static Decimal GetLoanFee()
		{
			var currentFee = (decimal)_ran.NextDouble() * 2;
			return currentFee;
		}
	}
}
