using System;
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
			var robots = new RobotFactory.TeamBuilder().GetRobots();

			var results = robots.Where(x => x.Speed > 10).OrderBy(x => x.PrimeName);


			// initializer; condition; iterator
			for (int counter = 0; counter < results.Count(); counter++)
			{
				Console.WriteLine(counter);
			}
		}

		private void AttributeButton_Click(object sender, RoutedEventArgs e)
		{
			var robots = new RobotFactory.TeamBuilder().GetRobots();

			var firstRobot = robots.First();
		}

		private Random _ran = new Random();

		private void RecursiveButton_Click(object sender, RoutedEventArgs e)
		{
			// use the Parallel watch window to
			// examine variable for each recursive pass.


			bool isPalindrome;
			isPalindrome = Puzzle.IsPalindrome("Tuna roll or a nut");

			isPalindrome = Puzzle.IsPalindrome("I am hungry now");
		}

		private void OverLoadsButton_Click(object sender, RoutedEventArgs e)
		{
			// set a breakpoint for all overloads of a function
			// use the New Breakpoint, Function (GetTicketCount)

			var result = TicketGenerator.GetTicketCount();
			result = TicketGenerator.GetTicketCount(true);
		}
	}
}