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
    public partial class frmConsultarProd : Form
    {
        public frmConsultarProd()
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

            //define o campo "Categoria" com o texto "Categoria: " mais a "Categoria" da Classe "Produto"
            lblNome.Text = "Nome: " + Produto.Nome;
            lblCategoria.Text = "Categoria: " + Produto.Categoria;
            lblPreco.Text = "Preço: " + Produto.Preco;
            lblPeso.Text = "Peso: " + Produto.Peso;
            lblMarca.Text = "Marca: " + Produto.Marca;
            lblQuantidade.Text = "Quantidade: " + Produto.Quantidade;
        }
    }
}
