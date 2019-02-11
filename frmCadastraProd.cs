using System;
using System.Windows.Forms;

namespace CompareAqui
{
    public partial class frmCadastraProd : Form
    {
        public frmCadastraProd()
        {
            InitializeComponent();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            //define o campo "Cod" da Classe "Produto" com o campo "CodBarra" removendo os espaços em branco do início e fim da palavra
            Produto.Cod = txtCodBarra.Text.Trim();
            Produto.Nome = txtNome.Text.Trim();
            Produto.Categoria = txtCategoria.Text.Trim();
            Produto.Preco = txtPreco.Text.Trim();
            Produto.Peso = txtPeso.Text.Trim();
            Produto.Marca = txtMarca.Text.Trim();
            Produto.Quantidade = txtQuantidade.Text.Trim();

            //instância uma Classe
            Produto prod = new Produto();

            //chama o método "InserirDados" da Classe "Produto"
            prod.InserirDados();

            this.Hide();
        }
    }
}
