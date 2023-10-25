using CapaDatos;
using System;
using CapaEntidad;
using CapaLogica;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using Microsoft.VisualBasic;

namespace CapaPresentacion
{
    public partial class AccesoPorCodigo : Form
    {
        public AccesoPorCodigo()
        {
            InitializeComponent();
            plUser.Enabled = false;
        }

        private void AccesoPorCodigo_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Email email = new Email();
            EntUsuario user = new EntUsuario();
            user.username = this.txtCorreo.Text.Trim();
            int numero = email.Enviar(txtCorreo.Text);
            int resultado = 0;
            bool bandera = false;
            if (numero != 0)
            {
                try
                {
                    do
                    {
                        resultado = Convert.ToInt32(Interaction.InputBox("Ingrese el código de confirmación:", "Acceso por Correo"));
                        if (numero == resultado)
                        {
                            
                            MessageBox.Show("El codigo es valido. \nCuenta Habilitada");
                            logUser.Instancia.habilitarUsuario(user);
                            Close();
                            bandera = true;
                            txtUser.Enabled = true;
                            btnSend.Visible = false;
                            plUser.Visible = true;
                            plUser.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("El codigo no es valido");

                        }
                    } while (bandera == false);
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

        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                EntUsuario user = new EntUsuario();
                user.username = this.txtUser.Text.Trim();
                logUser.Instancia.habilitarUsuario(user);

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
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
