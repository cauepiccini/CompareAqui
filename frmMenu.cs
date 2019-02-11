using System;
using System.Windows.Forms;

namespace CompareAqui
{
    public partial class frmMenu : Form
    {
        //método Construtor da Classe
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {
            frmCadastraProd cadastraProd = new frmCadastraProd();
            cadastraProd.ShowDialog();
            this.Show();
        }

        private void btnAlterarProd_Click(object sender, EventArgs e)
        {
            frmAlterarProd alterarProd = new frmAlterarProd();
            alterarProd.ShowDialog();
            this.Show();
        }

        private void btnExcluirProd_Click(object sender, EventArgs e)
        {
            frmExcluirProd excluirProd = new frmExcluirProd();
            excluirProd.ShowDialog();
            this.Show();
        }

        private void btnConsultarProd_Click(object sender, EventArgs e)
        {
            frmConsultarProd consultarProd = new frmConsultarProd();
            consultarProd.ShowDialog();
            this.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Encerra a aplicação
            Application.Exit();
        }
    }
}
