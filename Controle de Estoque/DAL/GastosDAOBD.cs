using Controle_de_Gastos.BLL;
using Controle_de_Gastos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Gastos.DAL
{
    class GastosDAOBD : IGastosDAO
    {

        private ConexaoBD Conexao;

        public GastosDAOBD()
        {
            Conexao = new ConexaoBD();
        }

        public bool Atualizar(Gasto gasto)
        {
            SqlConnection conn = Conexao.AbrirConexao();
            if (conn != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE GASTOS SET DATA = @data, VALOR = @valor, DESCRICAO = @descricao WHERE ID = @id  ";

                cmd.Parameters.AddWithValue("@id", gasto.Id);
                cmd.Parameters.AddWithValue("@data", gasto.Data);
                cmd.Parameters.AddWithValue("@valor", gasto.Valor);
                cmd.Parameters.AddWithValue("@descricao", gasto.Descricao);
                cmd.ExecuteNonQuery();
                Conexao.FecharConexao();
                return true;
            }
            return false;
        }

        public bool Excluir(int id)
        {
            SqlConnection conn = Conexao.AbrirConexao();

            if (conn != null) {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM GASTOS WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Conexao.FecharConexao();
                return true;
            }
            return false;
        }

        public bool Inserir(Gasto gasto)
        {
            SqlConnection conn = Conexao.AbrirConexao();
            if (conn != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO GASTOS (DATA, VALOR, DESCRICAO) VALUES (@data, @valor, @descricao)";
                cmd.Parameters.AddWithValue("@data", gasto.Data);
                cmd.Parameters.AddWithValue("@valor", gasto.Valor);
                cmd.Parameters.AddWithValue("@descricao", gasto.Descricao);
                cmd.ExecuteNonQuery();
                Conexao.FecharConexao();
                return true;
            }
            return false;
        }

        public DataSet ListarPorMesAno(int mes, int ano)
        {
            SqlConnection conn = Conexao.AbrirConexao();
            if (conn != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM GASTOS WHERE MONTH(DATA) = @mes AND YEAR(DATA) = @ano";

                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@ano", ano);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet gastos = new DataSet();

                adapter.Fill(gastos, "GASTOS");
                return gastos;
            }
            return null;
        }

        public DataSet ListarTodos()
        {
            SqlConnection conn = Conexao.AbrirConexao();

            string consulta = "SELECT * FROM GASTOS";

            if (conn != null)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);
                DataSet gastos = new DataSet();

                adapter.Fill(gastos, "GASTOS");
                return gastos;
            }
            return null;

        }
    }
}
