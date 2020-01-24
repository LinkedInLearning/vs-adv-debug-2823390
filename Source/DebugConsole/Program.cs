using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebugConsole
{
	class Program
	{
		static async Task Main(string[] args)
		{
			bool showMenu = true;
			while (showMenu)
			{
				showMenu = AppMenu();
			}

			if (_runAsync)
			{
				await StartRobotAsync();
				MainThreadWork();
			}
			Console.WriteLine("Robots Experiment Finished");



		}
		private static bool _runAsync = false;
		private static bool AppMenu()
		{

			Console.ResetColor();
			Console.WriteLine("Choose an option:");
			Console.WriteLine("A: One Thread");
			Console.WriteLine("B: Use Parallel");
			Console.WriteLine("C: Use Tasks");
			Console.WriteLine("D: Use async/await");
			Console.WriteLine("(Esc) Exit");
			Console.WriteLine("Select an option: ");

			var key = Console.ReadKey(intercept: true).Key;
			if (key == ConsoleKey.A)
			{
				StartRobotsOneThread();
				MainThreadWork();
				return true;

			}
			else if (key == ConsoleKey.B)
			{
				StartRobotsParellel();
				MainThreadWork();
				return true;
			}
			else if (key == ConsoleKey.C)
			{
				StartRobotsTask();
				MainThreadWork();
				return true;
			}
			else if (key == ConsoleKey.D)
			{
				_runAsync = true;
				return false;
			}
			else if (key == ConsoleKey.Escape)
			{

				return false;
			}
			else
			{ return true; }
		}

		private static void MainThreadWork()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			for (int counter = 0; counter < 3; counter++)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Task.Delay(20);
				Console.WriteLine($"Main Thread. {counter}");
			}
			Console.ResetColor();
		}
		static void StartRobotsOneThread()
		{
			ChargeBatteries();
			_robot1.PickupItems();
			_robot2.PickupItems();
			_robot3.PickupItems();
			_robot4.PickupItems();
		}
		private static void StartRobotsParellel()
		{
			ChargeBatteries();
			var robots = new List<Robot>();
			robots.Add(_robot1);
			robots.Add(_robot2);
			robots.Add(_robot3);
			robots.Add(_robot4);

			Parallel.ForEach(robots, r => r.PickupItems()); ;

			robots.Clear();
		}


		private static void StartRobotsTask()
		{
			ChargeBatteries();
			Task.Factory.StartNew(() => { _robot1.PickupItems(); });
			Task.Factory.StartNew(() => { _robot2.PickupItems(); });
			Task.Factory.StartNew(() => { _robot3.PickupItems(); });
			var lastTask = Task.Factory.StartNew(() => { _robot4.PickupItems(); });
			lastTask.Wait();
		}

		private static void ChargeBatteries()
		{
			_robot1.BatteryLevel = _robot1.BatteryLevel = _robot3.BatteryLevel = _robot4.BatteryLevel = 1;
		}

	
		private static async Task StartRobotAsync()
		{

			ChargeBatteries();

			Task.Factory.StartNew(() => { _robot1.PickupItems(); });
			Task.Factory.StartNew(() => { _robot2.PickupItems(); });
			await Task.Factory.StartNew(() => { _robot3.PickupItems(); });
			await Task.Factory.StartNew(() => { _robot4.PickupItems(); });
			Task.Delay(2000);
		}

		private static Robot _robot1 = new Robot(name: "1-Mingle",
																					itemCount: 10,
																					workEfficiency: .02,
																					scanDelay: 500);
		private static Robot _robot2 = new Robot(name: "2-Yodel",
																										itemCount: 12,
																										workEfficiency: .04,
																										scanDelay: 35,
																										laserColor: ConsoleColor.Yellow,
																										outputBuffer: 1);
		private static Robot _robot3 = new Robot(name: "3-Blade", 
																							itemCount: 7, 
																							workEfficiency: .05, 
																							scanDelay: 135, 
																							laserColor: ConsoleColor.Cyan, 
																							outputBuffer: 2);
		private static Robot _robot4 = new Robot(name: "4-Spook", 
																										itemCount: 4,
																										workEfficiency: .04,
																										scanDelay: 500,
																										laserColor: ConsoleColor.White,
																										outputBuffer: 3);
	}

}
