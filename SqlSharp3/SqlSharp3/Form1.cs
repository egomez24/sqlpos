using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SqlSharp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection miconexion;
        //SqlDataAdapter tadapter;
        SqlCommand micomando;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            indicador1();
            Form2 frm2 = new Form2();
            frm2.Opacity = 0;
            frm2.ShowDialog();
            textBox1.Text = frm2.bobbie;
            label5.Visible = false;

        }

        void indicador1()
        {
            label5.Visible = true;
            label5.Text = "Leyendo";
            label5.ForeColor = System.Drawing.Color.Green;
        }

        private void guardar()
        {

            try
            {
                if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
                {
                    miconexion = new SqlConnection(@"Data source = TONYXDPC-PC\SQLEXPRESS;Initial Catalog = supermarket;User Id=sa;Password = hola26;");
                    miconexion.Open();
                    micomando = new SqlCommand(string.Format("Insert Into items (codigo,nombre,precio) Values (@Codigo,@Nombre,@Precio)"), miconexion);
                    micomando.Parameters.Add("@Codigo", SqlDbType.VarChar, 50);
                    micomando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
                    micomando.Parameters.Add("@Precio", SqlDbType.BigInt, 18);
                    micomando.Parameters["@Codigo"].Value = textBox1.Text;
                    micomando.Parameters["@Nombre"].Value = textBox2.Text;
                    micomando.Parameters["@Precio"].Value = Convert.ToInt32(textBox3.Text);
                    micomando.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    miconexion.Close();
                }
                else
                {
                    MessageBox.Show("Hay campos vacios", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                miconexion = new SqlConnection(@"Data source = TONYXDPC-PC\SQLEXPRESS;Initial Catalog = supermarket;User Id=sa;Password = hola26;");
                miconexion.Open();
                //string cadenalogi;
                //cadenalogi = "select * from wilmerantonio Where Codigo = '" + textBox1.Text "'";
                micomando = new SqlCommand(("Select * From items Where codigo = @Codigo"), miconexion);
                //micomando.Parameters.Add(new SqlParameter("Codigo", textBox1.Text));
                //micomando.Parameters.AddWithValue("@Codigo", textBox1.Text);
                //micomando.Parameters.Add(new SqlParameter("Codigo", textBox1.Text));
                //micomando.Parameters["@codigo"].Value = Convert.ToInt32(textBox1.Text);
                micomando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = textBox1.Text;
                dr = micomando.ExecuteReader();
                /*
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("codigo", typeof(string)));
                dt.Columns.Add(new DataColumn("nombre", typeof(string)));
                dt.Columns.Add(new DataColumn("precio", typeof(int)));
                //string codigorex;
                */
                if (dr.Read())
                {
                    //codigorex = (string)dr["Codigo"];
                    DataRow newRow = dt.NewRow();
                    newRow["codigo"] = dr["codigo"].ToString();
                    newRow["nombre"] = dr["nombre"].ToString();
                    newRow["precio"] = dr["precio"].ToString() ;
                    dt.Rows.Add(newRow);
                    dataGridView1.DataSource = dt;
                    miconexion.Close();
                }
                //tadapter = new SqlDataAdapter(micomando);
                //dt = new DataTable();
                //tadapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                //MessageBox.Show("Equal" + cadenalogi);
                //dt.Rows.Add()
                //dataGridView1.DataSource = dt;
            }
            catch (Exception Ex1)
            {
                MessageBox.Show("Error" + Ex1.ToString());
            }


            /*
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Codigo", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Precio", typeof(int)));
            dt.Rows.Add("k1","Kawameishon",800);
            int index = dataGridView1.Rows.Add();
            dataGridView1.DataSource = dt;
            label3.Text = dt.Cells[0].FormatedValue.ToString();
            dataGridView1.Rows[1].Cells[2].Value = "Hola";
            */

        }
        //private DataTable dt = new DataTable;
        private void Form1_Load(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString();
            dt.Columns.Add(new DataColumn("codigo", typeof(string)));
            dt.Columns.Add(new DataColumn("nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("precio", typeof(int)));
            dt.Columns.Add(new DataColumn("cantidad",typeof(int)));
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        static void fortress(String codigo, String nombre, String precio, String fcodigo)
        {


        }
        private void AddRow(DataTable table)
        {
            //Create an array with three elements.
            object[] rowVals = new object[3];
            DataRowCollection rowCollection = table.Rows;
            rowVals[0] = "hello";
            rowVals[1] = "wold";
            rowVals[2] = "two";
            // add and return the new row
            DataRow row = rowCollection.Add(rowVals);
        }


        private void consulta(string centos)
        {
            try
            {
                miconexion = new SqlConnection(@"Data source = TONYXDPC-PC\SQLEXPRESS;Initial Catalog = supermarket;User Id=sa;Password = hola26;");
                miconexion.Open();
                micomando = new SqlCommand((centos),miconexion);
                micomando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = textBox1.Text;
                dr = micomando.ExecuteReader();
                while (dr.Read())
                {
                    DataRow ncampo = dt.NewRow();
                    ncampo["codigo"] = dr["codigo"].ToString();
                    ncampo["nombre"] = dr["nombre"].ToString();
                    ncampo["precio"] = dr["precio"].ToString();
                    dt.Rows.Add(ncampo);
                }
                dataGridView1.DataSource = dt;
                miconexion.Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.ToString(), "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }
        private void Button4_Click(object sender, EventArgs e)
        {
            string consulta1;
            consulta1 = "Select * From items";
            consulta(consulta1);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                miconexion = new SqlConnection(@"Data source = TONYXDPC-PC\SQLEXPRESS;Initial Catalog = supermarket;User Id=sa;Password = hola26;");
                miconexion.Open();
                micomando = new SqlCommand(string.Format("Update items Set nombre = @nombre, precio = @precio Where codigo = @codigo"), miconexion);
                micomando.Parameters.Add("@codigo", SqlDbType.VarChar, 50);
                micomando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
                micomando.Parameters.Add("@Precio", SqlDbType.BigInt, 18);
                micomando.Parameters["@Codigo"].Value = textBox1.Text;
                micomando.Parameters["@Nombre"].Value = textBox2.Text;
                micomando.Parameters["@Precio"].Value = Convert.ToInt32(textBox3.Text);
                micomando.ExecuteNonQuery();
                miconexion.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.ToString(), "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

    }
}
