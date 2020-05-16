using System;

namespace MatrixOperations
{
	class Row
	{
		public double[] rowArray;

		public Row(int size)
		{
			this.rowArray = new double[size];
		}

		public void PrintRow()
		{
			for (int i = 0; i < rowArray.Length; i++)
			{
				Console.Write("[{0,5:0.##}]", rowArray[i]);
			}
		}
	}
}
