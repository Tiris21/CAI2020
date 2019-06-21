using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Xml;

namespace Cai2020
{
    public partial class CuestionarioPersona : System.Web.UI.Page
    {
        //public static int cuenta;
        //public static int actual;
        //public static int p1;
        //public static int p2;
        //public static string nombre;
        public static bool check = false;
        private bool isEditMode = false;
        public static int[] regreso = new int[21];
        protected bool IsInEditMode
        {

            get { return this.isEditMode; }

            set { this.isEditMode = value; }

        }
        #region web Services GetContent
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent2(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string GetContent3(string contextKey)
        {
            //return "<strong>" + contextKey + "</strong>";
            return "";
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int op = 0;
            GetSelectedRecord();
            //if (HttpContext.Current.Session["testigo"].ToString() == "1")
            //{
            //    Response.Redirect("Index.aspx");
            //}
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["testigo"].ToString() == "1")
                {
                    Response.Redirect("Index.aspx");
                }
                if (HttpContext.Current.Session["qr_viv"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ExpiresAbsolute = DateTime.Now.AddMonths(-1);
                //HttpContext.Current.Session["mio"] = "0";
                int j = 0;
                foreach (int i in regreso)
                {
                    regreso[j] = 0;
                    j++;
                }
                HttpContext.Current.Session["cuenta"] = "0";
                HttpContext.Current.Session["actual"] = "0";
                HttpContext.Current.Session["p1"] = "0";
                HttpContext.Current.Session["p2"] = "0";
                string oradb = ConfigurationManager.AppSettings["cai2020"];
                OracleConnection conn = new OracleConnection(); // C#
                conn.ConnectionString = oradb.ToString();
                int p = 0;
                try
                {
                    System.Data.DataTable table = new DataTable("ParentTable");
                    // Declare variables for DataColumn and DataRow objects.
                    DataColumn column;
                    DataRow row;
                    // Create new DataColumn, set DataType, 
                    // ColumnName and add to DataTable. 
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "CUENTA";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "NOMBRE";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "SEXO";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "EDAD";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "PARENTESCO";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    // Make the ID column the primary key column.
                    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                    PrimaryKeyColumns[0] = table.Columns["id"];
                    table.PrimaryKey = PrimaryKeyColumns;
                    // Instantiate the DataSet variable.
                    DataSet dataSet = new DataSet();
                    //Add the new DataTable to the DataSet.
                    dataSet.Tables.Add(table);
                    conn.Open();
                    //EVALUAR SI YA SE TIENEN REGISTROS GUARDADOS LA LISTA
                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = conn;
                    OracleParameter myParam3 = cmd3.CreateParameter();
                    myParam3.OracleDbType = OracleDbType.NVarchar2;
                    myParam3.Value = HttpContext.Current.Session["qr_viv"].ToString();
                    myParam3.ParameterName = "qr";
                    cmd3.Parameters.Add(myParam3);
                    cmd3.CommandText = "SELECT QR_VIV,NUMPER,NOMBRE,SEXO,EDAD,PARENT,PARENT_OTRO,ENT_NAC_AQUI,ENT_NAC_OTRO,ENT_NAC_USA,ENT_NAC_PAIS,DHSERSAL1,DHSERSAL2,RELIGION,AFRODES,HLENGUA,QDIALECT,HESPANOL,ASISTEN,ESCOLARI,NIVACAD,ALFABET,ENT_RESI12_AQUI,ENT_RESI12_OTRO,ENT_RESI12_USA,ENT_RESI12_PAIS,SITUA_CONYUGAL,TRABAJO,ACTIVIDADES_EA,ACTIVIDADES_EI FROM CAP_INT_TR_PERSONA where QR_VIV = :qr order by NUMPER";
                    cmd3.CommandType = CommandType.Text;
                    OracleDataReader dr3 = cmd3.ExecuteReader();
                    while (dr3.Read())
                    {
                        if (string.IsNullOrEmpty(dr3["ENT_NAC_AQUI"].ToString()) && string.IsNullOrEmpty(dr3["ENT_NAC_OTRO"].ToString()) && string.IsNullOrEmpty(dr3["ENT_NAC_USA"].ToString()) && string.IsNullOrEmpty(dr3["ENT_NAC_PAIS"].ToString()) && string.IsNullOrEmpty(dr3["DHSERSAL1"].ToString()) && string.IsNullOrEmpty(dr3["DHSERSAL2"].ToString()) && string.IsNullOrEmpty(dr3["RELIGION"].ToString()) && string.IsNullOrEmpty(dr3["AFRODES"].ToString()) && string.IsNullOrEmpty(dr3["HLENGUA"].ToString()) && string.IsNullOrEmpty(dr3["QDIALECT"].ToString()) && string.IsNullOrEmpty(dr3["HESPANOL"].ToString()) && string.IsNullOrEmpty(dr3["ASISTEN"].ToString()) && string.IsNullOrEmpty(dr3["ESCOLARI"].ToString()) && string.IsNullOrEmpty(dr3["NIVACAD"].ToString()) && string.IsNullOrEmpty(dr3["ALFABET"].ToString()) && string.IsNullOrEmpty(dr3["ENT_RESI12_AQUI"].ToString()) && string.IsNullOrEmpty(dr3["ENT_RESI12_OTRO"].ToString()) && string.IsNullOrEmpty(dr3["ENT_RESI12_USA"].ToString()) && string.IsNullOrEmpty(dr3["ENT_RESI12_PAIS"].ToString()) && string.IsNullOrEmpty(dr3["SITUA_CONYUGAL"].ToString()) && string.IsNullOrEmpty(dr3["TRABAJO"].ToString()) && string.IsNullOrEmpty(dr3["ACTIVIDADES_EA"].ToString()) && string.IsNullOrEmpty(dr3["ACTIVIDADES_EI"].ToString()))
                        {
                            row = table.NewRow();
                            row["CUENTA"] = dr3["NUMPER"].ToString();
                            row["NOMBRE"] = dr3["NOMBRE"].ToString();
                            if (dr3["SEXO"].ToString() == "1")
                            {
                                row["SEXO"] = "Hombre";
                            }
                            else if (dr3["SEXO"].ToString() == "3")
                            {
                                row["SEXO"] = "Mujer";
                            }
                            row["EDAD"] = dr3["EDAD"].ToString();
                            if (dr3["PARENT"].ToString() == "1")
                            {
                                row["PARENTESCO"] = "Jefa(e)";
                            }
                            else if (dr3["PARENT"].ToString() == "2")
                            {
                                row["PARENTESCO"] = "Esposa(o) o pareja";
                            }
                            else if (dr3["PARENT"].ToString() == "3")
                            {
                                row["PARENTESCO"] = "Hija(o)";
                            }
                            else if (dr3["PARENT"].ToString() == "4")
                            {
                                row["PARENTESCO"] = "Nieta(o)";
                            }
                            else if (dr3["PARENT"].ToString() == "5")
                            {
                                row["PARENTESCO"] = "Nuera o yerno";
                            }
                            else if (dr3["PARENT"].ToString() == "6")
                            {
                                row["PARENTESCO"] = "Madre o padre";
                            }
                            else if (dr3["PARENT"].ToString() == "7")
                            {
                                row["PARENTESCO"] = "Suegra (o)";
                            }
                            else if (dr3["PARENT"].ToString() == "8")
                            {
                                row["PARENTESCO"] = dr3["PARENT_OTRO"].ToString();
                            }
                            table.Rows.Add(row);
                            p++;
                        }
                    }
                    Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                    Gvresulta.DataBind();
                    dr3.Dispose();
                    cmd3.Dispose();
                    //EMPIEZA LA CONDICIÓN
                    if (p != 0)
                    {
                        ayuda01.Attributes["data-content"] = leer_xml(4);
                        //string hola = Gvresulta.Rows[0].Cells[1].Text + " " + p.ToString() + " " + Gvresulta.Rows[0].Cells[0].Text; ;.
                        OracleCommand cmd4 = new OracleCommand();
                        cmd4.Connection = conn;
                        OracleParameter myParam4 = cmd4.CreateParameter();
                        myParam4.OracleDbType = OracleDbType.NVarchar2;
                        myParam4.Value = HttpContext.Current.Session["qr_viv"].ToString();
                        myParam4.ParameterName = "qr";
                        cmd4.Parameters.Add(myParam4);
                        cmd4.CommandText = "SELECT NUMPERS, VERLIST, NUMINF, NINOS_VIV, NINOS_VIV_CUANTOS, VERNINOS from CAP_INT_TR_VIVIENDA where QR_VIV = :qr";
                        cmd4.CommandType = CommandType.Text;
                        OracleDataReader dr4 = cmd4.ExecuteReader();
                        if (dr4.Read())
                        {
                            if (string.IsNullOrEmpty(dr4["NUMPERS"].ToString()) && string.IsNullOrEmpty(dr4["VERLIST"].ToString()) && string.IsNullOrEmpty(dr4["NUMINF"].ToString()) && string.IsNullOrEmpty(dr4["NINOS_VIV"].ToString()) && string.IsNullOrEmpty(dr4["NINOS_VIV_CUANTOS"].ToString()) && string.IsNullOrEmpty(dr4["VERNINOS"].ToString()))
                            {
                                Avance_barra2(4);
                                int actual = 0;
                                HttpContext.Current.Session["actual"] = actual.ToString();
                                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                                System.Data.DataTable table1 = new DataTable("ParentTable");
                                // Declare variables for DataColumn and DataRow objects.
                                DataColumn column1;
                                DataRow row1;
                                // Create new DataColumn, set DataType, 
                                // ColumnName and add to DataTable. 
                                column1 = new DataColumn();
                                column1.DataType = System.Type.GetType("System.String");
                                column1.ColumnName = "CUENTA";
                                column1.ReadOnly = false;
                                column1.Unique = false;
                                // Add the Column to the DataColumnCollection.
                                table1.Columns.Add(column1);
                                column1 = new DataColumn();
                                column1.DataType = System.Type.GetType("System.String");
                                column1.ColumnName = "NOMBRE";
                                column1.ReadOnly = false;
                                column1.Unique = false;
                                // Add the Column to the DataColumnCollection.
                                table1.Columns.Add(column1);
                                column1 = new DataColumn();
                                column1.DataType = System.Type.GetType("System.String");
                                column1.ColumnName = "SEXO";
                                column1.ReadOnly = false;
                                column1.Unique = false;
                                // Add the Column to the DataColumnCollection.
                                table1.Columns.Add(column1);
                                column1 = new DataColumn();
                                column1.DataType = System.Type.GetType("System.String");
                                column1.ColumnName = "EDAD";
                                column1.ReadOnly = false;
                                column1.Unique = false;
                                // Add the Column to the DataColumnCollection.
                                table1.Columns.Add(column1);
                                column1 = new DataColumn();
                                column1.DataType = System.Type.GetType("System.String");
                                column1.ColumnName = "PARENTESCO";
                                column1.ReadOnly = false;
                                column1.Unique = false;
                                // Add the Column to the DataColumnCollection.
                                table1.Columns.Add(column1);
                                // Make the ID column the primary key column.
                                DataColumn[] PrimaryKeyColumns1 = new DataColumn[1];
                                PrimaryKeyColumns1[0] = table1.Columns["id"];
                                table1.PrimaryKey = PrimaryKeyColumns1;
                                // Instantiate the DataSet variable.
                                DataSet dataSet1 = new DataSet();
                                //Add the new DataTable to the DataSet.
                                dataSet1.Tables.Add(table1);
                                int i = 0;
                                for (i = 0; i < Gvresulta.Rows.Count; i++)
                                {
                                    row1 = table1.NewRow();
                                    row1["CUENTA"] = Gvresulta.Rows[i].Cells[0].Text;//j.ToString();
                                    row1["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                                    row1["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                                    row1["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                                    row1["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                                    table1.Rows.Add(row1);
                                }
                                GridView1.DataSource = dataSet1.Tables["ParentTable"];
                                GridView1.DataBind();
                                cierracom2(Page);
                                cierracom3a(Page);
                                cierracom4(Page);
                                cierracom4p(Page);
                                cierracom5(Page);
                                abrecom2(Page);
                                abrecom5b(Page);
                            }
                            else
                            {
                                int actual = 0;
                                HttpContext.Current.Session["actual"] = actual.ToString();
                                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                                //Guardar(4, 0);
                                ayuda01a.Attributes["data-content"] = leer_xml(7);
                                HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                                lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                                lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                abrecom4q6(Page);
                                cierracom2(Page);
                                cierracom3a(Page);
                                cierracom4(Page);
                                cierracom4p(Page);
                                cierracom5(Page);
                                int cuenta = 1;
                                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                                int p1 = 1;
                                HttpContext.Current.Session["p1"] = p1.ToString();
                                actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                                int p2 = 1;
                                HttpContext.Current.Session["p2"] = p2.ToString();
                                actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                                Avance_barra(1);
                            }
                        }
                        else
                        {
                            Response.Redirect("CuestionarioVivienda.aspx");
                        }
                        dr4.Dispose();
                        cmd4.Dispose();
                    }
                    else
                    {
                        abrecom4q5(Page);
                    }
                }
                catch (Exception e1)
                {
                    HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                }
                finally
                {
                    conn.Dispose();
                }
                ////agregar01a.Visible = false;
                ////abrecom2(Page);
                ////abrecom3(Page);
                //abrecom4q5(Page);
                //////abrecom3a(Page);
                //////abrecom4(Page);
                //////abrecom5(Page);
                ////////abrecom5a(Page);
                //////Solo iba esto
                ////Image1.ImageUrl = "Images/Cortinilla2.JPG";
                ////programmaticModalPopup2.Show();
                //////hasta aquí
                ////tb_IIe24.Visible = false;
                ////tb_IIe11.Focus();
                ////tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                ////DropDownList1.Items.Add("Seleccione...");
                ////DropDownList1.Items.Add("Esposa(o) o pareja");
                ////DropDownList1.Items.Add("Hija(o)");
                ////DropDownList1.Items.Add("Nieta(o)");
                ////DropDownList1.Items.Add("Nuera o yerno");
                ////DropDownList1.Items.Add("Madre o padre");
                ////DropDownList1.Items.Add("Suegra (o)");
                //////DropDownList1.Items.Add("Sin parentesco");
                ////DropDownList1.Items.Add("Otro(especifique)");
                ////System.Data.DataTable table = new DataTable("ParentTable");
                ////// Declare variables for DataColumn and DataRow objects.
                ////DataColumn column;
                ////DataRow row;
                ////// Create new DataColumn, set DataType, 
                ////// ColumnName and add to DataTable. 
                ////column = new DataColumn();
                ////column.DataType = System.Type.GetType("System.String");
                ////column.ColumnName = "CUENTA";
                ////column.ReadOnly = false;
                ////column.Unique = false;
                ////// Add the Column to the DataColumnCollection.
                ////table.Columns.Add(column);
                ////column = new DataColumn();
                ////column.DataType = System.Type.GetType("System.String");
                ////column.ColumnName = "NOMBRE";
                ////column.ReadOnly = false;
                ////column.Unique = false;
                ////// Add the Column to the DataColumnCollection.
                ////table.Columns.Add(column);
                ////column = new DataColumn();
                ////column.DataType = System.Type.GetType("System.String");
                ////column.ColumnName = "SEXO";
                ////column.ReadOnly = false;
                ////column.Unique = false;
                ////// Add the Column to the DataColumnCollection.
                ////table.Columns.Add(column);
                ////column = new DataColumn();
                ////column.DataType = System.Type.GetType("System.String");
                ////column.ColumnName = "EDAD";
                ////column.ReadOnly = false;
                ////column.Unique = false;
                ////// Add the Column to the DataColumnCollection.
                ////table.Columns.Add(column);
                ////column = new DataColumn();
                ////column.DataType = System.Type.GetType("System.String");
                ////column.ColumnName = "PARENTESCO";
                ////column.ReadOnly = false;
                ////column.Unique = false;
                ////// Add the Column to the DataColumnCollection.
                ////table.Columns.Add(column);

                ////// Make the ID column the primary key column.
                ////DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                ////PrimaryKeyColumns[0] = table.Columns["id"];
                ////table.PrimaryKey = PrimaryKeyColumns;
                ////// Instantiate the DataSet variable.
                ////DataSet dataSet = new DataSet();
                //////Add the new DataTable to the DataSet.
                ////dataSet.Tables.Add(table);


                ////Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                ////Gvresulta.DataBind();
                ////row = table.NewRow();
                ////row["CUENTA"] = "1";//Gvresulta.Rows[i].Cells[0].Text;
                ////row["NOMBRE"] = "";
                ////row["SEXO"] = "";
                ////row["EDAD"] = "";
                ////row["PARENTESCO"] = "Titular";
                ////table.Rows.Add(row);
                ////gv1.DataSource = dataSet.Tables["ParentTable"];
                ////gv1.DataBind();
                ////ayuda01.Attributes["data-content"] = leer_xml(Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString()));
                ////Avance_barra(0);
                //////if (HttpContext.Current.Session["mio"].ToString() == "1")
                //////{
                //////    cierracom2(Page);
                //////    cierracom3(Page);
                //////    abrecom2(Page);
                //////    abrecom3(Page);
                //////    tb_IIe24.Visible = false;
                //////    tb_IIe11.Focus();
                //////    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                //////    HttpContext.Current.Session["mio"] = "1";
                //////}
                //////else
                //////{
                //////    cierracom2(Page);
                //////    cierracom3(Page);
                ////}
            }
            else
            {
                op = 1;
            }
            //if (radioB9.Checked == true && op ==1)
            //{
            //    abrecom2(Page);
            //    abrecom3(Page);
            //    //abrecom4(Page);
            //    //abrecom5(Page);
            //    ////abrecom5a(Page);
            //    tb_IIe21.BackColor = System.Drawing.Color.White;
            //    tb_IIe24.Visible = true;
            //    tb_IIe24.Focus();
            //    tb_IIe24.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            //else if (radioB9.Checked == false && op == 1)
            //{
            //    abrecom2(Page);
            //    abrecom3(Page);
            //    //abrecom4(Page);
            //    //abrecom5(Page);
            //    ////abrecom5a(Page);
            //    tb_IIe24.Text = "";
            //    tb_IIe24.Visible = false;
            //    tb_IIe24.BackColor = System.Drawing.Color.White;
            //    tb_IIe21.Focus();
            //    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
        }

        protected void Transfer_(string url)
        {
            foreach (string key_ in ViewState.Keys)
            {
                if (Session[key_] == null)
                {
                    Session.Add(key_, ViewState[key_]);
                }
                else
                    Session[key_] = ViewState[key_];
            }

            Server.Transfer(url);
        }

        void Avance_barra(int inicio)
        {
            double porcentaje = 0;
            int total_per = Gvresulta.Rows.Count;
            int total_preg = 15;

            //if (cuenta == 9 || cuenta == 18 || cuenta == 27 || cuenta == 36 || cuenta == 45)
            //{ ++persona_actual; }
            //cuenta = Int32.Parse(Session["pregunta_act"].ToString()) + 1;
            porcentaje = Math.Round((1.0 / total_per) * 100, 2);
            porcentaje = (porcentaje) * (Convert.ToInt32(HttpContext.Current.Session["p2"].ToString())); //5 = (1 / int total_preg)*100
            barra_tot.Attributes["aria-valuenow"] = porcentaje.ToString();
            barra_tot.Attributes["style"] = "width:" + porcentaje + "%";
            avance_tot.Text = "Persona: " + (Convert.ToInt32(HttpContext.Current.Session["p2"].ToString())) + " de " + total_per;
            
            //if (porcentaje >= 100)
            //{
            //    barra_tot.InnerHtml = "Ultima!";
            //}
            //else
            //{
            //    barra_tot.InnerHtml = "";
            //}

            //barra de avance de las preguntas de cada persona
            porcentaje = Math.Round((1.0 / total_preg) * 100, 2);
            porcentaje = (porcentaje) * (Convert.ToInt32(HttpContext.Current.Session["p1"].ToString())); //5 = (1 / int total_preg)*100
            barra.Attributes["aria-valuenow"] = porcentaje.ToString();
            barra.Attributes["style"] = "width:" + porcentaje + "%";
            avance.Text = "Pregunta: " + (Convert.ToInt32(HttpContext.Current.Session["p1"].ToString())) + " de " + total_preg;
            
            //if (porcentaje >= 100)
            //{
            //    barra.InnerHtml = "Ultima!";
            //}
            //else
            //{
            //    barra.InnerHtml = "";
            //}


        }
        void Avance_barra2(int inicio)
        {
            double porcentaje = 0;
            int total_preg = 6;

            //barra de avance de las preguntas de cada persona
            porcentaje = Math.Round((1.0 / total_preg) * 100, 2);
            porcentaje = (porcentaje) * (Convert.ToInt32(inicio)); //5 = (1 / int total_preg)*100
            barra1.Attributes["aria-valuenow"] = porcentaje.ToString();
            barra1.Attributes["style"] = "width:" + porcentaje + "%";
            avance1.Text = "Paso: " + (Convert.ToInt32(inicio)) + " de " + total_preg;

            //if (porcentaje >= 100)
            //{
            //    barra.InnerHtml = "Ultima!";
            //}
            //else
            //{
            //    barra.InnerHtml = "";
            //}


        }

        void Avance_barra3(int inicio)
        {
            double porcentaje = 0;
            int total_preg = 6;

            //barra de avance de las preguntas de cada persona
            porcentaje = Math.Round((1.0 / total_preg) * 100, 2);
            porcentaje = (porcentaje) * (Convert.ToInt32(inicio)); //5 = (1 / int total_preg)*100
            Div33.Attributes["aria-valuenow"] = porcentaje.ToString();
            Div33.Attributes["style"] = "width:" + porcentaje + "%";
            Label6.Text = "Paso: " + (Convert.ToInt32(inicio)) + " de " + total_preg;

            //if (porcentaje >= 100)
            //{
            //    barra.InnerHtml = "Ultima!";
            //}
            //else
            //{
            //    barra.InnerHtml = "";
            //}


        }

        void Avance_barra4(int inicio)
        {
            double porcentaje = 0;
            int total_preg = 6;

            //barra de avance de las preguntas de cada persona
            porcentaje = Math.Round((1.0 / total_preg) * 100, 2);
            porcentaje = (porcentaje) * (Convert.ToInt32(inicio)); //5 = (1 / int total_preg)*100
            Div35.Attributes["aria-valuenow"] = porcentaje.ToString();
            Div35.Attributes["style"] = "width:" + porcentaje + "%";
            Label43.Text = "Paso: " + (Convert.ToInt32(inicio)) + " de " + total_preg;

            //if (porcentaje >= 100)
            //{
            //    barra.InnerHtml = "Ultima!";
            //}
            //else
            //{
            //    barra.InnerHtml = "";
            //}


        }

        protected string leer_xml(int numAyuda)
        {
            string txtAyuda = "";//"<div><b>Ejemplo usando un div interno</b> - content</div>";
            //XmlTextReader reader = new XmlTextReader("ayudas.xml");
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(MapPath("~/App_data/ayudasp.xml"));

                XmlNodeList xAyudas = xDoc.GetElementsByTagName("Ayudas");
                XmlNodeList xLista = ((XmlElement)xAyudas[0]).GetElementsByTagName("ayuda");

                foreach (XmlElement nodo in xLista)
                {
                    if (Int32.Parse(nodo.GetAttribute("id")) == numAyuda)
                    {
                        //txtAyuda = nodo.GetAttribute("descrip");
                        txtAyuda = nodo.InnerText;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string r = ex.ToString();
            }
            return txtAyuda;
        }

       

        protected void gv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            isEditMode = true;
        }

        protected void gv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            isEditMode = false;
            gv1.EditIndex = -1;
            gv1.DataBind();

        }

        protected void gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //foreach (GridViewRow row in gv1.Rows)
            //      { 

            //      } 

            for (int i = 0; i <= gv1.Rows.Count - 1; i++)
            {
                int sno = Convert.ToInt32(gv1.Rows[i].Cells[1].Text);

                String pram = ((TextBox)gv1.Rows[i].FindControl("Textbox2")).Text;
                String unit = ((TextBox)gv1.Rows[i].FindControl("Textbox20")).Text;
                String spval = ((TextBox)gv1.Rows[i].FindControl("Textbox3")).Text;
                String torval = ((TextBox)gv1.Rows[i].FindControl("Textbox6")).Text;
                //String obtval = ((TextBox)gv1.Rows[i].FindControl("Textbox5")).Text;

            }

        }




        protected void ImageButton3_Command(object sender, CommandEventArgs e)
        {
            ImageButton ibLink = (ImageButton)sender;
            string sLine = "";
            ArrayList cadena1 = new ArrayList();
            sLine = ibLink.CommandArgument.ToString();
            char[] delimiterChars = { '@' };
            string text = sLine.ToString();
            string[] words = text.Split(delimiterChars);
            foreach (string s in words)
            {
                cadena1.Add(s.Trim());
            }
            string slClienteID = cadena1[1].ToString();
            string slID = cadena1[0].ToString();
            string tipo = cadena1[2].ToString();
            if (slID == "1")
            {
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4q(Page);
            }
            else
            {
                //Leer el grid_view y filtrar el dato que se eligio con el botón y no incluirlo, crear secuencialmente la tabla y asignarla al gridview
                System.Data.DataTable table = new DataTable("ParentTable");
                // Declare variables for DataColumn and DataRow objects.
                DataColumn column;
                DataRow row;
                // Create new DataColumn, set DataType, 
                // ColumnName and add to DataTable. 
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUENTA";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NOMBRE";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SEXO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "EDAD";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PARENTESCO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = table.Columns["id"];
                table.PrimaryKey = PrimaryKeyColumns;
                // Instantiate the DataSet variable.
                DataSet dataSet = new DataSet();
                //Add the new DataTable to the DataSet.
                dataSet.Tables.Add(table);

                int i, j = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    if (Gvresulta.Rows[i].Cells[0].Text != slID.ToString())
                    {
                        j++;
                        row = table.NewRow();
                        row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        table.Rows.Add(row);
                    }
                }
                Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                Gvresulta.DataBind();
                cadena1.Clear();
                abrecom2(Page);
                abrecom3a(Page);
                abrecom5(Page);
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        protected void ImageButton4_Command(object sender, CommandEventArgs e)
        {
            //if (tb_IIe11.Text == "")
            //{
            //    tb_IIe11.Text = "0";
            //}
            //if (Convert.ToInt16(tb_IIe11.Text) <= Gvresulta.Rows.Count)
            //{
            //    //tb_IIe11.BackColor = System.Drawing.Color.White;
            //    tb_IIe11.Focus();
            //    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            //    mensaje(Page, "La cantidad de personas registradas debe de ser igual al número de las personas que viven aquí");
            //}
            //else
            //{
                //ImageButton ibLink = (ImageButton)sender;
                //string sLine = "";
                //ArrayList cadena1 = new ArrayList();
                //sLine = ibLink.CommandArgument.ToString();
                //char[] delimiterChars = { '@' };
                //string text = sLine.ToString();
                //string[] words = text.Split(delimiterChars);
                //foreach (string s in words)
                //{
                //    cadena1.Add(s.Trim());
                //}
                //string slClienteID = cadena1[1].ToString();
                //string slID = cadena1[0].ToString();
                //string tipo = cadena1[2].ToString();
                ////Leer el grid_view y filtrar el dato que se eligio con el botón y no incluirlo, crear secuencialmente la tabla y asignarla al gridview
                //System.Data.DataTable table = new DataTable("ParentTable");
                //// Declare variables for DataColumn and DataRow objects.
                //DataColumn column;
                //DataRow row;
                //// Create new DataColumn, set DataType, 
                //// ColumnName and add to DataTable. 
                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.String");
                //column.ColumnName = "CUENTA";
                //column.ReadOnly = false;
                //column.Unique = false;
                //// Add the Column to the DataColumnCollection.
                //table.Columns.Add(column);
                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.String");
                //column.ColumnName = "NOMBRE";
                //column.ReadOnly = false;
                //column.Unique = false;
                //// Add the Column to the DataColumnCollection.
                //table.Columns.Add(column);
                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.String");
                //column.ColumnName = "SEXO";
                //column.ReadOnly = false;
                //column.Unique = false;
                //// Add the Column to the DataColumnCollection.
                //table.Columns.Add(column);
                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.String");
                //column.ColumnName = "EDAD";
                //column.ReadOnly = false;
                //column.Unique = false;
                //// Add the Column to the DataColumnCollection.
                //table.Columns.Add(column);
                //column = new DataColumn();
                //column.DataType = System.Type.GetType("System.String");
                //column.ColumnName = "PARENTESCO";
                //column.ReadOnly = false;
                //column.Unique = false;
                //// Add the Column to the DataColumnCollection.
                //table.Columns.Add(column);
                //// Make the ID column the primary key column.
                //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                //PrimaryKeyColumns[0] = table.Columns["id"];
                //table.PrimaryKey = PrimaryKeyColumns;
                //// Instantiate the DataSet variable.
                //DataSet dataSet = new DataSet();
                ////Add the new DataTable to the DataSet.
                //dataSet.Tables.Add(table);

                int i, j = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    //j++;
                    //row = table.NewRow();
                    //row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    //row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    //row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    //row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    //row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    //table.Rows.Add(row);
                    lb_III01.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";// nombre de la persona
                                                                                                                         //lb_IIIe1e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe2e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe3e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe4e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe5e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe6e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe7e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                                                                                                                         //lb_IIIe8e2.Text = Gvresulta.Rows[i].Cells[1].Text + " de " + Gvresulta.Rows[i].Cells[3].Text + " años";
                //lb_IIIe101e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe100e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe1e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe102e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe103e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe2e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe3e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe4e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe5e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe6e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe7e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe1301e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe1302e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe10e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe8e2.Text = Gvresulta.Rows[i].Cells[1].Text;
                lb_IIIe12e2.Text = Gvresulta.Rows[i].Cells[1].Text;
            }
                //Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                //Gvresulta.DataBind();
                //cadena1.Clear();

                //cuenta += 1;
                //lb_III01.Text = slClienteID.ToString();// nombre de la persona
                //lb_IIIe1e2.Text = slClienteID.ToString();
                //lb_IIIe2e2.Text = slClienteID.ToString();
                //lb_IIIe3e2.Text = slClienteID.ToString();
                //lb_IIIe4e2.Text = slClienteID.ToString();
                //lb_IIIe5e2.Text = slClienteID.ToString();
                //lb_IIIe6e2.Text = slClienteID.ToString();
                //lb_IIIe7e2.Text = slClienteID.ToString();
                //lb_IIIe8e2.Text = slClienteID.ToString();
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5(Page);
                abrecom6(Page);
                abrecom700(Page);
                abrecom100(Page);
            //}
        }

        protected void Gvresulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#cccccc';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#cccccc';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }

        protected void agregar01_Click(object sender, EventArgs e)
        {
            Avance_barra2(2);
            if (tb_IIe21.Text == "")
            {
                //mensaje(Page, "Debe escribir el nombre de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "Debe escribir el nombre de la persona";
                programmaticModalPopup.Show();
                //tb_IIe11.BackColor = System.Drawing.Color.White;
                tb_IIe21.Focus();
                tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4(Page);
            }
            //else if (RadioButtonList1.Items[0].Selected == false && RadioButtonList1.Items[1].Selected == false)
            else if (radioA1.Checked == false && radioA2.Checked == false)
            {
                //mensaje(Page, "Debe elegir el sexo de la persona actual");
                Label17.Text = "Aviso";
                Label10.Text = "Debe elegir el sexo de la persona actual";
                programmaticModalPopup.Show();
                //tb_IIe11.BackColor = System.Drawing.Color.White;
                tb_IIe21.Focus();
                tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4(Page);
            }
            else if (tb_IIe23.Text == "")
            {
                //mensaje(Page, "Debe escribir la edad de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "Debe escribir la edad de la persona";
                programmaticModalPopup.Show();
                tb_IIe21.BackColor = System.Drawing.Color.White;
                tb_IIe23.Focus();
                tb_IIe23.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4(Page);
            }
            else if (Convert.ToUInt32(tb_IIe23.Text) > 130)
            {
                //mensaje(Page, "Debe escribir la edad de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "La edad de la persona no debe ser mayor de 130 años";
                programmaticModalPopup.Show();
                tb_IIe21.BackColor = System.Drawing.Color.White;
                tb_IIe23.Focus();
                tb_IIe23.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4(Page);
            }
            //else if (RadioButtonList2.Items[0].Selected == false && RadioButtonList2.Items[1].Selected == false && RadioButtonList2.Items[2].Selected == false && RadioButtonList2.Items[3].Selected == false && RadioButtonList2.Items[4].Selected == false && RadioButtonList2.Items[5].Selected == false && RadioButtonList2.Items[6].Selected == false && RadioButtonList2.Items[7].Selected == false && RadioButtonList2.Items[8].Selected == false)
            //else if (radioB1.Checked == false && radioB2.Checked == false && radioB3.Checked == false && radioB4.Checked == false && radioB5.Checked == false && radioB6.Checked == false && radioB7.Checked == false && radioB8.Checked == false && radioB9.Checked == false)
            //{
            //    mensaje(Page, "Debe elegir el parentesco de la persona");
            //    tb_IIe11.BackColor = System.Drawing.Color.White;
            //    tb_IIe21.Focus();
            //    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            //else if (radioB9.Checked == true && tb_IIe24.Text == "")
            //{
            //    mensaje(Page, "Debe escribir el parentesco de la persona");
            //    tb_IIe21.BackColor = System.Drawing.Color.White;
            //    tb_IIe24.Focus();
            //    tb_IIe24.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            else if (Convert.ToInt32(tb_IIe23.Text) < 12)
            {
                cierracom2(Page);
                cierracom4(Page);
                abrecom4s1(Page);
            }
            else
            {
                ayuda01.Attributes["data-content"] = leer_xml(1);
                System.Data.DataTable table = new DataTable("ParentTable");
                // Declare variables for DataColumn and DataRow objects.
                DataColumn column;
                DataRow row;
                // Create new DataColumn, set DataType, 
                // ColumnName and add to DataTable. 
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUENTA";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NOMBRE";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SEXO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "EDAD";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PARENTESCO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = table.Columns["id"];
                table.PrimaryKey = PrimaryKeyColumns;
                // Instantiate the DataSet variable.
                DataSet dataSet = new DataSet();
                //Add the new DataTable to the DataSet.
                dataSet.Tables.Add(table);
                int i, j = 1;
                //for (i = 0; i < Gvresulta.Rows.Count; i++)
                //{
                //    j++;
                //    row = table.NewRow();
                //    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                //    row["NOMBRE"] = Gvresulta.Rows[i].Cells[2].Text;
                //    row["SEXO"] = Gvresulta.Rows[i].Cells[3].Text;
                //    row["EDAD"] = Gvresulta.Rows[i].Cells[4].Text;
                //    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[5].Text;
                //    table.Rows.Add(row);
                //}
                j++;
                row = table.NewRow();
                row["CUENTA"] = "1";
                row["NOMBRE"] = tb_IIe21.Text;
                if (radioA1.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23.Text;
                //if (radioB1.Checked == true)
                //{
                //    row["PARENTESCO"] = "Jefa(e)";
                //}
                //else if (radioB2.Checked == true)
                //{
                //    row["PARENTESCO"] = "Esposa(o) o pareja";
                //}
                //else if (radioB3.Checked == true)
                //{
                //    row["PARENTESCO"] = "Hija(o)";
                //}
                //else if (radioB4.Checked == true)
                //{
                //    row["PARENTESCO"] = "Nieta(o)";
                //}
                //else if (radioB5.Checked == true)
                //{
                //    row["PARENTESCO"] = "Nuera o yerno";
                //}
                //else if (radioB6.Checked == true)
                //{
                //    row["PARENTESCO"] = "Madre o padre";
                //}
                //else if (radioB7.Checked == true)
                //{
                //    row["PARENTESCO"] = "Suegra (o)";
                //}
                //else if (radioB8.Checked == true)
                //{
                //    row["PARENTESCO"] = "Sin parentesco";
                //}
                //else if (radioB9.Checked == true)
                //{
                //    row["PARENTESCO"] = tb_IIe24.Text;
                //}
                row["PARENTESCO"] = "Jefa(e)";
                table.Rows.Add(row);
                for (i = 1; i < Gvresulta.Rows.Count; i++)
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = Gvresulta.Rows[i].Cells[0].Text;//j.ToString()t;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                Gvresulta.DataBind();
                HttpContext.Current.Session["nombre"] = tb_IIe21.Text + " de " + tb_IIe23.Text + " años";
                tb_IIe21.Text = "";
                radioA1.Checked = false;
                radioA2.Checked = false;
                tb_IIe23.Text = "";
                //radioB1.Checked = false;
                //radioB2.Checked = false;
                //radioB3.Checked = false;
                //radioB4.Checked = false;
                //radioB5.Checked = false;
                //radioB6.Checked = false;
                //radioB7.Checked = false;
                //radioB8.Checked = false;
                //radioB9.Checked = false;
                tb_IIe24.Text = "";
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                //if (radioB9.Checked == false)
                //{
                //    tb_IIe24.Visible = false;
                //    tb_IIe24.BackColor = System.Drawing.Color.White;
                //}
                abrecom2(Page);
                abrecom3a(Page);
                abrecom5(Page);
            }
        }

        protected void agregar01p_Click(object sender, EventArgs e)
        {
            int k = Gvresulta.Rows.Count;
            if (tb_IIe21p.Text == "")
            {
                //mensaje(Page, "Debe escribir el nombre de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "Debe escribir el nombre de la persona";
                programmaticModalPopup.Show();
                tb_IIe21p.Focus();
                tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4p(Page);
            }
            //else if (RadioButtonList1.Items[0].Selected == false && RadioButtonList1.Items[1].Selected == false)
            else if (radioA1p.Checked == false && radioA2p.Checked == false)
            {
                //mensaje(Page, "Debe elegir el sexo de la persona actual");
                Label17.Text = "Aviso";
                Label10.Text = "Debe elegir el sexo de la persona actual";
                programmaticModalPopup.Show();
                tb_IIe21p.Focus();
                tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4p(Page);
            }
            else if (tb_IIe23p.Text == "")
            {
                //mensaje(Page, "Debe escribir la edad de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "Debe escribir la edad de la persona";
                programmaticModalPopup.Show();
                tb_IIe21p.BackColor = System.Drawing.Color.White;
                tb_IIe23p.Focus();
                tb_IIe23p.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4p(Page);
            }
            else if (Convert.ToUInt32(tb_IIe23p.Text) > 130)
            {
                //mensaje(Page, "Debe escribir la edad de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "La edad de la persona no debe ser mayor de 130 años";
                programmaticModalPopup.Show();
                tb_IIe21p.BackColor = System.Drawing.Color.White;
                tb_IIe23p.Focus();
                tb_IIe23p.BackColor = System.Drawing.Color.LightSteelBlue;
                abrecom2(Page);
                abrecom4p(Page);
            }
            else if (DropDownList1.Text == "Seleccione...")
            //else if (RadioButtonList2.Items[0].Selected == false && RadioButtonList2.Items[1].Selected == false && RadioButtonList2.Items[2].Selected == false && RadioButtonList2.Items[3].Selected == false && RadioButtonList2.Items[4].Selected == false && RadioButtonList2.Items[5].Selected == false && RadioButtonList2.Items[6].Selected == false && RadioButtonList2.Items[7].Selected == false && RadioButtonList2.Items[8].Selected == false)
            //else if (radioB1.Checked == false && radioB2.Checked == false && radioB3.Checked == false && radioB4.Checked == false && radioB5.Checked == false && radioB6.Checked == false && radioB7.Checked == false && radioB8.Checked == false && radioB9.Checked == false)
            {
                //mensaje(Page, "Debe elegir el parentesco de la persona");
                Label17.Text = "Aviso";
                Label10.Text = "Debe elegir el parentesco de la persona";
                programmaticModalPopup.Show();
                tb_IIe21p.BackColor = System.Drawing.Color.White;
                //tb_IIe21p.Focus();
                //tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
                DropDownList1.Focus();
                abrecom2(Page);
                abrecom4p(Page);
            }
            else if (tb_IIe24.Text.Length < 3 && DropDownList1.Text == "Otro(especifique)")
            {
                //mensaje(Page, "El parentesco de la persona debe contener mínimo 3 caracteres");
                Label17.Text = "Aviso";
                Label10.Text = "El parentesco de la persona debe contener mínimo 3 caracteres";
                programmaticModalPopup.Show();
                tb_IIe21p.BackColor = System.Drawing.Color.White;
                tb_IIe24.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIe24.Focus();
                abrecom2(Page);
                abrecom4p(Page);

            }
            //else if (radioB9.Checked == true && tb_IIe24.Text == "")
            //{
            //    mensaje(Page, "Debe escribir el parentesco de la persona");
            //    tb_IIe21.BackColor = System.Drawing.Color.White;
            //    tb_IIe24.Focus();
            //    tb_IIe24.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            else if (DropDownList1.Text == "Esposa(o) o pareja" && k > 1)
            {
                int i;
                int l = 0;
                for (i = 0; i < k; i++)
                {
                    if (Gvresulta.Rows[i].Cells[4].Text == "Esposa(o) o pareja")
                    {
                        if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                        {
                            l++;
                        }
                    }
                }
                if (Convert.ToInt32(tb_IIe23p.Text) < 12 && l >= 1)
                {
                    cierracom2(Page);
                    cierracom4p(Page);
                    abrecom4s10(Page);
                }
                else if (l >= 1)
                {
                    cierracom2(Page);
                    cierracom4p(Page);
                    abrecom4s2(Page);
                }
                else if (Convert.ToInt32(tb_IIe23p.Text) < 12)
                {
                    cierracom2(Page);
                    cierracom4p(Page);
                    abrecom4s6(Page);
                }
                else
                {
                    ayuda01.Attributes["data-content"] = leer_xml(1);
                    System.Data.DataTable table = new DataTable("ParentTable");
                    // Declare variables for DataColumn and DataRow objects.
                    DataColumn column;
                    DataRow row;
                    // Create new DataColumn, set DataType, 
                    // ColumnName and add to DataTable. 
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "CUENTA";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "NOMBRE";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "SEXO";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "EDAD";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "PARENTESCO";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    // Make the ID column the primary key column.
                    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                    PrimaryKeyColumns[0] = table.Columns["id"];
                    table.PrimaryKey = PrimaryKeyColumns;
                    // Instantiate the DataSet variable.
                    DataSet dataSet = new DataSet();
                    //Add the new DataTable to the DataSet.
                    dataSet.Tables.Add(table);
                    int j = 0;
                    i = 0;
                    int mp = 0;
                    for (i = 0; i < Gvresulta.Rows.Count; i++)
                    {
                        if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                        {
                            j++;
                            row = table.NewRow();
                            row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                            row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                            row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                            row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                            row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                            table.Rows.Add(row);
                        }
                        else
                        {
                            j++;
                            row = table.NewRow();
                            if (Gvresulta.Rows[i].Cells[0].Text == "1")
                            {
                                row["CUENTA"] = j.ToString();
                                row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                                row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                                row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                                row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                                mp = 1;
                            }
                            else
                            {
                                row["CUENTA"] = j.ToString();
                                row["NOMBRE"] = tb_IIe21p.Text;
                                if (radioA1p.Checked == true)
                                {
                                    row["SEXO"] = "Hombre";
                                }
                                else if (radioA2p.Checked == true)
                                {
                                    row["SEXO"] = "Mujer";
                                }
                                row["EDAD"] = tb_IIe23p.Text;
                                if (DropDownList1.Text == "Otro(especifique)")
                                {
                                    row["PARENTESCO"] = tb_IIe24.Text;
                                }
                                else
                                {
                                    row["PARENTESCO"] = DropDownList1.Text;
                                }
                            }
                            table.Rows.Add(row);
                            HttpContext.Current.Session["editar"] = "";
                        }
                    }
                    if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
                    {
                        j++;
                        row = table.NewRow();
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        //if (radioB1.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Jefa(e)";
                        //}
                        //else if (radioB2.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Esposa(o) o pareja";
                        //}
                        //else if (radioB3.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Hija(o)";
                        //}
                        //else if (radioB4.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Nieta(o)";
                        //}
                        //else if (radioB5.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Nuera o yerno";
                        //}
                        //else if (radioB6.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Madre o padre";
                        //}
                        //else if (radioB7.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Suegra (o)";
                        //}
                        //else if (radioB8.Checked == true)
                        //{
                        //    row["PARENTESCO"] = "Sin parentesco";
                        //}
                        //else if (radioB9.Checked == true)
                        //{
                        //    row["PARENTESCO"] = tb_IIe24.Text;
                        //}
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                        table.Rows.Add(row);
                    }
                    else
                    {
                        HttpContext.Current.Session["editar"] = "p";
                    }
                    Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                    Gvresulta.DataBind();
                    tb_IIe21p.Text = "";
                    radioA1p.Checked = false;
                    radioA2p.Checked = false;
                    tb_IIe23p.Text = "";
                    //radioB1.Checked = false;
                    //radioB2.Checked = false;
                    //radioB3.Checked = false;
                    //radioB4.Checked = false;
                    //radioB5.Checked = false;
                    //radioB6.Checked = false;
                    //radioB7.Checked = false;
                    //radioB8.Checked = false;
                    //radioB9.Checked = false;
                    tb_IIe24.Visible = false;
                    tb_IIe24.Text = "";
                    //if (radioB9.Checked == false)
                    //{
                    //    tb_IIe24.Visible = false;
                    //    tb_IIe24.BackColor = System.Drawing.Color.White;
                    //}
                    abrecom2(Page);
                    abrecom3a(Page);
                    abrecom5(Page);
                    tb_IIe11.Focus();
                    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                    siguienteini.Visible = false;
                    agregar01a.Visible = true;
                }
            }
            else if (DropDownList1.Text == "Hija(o)" && ((Convert.ToInt32(Gvresulta.Rows[0].Cells[3].Text) - Convert.ToInt32(tb_IIe23p.Text)) < 11))
            {
                cierracom2(Page);
                cierracom4p(Page);
                abrecom4s3(Page);
            }
            else if (DropDownList1.Text == "Nieta(o)" && ((Convert.ToInt32(Gvresulta.Rows[0].Cells[3].Text) - Convert.ToInt32(tb_IIe23p.Text)) < 21))
            {
                cierracom2(Page);
                cierracom4p(Page);
                abrecom4s4(Page);
            }
            else if (DropDownList1.Text == "Madre o padre" && ((Convert.ToInt32(tb_IIe23p.Text) - Convert.ToInt32(Gvresulta.Rows[0].Cells[3].Text)) < 11))
            {
                cierracom2(Page);
                cierracom4p(Page);
                abrecom4s5(Page);
            }
            else if (DropDownList1.Text == "Esposa(o) o pareja" && (Convert.ToInt32(tb_IIe23p.Text) < 12))
            {
                cierracom2(Page);
                cierracom4p(Page);
                abrecom4s6(Page);
            }
            else
            {
                ayuda01.Attributes["data-content"] = leer_xml(1);
                System.Data.DataTable table = new DataTable("ParentTable");
                // Declare variables for DataColumn and DataRow objects.
                DataColumn column;
                DataRow row;
                // Create new DataColumn, set DataType, 
                // ColumnName and add to DataTable. 
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUENTA";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NOMBRE";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SEXO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "EDAD";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PARENTESCO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = table.Columns["id"];
                table.PrimaryKey = PrimaryKeyColumns;
                // Instantiate the DataSet variable.
                DataSet dataSet = new DataSet();
                //Add the new DataTable to the DataSet.
                dataSet.Tables.Add(table);
                int i, j = 0;
                int mp = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                    {
                        j++;
                        row = table.NewRow();
                        row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        j++;
                        row = table.NewRow();
                        if (Gvresulta.Rows[i].Cells[0].Text == "1")
                        {
                            row["CUENTA"] = j.ToString();
                            row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                            row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                            row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                            row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                            mp = 1;
                        }
                        else
                        {
                            row["CUENTA"] = j.ToString();
                            row["NOMBRE"] = tb_IIe21p.Text;
                            if (radioA1p.Checked == true)
                            {
                                row["SEXO"] = "Hombre";
                            }
                            else if (radioA2p.Checked == true)
                            {
                                row["SEXO"] = "Mujer";
                            }
                            row["EDAD"] = tb_IIe23p.Text;
                            if (DropDownList1.Text == "Otro(especifique)")
                            {
                                row["PARENTESCO"] = tb_IIe24.Text;
                            }
                            else
                            {
                                row["PARENTESCO"] = DropDownList1.Text;
                            }
                        }
                        table.Rows.Add(row);
                        HttpContext.Current.Session["editar"] = "";
                    }
                }
                if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();
                    row["NOMBRE"] = tb_IIe21p.Text;
                    if (radioA1p.Checked == true)
                    {
                        row["SEXO"] = "Hombre";
                    }
                    else if (radioA2p.Checked == true)
                    {
                        row["SEXO"] = "Mujer";
                    }
                    row["EDAD"] = tb_IIe23p.Text;
                    //if (radioB1.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Jefa(e)";
                    //}
                    //else if (radioB2.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Esposa(o) o pareja";
                    //}
                    //else if (radioB3.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Hija(o)";
                    //}
                    //else if (radioB4.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Nieta(o)";
                    //}
                    //else if (radioB5.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Nuera o yerno";
                    //}
                    //else if (radioB6.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Madre o padre";
                    //}
                    //else if (radioB7.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Suegra (o)";
                    //}
                    //else if (radioB8.Checked == true)
                    //{
                    //    row["PARENTESCO"] = "Sin parentesco";
                    //}
                    //else if (radioB9.Checked == true)
                    //{
                    //    row["PARENTESCO"] = tb_IIe24.Text;
                    //}
                    if (DropDownList1.Text == "Otro(especifique)")
                    {
                        row["PARENTESCO"] = tb_IIe24.Text;
                    }
                    else
                    {
                        row["PARENTESCO"] = DropDownList1.Text;
                    }
                    table.Rows.Add(row);
                }
                else
                {
                    HttpContext.Current.Session["editar"] = "p";
                }
                Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                Gvresulta.DataBind();
                tb_IIe21p.Text = "";
                radioA1p.Checked = false;
                radioA2p.Checked = false;
                tb_IIe23p.Text = "";
                //radioB1.Checked = false;
                //radioB2.Checked = false;
                //radioB3.Checked = false;
                //radioB4.Checked = false;
                //radioB5.Checked = false;
                //radioB6.Checked = false;
                //radioB7.Checked = false;
                //radioB8.Checked = false;
                //radioB9.Checked = false;
                tb_IIe24.Visible = false;
                tb_IIe24.Text = "";
                //if (radioB9.Checked == false)
                //{
                //    tb_IIe24.Visible = false;
                //    tb_IIe24.BackColor = System.Drawing.Color.White;
                //}
                abrecom2(Page);
                abrecom3a(Page);
                abrecom5(Page);
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                siguienteini.Visible = false;
                agregar01a.Visible = true;
            }
        }

