using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Web;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Net;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;




namespace Cai2020
{
    class OracleServer
    {
        public OracleServer()
        {
             
        }

        public string ejecutar_package(string nombre, Int64 id_inm, string consalida)
        {//"nombre" es el nombre completo del paquete.nombre procedimiento; ejemplo: Pkg_cai2020.borrar_todo
         //id_inm id del inmueble al que se va a enviar a algun procedimiento del paquete
         //consalida ='S' para indicarle que el procedimiento a usarse devuelve un 1 si fue correcto , 
         // "" si el procedimiento no devuelve nada , 
         //o el error en caso de que procedimiento mande algun error
            string valor = "";
            //string error = "";
            OracleDataReader miReader = null;
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            try
            {
                OracleCommand miComando = new OracleCommand(nombre, miConexion);
                miComando.CommandType = CommandType.StoredProcedure;
                //Envio 2 parametros
                miComando.Parameters.Add("p_id_inm", OracleDbType.Int32);
                miComando.Parameters["p_id_inm"].Value = id_inm;

                if (consalida == "S")
                {
                    //Obtengo 2 parametros de salida
                    miComando.Parameters.Add("p_ban", OracleDbType.Int32);
                    miComando.Parameters["p_ban"].Direction = ParameterDirection.Output;

                    //miComando.Parameters.Add("err_num", OracleType.VarChar);
                    //miComando.Parameters["err_num"].Direction = ParameterDirection.Output;
                }
                miConexion.Open();
                miReader = miComando.ExecuteReader(CommandBehavior.CloseConnection);
                miConexion.Close();

                if (consalida == "S")
                {
                    valor = miComando.Parameters["p_ban"].Value.ToString();
                }
                //error = miComando.Parameters["err_num"].Value.ToString();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
                miReader = null;
            }
            //while (miReader.Read())
            //{
            //valor = miReader.GetInt32(0).ToString();

            //}
            return valor;
        }
        //public string addarchivoprocedure(string nombre, string DR, string ENT, string CE, string CN, string CZ, string CM, string CONSCM, string NOMBRE, string AP_PATERNO, string AP_MATERNO, string CORREO, string CURP, string FECHA, string ESTATUS, string ID_PERFIL, string cveoper_reqperfil)
        public string addarchivoprocedure(string nombre, string DR, string ENT, string CE, string CZ, string CM, string CONSCM,string USUARIO, string NOMBRE, string AP_PATERNO, string AP_MATERNO, string CORREO, string CURP, string FECHA, string ESTATUS, string ID_PERFIL, string cveoper_reqperfil, string sexo)
        {
            string valor="";
            //string error = "";
            OracleDataReader miReader = null;
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            try
            {
                OracleCommand miComando = new OracleCommand(nombre, miConexion);
                miComando.CommandType = CommandType.StoredProcedure;
                //Envio 2 parametros
                miComando.Parameters.Add("IDR", OracleDbType.NVarchar2);
                miComando.Parameters["IDR"].Value = DR;
                miComando.Parameters.Add("IENT", OracleDbType.NVarchar2);
                miComando.Parameters["IENT"].Value = ENT;
                miComando.Parameters.Add("ICE", OracleDbType.NVarchar2);
                miComando.Parameters["ICE"].Value = CE;
                //miComando.Parameters.Add("ICN", OracleType.VarChar);
                //miComando.Parameters["ICN"].Value = CN;
                miComando.Parameters.Add("ICZ", OracleDbType.NVarchar2);
                miComando.Parameters["ICZ"].Value = CZ;
                miComando.Parameters.Add("ICM", OracleDbType.NVarchar2);
                miComando.Parameters["ICM"].Value = CM;
                miComando.Parameters.Add("ICONSCM", OracleDbType.NVarchar2);
                miComando.Parameters["ICONSCM"].Value = CONSCM;
                miComando.Parameters.Add("IUSUARIO", OracleDbType.NVarchar2);
                miComando.Parameters["IUSUARIO"].Value = USUARIO;
                miComando.Parameters.Add("INOMBRE", OracleDbType.NVarchar2);
                miComando.Parameters["INOMBRE"].Value = NOMBRE;
                miComando.Parameters.Add("IAP_PATERNO", OracleDbType.NVarchar2);
                miComando.Parameters["IAP_PATERNO"].Value = AP_PATERNO;
                miComando.Parameters.Add("IAP_MATERNO", OracleDbType.NVarchar2);
                miComando.Parameters["IAP_MATERNO"].Value = AP_MATERNO;
                miComando.Parameters.Add("ICORREO", OracleDbType.NVarchar2);
                miComando.Parameters["ICORREO"].Value = CORREO;
                miComando.Parameters.Add("ICURP", OracleDbType.NVarchar2);
                miComando.Parameters["ICURP"].Value = CURP;
                miComando.Parameters.Add("IESTATUS", OracleDbType.NVarchar2);
                miComando.Parameters["IESTATUS"].Value = ESTATUS;
                miComando.Parameters.Add("IPERFIL", OracleDbType.NVarchar2);
                miComando.Parameters["IPERFIL"].Value = ID_PERFIL;
                miComando.Parameters.Add("IFECHA", OracleDbType.NVarchar2);
                miComando.Parameters["IFECHA"].Value = FECHA;
                miComando.Parameters.Add("ITCONTROL", OracleDbType.NVarchar2);
                miComando.Parameters["ITCONTROL"].Value = cveoper_reqperfil;
                miComando.Parameters.Add("ISEXO", OracleDbType.NVarchar2);
                miComando.Parameters["ISEXO"].Value = sexo;
                
                //Obtengo 2 parametros de salida
                miComando.Parameters.Add("RBANDERA", OracleDbType.Int32);
                miComando.Parameters["RBANDERA"].Direction = ParameterDirection.Output;
                //miComando.Parameters.Add("err_num", OracleType.VarChar);
                //miComando.Parameters["err_num"].Direction = ParameterDirection.Output;

                miConexion.Open();
                miReader = miComando.ExecuteReader(CommandBehavior.CloseConnection);
                miConexion.Close();
                valor = miComando.Parameters["RBANDERA"].Value.ToString();
                //error = miComando.Parameters["err_num"].Value.ToString();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
                miReader = null;
            }
            //while (miReader.Read())
            //{
            //valor = miReader.GetInt32(0).ToString();
            
            //}
            return valor;
        }

