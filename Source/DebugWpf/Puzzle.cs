using System.Diagnostics;

namespace DebugWpf
{
	internal class Puzzle
	{
		public static bool IsPalindrome(string originalPhrase)
		{
			if (Debugger.IsAttached)
				Debugger.Break();
			var workingPhrase = originalPhrase.ToLower();

			workingPhrase = workingPhrase.Replace(" ", "");
			var currentLength = workingPhrase.Length;
			if (workingPhrase.Length == 1 || workingPhrase.Length == 0)
			{ return true; }
			if (workingPhrase[0] != workingPhrase[workingPhrase.Length - 1])
			{ return false; }

			return IsPalindrome(workingPhrase.Substring(1, workingPhrase.Length - 2)); ;
		}
	}
}