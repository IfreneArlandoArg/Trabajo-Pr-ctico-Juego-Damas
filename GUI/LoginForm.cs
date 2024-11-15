using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        UsuarioBLL usuarioBLL = new UsuarioBLL();

        public bool Cancelado { get; set; }

        public bool Registrado { get; set; }

        public int countLogin { get; set; }

        

        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }




        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.DarkGray;

            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.DarkGray;

            btnRegister.Hide();

            Registrado = false;

            Cancelado = false;

            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.DarkGray;
            }
            else 
            {
                txtUsername.ForeColor = Color.Black;
            }

            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DarkGray;
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';


            }
        }

        private void chBxRegistrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chBxRegistrar.Checked)
            { 
                btnRegister.Show(); 
            }
            else 
            { 
                btnRegister.Hide(); 
            }
        }

        private void chBxVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chBxVerPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else 
            {
                txtPassword.PasswordChar = '*';
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
                    throw new Exception("Username y/o Password incorrecto!!!");

                Jugador jugador = new Jugador(txtUsername.Text, txtPassword.Text);

                Registrado = usuarioBLL.ValidarCredenciales(jugador.NombreUsuario, jugador.Contraseña);

                if (Registrado)
                {
                    MessageBox.Show($"Bienvenido {jugador.NombreUsuario}!!!");

                    this.Close();
                }
                else
                {
                    countLogin++;
                    MessageBox.Show($"Intento: {countLogin}\nLe quedan {3 - countLogin} posibles");

                    if (countLogin == 3)
                    {
                        this.Close();
                        throw new Exception("Superaste la cantidad de intentos posibles!");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        
        }

      

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrarForm Registrar = new RegistrarForm();

                Registrar.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Cancelado = true;

                this.Close();

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
