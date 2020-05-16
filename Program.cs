using System;
using System.Threading;

namespace MatrixOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of rows");
			int rowNumber = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the number of columns");
			int columnNumber = Convert.ToInt32(Console.ReadLine());
			Matrix matrix1 = new Matrix(rowNumber, columnNumber);

			matrix1.FillMatrix();

			bool resume = true;
			while (resume == true)
			{
				PrintMenu();
				matrix1.PrintMatrix();
				int userChoice = 5;
				try
				{
					userChoice = Convert.ToInt32(Console.ReadLine());
				}
				catch (FormatException e)
				{
					//do nothing
				}

				switch (userChoice)
				{
					case 1:
						try
						{
							matrix1.SwapRows();
						}
						catch (Exception e)
						{
							Console.WriteLine("You have entered an invalid number, returning to main menu");
							Thread.Sleep(1000);
						}
						break;
					case 2:
						try
						{
							matrix1.MultiplyByScalar();
						}
						catch (Exception e)
						{
							Console.WriteLine("You have entered an invalid number, returning to main menu");
							Thread.Sleep(1000);
						}
						break;
					case 3:
						try
						{
							matrix1.AddRows();
						}
						catch (Exception e)
						{
							Console.WriteLine("You have entered an invalid number, returning to main menu");
							Thread.Sleep(1000);
						}
						break;
					case 4:
						resume = false;
						break;
					default:
						Console.WriteLine("The number entered does not match any of the options");
						break;
				}
			}

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}

		public static void PrintMenu()
		{
			Console.Clear();
			Console.WriteLine("{0,20}", "Main Menu:");
			Console.WriteLine("Press 1 to swap rows");
			Console.WriteLine("Press 2 to multiply a row by a scalar");
			Console.WriteLine("Press 3 to add one row to another row");
			Console.WriteLine("Press 4 to exit");
			Console.WriteLine();
		}
	}
}
