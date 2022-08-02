# **Computer Workshop #5:** Behaviour patterns
**Objective:** *get acquainted with basic behaviour patterns, learn how to apply them in software design and development.*

## :brain: Statement of the task of computer workshop #5:
The following steps are required in completing the computer workshop:
1) Study behavioral patterns. Know the general characteristics and purpose of each of them, peculiarities of implementation of each behavioral pattern and cases of their application.
2) Implement the task according to the variant suggested below. Develop interfaces and classes to apply one or more patterns. Fully implement methods related to the implementation of the chosen pattern.
3) Complete outline of the project architecture (assigning of methods and classes), peculiarities of implementation of the selected pattern. For each pattern, specify the main classes and their purpose.
4) Draw the UML diagram of the class

All variants you can find [here]() :point_left:.

## :eyes: Variant #1:
Implement Sudoku game algorithm. To implement the ability to "undo".

## :shrug: Choosing a pattern
Since we are faced with the problem of "Undo". The obvious solution is to use the "Memento" pattern. With it we are able to save the game states from the beginning to the current view. So to implement the pattern, we need a class whose data will be used to save the state - Field (Sudoku field). The class that saves the state is SudokuMemento, and the class with the stack of states is SudokuHistory.

Since the state is saved each time the client moves, the ability to create a SudokuMemento object (saving the state) is better to be provided not to the client, but to make this call directly when the client enters a new number into sudoku without the client knowing it. Consequently, it makes sense to make the SaveState() method private in the Field class. And the "Undo" method is already custom, and returns the state of the field at the client's preliminary move.


## :office: The architecture of the project
1. class Field - represents Sudoku field with the ability to interact with it.
    Attributes:
        - Field (basic sudoku field of size 9 by 9),
        - H (the stack of categorizations, SudokuHistory object).
    Methods:
        - SetValue(int horizontal, int vertical, int value): allows the client to put numbers on the sudoku field vertically and horizontally, checking that the number is between 1 and 9, and the insertion will not break sudoku rules (can't have the same numbers on the same line ). If the insertion succeeds, it additionally saves the state; if it fails, it causes an error message.
        - private SaveState() is a method that adds a new current game state to the H stack. It is used in the SetValue() method.
        - Undo() - this method returns the state of the field on the previous turn.

2. class SudokuMemento - a class that holds the array-field of class Field, thereby saving the game state.
3. class SudokuHistory - a class that performs the function of storing states in the stack.

:art: [Final diagram](https://github.com/MilaHalko/C4_.NET/blob/Lab5/Diagrams/SudokuMemento.jpg)

:memo: [Full report PDF](https://github.com/MilaHalko/C4_.NET/blob/Lab5/Reports%26Variants/Lab5.pdf)/[docx](https://github.com/MilaHalko/C4_.NET/blob/Lab5/Reports%26Variants/Lab5.docx)

:computer: [Full code](https://github.com/MilaHalko/C4_.NET/tree/Lab5/SudokuMementoProg/SudokuMementoProg) 