        public void Carga_REPORTE_GRIDVIEW(object sender, string NOMBRE_SP, string nombre_cursor, string DR, string ENT, string CE, string CZ, string CM, int nivel)
        {//procedimiento para llenar un gridview y desagregar hasta la conscm
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            //OracleDataReader miReader = null;
            OracleDataAdapter adapter = new OracleDataAdapter();
            try
            {
                OracleCommand miComando = new OracleCommand(NOMBRE_SP, miConexion);
                miComando.CommandType = CommandType.StoredProcedure;
                //Envio 2 parametros
                miComando.Parameters.Add("IDR", OracleDbType.NVarchar2);
                miComando.Parameters["IDR"].Value = DR;
                miComando.Parameters.Add("IENT", OracleDbType.NVarchar2);
                miComando.Parameters["IENT"].Value = ENT;
                miComando.Parameters.Add("ICE", OracleDbType.NVarchar2);
                miComando.Parameters["ICE"].Value = CE;
                //miComando.Parameters.Add("ICN", OracleType.VarChar);
                //miComando.Parameters["ICN"].Value = CN;
                miComando.Parameters.Add("ICZ", OracleDbType.NVarchar2);
                miComando.Parameters["ICZ"].Value = CZ;
                miComando.Parameters.Add("ICM", OracleDbType.NVarchar2);
                miComando.Parameters["ICM"].Value = CM;
                miComando.Parameters.Add("IORDEN", OracleDbType.NVarchar2);
                miComando.Parameters["IORDEN"].Value = nivel;
                //CURSOR DE SALIDA
                miComando.Parameters.Add(nombre_cursor, OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter odr = new OracleDataAdapter(miComando);
                odr.Fill(ds);
                System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
                GView.DataSource = ds.Tables[0];
                GView.DataBind();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            finally
            {
                miConexion.Close();
            }

        }

        public void Carga_REPORTE_GRIDVIEW_TAB(object sender, string NOMBRE_SP, string nombre_cursor, string DR, string ENT, string CE, string CZ, string CM, int nivel, int dias_plan, int dias_trans, int tablero)
        {//procedimiento para llenar un gridview y desagregar hasta la conscm
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            //OracleDataReader miReader = null;
            OracleDataAdapter adapter = new OracleDataAdapter();
            try
            {
                OracleCommand miComando = new OracleCommand(NOMBRE_SP, miConexion);
                miComando.CommandType = CommandType.StoredProcedure;
                //Envio 2 parametros
                if (tablero == 1)
                {
                    miComando.Parameters.Add("IDR", OracleDbType.NVarchar2);
                    miComando.Parameters["IDR"].Value = DR;
                    miComando.Parameters.Add("IENT", OracleDbType.NVarchar2);
                    miComando.Parameters["IENT"].Value = ENT;
                    miComando.Parameters.Add("ICE", OracleDbType.NVarchar2);
                    miComando.Parameters["ICE"].Value = CE;
                    //miComando.Parameters.Add("ICN", OracleType.VarChar);
                    //miComando.Parameters["ICN"].Value = CN;
                    miComando.Parameters.Add("ICZ", OracleDbType.NVarchar2);
                    miComando.Parameters["ICZ"].Value = CZ;
                }
                if (tablero == 3)
                {
                    miComando.Parameters.Add("IDR", OracleDbType.NVarchar2);
                    miComando.Parameters["IDR"].Value = DR;
                    miComando.Parameters.Add("IENT", OracleDbType.NVarchar2);
                    miComando.Parameters["IENT"].Value = ENT;
                    miComando.Parameters.Add("ICE", OracleDbType.NVarchar2);
                    miComando.Parameters["ICE"].Value = CE;
                }
                miComando.Parameters.Add("ICM", OracleDbType.NVarchar2);
                miComando.Parameters["ICM"].Value = CM;
                miComando.Parameters.Add("IORDEN", OracleDbType.NVarchar2);
                miComando.Parameters["IORDEN"].Value = nivel;
                miComando.Parameters.Add("IDIASPLAN", OracleDbType.Int32);
                miComando.Parameters["IDIASPLAN"].Value = dias_plan;
                miComando.Parameters.Add("IDIASTRANS", OracleDbType.Int32);
                miComando.Parameters["IDIASTRANS"].Value = dias_trans;
                //CURSOR DE SALIDA
                miComando.Parameters.Add(nombre_cursor, OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter odr = new OracleDataAdapter(miComando);
                odr.Fill(ds);
                System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
                GView.DataSource = ds.Tables[0];
                GView.DataBind();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            finally
            {
                miConexion.Close();
            }

        }

        public void Carga_REPORTE_GRIDVIEW_USR(object sender, string NOMBRE_SP, string nombre_cursor, string DR, string ENT, string CE, string CZ, string CM,string USUARIOCM, int nivel,string iniciado)
        {//procedimiento para llenar un gridview y desagregar hasta usuarios de la conscm
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            //OracleDataReader miReader = null;
            OracleDataAdapter adapter = new OracleDataAdapter();
            try
            {
                OracleCommand miComando = new OracleCommand(NOMBRE_SP, miConexion);
                miComando.CommandType = CommandType.StoredProcedure;
                //Envio 2 parametros
                miComando.Parameters.Add("IDR", OracleDbType.NVarchar2);
                miComando.Parameters["IDR"].Value = DR;
                miComando.Parameters.Add("IENT", OracleDbType.NVarchar2);
                miComando.Parameters["IENT"].Value = ENT;
                miComando.Parameters.Add("ICE", OracleDbType.NVarchar2);
                miComando.Parameters["ICE"].Value = CE;
                miComando.Parameters.Add("ICZ", OracleDbType.NVarchar2);
                miComando.Parameters["ICZ"].Value = CZ;
                miComando.Parameters.Add("ICM", OracleDbType.NVarchar2);
                miComando.Parameters["ICM"].Value = CM;
                miComando.Parameters.Add("IORDEN", OracleDbType.NVarchar2);
                miComando.Parameters["IORDEN"].Value = nivel;
                miComando.Parameters.Add("IUSUARIO", OracleDbType.NVarchar2);
                miComando.Parameters["IUSUARIO"].Value = USUARIOCM;
                if (iniciado != "")                
                {
                    miComando.Parameters.Add("IINICIADO", OracleDbType.NVarchar2);
                    miComando.Parameters["IINICIADO"].Value = iniciado;
                }
                //CURSOR DE SALIDA
                miComando.Parameters.Add(nombre_cursor, OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter odr = new OracleDataAdapter(miComando);
                odr.Fill(ds);
                System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
                GView.DataSource = ds.Tables[0];
                GView.DataBind();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            finally
            {
                miConexion.Close();
            }

        }

       

        public string ExistenDatos(string valor)
        {

            object pos = null;
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            try
            {
                OracleCommand miComando = new OracleCommand(valor, miConexion);
                miConexion.Open();
                valor = "0";
                if (miComando.ExecuteScalar() != null)
                {
                    pos = miComando.ExecuteScalar();
                    valor = pos.ToString();
                }
            }
            catch (Exception)
            {
                valor = "0";
            }
            finally
            {
                miConexion.Close();
            }
            return valor;
        }

        
        public OracleDataReader RecuperaFilas(string StrSql)
        {
            OracleDataReader miReader = null;
            //OracleConnection miConexion = new OracleConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            try
            {
                miConexion.Open();
                OracleCommand miComando = new OracleCommand(StrSql, miConexion);
                
                OracleDataReader result = miComando.ExecuteReader(CommandBehavior.CloseConnection);
                //OracleDataReader result	 = miComando.ExecuteReader();
                miReader = result;
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
                miReader = null;
            }
            return miReader;
        }
        


        public void ABC_datos(string update)
        {
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            try
            {
                miConexion.Open();
                OracleCommand Comando = new OracleCommand(update, miConexion);
                Comando.ExecuteNonQuery();
            }
            finally
            {
                miConexion.Close();
            }

        }


        public DataTable RecuperaQuery(string query)
        {
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand(query, miConexion);
            adapter.Fill(ds);
            adapter.Dispose();
            return ds.Tables[0];
        }

        //procedimiento para el login mandando como parametros el usuario y contraseña para que no puedan hacer sql inyection
        public DataTable RecuperaQuery(string query, string usr, string pwd)
        {
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            OracleCommand ocm = new OracleCommand(query, miConexion);

            ocm.Parameters.Add(":usu", usr);
            ocm.Parameters.Add(":pwd", pwd);
            OracleDataAdapter adapter = new OracleDataAdapter(ocm);
            //adapter.SelectCommand = ;
            adapter.Fill(ds);
            adapter.Dispose();
            return ds.Tables[0];
        }
        

        public void Carga_DataGrid(object sender, string dato)
        {
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            OracleDataAdapter adapter = new OracleDataAdapter();
            try
            {
                miConexion.Open();
                adapter.SelectCommand = new OracleCommand(dato, miConexion);
                adapter.Fill(ds);

                System.Web.UI.WebControls.DataGrid GView = (System.Web.UI.WebControls.DataGrid)(sender);
                GView.DataSource = ds.Tables[0];
                GView.DataBind();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            finally
            {
                miConexion.Close();
            }
        }

        public void Carga_Gridview(object sender, string dato)
        {
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            OracleDataAdapter adapter = new OracleDataAdapter();
            try
            {
                miConexion.Open();
                adapter.SelectCommand = new OracleCommand(dato, miConexion);
                adapter.Fill(ds);

                System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
                GView.DataSource = ds.Tables[0];
                GView.DataBind();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            finally
            {
                miConexion.Close();
            }
        }

        public System.Web.UI.HtmlControls.HtmlForm exportarGrid_excel(object sender, string query, string titulo, string subtitulo,int colspan, string campos_ocultar)
        {   //Nota :ejemplo datos requeridos (Migridview, "Titulo principal","Subtitulo",4,"1,6") ; el campo colspan es el total de columnas que se muestran en el gridview
            System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
            //toma automaticamente el estilo que tiene el gridview
            GView.AllowPaging = false;
            //spliteamos las columnas que no queremos que se pasen al excel
            string lines = campos_ocultar;
            if ( (lines != null) && (lines !="") )
            {
                string[] cols = lines.Split(',');
                foreach (string colum in cols)
                {
                    //int col = Int32.Parse(colum);
                    GView.Columns[Int32.Parse(colum)].Visible = false;
                }
            }

            Carga_Gridview(GView, query);
            System.Web.UI.WebControls.Table tablatitulos = new System.Web.UI.WebControls.Table();
            //RENGLON SUBTITULO
            GridViewRow oGridViewRow2 = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell oTableSubTitulo = new TableCell();
            //TiTULO
            oTableSubTitulo.Text = subtitulo; 
            oTableSubTitulo.ColumnSpan = colspan;
            oGridViewRow2.HorizontalAlign = HorizontalAlign.Center;
            oGridViewRow2.Cells.Add(oTableSubTitulo);//cargamos el dato al gridview
            oGridViewRow2.BackColor = System.Drawing.Color.White;
            oGridViewRow2.ForeColor = System.Drawing.Color.Gray;
             //((Table)GView.Controls[0]).Rows.AddAt(0, oGridViewRow2);
            //RENGLON TITULO
            GridViewRow oGridViewRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
            //En la siguiente tabla construimos el registro del header extra
            TableCell oTableTitulo = new TableCell();
            //TiTULO
            oTableTitulo.Text = titulo; //Le añades un valor
            oTableTitulo.ColumnSpan = colspan;
            oGridViewRow.HorizontalAlign = HorizontalAlign.Center;
            oGridViewRow.Cells.Add(oTableTitulo);
            oGridViewRow.BackColor = System.Drawing.Color.White;
            oGridViewRow.ForeColor = System.Drawing.Color.Gray;
            oGridViewRow.Font.Bold = true;
             //((Table)GView.Controls[0]).Rows.AddAt(0, oGridViewRow);
            //agregamos los registros de titulo y subtitulo a una tabla
            tablatitulos.Rows.Add(oGridViewRow);
            tablatitulos.Rows.Add(oGridViewRow2);
            

            //agregamos el estilo al gridview exportado
            GView.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GView.HeaderRow.Cells)
            {
                cell.BackColor = GView.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GView.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GView.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GView.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo
            //tablatitulos.Rows.AddAt(1, GView);
            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(tablatitulos);
            form.Controls.Add(GView);
            return form;
        }


    
        public System.Web.UI.HtmlControls.HtmlForm exportarGrid_excel2(object sender, string query, string datosizq, string titulos, string datosder, string tramo, string colspan, string campos_ocultar)//,string nombusr)
        {   //Procedimiento para exportar a excel un gridview cuando se tiene que agregar varios titulos y columnas en el reporte

            System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
            //toma automaticamente el estilo que tiene el gridview
            GView.AllowPaging = false;
            if (query != "")
            {
                Carga_Gridview(GView, query);
            }
            //GView.GridLines = GridLines.None;

            string[] tit = titulos.Split(',');
            string[] dizq = datosizq.Split(',');
            string[] dder = datosder.Split(',');
            string[] dcolspan = colspan.Split(',');
            int totcolum = 0;
            System.Web.UI.WebControls.Table tablatitulos = new System.Web.UI.WebControls.Table();
            if (titulos != "")
            {
                for (int n = 0; n < tit.Length; n++)
                {
                    GridViewRow oGridViewRowTbTitulos = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                    //Datos lado izquierdo
                    TableCell oTableSubIzq = new TableCell();
                    oTableSubIzq.Text = dizq[n];
                    oTableSubIzq.ColumnSpan = Int32.Parse(dcolspan[0]);
                    oTableSubIzq.HorizontalAlign = HorizontalAlign.Left;
                    oGridViewRowTbTitulos.Cells.Add(oTableSubIzq);//cargamos el dato al gridview
                    //TiTULO
                    TableCell oTableSubTitulo = new TableCell();
                    oTableSubTitulo.Text = tit[n];
                    oTableSubTitulo.ColumnSpan = Int32.Parse(dcolspan[1]);
                    oTableSubTitulo.HorizontalAlign = HorizontalAlign.Center;
                    //oGridViewRowTbTitulos.Cells[1].Controls.Add(oTableSubTitulo);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubTitulo);//cargamos el dato al gridview
                    //Datos lado derecho
                    TableCell oTableSubDer = new TableCell();
                    oTableSubDer.Text = dder[n];
                    oTableSubDer.ColumnSpan = Int32.Parse(dcolspan[2]);
                    oTableSubDer.HorizontalAlign = HorizontalAlign.Right;
                    //agregamos las celdas al registros
                    //oGridViewRowTbTitulos.Cells[2].Controls.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.BackColor = System.Drawing.Color.White;
                    oGridViewRowTbTitulos.ForeColor = System.Drawing.Color.Gray;
                    totcolum += Int32.Parse(dcolspan[n]);
                    tablatitulos.Rows.Add(oGridViewRowTbTitulos);
                    //n++;
                }

                GridViewRow oGridViewRowTbTramo = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                //Registro para poner el nombre del usuario que genero el reporte
                TableCell oTableUsuario = new TableCell();
                oTableUsuario.Text = HttpContext.Current.Session["usuario"].ToString();
                oTableUsuario.ColumnSpan = 2;
                oTableUsuario.HorizontalAlign = HorizontalAlign.Left;
                oGridViewRowTbTramo.Cells.Add(oTableUsuario);//cargamos el dato al gridview
                //Registros para poner tramo de clave operativa o algun dato o dejar en blanco
                TableCell oTableTramo = new TableCell();
                oTableTramo.Text = tramo;
                oTableTramo.ColumnSpan = totcolum - 2;
                oTableTramo.HorizontalAlign = HorizontalAlign.Right;
                oGridViewRowTbTramo.Cells.Add(oTableTramo);//cargamos el dato al gridview
                tablatitulos.Rows.Add(oGridViewRowTbTramo);
            }



            //agregamos el estilo al gridview exportado
            GView.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GView.HeaderRow.Cells)
            {
                cell.BackColor = GView.HeaderStyle.BackColor;
                //string id=cell.ID;
            }
            foreach (GridViewRow row in GView.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GView.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GView.RowStyle.BackColor;

                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo
            //tablatitulos.Rows.AddAt(1, GView);

            //spliteamos las columnas que no queremos que se pasen al excel
            string lines = campos_ocultar;

            if ((lines != null) && (lines != ""))
            {
                string[] cols = lines.Split(',');
                foreach (string colum in cols)
                {

                    GView.Columns[Int32.Parse(colum)].Visible = false;
                    GView.HeaderRow.Cells[0].Visible = false;
                    //GView.HeaderRow.Cells[0].ColumnSpan = 1;
                }
            }

            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(tablatitulos);
            //form.Controls.Add(tablatitulosmod);
            form.Controls.Add(GView);
            return form;
        }

        public System.Web.UI.HtmlControls.HtmlForm exportarGrid_excelVerif(object sender, string query,string separador, string datosizq, string titulos, string datosder, string tramo, string colspan, string campos_ocultar)//,string nombusr)
        {   //Procedimiento para exportar a excel un gridview cuando se tiene que agregar varios titulos y columnas en el reporte
            //este acepta mas de 3 renglones de titulos y  comas en los titulos 
            //separador: tipo de separador a usar para datosizq,titulos y datosder

            System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
            //toma automaticamente el estilo que tiene el gridview
            GView.AllowPaging = false;
            if (query != "")
            {
                string[] desagreci = query.Split('|');
                string desasdrc = desagreci[0];
                string desasentc = desagreci[1];
                string desascec = desagreci[2];
                string desasczc = desagreci[3];
                string desascmc = desagreci[4];
                int desanivelc = 0;
                string storedproc = desagreci[5];
                Carga_REPORTE_GRIDVIEW(sender, storedproc, "REGISTROS", desasdrc, desasentc, desascec, desasczc, desascmc, desanivelc);
            }
            //GView.GridLines = GridLines.None;

            string[] tit = titulos.Split(char.Parse(separador));
            string[] dizq = datosizq.Split(char.Parse(separador));
            string[] dder = datosder.Split(char.Parse(separador));
            string[] dcolspan = colspan.Split(',');
            int totcolum = 0;
            System.Web.UI.WebControls.Table tablatitulos = new System.Web.UI.WebControls.Table();
            if (titulos != "")
            {
                for (int n = 0; n < tit.Length; n++)
                {
                    GridViewRow oGridViewRowTbTitulos = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                    //Datos lado izquierdo
                    TableCell oTableSubIzq = new TableCell();
                    oTableSubIzq.Text = dizq[n];
                    oTableSubIzq.ColumnSpan = Int32.Parse(dcolspan[0]);
                    oTableSubIzq.HorizontalAlign = HorizontalAlign.Left;
                    oGridViewRowTbTitulos.Cells.Add(oTableSubIzq);//cargamos el dato al gridview
                    //TiTULO
                    TableCell oTableSubTitulo = new TableCell();
                    oTableSubTitulo.Text = tit[n];
                    oTableSubTitulo.ColumnSpan = Int32.Parse(dcolspan[1]);
                    oTableSubTitulo.HorizontalAlign = HorizontalAlign.Center;
                    //oGridViewRowTbTitulos.Cells[1].Controls.Add(oTableSubTitulo);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubTitulo);//cargamos el dato al gridview
                    //Datos lado derecho
                    TableCell oTableSubDer = new TableCell();
                    oTableSubDer.Text = dder[n];
                    oTableSubDer.ColumnSpan = Int32.Parse(dcolspan[2]);
                    oTableSubDer.HorizontalAlign = HorizontalAlign.Right;
                    //agregamos las celdas al registros
                    //oGridViewRowTbTitulos.Cells[2].Controls.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.BackColor = System.Drawing.Color.White;
                    oGridViewRowTbTitulos.ForeColor = System.Drawing.Color.Gray;
                    if (n<3) 
                        { totcolum += Int32.Parse(dcolspan[n]); }
                    tablatitulos.Rows.Add(oGridViewRowTbTitulos);
                    //n++;
                }

                GridViewRow oGridViewRowTbTramo = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                //Registro para poner el nombre del usuario que genero el reporte
                TableCell oTableUsuario = new TableCell();
                oTableUsuario.Text = HttpContext.Current.Session["usuario"].ToString();
                oTableUsuario.ColumnSpan = 2;
                oTableUsuario.HorizontalAlign = HorizontalAlign.Left;
                oGridViewRowTbTramo.Cells.Add(oTableUsuario);//cargamos el dato al gridview
                //Registros para poner tramo de clave operativa o algun dato o dejar en blanco
                TableCell oTableTramo = new TableCell();
                oTableTramo.Text = tramo;
                oTableTramo.ColumnSpan = totcolum - 2;
                oTableTramo.HorizontalAlign = HorizontalAlign.Right;
                oGridViewRowTbTramo.Cells.Add(oTableTramo);//cargamos el dato al gridview
                tablatitulos.Rows.Add(oGridViewRowTbTramo);
            }



            //agregamos el estilo al gridview exportado
            GView.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GView.HeaderRow.Cells)
            {
                cell.BackColor = GView.HeaderStyle.BackColor;
                //string id=cell.ID;
            }
            foreach (GridViewRow row in GView.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GView.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GView.RowStyle.BackColor;

                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo
            //tablatitulos.Rows.AddAt(1, GView);

            //spliteamos las columnas que no queremos que se pasen al excel
            string lines = campos_ocultar;

            if ((lines != null) && (lines != ""))
            {
                string[] cols = lines.Split(',');
                foreach (string colum in cols)
                {

                    GView.Columns[Int32.Parse(colum)].Visible = false;
                    GView.HeaderRow.Cells[0].Visible = false;
                    //GView.HeaderRow.Cells[0].ColumnSpan = 1;
                }
            }

            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(tablatitulos);
            //form.Controls.Add(tablatitulosmod);
            form.Controls.Add(GView);
            return form;
        }

        //procedimiento para exportar dos gridview uno con totales y el segundo es un listado
        public System.Web.UI.HtmlControls.HtmlForm exportarGrid_excel3(object sender, string query, string datosizq, string titulos, string datosder, string tramo, string colspan, string campos_ocultar, object sender2, string query2)//,string nombusr)
        {   //Procedimiento para exportar a excel un gridview cuando se tiene que agregar varios titulos y columnas en el reporte
            //gridview de los totales
            System.Web.UI.WebControls.GridView GViewtot = (System.Web.UI.WebControls.GridView)(sender2);
            //toma automaticamente el estilo que tiene el gridview
            GViewtot.AllowPaging = false;
            if (query2 != "")
            {
                Carga_Gridview(GViewtot, query2);
            }
            
            //GView.GridLines = GridLines.None;

            string[] tit = titulos.Split(',');
            string[] dizq = datosizq.Split(',');
            string[] dder = datosder.Split(',');
            string[] dcolspan = colspan.Split(',');
            int totcolum = 0;
            System.Web.UI.WebControls.Table tablatitulos = new System.Web.UI.WebControls.Table();
            for (int n = 0; n < tit.Length; n++)
            {
                GridViewRow oGridViewRowTbTitulos = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                //Datos lado izquierdo
                TableCell oTableSubIzq = new TableCell();
                oTableSubIzq.Text = dizq[n];
                oTableSubIzq.ColumnSpan = Int32.Parse(dcolspan[0]);
                oTableSubIzq.HorizontalAlign = HorizontalAlign.Left;
                oGridViewRowTbTitulos.Cells.Add(oTableSubIzq);//cargamos el dato al gridview
                //TiTULO
                TableCell oTableSubTitulo = new TableCell();
                oTableSubTitulo.Text = tit[n];
                oTableSubTitulo.ColumnSpan = Int32.Parse(dcolspan[1]);
                oTableSubTitulo.HorizontalAlign = HorizontalAlign.Center;
                //oGridViewRowTbTitulos.Cells[1].Controls.Add(oTableSubTitulo);//cargamos el dato al gridview
                oGridViewRowTbTitulos.Cells.Add(oTableSubTitulo);//cargamos el dato al gridview
                //Datos lado derecho
                TableCell oTableSubDer = new TableCell();
                oTableSubDer.Text = dder[n];
                oTableSubDer.ColumnSpan = Int32.Parse(dcolspan[2]);
                oTableSubDer.HorizontalAlign = HorizontalAlign.Right;
                //agregamos las celdas al registros

                //oGridViewRowTbTitulos.Cells[2].Controls.Add(oTableSubDer);//cargamos el dato al gridview
                oGridViewRowTbTitulos.Cells.Add(oTableSubDer);//cargamos el dato al gridview
                oGridViewRowTbTitulos.BackColor = System.Drawing.Color.White;
                oGridViewRowTbTitulos.ForeColor = System.Drawing.Color.Gray;
                totcolum += Int32.Parse(dcolspan[n]);
                tablatitulos.Rows.Add(oGridViewRowTbTitulos);
                //n++;
            }
            GridViewRow oGridViewRowTbTramo = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
            //Registro para poner el nombre del usuario que genero el reporte
            TableCell oTableUsuario = new TableCell();
            oTableUsuario.Text = HttpContext.Current.Session["usuario"].ToString();
            oTableUsuario.ColumnSpan = 2;
            oTableUsuario.HorizontalAlign = HorizontalAlign.Left;
            oGridViewRowTbTramo.Cells.Add(oTableUsuario);//cargamos el dato al gridview
            //Registros para poner tramo de clave operativa o algun dato o dejar en blanco
            TableCell oTableTramo = new TableCell();
            oTableTramo.Text = tramo;
            oTableTramo.ColumnSpan = totcolum - 2;
            oTableTramo.HorizontalAlign = HorizontalAlign.Right;
            oGridViewRowTbTramo.Cells.Add(oTableTramo);//cargamos el dato al gridview
            tablatitulos.Rows.Add(oGridViewRowTbTramo);

            //agregamos el estilo al gridview exportado
            GViewtot.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GViewtot.HeaderRow.Cells)
            {
                cell.BackColor = GViewtot.HeaderStyle.BackColor;
                //string id=cell.ID;
            }
            foreach (GridViewRow row in GViewtot.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GViewtot.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GViewtot.RowStyle.BackColor;

                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo

           



            //gridview del listado o reporte
            System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
            //toma automaticamente el estilo que tiene el gridview
            GView.AllowPaging = false;
            if (query != "")
            {
                Carga_Gridview(GView, query);
            }
            //agregamos el estilo al gridview exportado
            GView.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GView.HeaderRow.Cells)
            {
                cell.BackColor = GView.HeaderStyle.BackColor;
                //string id=cell.ID;
            }
            foreach (GridViewRow row in GView.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GView.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GView.RowStyle.BackColor;

                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo
            //tablatitulos.Rows.AddAt(1, GView);

            //spliteamos las columnas que no queremos que se pasen al excel
            string lines = campos_ocultar;

            if ((lines != null) && (lines != ""))
            {
                string[] cols = lines.Split(',');
                foreach (string colum in cols)
                {

                    GView.Columns[Int32.Parse(colum)].Visible = false;
                    GView.HeaderRow.Cells[0].Visible = false;
                    //GView.HeaderRow.Cells[0].ColumnSpan = 1;
                }
            }

            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Controls.Add(GViewtot);
            tr1.Cells.Add(cell1);
            tb.Rows.Add(tr1);
            TableRow tr2 = new TableRow();
            TableCell cell2 = new TableCell();
            cell2.Text = "&nbsp;";
            tr2.Cells.Add(cell2);
            tb.Rows.Add(tr2);
            TableRow tr3 = new TableRow();
            TableCell cell3 = new TableCell();
            cell3.Controls.Add(GView);
            tr3.Cells.Add(cell3);
            tb.Rows.Add(tr3);
            


            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(tablatitulos);
            form.Controls.Add(tb);
            //form.Controls.Add();
            //form.Controls.Add();
            return form;
        }

        public System.Web.UI.HtmlControls.HtmlForm exportarGrid_excel_cobertura(object sender, string query, string datosizq, string titulos, string datosder, string tramo, string colspan, string campos_ocultar)//,string nombusr)
        {   //Procedimiento para exportar a excel un gridview cuando se tiene que agregar varios titulos y columnas en el reporte

            System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
            //toma automaticamente el estilo que tiene el gridview
            GView.AllowPaging = false;

            string[] desagreci = query.Split('|');
            string desasdrc = desagreci[0];
            string desasentc = desagreci[1];
            string desascec = desagreci[2];
            string desasczc = desagreci[3];
            string desascmc = desagreci[4];
            int desanivelc = Int32.Parse(desagreci[5]);
            string storedproc = desagreci[6];
            Carga_REPORTE_GRIDVIEW(sender, storedproc, "REGISTROS", desasdrc, desasentc, desascec, desasczc, desascmc, desanivelc);

            //GView.GridLines = GridLines.None;

            string[] tit = titulos.Split(',');
            string[] dizq = datosizq.Split(',');
            string[] dder = datosder.Split(',');
            string[] dcolspan = colspan.Split(',');
            int totcolum = 0;
            System.Web.UI.WebControls.Table tablatitulos = new System.Web.UI.WebControls.Table();
            if (titulos != "")
            {
                for (int n = 0; n < tit.Length; n++)
                {
                    GridViewRow oGridViewRowTbTitulos = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                    //Datos lado izquierdo
                    TableCell oTableSubIzq = new TableCell();
                    oTableSubIzq.Text = dizq[n];
                    oTableSubIzq.ColumnSpan = Int32.Parse(dcolspan[0]);
                    oTableSubIzq.HorizontalAlign = HorizontalAlign.Left;
                    oGridViewRowTbTitulos.Cells.Add(oTableSubIzq);//cargamos el dato al gridview
                    //TiTULO
                    TableCell oTableSubTitulo = new TableCell();
                    oTableSubTitulo.Text = tit[n];
                    oTableSubTitulo.ColumnSpan = Int32.Parse(dcolspan[1]);
                    oTableSubTitulo.HorizontalAlign = HorizontalAlign.Center;
                    //oGridViewRowTbTitulos.Cells[1].Controls.Add(oTableSubTitulo);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubTitulo);//cargamos el dato al gridview
                    //Datos lado derecho
                    TableCell oTableSubDer = new TableCell();
                    oTableSubDer.Text = dder[n];
                    oTableSubDer.ColumnSpan = Int32.Parse(dcolspan[2]);
                    oTableSubDer.HorizontalAlign = HorizontalAlign.Right;
                    //agregamos las celdas al registros

                    //oGridViewRowTbTitulos.Cells[2].Controls.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.BackColor = System.Drawing.Color.White;
                    oGridViewRowTbTitulos.ForeColor = System.Drawing.Color.Gray;
                    totcolum += Int32.Parse(dcolspan[n]);
                    tablatitulos.Rows.Add(oGridViewRowTbTitulos);
                    //n++;
                }

                GridViewRow oGridViewRowTbTramo = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                //Registro para poner el nombre del usuario que genero el reporte
                TableCell oTableUsuario = new TableCell();
                oTableUsuario.Text = HttpContext.Current.Session["usuario"].ToString();
                oTableUsuario.ColumnSpan = 2;
                oTableUsuario.HorizontalAlign = HorizontalAlign.Left;
                oGridViewRowTbTramo.Cells.Add(oTableUsuario);//cargamos el dato al gridview
                //Registros para poner tramo de clave operativa o algun dato o dejar en blanco
                TableCell oTableTramo = new TableCell();
                oTableTramo.Text = tramo;
                oTableTramo.ColumnSpan = totcolum - 2;
                oTableTramo.HorizontalAlign = HorizontalAlign.Right;
                oGridViewRowTbTramo.Cells.Add(oTableTramo);//cargamos el dato al gridview
                tablatitulos.Rows.Add(oGridViewRowTbTramo);
            }



            //agregamos el estilo al gridview exportado
            GView.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GView.HeaderRow.Cells)
            {
                cell.BackColor = GView.HeaderStyle.BackColor;
                //string id=cell.ID;
            }
            foreach (GridViewRow row in GView.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GView.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GView.RowStyle.BackColor;

                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo
            //tablatitulos.Rows.AddAt(1, GView);

            //spliteamos las columnas que no queremos que se pasen al excel
            string lines = campos_ocultar;

            if ((lines != null) && (lines != ""))
            {
                string[] cols = lines.Split(',');
                foreach (string colum in cols)
                {

                    GView.Columns[Int32.Parse(colum)].Visible = false;
                    GView.HeaderRow.Cells[0].Visible = false;
                    //GView.HeaderRow.Cells[0].ColumnSpan = 1;
                }
            }

            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(tablatitulos);
            //form.Controls.Add(tablatitulosmod);
            form.Controls.Add(GView);
            return form;
        }

        public System.Web.UI.HtmlControls.HtmlForm exportarGrid_excel_tablero(object sender, string query, string datosizq, string titulos, string datosder, string tramo, string colspan, string campos_ocultar,int nivelselec,string colimagenes,string namecolimagenes)//,string nombusr)
        {   //Procedimiento para exportar a excel un gridview cuando se tiene que agregar varios titulos y columnas en el reporte

            //nivelselec: usando en tablero 3, 0 cuando se va a mostrar solo las cm que le pertenecen a la figura y 1 cuando se muestra las CM con cada uno de sus capturistas
            //colimagenes: array del numero de columnas que son imagenes separados por "|" 
            //namecolimagenes: array de los id de las columnas que son imagenes  separados por "|" 
            //NOTA: se requiere el query cuando el reporte esta paginado, en caso contrario debe venir en blanco, ademas el campo nivelselec solo se usa si se va a filtrar el reporte , por CM o por CM y sus figuras
            System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
            //toma automaticamente el estilo que tiene el gridview
            GView.AllowPaging = false;

            if (query != "")
            {
                string[] desagreci = query.Split('|');
                string desasdrc = desagreci[0];
                string desasentc = desagreci[1];
                string desascec = desagreci[2];
                string desasczc = desagreci[3];
                string desascmc = desagreci[4];
                int desanivelc = nivelselec;
                string storedproc = "";
                if (colimagenes != "")
                {
                    desanivelc = nivelselec;
                    storedproc = desagreci[6];
                    Carga_REPORTE_GRIDVIEW_TAB(sender, storedproc, "REGISTROS", desasdrc, desasentc, desascec, desasczc, desascmc, desanivelc, 0, 0, 3);
                }
                else//para usar los reportes de mon digitacion y mon verificacion
                {
                    string cap_usr = desagreci[5];
                    desanivelc = Int32.Parse(desagreci[6].ToString());
                    storedproc = desagreci[7];
                    Carga_REPORTE_GRIDVIEW_USR(sender, storedproc, "REGISTROS", desasdrc, desasentc, desascec, desasczc, desascmc, cap_usr, desanivelc, "");
                }
            }
            //GView.GridLines = GridLines.None;
            

            string[] tit = titulos.Split(',');
            string[] dizq = datosizq.Split(',');
            string[] dder = datosder.Split(',');
            string[] dcolspan = colspan.Split(',');
            int totcolum = 0;
            System.Web.UI.WebControls.Table tablatitulos = new System.Web.UI.WebControls.Table();
            if (titulos != "")
            {
                for (int n = 0; n < tit.Length; n++)
                {
                    GridViewRow oGridViewRowTbTitulos = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                    //Datos lado izquierdo
                    TableCell oTableSubIzq = new TableCell();
                    oTableSubIzq.Text = dizq[n];
                    oTableSubIzq.ColumnSpan = Int32.Parse(dcolspan[0]);
                    oTableSubIzq.HorizontalAlign = HorizontalAlign.Left;
                    oGridViewRowTbTitulos.Cells.Add(oTableSubIzq);//cargamos el dato al gridview
                    //TiTULO
                    TableCell oTableSubTitulo = new TableCell();
                    oTableSubTitulo.Text = tit[n];
                    oTableSubTitulo.ColumnSpan = Int32.Parse(dcolspan[1]);
                    oTableSubTitulo.HorizontalAlign = HorizontalAlign.Center;
                    //oGridViewRowTbTitulos.Cells[1].Controls.Add(oTableSubTitulo);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubTitulo);//cargamos el dato al gridview
                    //Datos lado derecho
                    TableCell oTableSubDer = new TableCell();
                    oTableSubDer.Text = dder[n];
                    oTableSubDer.ColumnSpan = Int32.Parse(dcolspan[2]);
                    oTableSubDer.HorizontalAlign = HorizontalAlign.Right;
                    //agregamos las celdas al registros

                    //oGridViewRowTbTitulos.Cells[2].Controls.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.Cells.Add(oTableSubDer);//cargamos el dato al gridview
                    oGridViewRowTbTitulos.BackColor = System.Drawing.Color.White;
                    oGridViewRowTbTitulos.ForeColor = System.Drawing.Color.Gray;
                    totcolum += Int32.Parse(dcolspan[n]);
                    tablatitulos.Rows.Add(oGridViewRowTbTitulos);
                    //n++;
                }

                GridViewRow oGridViewRowTbTramo = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Insert);
                //Registro para poner el nombre del usuario que genero el reporte
                TableCell oTableUsuario = new TableCell();
                oTableUsuario.Text = HttpContext.Current.Session["usuario"].ToString();
                oTableUsuario.ColumnSpan = 2;
                oTableUsuario.HorizontalAlign = HorizontalAlign.Left;
                oGridViewRowTbTramo.Cells.Add(oTableUsuario);//cargamos el dato al gridview
                //Registros para poner tramo de clave operativa o algun dato o dejar en blanco
                TableCell oTableTramo = new TableCell();
                oTableTramo.Text = tramo;
                oTableTramo.ColumnSpan = totcolum - 2;
                oTableTramo.HorizontalAlign = HorizontalAlign.Right;
                oGridViewRowTbTramo.Cells.Add(oTableTramo);//cargamos el dato al gridview
                tablatitulos.Rows.Add(oGridViewRowTbTramo);
            }


            
            //agregamos el estilo al gridview exportado
            GView.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GView.HeaderRow.Cells)
            {
                cell.BackColor = GView.HeaderStyle.BackColor;
                //string id=cell.ID;
            }
            //obtenes los numeros de las columnas que traen las imagenes
            string[] cimagenes = colimagenes.Split('|');
            string[] nomimagenes = namecolimagenes.Split('|');
                
            foreach (GridViewRow row in GView.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                if (colimagenes != "")
                {
                    string nomcap = "";
                    string colorcamp = "";
                    for (int n = 0; n < cimagenes.Length; n++)
                    {
                        int numx = Int32.Parse(cimagenes[n].ToString());
                        nomcap = nomimagenes[n];
                        System.Web.UI.WebControls.Image campoimg = (System.Web.UI.WebControls.Image)row.Cells[numx].FindControl(nomcap);
                        switch (campoimg.ImageUrl.ToString().ToLower())
                        {
                            case "~/images/verde.ico": { colorcamp = "Verde"; break; }
                            case "~/images/amarillo.ico": { colorcamp = "Amarillo"; break; }
                            case "~/images/rojo.ico": { colorcamp = "Rojo"; break; }
                            case "~/images/gris.ico": { colorcamp = "Gris"; break; }
                            case "~/images/concluido.ico": { colorcamp = "Concluido"; break; }
                        }
                        row.Cells[numx].Text = colorcamp;
                    }
                }
                /*System.Web.UI.WebControls.Image tmio7 = (System.Web.UI.WebControls.Image)row.Cells[10].FindControl("banPROD_EDO");
                string dato7 = tmio7.ImageUrl.ToString();
                row.Cells[10].Text = dato7;
                System.Web.UI.WebControls.Image tmio8 = (System.Web.UI.WebControls.Image)row.Cells[11].FindControl("ban_CALIDAD");
                string dato8 = tmio8.ImageUrl.ToString();
                row.Cells[11].Text = dato8;
                System.Web.UI.WebControls.Image tmio9 = (System.Web.UI.WebControls.Image)row.Cells[12].FindControl("ban_ANALISTA");
                string dato9 = tmio9.ImageUrl.ToString();
                row.Cells[12].Text = dato9;*/
                foreach (TableCell cell in row.Cells)
                {

                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GView.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GView.RowStyle.BackColor;

                    }
                    cell.CssClass = "textmode";
                }//fin foreach interno
            }//fin foreach externo
            //tablatitulos.Rows.AddAt(1, GView);

            //spliteamos las columnas que no queremos que se pasen al excel
            string lines = campos_ocultar;

            if ((lines != null) && (lines != ""))
            {
                string[] cols = lines.Split(',');
                foreach (string colum in cols)
                {

                    GView.Columns[Int32.Parse(colum)].Visible = false;
                    GView.HeaderRow.Cells[0].Visible = false;
                    //GView.HeaderRow.Cells[0].ColumnSpan = 1;
                }
            }

            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(tablatitulos);
            //form.Controls.Add(tablatitulosmod);
            form.Controls.Add(GView);
            return form;
        }

        

        //Procedimiento para cargar un arbol con los nodos marcados si estan la relacion de opciones del menu con el perfil seleccionado

        public void Carga_arbol_menu(object sender, string id_perfil)
        {
                System.Web.UI.WebControls.TreeView arbol_menu = (System.Web.UI.WebControls.TreeView)(sender);
                OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]); // C#
                conn.Open();
                DataSet ds = new DataSet();
                string sql = "Select MenuID,Text,Description,ParentID,Image,Navigate from TC_Menu order by menuid";
                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.Fill(ds);
                da.Dispose();
                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";
                DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MenuID"], ds.Tables["Menu"].Columns["ParentID"], true);
                relation.Nested = true;
                ds.Relations.Add(relation);
                XmlDocument myXMLDocument = new XmlDocument();
                myXMLDocument.LoadXml(ds.GetXml());
                XmlNodeList listaMenus = myXMLDocument.SelectNodes("Menus/Menu");
                XmlNode unMenu;
                for (int i = 0; i < listaMenus.Count; i++)
                {
                    unMenu = listaMenus.Item(i);
                    string mid = unMenu.SelectSingleNode("MENUID").InnerText;
                    string mtexto = unMenu.SelectSingleNode("TEXT").InnerText;
                    string mdesc = unMenu.SelectSingleNode("DESCRIPTION").InnerText;
                    string mimage = unMenu.SelectSingleNode("IMAGE").InnerText;
                    string mnav = unMenu.SelectSingleNode("NAVIGATE").InnerText;
                    TreeNode nuevoNodo = new TreeNode();
                    nuevoNodo.Text = mid + " " + mtexto;
                    try
                    {
                        OracleCommand cmd2 = new OracleCommand();
                        cmd2.Connection = conn;
                        cmd2.CommandText = "select id_perfil,menuid from tr_rel_perfil_menu where id_perfil = " + id_perfil + " and menuid=" + mid + "  order by menuid";
                        cmd2.CommandType = CommandType.Text;
                        OracleDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            nuevoNodo.Checked = true;
                        }
                        dr2.Dispose();
                        cmd2.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        //conn.Dispose();
                    }
                    arbol_menu.Nodes.Add(nuevoNodo);
                    XmlNodeList listaMenus2 = myXMLDocument.SelectNodes("Menus/Menu/Menu");
                    XmlNode unMenu2;
                    for (int j = 0; j < listaMenus2.Count; j++)
                    {
                        unMenu2 = listaMenus2.Item(j);
                        string mid2 = unMenu2.SelectSingleNode("MENUID").InnerText;
                        string mtexto2 = unMenu2.SelectSingleNode("TEXT").InnerText;
                        string mdesc2 = unMenu2.SelectSingleNode("DESCRIPTION").InnerText;
                        string mpadre2 = unMenu2.SelectSingleNode("PARENTID").InnerText;
                        string mimage2 = unMenu2.SelectSingleNode("IMAGE").InnerText;
                        string mnav2 = unMenu2.SelectSingleNode("NAVIGATE").InnerText;
                        if (mid == mpadre2)
                        {
                            TreeNode nodoA = new TreeNode();
                            nodoA.Text = mid2 + " " + mtexto2;
                            try
                            {
                                OracleCommand cmd2 = new OracleCommand();
                                cmd2.Connection = conn;
                                cmd2.CommandText = "select id_perfil,menuid from tr_rel_perfil_menu where id_perfil = " + id_perfil + " and menuid=" + mid2 + "  order by menuid";
                                cmd2.CommandType = CommandType.Text;
                                OracleDataReader dr2 = cmd2.ExecuteReader();
                                if (dr2.Read())
                                {
                                    nodoA.Checked = true;
                                }
                                dr2.Dispose();
                                cmd2.Dispose();
                            }
                            catch (Exception e1)
                            {
                                HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                            }
                            finally
                            {
                                //conn.Dispose();
                            }
                            nodoA.ImageUrl = "~/Images/services.ico";
                            nuevoNodo.ChildNodes.Add(nodoA);
                            nuevoNodo.ImageUrl = "~/Images/netfol.ico";
                            XmlNodeList listaMenus3 = myXMLDocument.SelectNodes("Menus/Menu/Menu/Menu");
                            XmlNode unMenu3;
                            for (int k = 0; k < listaMenus3.Count; k++)
                            {
                                unMenu3 = listaMenus3.Item(k);
                                string mid3 = unMenu3.SelectSingleNode("MENUID").InnerText;
                                string mtexto3 = unMenu3.SelectSingleNode("TEXT").InnerText;
                                string mdesc3 = unMenu3.SelectSingleNode("DESCRIPTION").InnerText;
                                string mpadre3 = unMenu3.SelectSingleNode("PARENTID").InnerText;
                                string mimage3 = unMenu3.SelectSingleNode("IMAGE").InnerText;
                                string mnav3 = unMenu3.SelectSingleNode("NAVIGATE").InnerText;
                                if (mid2 == mpadre3)
                                {
                                    TreeNode nodoB = new TreeNode();
                                    nodoB.Text = mid3 + " " + mtexto3;
                                    try
                                    {
                                        OracleCommand cmd2 = new OracleCommand();
                                        cmd2.Connection = conn;
                                        cmd2.CommandText = "select id_perfil,menuid from tr_rel_perfil_menu where id_perfil = " + id_perfil + " and menuid=" + mid3 + "  order by menuid";
                                        cmd2.CommandType = CommandType.Text;
                                        OracleDataReader dr2 = cmd2.ExecuteReader();
                                        if (dr2.Read())
                                        {
                                            nodoB.Checked = true;
                                        }
                                        dr2.Dispose();
                                        cmd2.Dispose();
                                    }
                                    catch (Exception e1)
                                    {
                                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                                    }
                                    finally
                                    {
                                        //conn.Dispose();
                                    }
                                    nodoB.ImageUrl = "~/Images/services.ico";
                                    nodoA.ChildNodes.Add(nodoB);
                                    nodoA.ImageUrl = "~/Images/netfol2.ico";
                                }
                            }
                        }
                    }
                }
                conn.Dispose();
        }

        //Procedimiento para cargar un arbol con los nodos de las opciones disponibles del menu
        public void Carga_arbol_menu(object sender)
        {
            System.Web.UI.WebControls.TreeView arbol_menu = (System.Web.UI.WebControls.TreeView)(sender);
            OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]); // C#
            conn.Open();
            DataSet ds = new DataSet();
            string sql = "Select MenuID,Text,Description,ParentID,Image,Navigate from TC_Menu  order by menuid";
            OracleDataAdapter da = new OracleDataAdapter(sql, conn);
            da.Fill(ds);
            da.Dispose();
            ds.DataSetName = "Menus";
            ds.Tables[0].TableName = "Menu";
            DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MenuID"], ds.Tables["Menu"].Columns["ParentID"], true);
            relation.Nested = true;
            ds.Relations.Add(relation);
            XmlDocument myXMLDocument = new XmlDocument();
            myXMLDocument.LoadXml(ds.GetXml());
            XmlNodeList listaMenus = myXMLDocument.SelectNodes("Menus/Menu");
            XmlNode unMenu;
            for (int i = 0; i < listaMenus.Count; i++)
            {
                unMenu = listaMenus.Item(i);
                string mid = unMenu.SelectSingleNode("MENUID").InnerText;
                string mtexto = unMenu.SelectSingleNode("TEXT").InnerText;
                string mdesc = unMenu.SelectSingleNode("DESCRIPTION").InnerText;
                string mimage = unMenu.SelectSingleNode("IMAGE").InnerText;
                string mnav = unMenu.SelectSingleNode("NAVIGATE").InnerText;
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = mid + " " + mtexto;
                
                arbol_menu.Nodes.Add(nuevoNodo);
                XmlNodeList listaMenus2 = myXMLDocument.SelectNodes("Menus/Menu/Menu");
                XmlNode unMenu2;
                for (int j = 0; j < listaMenus2.Count; j++)
                {
                    unMenu2 = listaMenus2.Item(j);
                    string mid2 = unMenu2.SelectSingleNode("MENUID").InnerText;
                    string mtexto2 = unMenu2.SelectSingleNode("TEXT").InnerText;
                    string mdesc2 = unMenu2.SelectSingleNode("DESCRIPTION").InnerText;
                    string mpadre2 = unMenu2.SelectSingleNode("PARENTID").InnerText;
                    string mimage2 = unMenu2.SelectSingleNode("IMAGE").InnerText;
                    string mnav2 = unMenu2.SelectSingleNode("NAVIGATE").InnerText;
                    if (mid == mpadre2)
                    {
                        TreeNode nodoA = new TreeNode();
                        nodoA.Text = mid2 + " " + mtexto2;
                        
                        nodoA.ImageUrl = "~/Images/services.ico";
                        nuevoNodo.ChildNodes.Add(nodoA);
                        nuevoNodo.ImageUrl = "~/Images/netfol.ico";
                        XmlNodeList listaMenus3 = myXMLDocument.SelectNodes("Menus/Menu/Menu/Menu");
                        XmlNode unMenu3;
                        for (int k = 0; k < listaMenus3.Count; k++)
                        {
                            unMenu3 = listaMenus3.Item(k);
                            string mid3 = unMenu3.SelectSingleNode("MENUID").InnerText;
                            string mtexto3 = unMenu3.SelectSingleNode("TEXT").InnerText;
                            string mdesc3 = unMenu3.SelectSingleNode("DESCRIPTION").InnerText;
                            string mpadre3 = unMenu3.SelectSingleNode("PARENTID").InnerText;
                            string mimage3 = unMenu3.SelectSingleNode("IMAGE").InnerText;
                            string mnav3 = unMenu3.SelectSingleNode("NAVIGATE").InnerText;
                            if (mid2 == mpadre3)
                            {
                                TreeNode nodoB = new TreeNode();
                                nodoB.Text = mid3 + " " + mtexto3;
                                
                                nodoB.ImageUrl = "~/Images/services.ico";
                                nodoA.ChildNodes.Add(nodoB);
                                nodoA.ImageUrl = "~/Images/netfol2.ico";
                            }
                        }
                    }
                }
            }
            conn.Dispose();
        }

