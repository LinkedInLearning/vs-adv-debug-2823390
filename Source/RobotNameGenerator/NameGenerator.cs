using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RobotNameGenerator
{
	public class NameGenerator
	{
		private List<string> _primeNames;
		private List<string> _crewNames;
		private Random _ran = new Random();

		public NameGenerator()
		{
		
			// read XML instead of text files
			var xmlDoc = XDocument.Load("RobotNames.xml");
		
			
			 _crewNames = xmlDoc.Root.Elements("CrewNames").Elements("CrewName")
																 .Select(element => element.Value)
																 .ToList<string>();
			_primeNames = xmlDoc.Root.Elements("PrimeNames").Elements("PrimeName")
																.Select(element => element.Value)
																.ToList<string>();
			#region old file access code
			//_crewNames = System.IO.File.ReadAllLines("RobotCrewNames.txt").ToList<string>();
			_primeNames = System.IO.File.ReadAllLines("RobotPrimeNames.txt").ToList<string>();
			#endregion
		}

		public RobotName GetRobotName()
		{
			var randomPrimeIndex = _ran.Next(1, _primeNames.Count);
			var randomCrewIndex = _ran.Next(0, _crewNames.Count);
			return new RobotName { PrimeName = _primeNames[randomPrimeIndex], CrewName = _crewNames[randomCrewIndex] };
		}

		public List<RobotName> GetAllRobotNames()
		{
			var temp = new List<RobotName>();

			var q1 = from name in _primeNames
							 orderby _ran.NextDouble()
							 select name;
			var q2 = from name in _crewNames
							 orderby _ran.NextDouble()
							 select name;
			var primeNameList = q1.ToList();
			var crewNameList = q2.ToList();
			for (int i = 0; i < primeNameList.Count; i++)
			{
				temp.Add(new RobotName { PrimeName = primeNameList.ElementAt(i), CrewName = crewNameList.ElementAt(i) });
			}

			return temp;
		}


		public struct RobotName
		{
			public string PrimeName { get; set; }
			public string CrewName { get; set; }
		}
	}
}