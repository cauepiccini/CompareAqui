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
    public partial class frmAlteraSenha : Form
    {
        public frmAlteraSenha()
        {
            InitializeComponent();
        }

        bool desmascarar;

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
            if (txtConfirmaSenha.Text.Equals(txtNovaSenha.Text))
            {
                string conex = "server=localhost;user=root;password=;database=db_compareaqui;";
                MySqlConnection cnx = new MySqlConnection(conex);

                string comando = "UPDATE tb_usuarioempresa SET usu_Senha='" + txtNovaSenha.Text + "';";
                MySqlCommand cmd = new MySqlCommand(comando, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alterado com sucesso!!!");
                cnx.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Os campos não coincidem! Verifique e tente novamente");
            }
            }
            private void btnVeSenha_Click(object sender, EventArgs e)
            {
                if (desmascarar == true)
                {
                    txtNovaSenha.UseSystemPasswordChar = false;
                    desmascarar = false;
                }
                else
                {
                    txtNovaSenha.UseSystemPasswordChar = true;
                    desmascarar = true;
                }
            }

            private void btnVeConfimacao_Click(object sender, EventArgs e)
            {
                if (desmascarar == true)
                {
                    txtConfirmaSenha.UseSystemPasswordChar = false;
                    desmascarar = false;
                }
                else
                {
                    txtConfirmaSenha.UseSystemPasswordChar = true;
                    desmascarar = true;
                }
            }
        }
    }
