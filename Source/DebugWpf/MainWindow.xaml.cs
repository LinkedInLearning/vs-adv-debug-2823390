using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			// stress one of the CPU cores
			var percents = new List<int>() { 90 };
			Parallel.ForEach(percents, (p) => CpuTester.UseTheCpu(p, 2000));
			var nameGen = new RobotNameGenerator.NameGenerator();

			// other code
			var roboNames = nameGen.GetAllRobotNames();
			TeamAListBox.ItemsSource = roboNames.Take(6);
			TeamBListBox.ItemsSource = roboNames.Skip(6).Take(6);
		}

		private void LoadFourButton_Click(object sender, RoutedEventArgs e)
		{
			// stress some of the CPU cores
			var percents = new List<int>() { 30, 50, 80, 90 };
			Parallel.ForEach(percents, (p) => CpuTester.UseTheCpu(p, 2000));

			// other code
			TeamAListBox.ItemsSource = null;
			TeamBListBox.ItemsSource = null;
		}
	}
}