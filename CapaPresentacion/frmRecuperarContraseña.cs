using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using InfinityGaming.CapaDatos;

namespace InfinityGaming.CapaPresentacion
{
    public partial class frmRecuperarContraseña : Form
    {
        csCRUD crud = new csCRUD();
        string correoUsuario = "";
        int idUsuarioActual = 0;
        string codigoGenerado = "";

        public frmRecuperarContraseña()
        {
            InitializeComponent();

            lblCodigo.Visible = false;
            txtCodigo.Visible = false;
            btnValidar.Visible = false;
            btnReenviar.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecuperarContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmLogin"]?.Show();
        }

        private void frmRecuperarContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                csMoverFormulario.Mover(this);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese usuario y correo", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = crud.EjecutarSP_DataTable(
                "RecuperarUsuario",
                new SqlParameter("@Usuario", txtUsuario.Text.Trim()),
                new SqlParameter("@Correo", txtCorreo.Text.Trim())
            );
            correoUsuario = dt.Rows[0]["Correo"].ToString();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Usuario o correo incorrectos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idUsuarioActual = Convert.ToInt32(dt.Rows[0]["IdUsuario"]);

            GenerarCodigo();

            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            btnValidar.Visible = true;
            btnReenviar.Visible = true;

            label1.Visible = false;
            label2.Visible = false;
            lblTitulo.Text = "VALIDAR CODIGO";
            txtCorreo.Visible = false;
            txtUsuario.Visible = false;
            btnRecuperar.Visible = false;
        }

        private void GenerarCodigo()
        {
            codigoGenerado = new Random().Next(100000, 999999).ToString();

            crud.ejecutarSP(
                "IRecuperacionPassword",
                new SqlParameter("@IdUsuario", idUsuarioActual),
                new SqlParameter("@Codigo", codigoGenerado)
            );

            EnviarCorreo(codigoGenerado);

            MessageBox.Show(
                "Se envió el código de recuperación a tu correo",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCodigo.Text.Trim() == codigoGenerado)
            {
                MessageBox.Show(
                    "Código válido, puede cambiar la contraseña",
                    "Correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                frmNuevaContraseña nuevaContraseña = new frmNuevaContraseña(idUsuarioActual);
                nuevaContraseña.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Código incorrecto",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void EnviarCorreo(string codigo)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("infinityg1126@gmail.com");
                correo.To.Add(correoUsuario);
                correo.Subject = "Recuperación de contraseña";
                correo.Body =
                    "Hola,\n\n" +
                    "Tu código de recuperación es: " + codigo + "\n\n" +
                    "Este código expira en 10 minutos.\n\n" +
                    "Si no solicitaste este código, ignora este correo.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(
                    "infinityg1126@gmail.com",
                    "kydxgzooaokbzkls"
                );
                smtp.EnableSsl = true;

                smtp.Send(correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al enviar el correo:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnReenviar_Click_1(object sender, EventArgs e)
        {
            GenerarCodigo();
        }
    }
}
