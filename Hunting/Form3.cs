using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hunting
{

    public partial class Form3 : Form
    {
 
          
        public Form3()
        {
            InitializeComponent();
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer("VariationII.wav");
            sp.PlayLooping();
            Cursor.Show();

       
        }
       
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            //this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Hide();
                this.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true){
                checkBox2.Checked = false;
                catC.Text = "1";
            }
            else
            {
                checkBox2.Checked = true;
                catC.Text = "2";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                catC.Text = "2";
            }
            else
            {
                checkBox1.Checked = true;
                catC.Text = "1";
            }
        }
    }
}
