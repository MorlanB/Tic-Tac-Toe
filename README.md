# Tic-Tac-Toe
Tic-Tac-Toe game in Windows Forms.

FORM. The form contains a grid with nine buttons aligned to form the 3x3 board and a reset button. 

CODE. First, a multidimensional array is used to store the three rows of buttons with three buttons each, so that their behavior and format can be manipulated all at once with a pair of for statements. 

Each time a button is pressed a boolean “HasWon()” method is called to check if the player who pressed the button has won in that turn.
If that’s the case, a message box retrieves the player’s symbol (X or O) and displays it along the message “Player * has won” and the board is cleared.
If hasWon() is false, a bool variable that indicates the player’s turn changes value.

HasWon(). First, the method creates an array with pairs of indexes that indicate all possible winning alternatives. These indexes go by groups of three, representing the three symbols needed to connect a line over the grid. However, the groups are not shown in the array, but are taken at once in the for statement, which increases “i” by adding three at a time after each iteration.

Then, a for statement uses the coordinates in the index array to match them with the buttons array and check for a winning combination in the board. “If three of the buttons’ contents are the same in the specified coordinates, and they are not null, HasWon equals true, if not, then it returns false.” This way, a break can be called as soon as the winning combination is found and not necessarily after searching through all of them.
