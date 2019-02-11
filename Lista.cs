using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CompareAqui
{
    class Lista
    {
        public static string Nome, Categoria, Mercado, Preco, Id;

        public void InsereLista()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "INSERT INTO tb_lista(list_id, list_nome, list_categoria, list_mercado, list_preco)" +
                    "VALUES('" + Id + "', '" + Nome + "', '" + Categoria + "', '" + Mercado + "', '" + Preco + "');";
                MySqlCommand command = new MySqlCommand(cmd, cnx);
                cnx.Open();

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ExcluirLista()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "DELETE FROM tb_lista WHERE list_id = '" + Id + "'";
                MySqlCommand command = new MySqlCommand(cmd, cnx);
                cnx.Open();

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
