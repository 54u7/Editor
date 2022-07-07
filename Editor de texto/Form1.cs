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

namespace Editor_de_texto
{
    public partial class Form1 : Form
    {
        string archivo;
        public Form1()
        {
            InitializeComponent();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Texto|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                archivo = open.FileName;

                using (StreamReader sr = new StreamReader(archivo))
                {
                    CajaTxt.Text = sr.ReadToEnd();
                }
                Form1.ActiveForm.Text = archivo + " | NOTE";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Texto|*.txt";


            if (archivo != null) 
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(CajaTxt.Text);
                }
            }
            else
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    archivo = save.FileName;
                    using (StreamWriter sw = new StreamWriter(save.FileName))
                    {
                        sw.Write(CajaTxt.Text);
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CajaTxt.Clear();
            archivo = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
