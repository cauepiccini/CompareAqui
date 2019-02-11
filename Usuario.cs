using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MySql.Data;
using System.Data;

namespace CompareAqui
{
    class Usuario
    {
        public static string Nome, Email, Sexo, Nascimento, Senha;

        public void InsereDados()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database =CompareAqui";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "INSERT INTO tb_usuario(usu_nome, usu_email, usu_sexo, usu_nascimento, usu_senha)"+
                    "VALUES('"+Nome+"','"+Email+"','"+Sexo+"','"+Nascimento+"','"+Senha+"')";
                MySqlCommand command = new MySqlCommand(cmd, cnx);
                cnx.Open();

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AlteraDados()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database =CompareAqui";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "UPDATE tb_usuario SET usu_nome ='" + Nome + "', usu_email ='" + Email + "', usu_sexo ='" + Sexo 
                            + "', usu_nascimento ='" + Nascimento + "', usu_senha ='"+Senha+"';";
                MySqlCommand command = new MySqlCommand(cmd, cnx);
                cnx.Open();

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool PegarDados()
        {
            try
            {
                string BancoDeDados = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
                MySqlConnection ConexaoMySQL = new MySqlConnection(BancoDeDados);

                string ComandoSelect = "SELECT * FROM tb_usuario WHERE usu_email = '" + Email + "' and usu_senha = '" + Senha + "';";
                MySqlDataAdapter ExecutaComando = new MySqlDataAdapter(ComandoSelect, ConexaoMySQL);

                DataTable Tabela = new DataTable();
                ExecutaComando.Fill(Tabela);
                if (Tabela.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void ExcluirDados()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "DELETE FROM tb_usuario WHERE usu_email = '" + Email + "'";
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
