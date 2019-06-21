using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Web.Script;
using System.Windows;
using System.Text;
using System.Net.Mail;
using System.ComponentModel;

namespace Cai2020
{
	public partial class Registrar : System.Web.UI.Page
	{
        int paso = 0;
        static bool mailSent = false;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            paso = paso + 1;
            //if (paso == 1)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "confi();", true);
            //}

        }

        protected void Butcon_Click(object sender, EventArgs e)
        {
           // cambiaContraseña("", "");
            String expresion = "";
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (string.IsNullOrEmpty(txtcorreo.Text) || string.IsNullOrEmpty(txtrepitecorreo.Text) || string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtcontra.Text))
			{
				mensaje_error.InnerHtml = "<strong>No debe haber campos vacios.</strong>";
				//ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
			}

            else if (txtcontra.MaxLength<8 || txtcorreo.MaxLength<8 || txtpassword.MaxLength <8 || txtrepitecorreo.MaxLength < 8)
            {
                mensaje_error.InnerHtml = "<strong>El numero de caracteres no debe ser menor a 8</strong>";
            }

			else if (Regex.IsMatch(txtcorreo.Text, expresion) && Regex.IsMatch(txtrepitecorreo.Text, expresion))
			{
				if (Regex.Replace(txtcorreo.Text, expresion, String.Empty).Length == 0 && Regex.Replace(txtrepitecorreo.Text, expresion, String.Empty).Length == 0)
				{

					if (!txtcorreo.Text.Equals(txtrepitecorreo.Text))
					{
						mensaje_error.InnerHtml = "<strong>Los correos son diferentes. Favor de verificar.</strong>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);

                        //	txtcorreo.Text = "";
                        //	txtrepitecorreo.Text = "";
                        txtrepitecorreo.Focus();
					}
					else if (!txtpassword.Text.Equals(txtcontra.Text))
					{
						mensaje_error.InnerHtml = "<strong>Las contraseñas son diferentes favor de verificar.</strong>";
						ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
						//	txtpassword.Text = "";
						//	txtcontra.Text = "";
						txtrepitecorreo.Focus();
					}
					else
					{
                        Session["usuario"] = txtcorreo.Text;

                        cambiaContraseña(txtcorreo.Text, txtpassword.Text);
                        //cambiaContraseña(txtcorreo.Text, txtpassword.Text);


                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                    }
				}
			}
			else
			{
				mensaje_error.InnerHtml = "<strong>El formato del correo no es correcto.</strong>";
				//ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);
			}
		}




        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
             bool mailSent = false;
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }

        private void cambiaContraseña(string email, string contrasena)
		{

            OracleDataReader miReader = null;
            string valor = "UPDATE cap_int_tc_usuario SET EMAIL = '"+email+"', CONTRASENA_NVA = '"+contrasena+"' WHERE nombre = '"+ Session["UserName"] + "'";
            string oradb = ConfigurationManager.AppSettings["cai2020"];
            OracleConnection conn = new OracleConnection(); // C#
            OracleCommand command = conn.CreateCommand();
            conn.ConnectionString = oradb.ToString();
            conn.Open();
            OracleTransaction transaction;
            command = new OracleCommand(valor, conn);
            // Start a local transaction
            transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            // Assign transaction object for a pending local transaction
            command.Transaction = transaction;
            command.Transaction.Commit();
            OracleDataAdapter adapter = new OracleDataAdapter();
            
            String sql = "";

            sql = "";



            try
            {
                adapter.UpdateCommand = new OracleCommand(valor, conn);
                adapter.UpdateCommand.ExecuteNonQuery();
                adapter.UpdateCommand.Transaction.Commit();
                adapter.UpdateCommand.Dispose();
                //command.Transaction.Commit();
                //command.Dispose();

                conn.Close();


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<br>INEGI – Prueba Censo 2020 por Internet</br>");
                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine("<br>Prueba Censo 2020 por Internet</br>");

                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine();



                StringBuilder mailBody = new StringBuilder();
                mailBody.AppendFormat("<h2>Cuenta de usuario del Censo 2020 por Internet</h2>");
                mailBody.AppendFormat("<h1 style=\"color: Blue;\">Código para cambiar contraseña</h1>");
                mailBody.AppendFormat("<p>Usa este código para cambiar la contraseña de la cuenta <span style=\"color: Blue;\">" + txtpassword.Text + "</span> que registraste en el sitio INEGI para contestar el cuestionario del censo. </p>,");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Si no has solicitado este código de seguridad, puedes descartar este correo electrónico. Es posible que otro usuario haya escrito tu dirección.</p>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Gracias,</p>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<h4>Instituto Nacional de Estadística y Geografía INEGI</h4>");
                // mnsj.Body = "  Mensaje de Prueba \n\n Enviado desde C#\n\n Código:" + nAleatorio.ToString();


                //mnsj.Body = "  Mensaje de Prueba \n\n Enviado desde C#\n\n Código:" + nAleatorio.ToString();

                //mnsj.Body = mailBody.ToString();
                //mnsj.IsBodyHtml = true;

               
               // MailMessage mnsj = new MailMessage();
               // mnsj.Subject = "Cambio de contraseña de usuario del Censo 2020 por Internet";
               // mnsj.To.Add(new MailAddress(txtpassword.Text));
               // mnsj.From = new MailAddress("cai2020@inegi.org.mx", "INEGI – Cuentas del Censo 2020");



                String userName = "cai2020@inegi.org.mx";
                String password = "";
                MailMessage msg = new MailMessage();
                //msg.To.Add(new MailAddress("edgar.guadarrama@inegi.org.mx"));
                msg.To.Add(new MailAddress(txtcorreo.Text));
                msg.From = new MailAddress("cai2020@inegi.org.mx", "INEGI – Cuentas del Censo 2020");
                msg.Subject = "Cambio de contraseña de usuario del Censo 2020 por Internet";
                msg.Body = mailBody.ToString();
                msg.IsBodyHtml = true;
                //SmtpClient server = new SmtpClient("w-appintrasmtp.inegi.gob.mx", 25);
                SmtpClient client = new SmtpClient("w-appintrasmtp.inegi.gob.mx", 25);
                
                client.Host = "smtp.office365.com";
                //client.Host = "w-appintrasmtp.inegi.gob.mx";

                client.Credentials = new System.Net.NetworkCredential(userName, password);
                client.Port = 587;
                //client.Port = 25;
                client.EnableSsl = true;
                client.Send(msg);
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { myModal(); });", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { confi(); });", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "confi();", true);

                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "myModal();", true);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }  



            //OracleDataReader miReader = null;
            //string valor = "";
            //string oradb = ConfigurationManager.AppSettings["cai2020"];
            //OracleConnection conn = new OracleConnection(); // C#
            //conn.ConnectionString = oradb.ToString();
            //conn.Open();
            //HttpContext.Current.Session.Remove("captcha");
            ////mandamos llamar a la funcion de borrar_todo del paquete Pkg_cai2020
            ////Session["bandera"] = oracle.ejecutar_package("Pkg_cai2020.borrar_todo", Int64.Parse(Session["Id_inm"].ToString()), "S");
            //try
            //{
            //    ////AQUI PONER EL CONTROL DE INGRESO DOBLE
            //    OracleCommand cmd01 = new OracleCommand();
            //    cmd01.Connection = conn;
            //    cmd01.CommandText = "UPDATE cap_int_tc_usuario SET USUARIO = 'pru', CONTRASENA = 'pru' WHERE nombre = 'AENZRH'";
            //    cmd01.CommandType = CommandType.Text;
            //    int rowCount = 0;
            //    rowCount = cmd01.ExecuteNonQuery();
            //    //OracleDataReader dr01 = cmd01.ExecuteReader();
            //    //while (dr01.Read())
            //    //{
            //    //    // your logic here
            //    //    rowCount++;
            //    //}
            //    //dr01.Dispose();
            //    cmd01.Dispose();
            //}
            //catch (Exception e1)
            //{
            //    miReader = null;
            //    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
            //}
            //finally
            //{
            //    conn.Dispose();
            //}








            //         //string oradb = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = estdembd.inegi.gob.mx)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = estdem)));User ID=cpv2020_pru_capweb;Password=cpv2020_pru_capweb;";
            //         //dataSource alias = "SampleDataSource" descriptor = "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=estdembd.inegi.gob.mx)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=estdem))) " />
            //         //< add name = "cai2020" connectionString = "Data Source=SampleDataSource;Persist Security Info=True;User ID=cpv2020_pru_capweb;Password=cpv2020_pru_capweb;" providerName = "Oracle.ManagedDataAccess.Client" />
            //         string oradb = ConfigurationManager.AppSettings["cai2020"];
            //         OracleConnection conn = new OracleConnection(); // C#
            //         conn.ConnectionString = oradb;
            //         conn.Open();
            //         OracleCommand cmd = conn.CreateCommand();
            //         cmd.CommandType = CommandType.Text;
            //         cmd.CommandText = "UPDATE cap_int_tc_usuario SET USUARIO = 'pru', CONTRASENA = 'pru' WHERE nombre = 'AENZRH'";
            //         //cmd.CommandText = "UPDATE cap_int_tc_usuario SET USUARIO = :param1, CONTRASENA = :param2 WHERE nombre = 'AENZRH'";
            //        // cmd.Parameters.Add("param1", email);
            //         //cmd.Parameters.Add("param2", contrasena);

            //         int registros = cmd.ExecuteNonQuery();




            //         string userName = (string)Session["UserName"];
            //string password = (string)Session["Password"];
            ////var queryString = string.Format(@"UPDATE cap_int_tc_usuario SET USUARIO = '" + email + "', CONTRASENA = '" + contrasena + "'WHERE nombre = 'AENZRH'");
            //string queryString = "UPDATE cap_int_tc_usuario SET USUARIO = '" + email + "', CONTRASENA = '" + contrasena + "'WHERE nombre = 'AENZRH'";

            ////string oradb = ConfigurationManager.AppSettings["cai2020"];
            //try
            //{
            //	//OracleConnection conn = new OracleConnection(); // C#
            //	conn.ConnectionString = oradb.ToString();
            //	conn.Open();
            //	//OracleCommand cmd = conn.CreateCommand();
            //             cmd.CommandText = queryString;
            //             cmd.CommandType = System.Data.CommandType.Text;
            //             int rowsUpdated = cmd.ExecuteNonQuery();
            //	if (rowsUpdated > 0)
            //	{
            //		mensaje_error.InnerHtml = "<strong>Exito.</strong>";
            //		ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { abrirModal(1); });", true);

            //	}
            //}
            //catch (Exception er)
            //{
            //	Console.Write(er.Message);
            //}


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { confi(); });", true);
        }
    }
	
}