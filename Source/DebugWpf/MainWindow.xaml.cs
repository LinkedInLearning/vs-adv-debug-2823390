using System.Linq;
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

			// step into
			numberMonths = 12;
			loanAmount = 1200;
			monthlyPayment = Financial.CalculateMonthlyPayment(numberOfMonths: numberMonths,
																												 loanRate: rate,
																												 loanAmount: loanAmount);
			ResultsListBox.Items.Add($"{loanAmount:C} loan for {numberMonths} months: {monthlyPayment:C}");

			// step over
			numberMonths = 4;
			loanAmount = 2800;
			monthlyPayment = Financial.CalculateMonthlyPayment(numberOfMonths: 24,
																									 loanRate: rate,
																									 loanAmount: 2800);
			ResultsListBox.Items.Add($"{loanAmount:C} loan for {numberMonths} months: {monthlyPayment:C}");

			// step out;
			numberMonths = 36;
			loanAmount = 3770;
			monthlyPayment = Financial.CalculateMonthlyPayment(numberOfMonths: 36,
																								 loanRate: rate,
																								 loanAmount: 3700);
			ResultsListBox.Items.Add($"{loanAmount:C} loan for {numberMonths} months: {monthlyPayment:C}");

		}

			private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			ResultsListBox.ItemsSource = null;
			
		}
	}
}