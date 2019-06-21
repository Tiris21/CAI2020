using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Xml;

namespace Cai2020
{
    public partial class CuestionarioPersona2 : System.Web.UI.Page
    {
        public static int cuenta;
        private bool isEditMode = false;
        int persona_actual=1;
        protected bool IsInEditMode
        {

            get { return this.isEditMode; }

            set { this.isEditMode = value; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cuenta = 0;
                abrecom2(Page);
                abrecom3(Page);
                //abrecom4(Page);
                //abrecom5(Page);
                ////abrecom5a(Page);
                //tb_IIe24.Visible = false;

                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
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


                //    Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                //    Gvresulta.DataBind();
                //    row = table.NewRow();
                //    row["CUENTA"] = "1";//Gvresulta.Rows[i].Cells[0].Text;
                //    row["NOMBRE"] = "";
                //    row["SEXO"] = "";
                //    row["EDAD"] = "";
                //    row["PARENTESCO"] = "Titular";
                //    table.Rows.Add(row);
                //    gv1.DataSource = dataSet.Tables["ParentTable"];
                //    gv1.DataBind();
                //}
                //if (radioB9.Checked == true)
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
                //else if (radioB9.Checked == false)
                //{
                //    abrecom2(Page);
                //    abrecom3(Page);
                //    //abrecom4(Page);
                //    //abrecom5(Page);
                //    ////abrecom5a(Page);
                //    tb_IIe24.Text = "";
                //    tb_IIe24.Visible = false;
                //    tb_IIe24.BackColor = System.Drawing.Color.White;
                //    //tb_IIe21.Focus();
                //    //tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                ayuda01.Attributes["data-content"] = leer_xml(cuenta);
                Avance_barra(0);
            }
        }

        void Avance_barra(int inicio)
        {
            double porcentaje = 0;
            int total_per = 3;
            int total_preg = 9;
            
            if (cuenta == 9 || cuenta==18 || cuenta==27 || cuenta==36 || cuenta==45)
            { ++persona_actual; }
            //cuenta = Int32.Parse(Session["pregunta_act"].ToString()) + 1;
            porcentaje = Math.Round((1.0 / total_per) * 100, 2);
            porcentaje = (porcentaje) * (persona_actual); //5 = (1 / int total_preg)*100
            barra_tot.Attributes["aria-valuenow"] = porcentaje.ToString();
            barra_tot.Attributes["style"] = "width:" + porcentaje + "%";
            avance_tot.Text = "Persona: " + (persona_actual) + " de " + total_per;
            //Session["pregunta_act"] = (1+ cuenta);
            if (porcentaje >= 100)
            {
                barra_tot.InnerHtml = "Completo!";
            }
            else
            {
                barra_tot.InnerHtml = "";
            }

            //barra de avance de las preguntas de cada persona
            porcentaje = Math.Round((1.0 / total_preg) * 100, 2);
            porcentaje = (porcentaje) * (1 + cuenta); //5 = (1 / int total_preg)*100
            barra.Attributes["aria-valuenow"] = porcentaje.ToString();
            barra.Attributes["style"] = "width:" + porcentaje + "%";
            avance.Text = "Pregunta: " + (1 + cuenta) + " de " + total_preg;
                //Session["pregunta_act"] = cuenta;
            if (porcentaje >= 100)
              {
                  barra.InnerHtml = "Completo!";
              }
            else
              {
                  barra.InnerHtml = "";
              }
            

        }

