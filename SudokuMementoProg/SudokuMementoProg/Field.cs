namespace SudokuMementoProg
{
	internal class Field
	{
		private int[,] field =
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

		private SudokuHistory H = new SudokuHistory();
		public void SetValue(int horizontal, int vertical, int value)
		{
			Console.WriteLine($"\n*** SET [{horizontal}, {vertical}] = {value}");
			bool correct = true;
			if (value < 1 || value > 9)
			{
				correct = false;
			}
			if (correct)
			{
				for (int index = 0; index < 9; index++)
				{
					if (value == field[index, vertical])
					{
						correct = false;
					}
					if (value == field[horizontal, index])
					{
						correct = false;
					}
				}
			}
			if (correct)
			{
				Console.WriteLine("Saving process:");
				this.SaveState();
				Console.WriteLine("State is pushed! Old Sudoku:");
				this.PrintWithNumberBold(horizontal, vertical);
				field[horizontal, vertical] = value;
				Console.WriteLine("New Sudoku:");
				this.PrintWithNumberBold(horizontal, vertical);
			}
			else
			{
				Console.WriteLine("New value is not possible!");
				this.PrintWithNumberBold(horizontal, vertical);
			}
		}

		private void SaveState()
		{
			H.history.Push(new SudokuMemento(field));
		}

		public void Undo()
		{
			Console.WriteLine("\n*** UNDO STEP:");
			if (H.history.Count() > 0)
			{
				Console.WriteLine("Undo Process. Current Sudoku:");
				Console.WriteLine(this);

				SudokuMemento memento = H.history.Pop();
				int i_ = -1, j_ = -1;
				bool changed = false;
				for (int i = 0; i < 9; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						if (this.field[i, j] != memento.field[i, j])
						{
							i_ = i;
							j_ = j;
							this.field[i, j] = memento.field[i, j];

							changed = true;
							break;
						}
					}
					if (changed)
					{
						break;
					}
				}
				//
				Console.WriteLine("Undo is done! Previous Sudoku:");
				this.PrintWithNumberBold(i_, j_);
			}
			else
			{
				Console.WriteLine("Stack is empty -> Undo is impossible!");
			}
		}

		public override string ToString()
		{
			string fieldStr = "";
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					fieldStr += field[i, j].ToString() + " ";
				}
				fieldStr += "\n";
			}
			return fieldStr;
		}

		private void PrintWithNumberBold(int horizontal, int vertical)
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (horizontal == i && vertical == j)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write(field[i, j].ToString() + " ");
						Console.ResetColor();
					}
					else
					{
						Console.Write(field[i, j].ToString() + " ");
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
