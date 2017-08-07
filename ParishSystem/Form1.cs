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
            DataTable dt = dh.test(comboBox1.Text);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(new ComboboxContent(int.Parse(dr["profileID"].ToString()), dr["name"].ToString()));
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
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

