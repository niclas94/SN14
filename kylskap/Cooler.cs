using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kylskap
{
	class Cooler
	{
		private decimal _insideTemperature;
		private decimal _targetTemperature;
		private const decimal OutsideTemperature = 23.7m;

		public bool DoorIsOpen { get; set; }

		public decimal InsideTemperature 
		{
		
			get
			{
				return _insideTemperature;
			}

			set
			{
				if(value > 45 || value < 0)
				{
					throw new ArgumentException();
				}
				_insideTemperature = value;
			}
		}

		public bool IsOn{ get; set; }

		public decimal TargetTemperature 
		{

			get
			{
				return _targetTemperature;
			}

			set 
			{
				if (value > 20 || value < 0) 
				{
					throw new ArgumentException();
				}

				_targetTemperature = value;
			}
		}

		public Cooler()
			: this (0, 0)
		{

		}
		public Cooler(decimal insideTemperature, decimal targetTemperature)
			: this(insideTemperature, targetTemperature, false, false)
		{

		}
		public Cooler(decimal insideTemperature, decimal targetTemperature, bool isOn, bool doorisOpen)
		{
			InsideTemperature = insideTemperature;
			TargetTemperature = targetTemperature;
			IsOn = isOn;
			DoorIsOpen = doorisOpen;
		}

		public void Tick()
		{
			decimal change = 0;

			if (IsOn == true && DoorIsOpen == false)
			{ 
				change -= 0.2m;
			}
			else if (IsOn == true && DoorIsOpen == true)
			{
				change += 0.2m;
			}
			else if (IsOn == false && DoorIsOpen == false)
			{
				change += 0.1m;
			}
			else if (IsOn == false && DoorIsOpen == true)
			{
				change += 0.5m;
			}

			if(InsideTemperature + change < TargetTemperature)
			{
				InsideTemperature = TargetTemperature;
			}
			else if (InsideTemperature + change > OutsideTemperature)
			{
				InsideTemperature = OutsideTemperature;
			}
			else 
			{
				InsideTemperature += change;
			}
		}
		public override string ToString() 
		{
			return string.Format("[{0}] : {1:F1}°C : ({2:F1}°C) - {3}", IsOn == true ? "PÅ" : "AV", InsideTemperature, TargetTemperature, DoorIsOpen == true ? "Öppet" : "Stängt");
		}		
	}
}
