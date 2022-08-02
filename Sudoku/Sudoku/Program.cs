namespace sudoku
{
	class Program
	{
		static void Main(string[] args)
		{
			Field sudoku = new Field();
			Console.WriteLine(sudoku);
			sudoku[0,0] = 1;	// +
			sudoku[0,4] = 9;	// wrong
			sudoku[0,4] = 7;	// +
			sudoku[0,5] = 10;	// wrong
			sudoku.Undo();		// -
			sudoku[1,3] = 1;	// +
			sudoku.Undo();		// -
			sudoku.Undo();		// -
		}
	}

	class Field
	{
		private int[,] field = new int[9, 9]
		{
			{0, 8, 9, 0, 0, 0, 3, 0, 0 },
			{0, 0, 0, 0, 3, 6, 0, 2, 9 },
			{0, 0, 0, 0, 0, 2, 5, 0, 0 },
			{0, 7, 3, 0, 0, 0, 4, 8, 2 },
			{0, 0, 0, 5, 0, 8, 0, 0, 0 },
			{0, 0, 0, 4, 0, 0, 0, 0, 7 },
			{7, 9, 0, 3, 6, 0, 0, 1, 8 },
			{0, 0, 0, 0, 5, 0, 0, 0, 6 },
			{3, 0, 2, 0, 9, 0, 0, 0, 5 }
		};

		SudokuHistory history = new SudokuHistory();

		public Field this[int i, int j]
		{
			get;
			set
			{
				bool correct = true;
				if (value < 1 || value > 9)
				{
					correct = false;
				}
				if (correct)
				{
					for (int index = 0; index < 9; index++)
					{
						if (value == this[index,j])
						{
							correct = false;
						}
						if (value == this[i, index])
						{
							correct = false;
						}
					}
				}
				if (correct)
				{
					this.SaveState();
					this[i, j] = value;
					//
					Console.WriteLine("\nChanged correctly!:");
					Console.WriteLine(field);
				}   
			}
		}

		private SudokuMomento SaveState()
		{
			//
			Console.WriteLine("\nState is saved!:");
			Console.WriteLine(field);
			history.history.Push(new SudokuMomento(field));
		}

		public void Undo()
		{
			SudokuMemento memento = history.history.Pop();
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					this.field[i, j] = state.field[i, j];
				}
			}
			//
			Console.WriteLine("\nUndo is done!(new):");
			Console.WriteLine(field);
		}

		public override string ToString()
		{
			string fieldStr = "";
			foreach (var i in field)
			{
				foreach (var j in i)
				{
					fieldStr += j.ToString() + " ";
				}
				fieldStr += "\n";
			}
			return fieldStr;
		}
	}

	class SudokuMemento
	{
		pub int[,] field { get; private set; }

		public SudokuMemento(int[9, 9] f)
		{
			field = new int[9, 9];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					field[i, j] = f[i, j];
				}
			}
		}
	}

	class SudokuHistory
	{
		public Stack<SudokuMemento> history { get; private set; }
		public SudokuHistory()
		{
			history = new Stack<SudokuMemento>();
		}

	}
}