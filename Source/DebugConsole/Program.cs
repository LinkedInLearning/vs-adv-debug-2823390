using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebugConsole
{
	class Program
	{
		static async Task Main(string[] args)
		{
			//	StartRobotsOneThread();
			//StartRobotsParellel();
			StartRobotsTask();
			//await StartRobotAsync();
			MainThreadWork();
			Console.WriteLine("Robots Experiment Finished");

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
		private static void StartRobotsParellel()
		{
			var robots = new List<Robot>();
			robots.Add(new Robot(name: "1-Mingle", itemCount: 10, workEfficiency: .02, scanDelay: 500));
			robots.Add(new Robot(name: "2-Yodel", itemCount: 30, workEfficiency: .04, scanDelay: 35, laserColor: ConsoleColor.Yellow));
			robots.Add(new Robot(name: "3-Squido", itemCount: 15, workEfficiency: .05, scanDelay: 135, laserColor: ConsoleColor.Cyan));
			robots.Add(new Robot(name: "4-Spook", itemCount: 4, workEfficiency: .04, scanDelay: 500, laserColor: ConsoleColor.White));
			Parallel.ForEach(robots, r => r.PickupItems()); ;


		}

		static void StartRobotsOneThread()
		{
			Console.WriteLine("Start Work on Main Thread");
			var robot1 = new Robot(name: "1-Mingle", itemCount: 10, workEfficiency: .02, scanDelay: 500);
			var robot2 = new Robot(name: "2-Yodel", itemCount: 12, workEfficiency: .04, scanDelay: 35, laserColor: ConsoleColor.Yellow);
			var robot3 = new Robot(name: "3-Squido", itemCount: 15, workEfficiency: .05, scanDelay: 135, laserColor: ConsoleColor.Cyan);
			var robot4 = new Robot(name: "4-Spook", itemCount: 4, workEfficiency: .04, scanDelay: 500, laserColor: ConsoleColor.White);
			robot1.PickupItems();
			robot2.PickupItems();
			robot3.PickupItems();
			robot4.PickupItems();
		}
		private static void StartRobotsTask()
		{
			var robot1 = new Robot(name: "1-Mingle", itemCount: 10, workEfficiency: .02, scanDelay: 500);
			var robot2 = new Robot(name: "2-Yodel", itemCount: 12, workEfficiency: .04, scanDelay: 35, laserColor: ConsoleColor.Yellow);
			var robot3 = new Robot(name: "3-Squido", itemCount: 7, workEfficiency: .05, scanDelay: 135, laserColor: ConsoleColor.Cyan);
			var robot4 = new Robot(name: "4-Spook", itemCount: 4, workEfficiency: .04, scanDelay: 500, laserColor: ConsoleColor.White);
			Task.Factory.StartNew(() => { robot1.PickupItems(); });
			Task.Factory.StartNew(() => { robot2.PickupItems(); });
		
			var lastTask = Task.Factory.StartNew(() => { robot3.PickupItems(); });
			lastTask.Wait();
		}
		
		private static async Task StartRobotAsync()
		{
			var robot1 = new Robot(name: "1-Mingle", itemCount: 10, workEfficiency: .02, scanDelay: 500);
			var robot2 = new Robot(name: "2-Yodel", itemCount: 12, workEfficiency: .04, scanDelay: 35, laserColor: ConsoleColor.Yellow);
			var robot3 = new Robot(name: "3-Squido", itemCount: 7, workEfficiency: .05, scanDelay: 135, laserColor: ConsoleColor.Cyan);
			var robot4 = new Robot(name: "4-Spook", itemCount: 4, workEfficiency: .04, scanDelay: 500, laserColor: ConsoleColor.White);
			Task.Factory.StartNew(() => { robot1.PickupItems(); });
			Task.Factory.StartNew(() => { robot2.PickupItems(); });
			await Task.Factory.StartNew(() => { robot3.PickupItems(); });
			await Task.Factory.StartNew(() => { robot4.PickupItems(); });
			Task.Delay(2000);
		}
	}

}
