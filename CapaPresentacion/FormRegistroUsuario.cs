using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FormRegistroUsuario : Form
    {
        APIDNI apidni = new APIDNI();
        private bool passwordVisible1 = false;
        private bool passwordVisible = false;

        List<EntRol> listarol = logUser.Instancia.ListarRoles();
        public FormRegistroUsuario()
        {
            InitializeComponent();
            listarRoles();
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            lbMensajeErrorCorreo.Visible = false;
        }

        private void FormRegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnDNI_Click(object sender, EventArgs e)
        {


        }
        private void listarRoles()
        {
            foreach (EntRol rol in listarol)
            {
                cmbRol.Items.Add(rol.rolname);
            }
        }

        private EntRol buscarRolPorNombre(string nombre)
        {

            foreach (EntRol rol in listarol)
            {
                if (rol.rolname == nombre)
                    return rol;
            }
            return null;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
                panelContainer.Location = new Point(307, 399);
                panelParametros.Visible = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
                txtPassword.UseSystemPasswordChar = false;
                panelContainer.Location = new Point(303, 266);
                panelParametros.Visible = false;
            }
        }
        private void txtCONPassword_Enter(object sender, EventArgs e)
        {
            if (txtCONPassword.Text == "Confirmación Password")
            {
                txtCONPassword.Text = "";
                txtCONPassword.ForeColor = Color.Silver;
                txtCONPassword.UseSystemPasswordChar = true;
            }
        }
        private void txtCONPassword_Leave(object sender, EventArgs e)
        {
            if (txtCONPassword.Text == "")
            {
                txtCONPassword.Text = "Confirmación Password";
                txtCONPassword.ForeColor = Color.Silver;
                txtCONPassword.UseSystemPasswordChar = false;
            }
        }
        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "DNI")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Silver;
            }
        }
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                txtDNI.Text = "DNI";
                txtDNI.ForeColor = Color.Silver;
            }
        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "" && txtPassword.Text != "" && txtDNI.Text.Length == 8)
                {
                    if (logUser.Instancia.validarEstructuraCorreo(txtUsername.Text))
                    {
                        if (logUser.Instancia.validarEstructuraContrasenia(txtPassword.Text))
                        {
                            if (txtPassword.Text == txtCONPassword.Text)
                            {
                                EntUsuario user = new EntUsuario();

                                user.username = txtUsername.Text;
                                user.contrasenia = txtPassword.Text;
                                user.dni = txtDNI.Text;
                                user.rol = buscarRolPorNombre(cmbRol.Text).idrol;
                                dynamic respuesta = apidni.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDNI.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImtnYXJjaWFtaXJAZ21haWwuY29tIn0.DmnmjodKhFK8W0vDUGg6vHgpgqDK1Qa1hFJZ82k-SCo");
                                user.apellido = respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                                user.telefono = txtNumberPhone.Text;
                                user.nombres = respuesta.nombres;
                                logUser.Instancia.registrarUsuario(user);
                                MessageBox.Show("El usuario se registro correctamente.");
                            }
                            else
                                MessageBox.Show("La contraseña no coincide");
                        }
                        else
                            MessageBox.Show("Estructura de contraseña no valida");

                    }
                    else
                        MessageBox.Show("Estructura de correo no valida");
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //limpiarVariables();
        }

        private void txtNumberPhone_Leave(object sender, EventArgs e)
        {
            if (txtNumberPhone.Text.Equals(""))
            {
                txtNumberPhone.Text = "Telefono";
                txtNumberPhone.ForeColor = Color.Silver;
            }
        }

        private void txtNumberPhone_Enter(object sender, EventArgs e)
        {
            if (txtNumberPhone.Text.Equals("Telefono"))
            {
                txtNumberPhone.Text = "";
                txtNumberPhone.ForeColor = Color.Silver;
            }
        }

        private void btnDNI_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtDNI.Text.Length == 8)
                {
                    dynamic respuesta = apidni.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDNI.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImtnYXJjaWFtaXJAZ21haWwuY29tIn0.DmnmjodKhFK8W0vDUGg6vHgpgqDK1Qa1hFJZ82k-SCo");
                    string text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                    MessageBox.Show(text);
                }
                else
                {
                    string text = "DNI invalido.Ingrese otro DNI";
                    MessageBox.Show(text);
                }

            }
            catch
            {
                string text = "DNI invalido.Ingrese otro DNI";
                MessageBox.Show(text);
            }
        }



        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            validarLongitud();
            validarMayuscula();
            validarMinuscula();
            validarNumero();
            validarCaracter();
        }

        private void validarLongitud()
        {
            pictureLength.Image = (txtPassword.Text.Length >= 8) ? Properties.Resources.check : Properties.Resources.x;

        }

        private void validarMayuscula()
        {
            pictureMayus.Image = (Regex.IsMatch(txtPassword.Text, @"[A-Z]")) ? Properties.Resources.check : Properties.Resources.x;

        }

        private void validarMinuscula()
        {
            pictureMinus.Image = (Regex.IsMatch(txtPassword.Text, @"[a-z]")) ? Properties.Resources.check : Properties.Resources.x;
        }

        private void validarNumero()
        {
            pictureNumber.Image = (Regex.IsMatch(txtPassword.Text, @"\d")) ? Properties.Resources.check : Properties.Resources.x;
        }

        private void validarCaracter()
        {
            pictureCharacter.Image = (Regex.IsMatch(txtPassword.Text, @"[!@#\$%&*_-]")) ? Properties.Resources.check : Properties.Resources.x;
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (passwordVisible1)
            {
                pictureBox8.Image = Properties.Resources.show;
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                pictureBox8.Image = Properties.Resources.hide;
                txtPassword.UseSystemPasswordChar = false;
            }

            passwordVisible1 = !passwordVisible1;
        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                pictureBox9.Image = Properties.Resources.show;
                txtCONPassword.UseSystemPasswordChar = true;
            }
            else
            {
                pictureBox9.Image = Properties.Resources.hide;
                txtCONPassword.UseSystemPasswordChar = false;
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
