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
		// simulated service
		public static Decimal GetBankRateFromSystem()
		{
			if (_ran.NextDouble() < .2)
			{
				throw new System.Net.HttpListenerException(errorCode: 422, "Cannot start HTTP listener");
			}
			else if (_ran.NextDouble() < .4)
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
