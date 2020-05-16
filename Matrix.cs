using System;
using System.Threading;

namespace MatrixOperations
{
	class Matrix
	{
		private int numberOfRows;
		private int numberOfColumns;
		private Row[] arrayOfRows;

		public Matrix(int rows, int columns)
		{
			this.numberOfRows = rows;
			this.numberOfColumns = columns;
			this.arrayOfRows = new Row[numberOfRows];

			for (int i = 0; i < numberOfRows; i++)
			{
				arrayOfRows[i] = new Row(numberOfColumns);
			}
		}

		public void PrintMatrix()
		{
			for (int i = 0; i < numberOfRows; i++)
			{
				arrayOfRows[i].PrintRow();
				Console.Write("\n");
			}
		}

		public int GetNumberOfRows()
		{
			return numberOfRows;
		}

		public void FillMatrix()
		{
			for (int i = 0; i < this.numberOfRows; i++)
			{
				for (int j = 0; j < this.numberOfColumns; j++)
				{
					Console.Clear();
					this.PrintMatrix();
					Console.WriteLine("enter the next number");
					double input = Convert.ToDouble(Console.ReadLine());
					this.arrayOfRows[i].rowArray[j] = input;
				}
				Console.Clear();
				this.PrintMatrix();
			}
		}

		public void SwapRows()
		{
			Console.WriteLine("Enter the first row to swap (start counting at zero)\n" +
				"press q to cancel");
			String input = Console.ReadLine();
			if (input == "q")
			{
				return;
			}
			else
			{
				try
				{
					int firstRow = Convert.ToInt32(input);
					Console.WriteLine("Enter the second row to swap (start counting at zero)");
					int secondRow = Convert.ToInt32(Console.ReadLine());

					Row temp = arrayOfRows[firstRow];
					arrayOfRows[firstRow] = arrayOfRows[secondRow];
					arrayOfRows[secondRow] = temp;

					Program.PrintMenu();
					this.PrintMatrix();
				}
				catch (FormatException e)
				{
					throw;
				}
				catch (IndexOutOfRangeException e)
				{
					throw;
				}
			}
		}

		public void MultiplyByScalar()
		{
			Console.WriteLine("Enter the row you want to multiply (start counting at zero)\n" +
				"press q to cancel");
			String input = Console.ReadLine();
			if (input == "q")
			{
				return;
			}
			else
			{
				int rowNumber = Convert.ToInt32(input);
				Console.WriteLine("Enter the number you want to multiply this row by");
				double scalar = Convert.ToDouble(Console.ReadLine());

				for (int i = 0; i < this.numberOfColumns; i++)
				{
					arrayOfRows[rowNumber].rowArray[i] = (arrayOfRows[rowNumber].rowArray[i] * scalar);
				}

				Program.PrintMenu();
				this.PrintMatrix();
			}
		}

		public void AddRows()
		{
			Boolean complete = false;
			while (complete == false)
			{
				Console.WriteLine("Enter the first row you want to add (start counting at zero)" +
					",This row will stay unchanged\n" + 
					"press q to cancel");
				String input = Console.ReadLine();
				if (input == "q")
				{
					return;
				}
				else
				{
					int firstRow = Convert.ToInt32(input);
					Console.WriteLine("Enter the row you want to add the first row to (start counting at zero)");
					int secondRow = Convert.ToInt32(Console.ReadLine());

					if (firstRow == secondRow)
					{
						Console.WriteLine("you cannot add a row to inself, returning to main menu");
						Thread.Sleep(1000);
					}
					else
					{
						for (int i = 0; i < numberOfColumns; i++)
						{
							arrayOfRows[secondRow].rowArray[i] = arrayOfRows[secondRow].rowArray[i] +
								arrayOfRows[firstRow].rowArray[i];
						}
						complete = true;
					}
				}
			}
		}
	}
}