        //Procedimiento para guardar las relaciones de las opciones del menu con el perfil
        public void Guardar_arbol_menu(object sender, string id_perfil)
        {
            OracleCommand cmd = new OracleCommand();
            OracleCommand cmd3 = new OracleCommand();
            System.Web.UI.WebControls.TreeView arbol_menu = (System.Web.UI.WebControls.TreeView)(sender);
            OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]); // C#
            conn.Open();
            cmd3.Connection = conn;
            cmd3.CommandText = "delete tr_rel_perfil_menu where id_perfil = " + id_perfil ;
            cmd3.CommandType = CommandType.Text;
            int j = cmd3.ExecuteNonQuery();
            cmd3.Dispose();
            foreach (TreeNode nuevoNodo in arbol_menu.Nodes)
            {
                if (nuevoNodo.Checked)
                {
                    string sLine = "";
                    ArrayList cadena1 = new ArrayList();
                    sLine = nuevoNodo.Text.ToString();
                    if (sLine != null)
                    {
                        char[] delimiterChars = { ' ' };
                        string text = sLine.ToString();
                        string[] words = text.Split(delimiterChars);
                        foreach (string s in words)
                        {
                            cadena1.Add(s.Trim());
                        }
                    }
                    try
                    {
                        cmd3.Connection = conn;
                        cmd3.CommandText = "INSERT INTO tr_rel_perfil_menu (id_perfil,menuid) VALUES ( " + id_perfil + "," + cadena1[0].ToString() + ")";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e2)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e2.ToString();
                    }
                    finally
                    {
                        cadena1.Clear();
                        //conn.Dispose();
                    }
                }
                foreach (TreeNode nodoA in nuevoNodo.ChildNodes)
                {
                    if (nodoA.Checked)
                    {
                        string sLine = "";
                        ArrayList cadena1 = new ArrayList();
                        sLine = nodoA.Text.ToString();
                        if (sLine != null)
                        {
                            char[] delimiterChars = { ' ' };
                            string text = sLine.ToString();
                            string[] words = text.Split(delimiterChars);
                            foreach (string s in words)
                            {
                                cadena1.Add(s.Trim());
                            }
                        }
                        try
                        {
                            cmd3.Connection = conn;
                            cmd3.CommandText = "INSERT INTO tr_rel_perfil_menu (id_perfil,menuid) VALUES ( " + id_perfil + "," + cadena1[0].ToString() + ")";
                            cmd3.CommandType = CommandType.Text;
                            int k = cmd3.ExecuteNonQuery();
                            cmd3.Dispose();
                        }
                        catch (Exception e2)
                        {
                            HttpContext.Current.Session["MensajeDeError"] = e2.ToString();
                        }
                        finally
                        {
                            cadena1.Clear();
                            //conn.Dispose();
                        }
                    }
                    foreach (TreeNode nodoB in nodoA.ChildNodes)
                    {
                        if (nodoB.Checked)
                        {
                            string sLine = "";
                            ArrayList cadena1 = new ArrayList();
                            sLine = nodoB.Text.ToString();
                            if (sLine != null)
                            {
                                char[] delimiterChars = { ' ' };
                                string text = sLine.ToString();
                                string[] words = text.Split(delimiterChars);
                                foreach (string s in words)
                                {
                                    cadena1.Add(s.Trim());
                                }
                            }
                            try
                            {
                                cmd3.Connection = conn;
                                cmd3.CommandText = "INSERT INTO tr_rel_perfil_menu (id_perfil,menuid) VALUES ( " + id_perfil + "," + cadena1[0].ToString() + ")";
                                cmd3.CommandType = CommandType.Text;
                                int k = cmd3.ExecuteNonQuery();
                                cmd3.Dispose();
                            }
                            catch (Exception e2)
                            {
                                HttpContext.Current.Session["MensajeDeError"] = e2.ToString();
                            }
                            finally
                            {
                                cadena1.Clear();
                                //conn.Dispose();
                            }
                        }
                    }
                }
            }
            conn.Dispose();
        }



        public void Carga_Combo(object sender, OracleDataReader registros, string dato)
        {
            System.Web.UI.WebControls.DropDownList Dg_list = (System.Web.UI.WebControls.DropDownList)(sender);
            Dg_list.Items.Clear();
            Dg_list.DataSource = registros;
            Dg_list.DataTextField = dato;
            Dg_list.DataValueField = dato;
            Dg_list.DataBind();
        }

        public void Carga_Combo(object sender, OracleDataReader registros, string dato, string value)
        {
            System.Web.UI.WebControls.DropDownList Dg_list = (System.Web.UI.WebControls.DropDownList)(sender);
            Dg_list.Items.Clear();
            Dg_list.DataSource = registros;
            Dg_list.DataTextField = dato;
            Dg_list.DataValueField = value;
            Dg_list.DataBind();
        }

        public void Carga_SP_Combo_(object sender, string NOMBRE_SP, string nombre_cursor, string DR, string ENT, string dato, string value)
        {//procedimiento para llenar un DropDownList desde un stored procedure
            DataSet ds = new DataSet();
            OracleConnection miConexion = new OracleConnection(ConfigurationManager.AppSettings["cai2020"]);
            //OracleDataReader miReader = null;
            OracleDataAdapter adapter = new OracleDataAdapter();
            try
            {
                OracleCommand miComando = new OracleCommand(NOMBRE_SP, miConexion);
                miComando.CommandType = CommandType.StoredProcedure;
                    miComando.Parameters.Add("IDR", OracleDbType.NVarchar2);
                    miComando.Parameters["IDR"].Value = DR;
                    miComando.Parameters.Add("IENT", OracleDbType.NVarchar2);
                    miComando.Parameters["IENT"].Value = ENT;
                //CURSOR DE SALIDA
                miComando.Parameters.Add(nombre_cursor, OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter odr = new OracleDataAdapter(miComando);
                odr.Fill(ds);

                //System.Web.UI.WebControls.GridView GView = (System.Web.UI.WebControls.GridView)(sender);
                //GView.DataSource = ds.Tables[0];
                //GView.DataBind();
                //adapter.Dispose();

                System.Web.UI.WebControls.DropDownList Dg_list = (System.Web.UI.WebControls.DropDownList)(sender);
                Dg_list.Items.Clear();
                Dg_list.DataSource = ds.Tables[0]; ;
                Dg_list.DataTextField = dato;
                Dg_list.DataValueField = value;
                Dg_list.DataBind();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            finally
            {
                miConexion.Close();
            }

        }


        public void Carga_ListBox(object sender, OracleDataReader registros, string dato)
        {
            System.Web.UI.WebControls.ListBox Dg_list = (System.Web.UI.WebControls.ListBox)(sender);
            Dg_list.Items.Clear();
            Dg_list.DataSource = registros;
            Dg_list.DataTextField = dato;
            Dg_list.DataValueField = dato;
            Dg_list.DataBind();
        }

        public void Carga_ListBox(object sender, OracleDataReader registros, string dato, string value)
        {
            System.Web.UI.WebControls.ListBox Dg_list = (System.Web.UI.WebControls.ListBox)(sender);
            Dg_list.Items.Clear();
            Dg_list.DataSource = registros;
            Dg_list.DataTextField = dato;
            Dg_list.DataValueField = value;
            Dg_list.DataBind();
        }

        public void Carga_CHListBox(object sender, OracleDataReader registros, string dato, string regcalle)
        {
            System.Web.UI.WebControls.CheckBoxList CHB_list = (System.Web.UI.WebControls.CheckBoxList)(sender);
            CHB_list.Items.Clear();
            CHB_list.DataSource = registros;
            CHB_list.DataTextField = dato;
            CHB_list.DataValueField = regcalle;
            CHB_list.DataBind();
        }

        
        

     //procedimientos para cargar datos desde un archivo xml
        public void Carga_ComboXML(object sender, string ruta, string dato, string value)
        {
            System.Web.UI.WebControls.DropDownList Dg_list = (System.Web.UI.WebControls.DropDownList)(sender);
            Dg_list.Items.Clear();
            DataSet ds5 = new DataSet();
            ds5.ReadXml(ruta);
            Dg_list.DataSource = ds5;
            Dg_list.DataTextField =  dato;
            Dg_list.DataValueField = value;
            Dg_list.DataBind();
        }

        public void Carga_ComboXMLhijo(object sender,string rutaxml,  string atribdato, string atribvalue,string padreselec,string nodop,string nodoh)
        {//recorriendo nodos hijos y agregandolos a una tabla para asignar al combo
            DataTable dtmun = new DataTable(); //creas una tabla
            dtmun.Columns.Add(atribdato); //le creas las columnas de la tabla temporal dtmun
            dtmun.Columns.Add(atribvalue);
            //se crean las variables temporales donde guardaremos los valores de los atributos de cada uno de los nodos que se van recorriendo del arbol
            string tmp_nombrexml = "";
            string tmp_valorxml = "";
            //cargamos el xml
            string xml = rutaxml;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xml);
            XmlNodeList regionales = xDoc.GetElementsByTagName(nodop);//se obtiene la lista de los nodos padre (nodop)
            int n = 0;
            while (n <= regionales.Count)
            {
                // se toma el nombre del nodo padre en que esta posicionado para ver si es igual al que se selecciono "padreselec"
                string nodopadresel = ((XmlElement)regionales[n]).Attributes[atribdato].Value.ToString();
                if (nodopadresel == padreselec)//verificamos si el nodo en el que esta(nodop) es igual al que seleccionaron
                {
                    //se obtiene la lista de los nodos hijos "nodoh"
                    XmlNodeList lista = ((XmlElement)regionales[n]).GetElementsByTagName(nodoh); 
                    if (lista.Count >= 1)
                    {
                        //recorremos todos los nodos hijos(nodoh) del nodo padre (nodop) y tomamos los atributos (atribdato,atribvalue) para guardarlos en una tabla
                        foreach (XmlElement nodo in lista)
                        {
                            int i = 0;
                            DataRow drxml = dtmun.NewRow();
                            tmp_nombrexml = nodo.Attributes[atribdato].Value.ToString();
                            tmp_valorxml = nodo.Attributes[atribvalue].Value.ToString();
                            drxml[atribdato] = tmp_nombrexml;
                            drxml[atribvalue] = tmp_valorxml;
                            dtmun.Rows.Add(drxml);
                        }
                    }
                    //n = regionales.Count;
                    break;//nos salimos una ves que llegamos al nodo padre(nodop) que se habia seleccionado en "padreselec" 
                }
                else { n++; }

            }//fin del primer foreach
            //cargamos los datos en el combo que guardamos en la tabla dtmun
            System.Web.UI.WebControls.DropDownList Dg_list = (System.Web.UI.WebControls.DropDownList)(sender);
            Dg_list.Items.Clear();
            Dg_list.DataSource = dtmun;
            Dg_list.DataTextField = atribdato;
            Dg_list.DataValueField = atribvalue;
            Dg_list.DataBind();
        }

        public void Carga_ComboXMLhijos(object sender, string rutaxml, string atribdato, string atribvalue, string padreselec, string nodop, string nodoh)
        {//recorriendo nodos hijos y se agregan al combo
            //se crean las variables temporales donde guardaremos los valores de los atributos de cada uno de los nodos que se van recorriendo del arbol
            string tmp_nombrexml = "";
            string tmp_valorxml = "";
            System.Web.UI.WebControls.DropDownList Dg_list = (System.Web.UI.WebControls.DropDownList)(sender);
            Dg_list.Items.Clear();
            //cargamos el xml
            string xml = rutaxml;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xml);
            XmlNodeList regionales = xDoc.GetElementsByTagName(nodop);//se obtiene la lista de los nodos padre (nodop)
            int n = 0;
            while (n <= regionales.Count)
            {
                // se toma el nombre del nodo padre en que esta posicionado para ver si es igual al que se selecciono "padreselec"
                string nodopadresel = ((XmlElement)regionales[n]).Attributes[atribdato].Value.ToString();
                if (nodopadresel == padreselec)//verificamos si el nodo en el que esta es igual al que seleccionaron
                {
                    //se obtiene la lista de los nodos hijos "nodoh"
                    XmlNodeList lista = ((XmlElement)regionales[n]).GetElementsByTagName(nodoh);
                    if (lista.Count >= 1)
                    {
                        int i = 0;
                        //recorremos todos los nodos hijos(nodoh) del nodo padre (nodop) y tomamos los atributos (atribdato,atribvalue) para insertarlos
                        foreach (XmlElement nodo in lista)
                        {
                            tmp_nombrexml = nodo.Attributes[atribvalue].Value.ToString() +" - "+ nodo.Attributes[atribdato].Value.ToString();
                            tmp_valorxml = nodo.Attributes[atribvalue].Value.ToString();
                            Dg_list.Items.Insert(i, new ListItem(tmp_nombrexml, tmp_valorxml));
                            i++;
                        }
                    }
                    break;//nos salimos una ves que llegamos al nodo padre(nodop) que se habia seleccionado en "padreselec" 
                }
                else { n++; }
            }//fin del primer foreach
        }


        //public GridViewRow InsertarEncabezadoGrid2(string ordencol,string nombrecamposcol,string tamañocolspan,string ordenrow, string nombrecamoposrow, string tamañorowspan)
        //{
        //    GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //    
        //    //Spliteamos los nombres de los campos con colspan
        //    int ncol = 0;
        //    string lines = nombrecamposcol;
        //    if ( (lines != null) && (lines !="") )
        //    {
        //        string[] cols = lines.Split(',');
        //        string[] tamcol = tamañocolspan.Split(',');
        //        foreach (string colum in cols)
        //        {
        //            TableCell oTableCell = new TableCell();
        //            //Add Datos de usuario
        //            oTableCell.Text = colum;
        //            oTableCell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
        //            if ((tamañocolspan != null) && (tamañocolspan != ""))
        //            {
        //                oTableCell.ColumnSpan = Int32.Parse(tamcol[ncol]);
        //            }
        //            oGridViewRow.Cells.Add(oTableCell);//cargamos la tabla al gridview
        //            ncol++;
        //        }
        //    }
        //    //Spliteamos los nombres de los campos con rowspan
        //    int nrow = 0;
        //    string linesr = nombrecamoposrow;
        //    if ((linesr != null) && (linesr != ""))
        //    {
        //        string[] colsr = linesr.Split(',');
        //        string[] tamrow = tamañorowspan.Split(',');
        //        foreach (string columr in colsr)
        //        {
        //            TableCell oTableCell = new TableCell();
        //            //Add Datos de usuario
        //            oTableCell.Text = columr;
        //            oTableCell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
        //            if ((tamañorowspan != null) && (tamañorowspan != ""))
        //            {
        //                oTableCell.RowSpan = Int32.Parse(tamrow[nrow]);
        //            }
        //            oGridViewRow.Cells.Add(oTableCell);//cargamos la tabla al gridview
        //            nrow++;
        //        }
        //    }
            
        //    return oGridViewRow;
        //}

        public GridViewRow InsertarEncabezadoGrid(string tipocolumnas, string nombrecolumnas, string tamañocolumnas, string combinados)
        {
            //cadema tipocolumnas: 0 sin cambio,1 aplicar colspan a la columna,2 aplicar rowspan a la columna,3 aplicar colspan y rowspan ("0,1,2,3")
            //cadena nombrecolumnas: nombres de las columnas que se agregaran al header ("columna 1, columna 2,columna 3")
            //cadena tamañocolumnas: tamaño de colspan o rowspan que se le aplicaria a la columna segun el tipo especificado("1,2,3") NOTA:si el campo no tiene colspan ni rowsapn se puede dejar en vacio
            //cadena combinados: tamaño de colspan y rowspan para la columna de tipo 3 ("2,2") NOTA: los datos van en pares por cada columna
            GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            string campos = nombrecolumnas;
            //revisamos que no venga en nulo el string con los nombres de columnas
            int ncol = 0;
            int ncomb = 0;
            if ((campos != null) && (campos != ""))
            {
                //spliteamos los nombres de columnas, los tamaños y tipo (0 sin cambio,1 colspan,2 rowspan)
                string[] cols = nombrecolumnas.Split(',');
                string[] tamcol = tamañocolumnas.Split(',');
                string[] tipcol = tipocolumnas.Split(',');
                string[] tcombi = combinados.Split(',');
                foreach (string colum in cols)
                {
                    TableCell oTableCell = new TableCell();
                    //Add Datos de usuario
                    oTableCell.Text = colum;
                    oTableCell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                    oTableCell.ID = colum; ;
                    switch (tipcol[ncol])
                    {
                        case "1":
                            {
                                oTableCell.ColumnSpan = Int32.Parse(tamcol[ncol]);
                                break;
                            }
                        case "2":
                            {
                                oTableCell.RowSpan = Int32.Parse(tamcol[ncol]);
                                break;
                            }
                        case "3":
                            {
                                oTableCell.ColumnSpan = Int32.Parse(tcombi[ncomb]);
                                oTableCell.RowSpan = Int32.Parse(tcombi[ncomb + 1]);
                                ncomb++;
                                break;
                            }
                    }
                    oGridViewRow.Cells.Add(oTableCell);//cargamos la tabla al gridview
                    ncol++;
                }
            }

            return oGridViewRow;
        }

        #region Navegación entre los UPC's
        /// <summary>
        /// Este código generá un string el cual será utilizado como arreglo para identificar 
        /// el número de productos en la tienda, el upc actual, el 
        /// upc inicial, anterior, siguiente y el ultimo que serven para implementar la navegación
        /// </summary>
        public string Navegar(string upc)
        {
            DataTable tbl = RecuperaQuery("Select upc, ltrim(desc_titulo) as desc_titulo From Productos Where substring(disponibilidad,3,1)='1' Order by 2");
            int reg = tbl.Rows.Count;
            int num = tbl.Rows.Count - 1;
            if (upc == null || upc == "" || upc == "0") upc = tbl.Rows[0]["upc"].ToString();
            string p = tbl.Rows[0]["upc"].ToString();
            string a = tbl.Rows[0]["upc"].ToString();
            string s = tbl.Rows[num]["upc"].ToString();
            string u = tbl.Rows[num]["upc"].ToString();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (upc == tbl.Rows[i]["upc"].ToString())
                {
                    if (i != 0 && i != num)
                    {
                        a = tbl.Rows[i - 1]["upc"].ToString();
                        s = tbl.Rows[i + 1]["upc"].ToString();
                    }
                    else
                    {
                        if (i == 0)
                            s = tbl.Rows[1]["upc"].ToString();
                        else
                            a = tbl.Rows[num - 1]["upc"].ToString();
                    }
                    break;
                }
            }
            return reg.ToString() + "," + upc + "," + p + "," + a + "," + s + "," + u;
        }
        #endregion

        //public void cargapdf(string nombre)
        //{
        //    string ruta = @"\\nas-inegi.inegi.gob.mx\enc_intercensal_2015_PruebaIntegral2014_CAPTURA\Contenedor\";
        //    string miarch = "";
        //    NAS nas = new NAS();
        //    bool impersonate = nas.ImpersonateValidUser(
        //    "CEN.GPO.SISEG", 
        //    "b5&Iy8rMn",
        //    "INEGI"
        //    );
        //    try
        //    {
        //        miarch = ruta + nombre;
        //        if (File.Exists(miarch))
        //        {
        //            Response.Clear();
        //            Response.ClearContent();
        //            Response.ClearHeaders();
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + nombre);
        //            Response.ContentType = "application/exe";
        //            Response.TransmitFile(miarch);
        //            Response.End();
        //        }
        //    }
        //    catch (WebException wex)
        //    {
        //        wex.Message.ToString();
        //    }
        //    nas.UndoImpersonation();
        //}
    }
}


