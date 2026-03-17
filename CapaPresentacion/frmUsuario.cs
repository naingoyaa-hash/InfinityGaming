using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinityGaming
{
    public partial class frmUsuario : Form
    {
        csUsuario usuario = new csUsuario();
        long idUsuarioSeleccionado = 0;
        long idPersonaSeleccionada = 0;
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            EstiloDgvUsuarios();
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = usuario.Listar("");
            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdPersona"].Visible = false;

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                idPersonaSeleccionada = Convert.ToInt64(fila.Cells["IdPersona"].Value);
                idUsuarioSeleccionado = Convert.ToInt64(fila.Cells["IdUsuario"].Value);

                txtUsuario.Text = fila.Cells["Usuario"].Value.ToString();
                txtContraseña.Text = fila.Cells["Contraseña"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();

                if (fila.Cells["Rol"].Value.ToString() == "Admin")
                    rdbAdministrador.Checked = true;
                else
                    rdbEmpleado.Checked = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            usuario.Nombre = txtNombre.Text;
            usuario.Cedula = txtCedula.Text;
            usuario.Correo = txtCorreo.Text;
            usuario.Direccion = txtDireccion.Text;
            usuario.Usuario = txtUsuario.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.Admin = rdbAdministrador.Checked;

            var resultado = usuario.Insertar();

            MessageBox.Show(resultado.mensaje);

            if (resultado.ok)
            {
                CargarUsuarios();
                Limpiar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un usuario primero");
                return;
            }

            if (idPersonaSeleccionada == 0)
            {
                MessageBox.Show("Error: persona no seleccionada");
                return;
            }

            usuario.IdUsuario = idUsuarioSeleccionado;
            usuario.IdPersona = idPersonaSeleccionada;
            usuario.Nombre = txtNombre.Text;
            usuario.Cedula = txtCedula.Text;
            usuario.Correo = txtCorreo.Text;
            usuario.Direccion = txtDireccion.Text;
            usuario.Usuario = txtUsuario.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.Admin = rdbAdministrador.Checked;

            var resultado = usuario.ActualizarUsuario();

            MessageBox.Show(resultado.mensaje);

            if (resultado.ok)
            {
                CargarUsuarios();
                Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un usuario");
                return;
            }

            usuario.IdUsuario = idUsuarioSeleccionado;

            var resultado = usuario.Eliminar();

            MessageBox.Show(resultado.mensaje);

            if (resultado.ok)
            {
                CargarUsuarios();
                Limpiar();
            }
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();

            rdbAdministrador.Checked = false;
            rdbEmpleado.Checked = false;

            idUsuarioSeleccionado = 0;
            idPersonaSeleccionada = 0;
        }
        private void EstiloDgvUsuarios()
        {
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(140, 0, 255);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(90, 24, 154);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersHeight = 40;

            dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 55);
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.White;

            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;

            dgvUsuarios.CellDoubleClick += dgvUsuarios_CellDoubleClick;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvUsuarios_CellClick(sender, e);
            }
        }
    }
}
