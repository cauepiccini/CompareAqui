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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        frmCadastro cadastra = new frmCadastro();

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadastra.ShowDialog();
        }
    }
}
