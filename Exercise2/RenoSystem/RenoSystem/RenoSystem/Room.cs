using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenoSystem
{
	public class Room
	{
		private string _Name;

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value.Trim()))
				{
					throw new ArgumentException("Name is missing! Please enter a Name to proceed.");
				}

				_Name = value;
			}
		}

		public string Flooring { get; set; }

		public List<Wall> Walls { get; private set; } = new();

		public int TotalWalls
		{
			get
			{
				return Walls.Count;
			}
			set { }
		}

		public Room(string name, string flooring, List<Wall> walls)
		{
			Name = name;
			Flooring = flooring;
			Walls = walls;
		}

		public void AddWall(Wall wall)
		{
			if (wall == null)
			{
				throw new ArgumentException("Wall information is missing! Please enter the information of the Wall to proceed.");
			}
			else
			{
				bool planIdExists = false;

				foreach (Wall w in Walls)
				{
					if (w.PlanId == wall.PlanId)
					{
						planIdExists = true;
					}
				}

				if (planIdExists)
				{
					throw new ArgumentException("PlanId already exists.");
				}
				else
				{
					Walls.Add(wall);
				}
			}
		}

		public void RemoveWall(string planId)
		{
			if (string.IsNullOrWhiteSpace(planId))
			{
				throw new ArgumentException("PlanId is missing! Please enter a PlanId to proceed.");
			}
			else
			{
				foreach (Wall wall in Walls)
				{
					if (wall.PlanId == planId)
					{
						Walls.Remove(wall);
					}
				}
			}
		}
	}
}
