namespace SudokuMementoProg
{
	internal class SudokuMemento
	{
		public int[,] field { get; private set; }
		public SudokuMemento(int[,] field)
		{
			this.field = new int[9, 9];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					this.field[i, j] = field[i, j];
				}
			}
		}
	}
}
