using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;

namespace CapaDatos
{
    public class Email
    {
        public int Enviar(string receptor) {

            Random r = new Random();
            int numero = r.Next(100000, 1000000);
            MailMessage msg = new MailMessage();
            msg.To.Add(receptor);
            msg.Subject = "Correo de verificacion";
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = "<div class=\"centrar\">\r\n<div style=\"text-align: center;\">\r\n        <img src=\"https://scontent.ftru7-1.fna.fbcdn.net/v/t39.30808-6/387819911_1205339073741049_5701879120840022726_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeGfTz9DgXBNVsV-7D_VcWT_ECN4uCcClqMQI3i4JwKWo1ygiz6M3nKdfxohzdrrEdzO61B380FsmJXfq_XWy5fl&_nc_ohc=aEyvJ2lwMp0AX_iNmR3&_nc_ht=scontent.ftru7-1.fna&oh=00_AfDswizLXhalt3qZ4ZL8N2kCT17bPrGYs9oNml0vR9F9jA&oe=6536808A\" alt=\"\" style=\"max-width: 1000px; max-height: 150px;\">\r\n    </div>\r\n    <div style=\"text-align: center;\">\r\n        <h1 style=\"font-size: 25px;\">Solicitud para cambio de Contraseña</h1>\r\n    </div>\r\n</div>  <p style=\"margin-left: 450px; font-size: 20px;\">Su código de recuperación de cuenta es " +numero+"</p>"+ "<p style=\"margin-left: 450px; font-size: 20px;\">Ingrese el código de recuperación.</p>";
            //msg.Body = "Su codigo de recuperación de cuenta es " + numero + ".Ingrese el código de recuperación.";
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("kgarciamir19@gmail.com", "Soporte Wilson",System.Text.Encoding.UTF8);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("kgarciamir19@gmail.com", "bvtk nfav cgqh qtbk");//cuenta de emisor del mensaje y su contraseña
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                numero = 0;
            }

            return numero;
        }

    }
}
