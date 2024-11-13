namespace GUI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.picBxPortada = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chBxRegistrar = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.chBxVerPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBxPortada)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(153, 219);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(101, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Iniciar Sesión\r\n";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 255);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(219, 22);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // picBxPortada
            // 
            this.picBxPortada.BackColor = System.Drawing.Color.Transparent;
            this.picBxPortada.Image = ((System.Drawing.Image)(resources.GetObject("picBxPortada.Image")));
            this.picBxPortada.Location = new System.Drawing.Point(102, 22);
            this.picBxPortada.Name = "picBxPortada";
            this.picBxPortada.Size = new System.Drawing.Size(201, 159);
            this.picBxPortada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxPortada.TabIndex = 2;
            this.picBxPortada.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 295);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(148, 360);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(114, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chBxRegistrar
            // 
            this.chBxRegistrar.AutoSize = true;
            this.chBxRegistrar.Location = new System.Drawing.Point(133, 421);
            this.chBxRegistrar.Name = "chBxRegistrar";
            this.chBxRegistrar.Size = new System.Drawing.Size(146, 36);
            this.chBxRegistrar.TabIndex = 5;
            this.chBxRegistrar.Text = "¿No ténes cuenta ? \r\n¡ Crea tu uenta ya !";
            this.chBxRegistrar.UseVisualStyleBackColor = true;
            this.chBxRegistrar.CheckedChanged += new System.EventHandler(this.chBxRegistrar_CheckedChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(148, 477);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(114, 40);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Registrar";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // chBxVerPassword
            // 
            this.chBxVerPassword.AutoSize = true;
            this.chBxVerPassword.Location = new System.Drawing.Point(98, 326);
            this.chBxVerPassword.Name = "chBxVerPassword";
            this.chBxVerPassword.Size = new System.Drawing.Size(123, 20);
            this.chBxVerPassword.TabIndex = 7;
            this.chBxVerPassword.Text = "Ver contraseña.";
            this.chBxVerPassword.UseVisualStyleBackColor = true;
            this.chBxVerPassword.CheckedChanged += new System.EventHandler(this.chBxVerPassword_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 582);
            this.Controls.Add(this.chBxVerPassword);
            this.Controls.Add(this.picBxPortada);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chBxRegistrar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUsername);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBxPortada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox picBxPortada;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chBxRegistrar;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox chBxVerPassword;
    }
}