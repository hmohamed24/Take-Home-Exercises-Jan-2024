﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenoSystem
{
    public class Wall
    {
        //data members

        private string _Color;
        private int _Height;
        private string _PlanId;
        private int _Width;

        //constants

        private const int _HEIGHT = 100;
        private const int _WIDTH = 26;

        //properties

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentException("Color is missing! Please enter a Color to proceed.");
                }

                _Color = value;
            }
        }

        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (!Utilities.IsNonZeroPositive(value))
                {
                    throw new ArgumentException($"The Height value: {value} is invalid. Must be a positive value.");
                }

                if (!Utilities.IsValidMinimum(value, _HEIGHT))
                {
                    throw new ArgumentException($"The Height should be a minimum of {_HEIGHT} cm");
                }

                _Height = value;
            }
        }

        public string PlanId
        {
            get
            {
                return _PlanId;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentException("PlanId is missing! Please enter a PlanId to proceed.");
                }

                _PlanId = value;
            }
        }

        public int SurfaceArea
        {
            get
            {
                int wallopening = 0;
                if (WallOpening != null)
                    wallopening = WallOpening.Area;
                return (_Width * _Height) - wallopening;
            }

        }

        public Opening? WallOpening
        {
            get;
            private set;
        }

        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (!Utilities.IsNonZeroPositive(value))
                {
                    throw new ArgumentException($"The Width value: {value} is invalid. Must be a positive value.");
                }

                if (!Utilities.IsValidMinimum(value, _WIDTH))
                {
                    throw new ArgumentException($"The Width should be a minimum of {_WIDTH} cm");
                }

                _Width = value;
            }
        }

        //behaviours
        public override string ToString()
        {
            if (WallOpening == null)
            {
                return $"{PlanId},{Width},{Height},{Color}";

            }
            else
            {
                return $"{PlanId},{Width},{Height},{Color},{WallOpening.ToString()}";
            }
        }
        public Wall(string planid, int width, int height, string color, Opening? wallopening)
        {
            PlanId = planid;
            Width = width;
            Height = height;
            Color = color;
            WallOpening = wallopening;

            if (WallOpening != null)
            {
                int WallArea = _Width * _Height;
                double MinWallArea = 0.90 * WallArea;
                if (WallOpening.Area >= MinWallArea)
                {
                    throw new ArgumentException($"Opening limit exceeded: The area for the current opening is {WallOpening.Area}cm. It should be less than {MinWallArea}cm that is 90% of the wall area.");
                }
            }
        }
        public void DeleteOpening()
        {
            WallOpening = null;
        }
        public void ReplaceOpening(Opening opening)
        {

            if (opening == null)
            {
                throw new ArgumentNullException("Opening is missing! Please enter a new opening to replace the current one!");
            }

            WallOpening = opening;

        }

		public static Wall Parse(string item)
		{
			string[] pieces = item.Split(',');

			if (pieces.Length != 5)
			{
				throw new FormatException($"String not in expected format. Missing/excessive values(s): {item}");
			}

			return new Wall(pieces[0],
							int.Parse(pieces[1]),
							int.Parse(pieces[2]),
							pieces[3],
				            (Opening)Enum.Parse(typeof(Opening), pieces[4]));
		}

		public static bool TryParse(string item, out Wall result)
		{
			result = null;
			bool valid = true;
			try
			{
				result = Parse(item);
			}
			catch (Exception ex)
			{
				valid = false;
			}

			return valid;
		}
	}
}
