﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidaVolymer
{
	class Program
	{
		private static Solid CreateSolid(SolidType solidType)
		{

			switch (solidType)
			{
				case SolidType.CircularCone:
					Console.Clear();
					Console.BackgroundColor = ConsoleColor.DarkGreen;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(" ╔═══════════════════════════════════╗ ");
					Console.WriteLine(" ║              Kon                  ║ ");
					Console.WriteLine(" ╚═══════════════════════════════════╝ ");
					Console.ResetColor();
					Console.WriteLine();
					break;
				case SolidType.Cylinder:
					Console.Clear();
					Console.BackgroundColor = ConsoleColor.DarkGreen;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(" ╔═══════════════════════════════════╗ ");
					Console.WriteLine(" ║             Cylinder              ║ ");
					Console.WriteLine(" ╚═══════════════════════════════════╝ ");
					Console.ResetColor();
					Console.WriteLine();
					break;
			}

			double radius = ReadDoubleGreaterThanZero("Ange radien (r): ");
			double height = ReadDoubleGreaterThanZero("Ange höjden (h): ");

			switch (solidType)
			{
				case SolidType.CircularCone:
					return new CircularCone(height, radius);
				case SolidType.Cylinder:
					return new Cylinder(height, radius);
				default:
					return null;
			}
		}

		static void Main(string[] args)
		{
			do
			{
				ViewMenu();
			
				switch (Console.ReadLine())
				{
					case "0": return;

					case "1": ViewSolidDetail(CreateSolid(SolidType.CircularCone));
						break;

					case "2": ViewSolidDetail(CreateSolid(SolidType.Cylinder));
						break;

					default: 
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("\nFel! Ange ett nummer mellan 0-2.");
						Console.ResetColor();
						break;
				}

				Console.BackgroundColor = ConsoleColor.DarkBlue;
				Console.WriteLine("\nTryck valfri tangent för att börja om. ESC avslutar!");
				Console.ResetColor();
			}
			while (Console.ReadKey(true).Key != ConsoleKey.Escape);
			
			
		}

		private static double ReadDoubleGreaterThanZero(string prompt)
		{
			while(true)
			{
				Console.Write(prompt);
				try
				{
					double flyttal = double.Parse(Console.ReadLine());
					if (flyttal < 0) 
					{
						throw new ArgumentException();
					}
					return flyttal;
				}
				catch
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("Fel! Ange ett flyttal större än 0.");
					Console.ResetColor();
				}
			}
			
		}

		private static void ViewMenu()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(" ╔═══════════════════════════════════╗ ");
			Console.WriteLine(" ║          Solida volymer           ║ ");
			Console.WriteLine(" ╚═══════════════════════════════════╝ ");
			Console.ResetColor();
			Console.WriteLine();
			Console.WriteLine(" 0. Avsluta.");
			Console.WriteLine("\n 1. Kon.");
			Console.WriteLine("\n 2. Cylinder.");
			Console.WriteLine("\n═══════════════════════════════════════");
			Console.Write(" Ange ditt menyval [0-2]: ");
		}

		private static void ViewSolidDetail(Solid solid)
		{
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			Console.WriteLine(" ╔═══════════════════════════════════╗ ");
			Console.WriteLine(" ║              Detaljer             ║ ");
			Console.WriteLine(" ╚═══════════════════════════════════╝ ");
			Console.ResetColor();
			Console.WriteLine();
			Console.WriteLine(solid.ToString());
			Console.WriteLine("\n═══════════════════════════════════════");
		
		}
	}
}