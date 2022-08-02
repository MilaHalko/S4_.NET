using SudokuMementoProg;

namespace sudoku
{
	class Program
	{
		static void Main(string[] args)
		{
			Field sudoku = new Field();
            Console.WriteLine("*** SUDOKU GAME STARTED:");
			Console.WriteLine(sudoku);
			sudoku.Undo();
			sudoku.SetValue(0, 0, 1); // +
			sudoku.SetValue(0, 4, 9); // wrong
			sudoku.SetValue(0, 4, 7); // +
			sudoku.SetValue(0, 5, 10);// wrong
			sudoku.Undo();            // -
			sudoku.SetValue(1, 3, 1); // +
			sudoku.Undo();			  // -
			sudoku.Undo();            // -
			sudoku.Undo();            // -
		}
	}
}