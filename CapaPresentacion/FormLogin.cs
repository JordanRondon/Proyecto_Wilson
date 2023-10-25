using CapaDatos;
using CapaEntidad;
using CapaLogica;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public System.Drawing.Point MoveForm_MousePosition;
        public System.Drawing.Point MoveForm_MousePosition2;
        private int intentosRestantes = 5;

        private bool passwordVisible = false;

        public FormLogin()
        {
            InitializeComponent();
            panel1.Controls.Add(logo);
            logo.Location = new Point(2, 62);
            logo.BackColor = Color.Transparent;
            lbMensajeErrorCorreo.Visible = false;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Silver;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.ForeColor = Color.Silver;
                txtUsername.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                EntUsuario user = new EntUsuario();
                user.username = this.txtUsername.Text.Trim();
                user.contrasenia = this.txtPassword.Text.Trim();

                if (logUser.Instancia.verificarEstadoUsuario(user.username))
                {
                    if (logUser.Instancia.validarContrasenia(user.username, user.contrasenia))
                    {
                        switch (logUser.Instancia.obtenerrol(user.username))
                        {
                            case 1:
                                this.Hide();
                                formAdministrador paneladmin = new formAdministrador();
                                paneladmin.ShowDialog();
                                Close();
                                break;
                            case 2:
                            case 3:
                                this.Hide();
                                FormCocinero panelCocinero = new FormCocinero();
                                panelCocinero.ShowDialog();
                                break;
                            case 4:
                                this.Hide();
                                formCajero panelcajero = new formCajero();
                                panelcajero.ShowDialog();
                                Close();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (intentosRestantes > 0)
                        {
                            intentosRes.Visible = true;
                            intentosRes.Text = $"Intentos restantes: {intentosRestantes}";
                            intentosRestantes--;
                        }
                        else
                        {
                            logUser.Instancia.suspenderUsuario(user);
                            intentosRes.Text = $"Intentos restantes: 0";
                            DialogResult result = MessageBox.Show("Cuenta Suspendida\n¿Desea habilitar por correo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            intentosRes.Visible = false;
                            intentosRestantes = 5;
                            if (result == DialogResult.Yes)
                            {
                                AccesoPorCodigo codeAcces = new AccesoPorCodigo();
                                codeAcces.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Cuenta Suspendida\n¿Desea habilitar por correo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                    {
                        AccesoPorCodigo codeAcces = new AccesoPorCodigo();
                        codeAcces.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.Handled = true;
                btnLogin.PerformClick();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm_MousePosition = new System.Drawing.Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Drawing.Point mousePosition = Control.MousePosition;
                mousePosition.Offset(MoveForm_MousePosition.X, MoveForm_MousePosition.Y);
                this.Location = mousePosition;
            }
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm_MousePosition2 = new System.Drawing.Point(-e.X, -e.Y);
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Drawing.Point mousePosition = Control.MousePosition;
                mousePosition.Offset(MoveForm_MousePosition2.X, MoveForm_MousePosition2.Y);
                this.Location = mousePosition;
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            RecuperarEmail interfazrecuperar = new RecuperarEmail();
            interfazrecuperar.ShowDialog();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                pictureBox1.Image = Properties.Resources.show;
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.hide;
                txtPassword.UseSystemPasswordChar = false;
            }

            passwordVisible = !passwordVisible;
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (!datUser.Instancia.validarEstructuraCorreo(txtUsername.Text))
            {
                lbMensajeErrorCorreo.Visible = true;
            }
            else
            {
                lbMensajeErrorCorreo.Visible = false;
            }
        }
    }
}
