using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebugConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start Work");

			//var robot1 = new Robot(name: "Mingle", workEfficiency: .02, scanDelay: 500);
			//var robot2 = new Robot(name: "Yodel", workEfficiency: .04, scanDelay: 35, laserColor: ConsoleColor.Yellow);
			//robot1.PickupItems(10);
			//robot2.PickupItems(30);
			var robots = new List<Robot>();
			robots.Add(new Robot(name: "Mingle", workEfficiency: .02, scanDelay: 500));
			//Parallel.ForEach
			Console.Read();
		}
	}
}
