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
    public partial class frmExcluirProd : Form
    {
        public frmExcluirProd()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //instância uma Classe
            Produto prod = new Produto();

            //define o campo "Cod" da Classe "Produto" com o campo "CodBarra"
            Produto.Cod = txtCodBarra.Text;

            //chama o método "PegarDados" da Classe "Produto"
            prod.PegarDados();

            //define o campo "Categoria" com o texto "Categoria: " mais a "Categoria" da Classe "Produto"
            lblNome.Text = "Nome: " + Produto.Nome;
            lblCategoria.Text = "Categoria: " + Produto.Categoria;
            lblPreco.Text = "Preço: " + Produto.Preco;
            lblPeso.Text = "Peso: " + Produto.Peso;
            lblMarca.Text = "Marca: " + Produto.Marca;
            lblQuantidade.Text = "Quantidade: " + Produto.Quantidade;
            btnExcluir.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //instância uma Classe
            Produto prod = new Produto();

            //chama o método "ExcluirDados" da Classe "Produto"
            prod.ExcluirDados();

            //define o campo "Categoria" com o texto "Categoria: "
            lblCategoria.Text = "Categoria: ";
            lblMarca.Text = "Fornecedor: ";
            lblQuantidade.Text = "Marca: ";
            lblPreco.Text = "Peso Liquido: ";
            lblNome.Text = "Preco de Venda: ";
            lblPeso.Text = "Quantidade: ";

            Produto.Nome = "";
            Produto.Categoria = "";
            Produto.Mercado = "";
            Produto.Preco = "";
            Produto.Peso = "";
            Produto.Marca = "";
            Produto.Quantidade = "";
            btnExcluir.Enabled = false;

            this.Hide();
        }
    }
}
