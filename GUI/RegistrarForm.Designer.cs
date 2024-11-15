namespace GUI
{
    partial class RegistrarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarForm));
            this.chBxVerPassword = new System.Windows.Forms.CheckBox();
            this.picBxPortada = new System.Windows.Forms.PictureBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBxPortada)).BeginInit();
            this.SuspendLayout();
            // 
            // chBxVerPassword
            // 
            this.chBxVerPassword.AutoSize = true;
            this.chBxVerPassword.Location = new System.Drawing.Point(88, 345);
            this.chBxVerPassword.Name = "chBxVerPassword";
            this.chBxVerPassword.Size = new System.Drawing.Size(123, 20);
            this.chBxVerPassword.TabIndex = 15;
            this.chBxVerPassword.Text = "Ver contraseña.";
            this.chBxVerPassword.UseVisualStyleBackColor = true;
            this.chBxVerPassword.CheckedChanged += new System.EventHandler(this.chBxVerPassword_CheckedChanged);
            // 
            // picBxPortada
            // 
            this.picBxPortada.BackColor = System.Drawing.Color.Transparent;
            this.picBxPortada.Image = ((System.Drawing.Image)(resources.GetObject("picBxPortada.Image")));
            this.picBxPortada.Location = new System.Drawing.Point(89, 46);
            this.picBxPortada.Name = "picBxPortada";
            this.picBxPortada.Size = new System.Drawing.Size(201, 159);
            this.picBxPortada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxPortada.TabIndex = 10;
            this.picBxPortada.TabStop = false;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(133, 382);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(114, 40);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Registrar";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(126, 238);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 16);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Registrar Usuario";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(83, 314);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 22);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(83, 274);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(219, 22);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(133, 428);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 40);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // RegistrarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 496);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.chBxVerPassword);
            this.Controls.Add(this.picBxPortada);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "RegistrarForm";
            this.Text = "RegistrarForm";
            this.Load += new System.EventHandler(this.RegistrarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBxPortada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chBxVerPassword;
        private System.Windows.Forms.PictureBox picBxPortada;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnCancelar;
    }
}