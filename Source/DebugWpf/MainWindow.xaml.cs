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
			var nameGen = new RobotNameGenerator.NameGenerator();

			var roboNames = nameGen.GetAllRobotNames();
			TeamAListBox.ItemsSource = roboNames.Take(6);
			TeamBListBox.ItemsSource = roboNames.Skip(6).Take(6);
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			TeamAListBox.ItemsSource = null;
			TeamBListBox.ItemsSource = null;
		}
	}
}