using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareAqui
{
    class Produto
    {
        public static string Cod, Nome, Categoria, Mercado, Preco, Peso, Marca, Quantidade;

        public void InserirDados()
        {
            //tenta inserir
            try
            {

                //verifica se os campos estão em branco
                if (!Cod.Equals("") && !Nome.Equals("") && !Categoria.Equals("") &&
                    !Mercado.Equals("") && !Preco.Equals("") && !Peso.Equals("") &&
                    !Marca.Equals("") && !Quantidade.Equals(""))
                {
                    string myConnectionString = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
                    MySqlConnection myConnection = new MySqlConnection(myConnectionString);
                    string myInsertQuery = "INSERT INTO tb_produto (prod_cod, prod_nome, prod_categoria, prod_mercado, prod_preco, prod_peso, prod_marca, prod_quantidade)"+
                        " Values('" + Cod + "','" + Nome + "','" + Categoria + "','" + Mercado + "','" + Preco + "','" + Peso + "','" + Marca + "','" + Quantidade + "')";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery, myConnection);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    //MessageBox.Show("Produto cadastrado com sucesso");
                }
                else
                {
                    MessageBox.Show("Nao deixe nenhum campo em branco ou somente com espacos!!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void PegarDados()
        {
            //cria a conexão com o banco de dados
            string ConexaoString = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";

            //cria a conexão com o banco de dados
            MySqlConnection ConexaoMySQL = new MySqlConnection(ConexaoString);

            //Criando Comando de seleção do produto
            string ComandoSelect = "SELECT * FROM tb_produto WHERE prod_Cod = '" + Cod + "'";

            //Executa o comando que seleciona o produto
            MySqlDataAdapter sda = new MySqlDataAdapter(ComandoSelect, ConexaoMySQL);

            //cria a tabela que organiza os dados recebidos
            DataTable Tabela = new DataTable();
            sda.Fill(Tabela);

            //caso código de barras encontrado exibe os valores correspondentes
            if (Tabela.Rows.Count == 1)
            {
                Nome = Tabela.Rows[0][1].ToString();
                Categoria = Tabela.Rows[0][2].ToString();
                Mercado = Tabela.Rows[0][3].ToString();
                Preco = Tabela.Rows[0][4].ToString();
                Peso = Tabela.Rows[0][5].ToString();
                Marca = Tabela.Rows[0][6].ToString();
                Quantidade = Tabela.Rows[0][7].ToString();
            }
            else
            {
                MessageBox.Show("Codigo de Barras nao encontrado!");
            }
        }

        //método de alteração de dados dos produtos
        public void AtualizaDados()
        {
             //tenta inserir
             try
             {

                 //verifica se os campos estão em branco
                 if (!Cod.Equals("") && !Nome.Equals("") && !Categoria.Equals("") &&
                    !Mercado.Equals("") && !Preco.Equals("") && !Peso.Equals("") &&
                    !Marca.Equals("") && !Quantidade.Equals(""))
                {
                    //cria variavel com conexão com o banco de dados 
                    string myConnectionString =
                       "server =localhost; user id =root; password =; port =3306; database = CompareAqui";

                     //cria o comando de conexão
                    MySqlConnection myConnection = new MySqlConnection(myConnectionString);

                     //Criando Comando de alteração dos produtos
                     string myInsertQuery =
                         "UPDATE tb_produto SET prod_nome='" + Nome + "',prod_categoria ='" + Categoria + "',prod_mercado ='" + Mercado + "', prod_preco='" + Preco + "',"+
                         "prod_peso='" + Convert.ToDecimal(Peso) + "',prod_marca ='" + Marca + "',prod_quantidade ='" + Quantidade + "' WHERE prod_cod ='" + Convert.ToInt32(Cod)+"';";
                     MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                     //o comando é igual a conexão
                     myCommand.Connection = myConnection;

                     //abre a conexão
                     myConnection.Open();

                     //executa o comando de alteração no banco de dados
                     myCommand.ExecuteNonQuery();

                     //fecha conexão
                     myCommand.Connection.Close();
                    //MessageBox.Show("Produto alterado com sucesso");
                 }
                 else
                 {
                     MessageBox.Show("Nao deixe nenhum campo em branco ou somente com espacos!!");
                 }
             }
             catch (Exception e)
             {
                 MessageBox.Show("" + e);
             }
        }

        public void ExcluirDados()
        {
            string ConexaoString = "server =localhost; user id =root; password =; port =3306; database = CompareAqui";
            MySqlConnection ConexaoMySQL = new MySqlConnection(ConexaoString);

            //Criando variavel de comando de exclusão de produtos
            string ComandoDelete = "DELETE FROM tb_produto WHERE prod_Cod = '" + Cod + "'";
            MySqlCommand Comando = new MySqlCommand(ComandoDelete);
            Comando.Connection = ConexaoMySQL;
            ConexaoMySQL.Open();
            Comando.ExecuteNonQuery();
            Comando.Connection.Close();
            //MessageBox.Show("Deletado com sucesso");
        }
    }
}
