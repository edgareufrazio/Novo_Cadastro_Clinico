using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Clinico
{
    public partial class Pagamentos : Form
    {
        public Pagamentos()
        {
            InitializeComponent();

            GerenciadorTema.OnTemaAlterado += AplicarTemaLocal;
            this.FormClosed += (s, e) => GerenciadorTema.OnTemaAlterado -= AplicarTemaLocal;
            AplicarTemaLocal();
        }

        private void AplicarTemaLocal()
        {
            GerenciadorTema.AplicarTema(this);
        }

        private async void Pagamentos_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT co.Consulta_id, cl.Nome_c AS Nome, co.Valor AS Total, "
                    + "co.Valor - COALESCE(SUM(pa.Valor_p), 0) AS Em_Aberto, co.Data_hora AS Data "
                    + "FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id "
                    + "LEFT JOIN Pagamentos pa ON co.Consulta_id = pa.Consulta_id "
                    + "GROUP BY co.Consulta_id, cl.Nome_c, co.Valor, co.Data_hora";

                var dt = await DataAccess.ExecuteDataTableAsync(query);
                grid_pagamentos.DataSource = dt;
                GerenciadorTema.EstilizarDataGridView(grid_pagamentos);
                // Patch refresh: no-op edit to update file after external modifications
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Erro ao carregar pagamentos: " + ex.Message);
            }
        }

        private async void bt_pesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                var nome = (tb_nome?.Text ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("Digite um nome para pesquisar");
                    return;
                }

                string sqlCheck = "SELECT Nome_c FROM Clientes WHERE Nome_c LIKE @Nome";
                var dtCheck = await DataAccess.ExecuteDataTableAsync(sqlCheck, new SqlParameter("@Nome", nome + "%"));

                if (dtCheck.Rows.Count == 0)
                {
                    MessageBox.Show("Cliente não encontrado");
                    tb_divida.Clear();
                    tb_id.Clear();
                    return;
                }

                string query = "SELECT co.Consulta_id, cl.Nome_c AS Nome, co.Valor AS Total, "
                    + "co.Valor - COALESCE(SUM(pa.Valor_p), 0) AS Em_Aberto, co.Data_hora AS Data "
                    + "FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id "
                    + "LEFT JOIN Pagamentos pa ON co.Consulta_id = pa.Consulta_id "
                    + "WHERE cl.Nome_c LIKE @nome AND co.Cliente_Id = cl.Cliente_Id "
                    + "GROUP BY co.Consulta_id, cl.Nome_c, co.Valor, co.Data_hora";

                var dt = await DataAccess.ExecuteDataTableAsync(query, new SqlParameter("@nome", nome + "%"));
                grid_pagamentos.DataSource = null;
                grid_pagamentos.Rows.Clear();
                grid_pagamentos.DataSource = dt;
                GerenciadorTema.EstilizarDataGridView(grid_pagamentos);

                string query2 = "SELECT SUM(co.Valor) AS TotalValor, co.Consulta_id "
                    + "FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id "
                    + "WHERE cl.Nome_c LIKE @nome "
                    + "GROUP BY co.Consulta_id";

                var dt2 = await DataAccess.ExecuteDataTableAsync(query2, new SqlParameter("@nome", nome + "%"));
                if (dt2.Rows.Count > 0)
                {
                    var row = dt2.Rows[0];
                    if (row[0] != DBNull.Value)
                        tb_divida.Text = Convert.ToDecimal(row[0]).ToString();
                    if (row[1] != DBNull.Value)
                        tb_id.Text = row[1].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Erro ao pesquisar pagamentos: " + ex.Message);
            }
        }

        private async void bt_exibir_Click(object sender, EventArgs e)
        {
            try
            {
                grid_pagamentos.DataSource = null;
                grid_pagamentos.Rows.Clear();
                var query = "SELECT co.Consulta_id, cl.Nome_c AS Nome, co.Valor AS Total, "
                    + "co.Valor - COALESCE(SUM(pa.Valor_p), 0) AS Em_Aberto, co.Data_hora AS Data "
                    + "FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id "
                    + "LEFT JOIN Pagamentos pa ON co.Consulta_id = pa.Consulta_id "
                    + "GROUP BY co.Consulta_id, cl.Nome_c, co.Valor, co.Data_hora";

                var dt = await DataAccess.ExecuteDataTableAsync(query);
                grid_pagamentos.DataSource = dt;
                GerenciadorTema.EstilizarDataGridView(grid_pagamentos);

                tb_divida.Clear();
                tb_nome.Clear();
                tb_id.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Erro ao exibir pagamentos: " + ex.Message);
            }
        }

        private async void bt_pagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_id.Text) || string.IsNullOrWhiteSpace(tb_deposito.Text))
                {
                    MessageBox.Show("Preencha todos os campos");
                    return;
                }

                int id = Convert.ToInt32(tb_id.Text);
                decimal valor = Convert.ToDecimal(tb_deposito.Text);

                string query = "INSERT INTO Pagamentos (Consulta_id, Forma, P_data, Valor_p) VALUES (@co_id, @forma, @DATA, @valor_p)";
                var affected = await DataAccess.ExecuteNonQueryAsync(query,
                    new SqlParameter("@valor_p", valor),
                    new SqlParameter("@co_id", id),
                    new SqlParameter("@forma", tb_modo.Text ?? string.Empty),
                    new SqlParameter("@DATA", DateTime.Now));

                MessageBox.Show("Efetuado com sucesso");
                tb_divida.Clear();
                tb_nome.Clear();
                tb_id.Clear();
                tb_deposito.Clear();
                Pagamentos_Load(sender, e);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Erro ao registrar pagamento: " + ex.Message);
            }
        }

        private void Pagamentos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Adicionar_cliente frm = Application.OpenForms["Adicionar_cliente"] as Adicionar_cliente;
            if (frm != null) frm.Show(); else new Adicionar_cliente().Show();
        }

        private void grid_pagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid_pagamentos.Rows[e.RowIndex];
                tb_nome.Text = row.Cells["Nome"].Value?.ToString() ?? string.Empty;
                tb_divida.Text = row.Cells["Em_Aberto"].Value?.ToString() ?? string.Empty;
                tb_id.Text = row.Cells["Consulta_id"].Value?.ToString() ?? string.Empty;
            }
        }

        private void tb_deposito_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
