using System;
using System.Windows.Forms;

namespace CompareAqui
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //define o campo "RazaoSocial" da Classe "Empresa" com o campo "razaoSocial" removendo os espaços em branco do início e fim da palavra
            Empresa.razaoSocial = txtRazaoSocial.Text.Trim();
            Empresa.Endereco = txtEndereco.Text.Trim();
            Empresa.CEP = mkdCEP.Text;
            Empresa.Telefone1 = mkdTelefone1.Text;
            Empresa.Telefone2 = mkdTelefone2.Text;
            Empresa.Usuario = txtUsuario.Text.Trim();
            Empresa.Senha = txtSenha.Text.Trim();
            Empresa.Responsavel = txtResponsavel.Text.Trim();
            Empresa.CNPJ = mkdCNPJ.Text;
            Empresa.Numero = txtNumero.Text.Trim();
            Empresa.Estado = txtEstado.Text.Trim();
            Empresa.Bairro = txtBairro.Text.Trim();
            Empresa.Email = txtEmail.Text.Trim();
            Empresa.Municipio = txtMunicipio.Text.Trim();

            //instância uma Classe
            Empresa emp = new Empresa();

            //chama o método "InserirDados" da Classe "Produto"
            emp.InserirDados();

            this.Close();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
