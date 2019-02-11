using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CompareAqui
{
    public partial class frmRecuperaSenhaUsu : Form
    {
        public frmRecuperaSenhaUsu()
        {
            InitializeComponent();
        }

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
            string conex = "server=localhost;user=root;password=;database=CompareAqui;";
            MySqlConnection cnx = new MySqlConnection(conex);

            string comand = "SELECT usu_senha FROM tb_usuario WHERE usu_email = '" + txtRecuperaSenha.Text + "';";
            MySqlDataAdapter da = new MySqlDataAdapter(comand, cnx);

            DataTable recupera = new DataTable();
            da.Fill(recupera);

            if (recupera.Rows.Count == 1)
            {
                frmAlteraSenhaUsu altera = new frmAlteraSenhaUsu();
                altera.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nenhum Usuário encontrado!");
            }
        }

    }
}
