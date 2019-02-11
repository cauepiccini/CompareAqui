using System;
using System.Windows.Forms;

namespace CompareAqui
{
    public partial class FrmLogin : Form
    {
        //método Construtor da Classe
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            //instância de um formulario
            frmCadastro cadastro = new frmCadastro();

            //escondendo o formulario atual
            this.Hide();

            //Mostrando o formulario instanciado
            cadastro.Show();
        }

        private void LnkEsqueceuSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperacaoSenha recuperar = new frmRecuperacaoSenha();

            recuperar.ShowDialog();
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmMenuUsu me = new frmMenuUsu();
            me.Hide();

            Empresa emp = new Empresa();

            //define  usuario e senha da Classe "Empresa" com o valor dos campos "Login" e "Senha"
            Empresa.Usuario = txtLogin.Text;
            Empresa.Senha = txtSenha.Text;

            //acessa o método "PegarDados" da Classe "Empresa"
            bool logado = emp.PegarDados();
            if (logado == true)
            {
                frmMenu menu = new frmMenu();
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario e/ou Senha incorreto(s)");
            }
        }
    }
}