        protected string leer_xml(int numAyuda)
        {
            string txtAyuda = "";//"<div><b>Ejemplo usando un div interno</b> - content</div>";
            //XmlTextReader reader = new XmlTextReader("ayudas.xml");
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(MapPath("~/App_data/ayudas.xml"));

                XmlNodeList xAyudas = xDoc.GetElementsByTagName("Ayudas");
                XmlNodeList xLista = ((XmlElement)xAyudas[0]).GetElementsByTagName("ayuda");

                foreach (XmlElement nodo in xLista)
                {
                    if (Int32.Parse(nodo.GetAttribute("id")) == numAyuda)
                    {
                        txtAyuda = nodo.GetAttribute("descrip");
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

            //int i,j = 0;
            //for (i = 0; i < Gvresulta.Rows.Count; i++)
            //{
            //    if (Gvresulta.Rows[i].Cells[0].Text != slID.ToString())
            //    {
            //        j++;
            //        row = table.NewRow();
            //        row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
            //        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
            //        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
            //        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
            //        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
            //        table.Rows.Add(row);
            //    }
            //}
            //Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            //Gvresulta.DataBind();
            cadena1.Clear();
            tb_IIe11.BackColor = System.Drawing.Color.White;
            //tb_IIe21.Focus();
            //tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        protected void ImageButton4_Command(object sender, CommandEventArgs e)
        {
            if (tb_IIe11.Text == "")
            {
                tb_IIe11.Text = "0";
            }
            if (Convert.ToInt16(tb_IIe11.Text) > 0)//Gvresulta.Rows.Count)
            {
                tb_IIe11.BackColor = System.Drawing.Color.White;
                //tb_IIe21.Focus();
                //tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
                mensaje(Page, "La cantidad de personas registradas debe de ser igual al número de las personas que viven aquí");
            }
            else
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

                //int i, j = 0;
                //for (i = 0; i < Gvresulta.Rows.Count; i++)
                //{
                //        j++;
                //        row = table.NewRow();
                //        row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                //        row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                //        row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                //        row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                //        row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                //        table.Rows.Add(row);
                //}
                //Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                //Gvresulta.DataBind();
                //cadena1.Clear();

                cuenta += 1;
                lb_III01.Text = slClienteID.ToString();// nombre de la persona
                lb_IIIe1e2.Text = slClienteID.ToString();
                lb_IIIe2e2.Text = slClienteID.ToString();
                lb_IIIe3e2.Text = slClienteID.ToString();
                lb_IIIe4e2.Text = slClienteID.ToString();
                lb_IIIe5e2.Text = slClienteID.ToString();
                lb_IIIe6e2.Text = slClienteID.ToString();
                lb_IIIe7e2.Text = slClienteID.ToString();
                lb_IIIe8e2.Text = slClienteID.ToString();
                cierracom2(Page);
                cierracom3(Page);
                cierracom4(Page);
                cierracom5(Page);
                abrecom6(Page);
                abrecom7(Page);
                abrecom100(Page);
            }
        }

        protected void Gvresulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#cccccc';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }

        protected void agregar01_Click(object sender, EventArgs e)
        {
            //if (tb_IIe21.Text == "")
            //{
            //    mensaje(Page, "Debe escribir el nombre de la persona");
            //    tb_IIe11.BackColor = System.Drawing.Color.White;
            //    tb_IIe21.Focus();
            //    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            ////else if (RadioButtonList1.Items[0].Selected == false && RadioButtonList1.Items[1].Selected == false)
            //else if (radioA1.Checked == false && radioA2.Checked == false)
            //{
            //    mensaje(Page, "Debe elegir el sexo de la persona actual");
            //    tb_IIe11.BackColor = System.Drawing.Color.White;
            //    tb_IIe21.Focus();
            //    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            //else if (tb_IIe23.Text == "")
            //{
            //    mensaje(Page, "Debe escribir la edad de la persona");
            //    tb_IIe11.BackColor = System.Drawing.Color.White;
            //    tb_IIe21.Focus();
            //    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            //}
            ////else if (RadioButtonList2.Items[0].Selected == false && RadioButtonList2.Items[1].Selected == false && RadioButtonList2.Items[2].Selected == false && RadioButtonList2.Items[3].Selected == false && RadioButtonList2.Items[4].Selected == false && RadioButtonList2.Items[5].Selected == false && RadioButtonList2.Items[6].Selected == false && RadioButtonList2.Items[7].Selected == false && RadioButtonList2.Items[8].Selected == false)
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
            //else
            //{
            //    System.Data.DataTable table = new DataTable("ParentTable");
            //    // Declare variables for DataColumn and DataRow objects.
            //    DataColumn column;
            //    DataRow row;
            //    // Create new DataColumn, set DataType, 
            //    // ColumnName and add to DataTable. 
            //    column = new DataColumn();
            //    column.DataType = System.Type.GetType("System.String");
            //    column.ColumnName = "CUENTA";
            //    column.ReadOnly = false;
            //    column.Unique = false;
            //    // Add the Column to the DataColumnCollection.
            //    table.Columns.Add(column);
            //    column = new DataColumn();
            //    column.DataType = System.Type.GetType("System.String");
            //    column.ColumnName = "NOMBRE";
            //    column.ReadOnly = false;
            //    column.Unique = false;
            //    // Add the Column to the DataColumnCollection.
            //    table.Columns.Add(column);
            //    column = new DataColumn();
            //    column.DataType = System.Type.GetType("System.String");
            //    column.ColumnName = "SEXO";
            //    column.ReadOnly = false;
            //    column.Unique = false;
            //    // Add the Column to the DataColumnCollection.
            //    table.Columns.Add(column);
            //    column = new DataColumn();
            //    column.DataType = System.Type.GetType("System.String");
            //    column.ColumnName = "EDAD";
            //    column.ReadOnly = false;
            //    column.Unique = false;
            //    // Add the Column to the DataColumnCollection.
            //    table.Columns.Add(column);
            //    column = new DataColumn();
            //    column.DataType = System.Type.GetType("System.String");
            //    column.ColumnName = "PARENTESCO";
            //    column.ReadOnly = false;
            //    column.Unique = false;
            //    // Add the Column to the DataColumnCollection.
            //    table.Columns.Add(column);
            //    // Make the ID column the primary key column.
            //    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //    PrimaryKeyColumns[0] = table.Columns["id"];
            //    table.PrimaryKey = PrimaryKeyColumns;
            //    // Instantiate the DataSet variable.
            //    DataSet dataSet = new DataSet();
            //    //Add the new DataTable to the DataSet.
            //    dataSet.Tables.Add(table);
            //    int i, j = 0;
            //    for (i = 0; i < Gvresulta.Rows.Count; i++)
            //    {
            //            j++;
            //            row = table.NewRow();
            //            row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
            //            row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
            //            row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
            //            row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
            //            row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
            //            table.Rows.Add(row);
            //    }
            //    j++;
            //    row = table.NewRow();
            //    row["CUENTA"] = j.ToString();
            //    row["NOMBRE"] = tb_IIe21.Text;
            //    if (radioA1.Checked == true)
            //    {
            //        row["SEXO"] = "Hombre";
            //    }
            //    else if(radioA2.Checked == true)
            //    {
            //        row["SEXO"] = "Mujer";
            //    }
            //    row["EDAD"] = tb_IIe23.Text;
            //    if (radioB1.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Jefa(e)";
            //    }
            //    else if (radioB2.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Esposa(o) o pareja";
            //    }
            //    else if (radioB3.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Hija(o)";
            //    }
            //    else if (radioB4.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Nieta(o)";
            //    }
            //    else if (radioB5.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Nuera o yerno";
            //    }
            //    else if (radioB6.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Madre o padre";
            //    }
            //    else if (radioB7.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Suegra (o)";
            //    }
            //    else if (radioB8.Checked == true)
            //    {
            //        row["PARENTESCO"] = "Sin parentesco";
            //    }
            //    else if (radioB9.Checked == true)
            //    {
            //        row["PARENTESCO"] = tb_IIe24.Text;
            //    }
            //    table.Rows.Add(row);
            //    Gvresulta.DataSource = dataSet.Tables["ParentTable"];
            //    Gvresulta.DataBind();
            //    tb_IIe21.Text = "";
            //    radioA1.Checked = false;
            //    radioA2.Checked = false;
            //    tb_IIe23.Text = "";
            //    radioB1.Checked = false;
            //    radioB2.Checked = false;
            //    radioB3.Checked = false;
            //    radioB4.Checked = false;
            //    radioB5.Checked = false;
            //    radioB6.Checked = false;
            //    radioB7.Checked = false;
            //    radioB8.Checked = false;
            //    radioB9.Checked = false;
            //    tb_IIe24.Text = "";
            //    tb_IIe11.BackColor = System.Drawing.Color.White;
            //    tb_IIe21.Focus();
            //    tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
            //    if (radioB9.Checked == false)
            //    {
            //        tb_IIe24.Visible = false;
            //        tb_IIe24.BackColor = System.Drawing.Color.White;
            //    }
            //}
        }

        protected void agregar01a_Click(object sender, EventArgs e)
        {
            int m;
            if (tb_IIe11.Text == "")
            {
                m = 0;
            }
            else
            {
                m = Convert.ToInt16(tb_IIe11.Text);
            }
            if (m >= 1)
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
                //for (i = 0; i < Gvresulta.Rows.Count; i++)
                for (i = 0; i < Convert.ToInt16(tb_IIe11.Text); i++)
                {
                    j++;
                    row = table.NewRow();
                    row["CUENTA"] = j.ToString();//Gvresulta.Rows[i].Cells[0].Text;
                    row["NOMBRE"] = "";
                    row["SEXO"] = "";
                    row["EDAD"] = "";
                    if (j == 1)
                    {
                        row["PARENTESCO"] = "Jefa (e)";
                    }
                    else
                    {
                        row["PARENTESCO"] = "";
                    }
                    //row["NOMBRE"] = Gvresulta.Rows[i].Cells[1].Text;
                    //row["SEXO"] = Gvresulta.Rows[i].Cells[2].Text;
                    //row["EDAD"] = Gvresulta.Rows[i].Cells[3].Text;
                    //row["PARENTESCO"] = Gvresulta.Rows[i].Cells[4].Text;
                    table.Rows.Add(row);
                }
                //j++;
                //row = table.NewRow();
                //row["CUENTA"] = j.ToString();
                //row["NOMBRE"] = "Jefa(e)";
                //row["SEXO"] = "";
                //row["EDAD"] = "";
                //row["PARENTESCO"] = "";
                //table.Rows.Add(row);

                //Gvresulta.DataSource = dataSet.Tables["ParentTable"];
                //Gvresulta.DataBind();
                abrecom5(Page);
            }
            else
            {
                tb_IIe11.Focus();
                tb_IIe11.BackColor = System.Drawing.Color.LightSteelBlue;
                mensaje(Page, "La cantidad de habitantes de la vivienda debe de ser mayor a 0");
            }
        }

        //protected void ayuda01_Click(object sender, EventArgs e)
        //{

        //}
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
        protected void cierracom4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec004');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com4", codigo);
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

        protected void cierracom14(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divsub = document.getElementById('Sec014');divsub.style.display = 'none';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Close Com14"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Close Com14", codigo);
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
        protected void abrecom4(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec004');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com4"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com4", codigo);
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

        protected void abrecom14(System.Web.UI.Page pagina)
        {
            string codigo;
            codigo = "<script language='JavaScript'>var divcom1 = document.getElementById('Sec014');divcom1.style.display = '';</script>";
            if (!pagina.ClientScript.IsStartupScriptRegistered("Open Com14"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "Open Com14", codigo);
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
            cuenta -= 1;
            switch (cuenta)
            {
                case 1:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom7(Page);
                    abrecom100(Page);
                    cierrabot1(Page);
                    break;
                case 2:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom8(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 3:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom9(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    tb_IIIe31.BackColor = System.Drawing.Color.LightSteelBlue;
                    tb_IIIe31.Focus();
                    break;
                case 4:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom10(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 5:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom11(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 6:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom12(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 7:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom13(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 8:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom14(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                default:
                    cuenta = 8;
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom14(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
            }
            ayuda01.Attributes["data-content"] = leer_xml(cuenta);
            Avance_barra(1);
        }

        protected void adelante01_Click(object sender, EventArgs e)
        {
            cuenta += 1;
            switch (cuenta)
            {
                case 1:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom7(Page);
                    abrecom100(Page);
                    cierrabot1(Page);
                    break;
                case 2:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom8(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 3:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom9(Page);
                    abrecom100(Page);
                    tb_IIIe31.BackColor = System.Drawing.Color.LightSteelBlue;
                    tb_IIIe31.Focus();
                    abrebot1(Page);
                    break;
                case 4:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom10(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 5:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom11(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 6:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom12(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 7:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom13(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                case 8:
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom14(Page);
                    abrecom100(Page);
                    abrebot1(Page);
                    break;
                default:
                    cuenta = 1;
                    cierracom2(Page);
                    cierracom3(Page);
                    cierracom4(Page);
                    cierracom5(Page);
                    cierracom6(Page);
                    cierracom7(Page);
                    cierracom8(Page);
                    cierracom9(Page);
                    cierracom10(Page);
                    cierracom11(Page);
                    cierracom12(Page);
                    cierracom13(Page);
                    cierracom14(Page);
                    cierracom100(Page);
                    abrecom6(Page);
                    abrecom7(Page);
                    abrecom100(Page);
                    cierrabot1(Page);
                    break;
            }
            ayuda01.Attributes["data-content"] = leer_xml(cuenta);
            Avance_barra(1);
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
            abrecom3(Page);
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
            radioC1.Checked = false;
            radioC2.Checked = false;
            radioC3.Checked = false;
            radioC4.Checked = false;
            radioC5.Checked = false;
            radioC6.Checked = false;
            radioC7.Checked = false;
            radioC8.Checked = false;
            radioD1.Checked = false;
            radioD2.Checked = false;
            tb_IIIe31.Text = "";
            radioE1.Checked = false;
            radioE2.Checked = false;
            radioF1.Checked = false;
            radioF2.Checked = false;
            //radioG1.Checked = false;
            //radioG2.Checked = false;
            //radioG3.Checked = false;
            //radioG4.Checked = false;
            //radioG5.Checked = false;
            //radioG6.Checked = false;
            //radioG7.Checked = false;
            //radioG8.Checked = false;
            //radioG9.Checked = false;
            //radioG10.Checked = false;
            //radioG11.Checked = false;
            //radioG12.Checked = false;
            //radioG13.Checked = false;
            //radioG14.Checked = false;
            //radioG15.Checked = false;
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
            radioI1.Checked = false;
            radioI2.Checked = false;
            radioI3.Checked = false;
            radioI4.Checked = false;
            radioI5.Checked = false;
            radioI6.Checked = false;
            radioI7.Checked = false;
            radioI8.Checked = false;
            radioI9.Checked = false;
            radioI10.Checked = false;
            radioI11.Checked = false;
            radioI12.Checked = false;
            radioI13.Checked = false;
            cuenta = 0;
            //tb_IIe24.Text = "";
            //tb_IIe11.BackColor = System.Drawing.Color.White;
            //tb_IIe21.Focus();
            //tb_IIe21.BackColor = System.Drawing.Color.LightSteelBlue;
        }
        protected void Guardar_todo_Click(object sender, EventArgs e)
        {
            cuenta = 0;
            Response.Redirect("CuestionarioVivienda.aspx");
        }

        protected void btn_lanzarc_Click(object sender, EventArgs e)
        {
            cuenta += 1;
            //lb_III01.Text = slClienteID.ToString();// nombre de la persona
            //lb_IIIe1e2.Text = slClienteID.ToString();
            //lb_IIIe2e2.Text = slClienteID.ToString();
            //lb_IIIe3e2.Text = slClienteID.ToString();
            //lb_IIIe4e2.Text = slClienteID.ToString();
            //lb_IIIe5e2.Text = slClienteID.ToString();
            //lb_IIIe6e2.Text = slClienteID.ToString();
            //lb_IIIe7e2.Text = slClienteID.ToString();
            //lb_IIIe8e2.Text = slClienteID.ToString();
            //string nom= tabla.Rows[0].Cells[2].FindControl("Nombre").ToString();
            lb_III01.Text = "Persona";// nombre de la persona
            lb_IIIe1e2.Text = "Persona";
            lb_IIIe2e2.Text = "Persona";
            lb_IIIe3e2.Text = "Persona";
            lb_IIIe4e2.Text = "Persona";
            lb_IIIe5e2.Text = "Persona";
            lb_IIIe6e2.Text = "Persona";
            lb_IIIe7e2.Text = "Persona";
            lb_IIIe8e2.Text = "Persona";

            cierracom2(Page);
            cierracom3(Page);
            cierracom4(Page);
            cierracom5(Page);
            abrecom6(Page);
            abrecom7(Page);
            abrecom100(Page);
        }

        //[System.Web.Services.WebMethod]
        //public static void guardarPersona(string[] persona)
        //{
            
        //    string numpers = persona[1].ToString();
        //    //empezarCuest(numpers);
        //    //foreach (var item in persona)
        //    //{

        //}

        //public void empezarCuest(string nombre)
        //{
        //    cuenta += 1;
        //    lb_III01.Text = nombre;// nombre de la persona
        //    lb_IIIe1e2.Text = nombre;
        //    lb_IIIe2e2.Text = nombre;
        //    lb_IIIe3e2.Text = nombre;
        //    lb_IIIe4e2.Text = nombre;
        //    lb_IIIe5e2.Text = nombre;
        //    lb_IIIe6e2.Text = nombre;
        //    lb_IIIe7e2.Text = nombre;
        //    lb_IIIe8e2.Text = nombre;

        //    cierracom2(Page);
        //    cierracom3(Page);
        //    cierracom4(Page);
        //    cierracom5(Page);
        //    abrecom6(Page);
        //    abrecom7(Page);
        //    abrecom100(Page);
        //}
    }
}