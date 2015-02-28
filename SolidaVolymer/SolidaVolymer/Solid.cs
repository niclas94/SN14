using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SolidaVolymer
{

	public abstract class Solid
	{
		private double _height;
		private double _radius;

		public double Height
		{
			get
			{
				return _height;
			}

			set
			{
				if (value == 0)
				{
					throw new ArgumentException();
				}
				_height = value;

			}
		}
		public double HeightSquared
		{
			get
			{
				return _height * _height;
			}
		}
		public double Radius
		{
			get
			{
				return _radius;
			}

			set
			{
				if (value == 0)
				{
					throw new ArgumentException();
				}
				_radius = value;
			}

		}
		public double RadiusSquared
		{
			get
			{
				return _radius * _radius;
			}
		}

		public abstract double BaseArea { get; }
		public abstract double SurfaceArea { get; }
		public abstract double Volume { get; }

		protected Solid(double height, double radius)
		{
			Height = height;
			Radius = radius;
		}

		public override string ToString()
		{
			return string.Format("{0,-12:}:{1,12:f2}\n{2,-12}:{3,12:f2}\n{4,-12}:{5,12:f2}\n{6,-12}:{7,12:f2}\n{8,-12}:{9,12:f2}\n",
			"Radie (r)", Radius, 
			"Höjd (h)", Height, 
			"Volym", Volume, 
			"Basarea", BaseArea, 
			"Ytarea", SurfaceArea);
		}
	}
}
