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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                LoginForm login = new LoginForm();



                while (!login.Registrado  )
                {
                    
                    login.ShowDialog();

                    if(login.countLogin == 3) 
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

                this.Show();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            


            

            


        }
    }
}
