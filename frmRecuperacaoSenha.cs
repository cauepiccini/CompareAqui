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
    public partial class frmRecuperacaoSenha : Form
    {
        public frmRecuperacaoSenha()
        {
            InitializeComponent();
        }

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
            string conex = "server=localhost;user=root;password=;database=CompareAqui;";
            MySqlConnection cnx = new MySqlConnection(conex);

            string comand = "SELECT usu_Senha FROM tb_usuarioempresa WHERE usu_Email = '" + txtRecuperaSenha.Text + "';";
            MySqlDataAdapter da = new MySqlDataAdapter(comand, cnx);

            DataTable recupera = new DataTable();
            da.Fill(recupera);

            if (recupera.Rows.Count == 1)
            {
                frmAlteraSenha altera = new frmAlteraSenha();
                altera.Show();
            }
            else
            {
                MessageBox.Show("Nenhum Usuário encontrado!");
            }
        }
    }
}
