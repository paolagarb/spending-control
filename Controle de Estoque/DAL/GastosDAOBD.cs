using Controle_de_Gastos.BLL;
using Controle_de_Gastos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Estoque.DAL
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
            
        }

        public bool Excluir(int id)
        {
            
        }

        public bool Inserir(Gasto gasto)
        {
            SqlConnection conn = Conexao.AbrirConexao();
            if (conn != null)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO GASTOS (DATA, VALOR, DESCRICAO) VALUES (@DATA, @VALOR, @DESCRICAO)";

            }
            return false;
        }

        public DataSet ListarPorMesAno(int mes, int ano)
        {
            
        }

        public DataSet ListarTodos()
        {
            
        }
    }
}
