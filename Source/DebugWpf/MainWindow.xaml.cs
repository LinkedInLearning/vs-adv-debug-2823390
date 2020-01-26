using System;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using RobotFactory;

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
		 
			var nameGen = new RobotFactory.TeamBuilder();
			
			var roboNames = nameGen.GetRobots();
			TeamAListBox.ItemsSource = roboNames.Take(6);
			TeamBListBox.ItemsSource = roboNames.Skip(6).Take(6);
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			TeamAListBox.ItemsSource = null;
			TeamBListBox.ItemsSource = null;
		}
		private Random _ran = new Random();
		private void ShowButton_Click(object sender, RoutedEventArgs e)
		{
			if (TeamAListBox.Items.Count ==0 || TeamBListBox.Items.Count ==0)
			{
				return;
			}
				try
				{
					var teamAMember = (Robot)(TeamAListBox.Items[_ran.Next(0,(TeamAListBox.Items.Count-1))]);
					var teamBMember = (Robot)(TeamBListBox.Items[_ran.Next(0, (TeamBListBox.Items.Count - 1))]);
				MatchTextBlock.Text = teamAMember.PrimeName + " vs. " + teamBMember.PrimeName;
				} catch (NullReferenceException ex)
				{
					MessageBox.Show("Null value, did you select a team member from the listbox?");
				} catch (Exception)
				{

					throw;
				}


			
		}
	}
}
