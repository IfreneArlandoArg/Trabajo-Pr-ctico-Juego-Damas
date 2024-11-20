using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using DAL;

namespace BLL
{
    public class PartidaManager
    {
        private const int BoardSize = 8;
        private string[,] board = new string[BoardSize, BoardSize];
        private int currentPlayer = 1; // 1 for Player 1, 2 for Player 2

        private readonly PartidaDataAccess partidaDataAccess = new PartidaDataAccess();
        private readonly BitacoraDataAccess bitacoraDataAccess = new BitacoraDataAccess();
        

        private int partidaID;
        private int jugador1ID;
        private int jugador2ID;

        public event Action<int> OnWinnerDeclared;


        public PartidaManager(int jugador1, int jugador2)
        {
            jugador1ID = jugador1;
            jugador2ID = jugador2;

            // Start a new game in the database
            partidaID = partidaDataAccess.IniciarPartida(jugador1ID, jugador2ID, DateTime.Now);

            // Log game start
            bitacoraDataAccess.RegistrarEvento(jugador1ID, "Comienzo de partida");
            bitacoraDataAccess.RegistrarEvento(jugador2ID, "Comienzo de partida");

            InitializeBoard();
        }

        public string[,] GetBoardState()
        {
            return board;
        }

        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void InitializeBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if ((row < 3 || row > 4) && (row + col) % 2 != 0)
                    {
                        board[row, col] = row < 3 ? "O" : "X";
                    }
                    else
                    {
                        board[row, col] = null;
                    }
                }
            }
        }

        public string GetPieceAt(Point position)
        {
            return board[position.X, position.Y];
        }

        private bool IsValidMove(Point from, Point to)
        {
            int rowDiff = to.X - from.X;
            int colDiff = to.Y - from.Y;

            if (to.X < 0 || to.X >= BoardSize || to.Y < 0 || to.Y >= BoardSize)
                return false; // Out of bounds

            string piece = board[from.X, from.Y];
            if (piece == null)
                return false; // No piece to move

            bool isKing = piece.Contains("(K)");
            char playerSymbol = piece[0]; // 'O' or 'X'

            // Ensure it's the current player's piece
            if ((currentPlayer == 1 && playerSymbol != 'O') || (currentPlayer == 2 && playerSymbol != 'X'))
                return false; // Not the current player's piece

            // For kings, allow all diagonal directions
            int[] validDirections = isKing ? new int[] { -1, 1 } : new int[] { (playerSymbol == 'O') ? 1 : -1 };

            // Regular move (one step diagonally)
            if (Math.Abs(rowDiff) == 1 && Math.Abs(colDiff) == 1)
            {
                if (Array.Exists(validDirections, d => d == rowDiff))
                {
                    return board[to.X, to.Y] == null; // Destination must be empty
                }
            }

            // Capture move (jumping over an opponent)
            if (Math.Abs(rowDiff) == 2 && Math.Abs(colDiff) == 2)
            {
                int middleRow = from.X + rowDiff / 2;
                int middleCol = from.Y + colDiff / 2;
                string middlePiece = board[middleRow, middleCol];

                if (middlePiece != null)
                {
                    char middlePlayerSymbol = middlePiece[0];

                    // Ensure middle piece is opponent's
                    if (middlePlayerSymbol != playerSymbol)
                    {
                        return board[to.X, to.Y] == null; // Destination must be empty
                    }
                }
            }

            return false; // Invalid move
        }



        public bool MakeMove(Point from, Point to)
        {
            if (!IsValidMove(from, to))
                return false;

            // Move the piece
            string piece = board[from.X, from.Y];
            board[to.X, to.Y] = piece;
            board[from.X, from.Y] = null;

            // Check for capture move
            if (Math.Abs(to.X - from.X) == 2)
            {
                int middleRow = (from.X + to.X) / 2;
                int middleCol = (from.Y + to.Y) / 2;
                board[middleRow, middleCol] = null; // Remove captured piece
            }

            // Check for king promotion
            if ((currentPlayer == 1 && to.X == BoardSize - 1) || (currentPlayer == 2 && to.X == 0))
            {
                board[to.X, to.Y] += " (K)";
            }

            SwitchTurn();
            CheckWinner(); // Check if there's a winner after this move
            return true;
        }





        private void SwitchTurn()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }

        public bool CheckEndGame()
        {
            // Count the pieces for both players
            var (countO, countX) = CountPieces();

            // Debugging: Log the piece counts
            Console.WriteLine($"Player 1 (O) Pieces: {countO}, Player 2 (X) Pieces: {countX}");

            // Check if a player has no pieces left
            if (countO == 0)
            {
                DeclareWinner(2); // Player 2 wins
                return true;
            }
            else if (countX == 0)
            {
                DeclareWinner(1); // Player 1 wins
                return true;
            }

            // Check if either player has no valid moves left
            bool player1HasMoves = false;
            bool player2HasMoves = false;

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    string piece = board[row, col];
                    if (piece == null) continue;

                    // Check for valid moves for each player
                    if (piece.StartsWith("O") && !player1HasMoves) player1HasMoves = HasLegalMove(row, col);
                    if (piece.StartsWith("X") && !player2HasMoves) player2HasMoves = HasLegalMove(row, col);

                    // If both players still have moves, no need to continue checking
                    if (player1HasMoves && player2HasMoves) return false;
                }
            }

            // Debugging: Log whether players have moves
            Console.WriteLine($"Player 1 Has Moves: {player1HasMoves}, Player 2 Has Moves: {player2HasMoves}");

            // Declare the winner if a player has no valid moves
            if (!player1HasMoves)
            {
                DeclareWinner(2); // Player 2 wins
                return true;
            }
            else if (!player2HasMoves)
            {
                DeclareWinner(1); // Player 1 wins
                return true;
            }

            return false; // Game is not over
        }





        private void DeclareWinner(int winnerPlayerID)
        {
            // Log the end of the game
            partidaDataAccess.FinalizarPartida(partidaID, winnerPlayerID, DateTime.Now);

            bitacoraDataAccess.RegistrarEvento(jugador1ID, "Fin de partida");
            bitacoraDataAccess.RegistrarEvento(jugador2ID, "Fin de partida");

            // Announce the winner
            MessageBox.Show($"Juego terminado. \nGanador: Jugador {winnerPlayerID}");

            
        }



        public void CheckWinner()
        {
            var (countO, countX) = CountPieces();

            // Debugging: Log the counts
            Console.WriteLine($"CountPieces: Player 1 (O) = {countO}, Player 2 (X) = {countX}");

            if (countO == 3)
            {
                OnWinnerDeclared?.Invoke(2); // Player 2 wins
            }
            else if (countX == 3)
            {
                OnWinnerDeclared?.Invoke(1); // Player 1 wins
            }
        }

        private (int countO, int countX) CountPieces()
        {
            int countO = 0; // Count for Player 1
            int countX = 0; // Count for Player 2

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    string piece = board[row, col];
                    if (piece == null) continue;

                    if (piece.StartsWith("O")) countO++; // Count Player 1 pieces
                    if (piece.StartsWith("X")) countX++; // Count Player 2 pieces
                }
            }

            return (countO, countX);
        }






        private bool HasLegalMove(int row, int col)
        {
            string piece = board[row, col];
            if (piece == null) return false; // No piece here

            bool isKing = piece.Contains("(K)");
            int[] directions = isKing ? new int[] { -1, 1 } : new int[] { (piece.StartsWith("O") ? 1 : -1) };

            // Check for regular moves
            foreach (int direction in directions)
            {
                for (int dCol = -1; dCol <= 1; dCol += 2) // Diagonal directions
                {
                    int newRow = row + direction;
                    int newCol = col + dCol;

                    if (IsInBounds(newRow, newCol) && board[newRow, newCol] == null)
                    {
                        return true; // Valid move
                    }
                }
            }

            // Check for capture moves
            foreach (int direction in directions)
            {
                for (int dCol = -2; dCol <= 2; dCol += 4) // Capturing moves
                {
                    int middleRow = row + direction / 2;
                    int middleCol = col + dCol / 2;
                    int newRow = row + direction;
                    int newCol = col + dCol;

                    if (IsInBounds(newRow, newCol) && board[newRow, newCol] == null)
                    {
                        string middlePiece = board[middleRow, middleCol];
                        if (middlePiece != null && middlePiece[0] != piece[0])
                        {
                            return true; // Valid capture
                        }
                    }
                }
            }

            return false; // No valid moves
        }




        // Helper method to check bounds
        private bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < BoardSize && col >= 0 && col < BoardSize;
        }


        public void EndGame(int winnerID)
        {
            // Finalize the game
            partidaDataAccess.FinalizarPartida(partidaID, winnerID, DateTime.Now);

            // Log game end
            bitacoraDataAccess.RegistrarEvento(jugador1ID, "Fin de partida");
            bitacoraDataAccess.RegistrarEvento(jugador2ID, "Fin de partida");
        }



    }
}

