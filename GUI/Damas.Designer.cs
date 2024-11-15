namespace GUI
{
    partial class Damas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Button btnEndGame;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.boardPanel = new System.Windows.Forms.Panel();
            this.lblTurno = new System.Windows.Forms.Label();
            this.btnEndGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(50, 50);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(400, 489);
            this.boardPanel.TabIndex = 0;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(500, 50);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(57, 20);
            this.lblTurno.TabIndex = 1;
            this.lblTurno.Text = "Turno";
            // 
            // btnEndGame
            // 
            this.btnEndGame.Location = new System.Drawing.Point(500, 100);
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.Size = new System.Drawing.Size(120, 40);
            this.btnEndGame.TabIndex = 2;
            this.btnEndGame.Text = "Terminar Juego";
            this.btnEndGame.UseVisualStyleBackColor = true;
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click);
            // 
            // Damas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 588);
            this.Controls.Add(this.btnEndGame);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.boardPanel);
            this.Name = "Damas";
            this.Text = "Damas";
            this.Load += new System.EventHandler(this.Damas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
