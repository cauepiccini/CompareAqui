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
    public partial class frmPerfil : Form
    {
        public frmPerfil()
        {
            InitializeComponent();
        }

        private void CarregaDado()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT usu_nome, usu_email, usu_nascimento, usu_sexo FROM tb_usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            MySqlDataReader le = cmd.ExecuteReader();
            while (le.Read())
            {
                lblEmail.Text = le["usu_email"].ToString();
                lblNascimento.Text = le["usu_nascimento"].ToString();
                lblNome.Text = "Bem Vindo: " + le["usu_nome"].ToString();
                lblSexo.Text = le["usu_sexo"].ToString();
            }
            conn.Close();
        }

        private void frmPerfil_Load(object sender, EventArgs e)
        {
            CarregaDado();
            pnlConfig.Visible = false;
        }

        private void btnListas_Click(object sender, EventArgs e)
        {
            new frmLista().Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new frmMenuUsu().Show();
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = false;
        }

        private void picConfig_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = true;
        }

        private void btnAlterarConta_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAlteraCadastroUsu().Show();
        }

        private void btnExcluirConta_Click(object sender, EventArgs e)
        {
            Usuario.Email = lblEmail.Text;

            Usuario usu = new Usuario();

            usu.ExcluirDados();
        }
    }
}
