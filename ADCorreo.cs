using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Text;
using System.IO;
using System.Net.Mime;
using TOVISIT.APP.Entidades;

namespace TOVISIT.APP.AccesoDatos
{
    public class ADCorreo
    {
        static string descripcionLog = string.Empty;

        #region MantenimientoCorreos
        public static int MantenimientoCorreos(ECorreo entCorreo, MailMessage email)
        {
            int valorRetorno = 0;

            AlternateView plainView = AlternateView.CreateAlternateViewFromString(entCorreo.Cuerpo.ToString(), Encoding.UTF8, MediaTypeNames.Text.Plain);
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(entCorreo.Cuerpo.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);

            email.From = new MailAddress(ConfigurationManager.AppSettings["De"]);
            email.Subject = entCorreo.Asunto;
            email.Body = entCorreo.Cuerpo;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            LinkedResource img = new LinkedResource(ConfigurationManager.AppSettings["imagenLogo"], MediaTypeNames.Image.Jpeg);
            LinkedResource img2 = new LinkedResource(ConfigurationManager.AppSettings["imagenThinkGreen"], MediaTypeNames.Image.Jpeg);
            img.ContentId = "imagen";
            img2.ContentId = "imagen2";
            htmlView.LinkedResources.Add(img);
            htmlView.LinkedResources.Add(img2);
            email.AlternateViews.Add(htmlView);
            email.AlternateViews.Add(plainView);
            email.AlternateViews.Add(htmlView);
            
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["ServidorCorreo"];
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["UsuarioCorreo"], ConfigurationManager.AppSettings["ClaveCorreo"]);

            try
            {
                smtp.Send(email);
                email.Dispose();
                valorRetorno = 1;
            }
            catch (Exception ex)
            {
                valorRetorno = 0;
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;
                entLog.Descripcion = descripcionLog;
                ADLog.InsertarLog(entLog);
            }

            return valorRetorno;
        }
        #endregion
    }
}