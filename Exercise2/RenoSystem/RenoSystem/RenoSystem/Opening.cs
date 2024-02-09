namespace RenoSystem
{
	public class Opening
	{
		private int _edging = 0;
		private int _height = 0;
		private int _width = 0;

		public int Edging
		{
			get { return _edging; }
			set
			{
				if (value != 0 && !Utilities.IsValidMinimum(value, 10))
				{
					throw new ArgumentException("The minimum edging is 10 cm.");
				}

				_edging = value;
			}
		}

		public int Height
		{
			get { return _height; }
			set
			{
				if (!Utilities.IsValidMinimum(value, 120))
				{
					throw new ArgumentException("The minimum height is 120 cm.");
				}

				_height = value;
			}
		}

		public int Width
		{
			get { return _width; }
			set
			{
				if (!Utilities.IsValidMinimum(value, 50))
				{
					throw new ArgumentException("The minimum width is 50 cm.");
				}

				_width = value;
			}
		}

		public int Area
		{
			get { return Width * Height; }
		}

		public int Perimeter
		{
			get { return (Width + Height) * 2; }
		}

		public OpeningType Type { get; set; }		

		public Opening(int width, int height, OpeningType type, int edging = 0)
		{
			Width = width;
			Height = height;
			Type = type;
			Edging = edging;
		}

		public string ToString()
		{
			return $"{Width},{Height},{Type},{Edging}";
		}
	}
}
