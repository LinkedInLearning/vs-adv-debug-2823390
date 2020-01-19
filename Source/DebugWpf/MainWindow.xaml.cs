using System.Windows;
using System.Linq;
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


			numberMonths = 10;
			loanAmount = 1100;
			try
			{
				rate = LoanCalc.GetCurrentLoanRate();
				monthlyPayment = LoanCalc.CalculateMonthlyPayment(numberOfMonths: numberMonths,
																													 loanAmount: loanAmount,
																													 loanRate: rate);
				formattedResult = $"{loanAmount:C} loan (at {rate:P}) {numberMonths} months: {monthlyPayment:C}";
				ResultsListBox.Items.Add(formattedResult);


				numberMonths = 4;
				loanAmount = 2200;
				monthlyPayment = LoanCalc.CalculateMonthlyPayment(numberOfMonths: numberMonths,
																													 loanAmount: loanAmount,
																													 loanRate: rate);
				formattedResult = $"{loanAmount:C} loan (at {rate:P}) {numberMonths} months: {monthlyPayment:C}";
				ResultsListBox.Items.Add(formattedResult);


				numberMonths = 36;
				loanAmount = 3300;
				monthlyPayment = LoanCalc.CalculateMonthlyPayment(numberOfMonths: numberMonths,
																													 loanAmount: loanAmount,
																													loanRate: rate);
				formattedResult = $"{loanAmount:C} loan (at {rate:P}) {numberMonths} months: {monthlyPayment:C}";
				ResultsListBox.Items.Add(formattedResult);
			} catch (System.Net.Http.HttpRequestException ex)
			{
				MessageBox.Show($"{ex.GetType().Name}: {ex.Message}");
			} catch (System.Net.HttpListenerException ex)
			{
				MessageBox.Show($"{ex.GetType().Name}: {ex.Message}");
			} catch (System.Exception)
			{
				MessageBox.Show("Something unexpected happened in the application! Please restart the application.");
				throw;
			}
			
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			ResultsListBox.Items.Clear();
		}

		private void UnhandledButton_Click(object sender, RoutedEventArgs e)
		{
			var nameGen = new RobotNameGenerator.NameGenerator();
			var nameList = nameGen.GetAllRobotNames();

			var name = nameList.ElementAt(120);
		}
	}
}