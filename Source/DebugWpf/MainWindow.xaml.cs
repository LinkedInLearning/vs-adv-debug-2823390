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
			_bigList.AddRange(Enumerable.Range(1, 1000 * 1500 ));
			
			TeamAListBox.Items.Add ($"{_bigList.Count:E2} total items");

		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				_bigList.RemoveRange(1, (int)(_bigList.Count /4));
			} catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			TeamBListBox.Items.Add( $"{_bigList.Count:E2} total items");
		
		}

		private void ForceButton_Click(object sender, RoutedEventArgs e)
		{
			GC.Collect();
		}
	}
}