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
    public partial class frmLista : Form
    {
        public frmLista()
        {
            InitializeComponent();
        }

        public void mostraDatagrid()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_lista;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        public void atualizaDatagrid()
        {
            string pesquisaNA = txtNome.Text;
            string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection cnx = new MySqlConnection(conex);

            string cmdDgv = "SELECT * FROM tb_lista WHERE list_nome like '%" + pesquisaNA + "%' ORDER BY list_cod;";

            MySqlDataAdapter da = new MySqlDataAdapter(cmdDgv, cnx);

            DataTable produtos = new DataTable();
            da.Fill(produtos);

            dgvConsultar.DataSource = produtos;
        }

        private void frmLista_Load(object sender, EventArgs e)
        {
            mostraDatagrid();
            dgvConsultar.AutoGenerateColumns = false;
            pnlConfig.Visible = false;
        }

        private void picConfig_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = false;
        }

        private void btnExcluirLista_Click(object sender, EventArgs e)
        {
            string id = dgvConsultar.SelectedCells[0].Value.ToString();

            Lista.Id = id;

            Lista list = new Lista();

            list.ExcluirLista();
        }
    }
}
