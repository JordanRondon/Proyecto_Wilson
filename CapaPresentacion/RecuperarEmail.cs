using CapaDatos;
using System;
using CapaLogica;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace CapaPresentacion
{
    public partial class RecuperarEmail : Form
    {

        private bool passwordVisible1 = false;
        private bool passwordVisible = false;
        public RecuperarEmail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Email email = new Email();
            int numero = email.Enviar(txt_usuario.Text);
            int resultado=0;
            bool bandera=false;
            if (numero !=0)
            {
                try
                {
                    do
                    {
                        resultado = Convert.ToInt32(Interaction.InputBox("Ingrese el código de confirmación:", "Verificación de Cambio de Contraseña"));
                        if (numero == resultado)
                        {
                            MessageBox.Show("El codigo es valido");
                            bandera = true;
                            txt_usuario.Enabled = false;
                            contraseñalabel.Visible = true;
                            txt_contraseña.Visible = true;
                            confirmacionlabel.Visible = true;
                            txt_confirmacion.Visible = true;
                            btn_enviar.Visible = false;
                            btn_cambiar.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("El codigo no es valido");
                           
                        }
                    }while (bandera == false);
                }
                catch (Exception ex)
                {
                    

                }
                
            }
            else
            {
                MessageBox.Show("No se pudo enviar un código de confirmación a su correo");
            }
            bandera = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_cambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if(datUser.Instancia.validarEstructuraContrasenia(txt_contraseña.Text))
                {
                    if (txt_contraseña.Text == txt_confirmacion.Text)
                    {
                        logUser.Instancia.cambiarcontraseña(txt_usuario.Text, txt_contraseña.Text);
                        MessageBox.Show("La contraseña se cambio correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña no coincide con la confirmación");
                    }
                }
                else
                {
                    MessageBox.Show("Estructura de contraseña no valida");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo cambiar la contraseña");
            }
        }

        private void txt_usuario_Enter(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "Ingrese su correo")
            {
                txt_usuario.Text = "";
                txt_usuario.ForeColor = Color.Silver;
            }
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.ForeColor = Color.Silver;
                txt_usuario.Text = "Ingrese su correo";
                
            }
        }

        private void txt_contraseña_Enter(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "Contraseña")
            {
                txt_contraseña.UseSystemPasswordChar = true;
                txt_contraseña.Text = "";
                txt_contraseña.ForeColor = Color.Silver;

            }
        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "")
            {
                txt_contraseña.UseSystemPasswordChar = false;
                txt_contraseña.ForeColor = Color.Silver;
                txt_contraseña.Text = "Contraseña";
                
            }
        }

        private void txt_confirmacion_Enter(object sender, EventArgs e)
        {
            if (txt_confirmacion.Text == "Confirmación Contraseña")
            {
                txt_confirmacion.UseSystemPasswordChar = true;
                txt_confirmacion.Text = "";
                txt_confirmacion.ForeColor = Color.Silver;
            }
        }

        private void txt_confirmacion_Leave(object sender, EventArgs e)
        {
            if (txt_confirmacion.Text == "")
            {
                txt_confirmacion.UseSystemPasswordChar = false;
                txt_confirmacion.ForeColor = Color.Silver;
                txt_confirmacion.Text = "Confirmación Contraseña";

            }
        }

        private void RecuperarEmail_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (passwordVisible1)
            {
                pictureBox1.Image = Properties.Resources.show;
                txt_contraseña.UseSystemPasswordChar = true;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.hide;
                txt_contraseña.UseSystemPasswordChar = false;
            }

            passwordVisible1 = !passwordVisible1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                pictureBox2.Image = Properties.Resources.show;
                txt_confirmacion.UseSystemPasswordChar = true;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.hide;
                txt_confirmacion.UseSystemPasswordChar = false;
            }

            passwordVisible = !passwordVisible;
        }
    }
}
