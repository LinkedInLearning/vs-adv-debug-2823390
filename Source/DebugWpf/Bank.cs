﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWpf.Financial
{
	internal class OnlineServices
	{
		static Random _ran = new Random();
		public static Decimal GetBankRateFromSystem()
		{
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
