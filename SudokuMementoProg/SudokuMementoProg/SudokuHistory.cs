namespace SudokuMementoProg
{
    internal class SudokuHistory
	{
		public Stack<SudokuMemento> history { get; private set; }
		public SudokuHistory()
		{
			history = new Stack<SudokuMemento>();
		}

	}
}
