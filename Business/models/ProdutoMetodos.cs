using Database.Repositorios.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.models
{
    public partial class Produto : IRepositorio<Produto>
    {
        private static readonly string connStr = "server=localhost;user=root;database=produtos_cs;port=3306;password=179179;";

        public void Gravar(Produto prod)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                string query = $"INSERT INTO produtos (nome, descricao, data_criacao, data_validade, quantidade_estoque) VALUES ('{prod.Nome}', '{prod.Descricao}', '{prod.Data_Criacao.ToString("yyyy/M/dd")}', '{prod.Data_Validade.ToString("yyyy/M/dd")}', '{prod.Quantidade_Estoque}')";
                if (prod.Id > 0)
                {
                    query = $"update produtos set nome={prod.Nome},descricao={prod.Descricao},data_criacao={prod.Data_Criacao.ToString("yyyy/M/dd")},data_validade={prod.Data_Validade.ToString("yyyy/M/dd")},quantidade_estoque={prod.Quantidade_Estoque} where id = {prod.Id};";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public Produto? BuscaPorId(int id)
        {
            Produto prod = new Produto();

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                string query = $"SELECT * FROM produtos where id = {id};";

                var cmd = new MySqlCommand(query, conn);
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    prod.Id = dataReader.GetInt32("id");
                    prod.Nome = dataReader["nome"].ToString();
                    prod.Descricao = dataReader["descricao"].ToString();
                    prod.Data_Criacao = dataReader.GetDateTime("data_criacao");
                    prod.Data_Validade = dataReader.GetDateTime("data_validade");
                    prod.Quantidade_Estoque = dataReader.GetInt32("quantidade_estoque");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return prod;
        }

        public List<Produto> BuscaTodos()
        {
            List<Produto> produtos = new List<Produto>();

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                string query = "SELECT * FROM produtos";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    produtos.Add(new Produto
                    {
                        _id = dataReader.GetInt32("id"),
                        _nome = dataReader["nome"].ToString(),
                        _descricao = dataReader["descricao"].ToString(),
                        _dataCriacao = dataReader.GetDateTime("data_criacao"),
                        _dataValidade = dataReader.GetDateTime("data_validade"),
                        _quantidadeEstoque = dataReader.GetInt32("quantidade_estoque"),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return produtos;
        }
        public void ApagaPorId(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                string query = $"delete from produtos where id = {id};";

                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
