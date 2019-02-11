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
    public partial class frmAdm : Form
    {
        public frmAdm()
        {
            InitializeComponent();
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("admin") && txtSenha.Text.Equals("admin"))
            {
                this.Hide();
                frmCadastro cadastra = new frmCadastro();
                cadastra.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Usuario/Senha incorretos");
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
