using System.Windows;

namespace DebugWpf
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			decimal monthlyPayment;
			decimal rate = 5.6M;
			int numberMonths;
			decimal loanAmount;
			string formattedResult;

			// step into
			numberMonths = 10;
			loanAmount = 1100;
			rate = LoanCalc.GetCurrentLoanRate();
			monthlyPayment = LoanCalc.CalculateMonthlyPayment(numberOfMonths: numberMonths,
																												 loanAmount: loanAmount,
																												 loanRate: rate);
			formattedResult = $"{loanAmount:C} loan (at {rate:P}) {numberMonths} months: {monthlyPayment:C}";
			ResultsListBox.Items.Add(formattedResult);

			// step over
			numberMonths = 4;
			loanAmount = 2200;
			monthlyPayment = LoanCalc.CalculateMonthlyPayment(numberOfMonths: numberMonths,
																												 loanAmount: loanAmount,
																												 loanRate: rate);
			formattedResult = $"{loanAmount:C} loan (at {rate:P}) {numberMonths} months: {monthlyPayment:C}";
			ResultsListBox.Items.Add(formattedResult);

			// step out;
			numberMonths = 36;
			loanAmount = 3300;
			monthlyPayment = LoanCalc.CalculateMonthlyPayment(numberOfMonths: numberMonths,
				 																								loanAmount: loanAmount,
																												loanRate: rate);
			formattedResult = $"{loanAmount:C} loan (at {rate:P}) {numberMonths} months: {monthlyPayment:C}";
			ResultsListBox.Items.Add(formattedResult);
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			ResultsListBox.Items.Clear();
		}
	}
}