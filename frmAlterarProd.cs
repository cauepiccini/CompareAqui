using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompareAqui
{
    public partial class frmAlterarProd : Form
    {
        public frmAlterarProd()
        {
            InitializeComponent();
        }

      
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //cria a instancia da Classe "Produto"
            Produto prod = new Produto();

            //define o valor da variavel "Cod" na Classe Produto
            Produto.Cod = txtCodBarra.Text;

            //acessa a Classe Produto, pegando o método "Pegar Dados"
            prod.PegarDados();

            //define os campo de texto como ativo
            txtNome.Enabled = true;
            txtCategoria.Enabled = true;
            txtPreco.Enabled = true;
            txtPeso.Enabled = true;
            txtMarca.Enabled = true;
            txtQuantidade.Enabled = true;
            btnAlterar.Enabled = true;


            //Define o valor dos campos de texto com o valor dos atributos encontrados na Classe "Produto"
            txtNome.Text = Produto.Nome;
            txtCategoria.Text = Produto.Categoria;
            txtPreco.Text = Produto.Preco;
            txtPeso.Text = Produto.Peso;
            txtMarca.Text = Produto.Marca;
            txtQuantidade.Text = Produto.Quantidade;
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Produto.Nome = txtNome.Text.Trim();
            Produto.Categoria = txtCategoria.Text.Trim();
            Produto.Preco = txtPreco.Text.Trim();
            Produto.Peso = txtPeso.Text.Trim();
            Produto.Marca = txtMarca.Text.Trim();
            Produto.Quantidade = txtQuantidade.Text.Trim();

            //instância uma Classe
            Produto prod = new Produto();

            //chama o método "InserirDados" da Classe "Produto"
            prod.AtualizaDados();

            this.Hide();
        }
    }
}
