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

        public Damas()
        {
            InitializeComponent();
        }

        private void Damas_Load(object sender, EventArgs e)
        {
            try
            {
                LoginForm login = new LoginForm();

                while (!login.Registrado)
                {
                    login.ShowDialog();

                    if (login.countLogin == 3)
                    {
                        this.Close();
                        break;
                    }

                    if (login.Cancelado)
                    {
                        this.Close();
                        break;
                    }
                }

                // Show the Damas form after successful login
                InitializeBoard();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeBoard()
        {
            boardPanel.Controls.Clear();

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Button tile = new Button
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Location = new Point(col * TileSize, row * TileSize),
                        BackColor = (row + col) % 2 == 0 ? Color.White : Color.Black,
                        FlatStyle = FlatStyle.Flat,
                        Tag = new Point(row, col) // Store position as a tag
                    };

                    if ((row < 3 || row > 4) && (row + col) % 2 != 0)
                    {
                        // Add initial pieces for players
                        tile.Text = row < 3 ? "O" : "X";
                        tile.ForeColor = row < 3 ? Color.Red : Color.Blue;
                    }

                    tile.Click += Tile_Click;
                    boardPanel.Controls.Add(tile);
                    boardTiles[row, col] = tile;
                }
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button clickedTile = sender as Button;
            Point position = (Point)clickedTile.Tag;

            MessageBox.Show($"Tile clicked at position: {position.X}, {position.Y}");
            // Add move logic here
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juego terminado.");
            this.Close();
        }
    }
}