        protected void agregar01a_Click(object sender, EventArgs e)
        {
            //int m;
            //if (tb_IIe11.Text == "")
            //{
            //    m = 0;
            //}
            //else
            //{
            //    m = Convert.ToInt16(tb_IIe11.Text);
            //}
            //if (m >= 1)
            //{
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4p(Page);
                ayuda01.Attributes["data-content"] = leer_xml(2);
                lb_IIe24.Text = "¿Qué es esta persona de " + HttpContext.Current.Session["nombre"].ToString() + "?";
                tb_IIe21p.Text = "";
                radioA1p.Checked = false;
                radioA2p.Checked = false;
                tb_IIe23p.Text = "";
                DropDownList1.SelectedIndex = 0;
                lb_IIe24.Visible = true;
                DropDownList1.Visible = true;
                tb_IIe24.Text = "";
                tb_IIe21p.Focus();
                tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            //else
            //{
            //    tb_IIe11.Focus();
            //    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            //    mensaje(Page, "La cantidad de habitantes de la vivienda debe de ser mayor a 0");
            //}
        }
        protected void agregar01b_Click(object sender, EventArgs e)
        {
            siguienteini.Visible = false;
            agregar01a.Visible = true;
            lb_IIe24.Visible = false;
            DropDownList1.Visible = false;
            //int m;
            //if (tb_IIe11.Text == "")
            //{
            //    m = 0;
            //}
            //else
            //{
            //    m = Convert.ToInt16(tb_IIe11.Text);
            //}
            //if (m >= 1)
            //{
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4(Page);
                tb_IIe21.Focus();
                tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                System.Data.DataTable table = new DataTable("ParentTable");
                // Declare variables for DataColumn and DataRow objects.
                DataColumn column;
                DataRow row;
                // Create new DataColumn, set DataType, 
                // ColumnName and add to DataTable. 
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUENTA";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NOMBRE";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SEXO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "EDAD";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PARENTESCO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = table.Columns["id"];
                table.PrimaryKey = PrimaryKeyColumns;
                // Instantiate the DataSet variable.
                DataSet dataSet = new DataSet();
                //Add the new DataTable to the DataSet.
                dataSet.Tables.Add(table);
                int i, j = 0;
                ////for (i = 0; i < Gvresulta.Rows.Count; i++)
                //for (i = 0; i < Convert.ToInt16(tb_IIe11.Text); i++)
                //{
                //    j++;
                //    row = table.NewRow();
                //    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                //    row["NOMBRE"] = "";
                //    row["SEXO"] = "";
                //    row["EDAD"] = "";
                //    if (j == 1)
                //    {
                //        row["PARENTESCO"] = "Jefa (e)";
                //    }
                //    else
                //    {
                //        row["PARENTESCO"] = "";
                //    }
                //    //row["NOMBRE"] = Gvresulta.Rows[i].Cells[2].Text;
                //    //row["SEXO"] = Gvresulta.Rows[i].Cells[3].Text;
                //    //row["EDAD"] = Gvresulta.Rows[i].Cells[4].Text;
                //    //row["PARENTESCO"] = Gvresulta.Rows[i].Cells[5].Text;
                //    table.Rows.Add(row);
                //}
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = "";
                row["SEXO"] = "";
                row["EDAD"] = "";
                row["PARENTESCO"] = "Jefa(e)";
                table.Rows.Add(row);

                Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                Gvresulta.DataBind();
                //abrecom5(Page);
            //}
            //else
            //{
            //    abrecom2(Page);
            //    abrecom3a(Page);
            //    tb_IIe11.Focus();
            //    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            //    mensaje(Page, "La cantidad de habitantes de la vivienda debe de ser mayor a 0");
            //}
        }
        protected void agregar01b1_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["cuenta"] = "0";
            Avance_barra2(1);
            //Leer el grid_view y filtrar el dato que se eligio con el botón y no incluirlo, crear secuencialmente la tabla y asignarla al gridview
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            //siguienteini.Visible = false;
            //agregar01a.Visible = true;
            //abrecom2(Page);
            //abrecom4(Page);
            //tb_IIe21.Focus();
            //tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            abrecom4q5(Page);
            //abrecom3a(Page);

        }
        protected void agregar01b3_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["cuenta"] = "0";
            Avance_barra2(2);
            ayuda01.Attributes["data-content"] = leer_xml(1);
            //Leer el grid_view y filtrar el dato que se eligio con el botón y no incluirlo, crear secuencialmente la tabla y asignarla al gridview
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            int i, j = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["registro"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            cierracom4q1(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            //tb_IIe11.Focus();
            //tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
        }
        protected void agregar01b2_Click(object sender, EventArgs e)
        {
            if (tb_IIe11.Text == "" && regreso[0] == 0)
            {
                regreso[0] = 0;
                Label17.Text = "Aviso";
                Label10.Text = "No proporcionó respuesta a esta pregunta";
                programmaticModalPopup.Show();
                HttpContext.Current.Session["cuenta"] = "0";
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                siguienteini.Visible = true;
                agregar01a.Visible = false;
                abrecom2(Page);
                abrecom3(Page);
            }
            else if (tb_IIe11.Text == "0")
            {
                //Image1.ImageUrl = "Images/Cortinilla4.JPG";
                //programmaticModalPopup2.Show();
                //cierramodal(Page);
                cierracom2(Page);
                cierracom3(Page);
                abrecom4s(Page);
            }
            else
            {
                if (Gvresulta.Rows.Count >= 1)
                {
                    System.Data.DataTable table = new DataTable("ParentTable");
                    // Declare variables for DataColumn and DataRow objects.
                    DataColumn column;
                    DataRow row;
                    // Create new DataColumn, set DataType, 
                    // ColumnName and add to DataTable. 
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "CUENTA";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "NOMBRE";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "SEXO";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "EDAD";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "PARENTESCO";
                    column.ReadOnly = false;
                    column.Unique = false;
                    // Add the Column to the DataColumnCollection.
                    table.Columns.Add(column);
                    // Make the ID column the primary key column.
                    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                    PrimaryKeyColumns[0] = table.Columns["id"];
                    table.PrimaryKey = PrimaryKeyColumns;
                    // Instantiate the DataSet variable.
                    DataSet dataSet = new DataSet();
                    //Add the new DataTable to the DataSet.
                    dataSet.Tables.Add(table);
                    int i, j = 0;
                    int mp = 0;
                    for (i = 0; i < Gvresulta.Rows.Count; i++)
                    {
                        if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                        {
                            j++;
                            row = table.NewRow();
                            row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                            row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                            row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                            row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                            row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                            table.Rows.Add(row);
                        }
                        else
                        {
                            j++;
                            row = table.NewRow();
                            if (Gvresulta.Rows[i].Cells[0].Text == "1")
                            {
                                row["CUENTA"] = j.ToString();
                                row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                                row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                                row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                                row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                                mp = 1;
                            }
                            else
                            {
                                row["CUENTA"] = j.ToString();
                                row["NOMBRE"] = tb_IIe21p.Text;
                                if (radioA1p.Checked == true)
                                {
                                    row["SEXO"] = "Hombre";
                                }
                                else if (radioA2p.Checked == true)
                                {
                                    row["SEXO"] = "Mujer";
                                }
                                row["EDAD"] = tb_IIe23p.Text;
                                if (DropDownList1.Text == "Otro(especifique)")
                                {
                                    row["PARENTESCO"] = tb_IIe24.Text;
                                }
                                else
                                {
                                    row["PARENTESCO"] = DropDownList1.Text;
                                }
                            }
                            table.Rows.Add(row);
                            HttpContext.Current.Session["editar"] = "";
                        }
                    }
                    Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                    Gvresulta.DataBind();
                    Avance_barra2(2);
                    tb_IIe21p.Text = "";
                    radioA1p.Checked = false;
                    radioA2p.Checked = false;
                    tb_IIe23p.Text = "";
                    tb_IIe24.Visible = false;
                    tb_IIe24.Text = "";
                    cierracom4s5(Page);
                    abrecom2(Page);
                    abrecom3a(Page);
                    abrecom5(Page);
                    tb_IIe11.Focus();
                    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                    siguienteini.Visible = false;
                    agregar01a.Visible = true;
                }
                else
                {
                    HttpContext.Current.Session["cuenta"] = "0";
                    Avance_barra2(1);
                    tb_IIe11.Focus();
                    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                    //siguienteini.Visible = true;
                    //agregar01a.Visible = false;
                    siguienteini.Visible = false;
                    agregar01a.Visible = true;
                    abrecom2(Page);
                    abrecom4(Page);
                    tb_IIe21.Focus();
                    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                    //abrecom3a(Page);
                }
            }
        }
        protected void ayuda01_Click(object sender, EventArgs e)
        {

        }
        protected void mensaje(System.Web.UI.Page pagina, string aviso)
        {
            string codigo;
            codigo = "<script language='JavaScript'>alert('" + aviso + "');</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Avisar"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Avisar", codigo);
            }
        }

