using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlSharp3
{
    public partial class Form2 : Form
    {
        public string bobbie1;
        public string bobbie
        {
            get{return bobbie1;}
            set{bobbie1 = value;}
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
        public string chapa1;
        public void interceptor(string j)
        {
            string cadena1;
            string cadena2;
            cadena1 = j;
            for (int x = 0; cadena1.Length > x; x++)
            {
                cadena2 = cadena1.Substring(x,1);
                {
                    if (cadena2 == "D" || cadena2 == "R")
                    {

                    }
                    else
                    {
                        chapa1 = chapa1 + cadena2;
                    }
                    if (cadena2 == "R")
                    {
                        bobbie1 = chapa1;
                        chapa1 = "";
                        Close();
                    }
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            interceptor(e.KeyCode.ToString()); ;
        }
    }
}
