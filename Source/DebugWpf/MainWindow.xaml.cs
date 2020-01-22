using System;
using System.Collections.Generic;
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
		List<int> _bigList = new List<int>();
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_bigList.AddRange(Enumerable.Range(1, 1000 * 1000));
			var nameGen = new RobotNameGenerator.NameGenerator();

			var roboNames = nameGen.GetAllRobotNames();
			TeamAListBox.ItemsSource = roboNames.Take(6);
			TeamBListBox.ItemsSource = roboNames.Skip(6).Take(6);
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			_bigList.RemoveRange(1, 500 * 1000);
			TeamAListBox.ItemsSource = null;
			TeamBListBox.ItemsSource = null;
		}

		private void ForceButton_Click(object sender, RoutedEventArgs e)
		{
			GC.Collect();
		}
	}
}