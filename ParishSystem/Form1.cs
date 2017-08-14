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
        treasurerBackend dh = new treasurerBackend();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = dh.getSummaryCashDisbursment(dh.getTransactionsByAccountingBookFormatRecent(1),1);
          //dataGridView1.DataSource=  dh.getSummaryCashDisbursment(dh.get(1),1);
        }//accounting book form
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

