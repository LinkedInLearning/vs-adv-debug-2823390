using DebugWpf.Financial;

namespace DebugWpf
{
	internal class LoanCalc
	{
		public static decimal CalculateMonthlyPayment(int numberOfMonths, decimal loanAmount, decimal loanRate)
		{
			// simplified and inaccurate formula
			decimal perMonth = 0;
			decimal perMonthWithLoanRate = 0;

			perMonth = loanAmount / numberOfMonths;

			perMonthWithLoanRate = perMonth * (1 + loanRate);
			return perMonthWithLoanRate;
		}

		public static decimal GetCurrentLoanRate()
		{
			var currentFederalRate = OnlineServices.GetBankRateFromSystem();
			var ourCalculatedRate = currentFederalRate + OnlineServices.GetLoanFee();
			return ourCalculatedRate / 100;
		}
	}
}