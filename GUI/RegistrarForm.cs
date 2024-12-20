﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;


namespace GUI
{
    public partial class RegistrarForm : Form
    {
        public RegistrarForm()
        {
            InitializeComponent();
        }

        UsuarioBLL usuarioBLL = new UsuarioBLL();

        public bool Cancelado { get; set; }
        public bool Registrado { get; set; }


        private void RegistrarForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.DarkGray;

                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DarkGray;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"ERROR");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Cancelado...");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
                    throw new Exception("Username y/o Password incorrecto!!!");

                Jugador jugador = new Jugador(txtUsername.Text, txtPassword.Text);

                usuarioBLL.RegistrarUsuario(jugador);

                this.Close();

                MessageBox.Show($"{jugador.NombreUsuario} registrado con exito!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
