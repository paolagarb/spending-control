using Controle_de_Gastos.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Gastos.DAL
{
    interface IGastosDAO
    {
        bool Inserir(Gasto gasto);
        bool Atualizar(Gasto gasto);
        bool Excluir(int id);
        DataSet ListarTodos();
        DataSet ListarPorMesAno(int mes, int ano);
    }
}
