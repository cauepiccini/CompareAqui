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
    public partial class frmCadastra : Form
    {
        public frmCadastra()
        {
            InitializeComponent();
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

        private void btnCadastrar_Click(object sender, EventArgs e)
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
                        usu.InsereDados();
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
    }
}
