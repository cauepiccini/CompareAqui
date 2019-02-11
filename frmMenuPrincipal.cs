using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareAqui
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void BtnAdm_Click(object sender, EventArgs e)
        {
            frmAdm adm = new frmAdm();
            adm.ShowDialog();
            this.Show();
        }

        private void BtnEmpresa_Click(object sender, EventArgs e)
        {
            FrmLogin empresa = new FrmLogin();
            empresa.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new frmCadastra().Show();
        }

        private void lnkCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmRecuperaSenhaUsu().Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();

            Usuario.Email = txtEmail.Text;
            Usuario.Senha = txtSenha.Text;

            bool logado = usu.PegarDados();
            if (logado == true)
            {
                this.Hide();
                frmMenuUsu menu = new frmMenuUsu();
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario e/ou Senha incorreto(s)");
            }
        }

        bool desmascarar;

        private void btnVerSenha_Click(object sender, EventArgs e)
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

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Você deseja mesmo finalizar sua sessão", "Zaori", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
        }
    }
}
