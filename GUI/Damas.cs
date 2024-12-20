﻿using BE;
using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Damas : Form
    {
        private const int BoardSize = 8;
        private const int TileSize = 50;
        private Button[,] boardTiles = new Button[BoardSize, BoardSize];
        int jugador1ID = 0, jugador2ID = 0;

        public Damas()
        {
            InitializeComponent();
        }

        PartidaManager partidaManager;
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        private void HandleWinnerDeclared(int winnerPlayerID)
        {
            int IdGanador = winnerPlayerID == 1 ? jugador1ID : jugador2ID;
            Jugador tempUser = usuarioBLL.GetUsuario(IdGanador);

            MessageBox.Show($"Juego terminado. \nGanador: {tempUser.NombreUsuario}");
            MessageBox.Show($"\"Hay qué cerrar el estadio, los genios hacen esto...\"");
            this.Close();
        }

        private void Damas_Load(object sender, EventArgs e)
        {
            try
            {
                LoginForm login = new LoginForm();
              //  int jugador1ID = 0, jugador2ID = 0;

                // Player 1 Login
                MessageBox.Show("Jugador 1, por favor inicie sesión.");
                while (!login.Registrado)
                {
                    login.ShowDialog();
                    if (login.Cancelado)
                    {
                        MessageBox.Show("Inicio de sesión cancelado. Cerrando aplicación.");
                        this.Close();
                        return;
                    }

                    if (login.countLogin == 3)
                    {
                        MessageBox.Show("Intentos de inicio de sesión excedidos. Cerrando aplicación.");
                        this.Close();
                        return;
                    }
                }
                jugador1ID = login.UsuarioID;

                // Player 2 Login
                MessageBox.Show("Jugador 2, por favor inicie sesión.");
                login.Reset();
                while (!login.Registrado)
                {
                    login.ShowDialog();
                    if (login.Cancelado)
                    {
                        MessageBox.Show("Inicio de sesión cancelado. Cerrando aplicación.");
                        this.Close();
                        return;
                    }

                    if (login.countLogin == 3)
                    {
                        MessageBox.Show("Intentos de inicio de sesión excedidos. Cerrando aplicación.");
                        this.Close();
                        return;
                    }
                }
                jugador2ID = login.UsuarioID;

                // Initialize game with player IDs
                partidaManager = new PartidaManager(jugador1ID, jugador2ID);
                partidaManager.OnWinnerDeclared += HandleWinnerDeclared;


                // Initialize board
                InitializeBoard(partidaManager.GetBoardState());
                lblTurno.Text = $"Turno: Jugador {partidaManager.GetCurrentPlayer()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el juego: {ex.Message}");
                this.Close();
            }
        }


        private void InitializeBoard(string[,] boardState)
        {
            boardPanel.Controls.Clear();

            for (int row = 0; row < boardState.GetLength(0); row++)
            {
                for (int col = 0; col < boardState.GetLength(1); col++)
                {
                    Button tile = new Button
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Location = new Point(col * TileSize, row * TileSize),
                        BackColor = (row + col) % 2 == 0 ? Color.White : Color.Black,
                        FlatStyle = FlatStyle.Flat,
                        Tag = new Point(row, col)
                    };

                    string piece = boardState[row, col];
                    if (piece != null)
                    {
                        tile.Text = piece;
                        tile.ForeColor = piece.Contains("O") ? Color.Red : Color.Blue;
                    }

                    tile.Click += Tile_Click;
                    boardPanel.Controls.Add(tile);
                    boardTiles[row, col] = tile;
                }
            }
        }

        private Button selectedPiece = null;
        private Point? selectedPosition = null;

        private void Tile_Click(object sender, EventArgs e)
        {
            Button clickedTile = sender as Button;
            Point position = (Point)clickedTile.Tag;

            string piece = partidaManager.GetPieceAt(position);

            // Debugging: Print the piece value
            Console.WriteLine($"Piece at {position.X}, {position.Y}: {piece}");

            // If no piece is selected, attempt to select one
            if (selectedPiece == null)
            {
                if (piece != null)
                {
                    // Validate that the piece belongs to the current player
                    bool isCurrentPlayerPiece = (partidaManager.GetCurrentPlayer() == 1 && (piece.StartsWith("O") || piece.Contains("(K)"))) ||
                                                (partidaManager.GetCurrentPlayer() == 2 && (piece.StartsWith("X") || piece.Contains("(K)")));

                    if (isCurrentPlayerPiece)
                    {
                        selectedPiece = clickedTile;
                        selectedPosition = position;
                        clickedTile.BackColor = Color.Yellow; // Highlight selected piece
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una pieza válida.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una pieza válida.");
                }
            }
            else
            {
                // Attempt to move the selected piece
                if (partidaManager.MakeMove(selectedPosition.Value, position))
                {
                    UpdateBoard();
                    partidaManager.CheckWinner();


                    // Check if the game has ended
                    if (partidaManager.CheckEndGame())
                    {
                        MessageBox.Show($"Juego terminado. Ganador: Jugador {partidaManager.GetCurrentPlayer()}");
                        partidaManager.EndGame(partidaManager.GetCurrentPlayer());
                        this.Close();
                    }
                    else
                    {
                        lblTurno.Text = $"Turno: Jugador {partidaManager.GetCurrentPlayer()}";
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento inválido. Intente de nuevo.");
                }

                // Reset the selection regardless of move validity
                selectedPiece.BackColor = (selectedPosition.Value.X + selectedPosition.Value.Y) % 2 == 0 ? Color.White : Color.Black;
                selectedPiece = null;
                selectedPosition = null;
            }
        }







        private void UpdateBoard()
        {
            string[,] boardState = partidaManager.GetBoardState();
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    string piece = boardState[row, col];
                    Button tile = boardTiles[row, col];

                    // Update the text and color based on the piece
                    tile.Text = piece;
                    tile.ForeColor = piece == "O" || piece == "O (K)" ? Color.Red : Color.Blue;
                }
            }
        }



        private void btnEndGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego terminado.");
            this.Close();
        }
    }
}
