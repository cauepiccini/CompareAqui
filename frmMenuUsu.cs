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
    public partial class frmMenuUsu : Form
    {
        public frmMenuUsu()
        {
            InitializeComponent();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            new frmPerfil().Show();
        }

        public void mostraDatagrid()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_produto;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsulta.DataSource = produtos;
            //dgvConsulta.Columns.Clear();
        }

        public void atualizaDatagrid()
        {
            string pesquisaNA = txtNome.Text;
            string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_produto WHERE prod_nome like '%" + pesquisaNA + "%' ORDER BY prod_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsulta.DataSource = produtos;
        }

        private void frmMenuUsu_Load(object sender, EventArgs e)
        {
            mostraDatagrid();
        }

        private void btnAddLista_Click(object sender, EventArgs e)
        {
            string id = dgvConsulta.SelectedCells[0].Value.ToString();
            string nome = dgvConsulta.SelectedCells[1].Value.ToString();
            string categoria = dgvConsulta.SelectedCells[2].Value.ToString();
            string mercado = dgvConsulta.SelectedCells[3].Value.ToString();
            string preco = dgvConsulta.SelectedCells[4].Value.ToString();

            Lista.Id = id;
            Lista.Nome = nome;
            Lista.Categoria = categoria;
            Lista.Mercado = mercado;
            Lista.Preco = preco;

            Lista list = new Lista();

            list.InsereLista();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            atualizaDatagrid();
        }

        private void frmMenuUsu_FormClosing(object sender, FormClosingEventArgs e)
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
