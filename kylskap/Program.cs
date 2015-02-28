using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kylskap
{
	class Program
	{
		private static string HorizontalLine = "═════════════════════════════════════════";

		static void Main(string[] args)
		{
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("╔════════════════════════════════════════╗");
			Console.WriteLine("║         Kylskåpet COOLER <TM>          ║");
			Console.WriteLine("║             Modellnr: SN14             ║");
			Console.WriteLine("╚════════════════════════════════════════╝");
			Console.ResetColor();

			//Första testet
			Cooler cooler1 = new Cooler();
			Console.WriteLine(HorizontalLine);	              
			ViewTestHeader("Test 1.\nTest av standardkonstruktorn.");
			Console.WriteLine(cooler1.ToString());
			Console.WriteLine(HorizontalLine);

			//Andra testet
			Cooler cooler2 = new Cooler(24.5m, 4);
			ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, (24,5 och 4)");
			Console.WriteLine(cooler2.ToString());
			Console.WriteLine(HorizontalLine);

			// Tredje testet
			Cooler cooler3 = new Cooler(19.5m, 4, true, false);
			ViewTestHeader("Test 3.\nTest av konstrukorn med 4 parametrar, (19,5 ,4, True och False)");
			Console.WriteLine(cooler3.ToString());
			Console.WriteLine(HorizontalLine);

			// Fjärde testet
			Cooler cooler4 = new Cooler(5.3m, 4, true, false);
			ViewTestHeader("Test 4. \nTest av kylning med metoden Tick");
			Console.WriteLine(cooler4.ToString());
			Run(cooler4, 10);
			Console.WriteLine(HorizontalLine);

			// Femte testet
			Cooler cooler5 = new Cooler(5.3m, 4, false, false);
			ViewTestHeader("Test 5. \nTest av avstängt kyskåp med metoden Tick, vara avslaget och ha stängd dörr");
			Console.WriteLine(cooler5.ToString());
			Run(cooler5, 10);
			Console.WriteLine(HorizontalLine);

			// Sjätte testet 
			Cooler cooler6 = new Cooler(5.3m, 4, true, true);
			ViewTestHeader("Test 6. \nTest på påslaget kyskåp med metoden Tick, vara på och ha öppen dörr");
			Console.WriteLine(cooler6.ToString());
			Run(cooler6, 10);
			Console.WriteLine(HorizontalLine);

			// Sjunde testet
			Cooler cooler7 = new Cooler(19.7m, 4, false, true);
			ViewTestHeader("Test 7. \nTest av avslaget kyskåp med metoden Tick, ha öppen dörr");
			Console.WriteLine(cooler7.ToString());
			Run(cooler7, 10);
			Console.WriteLine(HorizontalLine);

			// Åttonde testet
			ViewTestHeader("Test 8. \nTest av egenskaperna så att undantag kastas då innertemperatur och \nmåltemperatur tilldelas felaktiga värden.");
			try
			{
				Cooler cooler8 = new Cooler();
				cooler8.InsideTemperature = 46.0m;
				Run(cooler8, 10);
			}
			catch (Exception)
			{
				ViewErrorMessage("\nInnertemperaturen är inte i intervallet 0 - 45°C");	
			}

			try
			{
				Cooler cooler8 = new Cooler();
				cooler8.TargetTemperature = -1m;
				Run(cooler8, 10);
			}
			catch (Exception)
			{
				ViewErrorMessage("Måltemperaturen är inte i intervallet 0 - 45°C");
			}
			Console.WriteLine(HorizontalLine);
 
			// Nionde testet
			ViewTestHeader("Test 9. \nTest av konstruktorer så att undantag kastas då innertemperatur och \nmåltemperatur tilldelas felaktiga värden.");
			try
			{
				Cooler cooler9 = new Cooler();
				cooler9.InsideTemperature = 46.0m;
				Run(cooler9, 10);
			}
			catch (Exception)
			{
				ViewErrorMessage("\nInnertemperaturen är inte i intervallet 0 - 45°C");
			}

			try
			{
				Cooler cooler9 = new Cooler();
				cooler9.TargetTemperature = -1m;
				Run(cooler9, 10);
			}
			catch (Exception)
			{
				ViewErrorMessage("Måltemperaturen är inte i intervallet 0 - 45°C");
			}

			Console.WriteLine();
		}
		private static void Run(Cooler cooler, int minutes)
		{
			for (int i = 0; i < 10; i++)
			{
				cooler.Tick();
				Console.WriteLine(cooler.ToString());
			}
		}
		private static void ViewErrorMessage(string message)
		{
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(message);
			Console.ResetColor();
		}
		private static void ViewTestHeader(string header)
		{
			Console.WriteLine(header);
		}
	}
}
