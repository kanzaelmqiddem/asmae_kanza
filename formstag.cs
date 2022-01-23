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

namespace tpado1
{
    public partial class formstag : Form
    {
        public List<object[]> stagiaire = new List<object[]>();
        int position;
        public formstag()
        {
            InitializeComponent();
            fill();
            position = 0;
           
        }
        public void fill()
        {
            stagiaire.Clear();
            SqlDataReader rd = Methodes.selection("tpado1", "select * from Stagiaire");
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    stagiaire.Add(new object[] { rd[0], rd[1], rd[2], rd[3] });
                }
            }
            //    txt_num.Text = Convert.ToString(stagiaire[0][0]);
            //    txt_nomm.Text = Convert.ToString(stagiaire[0][1]);
            //    txt_pren.Text = Convert.ToString(stagiaire[0][2]);
            //    dateTime.Text = Convert.ToString(stagiaire[0][3]);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_num.Text = "";
            txt_nomm.Text = "";
            txt_pren.Text = "";
            dateTime.Value = DateTime.Now;
        }

        private void formstag_Load(object sender, EventArgs e)
        {

        }

        private void btn_enrgsta_Click(object sender, EventArgs e)
        {
            try
            {
                Methodes.connecter("tpado1");
                if (txt_num.Text == "" || txt_nomm.Text == "" || txt_pren.Text == "")
                {
                    MessageBox.Show("Champ vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Methodes.misajour("tpado1", "insert into Stagiaire values (" + int.Parse(txt_num.Text) + ",'" + txt_nomm.Text + "', '" + txt_pren.Text + "','"+ dateTime.Value.ToShortDateString() + "')");
                MessageBox.Show("Ajoutee avec succes");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void btn_modsta_Click(object sender, EventArgs e)
        {
            try
            {
                Methodes.connecter("tpado1");
                if (txt_num.Text == "" || txt_nomm.Text == "" || lbl_prenom.Text == "")
                {
                    MessageBox.Show("Champ vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Methodes.misajour("tpado1", "update Stagiaire set  Nom_Sta='" + txt_nomm.Text + "',Pre_Sta='" + txt_pren.Text + "',Date_Sta='" + dateTime.Value.ToShortDateString() + "' where Num_Sta="  + int.Parse(txt_num.Text));
                MessageBox.Show("Modifier avec succes");
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_supsta_Click(object sender, EventArgs e)
        {
          

            DialogResult res = MessageBox.Show("Voulez vraiment supprimer l'étudiant numéro: " , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res==DialogResult.Yes)
            {
                try
                {

                    Methodes.connecter("tpado1");
                    if (txt_num.Text == "" )
                    {
                        MessageBox.Show("Champ du numero d'inscription est vide!!", "champ vide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Methodes.selection("tpado1", "delete from Stagiaire where Num_Sta=" + int.Parse(txt_num.Text));
                    MessageBox.Show("Stagiaire bien supprimé", "supression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btn_dernier_Click(object sender, EventArgs e)
        {
            position = stagiaire.Count - 1;
            txt_num.Text = Convert.ToString(stagiaire[position][0]);
            txt_nomm.Text = Convert.ToString(stagiaire[position][1]);
            txt_pren.Text = Convert.ToString(stagiaire[position][2]);
            dateTime.Text = Convert.ToString(stagiaire[position][3]);
        }

        private void btn_premier_Click(object sender, EventArgs e)
        {
            position = 0;
            txt_num.Text = Convert.ToString(stagiaire[position][0]);
            txt_nomm.Text = Convert.ToString(stagiaire[position][1]);
            txt_pren.Text = Convert.ToString(stagiaire[position][2]);
            dateTime.Text = Convert.ToString(stagiaire[position][3]);
        }

        private void btn_precedent_Click(object sender, EventArgs e)
        {
            position--;
            if (position>=0)
            {
                txt_num.Text = Convert.ToString(stagiaire[position][0]);
                txt_nomm.Text = Convert.ToString(stagiaire[position][1]);
                txt_pren.Text = Convert.ToString(stagiaire[position][2]);
                dateTime.Text = Convert.ToString(stagiaire[position][3]);
            }
            else
            {
                position++;
                MessageBox.Show("C'est le premier stagiaire!!");
            }
        }

        private void btn_suivant_Click(object sender, EventArgs e)
        {
            position++;
            if (position <stagiaire.Count)
            {
                txt_num.Text = Convert.ToString(stagiaire[position][0]);
                txt_nomm.Text = Convert.ToString(stagiaire[position][1]);
                txt_pren.Text = Convert.ToString(stagiaire[position][2]);
                dateTime.Text = Convert.ToString(stagiaire[position][3]);
            }
            else
            {
                position--;
                MessageBox.Show("C'est le dernier stagiaire!!");
            }


        }

        private void btn_rech_num_Click(object sender, EventArgs e)
        {
            Methodes.connecter("tpado1");
            SqlDataReader dr =Methodes.selection("tpado1", "select * from  Stagiaire where Num_Sta="  +int.Parse(txt_num.Text));
            while (dr.Read())
            {
                txt_num.Text = dr[0].ToString();
                txt_nomm.Text = dr[1].ToString();
                txt_pren.Text = dr[2].ToString();
                dateTime.Text = dr[3].ToString();

            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = Methodes.selection("tpado1", "select * from  Stagiaire where Prenom_Sta=  '"+txt_pren.Text+"'and Nom_Sta= '"+ txt_nomm.Text+"'");
            while (dr.Read())
            {
                txt_num.Text = dr[0].ToString();
                txt_pren.Text = dr[1].ToString();
                txt_nomm.Text = dr[2].ToString();
               
                dateTime.Text = dr[3].ToString();

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       
        private void btn_moy_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = Methodes.selection("tpado1", "select SUM(Notes.Note)/COUNT(Notes.Note) from Notes,Module,Stagiaire where Module.Num_Mod = Notes.Num_Mod and Stagiaire.Num_Sta = Notes.Num_Sta and Stagiaire.Num_Sta=" + int.Parse(txt_num.Text) + "");
            while (dr.Read())
            {
                MessageBox.Show("Votre moyenne est :" + dr[0].ToString());
            }
        }
    }
}

