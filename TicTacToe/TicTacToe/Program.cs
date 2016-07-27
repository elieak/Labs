using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            var game = new TicTacToeGame();
            game.DisplayBoard();
            var gameRunning = true;
            Console.WriteLine("The Game Has Begun");
            while (gameRunning)
            {
                Console.WriteLine($"Player {game.Player % 2 + 1}, make a choice :");
                Console.WriteLine("[1] = make a move, [2] = display board, [3] = exit game");
                int userMove;
                var selectNextStep = int.TryParse(Console.ReadLine(), out userMove);
                if (selectNextStep)
                    switch (userMove)
                    {
                        case 1:
                            PlayerMove(game);
                            break;
                        case 2:
                            game.DisplayBoard();
                            break;
                        case 3:
                            gameRunning = false;
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, choose again: ");
                            break;
                    }
                else
                    Console.WriteLine("You made an invalid selection, choose again: ");
            }
        }

        private static void PlayerMove(TicTacToeGame game)
        {
            Console.Write("choose [i,j] :");
            var selection = Console.ReadLine()?.Split();
            if (selection == null) return;
            var i = int.Parse(selection[0]);
            var j = int.Parse(selection[1]);
            if (game.PlayerMove(i, j) == false)
                Console.WriteLine("You made an invalid selection, choose again: ");
        }
    }
}
