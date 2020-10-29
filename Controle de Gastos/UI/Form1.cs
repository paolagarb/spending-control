using Controle_de_Gastos.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Gastos
{
    
    public partial class TelaControleDeGastos : Form
    {
        private ControladorGastos controlador;
        private int? idSelecionado;

        public TelaControleDeGastos()
        {
            InitializeComponent();
            controlador = new ControladorGastos();
            dgvDados.ForeColor = Color.Black;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblDescricao_Click(object sender, EventArgs e)
        {

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow row = dgvDados.Rows[e.RowIndex];
                idSelecionado = int.Parse(row.Cells["ID"].Value.ToString());
                dtpDataGasto.Text = row.Cells["DATA"].Value.ToString();
                txtValor.Text = row.Cells["VALOR"].Value.ToString();
                txtDescricao.Text = row.Cells["DESCRICAO"].Value.ToString();
                btnExcluir.Enabled = true;
            }
        }

        private void lblValor_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void TelaControleDeGastos_Load(object sender, EventArgs e)
        {
            ListarTodos();
            txtValor.Select();
        }

        private void lblData_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int mes = dateTimePicker1.Value.Month;
            int ano = dateTimePicker1.Value.Year;
            dgvDados.DataSource = controlador.ListarPorMesAno(mes, ano).Tables[0];
            dgvDados.ClearSelection();
            lblTotal.Text = $"TOTAL - R$ {CalcularTotal().ToString("N2")}";
        }

        private void LimparCampos()
        {
            txtDescricao.Text = "";
            txtValor.Text = "";
            idSelecionado = null;
            dtpDataGasto.Value = DateTime.Now;
            btnExcluir.Enabled = false;
        }

        private void ListarTodos()
        {
            dgvDados.DataSource = controlador.ListarTodos().Tables[0];
            dgvDados.ClearSelection();
            lblTotal.Text = $"TOTAL - R$ {CalcularTotal().ToString("N2")}";
        }

        private double CalcularTotal()
        {
            double total = 0.0;
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                double valor = (double)row.Cells["VALOR"].Value;
                total += valor;
            }
            return total;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            double valor;
            string descricao;
            if (txtValor.Text == "")
            {
                MessageBox.Show("Informa o Valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            } else
            {
                valor = Convert.ToDouble(txtValor.Text);
            }

            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha a Descrição", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            } else
            {
                descricao = txtDescricao.Text;
            }

            DateTime data = dtpDataGasto.Value;
            Gasto gasto = new Gasto(data, valor, descricao);
            gasto.Id = idSelecionado;
            controlador.Salvar(gasto);
            LimparCampos();
            ListarTodos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir(idSelecionado.Value);
            LimparCampos();
            ListarTodos();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            ListarTodos();
        }
    }
}
