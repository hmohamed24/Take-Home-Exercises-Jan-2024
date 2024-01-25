using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenoSystem
{
	public static class Utilities
	{
		public static bool IsNonZeroPositive(int numeric)
		{
			return numeric > 0;
		}

		public static bool IsZeroPositive(int numeric)
		{
			return numeric >= 0;
		}

		public static bool IsValidMinimum(int numeric, int minimum)
		{
			return numeric >= minimum;
		}
	}
}
