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
    public partial class frmAlteraCadastroUsu : Form
    {
        public frmAlteraCadastroUsu()
        {
            InitializeComponent();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Usuario.Nome = txtNome.Text;
            Usuario.Email = txtEmail.Text;
            Usuario.Nascimento = mskNascimento.Text;
            Usuario.Senha = txtSenha.Text;

            if (rdbMasculino.Checked == true)
            {
                Usuario.Sexo = "Masculino";
            }
            else if (rdbFeminino.Checked == true)
            {
                Usuario.Sexo = "Feminino";
            }
            else
            {
                Usuario.Sexo = "Outro";
            }

            if (!txtEmail.Equals("@gmail.com") || !txtEmail.Equals("@hotmail.com") || !txtEmail.Equals("@outlook.com"))
            {
                if (txtConfirSenha.Text == txtSenha.Text)
                {
                    if (!txtNome.Equals("") && !txtEmail.Equals("") && !mskNascimento.Equals("") &&
                        !txtSenha.Equals("") && !txtConfirSenha.Equals(""))
                    {
                        Usuario usu = new Usuario();
                        usu.AlteraDados();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não deixe nenhum espaço em branco!");
                    }
                }
                else
                {
                    MessageBox.Show("Senhas não coincidem!");
                }
            }
            else
            {
                MessageBox.Show("Email incorreto");
            }
        }

        bool desmascarar;

        private void btnVeSenha_Click(object sender, EventArgs e)
        {
            if (desmascarar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                desmascarar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                desmascarar = true;
            }
        }

        private void btnMostraSenha_Click(object sender, EventArgs e)
        {
            if (desmascarar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                desmascarar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                desmascarar = true;
            }
        }

        private void frmAlteraCadastroUsu_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void CarregaDados()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT * FROM tb_usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                txtNome.Text = leitor["usu_nome"].ToString();
                txtEmail.Text = leitor["usu_email"].ToString();
                txtSenha.Text = leitor["usu_senha"].ToString();
                txtConfirSenha.Text = leitor["usu_senha"].ToString();
                mskNascimento.Text = leitor["usu_nascimento"].ToString();

                if (leitor["usu_sexo"].ToString() == "Masculino")
                {
                    rdbMasculino.Checked = true;
                    Usuario.Sexo = "Masculino";
                }
                else if (leitor["usu_sexo"].ToString() == "Feminino")
                {
                    rdbFeminino.Checked = true;
                    Usuario.Sexo = "Feminino";
                }
                else
                {
                    Usuario.Sexo = "Outro";
                }
            }
            conn.Close();
        }
    }
}
