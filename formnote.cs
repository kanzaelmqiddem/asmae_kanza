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
    public partial class formnote : Form
    {
        public List<object[]> stagiairenompre = new List<object[]>();
        DataTable table = new DataTable();
        public formnote()
        {
            InitializeComponent();
            listenomprenom();
            listemodule();

            
        }

       

        
        public void listenomprenom()
        {

            try  
            {
                Methodes.connecter("tpado1");
                SqlDataReader dr = Methodes.selection("tpado1", "select Nom_Sta,Prenom_Sta from Stagiaire");

                while (dr.Read())
                {
                    comb_nom_pre.Items.Add(dr[1].ToString()+' '+dr[0].ToString());
                }
                dr.Close();

                Methodes.deconnecter("tpado1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        public void listemodule()
        {
            
            try   
            {
                Methodes.connecter("tpado1");
                SqlDataReader dr = Methodes.selection("tpado1", "select Nom_Mod from Module");

                while (dr.Read())
                {
                    comb_module.Items.Add(dr[0]);
                }
                dr.Close();

                Methodes.deconnecter("tpado1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btn_nv_Click(object sender, EventArgs e)
        {
            comb_nom_pre.Text = "";
            comb_module.Text = "";
            txt_note.Text="";
        }

        private void btn_enregi_Click(object sender, EventArgs e)
        {
            
            string nom_pre = comb_nom_pre.SelectedItem.ToString();
            string[] nom_complet = nom_pre.Split(new char [] { ' ' });
            string nom = nom_complet[1];
            string prenom = nom_complet[0];
            SqlDataReader dr=Methodes.selection("tpado1", "select Num_Sta from Stagiaire where  Nom_Sta='" + nom + "' and Prenom_Sta= '" + prenom + "' ");
            dr.Read();
            int numStag = (int)dr[0];

            string module = comb_module.SelectedItem.ToString();
            SqlDataReader rd = Methodes.selection("tpado1", "select Num_Mod from Module where Nom_Mod= '" + comb_module.SelectedItem.ToString() + "'");
            rd.Read();
            int nummodule = (int)rd[0];


            int result =Methodes.misajour("tpado1", "insert into Notes values ("+ numStag+","+ nummodule + ","+txt_note.Text+")");
            if(result == 0)
            {
                MessageBox.Show("Erreur");
            }
            else
            {
                MessageBox.Show("Ajouter aves succee");
            }
           

        }

        private void comb_module_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_modi_Click(object sender, EventArgs e)
        {
            try
            {
                Methodes.misajour("tpado1", "update Notes set Note='"+txt_note.Text + "'");
                MessageBox.Show("Modifier avec success");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }


        private void comb_nom_pre_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Methodes.connecter("tpado1");
            string nom_pre = comb_nom_pre.SelectedItem.ToString();
            string[] nom_complet = nom_pre.Split(new char[] { ' ' });
            string nom = nom_complet[1];
            string prenom = nom_complet[0];
            SqlDataReader dr = Methodes.selection("tpado1", "select Num_Sta from Stagiaire where  Nom_Sta='" + nom + "' and Prenom_Sta= '" + prenom + "' ");
            dr.Read();
            int numStag = (int)dr[0];
            SqlDataReader drr = Methodes.selection("tpado1", "select Module.Num_Mod, Module.Nom_Mod,Note from Stagiaire,Module,Notes where Stagiaire.Num_Sta = Notes.Num_Sta and Module.Num_Mod = Notes.Num_Mod and Stagiaire.Num_Sta="+numStag+"");

            while (drr.Read())
            {
                dataGridView1.Rows.Add(drr[0], drr[1], drr[2]);
                
            }
            drr.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_apercu_Click(object sender, EventArgs e)
        {

        }

        private void comb_module_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txt_note.Clear();
            string nom_pre = comb_nom_pre.SelectedItem.ToString();
            string[] nom_complet = nom_pre.Split(new char[] { ' ' });
            string nom = nom_complet[1];
            string prenom = nom_complet[0];
            SqlDataReader dr = Methodes.selection("tpado1", "select Num_Sta from Stagiaire where  Nom_Sta='" + nom + "' and Prenom_Sta= '" + prenom + "' ");
            dr.Read();
            int numStag = (int)dr[0];

            Methodes.connecter("tpado1");
            string module = comb_module.SelectedItem.ToString();
            SqlDataReader rd = Methodes.selection("tpado1", "select Num_Mod from Module where Nom_Mod= '" + comb_module.SelectedItem.ToString() + "'");
            rd.Read();
            int nummodule = (int)rd[0];

            SqlDataReader drr = Methodes.selection("tpado1", "select Module.Num_Mod, Module.Nom_Mod,Note from Stagiaire,Module,Notes where '"+nummodule+"' = Notes.Num_Mod and Stagiaire.Num_Sta = Notes.Num_Sta and Stagiaire.Num_Sta=" + numStag + " and Module.Num_Mod='"+nummodule+"'");
            while (drr.Read())
            {
                dataGridView1.Rows.Add(drr[0], drr[1], drr[2]);
                txt_note.Text = drr[2].ToString();

            }
           
            drr.Close();
        }

        private void formnote_Load(object sender, EventArgs e)
        {
           
        }

       
    }
}
