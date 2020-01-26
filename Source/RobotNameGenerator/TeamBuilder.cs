using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RobotFactory
{
	public class TeamBuilder
	{
		private List<string> _primeNames;
		private List<string> _crewNames;
		private Random _ran = new Random();

		public TeamBuilder()
		{

			// read XML instead of text files
			var xmlDoc = XDocument.Load("RobotNames.xml");


			_crewNames = xmlDoc.Root.Elements("CrewNames").Elements("CrewName")
																.Select(element => element.Value)
																.ToList<string>();
			_primeNames = xmlDoc.Root.Elements("PrimeNames").Elements("PrimeName")
																.Select(element => element.Value)
																.ToList<string>();
			for (int nameCounter = 0; nameCounter < _primeNames.Count; nameCounter++)
			{
				_robotPool.Add(new Robot());
			}
		}
		private void BuildRobotPool()
		{

		}
		private List<Robot> _robotPool = new List<Robot>();
		public List<Robot> GetRobots()
		{
			AssignRobotNames();
			RollStats();

			return _robotPool;
		}

		private void RollStats()
		{
			foreach (Robot robot in _robotPool)
			{
				robot.Endurance = RollDice(3);
				robot.Speed = RollDice(3);
				robot.Strength = RollDice(3);
			}
		}

		private void AssignRobotNames()
		{
			var randomizedPrimeNames = GetRandomizedPrimeNames();
			var randomizedCrewNames = GetRandomizedCrewNames();


			for (int i = 0; i < randomizedPrimeNames.Count; i++)
			{

				_robotPool.ElementAt(i).PrimeName = randomizedPrimeNames.ElementAt(i);
				_robotPool.ElementAt(i).CrewName = randomizedCrewNames.ElementAt(i);
			}
		}

		private List<String> GetRandomizedPrimeNames()
		{
			var q1 = from name in _primeNames
							 orderby _ran.NextDouble()
							 select name;
			return q1.ToList();
		}

		private List<String> GetRandomizedCrewNames()
		{
			var q1 = from name in _crewNames
							 orderby _ran.NextDouble()
							 select name;
			return q1.ToList();
		}
		private int RollDice(int diceCount)
		{
			int temp = 0;
			for (int i = 0; i < diceCount; i++)
			{
				temp += _ran.Next(1, 6);
			}
			return temp;
		}
	}

	public class Robot
	{
		public string PrimeName { get; set; }
		public string CrewName { get; set; }
		public int Speed { get; set; }
		public int Strength { get; set; }
		public int Endurance { get; set; }
	}
}