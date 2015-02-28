using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SolidaVolymer
{
	public class Cylinder : Solid
	{
		public override double BaseArea
		{
			get { return Math.PI * RadiusSquared; }
		}
		public override double SurfaceArea
		{
			get { return 2 * (Math.PI * Radius * (Radius + Height)); }
		}
		public override double Volume
		{
			get { return Math.PI * RadiusSquared * Height; }
		}

		public Cylinder(double height, double radius)
			:base(height, radius)
		{
		}

	}
}
