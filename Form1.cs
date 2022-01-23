using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpado1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            SetBackGroundColorOfMDIForm();

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gestionDesStagiairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formstag form1 = new formstag();
            form1.WindowState = FormWindowState.Maximized;
            form1.MdiParent = this;
            form1.Show();
        }

        private void gestionDesNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formnote form2 = new formnote();
            form2.WindowState = FormWindowState.Maximized;
            form2.MdiParent = this;
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)

                {
                    ctl.BackColor = System.Drawing.Color.LemonChiffon;
                }
            }
        }
    }
}
