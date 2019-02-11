using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CompareAqui
{
    internal class Empresa
    {
        //Variaveis
        public static string razaoSocial, Endereco, CEP, Telefone1, Telefone2, Usuario, Senha, Responsavel, CNPJ, Numero;
        public static string Bairro, Estado, Email, Municipio;

        //Método de verificação de usuario
        public bool PegarDados()
        {
            //cria variavel com conexão com o banco de dados
            string BancoDeDados = "server=localhost;userid=root;password=;port=3306;database=CompareAqui";

            //cria conexão com o banco de dados
            MySqlConnection ConexaoMySQL = new MySqlConnection(BancoDeDados);

            //Criando variavel de comando de seleção do usuario
            string ComandoSelect = "SELECT * FROM tb_usuarioempresa WHERE usu_usuario = '" + Usuario + "' and usu_senha = '" + Senha + "'";
            MySqlDataAdapter ExecutaComando = new MySqlDataAdapter(ComandoSelect, ConexaoMySQL);

            //Cria uma tabela que organiza os dados recebidos
            DataTable Tabela = new DataTable();
            ExecutaComando.Fill(Tabela);

            //Comparação dos dados inseridos com os dados salvos no Banco de Dados
            if (Tabela.Rows.Count == 1)
            {
                Produto.Mercado = ""+Tabela.Rows[0][1];
                return true;
            }
            else
            {
                return false;
            }
        }

        //Método de Inserção de Dados
        public void InserirDados()
        {
            //Tentativa de inserção de dados
            try
            {
                //Compara se os campos a serem inseridos estão em branco
                if (!razaoSocial.Equals("") && !Endereco.Equals("") && !CEP.Equals("") && !Telefone1.Equals("") && !Usuario.Equals("") && 
                    !Senha.Equals("") && !Responsavel.Equals("") && !CNPJ.Equals("") && !Numero.Equals("") && !Bairro.Equals("") && 
                    !Estado.Equals("") && !Email.Equals("") && !Municipio.Equals(""))
                {
                    //remove os caracteres especiais do telefone e CEP para inserir no Banco de Dados
                    if (Validar.CNPJ(CNPJ) == true)
                    {
                        Telefone1 = Telefone1.Replace("(", "");
                        Telefone1 = Telefone1.Replace(")", "");
                        Telefone1 = Telefone1.Replace("-", "");
                        Telefone1 = Telefone1.Replace(" ", "");
                        Telefone2 = Telefone2.Replace("(", "");
                        Telefone2 = Telefone2.Replace(")", "");
                        Telefone2 = Telefone2.Replace("-", "");
                        Telefone2 = Telefone2.Replace(" ", "");
                        CEP = CEP.Replace("-","");

                        //cria a conexão com o banco de dados
                        string BancoDeDados = "server=localhost;userid=root;password=;port=3306;database=CompareAqui";

                        //cria comando com os dados que serão inseridos
                        MySqlConnection ConexaoMySQL = new MySqlConnection(BancoDeDados);

                        string ComandoInsert = "INSERT INTO tb_usuarioempresa(usu_RazaoSocial, usu_CNPJ, usu_Endereco ,usu_Numero, usu_Bairro, usu_Municipio, usu_Estado, usu_CEP, usu_Telefone1, usu_Telefone2, usu_Usuario, usu_Senha, usu_Responsavel, usu_Email) " +
                            "VALUES ('" + razaoSocial + "','" + CNPJ + "',"+"'" + Endereco + "','" + Numero + "','" + Bairro + "','" + Municipio + "','" + Estado + "','" + CEP + "',"+
                        "'" + Telefone1 + "','" + Telefone2 + "','" + Usuario + "','" + Senha + "','" + Responsavel + "','" + Email + "')";
                        
                        MySqlCommand ExecutaComando = new MySqlCommand(ComandoInsert)
                        {
                            Connection = ConexaoMySQL
                        };

                        //abre a conexão com o banco de dados
                        ConexaoMySQL.Open();

                        //executa o comando de inserção no banco de dados
                        ExecutaComando.ExecuteNonQuery();

                        //fecha a conexão com o banco de dados
                        ExecutaComando.Connection.Close();

                        //mostra uma mensagem para  usuario
                        MessageBox.Show("Cadastrado com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("CNPJ Invalido");
                    }
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
    }
}