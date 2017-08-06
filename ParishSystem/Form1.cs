using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParishSystem
{
    public partial class Form1 : Form
    {
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(metroScrollBar1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
          
            }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            
            */


        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt = dh.test(comboBox1.Text);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "profileid";
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
         
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // comboBox1.DroppedDown = false;
            //textBox1.Text = comboBox1.Text;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
    }
    /*
     this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;

RNProveedor rnProveedor = new RNProveedor();
var listaProveedores = rnProveedor.Buscar();
Dictionary<int, String> dicTemp = new Dictionary<int, string>();

foreach (var entidad in listaProveedores)
{
    dicTemp.Add(entidad.ProvNro, entidad.ProNombre);
}

this.DataSource = new BindingSource(dicTemp, null);
this.DisplayMember = "Value";
this.ValueMember = "Key";
     */

