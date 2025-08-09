using System;
using System.Threading.Tasks.Dataflow;
namespace GameApp;




public class Game
{
    public static void Main(string[] args)
    {
        // The main entry point for the game
        // The game logic is implemented in the PlayGame method below
        PlayGame();
    }

    
    // Main game loop
    static void PlayGame()
    {
        int player = 1;
        int choice;
        int flag = 0;

        char[] board = new char[9];
        board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // Display Welcome message
        Console.WriteLine("_____________________________________________________________");
        Console.WriteLine("|              Welcome to Tic-Tac-Toe Game                   |");
        Console.WriteLine("______________________________________________________________");

        // A notice for game users
        Console.WriteLine("");
        Console.WriteLine("**Note:   The game ends only when there is a Winner or there is a Draw ");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("****************    Game   Board      *******************");
        Console.WriteLine("");

        do
        {
            DisplayBoard(board);
            player = (player % 2 == 0) ? 2 : 1;
            Console.WriteLine($"It is Player {player}'s turn to play now");
            Console.WriteLine("Please enter a number between 1 and 9 to place your mark on the board");
            String input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 9 && choice != 0)
            {
                if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    board[choice - 1] = (player == 1) ? 'X' : 'O';
                    player++;
                }
                else
                {
                    Console.WriteLine("This position is already occupied, please choose another position");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer number between 1 to 9");
                Console.ReadKey();
            }

            // Display the game board after each turn
            flag = CheckWin(board);
        } while (flag != 1 && flag != -1);

        // Display the result of the game
        if (flag == 1)
        {
            DisplayBoard(board);
            Console.WriteLine($"Player {--player} won the game");
        }
        else
        {
            Console.WriteLine("There was a draw, press....");
            Console.ReadKey();
        }
    }


    // Function to display the Game Board
    static void DisplayBoard(char[] board)
    {
        Console.WriteLine("______________________________________________________________________");
        Console.WriteLine(" |                     |                       |                     |");
        Console.WriteLine($"             {board[0]}                   {board[1]}                     {board[2]}      ");
        Console.WriteLine(" |                     |                       |                     |");
        Console.WriteLine("______________________________________________________________________");
        Console.WriteLine("______________________________________________________________________");
        Console.WriteLine(" |                     |                       |                     |");
        Console.WriteLine($"             {board[3]}                   {board[4]}                     {board[5]}      ");
        Console.WriteLine(" |                     |                       |                     |");
        Console.WriteLine("______________________________________________________________________");
        Console.WriteLine("______________________________________________________________________");
        Console.WriteLine(" |                     |                       |                     |");
        Console.WriteLine($"             {board[6]}                   {board[7]}                     {board[8]}      ");
        Console.WriteLine(" |                     |                       |                     |");
        Console.WriteLine("______________________________________________________________________");
    }



    // Function to check if there is a winner or it is a draw or the game is still ongoing
    public static int CheckWin(char[] board)
    {
        // Checking all possible winning combinations on the board
        // Check the same symbol along the rows.
        if (board[0] == board[1] && board[1] == board[2] && board[0] == board[2]) return 1;
        if (board[3] == board[4] && board[4] == board[5] && board[3] == board[5]) return 1;
        if (board[6] == board[7] && board[7] == board[8] && board[6] == board[8]) return 1;

        // Check the same symbol along the columns.
        if (board[0] == board[3] && board[3] == board[6] && board[0] == board[6]) return 1;
        if (board[1] == board[4] && board[4] == board[7] && board[1] == board[7]) return 1;
        if (board[2] == board[5] && board[5] == board[8] && board[2] == board[8]) return 1;

        // Check the same symbol along the diagonals.
        if (board[2] == board[4] && board[4] == board[6] && board[2] == board[6]) return 1;
        if (board[0] == board[4] && board[4] == board[8] && board[0] == board[8]) return 1;

        // Check for a draw
        if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5]
           != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9') return -1;

        // If no winner and no draw, the game is still ongoing
        return 0;
    }
}



