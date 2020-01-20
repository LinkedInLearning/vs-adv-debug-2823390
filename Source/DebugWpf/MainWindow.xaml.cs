using System;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using static RobotNameGenerator.NameGenerator;

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
			var mySetting = Environment.ProcessorCount;
			var all = Environment.GetEnvironmentVariables();

			//MessageBox.Show(mySetting.ToString());

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

		private void MessageButton_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show(messageBoxText: "Pick a member from each team?",
													caption: "First team match",
													icon: MessageBoxImage.Question,
													button: MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				var teamAMember = (RobotName)(TeamAListBox.SelectedItem );
				var teamBMember = (RobotName)(TeamBListBox.SelectedItem);
				MatchTextBlock.Text = teamAMember.PrimeName + " vs. " + teamBMember.PrimeName;
			}
		}
	}
}
