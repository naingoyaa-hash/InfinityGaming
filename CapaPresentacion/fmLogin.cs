using InfinityGaming.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class fmLogin : Form
    {
        csCRUD crud = new csCRUD();
        public fmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            int resultado = crud.login(txtUsuario.Text, txtPass.Text);
            if (resultado == 1)
            {
                fmMenu menu = new fmMenu(true);
                menu.Show();
                this.Hide();
            }
            else if (resultado == 0) 
            {
                fmMenu menu = new fmMenu(false);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }


    }
}  
