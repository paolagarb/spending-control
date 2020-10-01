using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Controle_de_Gastos.DAL
{
    class ConexaoBD
    {
        private static SqlConnection conexao;

        public ConexaoBD()
        {
            if (conexao == null)
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            }
        }

        public SqlConnection AbrirConexao()
        {
            try
            {
                if (conexao.State != System.Data.ConnectionState.Open)
                {
                    conexao.Open();
                }
                return conexao;
            } 
            catch (SqlException e)
            {
                Console.WriteLine($"Erro de conexão: {e.Message}");
            }
            return null;
        }

        public bool FecharConexao()
        {
            try
            {
                conexao.Close();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Erro ao fehar a conexão: {e.Message}");
            }

            return false;
        }
    }
}
