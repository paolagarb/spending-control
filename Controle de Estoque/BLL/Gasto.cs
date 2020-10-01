using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Gastos.BLL
{
    class Gasto
    {
        private int? Id;
        private DateTime Data;
        private double Valor;
        private string Descricao;

        public Gasto(DateTime data, double valor, string descricao)
        {
            Id = null;
            Data = data;
            Valor = valor;
            Descricao = descricao;
        }
    }
}
