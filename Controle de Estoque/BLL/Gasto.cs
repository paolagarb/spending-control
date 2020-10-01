using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Gastos.BLL
{
    class Gasto
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public Gasto(DateTime data, double valor, string descricao)
        {
            Id = null;
            Data = data;
            Valor = valor;
            Descricao = descricao;
        }
    }

}
