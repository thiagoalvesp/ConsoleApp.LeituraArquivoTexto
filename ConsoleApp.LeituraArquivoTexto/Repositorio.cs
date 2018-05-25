using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LeituraArquivoTexto
{
    public class Repositorio
    {
        public static void Gravar(string[] linha)
        {
            using (SqlConnection mainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {
                try
                {
                    mainConnection.Open();

                    string sql = "INSERT INTO TB_CLIENTES(NOME, ENDERECO, TELEFONE) VALUES (@NOME, @ENDERECO, @TELEFONE)";
                    SqlCommand cmd = new SqlCommand(sql, mainConnection);
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                    cmd.Parameters["@NOME"].Value = linha[0];
                    cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar);
                    cmd.Parameters["@ENDERECO"].Value = linha[1];
                    cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar);
                    cmd.Parameters["@TELEFONE"].Value = linha[2];

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (mainConnection.State != ConnectionState.Closed)
                    {
                        mainConnection.Close();
                    }
                }
            }
        }

        public static List<Cliente> Consultar()
        {
            var clientes = new List<Cliente>();
            using (SqlConnection mainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {
                mainConnection.Open();
                using (SqlCommand customerQuery = new SqlCommand("SELECT * FROM TB_CLIENTES", mainConnection))
                {
                    using (SqlDataReader reader = customerQuery.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                       

                        try
                        {
                            int nomeIndex = reader.GetOrdinal("NOME");
                            int enderecoIndex = reader.GetOrdinal("ENDERECO");
                            int telefoneIndex = reader.GetOrdinal("TELEFONE");
                            while (reader.Read())
                            {
                                string nome = reader[nomeIndex].ToString();
                                string endereco = reader[enderecoIndex].ToString();
                                string telefone = reader[telefoneIndex].ToString();

                                clientes.Add(new Cliente{
                                        Nome = nome,
                                        Endereco = endereco,
                                        Telefone = telefone});

                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (mainConnection.State != ConnectionState.Closed)
                            {
                                mainConnection.Close();
                            }
                            
                        }
                    }
                }
            }
            return clientes;
        }

        public static void Apagar()
        {
            using (SqlConnection mainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {
                try
                {
                    mainConnection.Open();
                    string sql = "DELETE TB_CLIENTES";
                    SqlCommand cmd = new SqlCommand(sql, mainConnection);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Dados apagados com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (mainConnection.State != ConnectionState.Closed)
                    {
                        mainConnection.Close();
                    }
                }
            }
        }

    }
}
