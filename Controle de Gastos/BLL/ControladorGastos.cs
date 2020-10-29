using Controle_de_Gastos.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Gastos.BLL
{
    class ControladorGastos
    {

        private IGastosDAO dao;

        public ControladorGastos()
        {
            dao = DAOFactory.CriarGastosDAO();
        }

        public bool Salvar(Gasto gasto)
        {
            if (gasto.Id == null)
            {
                return dao.Inserir(gasto);
            }
            return dao.Atualizar(gasto);
        }
        public bool Excluir(int id)
        {
            return dao.Excluir(id);
        }

        public DataSet ListarTodos()
        {
            return dao.ListarTodos();
        }

        public DataSet ListarPorMesAno(int mes, int ano)
        {
            return dao.ListarPorMesAno(mes, ano);
        }
    }
}
