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
			var randomizedPrimeNames = GetRandomizedPrimeNames();
			var randomizedCrewNames = GetRandomizedCrewNames();


			for (int i = 0; i < randomizedPrimeNames.Count; i++)
			{
				//temp.Add(new Robot { PrimeName = GetRandomizedPrimeNames().ElementAt(i), CrewName = GetRandomizedCrewNames().ElementAt(i) });
			
				
				_robotPool.ElementAt(i).PrimeName = randomizedPrimeNames.ElementAt(i);
				_robotPool.ElementAt(i).CrewName = randomizedCrewNames.ElementAt(i);
			}

			return _robotPool;
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
	}
	public class Robot
	{
		public string PrimeName { get; set; }
		public string CrewName { get; set; }
	}
}