using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private const int BoardLength = 3;
        private int _FieldsLeft = 9;
        public enum Board
        {
            X,
            O,
            E
        }
        readonly Board[,] _board = new Board[BoardLength, BoardLength];
        //indicate when player1 turn and when player2 turn
        public int Player { get; private set; }

        public Board this[int i, int j] => _board[i, j];

        public TicTacToeGame()
        {
            Init();
        }

        private void Init()
        {
            Player = 0;
            for (var i = 0; i < BoardLength; i++)
                for (var j = 0; j < BoardLength; j++)
                    _board[i, j] = Board.E;
        }

        public void DisplayBoard()
        {
            Console.WriteLine("-------------");
            for (var i = 0; i < BoardLength; i++)
            {
                for (var j = 0; j < BoardLength; j++)
                {
                    if (j == 0)
                        Console.Write("| ");

                    switch (_board[i, j])
                    {
                        case Board.X:
                            Console.Write(_board[i, j]);
                            break;
                        case Board.O:
                            Console.Write(_board[i, j]);
                            break;
                        default:
                            Console.Write(_board[i, j]);
                            break;
                    }
                    Console.Write(" | ");

                }
                Console.WriteLine("\n-------------");
            }
        }

        public bool PlayerMove(int i, int j)
        {
            if (i >= BoardLength || i < 0 || j >= BoardLength || j < 0) return false;
            switch (_board[i, j])
            {
                case Board.E:
                    if (Player % 2 == 0)
                    {
                        _board[i, j] = Board.X;
                        if (IsGameOver(_FieldsLeft))
                        {
                            Environment.Exit(1);
                        }
                        Player++;
                        return true;
                    }
                    _board[i, j] = Board.O;
                    if (IsGameOver(_FieldsLeft))
                        Environment.Exit(1);
                    Player++;
                    return true;
            }
            return false;
        }

        public bool IsGameOver(int fieldsLeft)
        {
            if (_board[0, 0] == _board[0, 1] && _board[0, 0] == _board[0, 2] && _board[0, 0] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[1, 0] == _board[1, 1] && _board[1, 0] == _board[1, 2] && _board[1, 0] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[2, 0] == _board[2, 1] && _board[2, 0] == _board[2, 2] && _board[2, 0] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[0, 0] == _board[1, 0] && _board[0, 0] == _board[2, 0] && _board[0, 0] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[0, 1] == _board[1, 1] && _board[0, 1] == _board[2, 1] && _board[0, 1] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[0, 2] == _board[1, 2] && _board[0, 2] == _board[2, 2] && _board[0, 2] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[0, 0] == _board[1, 1] && _board[0, 0] == _board[2, 2] && _board[1, 1] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }
            if (_board[0, 2] == _board[1, 1] && _board[2, 0] == _board[0, 2] && _board[1, 1] != Board.E)
            {
                Console.WriteLine($"Player {Player%2 + 1} Won!");
                DisplayBoard();
                return true;
            }

            --fieldsLeft;
            if (fieldsLeft == 0)
            {
                Console.WriteLine("Game Over");
                DisplayBoard();
                return true;
            }
            return false;
        }
    }
}