        protected void cierracom2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec002');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com2", codigo);
            }
        }
        protected void cierracom3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3", codigo);
            }
        }
        protected void cierracom3a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec003a');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com3a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com3a", codigo);
            }
        }
        protected void cierracom4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4", codigo);
            }
        }
        protected void cierracom4p(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004p');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4p"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4p", codigo);
            }
        }
        protected void cierracom4q(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q", codigo);
            }
        }
        protected void cierracom4q1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q1');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q1", codigo);
            }
        }
        protected void cierracom4q2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q2');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q2", codigo);
            }
        }
        protected void cierracom4q3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q3');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q3", codigo);
            }
        }
        protected void cierracom4q4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q4');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q4", codigo);
            }
        }
        protected void cierracom4q5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q5');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q5", codigo);
            }
        }
        protected void cierracom4q6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q6');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q6", codigo);
            }
        }
        protected void cierracom4q7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004q7');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4q7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4q7", codigo);
            }
        }
        protected void cierracom4s(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s", codigo);
            }
        }
        protected void cierracom4s1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S1');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s1", codigo);
            }
        }
        protected void cierracom4s2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S2');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s2", codigo);
            }
        }
        protected void cierracom4s3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S3');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s3", codigo);
            }
        }
        protected void cierracom4s4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S4');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s4", codigo);
            }
        }
        protected void cierracom4s5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S5');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s5", codigo);
            }
        }
        protected void cierracom4s6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S6');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s6", codigo);
            }
        }
        protected void cierracom4s7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S7');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s7", codigo);
            }
        }
        protected void cierracom4s8(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S8');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s8"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s8", codigo);
            }
        }
        protected void cierracom4s9(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S9');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s9"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s9", codigo);
            }
        }
        protected void cierracom4s10(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S10');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s10"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s10", codigo);
            }
        }
        protected void cierracom4s11(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S11');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s11"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s11", codigo);
            }
        }
        protected void cierracom4s12(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004S12');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4s12"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4s12", codigo);
            }
        }
        protected void cierracom5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec005');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com5", codigo);
            }
        }
        protected void cierracom5b(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec005b');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com5b"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com5b", codigo);
            }
        }
        protected void cierracom5c(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec005c');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com5c"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com5c", codigo);
            }
        }
        protected void cierracom5d(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec005d');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com5d"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com5d", codigo);
            }
        }
        protected void cierracom6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec006');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com6", codigo);
            }
        }

        protected void cierracom7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec007');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com7", codigo);
            }
        }
        protected void cierracom700(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec00700');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com700"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com700", codigo);
            }
        }
        protected void cierracom701(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec00701');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com701"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com701", codigo);
            }
        }
        protected void cierracom702(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec00702');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com702"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com702", codigo);
            }
        }
        protected void cierracom703(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec00703');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com703"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com703", codigo);
            }
        }
        protected void cierracom8(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec008');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com8"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com8", codigo);
            }
        }

        protected void cierracom9(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec009');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com9"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com9", codigo);
            }
        }

        protected void cierracom10(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec010');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com10"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com10", codigo);
            }
        }

        protected void cierracom11(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec011');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com11"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com11", codigo);
            }
        }

        protected void cierracom12(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec012');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com12"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com12", codigo);
            }
        }

        protected void cierracom13(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec013');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com13"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com13", codigo);
            }
        }
        protected void cierracom1301(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec01301');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com1301"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com1301", codigo);
            }
        }
        protected void cierracom1302(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec01302');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com1302"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com1302", codigo);
            }
        }
        protected void cierracom14(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec014');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com14"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com14", codigo);
            }
        }
        protected void cierracom1401(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec01401');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com1401"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com1401", codigo);
            }
        }
        protected void cierracom1403(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec01403');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com1403"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com1403", codigo);
            }
        }
        protected void cierracom100(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec100');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com100"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com100", codigo);
            }
        }

        protected void cierrabot1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('MainContent_atras01');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close bot1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close bot1", codigo);
            }
        }

        protected void abrecom2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec002');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com2", codigo);
            }
        }
        protected void abrecom3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3", codigo);
            }
        }
        protected void abrecom3a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec003a');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com3a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com3a", codigo);
            }
        }
        protected void abrecom4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4", codigo);
            }
        }
        protected void abrecom4p(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004p');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4p"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4p", codigo);
            }
        }
        protected void abrecom4q(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q", codigo);
            }
        }
        protected void abrecom4q1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q1');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q1", codigo);
            }
        }
        protected void abrecom4q2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q2');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q2", codigo);
            }
        }
        protected void abrecom4q3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q3');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q3", codigo);
            }
        }
        protected void abrecom4q4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q4');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q4", codigo);
            }
        }
        protected void abrecom4q5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q5');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q5", codigo);
            }
        }
        protected void abrecom4q6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q6');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q6", codigo);
            }
        }
        protected void abrecom4q7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004q7');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4q7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4q7", codigo);
            }
        }
        protected void abrecom4s(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s", codigo);
            }
        }
        protected void abrecom4s1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S1');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s1", codigo);
            }
        }
        protected void abrecom4s2(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S2');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s2"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s2", codigo);
            }
        }
        protected void abrecom4s3(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S3');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s3"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s3", codigo);
            }
        }
        protected void abrecom4s4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S4');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s4", codigo);
            }
        }
        protected void abrecom4s5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S5');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s5", codigo);
            }
        }
        protected void abrecom4s6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S6');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s6", codigo);
            }
        }
        protected void abrecom4s7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S7');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s7", codigo);
            }
        }
        protected void abrecom4s8(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S8');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s8"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s8", codigo);
            }
        }
        protected void abrecom4s9(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S9');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s9"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s9", codigo);
            }
        }
        protected void abrecom4s10(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S10');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s10"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s10", codigo);
            }
        }
        protected void abrecom4s11(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S11');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s11"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s11", codigo);
            }
        }
        protected void abrecom4s12(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004S12');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4s12"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4s12", codigo);
            }
        }
        protected void abrecom5(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec005');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com5"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com5", codigo);
            }
        }
        protected void abrecom5b(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec005b');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com5b"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com5b", codigo);
            }
        }
        protected void abrecom5c(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec005c');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com5c"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com5c", codigo);
            }
        }
        protected void abrecom5d(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec005d');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com5d"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com5d", codigo);
            }
        }
        protected void abrecom5a(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec005a');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com5a"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com5a", codigo);
            }
        }

        protected void abrecom6(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec006');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com6"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com6", codigo);
            }
        }

        protected void abrecom7(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec007');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com7"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com7", codigo);
            }
        }
        protected void abrecom700(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec00700');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com700"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com700", codigo);
            }
        }
        protected void abrecom701(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec00701');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com701"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com701", codigo);
            }
        }
        protected void abrecom702(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec00702');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com702"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com702", codigo);
            }
        }
        protected void abrecom703(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec00703');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com703"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com703", codigo);
            }
        }
        protected void abrecom8(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec008');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com8"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com8", codigo);
            }
        }

        protected void abrecom9(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec009');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com9"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com9", codigo);
            }
        }

        protected void abrecom10(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec010');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com10"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com10", codigo);
            }
        }

        protected void abrecom11(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec011');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com11"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com11", codigo);
            }
        }

        protected void abrecom12(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec012');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com12"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com12", codigo);
            }
        }

        protected void abrecom13(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec013');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com13"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com13", codigo);
            }
        }
        protected void abrecom1301(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec01301');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com1301"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com1301", codigo);
            }
        }
        protected void abrecom1302(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec01302');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com1302"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com1302", codigo);
            }
        }
        protected void abrecom14(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec014');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com14"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com14", codigo);
            }
        }
        protected void abrecom1401(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec01401');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com1401"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com1401", codigo);
            }
        }
        protected void abrecom1403(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec01403');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com1403"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com1403", codigo);
            }
        }
        protected void abrecom100(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec100');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com100"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com100", codigo);
            }
        }

        protected void abrebot1(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('MainContent_atras01');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open bot1"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open bot1", codigo);
            }
        }
        protected void atras01_Click(object sender, EventArgs e)
        {
            int cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            int p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
            int p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
            cuenta -= 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            switch (cuenta)
            {
                case 1:
                    p1 = 1;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(7);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom700(Page);
                    abrecom100(Page);
                    cierrabot1(Page);
                    break;
                case 2:
                    p1 = 2;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(8);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom7(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 3:
                    p1 = 3;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(9);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom702(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 4:
                    p1 = 4;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(10);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom703(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 5:
                    p1 = 5;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(11);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom8(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 6:
                    p1 = 6;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(12);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom9(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    tb_IIIe31.BackColor = System.Drawing.Color.LightSteelBlue;
                    tb_IIIe31.Focus();
                    break;
                case 7:
                    if (radioD2.Checked == true)
                    {
                        cuenta = 5;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 5;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(11);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom8(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        p1 = 7;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(13);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom10(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 8:
                    p1 = 8;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(14);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom11(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 9:
                    p1 = 9;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(15);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom12(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 10:
                    //if (tb_IIIe64.Text != "" || tb_IIIe65.Text != "" || tb_IIIe66.Text != "" || tb_IIIe67.Text != "" || tb_IIIe68.Text != "" || tb_IIIe69.Text != "" || tb_IIIe610.Text != "" || tb_IIIe611.Text != "" || tb_IIIe612.Text != "" || tb_IIIe613.Text != "" || tb_IIIe614.Text != "" || tb_IIIe615.Text != "")
                    if (radioG4.Checked != false || radioG5.Checked != false || radioG6.Checked != false || radioG7.Checked != false || radioG8.Checked != false || radioG9.Checked != false || radioG10.Checked != false || radioG11.Checked != false || radioG12.Checked != false || radioG13.Checked != false || radioG14.Checked != false || radioG15.Checked != false)
                    {
                        cuenta = 9;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 9;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(15);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom12(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        p1 = 10;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(16);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom13(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 11:
                    p1 = 11;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(17);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom1301(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 12:
                    p1 = 12;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(18);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom1302(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 13:
                    p1 = 13;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(19);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom1401(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 14:
                    p1 = 14;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(20);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom14(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 15:
                    p1 = 15;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(21);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom1403(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                default:
                    cuenta = 15;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    p1 = 15;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(21);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom1403(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom1403(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
            }
            //ayuda01.Attributes["data-content"] = leer_xml(cuenta);
            Avance_barra(1);
        }

        protected void adelante01_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["qr_viv"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            int cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            int p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
            int p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
            int actual;
            cuenta += 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            switch (cuenta)
            {
                case 1:
                    p1 = 1;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(7);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom700(Page);
                    cierracom7(Page);
                    cierracom702(Page);
                    cierracom703(Page);
                    cierracom703(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom1301(Page);
                    cierracom1302(Page);
                    cierracom1401(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom700(Page);
                    abrecom100(Page);
                    cierrabot1(Page);
                    break;
                case 2:
                    if (radioC1001.Checked == false && radioC1003.Checked == false && tb_IIIe1002.Text == "" && tb_IIIe1004.Text == "" && regreso[4] == 0)
                    {
                        regreso[4] = 1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 1;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 1;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(7);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom700(Page);
                        abrecom100(Page);
                        cierrabot1(Page);
                    }
                    else if (radioC1001.Checked == false && radioC1003.Checked == false && tb_IIIe1004.Text == "" && tb_IIIe1002.Text.Length < 3 && regreso[4] == 0)
                    {
                        regreso[4] = 0;
                        mensaje(Page, "El campo en otro estado debe de tener un mínimo de 3 caracteres");
                        cuenta = 1;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 1;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(7);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom700(Page);
                        abrecom100(Page);
                        cierrabot1(Page);
                    }
                    else if (radioC1001.Checked == false && radioC1003.Checked == false && tb_IIIe1002.Text == "" && tb_IIIe1004.Text.Length < 3 && regreso[4] == 0)
                    {
                        regreso[4] = 0;
                        mensaje(Page, "El campo en otro país debe de tener un mínimo de 3 caracteres");
                        cuenta = 1;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 1;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(7);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom700(Page);
                        abrecom100(Page);
                        cierrabot1(Page);
                    }
                    else
                    {
                        cuenta = 2;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 2;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(8);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom7(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 3:
                    if (CheckBox1.Checked == false && CheckBox2.Checked == false && CheckBox3.Checked == false && CheckBox4.Checked == false && CheckBox5.Checked == false && CheckBox6.Checked == false && CheckBox7.Checked == false && CheckBox8.Checked == false && regreso[5] == 0)
                    {
                        regreso[5] = 1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 2;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 2;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(8);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom7(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 3;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 3;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(9);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom702(Page);
                        abrecom100(Page);
                        tb_IIIe1021.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_IIIe1021.Focus();
                        abrebot1(Page);
                        //cuenta = 3;
                        //HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        //cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        //p1 = 3;
                        //HttpContext.Current.Session["p1"] = p1.ToString();
                        //p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        //Avance_barra(1);
                        //cierracom2(Page);
                        //cierracom3a(Page);
                        //cierracom4(Page);
                        //cierracom5(Page);
                        //cierracom6(Page);
                        //cierracom7(Page);
                        //cierracom8(Page);
                        //cierracom9(Page);
                        //cierracom10(Page);
                        //cierracom11(Page);
                        //cierracom12(Page);
                        //cierracom13(Page);
                        //cierracom14(Page);
                        //cierracom100(Page);
                        //abrecom6(Page);
                        //abrecom8(Page);
                        //abrecom100(Page);
                        //abrebot1(Page);
                    }
                    break;
                case 4:
                    if (tb_IIIe1021.Text == "" && regreso[6] == 0)
                    {
                        regreso[6] = 1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        cuenta = 3;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 3;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(9);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom702(Page);
                        abrecom100(Page);
                        tb_IIIe1021.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_IIIe1021.Focus();
                        abrebot1(Page);
                    }
                    else if (tb_IIIe1021.Text.Length < 3 && regreso[6] == 0)
                    {
                        regreso[6] = 0;
                        mensaje(Page, "El campo de religión debe de tener un mínimo de 3 caracteres");
                        cuenta = 3;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 3;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(9);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom702(Page);
                        abrecom100(Page);
                        tb_IIIe1021.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_IIIe1021.Focus();
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 4;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 4;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(10);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom703(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 5:
                    if (Convert.ToInt32(HttpContext.Current.Session["anos"].ToString()) < 3)
                    {
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        actual++;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        if (actual < Gvresulta.Rows.Count)
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            p2++;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            int j = 0;
                            foreach (int i in regreso)
                            {
                                regreso[j] = 0;
                                j++;
                            }
                            HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados corresponderán a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                            //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup3.Show();
                            Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            abrecom4q6(Page);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //cierrabot1(Page);
                        }
                        else
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            actual = 0;
                            HttpContext.Current.Session["actual"] = actual.ToString();
                            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                            p2 = 1;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //Label18.Text = "Guardado de datos";
                            Guardar(1, 1);
                            Label19.Text = "¡Usted ha concluido el cuestionario y se ha enviado exitosamente!";
                            abrecom4q3(Page);
                            cierrabot1(Page);
                        }
                    }
                    else if (radioC1031.Checked == false && radioC1033.Checked == false && regreso[7] == 0)
                    {
                        regreso[7] =1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 4;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 4;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(10);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom703(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 5;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 5;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(11);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom8(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 6:
                    if (radioD1.Checked == false && radioD2.Checked == false && regreso[8] == 0)
                    {
                        regreso[8] = 1;
                        cuenta = 5;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        p1 = 5;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(11);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom8(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else if (radioD2.Checked == true)
                    {
                        cuenta = 8;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 8;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(14);
                        tb_IIIe31.Text = "";
                        radioE1.Checked = false;
                        radioE2.Checked = false;
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom11(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 6;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 6;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(12);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom9(Page);
                        abrecom100(Page);
                        tb_IIIe31.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_IIIe31.Focus();
                        abrebot1(Page);
                    }
                    break;
                case 7:
                    if (tb_IIIe31.Text == "" && regreso[9] == 0)
                    {
                        regreso[9] = 1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        cuenta = 6;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 6;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(12);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom9(Page);
                        abrecom100(Page);
                        tb_IIIe31.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_IIIe31.Focus();
                        abrebot1(Page);
                    }
                    else if (tb_IIIe31.Text.Length < 3 && regreso[9] == 0)
                    {
                        regreso[9] = 0;
                        mensaje(Page, "El campo de lengua indígena debe de tener un mínimo de 3 caracteres");
                        cuenta = 6;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 6;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(12);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom9(Page);
                        abrecom100(Page);
                        tb_IIIe31.BackColor = System.Drawing.Color.LightSteelBlue;
                        tb_IIIe31.Focus();
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 7;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 7;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(13);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom10(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 8:
                    if (radioE1.Checked == false && radioE2.Checked == false && regreso[10] == 0)
                    {
                        regreso[10] = 1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 7;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 7;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(13);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom10(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 8;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 8;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(14);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom11(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 9:
                    if (radioF1.Checked == false && radioF2.Checked == false && regreso[11] == 0)
                    {
                        regreso[11] = 1;
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 8;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 8;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        tb_IIIe61.Text = "";
                        tb_IIIe62.Text = "";
                        tb_IIIe63.Text = "";
                        tb_IIIe64.Text = "";
                        tb_IIIe65.Text = "";
                        tb_IIIe66.Text = "";
                        tb_IIIe67.Text = "";
                        tb_IIIe68.Text = "";
                        tb_IIIe69.Text = "";
                        tb_IIIe610.Text = "";
                        tb_IIIe611.Text = "";
                        tb_IIIe612.Text = "";
                        tb_IIIe613.Text = "";
                        tb_IIIe614.Text = "";
                        tb_IIIe615.Text = "";
                        radioG1.Checked = false;
                        radioG2.Checked = false;
                        radioG3.Checked = false;
                        radioG4.Checked = false;
                        radioG5.Checked = false;
                        radioG6.Checked = false;
                        radioG7.Checked = false;
                        radioG8.Checked = false;
                        radioG9.Checked = false;
                        radioG10.Checked = false;
                        radioG11.Checked = false;
                        radioG12.Checked = false;
                        radioG13.Checked = false;
                        radioG14.Checked = false;
                        radioG15.Checked = false;
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(14);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom11(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        tb_IIIe61.Visible = false;
                        tb_IIIe62.Visible = false;
                        tb_IIIe63.Visible = false;
                        tb_IIIe64.Visible = false;
                        tb_IIIe65.Visible = false;
                        tb_IIIe66.Visible = false;
                        tb_IIIe67.Visible = false;
                        tb_IIIe68.Visible = false;
                        tb_IIIe69.Visible = false;
                        tb_IIIe610.Visible = false;
                        tb_IIIe611.Visible = false;
                        tb_IIIe612.Visible = false;
                        tb_IIIe613.Visible = false;
                        tb_IIIe614.Visible = false;
                        tb_IIIe615.Visible = false;
                        cuenta = 9;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 9;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        tb_IIIe61.Text = "";
                        tb_IIIe62.Text = "";
                        tb_IIIe63.Text = "";
                        tb_IIIe64.Text = "";
                        tb_IIIe65.Text = "";
                        tb_IIIe66.Text = "";
                        tb_IIIe67.Text = "";
                        tb_IIIe68.Text = "";
                        tb_IIIe69.Text = "";
                        tb_IIIe610.Text = "";
                        tb_IIIe611.Text = "";
                        tb_IIIe612.Text = "";
                        tb_IIIe613.Text = "";
                        tb_IIIe614.Text = "";
                        tb_IIIe615.Text = "";
                        radioG1.Checked = false;
                        radioG2.Checked = false;
                        radioG3.Checked = false;
                        radioG4.Checked = false;
                        radioG5.Checked = false;
                        radioG6.Checked = false;
                        radioG7.Checked = false;
                        radioG8.Checked = false;
                        radioG9.Checked = false;
                        radioG10.Checked = false;
                        radioG11.Checked = false;
                        radioG12.Checked = false;
                        radioG13.Checked = false;
                        radioG14.Checked = false;
                        radioG15.Checked = false;
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(15);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom12(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 10:
                    if (Convert.ToInt32(HttpContext.Current.Session["anos"].ToString()) < 5)
                    {
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        actual++;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        if (actual < Gvresulta.Rows.Count)
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            p2++;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            int j = 0;
                            foreach (int i in regreso)
                            {
                                regreso[j] = 0;
                                j++;
                            }
                            HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados corresponderán a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                            //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup3.Show();
                            Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            abrecom4q6(Page);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //cierrabot1(Page);
                        }
                        else
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            actual = 0;
                            HttpContext.Current.Session["actual"] = actual.ToString();
                            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                            p2 = 1;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //Label18.Text = "Guardado de datos";
                            Guardar(1, 1);
                            Label19.Text = "¡Usted ha concluido el cuestionario y se ha enviado exitosamente!";
                            abrecom4q3(Page);
                            cierrabot1(Page);
                        }
                    }
                    //else if (tb_IIIe61.Text == "" && tb_IIIe62.Text == "" && tb_IIIe63.Text == "" && tb_IIIe64.Text == "" && tb_IIIe65.Text == "" && tb_IIIe66.Text == "" && tb_IIIe67.Text == "" && tb_IIIe68.Text == "" && tb_IIIe69.Text == "" && tb_IIIe610.Text == "" && tb_IIIe611.Text == "" && tb_IIIe612.Text == "" && tb_IIIe613.Text == "" && tb_IIIe614.Text == "" && tb_IIIe615.Text == "" && regreso[12] == 0)
                    else if (radioG1.Checked == false && radioG2.Checked == false && radioG3.Checked == false && radioG4.Checked == false && radioG5.Checked == false && radioG6.Checked == false && radioG7.Checked == false && radioG8.Checked == false && radioG9.Checked == false && radioG10.Checked == false && radioG11.Checked == false && radioG12.Checked == false && radioG13.Checked == false && radioG14.Checked == false && radioG15.Checked == false && regreso[12] == 0)
                    {
                        regreso[12] = 1;
                        cuenta = 9;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        p1 = 9;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(15);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom12(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else if (radioG2.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe62.Text) ? tb_IIIe62.Text = "0" : tb_IIIe62.Text) > 3)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Preescolar o kinder es 3";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe62.Text == "0")
                            {
                                tb_IIIe62.Text = "";
                            }
                            cuenta = 10;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 10;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(16);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom13(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG3.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe63.Text) ? tb_IIIe63.Text = "0" : tb_IIIe63.Text) > 6)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Primaria es 6";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe63.Text == "0")
                            {
                                tb_IIIe63.Text = "";
                            }
                            cuenta = 10;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 10;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(16);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom13(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG4.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe64.Text) ? tb_IIIe64.Text = "0" : tb_IIIe64.Text) > 3)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Secundaria es 3";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe64.Text == "0")
                            {
                                tb_IIIe64.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG5.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe65.Text) ? tb_IIIe65.Text = "0" : tb_IIIe65.Text) > 4)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Preparatoria o bachillerato general es 4";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe65.Text == "0")
                            {
                                tb_IIIe65.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG6.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe66.Text) ? tb_IIIe66.Text = "0" : tb_IIIe66.Text) > 4)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Bachillerato tecnológico es 4";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe66.Text == "0")
                            {
                                tb_IIIe66.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG7.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe67.Text) ? tb_IIIe67.Text = "0" : tb_IIIe67.Text) > 4)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Estudios técnicos o comerciales con primaria terminada es 4";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe67.Text == "0")
                            {
                                tb_IIIe67.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG8.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe68.Text) ? tb_IIIe68.Text = "0" : tb_IIIe68.Text) > 5)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Estudios técnicos o comerciales con secundaria terminada es 5";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe68.Text == "0")
                            {
                                tb_IIIe68.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG9.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe69.Text) ? tb_IIIe69.Text = "0" : tb_IIIe69.Text) > 4)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Estudios técnicos o comerciales con preparatoria terminada es 4";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe69.Text == "0")
                            {
                                tb_IIIe69.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG10.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe610.Text) ? tb_IIIe610.Text = "0" : tb_IIIe610.Text) > 4)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Normal con primaria o secundaria terminada es 4";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe610.Text == "0")
                            {
                                tb_IIIe610.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG11.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe611.Text) ? tb_IIIe611.Text = "0" : tb_IIIe611.Text) > 4)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Normal de licenciatura es 4";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe611.Text == "0")
                            {
                                tb_IIIe611.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG12.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe612.Text) ? tb_IIIe612.Text = "0" : tb_IIIe612.Text) > 8)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Licenciatura es 8";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe612.Text == "0")
                            {
                                tb_IIIe612.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG13.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe613.Text) ? tb_IIIe613.Text = "0" : tb_IIIe613.Text) > 2)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Especialidad es 2";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe613.Text == "0")
                            {
                                tb_IIIe613.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG14.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe614.Text) ? tb_IIIe614.Text = "0" : tb_IIIe614.Text) > 3)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Maestría es 3";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe614.Text == "0")
                            {
                                tb_IIIe614.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    else if (radioG15.Checked == true)
                    {
                        if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIIe615.Text) ? tb_IIIe615.Text = "0" : tb_IIIe615.Text) > 6)
                        {
                            regreso[12] = 0;
                            cuenta = 9;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                            Label17.Text = "Aviso";
                            Label10.Text = "El grado máximo para Doctorado es 6";
                            programmaticModalPopup.Show();
                            p1 = 9;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(15);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom12(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            if (tb_IIIe615.Text == "0")
                            {
                                tb_IIIe615.Text = "";
                            }
                            cuenta = 11;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 11;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(17);
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1301(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                    }
                    //else if (tb_IIIe64.Text != "" || tb_IIIe65.Text != "" || tb_IIIe66.Text != "" || tb_IIIe67.Text != "" || tb_IIIe68.Text != "" || tb_IIIe69.Text != "" || tb_IIIe610.Text != "" || tb_IIIe611.Text != "" || tb_IIIe612.Text != "" || tb_IIIe613.Text != "" || tb_IIIe614.Text != "" || tb_IIIe615.Text != "")
                    else if (radioG4.Checked != false || radioG5.Checked != false || radioG6.Checked != false || radioG7.Checked != false || radioG8.Checked != false || radioG9.Checked != false || radioG10.Checked != false || radioG11.Checked != false || radioG12.Checked != false || radioG13.Checked != false || radioG14.Checked != false || radioG15.Checked != false)
                    {
                        cuenta = 11;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 11;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(17);
                        radioH1.Checked = false;
                        radioH2.Checked = false;
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1301(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 10;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 10;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(16);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom13(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 11:
                    if (radioH1.Checked == false && radioH2.Checked == false && regreso[13] == 0)
                    {
                        regreso[13] = 1;
                        cuenta = 10;
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 10;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 10;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(16);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom13(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 11;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 11;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(17);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1301(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 12:
                    if (Convert.ToInt32(HttpContext.Current.Session["anos"].ToString()) < 12)
                    {
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        actual++;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        if (actual < Gvresulta.Rows.Count)
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            p2++;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            int j = 0;
                            foreach (int i in regreso)
                            {
                                regreso[j] = 0;
                                j++;
                            }
                            HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados corresponderán a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                            //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup3.Show();
                            Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            abrecom4q6(Page);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //cierrabot1(Page);
                        }
                        else
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            actual = 0;
                            HttpContext.Current.Session["actual"] = actual.ToString();
                            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                            p2 = 1;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //Label18.Text = "Guardado de datos";
                            Guardar(1, 1);
                            Label19.Text = "¡Usted ha concluido el cuestionario y se ha enviado exitosamente!";
                            abrecom4q3(Page);
                            cierrabot1(Page);
                        }
                    }
                    else if (radioC1301.Checked == false && radioC1303.Checked == false && tb_IIIe1302.Text == "" && tb_IIIe1304.Text == "" && regreso[14] == 0)
                    {
                        regreso[14] = 1;
                        cuenta = 11;
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 11;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 11;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(17);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1301(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else if (radioC1301.Checked == false && radioC1303.Checked == false && tb_IIIe1304.Text == "" && tb_IIIe1302.Text.Length < 3 && regreso[14] == 0)
                    {
                        regreso[14] = 0;
                        mensaje(Page, "El campo en otro estado debe de tener un mínimo de 3 caracteres");
                        cuenta = 11;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 11;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(17);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1301(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else if (radioC1301.Checked == false && radioC1303.Checked == false && tb_IIIe1302.Text == "" && tb_IIIe1304.Text.Length < 3 && regreso[14] == 0)
                    {
                        regreso[14] = 0;
                        mensaje(Page, "El campo en otro país debe de tener un mínimo de 3 caracteres");
                        cuenta = 11;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 11;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(17);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1301(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        cuenta = 12;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 12;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(18);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1302(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 13:
                    //actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                    //actual++;
                    //HttpContext.Current.Session["actual"] = actual.ToString();
                    //actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                    if (radioC13021.Checked == false && radioC13022.Checked == false && radioC13023.Checked == false && radioC13024.Checked == false && radioC13025.Checked == false && radioC13026.Checked == false && radioC13027.Checked == false && radioC13028.Checked == false && regreso[15] == 0)
                    {
                        regreso[15] = 1;
                        cuenta = 12;
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 12;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 12;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(18);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1302(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        //actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        //actual--;
                        //HttpContext.Current.Session["actual"] = actual.ToString();
                        //actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        cuenta = 13;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 13;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(19);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1401(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;

                case 14:
                    actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                    //Guardar(5, Convert.ToInt32(Gvresulta.Rows[actual].Cells[0].Text));
                    actual++;
                    HttpContext.Current.Session["actual"] = actual.ToString();
                    actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                    if (radioI101.Checked == false && radioI102.Checked == false && regreso[16] == 0)
                    {
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        actual--;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        regreso[16] = 1;
                        cuenta = 13;
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 13;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 13;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(19);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1401(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else if (radioI101.Checked == true && actual >= Gvresulta.Rows.Count)
                    {
                        Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                        cuenta = 1;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        actual = 0;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        p2 = 1;
                        HttpContext.Current.Session["p2"] = p2.ToString();
                        p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                        p1 = 1;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(7);
                        lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                                                                                                                                       //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        //radioC1.Checked = false;
                        //radioC2.Checked = false;
                        //radioC3.Checked = false;
                        //radioC4.Checked = false;
                        //radioC5.Checked = false;
                        //radioC6.Checked = false;
                        //radioC7.Checked = false;
                        //radioC8.Checked = false;
                        CheckBox1.Enabled = true;
                        CheckBox2.Enabled = true;
                        CheckBox3.Enabled = true;
                        CheckBox4.Enabled = true;
                        CheckBox5.Enabled = true;
                        CheckBox6.Enabled = true;
                        CheckBox7.Enabled = true;
                        CheckBox8.Enabled = true;
                        CheckBox1.Checked = false;
                        CheckBox2.Checked = false;
                        CheckBox3.Checked = false;
                        CheckBox4.Checked = false;
                        CheckBox5.Checked = false;
                        CheckBox6.Checked = false;
                        CheckBox7.Checked = false;
                        CheckBox8.Checked = false;
                        //radioC1011.Checked = false;
                        //radioC1012.Checked = false;
                        //radioC1013.Checked = false;
                        //radioC1014.Checked = false;
                        radioC1001.Checked = false;
                        radioC1002.Checked = false;
                        tb_IIIe1002.Text = "";
                        tb_IIIe1002.Visible = false;
                        radioC1003.Checked = false;
                        radioC1004.Checked = false;
                        tb_IIIe1004.Text = "";
                        tb_IIIe1004.Visible = false;
                        tb_IIIe1021.Text = "";
                        radioC1031.Checked = false;
                        //radioC1032.Checked = false;
                        radioC1033.Checked = false;
                        //radioC1034.Checked = false;
                        radioD1.Checked = false;
                        radioD2.Checked = false;
                        tb_IIIe31.Text = "";
                        radioE1.Checked = false;
                        radioE2.Checked = false;
                        radioF1.Checked = false;
                        radioF2.Checked = false;
                        radioG1.Checked = false;
                        radioG2.Checked = false;
                        radioG3.Checked = false;
                        radioG4.Checked = false;
                        radioG5.Checked = false;
                        radioG6.Checked = false;
                        radioG7.Checked = false;
                        radioG8.Checked = false;
                        radioG9.Checked = false;
                        radioG10.Checked = false;
                        radioG11.Checked = false;
                        radioG12.Checked = false;
                        radioG13.Checked = false;
                        radioG14.Checked = false;
                        radioG15.Checked = false;
                        tb_IIIe61.Text = "";
                        tb_IIIe62.Text = "";
                        tb_IIIe63.Text = "";
                        tb_IIIe64.Text = "";
                        tb_IIIe65.Text = "";
                        tb_IIIe66.Text = "";
                        tb_IIIe67.Text = "";
                        tb_IIIe68.Text = "";
                        tb_IIIe69.Text = "";
                        tb_IIIe610.Text = "";
                        tb_IIIe611.Text = "";
                        tb_IIIe612.Text = "";
                        tb_IIIe613.Text = "";
                        tb_IIIe614.Text = "";
                        tb_IIIe615.Text = "";
                        radioH1.Checked = false;
                        radioH2.Checked = false;
                        radioC1301.Checked = false;
                        radioC1302.Checked = false;
                        tb_IIIe1302.Text = "";
                        tb_IIIe1302.Visible = false;
                        radioC1303.Checked = false;
                        radioC1304.Checked = false;
                        tb_IIIe1304.Text = "";
                        tb_IIIe1304.Visible = false;
                        radioC13021.Checked = false;
                        radioC13022.Checked = false;
                        radioC13023.Checked = false;
                        radioC13024.Checked = false;
                        radioC13025.Checked = false;
                        radioC13026.Checked = false;
                        radioC13027.Checked = false;
                        radioC13028.Checked = false;
                        radioI101.Checked = false;
                        radioI102.Checked = false;
                        radioI1.Checked = false;
                        radioI2.Checked = false;
                        radioI3.Checked = false;
                        radioI4.Checked = false;
                        radioI5.Checked = false;
                        radioI6.Checked = false;
                        radioI7.Checked = false;
                        radioI8.Checked = false;
                        radioI121.Checked = false;
                        radioI122.Checked = false;
                        radioI123.Checked = false;
                        radioI124.Checked = false;
                        radioI125.Checked = false;
                        //Label17.Text = "Continúa la captura de personas";
                        //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                        //programmaticModalPopup.Show();
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        //abrecom6(Page);
                        //abrecom7(Page);
                        //abrecom100(Page);
                        //Label18.Text = "Guardado de datos";
                        Guardar(1, 1);
                        Label19.Text = "¡Usted ha concluido el cuestionario y se ha enviado exitosamente!";
                        abrecom4q3(Page);
                        cierrabot1(Page);
                    }
                    else if (radioI101.Checked == true && actual < Gvresulta.Rows.Count)
                    {
                        Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                        cuenta = 1;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 1;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        p2++;
                        HttpContext.Current.Session["p2"] = p2.ToString();
                        p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(7);
                        int j = 0;
                        foreach (int i in regreso)
                        {
                            regreso[j] = 0;
                            j++;
                        }
                        HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                        lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                                                                                                                                       //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                       //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                        //radioC1.Checked = false;
                        //radioC2.Checked = false;
                        //radioC3.Checked = false;
                        //radioC4.Checked = false;
                        //radioC5.Checked = false;
                        //radioC6.Checked = false;
                        //radioC7.Checked = false;
                        //radioC8.Checked = false;
                        CheckBox1.Enabled = true;
                        CheckBox2.Enabled = true;
                        CheckBox3.Enabled = true;
                        CheckBox4.Enabled = true;
                        CheckBox5.Enabled = true;
                        CheckBox6.Enabled = true;
                        CheckBox7.Enabled = true;
                        CheckBox8.Enabled = true;
                        CheckBox1.Checked = false;
                        CheckBox2.Checked = false;
                        CheckBox3.Checked = false;
                        CheckBox4.Checked = false;
                        CheckBox5.Checked = false;
                        CheckBox6.Checked = false;
                        CheckBox7.Checked = false;
                        CheckBox8.Checked = false;
                        //radioC1011.Checked = false;
                        //radioC1012.Checked = false;
                        //radioC1013.Checked = false;
                        //radioC1014.Checked = false;
                        radioC1001.Checked = false;
                        radioC1002.Checked = false;
                        tb_IIIe1002.Text = "";
                        tb_IIIe1002.Visible = false;
                        radioC1003.Checked = false;
                        radioC1004.Checked = false;
                        tb_IIIe1004.Text = "";
                        tb_IIIe1004.Visible = false;
                        tb_IIIe1021.Text = "";
                        radioC1031.Checked = false;
                        //radioC1032.Checked = false;
                        radioC1033.Checked = false;
                        //radioC1034.Checked = false;
                        radioD1.Checked = false;
                        radioD2.Checked = false;
                        tb_IIIe31.Text = "";
                        radioE1.Checked = false;
                        radioE2.Checked = false;
                        radioF1.Checked = false;
                        radioF2.Checked = false;
                        radioG1.Checked = false;
                        radioG2.Checked = false;
                        radioG3.Checked = false;
                        radioG4.Checked = false;
                        radioG5.Checked = false;
                        radioG6.Checked = false;
                        radioG7.Checked = false;
                        radioG8.Checked = false;
                        radioG9.Checked = false;
                        radioG10.Checked = false;
                        radioG11.Checked = false;
                        radioG12.Checked = false;
                        radioG13.Checked = false;
                        radioG14.Checked = false;
                        radioG15.Checked = false;
                        tb_IIIe61.Text = "";
                        tb_IIIe62.Text = "";
                        tb_IIIe63.Text = "";
                        tb_IIIe64.Text = "";
                        tb_IIIe65.Text = "";
                        tb_IIIe66.Text = "";
                        tb_IIIe67.Text = "";
                        tb_IIIe68.Text = "";
                        tb_IIIe69.Text = "";
                        tb_IIIe610.Text = "";
                        tb_IIIe611.Text = "";
                        tb_IIIe612.Text = "";
                        tb_IIIe613.Text = "";
                        tb_IIIe614.Text = "";
                        tb_IIIe615.Text = "";
                        radioH1.Checked = false;
                        radioH2.Checked = false;
                        radioC1301.Checked = false;
                        radioC1302.Checked = false;
                        tb_IIIe1302.Text = "";
                        tb_IIIe1302.Visible = false;
                        radioC1303.Checked = false;
                        radioC1304.Checked = false;
                        tb_IIIe1304.Text = "";
                        tb_IIIe1304.Visible = false;
                        radioC13021.Checked = false;
                        radioC13022.Checked = false;
                        radioC13023.Checked = false;
                        radioC13024.Checked = false;
                        radioC13025.Checked = false;
                        radioC13026.Checked = false;
                        radioC13027.Checked = false;
                        radioC13028.Checked = false;
                        radioI101.Checked = false;
                        radioI102.Checked = false;
                        radioI1.Checked = false;
                        radioI2.Checked = false;
                        radioI3.Checked = false;
                        radioI4.Checked = false;
                        radioI5.Checked = false;
                        radioI6.Checked = false;
                        radioI7.Checked = false;
                        radioI8.Checked = false;
                        radioI121.Checked = false;
                        radioI122.Checked = false;
                        radioI123.Checked = false;
                        radioI124.Checked = false;
                        radioI125.Checked = false;
                        //Label17.Text = "Continúa la captura de personas";
                        //Label10.Text = "Ahora los datos solicitados corresponderán a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                        //programmaticModalPopup.Show();
                        //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                        //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                        //programmaticModalPopup3.Show();
                        Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                        abrecom4q6(Page);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        //abrecom6(Page);
                        //abrecom7(Page);
                        //abrecom100(Page);
                        //cierrabot1(Page);
                    }
                    else
                    {
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        actual--;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        cuenta = 14;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 14;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(20);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom1403(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom14(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    break;
                case 15:
                    if (radioI1.Checked == false && radioI2.Checked == false && radioI3.Checked == false && radioI4.Checked == false && radioI5.Checked == false && radioI6.Checked == false && radioI7.Checked == false && radioI8.Checked == false && regreso[17] == 0)
                    {
                        regreso[17] = 1;
                        cuenta = 14;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 14;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 14;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(20);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom14(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        //evaluar que sea solo radioI8
                        //if (radioI8.Checked == true)
                        //evaluar que sea solo radioI8 o blanco
                        if (radioI8.Checked == true || regreso[17] == 1)
                        {
                            cuenta = 15;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 15;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(21);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            abrecom6(Page);
                            abrecom1403(Page);
                            abrecom100(Page);
                            abrebot1(Page);
                        }
                        else
                        {
                            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                            //Guardar(5, Convert.ToInt32(Gvresulta.Rows[actual].Cells[0].Text));
                            actual++;
                            HttpContext.Current.Session["actual"] = actual.ToString();
                            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                            if (radioI8.Checked != true && actual >= Gvresulta.Rows.Count)
                            {
                                Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                                cuenta = 1;
                                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                                actual = 0;
                                HttpContext.Current.Session["actual"] = actual.ToString();
                                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                                p2 = 1;
                                HttpContext.Current.Session["p2"] = p2.ToString();
                                p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                                p1 = 1;
                                HttpContext.Current.Session["p1"] = p1.ToString();
                                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                                Avance_barra(1);
                                ayuda01a.Attributes["data-content"] = leer_xml(7);
                                lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                                                                                                                                               //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                //radioC1.Checked = false;
                                //radioC2.Checked = false;
                                //radioC3.Checked = false;
                                //radioC4.Checked = false;
                                //radioC5.Checked = false;
                                //radioC6.Checked = false;
                                //radioC7.Checked = false;
                                //radioC8.Checked = false;
                                CheckBox1.Enabled = true;
                                CheckBox2.Enabled = true;
                                CheckBox3.Enabled = true;
                                CheckBox4.Enabled = true;
                                CheckBox5.Enabled = true;
                                CheckBox6.Enabled = true;
                                CheckBox7.Enabled = true;
                                CheckBox8.Enabled = true;
                                CheckBox1.Checked = false;
                                CheckBox2.Checked = false;
                                CheckBox3.Checked = false;
                                CheckBox4.Checked = false;
                                CheckBox5.Checked = false;
                                CheckBox6.Checked = false;
                                CheckBox7.Checked = false;
                                CheckBox8.Checked = false;
                                //radioC1011.Checked = false;
                                //radioC1012.Checked = false;
                                //radioC1013.Checked = false;
                                //radioC1014.Checked = false;
                                radioC1001.Checked = false;
                                radioC1002.Checked = false;
                                tb_IIIe1002.Text = "";
                                tb_IIIe1002.Visible = false;
                                radioC1003.Checked = false;
                                radioC1004.Checked = false;
                                tb_IIIe1004.Text = "";
                                tb_IIIe1004.Visible = false;
                                tb_IIIe1021.Text = "";
                                radioC1031.Checked = false;
                                //radioC1032.Checked = false;
                                radioC1033.Checked = false;
                                //radioC1034.Checked = false;
                                radioD1.Checked = false;
                                radioD2.Checked = false;
                                tb_IIIe31.Text = "";
                                radioE1.Checked = false;
                                radioE2.Checked = false;
                                radioF1.Checked = false;
                                radioF2.Checked = false;
                                radioG1.Checked = false;
                                radioG2.Checked = false;
                                radioG3.Checked = false;
                                radioG4.Checked = false;
                                radioG5.Checked = false;
                                radioG6.Checked = false;
                                radioG7.Checked = false;
                                radioG8.Checked = false;
                                radioG9.Checked = false;
                                radioG10.Checked = false;
                                radioG11.Checked = false;
                                radioG12.Checked = false;
                                radioG13.Checked = false;
                                radioG14.Checked = false;
                                radioG15.Checked = false;
                                tb_IIIe61.Text = "";
                                tb_IIIe62.Text = "";
                                tb_IIIe63.Text = "";
                                tb_IIIe64.Text = "";
                                tb_IIIe65.Text = "";
                                tb_IIIe66.Text = "";
                                tb_IIIe67.Text = "";
                                tb_IIIe68.Text = "";
                                tb_IIIe69.Text = "";
                                tb_IIIe610.Text = "";
                                tb_IIIe611.Text = "";
                                tb_IIIe612.Text = "";
                                tb_IIIe613.Text = "";
                                tb_IIIe614.Text = "";
                                tb_IIIe615.Text = "";
                                radioH1.Checked = false;
                                radioH2.Checked = false;
                                radioC1301.Checked = false;
                                radioC1302.Checked = false;
                                tb_IIIe1302.Text = "";
                                tb_IIIe1302.Visible = false;
                                radioC1303.Checked = false;
                                radioC1304.Checked = false;
                                tb_IIIe1304.Text = "";
                                tb_IIIe1304.Visible = false;
                                radioC13021.Checked = false;
                                radioC13022.Checked = false;
                                radioC13023.Checked = false;
                                radioC13024.Checked = false;
                                radioC13025.Checked = false;
                                radioC13026.Checked = false;
                                radioC13027.Checked = false;
                                radioC13028.Checked = false;
                                radioI101.Checked = false;
                                radioI102.Checked = false;
                                radioI1.Checked = false;
                                radioI2.Checked = false;
                                radioI3.Checked = false;
                                radioI4.Checked = false;
                                radioI5.Checked = false;
                                radioI6.Checked = false;
                                radioI7.Checked = false;
                                radioI8.Checked = false;
                                radioI121.Checked = false;
                                radioI122.Checked = false;
                                radioI123.Checked = false;
                                radioI124.Checked = false;
                                radioI125.Checked = false;
                                //Label17.Text = "Continúa la captura de personas";
                                //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                //programmaticModalPopup.Show();
                                cierracom2(Page);
                                cierracom3a(Page);
                                cierracom4(Page);
                                cierracom5(Page);
                                cierracom6(Page);
                                cierracom700(Page);
                                cierracom7(Page);
                                cierracom702(Page);
                                cierracom703(Page);
                                cierracom8(Page);
                                cierracom9(Page);
                                cierracom10(Page);
                                cierracom11(Page);
                                cierracom12(Page);
                                cierracom13(Page);
                                cierracom1301(Page);
                                cierracom1302(Page);
                                cierracom1401(Page);
                                cierracom14(Page);
                                cierracom1403(Page);
                                cierracom100(Page);
                                //abrecom6(Page);
                                //abrecom7(Page);
                                //abrecom100(Page);
                                //Label18.Text = "Guardado de datos";
                                Guardar(1, 1);
                                Label19.Text = "¡Usted ha concluido el cuestionario y se ha enviado exitosamente!";
                                abrecom4q3(Page);
                                cierrabot1(Page);
                            }
                            else if (radioI8.Checked != true && actual < Gvresulta.Rows.Count)
                            {
                                Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                                cuenta = 1;
                                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                                p1 = 1;
                                HttpContext.Current.Session["p1"] = p1.ToString();
                                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                                p2++;
                                HttpContext.Current.Session["p2"] = p2.ToString();
                                p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                                Avance_barra(1);
                                ayuda01a.Attributes["data-content"] = leer_xml(7);
                                int j = 0;
                                foreach (int i in regreso)
                                {
                                    regreso[j] = 0;
                                    j++;
                                }
                                HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                                lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                                                                                                                                               //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                                               //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                                //radioC1.Checked = false;
                                //radioC2.Checked = false;
                                //radioC3.Checked = false;
                                //radioC4.Checked = false;
                                //radioC5.Checked = false;
                                //radioC6.Checked = false;
                                //radioC7.Checked = false;
                                //radioC8.Checked = false;
                                CheckBox1.Enabled = true;
                                CheckBox2.Enabled = true;
                                CheckBox3.Enabled = true;
                                CheckBox4.Enabled = true;
                                CheckBox5.Enabled = true;
                                CheckBox6.Enabled = true;
                                CheckBox7.Enabled = true;
                                CheckBox8.Enabled = true;
                                CheckBox1.Checked = false;
                                CheckBox2.Checked = false;
                                CheckBox3.Checked = false;
                                CheckBox4.Checked = false;
                                CheckBox5.Checked = false;
                                CheckBox6.Checked = false;
                                CheckBox7.Checked = false;
                                CheckBox8.Checked = false;
                                //radioC1011.Checked = false;
                                //radioC1012.Checked = false;
                                //radioC1013.Checked = false;
                                //radioC1014.Checked = false;
                                radioC1001.Checked = false;
                                radioC1002.Checked = false;
                                tb_IIIe1002.Text = "";
                                tb_IIIe1002.Visible = false;
                                radioC1003.Checked = false;
                                radioC1004.Checked = false;
                                tb_IIIe1004.Text = "";
                                tb_IIIe1004.Visible = false;
                                tb_IIIe1021.Text = "";
                                radioC1031.Checked = false;
                                //radioC1032.Checked = false;
                                radioC1033.Checked = false;
                                //radioC1034.Checked = false;
                                radioD1.Checked = false;
                                radioD2.Checked = false;
                                tb_IIIe31.Text = "";
                                radioE1.Checked = false;
                                radioE2.Checked = false;
                                radioF1.Checked = false;
                                radioF2.Checked = false;
                                radioG1.Checked = false;
                                radioG2.Checked = false;
                                radioG3.Checked = false;
                                radioG4.Checked = false;
                                radioG5.Checked = false;
                                radioG6.Checked = false;
                                radioG7.Checked = false;
                                radioG8.Checked = false;
                                radioG9.Checked = false;
                                radioG10.Checked = false;
                                radioG11.Checked = false;
                                radioG12.Checked = false;
                                radioG13.Checked = false;
                                radioG14.Checked = false;
                                radioG15.Checked = false;
                                tb_IIIe61.Text = "";
                                tb_IIIe62.Text = "";
                                tb_IIIe63.Text = "";
                                tb_IIIe64.Text = "";
                                tb_IIIe65.Text = "";
                                tb_IIIe66.Text = "";
                                tb_IIIe67.Text = "";
                                tb_IIIe68.Text = "";
                                tb_IIIe69.Text = "";
                                tb_IIIe610.Text = "";
                                tb_IIIe611.Text = "";
                                tb_IIIe612.Text = "";
                                tb_IIIe613.Text = "";
                                tb_IIIe614.Text = "";
                                tb_IIIe615.Text = "";
                                radioH1.Checked = false;
                                radioH2.Checked = false;
                                radioC1301.Checked = false;
                                radioC1302.Checked = false;
                                tb_IIIe1302.Text = "";
                                tb_IIIe1302.Visible = false;
                                radioC1303.Checked = false;
                                radioC1304.Checked = false;
                                tb_IIIe1304.Text = "";
                                tb_IIIe1304.Visible = false;
                                radioC13021.Checked = false;
                                radioC13022.Checked = false;
                                radioC13023.Checked = false;
                                radioC13024.Checked = false;
                                radioC13025.Checked = false;
                                radioC13026.Checked = false;
                                radioC13027.Checked = false;
                                radioC13028.Checked = false;
                                radioI101.Checked = false;
                                radioI102.Checked = false;
                                radioI1.Checked = false;
                                radioI2.Checked = false;
                                radioI3.Checked = false;
                                radioI4.Checked = false;
                                radioI5.Checked = false;
                                radioI6.Checked = false;
                                radioI7.Checked = false;
                                radioI8.Checked = false;
                                radioI121.Checked = false;
                                radioI122.Checked = false;
                                radioI123.Checked = false;
                                radioI124.Checked = false;
                                radioI125.Checked = false;
                                //Label17.Text = "Continúa la captura de personas";
                                //Label10.Text = "Ahora los datos solicitados corresponderán a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                //programmaticModalPopup.Show();
                                //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                                //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                //programmaticModalPopup3.Show();
                                Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                abrecom4q6(Page);
                                cierracom2(Page);
                                cierracom3a(Page);
                                cierracom4(Page);
                                cierracom5(Page);
                                cierracom6(Page);
                                cierracom700(Page);
                                cierracom7(Page);
                                cierracom702(Page);
                                cierracom703(Page);
                                cierracom8(Page);
                                cierracom9(Page);
                                cierracom10(Page);
                                cierracom11(Page);
                                cierracom12(Page);
                                cierracom13(Page);
                                cierracom1301(Page);
                                cierracom1302(Page);
                                cierracom1401(Page);
                                cierracom14(Page);
                                cierracom1403(Page);
                                cierracom100(Page);
                                //abrecom6(Page);
                                //abrecom7(Page);
                                //abrecom100(Page);
                                //cierrabot1(Page);
                            }
                        }
                    }
                    break;
                default:
                    if (radioI121.Checked == false && radioI122.Checked == false && radioI123.Checked == false && radioI124.Checked == false && radioI125.Checked == false && regreso[18] == 0)
                    {
                        regreso[18] = 1;
                        cuenta = 15;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        //mensaje(Page, "No se debe dejar la pregunta sin respuesta");
                        Label17.Text = "Aviso";
                        Label10.Text = "No proporcionó respuesta a esta pregunta";
                        programmaticModalPopup.Show();
                        cuenta = 15;
                        HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                        cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                        p1 = 15;
                        HttpContext.Current.Session["p1"] = p1.ToString();
                        p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                        Avance_barra(1);
                        ayuda01a.Attributes["data-content"] = leer_xml(21);
                        cierracom2(Page);
                        cierracom3a(Page);
                        cierracom4(Page);
                        cierracom5(Page);
                        cierracom6(Page);
                        cierracom700(Page);
                        cierracom7(Page);
                        cierracom702(Page);
                        cierracom703(Page);
                        cierracom8(Page);
                        cierracom9(Page);
                        cierracom10(Page);
                        cierracom11(Page);
                        cierracom12(Page);
                        cierracom13(Page);
                        cierracom1301(Page);
                        cierracom1302(Page);
                        cierracom1401(Page);
                        cierracom14(Page);
                        cierracom100(Page);
                        abrecom6(Page);
                        abrecom1403(Page);
                        abrecom100(Page);
                        abrebot1(Page);
                    }
                    else
                    {
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        actual++;
                        HttpContext.Current.Session["actual"] = actual.ToString();
                        actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                        if (actual < Gvresulta.Rows.Count)
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2 - 1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            p2++;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            int j = 0;
                            foreach (int i in regreso)
                            {
                                regreso[j] = 0;
                                j++;
                            }
                            HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados corresponderán a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                            //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup3.Show();
                            Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            abrecom4q6(Page);
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //cierrabot1(Page);
                        }
                        else
                        {
                            Guardar(5, Convert.ToInt32(Gvresulta.Rows[p2-1].Cells[0].Text));
                            cuenta = 1;
                            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                            actual = 0;
                            HttpContext.Current.Session["actual"] = actual.ToString();
                            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                            p2 = 1;
                            HttpContext.Current.Session["p2"] = p2.ToString();
                            p2 = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                            p1 = 1;
                            HttpContext.Current.Session["p1"] = p1.ToString();
                            p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                            Avance_barra(1);
                            ayuda01a.Attributes["data-content"] = leer_xml(7);
                            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                            //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                            //radioC1.Checked = false;
                            //radioC2.Checked = false;
                            //radioC3.Checked = false;
                            //radioC4.Checked = false;
                            //radioC5.Checked = false;
                            //radioC6.Checked = false;
                            //radioC7.Checked = false;
                            //radioC8.Checked = false;
                            CheckBox1.Enabled = true;
                            CheckBox2.Enabled = true;
                            CheckBox3.Enabled = true;
                            CheckBox4.Enabled = true;
                            CheckBox5.Enabled = true;
                            CheckBox6.Enabled = true;
                            CheckBox7.Enabled = true;
                            CheckBox8.Enabled = true;
                            CheckBox1.Checked = false;
                            CheckBox2.Checked = false;
                            CheckBox3.Checked = false;
                            CheckBox4.Checked = false;
                            CheckBox5.Checked = false;
                            CheckBox6.Checked = false;
                            CheckBox7.Checked = false;
                            CheckBox8.Checked = false;
                            //radioC1011.Checked = false;
                            //radioC1012.Checked = false;
                            //radioC1013.Checked = false;
                            //radioC1014.Checked = false;
                            radioC1001.Checked = false;
                            radioC1002.Checked = false;
                            tb_IIIe1002.Text = "";
                            tb_IIIe1002.Visible = false;
                            radioC1003.Checked = false;
                            radioC1004.Checked = false;
                            tb_IIIe1004.Text = "";
                            tb_IIIe1004.Visible = false;
                            tb_IIIe1021.Text = "";
                            radioC1031.Checked = false;
                            //radioC1032.Checked = false;
                            radioC1033.Checked = false;
                            //radioC1034.Checked = false;
                            radioD1.Checked = false;
                            radioD2.Checked = false;
                            tb_IIIe31.Text = "";
                            radioE1.Checked = false;
                            radioE2.Checked = false;
                            radioF1.Checked = false;
                            radioF2.Checked = false;
                            radioG1.Checked = false;
                            radioG2.Checked = false;
                            radioG3.Checked = false;
                            radioG4.Checked = false;
                            radioG5.Checked = false;
                            radioG6.Checked = false;
                            radioG7.Checked = false;
                            radioG8.Checked = false;
                            radioG9.Checked = false;
                            radioG10.Checked = false;
                            radioG11.Checked = false;
                            radioG12.Checked = false;
                            radioG13.Checked = false;
                            radioG14.Checked = false;
                            radioG15.Checked = false;
                            tb_IIIe61.Text = "";
                            tb_IIIe62.Text = "";
                            tb_IIIe63.Text = "";
                            tb_IIIe64.Text = "";
                            tb_IIIe65.Text = "";
                            tb_IIIe66.Text = "";
                            tb_IIIe67.Text = "";
                            tb_IIIe68.Text = "";
                            tb_IIIe69.Text = "";
                            tb_IIIe610.Text = "";
                            tb_IIIe611.Text = "";
                            tb_IIIe612.Text = "";
                            tb_IIIe613.Text = "";
                            tb_IIIe614.Text = "";
                            tb_IIIe615.Text = "";
                            radioH1.Checked = false;
                            radioH2.Checked = false;
                            radioC1301.Checked = false;
                            radioC1302.Checked = false;
                            tb_IIIe1302.Text = "";
                            tb_IIIe1302.Visible = false;
                            radioC1303.Checked = false;
                            radioC1304.Checked = false;
                            tb_IIIe1304.Text = "";
                            tb_IIIe1304.Visible = false;
                            radioC13021.Checked = false;
                            radioC13022.Checked = false;
                            radioC13023.Checked = false;
                            radioC13024.Checked = false;
                            radioC13025.Checked = false;
                            radioC13026.Checked = false;
                            radioC13027.Checked = false;
                            radioC13028.Checked = false;
                            radioI101.Checked = false;
                            radioI102.Checked = false;
                            radioI1.Checked = false;
                            radioI2.Checked = false;
                            radioI3.Checked = false;
                            radioI4.Checked = false;
                            radioI5.Checked = false;
                            radioI6.Checked = false;
                            radioI7.Checked = false;
                            radioI8.Checked = false;
                            radioI121.Checked = false;
                            radioI122.Checked = false;
                            radioI123.Checked = false;
                            radioI124.Checked = false;
                            radioI125.Checked = false;
                            //Label17.Text = "Continúa la captura de personas";
                            //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                            //programmaticModalPopup.Show();
                            cierracom2(Page);
                            cierracom3a(Page);
                            cierracom4(Page);
                            cierracom5(Page);
                            cierracom6(Page);
                            cierracom700(Page);
                            cierracom7(Page);
                            cierracom702(Page);
                            cierracom703(Page);
                            cierracom8(Page);
                            cierracom9(Page);
                            cierracom10(Page);
                            cierracom11(Page);
                            cierracom12(Page);
                            cierracom13(Page);
                            cierracom1301(Page);
                            cierracom1302(Page);
                            cierracom1401(Page);
                            cierracom14(Page);
                            cierracom1403(Page);
                            cierracom100(Page);
                            //abrecom6(Page);
                            //abrecom7(Page);
                            //abrecom100(Page);
                            //Label18.Text = "Guardado de datos";
                            Guardar(1, 1);
                            Label19.Text = "¡Usted ha concluido el cuestionario y se ha enviado exitosamente!";
                            abrecom4q3(Page);
                            cierrabot1(Page);
                        }
                    }
                    break;
            }
            //ayuda01.Attributes["data-content"] = leer_xml(cuenta);
            //Avance_barra(1);
        }
        protected void guarda01_Click(object sender, EventArgs e)
        {
            //cierracom2(Page);
            //cierracom3(Page);
            //cierracom4(Page);
            //cierracom5(Page);
            //cierracom6(Page);
            //cierracom7(Page);
            //cierracom8(Page);
            //cierracom9(Page);
            //cierracom10(Page);
            //cierracom11(Page);
            //cierracom12(Page);
            //cierracom13(Page);
            //cierracom14(Page);
            //cierracom100(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom4(Page);
            abrecom5(Page);
            //tb_IIe21.Text = "";
            //radioA1.Checked = false;
            //radioA2.Checked = false;
            //tb_IIe23.Text = "";
            //radioB1.Checked = false;
            //radioB2.Checked = false;
            //radioB3.Checked = false;
            //radioB4.Checked = false;
            //radioB5.Checked = false;
            //radioB6.Checked = false;
            //radioB7.Checked = false;
            //radioB8.Checked = false;
            //radioB9.Checked = false;
            //radioC1.Checked = false;
            //radioC2.Checked = false;
            //radioC3.Checked = false;
            //radioC4.Checked = false;
            //radioC5.Checked = false;
            //radioC6.Checked = false;
            //radioC7.Checked = false;
            //radioC8.Checked = false;
            CheckBox1.Enabled = true;
            CheckBox2.Enabled = true;
            CheckBox3.Enabled = true;
            CheckBox4.Enabled = true;
            CheckBox5.Enabled = true;
            CheckBox6.Enabled = true;
            CheckBox7.Enabled = true;
            CheckBox8.Enabled = true;
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
            CheckBox6.Checked = false;
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;
            //radioC1011.Checked = false;
            //radioC1012.Checked = false;
            //radioC1013.Checked = false;
            //radioC1014.Checked = false;
            radioC1001.Checked = false;
            radioC1002.Checked = false;
            tb_IIIe1002.Text = "";
            tb_IIIe1002.Visible = false;
            radioC1003.Checked = false;
            radioC1004.Checked = false;
            tb_IIIe1004.Text = "";
            tb_IIIe1004.Visible = false;
            tb_IIIe1021.Text = "";
            radioC1031.Checked = false;
            //radioC1032.Checked = false;
            radioC1033.Checked = false;
            //radioC1034.Checked = false;
            radioD1.Checked = false;
            radioD2.Checked = false;
            tb_IIIe31.Text = "";
            radioE1.Checked = false;
            radioE2.Checked = false;
            radioF1.Checked = false;
            radioF2.Checked = false;
            radioG1.Checked = false;
            radioG2.Checked = false;
            radioG3.Checked = false;
            radioG4.Checked = false;
            radioG5.Checked = false;
            radioG6.Checked = false;
            radioG7.Checked = false;
            radioG8.Checked = false;
            radioG9.Checked = false;
            radioG10.Checked = false;
            radioG11.Checked = false;
            radioG12.Checked = false;
            radioG13.Checked = false;
            radioG14.Checked = false;
            radioG15.Checked = false;
            tb_IIIe61.Text = "";
            tb_IIIe62.Text = "";
            tb_IIIe63.Text = "";
            tb_IIIe64.Text = "";
            tb_IIIe65.Text = "";
            tb_IIIe66.Text = "";
            tb_IIIe67.Text = "";
            tb_IIIe68.Text = "";
            tb_IIIe69.Text = "";
            tb_IIIe610.Text = "";
            tb_IIIe611.Text = "";
            tb_IIIe612.Text = "";
            tb_IIIe613.Text = "";
            tb_IIIe614.Text = "";
            tb_IIIe615.Text = "";
            radioH1.Checked = false;
            radioH2.Checked = false;
            radioC1301.Checked = false;
            radioC1302.Checked = false;
            tb_IIIe1302.Text = "";
            tb_IIIe1302.Visible = false;
            radioC1303.Checked = false;
            radioC1304.Checked = false;
            tb_IIIe1304.Text = "";
            tb_IIIe1304.Visible = false;
            radioC13021.Checked = false;
            radioC13022.Checked = false;
            radioC13023.Checked = false;
            radioC13024.Checked = false;
            radioC13025.Checked = false;
            radioC13026.Checked = false;
            radioC13027.Checked = false;
            radioC13028.Checked = false;
            radioI101.Checked = false;
            radioI102.Checked = false;
            radioI1.Checked = false;
            radioI2.Checked = false;
            radioI3.Checked = false;
            radioI4.Checked = false;
            radioI5.Checked = false;
            radioI6.Checked = false;
            radioI7.Checked = false;
            radioI8.Checked = false;
            radioI121.Checked = false;
            radioI122.Checked = false;
            radioI123.Checked = false;
            radioI124.Checked = false;
            radioI125.Checked = false;
            int cuenta = 0;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //tb_IIe24.Text = "";
            //tb_IIe11.BackColor = System.Drawing.Color.White;
            //tb_IIe21.Focus();
            //tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
        }
        protected void Guardar_todo_Click(object sender, EventArgs e)
        {
            //cuenta = 0;
            //Response.Redirect("CuestionarioVivienda.aspx");
            if (HttpContext.Current.Session["editar"].ToString() == "0")
            {
                //Avance_barra2(1);
                //abrecom2(Page);
                ////abrecom3a(Page);
                //abrecom3(Page);
                tb_IIe21.Text = "";
                radioA1.Checked = false;
                radioA2.Checked = false;
                tb_IIe23.Text = "";
                DropDownList1.SelectedIndex = 0;
                tb_IIe24.Visible = false;
                tb_IIe24.Text = "";
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                siguienteini.Visible = true;
                agregar01a.Visible = false;
                Image1.ImageUrl = "Images/Clase_De_Vivienda.jpg";
                cierracom4q4(Page);
                abrecom4q5(Page);
            }
            else
            {
                Avance_barra2(2);
                ayuda01.Attributes["data-content"] = leer_xml(1);
                HttpContext.Current.Session["editar"] = "0";
                cierracom4q(Page);
                cierracom4q2(Page);
                abrecom2(Page);
                abrecom3a(Page);
                abrecom5(Page);
                tb_IIe21.Text = "";
                radioA1.Checked = false;
                radioA2.Checked = false;
                tb_IIe23.Text = "";
                DropDownList1.SelectedIndex = 0;
                tb_IIe24.Visible = false;
                tb_IIe24.Text = "";
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                siguienteini.Visible = false;
                agregar01a.Visible = true;
            }
        }

        protected void Guardar_todop_Click(object sender, EventArgs e)
        {
            Avance_barra2(2);
            ayuda01.Attributes["data-content"] = leer_xml(1);
            //cuenta = 0;
            //Response.Redirect("CuestionarioVivienda.aspx");
            cierracom4q(Page);
            cierracom4q2(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            DropDownList1.SelectedIndex = 0;
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }


        //protected void btn_lanzarc_Click(object sender, EventArgs e)
        //{
        //    cuenta += 1;
        //    //lb_III01.Text = slClienteID.ToString();// nombre de la persona
        //    //lb_IIIe1e2.Text = slClienteID.ToString();
        //    //lb_IIIe2e2.Text = slClienteID.ToString();
        //    //lb_IIIe3e2.Text = slClienteID.ToString();
        //    //lb_IIIe4e2.Text = slClienteID.ToString();
        //    //lb_IIIe5e2.Text = slClienteID.ToString();
        //    //lb_IIIe6e2.Text = slClienteID.ToString();
        //    //lb_IIIe7e2.Text = slClienteID.ToString();
        //    //lb_IIIe8e2.Text = slClienteID.ToString();
        //    //string nom= tabla.Rows[0].Cells[2].FindControl("Nombre").ToString();
        //    lb_III01.Text = "Persona";// nombre de la persona
        //    lb_IIIe1e2.Text = "Persona";
        //    lb_IIIe2e2.Text = "Persona";
        //    lb_IIIe3e2.Text = "Persona";
        //    lb_IIIe4e2.Text = "Persona";
        //    lb_IIIe5e2.Text = "Persona";
        //    lb_IIIe6e2.Text = "Persona";
        //    lb_IIIe7e2.Text = "Persona";
        //    lb_IIIe8e2.Text = "Persona";

        //    cierracom2(Page);
        //    cierracom3(Page);
        //    cierracom4(Page);
        //    cierracom5(Page);
        //    abrecom6(Page);
        //    abrecom7(Page);
        //    abrecom100(Page);
        //}

        [System.Web.Services.WebMethod]
        public void guardarPersona(string[] persona)
        {
            int cuenta;
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            cuenta += 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            //foreach (var item in persona)
            //{
            lb_III01.Text = persona[1].ToString();// nombre de la persona
            //lb_IIIe101e2.Text = persona[1].ToString();
            lb_IIIe100e2.Text = persona[1].ToString();
            lb_IIIe1e2.Text = persona[1].ToString();
            lb_IIIe102e2.Text = persona[1].ToString();
            lb_IIIe103e2.Text = persona[1].ToString();
            lb_IIIe2e2.Text = persona[1].ToString();
            lb_IIIe3e2.Text = persona[1].ToString();
            lb_IIIe4e2.Text = persona[1].ToString();
            lb_IIIe5e2.Text = persona[1].ToString();
            lb_IIIe6e2.Text = persona[1].ToString();
            lb_IIIe7e2.Text = persona[1].ToString();
            lb_IIIe1301e2.Text = persona[1].ToString();
            lb_IIIe1302e2.Text = persona[1].ToString();
            lb_IIIe10e2.Text = persona[1].ToString();
            lb_IIIe8e2.Text = persona[1].ToString();
            lb_IIIe12e2.Text = persona[1].ToString();
            //}



            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom5(Page);
            abrecom6(Page);
            abrecom700(Page);
            abrecom100(Page);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            abrecom2(Page);
            abrecom4p(Page);
            if (DropDownList1.Text == "Otro(especifique)")
            {
                tb_IIe24.Visible = true;
                tb_IIe24.Focus();
                tb_IIe24.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIe21p.BackColor = System.Drawing.Color.White;
            }
            else
            {
                tb_IIe24.Text = "";
                tb_IIe24.Visible = false;
                tb_IIe21p.Focus();
                tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            }   
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(string.IsNullOrEmpty(tb_IIe11.Text) ? tb_IIe11.Text = "0" : tb_IIe11.Text) > Gvresulta.Rows.Count)
            //{
            //    cierracom2(Page);
            //    cierracom3a(Page);
            //    cierracom4(Page);
            //    cierracom4p(Page);
            //    cierracom5(Page);
            //    Label34.Text = "Inicialmente usted declaró " + tb_IIe11.Text + " personas en la vivienda, pero registró sólo " + Gvresulta.Rows.Count + ", por favor de verifique la información";
            //    abrecom2(Page);
            //    abrecom4s11(Page);
            //}
            //else
            //{
                //if (tb_IIe11.Text == "")
                //{
                //    tb_IIe11.Text = "0";
                //}
                //if (Convert.ToInt16(tb_IIe11.Text) > Gvresulta.Rows.Count)
                //{
                //    //tb_IIe11.BackColor = System.Drawing.Color.White;
                //    tb_IIe11.Focus();
                //    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                //    mensaje(Page, "La cantidad de personas registradas debe de ser igual al número de las personas que viven aquí");
                //    abrecom2(Page);
                //    abrecom3(Page);
                //    abrecom5(Page);
                //}
                //else
                //{
                //    //ImageButton ibLink = (ImageButton)sender;
                //    //string sLine = "";
                //    //ArrayList cadena1 = new ArrayList();
                //    //sLine = ibLink.CommandArgument.ToString();
                //    //char[] delimiterChars = { '@' };
                //    //string text = sLine.ToString();
                //    //string[] words = text.Split(delimiterChars);
                //    //foreach (string s in words)
                //    //{
                //    //    cadena1.Add(s.Trim());
                //    //}
                //    //string slClienteID = cadena1[1].ToString();
                //    //string slID = cadena1[0].ToString();
                //    //string tipo = cadena1[2].ToString();
                //    ////Leer el grid_view y filtrar el dato que se eligio con el botón y no incluirlo, crear secuencialmente la tabla y asignarla al gridview
                //    //System.Data.DataTable table = new DataTable("ParentTable");
                //    //// Declare variables for DataColumn and DataRow objects.
                //    //DataColumn column;
                //    //DataRow row;
                //    //// Create new DataColumn, set DataType, 
                //    //// ColumnName and add to DataTable. 
                //    //column = new DataColumn();
                //    //column.DataType = System.Type.GetType("System.String");
                //    //column.ColumnName = "CUENTA";
                //    //column.ReadOnly = false;
                //    //column.Unique = false;
                //    //// Add the Column to the DataColumnCollection.
                //    //table.Columns.Add(column);
                //    //column = new DataColumn();
                //    //column.DataType = System.Type.GetType("System.String");
                //    //column.ColumnName = "NOMBRE";
                //    //column.ReadOnly = false;
                //    //column.Unique = false;
                //    //// Add the Column to the DataColumnCollection.
                //    //table.Columns.Add(column);
                //    //column = new DataColumn();
                //    //column.DataType = System.Type.GetType("System.String");
                //    //column.ColumnName = "SEXO";
                //    //column.ReadOnly = false;
                //    //column.Unique = false;
                //    //// Add the Column to the DataColumnCollection.
                //    //table.Columns.Add(column);
                //    //column = new DataColumn();
                //    //column.DataType = System.Type.GetType("System.String");
                //    //column.ColumnName = "EDAD";
                //    //column.ReadOnly = false;
                //    //column.Unique = false;
                //    //// Add the Column to the DataColumnCollection.
                //    //table.Columns.Add(column);
                //    //column = new DataColumn();
                //    //column.DataType = System.Type.GetType("System.String");
                //    //column.ColumnName = "PARENTESCO";
                //    //column.ReadOnly = false;
                //    //column.Unique = false;
                //    //// Add the Column to the DataColumnCollection.
                //    //table.Columns.Add(column);
                //    //// Make the ID column the primary key column.
                //    //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                //    //PrimaryKeyColumns[0] = table.Columns["id"];
                //    //table.PrimaryKey = PrimaryKeyColumns;
                //    //// Instantiate the DataSet variable.
                //    //DataSet dataSet = new DataSet();
                //    ////Add the new DataTable to the DataSet.
                //    //dataSet.Tables.Add(table);

                //    //int i, j = 0;
                //    //for (i = 0; i < Gvresulta.Rows.Count; i++)
                //    //{
                //    //j++;
                //    //row = table.NewRow();
                //    //row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                //    //row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                //    //row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                //    //row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                //    //row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                //    //table.Rows.Add(row);
                Avance_barra2(4);
                int actual = 0;
                HttpContext.Current.Session["actual"] = actual.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                ayuda01.Attributes["data-content"] = leer_xml(4);
                //lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                ////}
                ////Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                ////Gvresulta.DataBind();
                ////cadena1.Clear();

                ////cuenta += 1;
                ////lb_III01.Text = slClienteID.ToString();// nombre de la persona
                ////lb_IIIe1e2.Text = slClienteID.ToString();
                ////lb_IIIe2e2.Text = slClienteID.ToString();
                ////lb_IIIe3e2.Text = slClienteID.ToString();
                ////lb_IIIe4e2.Text = slClienteID.ToString();
                ////lb_IIIe5e2.Text = slClienteID.ToString();
                ////lb_IIIe6e2.Text = slClienteID.ToString();
                ////lb_IIIe7e2.Text = slClienteID.ToString();
                ////lb_IIIe8e2.Text = slClienteID.ToString();

                //Leer el grid_view y filtrar el dato que se eligio con el botón y no incluirlo, crear secuencialmente la tabla y asignarla al gridview
                System.Data.DataTable table = new DataTable("ParentTable");
                // Declare variables for DataColumn and DataRow objects.
                DataColumn column;
                DataRow row;
                // Create new DataColumn, set DataType, 
                // ColumnName and add to DataTable. 
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUENTA";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NOMBRE";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SEXO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "EDAD";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PARENTESCO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = table.Columns["id"];
                table.PrimaryKey = PrimaryKeyColumns;
                // Instantiate the DataSet variable.
                DataSet dataSet = new DataSet();
                //Add the new DataTable to the DataSet.
                dataSet.Tables.Add(table);
                int i, j = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = Gvresulta.Rows[i].Cells[0].Text;//j.ToString();
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);

                }
                GridView1.DataSource = dataSet.Tables["ParentTable"];
                GridView1.DataBind();
                Guardar(2,1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5(Page);
                //cuenta = 1;
                //p1 = 1;
                //p2 = 1;
                //Avance_barra(1);
                //Label8.Text =  "Entonces, ¿son " + Gvresulta.Rows.Count + " personas  las que viven normalmente en su vivienda? ";
                abrecom2(Page);
                abrecom5b(Page);
                //}
            //}
        }
        protected void cierramodal(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>setTimeout(function () {$find('programmaticModalPopupBehavior2').hide(); window.open('http://www.inegi.org.mx/est/contenidos/proyectos/ccpv/default.aspx','_self');}, 4000);</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open moda"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open moda", codigo);
            }
        }
        protected void cierramodal1(System.Web.UI.Page pagina)
        {
            //string codigo;
            //codigo = "<script language='JavaScript'>setTimeout(function () {window.open('http://www3.inegi.org.mx/sistemas/Panorama2015','_self');}, 4000);</script>";
            int i = 0;
            int j = 0;
            int k = 0;
            string tiempo = "";
            //for (i = 0; i < Gvresulta.Rows.Count; i++)
            //{
            //    if (Gvresulta.Rows[i].Cells[2].Text == "Hombre")
            //    {
            //        j++;
            //    }
            //    else if (Gvresulta.Rows[i].Cells[2].Text == "Mujer")
            //    {
            //        k++;
            //    }
            //}
            string oradb = ConfigurationManager.AppSettings["cai2020"];
            OracleConnection conn = new OracleConnection(); // C#
            conn.ConnectionString = oradb.ToString();
            try
            {
                conn.Open();
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "select sexo from CAP_INT_TR_PERSONA where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                cmd1.CommandType = CommandType.Text;
                OracleDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    if (dr1["SEXO"].ToString() == "1")
                    {
                        j++;
                    }
                    if (dr1["SEXO"].ToString() == "3")
                    {
                        k++;
                    }
                }
                dr1.Dispose();
                cmd1.Dispose();
                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                OracleParameter myParam3 = cmd3.CreateParameter();
                myParam3.OracleDbType = OracleDbType.NVarchar2;
                myParam3.Value = HttpContext.Current.Session["qr_viv"].ToString();
                myParam3.ParameterName = "qr";
                cmd3.Parameters.Add(myParam3);
                cmd3.CommandText = "SELECT QR_VIV,TOTCUART FROM CAP_INT_TR_VIVIENDA where QR_VIV = :qr";
                cmd3.CommandType = CommandType.Text;
                OracleDataReader dr3 = cmd3.ExecuteReader();
                if (dr3.Read())
                {
                    if (dr3["TOTCUART"].ToString() != "")
                    {
                        HttpContext.Current.Session["mio"] = dr3["TOTCUART"].ToString();
                    }
                    else
                    {
                        HttpContext.Current.Session["mio"] = "0";
                    }
                }
                else
                {
                    HttpContext.Current.Session["mio"] = "0";
                }
                dr3.Dispose();
                cmd3.Dispose();
                OracleCommand cmd31 = new OracleCommand();
                cmd31.Connection = conn;
                cmd31.CommandText = "select FECHA from CAP_INT_TH_LLENADO where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                cmd31.CommandType = CommandType.Text;
                OracleDataReader dr31 = cmd31.ExecuteReader();
                while (dr31.Read())
                {
                    tiempo = dr31["FECHA"].ToString();
                }
                dr31.Dispose();
                cmd31.Dispose();
            }
            catch (Exception e1)
            {
                HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
            }
            finally
            {
                conn.Dispose();
            }
            //string nuevaUrl = string.Format("Reporte.aspx?id={0}&num_cuartos={1}&hombres={2}&mujeres={3}&nom_imagen={4}", HttpContext.Current.Session["qr_viv"].ToString() + DateTime.Today.ToString("ddMM") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00"), Convert.ToInt32(HttpContext.Current.Session["mio"].ToString()), Convert.ToInt32(j), Convert.ToInt32(k), "r02_002");
            string nuevaUrl = string.Format("Acuse.aspx?id={0}&num_cuartos={1}&hombres={2}&mujeres={3}", HttpContext.Current.Session["qr_viv"].ToString() + tiempo.Substring(0, 2).ToString() + tiempo.Substring(3, 2).ToString() + tiempo.Substring(11, 2).ToString() + tiempo.Substring(14, 2).ToString() + tiempo.Substring(17, 2).ToString(), Convert.ToInt32(HttpContext.Current.Session["mio"].ToString()), Convert.ToInt32(j), Convert.ToInt32(k));
            //string codigo = "<script language='JavaScript'>setTimeout(function () {window.open('" + nuevaUrl + "','_self');window.open('http://www3.inegi.org.mx/sistemas/Panorama2015','_blank');}, 4000);</script>";
            string codigo = "<script language='JavaScript'>setTimeout(function () {window.open('" + nuevaUrl + "','_self');}, 4000);</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open moda"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open moda", codigo);
            }
        }
        protected void LinkButton3plus_Click(object sender, EventArgs e)
        {
            //Image1.ImageUrl = "Images/Cortinilla4.JPG";
            //programmaticModalPopup2.Show();
            //cierramodal(Page);
            HttpContext.Current.Session["testigo"] = "1";
            cierracom4q3(Page);
            abrecom4q7(Page);
            cierramodal1(Page);
            //System.Threading.Thread.Sleep(4000);
            //programmaticModalPopup2.Hide();
            //Response.Redirect("http://www3.inegi.org.mx/sistemas/Panorama2015");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "hidemodal", "myfunction1()", true);
        }
        protected void LinkButton3bis_Click(object sender, EventArgs e)
        {
            int k = Gvresulta.Rows.Count;
            int i;
            int l = 0;
            //int m = 0;
            for (i = 0; i < k; i++)
            {
                if (Convert.ToInt32(Gvresulta.Rows[i].Cells[3].Text) > 11)
                {
                    l++;
                }
                //if (Gvresulta.Rows[i].Cells[4].Text != "Jefa(e)" && Gvresulta.Rows[i].Cells[4].Text != "Esposa(o) o pareja" && Gvresulta.Rows[i].Cells[4].Text != "Hija(o)" && Gvresulta.Rows[i].Cells[4].Text != "Nieta(o)" && Gvresulta.Rows[i].Cells[4].Text != "Nuera o yerno" && Gvresulta.Rows[i].Cells[4].Text != "Madre o padre" && Gvresulta.Rows[i].Cells[4].Text != "Suegra (o)")
                //{
                //    m++;
                //}
            }
            if (l == 0)
            {
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5(Page);
                abrecom4s7(Page);
            }
            //else if (m >= 10)
            //{
            //    cierracom2(Page);
            //    cierracom3a(Page);
            //    cierracom4(Page);
            //    cierracom4p(Page);
            //    cierracom5(Page);
            //    abrecom4s8(Page);
            //}
            else
            {
                int actual = 0;
                HttpContext.Current.Session["actual"] = actual.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                Avance_barra2(3);
                lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5(Page);
                int cuenta = 1;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 1;
                HttpContext.Current.Session["p1"] = p1.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                int p2 = 1;
                HttpContext.Current.Session["p2"] = p2.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                ayuda01.Attributes["data-content"] = leer_xml(3);
                Avance_barra(1);
                Label8.Text = "Entonces, ¿son " + Gvresulta.Rows.Count + " las personas que viven normalmente en su vivienda? ";
                abrecom2(Page);
                abrecom4q2(Page);
            }
        }
        protected void LinkButton3bis1_Click(object sender, EventArgs e)
        {
            Avance_barra3(5);
            Button1.Attributes["data-content"] = leer_xml(5);
            SetSelectedRecord();
            if (regreso[1] == 0)
            {
                regreso[1] = 1;
                Label17.Text = "Aviso";
                Label10.Text = "No proporcionó respuesta a esta pregunta";
                programmaticModalPopup.Show();
                int cuenta = 0;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                abrecom2(Page);
                abrecom5b(Page);
            }
            else
            {
                int actual = 0;
                int menor = 0;
                ViewState["SelectedContact"] = "0";
                HttpContext.Current.Session["actual"] = actual.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[5].FindControl("RadioButton1");
                    if (rb != null)
                    {
                        if (rb.Checked)
                        {
                            HiddenField hf = (HiddenField)GridView1.Rows[i].Cells[5].FindControl("HiddenField1");
                            if (hf != null)
                            {
                                ViewState["SelectedContact"] = hf.Value;
                                if (Convert.ToInt32(GridView1.Rows[i].Cells[3].Text) < 18)
                                {
                                    menor = 1;
                                }

                            }
                            break;
                        }
                    }
                }
                if (menor == 1)
                {
                    menor = 0;
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom4p(Page);
                    cierracom5b(Page);
                    abrecom4s12(Page);
                }
                else
                {
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom4p(Page);
                    cierracom5b(Page);
                    //abrecom2(Page);
                    abrecom5c(Page);
                }
            }
            GetSelectedRecord();
        }
        protected void LinkButton3bis2_Click(object sender, EventArgs e)
        {
            //Avance_barra2(6);
            if (rv01.Checked == false && rv02.Checked == false && regreso[2] == 0)
            {
                regreso[2] = 1;
                Label17.Text = "Aviso";
                Label10.Text = "No proporcionó respuesta a esta pregunta";
                programmaticModalPopup.Show();
                int actual = 0;
                HttpContext.Current.Session["actual"] = actual.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                Avance_barra2(5);
                Button1.Attributes["data-content"] = leer_xml(5);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5b(Page);
                //abrecom2(Page);
                abrecom5c(Page);
            }
            else
            {
                if (rv02.Checked == true)
                {
                    int actual = 0;
                    HttpContext.Current.Session["actual"] = actual.ToString();
                    actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                    Guardar(4,0);
                    tb_LP8.Text = "";
                    HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                    lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                    //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                    //Label17.Text = "Inicio de la captura de personas";
                    //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                    //programmaticModalPopup.Show();
                    //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                    //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                    //programmaticModalPopup3.Show();
                    Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                    abrecom4q6(Page);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom4p(Page);
                    cierracom5(Page);
                    int cuenta = 1;
                    HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                    cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                    int p1 = 1;
                    HttpContext.Current.Session["p1"] = p1.ToString();
                    actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                    int p2 = 1;
                    HttpContext.Current.Session["p2"] = p2.ToString();
                    actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                    Avance_barra(1);
                    ayuda01a.Attributes["data-content"] = leer_xml(7);
                    //abrecom6(Page);
                    //abrecom7(Page);
                    //abrecom100(Page);
                }
                else
                {
                    int actual = 0;
                    HttpContext.Current.Session["actual"] = actual.ToString();
                    actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                    Avance_barra4(6);
                    Button2.Attributes["data-content"] = leer_xml(6);
                    cierracom2(Page);
                    cierracom3a(Page);
                    cierracom4(Page);
                    cierracom4p(Page);
                    cierracom5c(Page);
                    tb_LP8.BackColor = System.Drawing.Color.LightSteelBlue;
                    tb_LP8.Focus();
                    //abrecom2(Page);
                    abrecom5d(Page);
                }
            }
        }
        protected void LinkButton3bisa_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            Avance_barra2(4);
            Button1.Attributes["data-content"] = leer_xml(4);
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5b(Page);
            abrecom2(Page);
            abrecom5b(Page);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            int i, j = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Convert.ToInt32(Gvresulta.Rows[i].Cells[3].Text) < 3)
                {
                    j++;
                }
            }
            if (tb_LP8.Text == "" && regreso[3] == 0)
            {
                regreso[3] = 0;
                Label17.Text = "Aviso";
                Label10.Text = "No proporcionó respuesta a esta pregunta";
                programmaticModalPopup.Show();
                int actual = 0;
                HttpContext.Current.Session["actual"] = actual.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5c(Page);
                //abrecom2(Page);
                Avance_barra4(6);
                Button2.Attributes["data-content"] = leer_xml(6);
                abrecom5d(Page);
            }
            else if (Convert.ToInt32(tb_LP8.Text) > j)
            {
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5d(Page);
                abrecom4s9(Page);
                HttpContext.Current.Session["banninos"] = "1";
                Guardar(4, 1);
            }
            else
            {
                int actual = 0;
                HttpContext.Current.Session["actual"] = actual.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
                Guardar(4, 0);
                HttpContext.Current.Session["anos"] = Gvresulta.Rows[actual].Cells[3].Text;
                lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
                //Label17.Text = "Inicio de la captura de personas";
                //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //programmaticModalPopup.Show();
                //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
                //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                //programmaticModalPopup3.Show();
                Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                abrecom4q6(Page);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom4p(Page);
                cierracom5(Page);
                int cuenta = 1;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 1;
                HttpContext.Current.Session["p1"] = p1.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                int p2 = 1;
                HttpContext.Current.Session["p2"] = p2.ToString();
                actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
                Avance_barra(1);
                ayuda01a.Attributes["data-content"] = leer_xml(7);
                //abrecom6(Page);
                //abrecom7(Page);
                //abrecom100(Page);
            }
        }

        protected void LinkButton4a_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            //Avance_barra2(1);
            Avance_barra3(5);
            Button1.Attributes["data-content"] = leer_xml(5);
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5c(Page);
            //abrecom2(Page);
            abrecom5c(Page);
        }

        protected void CHB_funciones_CheckedChanged(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
            //CheckBox cb = (CheckBox)GridView.Rows[selRowIndex].FindControl("CHB_funciones");
            CheckBox cb = ((CheckBox)Gvresulta.Rows[selRowIndex].FindControl("CHB_funciones"));
            if (cb.Checked)
            {
                // Find other checkbox using FindControl and check the
                ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_editar")).Visible = true;
                ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_eliminar")).Visible = true;
                //cb.Visible = false;
            }
            else
            {
                ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_editar")).Visible = false;
                ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_eliminar")).Visible = false;
            }

            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
        }

        protected void ImgBtn_editar_Command(object sender, CommandEventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((ImageButton)sender).Parent.Parent)).RowIndex;
            //CheckBox cb = (CheckBox)GridView.Rows[selRowIndex].FindControl("CHB_funciones");
            ((CheckBox)Gvresulta.Rows[selRowIndex].FindControl("CHB_funciones")).Visible=true;
            ((CheckBox)Gvresulta.Rows[selRowIndex].FindControl("CHB_funciones")).Checked = false;
            ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_editar")).Visible = false;
            ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_eliminar")).Visible = false;
            HttpContext.Current.Session["editar"] = "1";
            ImageButton ibLink = (ImageButton)sender;
            string sLine = "";
            ArrayList cadena1 = new ArrayList();
            sLine = ibLink.CommandArgument.ToString();
            char[] delimiterChars = { '@' };
            string text = sLine.ToString();
            string[] words = text.Split(delimiterChars);
            foreach (string s in words)
            {
                cadena1.Add(s.Trim());
            }
            string slClienteID = cadena1[1].ToString();
            string slID = cadena1[0].ToString();
            string tipo = cadena1[2].ToString();
            if (slID == "1")
            {
                ayuda01.Attributes["data-content"] = leer_xml(0);
                HttpContext.Current.Session["editar"] = slID.ToString();
                int i, j = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    if (Gvresulta.Rows[i].Cells[0].Text == slID.ToString())
                    {
                        j++;
                        tb_IIe21.Text = Gvresulta.Rows[i].Cells[1].Text;

                        if (Gvresulta.Rows[i].Cells[2].Text == "Hombre")
                        {
                            radioA1.Checked = true;
                        }
                        else if (Gvresulta.Rows[i].Cells[2].Text == "Mujer")
                        {
                            radioA2.Checked = true;
                        }
                       tb_IIe23.Text = Gvresulta.Rows[i].Cells[3].Text;
                        //row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    }
                }
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4(Page);
            }
            else
            {
                ayuda01.Attributes["data-content"] = leer_xml(2);
                HttpContext.Current.Session["editar"] = slID.ToString();
                int i, j = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    if (Gvresulta.Rows[i].Cells[0].Text == slID.ToString())
                    {
                        j++;
                        tb_IIe21p.Text = Gvresulta.Rows[i].Cells[1].Text;

                        if (Gvresulta.Rows[i].Cells[2].Text == "Hombre")
                        {
                            radioA1p.Checked = true;
                        }
                        else if (Gvresulta.Rows[i].Cells[2].Text == "Mujer")
                        {
                            radioA2p.Checked = true;
                        }
                        tb_IIe23p.Text = Gvresulta.Rows[i].Cells[3].Text;
                        if (Gvresulta.Rows[i].Cells[4].Text != "Esposa(o) o pareja" && Gvresulta.Rows[i].Cells[4].Text != "Hija(o)" && Gvresulta.Rows[i].Cells[4].Text != "Nieta(o)" && Gvresulta.Rows[i].Cells[4].Text != "Nuera o yerno" && Gvresulta.Rows[i].Cells[4].Text != "Madre o padre" && Gvresulta.Rows[i].Cells[4].Text != "Suegra (o)" && Gvresulta.Rows[i].Cells[4].Text != "Sin parentesco" && Gvresulta.Rows[i].Cells[4].Text != "Otro(especifique)")
                        //DropDownList1.Items.Add("Esposa(o) o pareja");
                        //DropDownList1.Items.Add("Hija(o)");
                        //DropDownList1.Items.Add("Nieta(o)");
                        //DropDownList1.Items.Add("Nuera o yerno");
                        //DropDownList1.Items.Add("Madre o padre");
                        //DropDownList1.Items.Add("Suegra (o)");
                        ////DropDownList1.Items.Add("Sin parentesco");
                        //DropDownList1.Items.Add("Otro(especifique)");
                        {
                            DropDownList1.SelectedValue = "Otro(especifique)";
                            tb_IIe24.Text = Gvresulta.Rows[i].Cells[4].Text;
                            tb_IIe24.Visible = true;
                        }
                        else
                        {
                            DropDownList1.SelectedValue = Gvresulta.Rows[i].Cells[4].Text;
                        }
                    }
                }
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4p(Page);
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        protected void ImgBtn_eliminar_Command(object sender, CommandEventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((ImageButton)sender).Parent.Parent)).RowIndex;
            //CheckBox cb = (CheckBox)GridView.Rows[selRowIndex].FindControl("CHB_funciones");
            ((CheckBox)Gvresulta.Rows[selRowIndex].FindControl("CHB_funciones")).Visible = true;
            ((CheckBox)Gvresulta.Rows[selRowIndex].FindControl("CHB_funciones")).Checked = false;
            ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_editar")).Visible = false;
            ((ImageButton)Gvresulta.Rows[selRowIndex].FindControl("ImgBtn_eliminar")).Visible = false;
            ImageButton ibLink = (ImageButton)sender;
            string sLine = "";
            ArrayList cadena1 = new ArrayList();
            sLine = ibLink.CommandArgument.ToString();
            char[] delimiterChars = { '@' };
            string text = sLine.ToString();
            string[] words = text.Split(delimiterChars);
            foreach (string s in words)
            {
                cadena1.Add(s.Trim());
            }
            string slClienteID = cadena1[1].ToString();
            string slID = cadena1[0].ToString();
            string tipo = cadena1[2].ToString();
            if (slID == "1")
            {
                ayuda01.Attributes["data-content"] = leer_xml(0);
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4q(Page);
            }
            else
            {
                ayuda01.Attributes["data-content"] = leer_xml(1);
                HttpContext.Current.Session["registro"] = slID.ToString();
                cierracom3a(Page);
                cierracom5(Page);
                abrecom2(Page);
                abrecom4q1(Page);
            }
        }

        private void GetSelectedRecord()
        {
            ViewState["SelectedContact"] = "0";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[5].FindControl("RadioButton1");
                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        HiddenField hf = (HiddenField)GridView1.Rows[i].Cells[5].FindControl("HiddenField1");
                        if (hf != null)
                        {
                            ViewState["SelectedContact"] = hf.Value;
                        }
                        break;
                    }
                }
            }
        }

        private void SetSelectedRecord()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[5].FindControl("RadioButton1");
                if (rb != null)
                {
                    HiddenField hf = (HiddenField)GridView1.Rows[i].Cells[5].FindControl("HiddenField1");
                    if (hf != null && ViewState["SelectedContact"] != null)
                    {
                        if (hf.Value.Equals(ViewState["SelectedContact"].ToString()))
                        {
                            regreso[1] = 1;
                            rb.Checked = true;
                            check = rb.Checked;// aquí se puede guardar la persona que es el 
                            break;
                        }
                    }
                }
            }
        }
        protected void radioC1001_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1001.Checked == true)
            {
                int cuenta = 1;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 1;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom700(Page);
                abrecom100(Page);
                cierrabot1(Page);
                tb_IIIe1002.Text = "";
                tb_IIIe1004.Text = "";
                tb_IIIe1002.Visible = false;
                tb_IIIe1004.Visible = false;
            }
        }
        protected void radioC1002_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1002.Checked == true)
            {
                int cuenta = 1;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 1;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom700(Page);
                abrecom100(Page);
                cierrabot1(Page);
                tb_IIIe1002.Text = "";
                tb_IIIe1004.Text = "";
                tb_IIIe1002.Visible = true;
                tb_IIIe1004.Visible = false;
                tb_IIIe1002.Focus();
                tb_IIIe1002.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }
        protected void radioC1003_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1003.Checked == true)
            {
                int cuenta = 1;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 1;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom700(Page);
                abrecom100(Page);
                cierrabot1(Page);
                tb_IIIe1002.Text = "";
                tb_IIIe1004.Text = "";
                tb_IIIe1002.Visible = false;
                tb_IIIe1004.Visible = false;
            }
        }
        protected void radioC1004_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1004.Checked == true)
            {
                int cuenta = 1;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 1;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom700(Page);
                abrecom100(Page);
                cierrabot1(Page);
                tb_IIIe1002.Text = "";
                tb_IIIe1004.Text = "";
                tb_IIIe1002.Visible = false;
                tb_IIIe1004.Visible = true;
                tb_IIIe1004.Focus();
                tb_IIIe1004.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }
        protected void radioG1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG1.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "0";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG2.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = true;
                tb_IIIe62.Focus();
                tb_IIIe62.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG3.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = true;
                tb_IIIe63.Focus();
                tb_IIIe63.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG4.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = true;
                tb_IIIe64.Focus();
                tb_IIIe64.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG5.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = true;
                tb_IIIe65.Focus();
                tb_IIIe65.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG6.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = true;
                tb_IIIe66.Focus();
                tb_IIIe66.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG7.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = true;
                tb_IIIe67.Focus();
                tb_IIIe67.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG8.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = true;
                tb_IIIe68.Focus();
                tb_IIIe68.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG9.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = true;
                tb_IIIe69.Focus();
                tb_IIIe69.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG10.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = true;
                tb_IIIe610.Focus();
                tb_IIIe610.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG11.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = true;
                tb_IIIe611.Focus();
                tb_IIIe611.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG12.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = true;
                tb_IIIe612.Focus();
                tb_IIIe612.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG13.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = true;
                tb_IIIe613.Focus();
                tb_IIIe613.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG14.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = true;
                tb_IIIe614.Focus();
                tb_IIIe614.BackColor = System.Drawing.Color.LightSteelBlue;
                tb_IIIe615.Visible = false;
            }
        }
        protected void radioG15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioG15.Checked == true)
            {
                int p1 = 6;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom12(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe61.Text = "";
                tb_IIIe62.Text = "";
                tb_IIIe63.Text = "";
                tb_IIIe64.Text = "";
                tb_IIIe65.Text = "";
                tb_IIIe66.Text = "";
                tb_IIIe67.Text = "";
                tb_IIIe68.Text = "";
                tb_IIIe69.Text = "";
                tb_IIIe610.Text = "";
                tb_IIIe611.Text = "";
                tb_IIIe612.Text = "";
                tb_IIIe613.Text = "";
                tb_IIIe614.Text = "";
                tb_IIIe615.Text = "";
                tb_IIIe61.Visible = false;
                tb_IIIe62.Visible = false;
                tb_IIIe63.Visible = false;
                tb_IIIe64.Visible = false;
                tb_IIIe65.Visible = false;
                tb_IIIe66.Visible = false;
                tb_IIIe67.Visible = false;
                tb_IIIe68.Visible = false;
                tb_IIIe69.Visible = false;
                tb_IIIe610.Visible = false;
                tb_IIIe611.Visible = false;
                tb_IIIe612.Visible = false;
                tb_IIIe613.Visible = false;
                tb_IIIe614.Visible = false;
                tb_IIIe615.Visible = true;
                tb_IIIe615.Focus();
                tb_IIIe615.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        protected void radioC1301_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1301.Checked == true)
            {
                int cuenta = 11;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 11;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom1301(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe1302.Text = "";
                tb_IIIe1304.Text = "";
                tb_IIIe1302.Visible = false;
                tb_IIIe1304.Visible = false;
            }
        }
        protected void radioC1302_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1302.Checked == true)
            {
                int cuenta = 11;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 11;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom1301(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe1302.Text = "";
                tb_IIIe1304.Text = "";
                tb_IIIe1302.Visible = true;
                tb_IIIe1304.Visible = false;
                tb_IIIe1302.Focus();
                tb_IIIe1302.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }
        protected void radioC1303_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1303.Checked == true)
            {
                int cuenta = 11;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 11;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom1301(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe1302.Text = "";
                tb_IIIe1304.Text = "";
                tb_IIIe1302.Visible = false;
                tb_IIIe1304.Visible = false;
            }
        }
        protected void radioC1304_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC1304.Checked == true)
            {
                int cuenta = 11;
                HttpContext.Current.Session["cuenta"] = cuenta.ToString();
                cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
                int p1 = 11;
                HttpContext.Current.Session["p1"] = p1.ToString();
                p1 = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
                Avance_barra(1);
                cierracom2(Page);
                cierracom3a(Page);
                cierracom4(Page);
                cierracom5(Page);
                cierracom6(Page);
                cierracom700(Page);
                cierracom7(Page);
                cierracom702(Page);
                cierracom703(Page);
                cierracom8(Page);
                cierracom9(Page);
                cierracom10(Page);
                cierracom11(Page);
                cierracom12(Page);
                cierracom13(Page);
                cierracom1301(Page);
                cierracom1302(Page);
                cierracom1401(Page);
                cierracom14(Page);
                cierracom1403(Page);
                cierracom100(Page);
                abrecom6(Page);
                abrecom1301(Page);
                abrecom100(Page);
                abrebot1(Page);
                tb_IIIe1302.Text = "";
                tb_IIIe1304.Text = "";
                tb_IIIe1302.Visible = false;
                tb_IIIe1304.Visible = true;
                tb_IIIe1304.Focus();
                tb_IIIe1304.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox1.Checked == false)
            {
                CheckBox2.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox4.Enabled = true;
                CheckBox5.Enabled = true;
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox2.Checked == true)
            {
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox1.Checked == true && CheckBox3.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox1.Checked == true && CheckBox4.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox1.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox1.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox1.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox2.Checked == false)
            {
                CheckBox1.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox4.Enabled = true;
                CheckBox5.Enabled = true;
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox2.Checked == true)
            {
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox3.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox4.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox3.Checked == false)
            {
                CheckBox1.Enabled = true;
                CheckBox2.Enabled = true;
                CheckBox4.Enabled = true;
                CheckBox5.Enabled = true;
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox3.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox3.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox4.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox4.Checked == false)
            {
                CheckBox1.Enabled = true;
                CheckBox2.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox5.Enabled = true;
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox4.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox4.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox4.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox4.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox4.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox4.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
        }

        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox5.Checked == false)
            {
                CheckBox1.Enabled = true;
                CheckBox2.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox4.Enabled = true;
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox4.Checked == true && CheckBox5.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox5.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox5.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
            }
        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox6.Checked == false)
            {
                CheckBox1.Enabled = true;
                CheckBox2.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox4.Enabled = true;
                CheckBox5.Enabled = true;
                CheckBox7.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox4.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox5.Checked == true && CheckBox6.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox7.Enabled = false;
            }
            else if (CheckBox6.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
            }
        }

        protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
            if (CheckBox7.Checked == false)
            {
                CheckBox1.Enabled = true;
                CheckBox2.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox4.Enabled = true;
                CheckBox5.Enabled = true;
                CheckBox6.Enabled = true;
            }
            else if (CheckBox1.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
            else if (CheckBox2.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
            else if (CheckBox3.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
            else if (CheckBox4.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox5.Enabled = false;
                CheckBox6.Enabled = false;
            }
            else if (CheckBox5.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox6.Enabled = false;
            }
            else if (CheckBox6.Checked == true && CheckBox7.Checked == true)
            {
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                CheckBox5.Enabled = false;
            }
        }

        protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
            abrebot1(Page);
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true || CheckBox5.Checked == true || CheckBox6.Checked == true || CheckBox7.Checked == true)
            {
                CheckBox8.Enabled = false;
            }
            else
            {
                CheckBox8.Enabled = true;
            }
        }
        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            //agregar01a.Visible = false;
            //abrecom2(Page);
            //abrecom3(Page);
            ////abrecom3a(Page);
            ////abrecom4(Page);
            ////abrecom5(Page);
            //////abrecom5a(Page);
            ////Image1.ImageUrl = "Images/Cortinilla2.JPG";
            ////programmaticModalPopup2.Show();
            //Avance_barra2(1);
            //tb_IIe24.Visible = false;
            //tb_IIe11.Focus();
            //tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            //DropDownList1.Items.Add("Seleccione...");
            //DropDownList1.Items.Add("Esposa(o) o pareja");
            //DropDownList1.Items.Add("Hija(o)");
            //DropDownList1.Items.Add("Nieta(o)");
            //DropDownList1.Items.Add("Nuera o yerno");
            //DropDownList1.Items.Add("Madre o padre");
            //DropDownList1.Items.Add("Suegra (o)");
            ////DropDownList1.Items.Add("Sin parentesco");
            //DropDownList1.Items.Add("Otro(especifique)");
            //System.Data.DataTable table = new DataTable("ParentTable");
            //// Declare variables for DataColumn and DataRow objects.
            //DataColumn column;
            //DataRow row;
            //// Create new DataColumn, set DataType, 
            //// ColumnName and add to DataTable. 
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "CUENTA";
            //column.ReadOnly = false;
            //column.Unique = false;
            //// Add the Column to the DataColumnCollection.
            //table.Columns.Add(column);
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "NOMBRE";
            //column.ReadOnly = false;
            //column.Unique = false;
            //// Add the Column to the DataColumnCollection.
            //table.Columns.Add(column);
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "SEXO";
            //column.ReadOnly = false;
            //column.Unique = false;
            //// Add the Column to the DataColumnCollection.
            //table.Columns.Add(column);
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "EDAD";
            //column.ReadOnly = false;
            //column.Unique = false;
            //// Add the Column to the DataColumnCollection.
            //table.Columns.Add(column);
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "PARENTESCO";
            //column.ReadOnly = false;
            //column.Unique = false;
            //// Add the Column to the DataColumnCollection.
            //table.Columns.Add(column);

            //// Make the ID column the primary key column.
            //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //PrimaryKeyColumns[0] = table.Columns["id"];
            //table.PrimaryKey = PrimaryKeyColumns;
            //// Instantiate the DataSet variable.
            //DataSet dataSet = new DataSet();
            ////Add the new DataTable to the DataSet.
            //dataSet.Tables.Add(table);


            //Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            //Gvresulta.DataBind();
            //row = table.NewRow();
            //row["CUENTA"] = "1";//Gvresulta.Rows[i].Cells[0].Text;
            //row["NOMBRE"] = "";
            //row["SEXO"] = "";
            //row["EDAD"] = "";
            //row["PARENTESCO"] = "Titular";
            //table.Rows.Add(row);
            //gv1.DataSource = dataSet.Tables["ParentTable"];
            //gv1.DataBind();
            //ayuda01.Attributes["data-content"] = leer_xml(Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString()));
            //Avance_barra(0);
            ////if (HttpContext.Current.Session["mio"].ToString() == "1")
            ////{
            ////    cierracom2(Page);
            ////    cierracom3(Page);
            ////    abrecom2(Page);
            ////    abrecom3(Page);
            ////    tb_IIe24.Visible = false;
            ////    tb_IIe11.Focus();
            ////    tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            ////    HttpContext.Current.Session["mio"] = "1";
            ////}
            ////else
            ////{
            ////    cierracom2(Page);
            ////    cierracom3(Page);
            ////}
            HttpContext.Current.Session["editar"] = 0;
            ayuda01.Attributes["data-content"] = leer_xml(0);
            tb_IIe24.Visible = false;
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("Seleccione...");
            DropDownList1.Items.Add("Esposa(o) o pareja");
            DropDownList1.Items.Add("Hija(o)");
            DropDownList1.Items.Add("Nieta(o)");
            DropDownList1.Items.Add("Nuera o yerno");
            DropDownList1.Items.Add("Madre o padre");
            DropDownList1.Items.Add("Suegra (o)");
            DropDownList1.Items.Add("Otro(especifique)");
            if (Gvresulta.Rows.Count >= 1)
            {
                System.Data.DataTable table = new DataTable("ParentTable");
                // Declare variables for DataColumn and DataRow objects.
                DataColumn column;
                DataRow row;
                // Create new DataColumn, set DataType, 
                // ColumnName and add to DataTable. 
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "CUENTA";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "NOMBRE";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SEXO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "EDAD";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "PARENTESCO";
                column.ReadOnly = false;
                column.Unique = false;
                // Add the Column to the DataColumnCollection.
                table.Columns.Add(column);
                // Make the ID column the primary key column.
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = table.Columns["id"];
                table.PrimaryKey = PrimaryKeyColumns;
                // Instantiate the DataSet variable.
                DataSet dataSet = new DataSet();
                //Add the new DataTable to the DataSet.
                dataSet.Tables.Add(table);
                int i, j = 0;
                int mp = 0;
                for (i = 0; i < Gvresulta.Rows.Count; i++)
                {
                    if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                    {
                        j++;
                        row = table.NewRow();
                        row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        table.Rows.Add(row);
                    }
                    else
                    {
                        j++;
                        row = table.NewRow();
                        if (Gvresulta.Rows[i].Cells[0].Text == "1")
                        {
                            row["CUENTA"] = j.ToString();
                            row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                            row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                            row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                            row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                            mp = 1;
                        }
                        else
                        {
                            row["CUENTA"] = j.ToString();
                            row["NOMBRE"] = tb_IIe21p.Text;
                            if (radioA1p.Checked == true)
                            {
                                row["SEXO"] = "Hombre";
                            }
                            else if (radioA2p.Checked == true)
                            {
                                row["SEXO"] = "Mujer";
                            }
                            row["EDAD"] = tb_IIe23p.Text;
                            if (DropDownList1.Text == "Otro(especifique)")
                            {
                                row["PARENTESCO"] = tb_IIe24.Text;
                            }
                            else
                            {
                                row["PARENTESCO"] = DropDownList1.Text;
                            }
                        }
                        table.Rows.Add(row);
                        HttpContext.Current.Session["editar"] = "";
                    }
                }
                Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                Gvresulta.DataBind();
                Avance_barra2(2);
                tb_IIe21p.Text = "";
                radioA1p.Checked = false;
                radioA2p.Checked = false;
                tb_IIe23p.Text = "";
                tb_IIe24.Visible = false;
                tb_IIe24.Text = "";
                cierracom4s5(Page);
                abrecom2(Page);
                abrecom3a(Page);
                abrecom5(Page);
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                siguienteini.Visible = false;
                agregar01a.Visible = true;
            }
            else
            {
                HttpContext.Current.Session["cuenta"] = "0";
                Avance_barra2(1);
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                //siguienteini.Visible = true;
                //agregar01a.Visible = false;
                siguienteini.Visible = false;
                agregar01a.Visible = true;
                abrecom2(Page);
                abrecom4(Page);
                tb_IIe21.Focus();
                tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                //abrecom3a(Page);
            }
        }
        protected void LinkButton16_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "Images/Clase_De_Vivienda.jpg";
            cierracom4q4(Page);
            abrecom4q4(Page);
        }
        protected void LinkButton17_Click(object sender, EventArgs e)
        {
            cierracom4q6(Page);
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom5(Page);
            cierracom6(Page);
            cierracom700(Page);
            cierracom700(Page);
            cierracom7(Page);
            cierracom702(Page);
            cierracom703(Page);
            cierracom703(Page);
            cierracom8(Page);
            cierracom9(Page);
            cierracom10(Page);
            cierracom11(Page);
            cierracom12(Page);
            cierracom13(Page);
            cierracom1301(Page);
            cierracom1302(Page);
            cierracom1401(Page);
            cierracom14(Page);
            cierracom1403(Page);
            cierracom100(Page);
            abrecom6(Page);
            abrecom700(Page);
            abrecom100(Page);
            cierrabot1(Page);
        }
        protected void Si02_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            //Aquí se debe de guardar el resultado
            Guardar(6, 1);
            HttpContext.Current.Session["testigo"] = "1";
            cierracom4s(Page);
            abrecom4q7(Page);
            cierramodal1(Page);
        }
        protected void No02_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["cuenta"] = "0";
            cierracom4s(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = true;
            agregar01a.Visible = false;
            abrecom2(Page);
            abrecom3(Page);
        }
        protected void Si03_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Default.aspx");
            HttpContext.Current.Session["testigo"] = "1";
            Avance_barra2(2);
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 1;
            j++;
            row = table.NewRow();
            row["CUENTA"] = "1";
            row["NOMBRE"] = tb_IIe21.Text;
            if (radioA1.Checked == true)
            {
                row["SEXO"] = "Hombre";
            }
            else if (radioA2.Checked == true)
            {
                row["SEXO"] = "Mujer";
            }
            row["EDAD"] = tb_IIe23.Text;
            row["PARENTESCO"] = "Jefa(e)";
            table.Rows.Add(row);
            for (i = 1; i < Gvresulta.Rows.Count; i++)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = Gvresulta.Rows[i].Cells[0].Text;//j.ToString()t;
                row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                table.Rows.Add(row);
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            HttpContext.Current.Session["nombre"] = tb_IIe21.Text + " de " + tb_IIe23.Text + " años";
            tb_IIe21.Text = "";
            radioA1.Checked = false;
            radioA2.Checked = false;
            tb_IIe23.Text = "";
            tb_IIe24.Text = "";
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s1(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
        }
        protected void No03_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21.BackColor = System.Drawing.Color.White;
            tb_IIe23.Focus();
            tb_IIe23.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s1(Page);
            abrecom2(Page);
            abrecom4(Page);
        }
        protected void Si04_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            int mp = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                else
                {
                    j++;
                    row = table.NewRow();
                    if (Gvresulta.Rows[i].Cells[0].Text == "1")
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        mp = 1;
                    }
                    else
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                    }
                    table.Rows.Add(row);
                    HttpContext.Current.Session["editar"] = "";
                }
            }
            if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = tb_IIe21p.Text;
                if (radioA1p.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2p.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23p.Text;

                if (DropDownList1.Text == "Otro(especifique)")
                {
                    row["PARENTESCO"] = tb_IIe24.Text;
                }
                else
                {
                    row["PARENTESCO"] = DropDownList1.Text;
                }
                table.Rows.Add(row);
            }
            else
            {
                HttpContext.Current.Session["editar"] = "p";
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            cierracom4s2(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void No04_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21p.Focus();
            tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s2(Page);
            abrecom2(Page);
            abrecom4p(Page);
        }
        protected void Si05_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            int mp = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                else
                {
                    j++;
                    row = table.NewRow();
                    if (Gvresulta.Rows[i].Cells[0].Text == "1")
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        mp = 1;
                    }
                    else
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                    }
                    table.Rows.Add(row);
                    HttpContext.Current.Session["editar"] = "";
                }
            }
            if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = tb_IIe21p.Text;
                if (radioA1p.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2p.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23p.Text;

                if (DropDownList1.Text == "Otro(especifique)")
                {
                    row["PARENTESCO"] = tb_IIe24.Text;
                }
                else
                {
                    row["PARENTESCO"] = DropDownList1.Text;
                }
                table.Rows.Add(row);
            }
            else
            {
                HttpContext.Current.Session["editar"] = "p";
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            cierracom4s3(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void No05_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21p.Focus();
            tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s3(Page);
            abrecom2(Page);
            abrecom4p(Page);
        }
        protected void Si06_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            int mp = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                else
                {
                    j++;
                    row = table.NewRow();
                    if (Gvresulta.Rows[i].Cells[0].Text == "1")
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        mp = 1;
                    }
                    else
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                    }
                    table.Rows.Add(row);
                    HttpContext.Current.Session["editar"] = "";
                }
            }
            if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = tb_IIe21p.Text;
                if (radioA1p.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2p.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23p.Text;

                if (DropDownList1.Text == "Otro(especifique)")
                {
                    row["PARENTESCO"] = tb_IIe24.Text;
                }
                else
                {
                    row["PARENTESCO"] = DropDownList1.Text;
                }
                table.Rows.Add(row);
            }
            else
            {
                HttpContext.Current.Session["editar"] = "p";
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            cierracom4s4(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void No06_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21p.Focus();
            tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s4(Page);
            abrecom2(Page);
            abrecom4p(Page);
        }
        protected void Si07_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            int mp = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                else
                {
                    j++;
                    row = table.NewRow();
                    if (Gvresulta.Rows[i].Cells[0].Text == "1")
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        mp = 1;
                    }
                    else
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                    }
                    table.Rows.Add(row);
                    HttpContext.Current.Session["editar"] = "";
                }
            }
            if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = tb_IIe21p.Text;
                if (radioA1p.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2p.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23p.Text;

                if (DropDownList1.Text == "Otro(especifique)")
                {
                    row["PARENTESCO"] = tb_IIe24.Text;
                }
                else
                {
                    row["PARENTESCO"] = DropDownList1.Text;
                }
                table.Rows.Add(row);
            }
            else
            {
                HttpContext.Current.Session["editar"] = "p";
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            cierracom4s5(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void No07_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21p.Focus();
            tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s5(Page);
            abrecom2(Page);
            abrecom4p(Page);
        }
        protected void Si08_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            int mp = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                else
                {
                    j++;
                    row = table.NewRow();
                    if (Gvresulta.Rows[i].Cells[0].Text == "1")
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        mp = 1;
                    }
                    else
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                    }
                    table.Rows.Add(row);
                    HttpContext.Current.Session["editar"] = "";
                }
            }
            if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = tb_IIe21p.Text;
                if (radioA1p.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2p.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23p.Text;

                if (DropDownList1.Text == "Otro(especifique)")
                {
                    row["PARENTESCO"] = tb_IIe24.Text;
                }
                else
                {
                    row["PARENTESCO"] = DropDownList1.Text;
                }
                table.Rows.Add(row);
            }
            else
            {
                HttpContext.Current.Session["editar"] = "p";
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            cierracom4s6(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void No08_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21p.Focus();
            tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s6(Page);
            abrecom2(Page);
            abrecom4p(Page);
        }
        protected void Si09_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            Avance_barra2(3);
            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5(Page);
            cierracom4s7(Page);
            int cuenta = 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            int p1 = 1;
            HttpContext.Current.Session["p1"] = p1.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
            int p2 = 1;
            HttpContext.Current.Session["p2"] = p2.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
            Avance_barra(1);
            Label8.Text = "Entonces, ¿son " + Gvresulta.Rows.Count + " las personas que viven normalmente en su vivienda? ";
            abrecom2(Page);
            abrecom4q2(Page);
        }
        protected void No09_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            cierracom4s7(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void Si010_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            Avance_barra2(3);
            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
            //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5(Page);
            cierracom4s8(Page);
            int cuenta = 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            int p1 = 1;
            HttpContext.Current.Session["p1"] = p1.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
            int p2 = 1;
            HttpContext.Current.Session["p2"] = p2.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
            Avance_barra(1);
            Label8.Text = "Entonces, ¿son " + Gvresulta.Rows.Count + " las personas que viven normalmente en su vivienda? ";
            abrecom2(Page);
            abrecom4q2(Page);
        }
        protected void No010_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                table.Rows.Add(row);
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            cierracom4s8(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void Si11_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            int mp = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                if (Gvresulta.Rows[i].Cells[0].Text != HttpContext.Current.Session["editar"].ToString())
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                else
                {
                    j++;
                    row = table.NewRow();
                    if (Gvresulta.Rows[i].Cells[0].Text == "1")
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                        mp = 1;
                    }
                    else
                    {
                        row["CUENTA"] = j.ToString();
                        row["NOMBRE"] = tb_IIe21p.Text;
                        if (radioA1p.Checked == true)
                        {
                            row["SEXO"] = "Hombre";
                        }
                        else if (radioA2p.Checked == true)
                        {
                            row["SEXO"] = "Mujer";
                        }
                        row["EDAD"] = tb_IIe23p.Text;
                        if (DropDownList1.Text == "Otro(especifique)")
                        {
                            row["PARENTESCO"] = tb_IIe24.Text;
                        }
                        else
                        {
                            row["PARENTESCO"] = DropDownList1.Text;
                        }
                    }
                    table.Rows.Add(row);
                    HttpContext.Current.Session["editar"] = "";
                }
            }
            if (HttpContext.Current.Session["editar"].ToString() != "" || mp == 1)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = tb_IIe21p.Text;
                if (radioA1p.Checked == true)
                {
                    row["SEXO"] = "Hombre";
                }
                else if (radioA2p.Checked == true)
                {
                    row["SEXO"] = "Mujer";
                }
                row["EDAD"] = tb_IIe23p.Text;

                if (DropDownList1.Text == "Otro(especifique)")
                {
                    row["PARENTESCO"] = tb_IIe24.Text;
                }
                else
                {
                    row["PARENTESCO"] = DropDownList1.Text;
                }
                table.Rows.Add(row);
            }
            else
            {
                HttpContext.Current.Session["editar"] = "p";
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            tb_IIe21p.Text = "";
            radioA1p.Checked = false;
            radioA2p.Checked = false;
            tb_IIe23p.Text = "";
            tb_IIe24.Visible = false;
            tb_IIe24.Text = "";
            cierracom4s10(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void No11_Click(object sender, EventArgs e)
        {
            Avance_barra2(1);
            tb_IIe21p.Focus();
            tb_IIe21p.BackColor = System.Drawing.Color.LightSteelBlue;
            cierracom4s10(Page);
            abrecom2(Page);
            abrecom4p(Page);
        }
        protected void Si12_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["cuenta"] = "0";
            Avance_barra2(1);
            cierracom4s11(Page);
            tb_IIe11.Focus();
            tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
            siguienteini.Visible = true;
            agregar01a.Visible = false;
            abrecom2(Page);
            abrecom3(Page);
        }
        protected void Si13_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            Avance_barra3(5);
            Button1.Attributes["data-content"] = leer_xml(5);
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5b(Page);
            //abrecom2(Page);
            abrecom5c(Page);
        }
        protected void No13_Click(object sender, EventArgs e)
        {
            int cuenta = 0;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            abrecom2(Page);
            abrecom5b(Page);
        }
        protected void P91_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5c(Page);
            cierracom4s9(Page);
            //abrecom2(Page);
            Avance_barra4(6);
            Button2.Attributes["data-content"] = leer_xml(6);
            abrecom5d(Page);
        }
        protected void P92_Click(object sender, EventArgs e)
        {
            Avance_barra2(2);
            ayuda01.Attributes["data-content"] = leer_xml(1);
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;
            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable. 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CUENTA";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NOMBRE";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SEXO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EDAD";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "PARENTESCO";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);
            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            // Instantiate the DataSet variable.
            DataSet dataSet = new DataSet();
            //Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            int i, j = 0;
            for (i = 0; i < Gvresulta.Rows.Count; i++)
            {
                j++;
                row = table.NewRow();
                row["CUENTA"] = j.ToString();
                row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                table.Rows.Add(row);
            }
            Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            Gvresulta.DataBind();
            Guardar(3,1);
            cierracom4s9(Page);
            abrecom2(Page);
            abrecom3a(Page);
            abrecom5(Page);
            siguienteini.Visible = false;
            agregar01a.Visible = true;
        }
        protected void P93_Click(object sender, EventArgs e)
        {
            int actual = 0;
            HttpContext.Current.Session["actual"] = actual.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["actual"].ToString());
            lb_III01.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";// nombre de la persona
                                                                                                                           //lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
                                                                                                                           //lb_IIIe101e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe100e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe102e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe103e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe2e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe3e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe4e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe5e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe6e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe7e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1301e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe1302e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe10e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe8e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            lb_IIIe12e2.Text = Gvresulta.Rows[actual].Cells[1].Text;
            //Label17.Text = "Inicio de la captura de personas";
            //Label10.Text = "Ahora los datos solicitados cosrresponderan a " + Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
            //programmaticModalPopup.Show();
            //Image2.ImageUrl = "Images/Cortinilla3A.JPG";
            //Label20.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
            //programmaticModalPopup3.Show();
            Label21.Text = Gvresulta.Rows[actual].Cells[1].Text + " de " + Gvresulta.Rows[actual].Cells[3].Text + " años";
            cierracom4s9(Page);
            abrecom4q6(Page);
            cierracom2(Page);
            cierracom3a(Page);
            cierracom4(Page);
            cierracom4p(Page);
            cierracom5(Page);
            int cuenta = 1;
            HttpContext.Current.Session["cuenta"] = cuenta.ToString();
            cuenta = Convert.ToInt32(HttpContext.Current.Session["cuenta"].ToString());
            int p1 = 1;
            HttpContext.Current.Session["p1"] = p1.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["p1"].ToString());
            int p2 = 1;
            HttpContext.Current.Session["p2"] = p2.ToString();
            actual = Convert.ToInt32(HttpContext.Current.Session["p2"].ToString());
            Avance_barra(1);
            //abrecom6(Page);
            //abrecom7(Page);
            //abrecom100(Page);
        }
        void Guardar(int modo, int per)
        {
            switch (modo)
            {
                case 1:
                    string oradb1 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn1 = new OracleConnection(); // C#
                    conn1.ConnectionString = oradb1.ToString();
                    conn1.Open();
                    try
                    {
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn1;
                        cmd3.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','31')";
                        cmd3.CommandType = CommandType.Text;
                        int k = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn1.Dispose();
                    }
                    break;
                case 2:
                    string oradb2 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn2 = new OracleConnection(); // C#
                    conn2.ConnectionString = oradb2.ToString();
                    conn2.Open();
                    try
                    {
                        int i = 0;
                        for (i = 0; i < Gvresulta.Rows.Count; i++)
                        {
                            OracleCommand miComando = new OracleCommand();
                            miComando.Connection = conn2;
                            miComando.CommandText = "insert into CAP_INT_TR_PERSONA (QR_VIV,NUMPER,NOMBRE,SEXO,EDAD,PARENT,PARENT_OTRO) VALUES (:P_QR_VIV,:P_NUMPER,:P_NOMBRE,:P_SEXO,:P_EDAD,:P_PARENT,:P_PARENT_OTRO)";
                            miComando.CommandType = CommandType.Text;
                            //Envio 2 parametros
                            miComando.Parameters.Add("P_QR_VIV", OracleDbType.NVarchar2);
                            miComando.Parameters["P_QR_VIV"].Value = HttpContext.Current.Session["qr_viv"].ToString();
                            miComando.Parameters.Add("P_NUMPER", OracleDbType.Int32);
                            miComando.Parameters["P_NUMPER"].Value = Convert.ToInt32(Gvresulta.Rows[i].Cells[0].Text);
                            miComando.Parameters.Add("P_NOMBRE", OracleDbType.NVarchar2);
                            miComando.Parameters["P_NOMBRE"].Value = Gvresulta.Rows[i].Cells[1].Text;
                            if (Gvresulta.Rows[i].Cells[2].Text == "Hombre")
                            {
                                miComando.Parameters.Add("P_SEXO", OracleDbType.Int32);
                                miComando.Parameters["P_SEXO"].Value = 1;
                            }
                            else if (Gvresulta.Rows[i].Cells[2].Text == "Mujer")
                            {
                                miComando.Parameters.Add("P_SEXO", OracleDbType.Int32);
                                miComando.Parameters["P_SEXO"].Value = 3;
                            }
                            miComando.Parameters.Add("P_EDAD", OracleDbType.Int32);
                            miComando.Parameters["P_EDAD"].Value = Convert.ToInt32(Gvresulta.Rows[i].Cells[3].Text);
                            if (Gvresulta.Rows[i].Cells[4].Text != "Jefa(e)" && Gvresulta.Rows[i].Cells[4].Text != "Esposa(o) o pareja" && Gvresulta.Rows[i].Cells[4].Text != "Hija(o)" && Gvresulta.Rows[i].Cells[4].Text != "Nieta(o)" && Gvresulta.Rows[i].Cells[4].Text != "Nuera o yerno" && Gvresulta.Rows[i].Cells[4].Text != "Madre o padre" && Gvresulta.Rows[i].Cells[4].Text != "Suegra (o)")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 8;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = Gvresulta.Rows[i].Cells[4].Text;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Jefa(e)")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 1;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Esposa(o) o pareja")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 2;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Hija(o)")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 3;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Nieta(o)")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 4;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Nuera o yerno")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 5;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Madre o padre")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 6;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            else if (Gvresulta.Rows[i].Cells[4].Text == "Suegra (o)")
                            {
                                miComando.Parameters.Add("P_PARENT", OracleDbType.Int32);
                                miComando.Parameters["P_PARENT"].Value = 7;
                                miComando.Parameters.Add("P_PARENT_OTRO", OracleDbType.NVarchar2);
                                miComando.Parameters["P_PARENT_OTRO"].Value = DBNull.Value; ;
                            }
                            int k = miComando.ExecuteNonQuery();
                            miComando.Dispose();
                        }
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn2.Dispose();
                    }
                    break;
                case 3:
                    string oradb3 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn3 = new OracleConnection(); // C#
                    conn3.ConnectionString = oradb3.ToString();
                    conn3.Open();
                    try
                    {
                        OracleCommand cdr1 = new OracleCommand();
                        cdr1.Connection = conn3;
                        cdr1.CommandText = "delete CAP_INT_TR_PERSONA where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                        cdr1.CommandType = CommandType.Text;
                        int k = cdr1.ExecuteNonQuery();
                        cdr1.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn3.Dispose();
                    }
                    break;
                case 4:
                    string oradb4 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn4 = new OracleConnection(); // C#
                    conn4.ConnectionString = oradb4.ToString();
                    conn4.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn4;
                        miComando.CommandText = "update CAP_INT_TR_VIVIENDA set NUMPERS = :P_NUMPERS, VERLIST = :P_VERLIST, NUMINF = :P_NUMINF, BAN_JEFE_MENOR = :P_BAN_JEFE_MENOR, BAN_CONYUGE = :P_BAN_CONYUGE, BAN_MENORES = :P_BAN_MENORES, BAN_INF_MENOR = :P_BAN_INF_MENOR, NINOS_VIV = :P_NINOS_VIV, NINOS_VIV_CUANTOS = :P_NINOS_VIV_CUANTOS, VERNINOS = :P_VERNINOS, BAN_NINOS = :P_BAN_NINOS where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_NUMPERS", OracleDbType.Int32);
                        miComando.Parameters["P_NUMPERS"].Value = Gvresulta.Rows.Count;
                        miComando.Parameters.Add("P_VERLIST", OracleDbType.Int32);
                        miComando.Parameters["P_VERLIST"].Value = 1;
                        miComando.Parameters.Add("P_NUMINF", OracleDbType.Int32);
                        miComando.Parameters["P_NUMINF"].Value = Convert.ToInt32(ViewState["SelectedContact"].ToString());
                        //Inicio de llenado de banderas de la lista de personas
                        //jefe menor
                        if (Convert.ToInt32(Gvresulta.Rows[0].Cells[3].Text) < 18)
                        {
                            miComando.Parameters.Add("P_BAN_JEFE_MENOR", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_JEFE_MENOR"].Value = 1;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_BAN_JEFE_MENOR", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_JEFE_MENOR"].Value = 0;
                        }
                        //mas de un conyuge
                        int i,j = 0;
                        for (i = 0; i < Gvresulta.Rows.Count; i++)
                        {
                            if (Gvresulta.Rows[i].Cells[4].Text == "Esposa(o) o pareja")
                            {
                                j++;
                            }
                        }
                        if (j > 1)
                        {
                            miComando.Parameters.Add("P_BAN_CONYUGE", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_CONYUGE"].Value = 1;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_BAN_CONYUGE", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_CONYUGE"].Value = 0;
                        }
                        //solo menores
                        j = 0;
                        for (i = 0; i < Gvresulta.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(Gvresulta.Rows[i].Cells[3].Text) < 18)
                            {
                                j++;
                            }
                        }
                        if (j >= Gvresulta.Rows.Count)
                        {
                            miComando.Parameters.Add("P_BAN_MENORES", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_MENORES"].Value = 1;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_BAN_MENORES", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_MENORES"].Value = 0;
                        }
                        //informante menor
                        if (Convert.ToInt32(Gvresulta.Rows[Convert.ToInt32(ViewState["SelectedContact"].ToString())].Cells[3].Text) < 18)
                        {
                            miComando.Parameters.Add("P_BAN_INF_MENOR", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_INF_MENOR"].Value = 1;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_BAN_INF_MENOR", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_INF_MENOR"].Value = 0;
                        }
                        //Fin de llenado de banderas de la lista de personas
                        if (rv01.Checked == true)
                        {
                            miComando.Parameters.Add("P_NINOS_VIV", OracleDbType.Int32);
                            miComando.Parameters["P_NINOS_VIV"].Value = 1;
                            miComando.Parameters.Add("P_NINOS_VIV_CUANTOS", OracleDbType.Int32);
                            miComando.Parameters["P_NINOS_VIV_CUANTOS"].Value = Convert.ToInt32(string.IsNullOrEmpty(tb_LP8.Text) ? tb_LP8.Text = "0" : tb_LP8.Text);
                            if (Convert.ToInt32(HttpContext.Current.Session["banninos"].ToString()) == 1)
                            {
                                miComando.Parameters.Add("P_VERNINOS", OracleDbType.Int32);
                                miComando.Parameters["P_VERNINOS"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_VERNINOS", OracleDbType.Int32);
                                miComando.Parameters["P_VERNINOS"].Value = 1;
                            }
                            miComando.Parameters.Add("P_BAN_NINOS", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_NINOS"].Value = Convert.ToInt32(HttpContext.Current.Session["banninos"].ToString());
                        }
                        else if (rv02.Checked == true)
                        {
                            miComando.Parameters.Add("P_NINOS_VIV", OracleDbType.Int32);
                            miComando.Parameters["P_NINOS_VIV"].Value = 3;
                            miComando.Parameters.Add("P_NINOS_VIV_CUANTOS", OracleDbType.Int32);
                            miComando.Parameters["P_NINOS_VIV_CUANTOS"].Value = DBNull.Value;
                            if (Convert.ToInt32(HttpContext.Current.Session["banninos"].ToString()) == 1)
                            {
                                miComando.Parameters.Add("P_VERNINOS", OracleDbType.Int32);
                                miComando.Parameters["P_VERNINOS"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_VERNINOS", OracleDbType.Int32);
                                miComando.Parameters["P_VERNINOS"].Value = 1;
                            }
                            miComando.Parameters.Add("P_BAN_NINOS", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_NINOS"].Value = Convert.ToInt32(HttpContext.Current.Session["banninos"].ToString());
                        }
                        else
                        {
                            miComando.Parameters.Add("P_NINOS_VIV", OracleDbType.Int32);
                            miComando.Parameters["P_NINOS_VIV"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_NINOS_VIV_CUANTOS", OracleDbType.Int32);
                            miComando.Parameters["P_NINOS_VIV_CUANTOS"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_VERNINOS", OracleDbType.Int32);
                            miComando.Parameters["P_VERNINOS"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_BAN_NINOS", OracleDbType.Int32);
                            miComando.Parameters["P_BAN_NINOS"].Value = DBNull.Value;
                        }
                        int k = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn4.Dispose();
                    }
                    break;
                case 5:
                    string oradb5 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn5 = new OracleConnection(); // C#
                    conn5.ConnectionString = oradb5.ToString();
                    conn5.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn5;
                        miComando.CommandText = "update CAP_INT_TR_PERSONA set ENT_NAC_AQUI = :P_ENT_NAC_AQUI, ENT_NAC_OTRO = :P_ENT_NAC_OTRO, ENT_NAC_USA = :P_ENT_NAC_USA, ENT_NAC_PAIS = :P_ENT_NAC_PAIS, DHSERSAL1 = :P_DHSERSAL1, DHSERSAL2 = :P_DHSERSAL2, RELIGION = :P_RELIGION, AFRODES = :P_AFRODES, HLENGUA = :P_HLENGUA, QDIALECT = :P_QDIALECT, HESPANOL = :P_HESPANOL, ASISTEN = :P_ASISTEN, ESCOLARI = :P_ESCOLARI, NIVACAD = :P_NIVACAD, ALFABET = :P_ALFABET, ENT_RESI12_AQUI = :P_ENT_RESI12_AQUI, ENT_RESI12_OTRO = :P_ENT_RESI12_OTRO, ENT_RESI12_USA = :P_ENT_RESI12_USA, ENT_RESI12_PAIS = :P_ENT_RESI12_PAIS, SITUA_CONYUGAL = :P_SITUA_CONYUGAL, TRABAJO = :P_TRABAJO, ACTIVIDADES_EA = :P_ACTIVIDADES_EA, ACTIVIDADES_EI = :P_ACTIVIDADES_EI where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "' AND NUMPER = " + per + "";
                        //miComando.CommandText = "update CAP_INT_TR_PERSONA set ENT_NAC_AQUI = :P_ENT_NAC_AQUI, ENT_NAC_OTRO = :P_ENT_NAC_OTRO, ENT_NAC_USA = :P_ENT_NAC_USA, ENT_NAC_PAIS = :P_ENT_NAC_PAIS, DHSERSAL1 = :P_DHSERSAL1, DHSERSAL2 = :P_DHSERSAL2, RELIGION = :P_RELIGION, AFRODES = :P_AFRODES, HLENGUA = :P_HLENGUA, QDIALECT = :P_QDIALECT, HESPANOL = :P_HESPANOL, ASISTEN = :P_ASISTEN, ESCOLARI = :P_ESCOLARI, NIVACAD = :P_NIVACAD, ALFABET = :P_ALFABET, ENT_RESI12_AQUI = :P_ENT_RESI12_AQUI, ENT_RESI12_OTRO = :P_ENT_RESI12_OTRO, ENT_RESI12_USA = :P_ENT_RESI12_USA, ENT_RESI12_PAIS = :P_ENT_RESI12_PAIS, SITUA_CONYUGAL = :P_SITUA_CONYUGAL where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        if (radioC1001.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_NAC_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_AQUI"].Value = 1;
                            miComando.Parameters.Add("P_ENT_NAC_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_PAIS"].Value = DBNull.Value;
                        }
                        else if (radioC1002.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_NAC_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_OTRO"].Value = tb_IIIe1002.Text;
                            miComando.Parameters.Add("P_ENT_NAC_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_PAIS"].Value = DBNull.Value;
                        }
                        else if (radioC1003.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_NAC_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_USA"].Value = 3;
                            miComando.Parameters.Add("P_ENT_NAC_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_PAIS"].Value = DBNull.Value;
                        }
                        else if (radioC1004.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_NAC_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_PAIS"].Value = tb_IIIe1004.Text;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_ENT_NAC_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_NAC_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_NAC_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_NAC_PAIS"].Value = DBNull.Value;
                        }
                        if (CheckBox8.Checked == true)
                        {
                            miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                            miComando.Parameters["P_DHSERSAL1"].Value = 8;
                            miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                            miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                        }
                        else if (CheckBox1.Checked == true)
                        {
                            if (CheckBox2.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 2;
                            }
                            else if (CheckBox3.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 3;
                            }
                            else if (CheckBox4.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 4;
                            }
                            else if (CheckBox5.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 5;
                            }
                            else if (CheckBox6.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 6;
                            }
                            else if (CheckBox7.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 7;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 1;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                            }
                        }
                        else if (CheckBox2.Checked == true)
                        {
                            if (CheckBox3.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 2;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 3;
                            }
                            else if (CheckBox4.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 2;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 4;
                            }
                            else if (CheckBox5.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 2;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 5;
                            }
                            else if (CheckBox6.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 2;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 6;
                            }
                            else if (CheckBox7.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 2;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 7;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 2;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                            }
                        }
                        else if (CheckBox3.Checked == true)
                        {
                            if (CheckBox4.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 3;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 4;
                            }
                            else if (CheckBox5.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 3;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 5;
                            }
                            else if (CheckBox6.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 3;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 6;
                            }
                            else if (CheckBox7.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 3;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 7;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 3;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                            }
                        }
                        else if (CheckBox4.Checked == true)
                        {
                            if (CheckBox5.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 4;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 5;
                            }
                            else if (CheckBox6.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 4;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 6;
                            }
                            else if (CheckBox7.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 4;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 7;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 4;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                            }
                        }
                        else if (CheckBox5.Checked == true)
                        {
                            if (CheckBox6.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 5;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 6;
                            }
                            else if (CheckBox7.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 5;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 7;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 5;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                            }
                        }
                        else if (CheckBox6.Checked == true)
                        {
                            if (CheckBox7.Checked == true)
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 6;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = 7;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL1"].Value = 6;
                                miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                                miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                            }
                        }
                        else if (CheckBox7.Checked == true)
                        {
                            miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                            miComando.Parameters["P_DHSERSAL1"].Value = 7;
                            miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                            miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;

                        }
                        else
                        {
                            miComando.Parameters.Add("P_DHSERSAL1", OracleDbType.Int32);
                            miComando.Parameters["P_DHSERSAL1"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_DHSERSAL2", OracleDbType.Int32);
                            miComando.Parameters["P_DHSERSAL2"].Value = DBNull.Value;
                        }
                        if (tb_IIIe1021.Text == "")
                        {
                            miComando.Parameters.Add("P_RELIGION", OracleDbType.NVarchar2);
                            miComando.Parameters["P_RELIGION"].Value = DBNull.Value;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_RELIGION", OracleDbType.NVarchar2);
                            miComando.Parameters["P_RELIGION"].Value = tb_IIIe1021.Text;
                        }
                        if (radioC1031.Checked == true)
                        {
                            miComando.Parameters.Add("P_AFRODES", OracleDbType.Int32);
                            miComando.Parameters["P_AFRODES"].Value = 1;
                        }
                        else if (radioC1033.Checked == true)
                        {
                            miComando.Parameters.Add("P_AFRODES", OracleDbType.Int32);
                            miComando.Parameters["P_AFRODES"].Value = 3;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_AFRODES", OracleDbType.Int32);
                            miComando.Parameters["P_AFRODES"].Value = DBNull.Value;
                        }
                        if (radioD1.Checked == true)
                        {
                            miComando.Parameters.Add("P_HLENGUA", OracleDbType.Int32);
                            miComando.Parameters["P_HLENGUA"].Value = 5;
                            if (tb_IIIe31.Text == "")
                            {
                                miComando.Parameters.Add("P_QDIALECT", OracleDbType.NVarchar2);
                                miComando.Parameters["P_QDIALECT"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_QDIALECT", OracleDbType.NVarchar2);
                                miComando.Parameters["P_QDIALECT"].Value = tb_IIIe31.Text;
                            }
                            if (radioE1.Checked == true)
                            {
                                miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                                miComando.Parameters["P_HESPANOL"].Value = 1;
                            }
                            else if (radioE2.Checked == true)
                            {
                                miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                                miComando.Parameters["P_HESPANOL"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                                miComando.Parameters["P_HESPANOL"].Value = DBNull.Value;
                            }
                        }
                        else if (radioD2.Checked == true)
                        {
                            miComando.Parameters.Add("P_HLENGUA", OracleDbType.Int32);
                            miComando.Parameters["P_HLENGUA"].Value = 7;
                            miComando.Parameters.Add("P_QDIALECT", OracleDbType.NVarchar2);
                            miComando.Parameters["P_QDIALECT"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                            miComando.Parameters["P_HESPANOL"].Value = DBNull.Value;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_HLENGUA", OracleDbType.Int32);
                            miComando.Parameters["P_HLENGUA"].Value = DBNull.Value;
                            if (tb_IIIe31.Text == "")
                            {
                                miComando.Parameters.Add("P_QDIALECT", OracleDbType.NVarchar2);
                                miComando.Parameters["P_QDIALECT"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_QDIALECT", OracleDbType.NVarchar2);
                                miComando.Parameters["P_QDIALECT"].Value = tb_IIIe31.Text;
                            }
                            if (radioE1.Checked == true)
                            {
                                miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                                miComando.Parameters["P_HESPANOL"].Value = 1;
                            }
                            else if (radioE2.Checked == true)
                            {
                                miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                                miComando.Parameters["P_HESPANOL"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_HESPANOL", OracleDbType.Int32);
                                miComando.Parameters["P_HESPANOL"].Value = DBNull.Value;
                            }
                        }
                        //AQUI ME QUEDE SIGUE ASISTE A LA ESCUELA
                        if (radioF1.Checked == true)
                        {
                            miComando.Parameters.Add("P_ASISTEN", OracleDbType.Int32);
                            miComando.Parameters["P_ASISTEN"].Value = 5;
                        }
                        else if (radioF2.Checked == true)
                        {
                            miComando.Parameters.Add("P_ASISTEN", OracleDbType.Int32);
                            miComando.Parameters["P_ASISTEN"].Value = 7;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_ASISTEN", OracleDbType.Int32);
                            miComando.Parameters["P_ASISTEN"].Value = DBNull.Value;
                        }
                        if (radioG1.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            miComando.Parameters["P_ESCOLARI"].Value = 0;
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 0;
                            if (radioH1.Checked == true)
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = 1;
                            }
                            else if (radioH2.Checked == true)
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                            }
                        }
                        else if (radioG2.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe62.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe62.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 1;
                            if (radioH1.Checked == true)
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = 1;
                            }
                            else if (radioH2.Checked == true)
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                            }
                        }
                        else if (radioG3.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe63.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe63.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 2;
                            if (radioH1.Checked == true)
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = 1;
                            }
                            else if (radioH2.Checked == true)
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = 3;
                            }
                            else
                            {
                                miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                                miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                            }
                        }
                        else if (radioG4.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe64.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe64.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 3;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG5.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe65.Text);
                            if (string.IsNullOrEmpty(tb_IIIe65.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe65.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 4;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG6.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe66.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe66.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 5;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG7.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe67.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe67.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 6;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG8.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe68.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe68.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 7;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG9.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe69.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe69.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 8;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG10.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe610.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe610.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 9;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG11.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe611.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe611.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 10;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG12.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe612.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe612.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 11;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG13.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe613.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe613.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 12;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG14.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe614.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe614.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 13;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else if (radioG15.Checked == true)
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            if (string.IsNullOrEmpty(tb_IIIe615.Text))
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            }
                            else
                            {
                                miComando.Parameters["P_ESCOLARI"].Value = Convert.ToInt32(tb_IIIe615.Text);
                            }
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = 14;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_ESCOLARI", OracleDbType.Int32);
                            miComando.Parameters["P_ESCOLARI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_NIVACAD", OracleDbType.Int32);
                            miComando.Parameters["P_NIVACAD"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ALFABET", OracleDbType.Int32);
                            miComando.Parameters["P_ALFABET"].Value = DBNull.Value;
                        }
                        if (radioC1301.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_RESI12_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_AQUI"].Value = 1;
                            miComando.Parameters.Add("P_ENT_RESI12_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_PAIS"].Value = DBNull.Value;
                        }
                        else if (radioC1302.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_RESI12_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_OTRO"].Value = tb_IIIe1302.Text;
                            miComando.Parameters.Add("P_ENT_RESI12_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_PAIS"].Value = DBNull.Value;
                        }
                        else if (radioC1303.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_RESI12_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_USA"].Value = 3;
                            miComando.Parameters.Add("P_ENT_RESI12_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_PAIS"].Value = DBNull.Value;
                        }
                        else if (radioC1304.Checked == true)
                        {
                            miComando.Parameters.Add("P_ENT_RESI12_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_PAIS"].Value = tb_IIIe1304.Text;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_ENT_RESI12_AQUI", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_AQUI"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_OTRO", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_OTRO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_USA", OracleDbType.Int32);
                            miComando.Parameters["P_ENT_RESI12_USA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ENT_RESI12_PAIS", OracleDbType.NVarchar2);
                            miComando.Parameters["P_ENT_RESI12_PAIS"].Value = DBNull.Value;
                        }
                        if (radioC13021.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 1;
                        }
                        else if (radioC13022.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 2;
                        }
                        else if (radioC13023.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 3;
                        }
                        else if (radioC13024.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 4;
                        }
                        else if (radioC13025.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 5;
                        }
                        else if (radioC13026.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 6;
                        }
                        else if (radioC13027.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 7;
                        }
                        else if (radioC13028.Checked == true)
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = 8;
                        }
                        else
                        {
                            miComando.Parameters.Add("P_SITUA_CONYUGAL", OracleDbType.Int32);
                            miComando.Parameters["P_SITUA_CONYUGAL"].Value = DBNull.Value;
                        }
                        if (radioI101.Checked == true)
                        {
                            miComando.Parameters.Add("P_TRABAJO", OracleDbType.Int32);
                            miComando.Parameters["P_TRABAJO"].Value = 1;
                            miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                            miComando.Parameters["P_ACTIVIDADES_EA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                            miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                        }
                        else if (radioI102.Checked == true)
                        {
                            miComando.Parameters.Add("P_TRABAJO", OracleDbType.Int32);
                            miComando.Parameters["P_TRABAJO"].Value = 3;
                            if (radioI1.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 1;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            else if (radioI2.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 2;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            else if (radioI3.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 3;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            else if (radioI4.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 4;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            else if (radioI5.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 5;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            else if (radioI6.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 6;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            else if (radioI7.Checked == true)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 7;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                            //else if (radioI8.Checked == true)
                            else if (radioI8.Checked == true || regreso[17] == 1)
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = 8;
                                if (radioI121.Checked == true)
                                {
                                    miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                    miComando.Parameters["P_ACTIVIDADES_EI"].Value = 1;
                                }
                                else if (radioI122.Checked == true)
                                {
                                    miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                    miComando.Parameters["P_ACTIVIDADES_EI"].Value = 2;
                                }
                                else if (radioI123.Checked == true)
                                {
                                    miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                    miComando.Parameters["P_ACTIVIDADES_EI"].Value = 3;
                                }
                                else if (radioI124.Checked == true)
                                {
                                    miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                    miComando.Parameters["P_ACTIVIDADES_EI"].Value = 4;
                                }
                                else if (radioI125.Checked == true)
                                {
                                    miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                    miComando.Parameters["P_ACTIVIDADES_EI"].Value = 5;
                                }
                                else
                                {
                                    miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                    miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                                }
                            }
                            else
                            {
                                miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EA"].Value = DBNull.Value;
                                miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                                miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                            }
                        }
                        else
                        {
                            miComando.Parameters.Add("P_TRABAJO", OracleDbType.Int32);
                            miComando.Parameters["P_TRABAJO"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ACTIVIDADES_EA", OracleDbType.Int32);
                            miComando.Parameters["P_ACTIVIDADES_EA"].Value = DBNull.Value;
                            miComando.Parameters.Add("P_ACTIVIDADES_EI", OracleDbType.Int32);
                            miComando.Parameters["P_ACTIVIDADES_EI"].Value = DBNull.Value;
                        }
                        int k = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                        //OracleCommand cmd5 = new OracleCommand();
                        //cmd5.Connection = conn5;
                        //cmd5.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','31')";
                        //cmd5.CommandType = CommandType.Text;
                        //int l = cmd5.ExecuteNonQuery();
                        //cmd5.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn5.Dispose();
                    }
                    break;
                case 6:
                    string oradb6 = ConfigurationManager.AppSettings["cai2020"];
                    OracleConnection conn6 = new OracleConnection(); // C#
                    conn6.ConnectionString = oradb6.ToString();
                    conn6.Open();
                    try
                    {
                        OracleCommand miComando = new OracleCommand();
                        miComando.Connection = conn6;
                        miComando.CommandText = "update CAP_INT_TR_VIVIENDA set NUMPERS = :P_NUMPERS where qr_viv = '" + HttpContext.Current.Session["qr_viv"].ToString() + "'";
                        miComando.CommandType = CommandType.Text;
                        //Envio 2 parametros
                        miComando.Parameters.Add("P_NUMPERS", OracleDbType.Int32);
                        miComando.Parameters["P_NUMPERS"].Value = 0;
                        int k = miComando.ExecuteNonQuery();
                        miComando.Dispose();
                        OracleCommand cmd3 = new OracleCommand();
                        cmd3.Connection = conn6;
                        cmd3.CommandText = "insert into CAP_INT_TH_LLENADO (QR_VIV,RES_VIS) VALUES ('" + HttpContext.Current.Session["qr_viv"].ToString() + "','33')";
                        cmd3.CommandType = CommandType.Text;
                        int n = cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                    }
                    catch (Exception e1)
                    {
                        HttpContext.Current.Session["MensajeDeError"] = e1.ToString();
                    }
                    finally
                    {
                        conn6.Dispose();
                    }
                    break;
            }
        }
    }
}