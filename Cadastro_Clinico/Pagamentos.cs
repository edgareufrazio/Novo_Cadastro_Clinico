using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cadastro_Clinico
{
    public partial class Pagamentos : Form
    {
        public Pagamentos()
        {
            InitializeComponent();
        }

        private void Pagamentos_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.Conectar();
            string query = //"SELECT co.Consulta_id, Nome_c as Nome, Valor as Total, Valor - (select sum(Valor_p) from Pagamentos where co.Consulta_id = pa.Consulta_id group by co.Consulta_id) as Em_Aberto, Data_hora as Data FROM Consultas as co, Clientes as cl, Pagamentos as pa WHERE co.Cliente_Id = cl.Cliente_Id AND co.Consulta_id = pa.Consulta_id GROUP BY Nome_c, Valor, Data_hora, co.Consulta_id, pa.Consulta_id";
            //string query = "Select Nome_C as 'Nome do Cliente', SUM(Valor) as 'Total das Consultas', SUM(Valor_p) as 'Total pago', SUM(Valor - Valor_p) as 'Valor em aberto' from Consultas as co, Pago as pa, Clientes as cl where co.Cliente_id = pa.Cliente_id and co.Cliente_id = cl.Cliente_id group by Nome_C";
            "SELECt co.Consulta_id,cl.Nome_c AS Nome,co.Valor AS Total,co.Valor - COALESCE(SUM(pa.Valor_p), 0) AS Em_Aberto,co.Data_hora AS Data FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id LEFT JOIN Pagamentos pa ON co.Consulta_id = pa.Consulta_id GROUP BY co.Consulta_id, cl.Nome_c, co.Valor, co.Data_hora";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid_pagamentos.DataSource = dt;
        }

        private void bt_pesquisar_Click(object sender, EventArgs e)
        {
           
            Connection conn = new Connection();
            conn.Conectar();
            string nome;
            decimal valor;




            string sql = "SELECT Nome_c FROM Clientes WHERE Nome_c = @Nome";

            SqlCommand cmd3 = new SqlCommand(sql, conn.Conectar());

            nome = tb_nome.Text;
            cmd3.Parameters.AddWithValue("@Nome", nome);

           
                using (SqlDataReader reader2 = cmd3.ExecuteReader())
                {
                    if (reader2.Read())
                    {
                        

                        if (tb_nome != null && tb_nome.Text == "")
                        {
                            MessageBox.Show("Digite um nome para pesquisar");
                            return;
                        }
                        else
                        {


                            try
                            {

                                nome = tb_nome.Text;

                            string query = //"SELECT Consulta_id, Nome_c as 'Nome', Valor as 'Total', Data_hora as 'Data' FROM Consultas as co, Clientes as cl WHERE cl.Nome_c = @nome and co.Cliente_Id = cl.Cliente_Id GROUP BY Nome_c, Valor, Data_hora, Consulta_id";
                            "SELECt co.Consulta_id,cl.Nome_c AS Nome,co.Valor AS Total,co.Valor - COALESCE(SUM(pa.Valor_p), 0) AS Em_Aberto, co.Data_hora AS Data FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id LEFT JOIN Pagamentos pa ON co.Consulta_id = pa.Consulta_id WHERE cl.Nome_c = @nome and co.Cliente_Id = cl.Cliente_Id GROUP BY co.Consulta_id, cl.Nome_c, co.Valor, co.Data_hora";
                                SqlCommand cmd = new SqlCommand(query, conn.Conectar());

                                cmd.Parameters.AddWithValue("@nome", nome);
                                grid_pagamentos.DataSource = null;
                                grid_pagamentos.Rows.Clear();

                                DataTable dt = new DataTable();

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                da.Fill(dt);
                                grid_pagamentos.DataSource = dt;

                                string query2 = "SELECT Sum(valor), co.Consulta_id FROM Consultas as co, Clientes as cl WHERE cl.Nome_c = @nome and co.Cliente_Id = cl.Cliente_Id GROUP BY Consulta_id";
                                SqlCommand cmd2 = new SqlCommand(query2, conn.Conectar());
                                cmd2.Parameters.AddWithValue("@nome", nome);

                                try
                                {
                                    using (SqlDataReader reader = cmd2.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            tb_divida.Text = reader.GetDecimal(0).ToString();
                                            tb_id.Text = reader.GetInt32(1).ToString();
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro: " + ex.Message);
                                }
                                finally
                                {
                                    conn.Desconectar(conn.Conectar());
                                }





                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro: " + ex.Message);
                            }
                            finally
                            {

                            }
                         
                           
                        }
                    } else
                    {
                    
                        MessageBox.Show("Cliente não encontrado");
                        tb_divida.Clear();
                        tb_nome.Clear();
                        tb_id.Clear();



                    }
                }

           
           
        }
        

        private void bt_exibir_Click(object sender, EventArgs e)
        {
            grid_pagamentos.DataSource = null;
            grid_pagamentos.Rows.Clear();
            Connection conn = new Connection();
            conn.Conectar();
            string query = "SELECt co.Consulta_id,cl.Nome_c AS Nome,co.Valor AS Total,co.Valor - COALESCE(SUM(pa.Valor_p), 0) AS Em_Aberto,co.Data_hora AS Data FROM Consultas co INNER JOIN Clientes cl ON co.Cliente_Id = cl.Cliente_Id LEFT JOIN Pagamentos pa ON co.Consulta_id = pa.Consulta_id GROUP BY co.Consulta_id, cl.Nome_c, co.Valor, co.Data_hora"; ;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid_pagamentos.DataSource = dt;
            tb_divida.Clear();
            tb_nome.Clear();
            tb_id.Clear();
        }

        private void bt_pagar_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.Conectar();
            int id = Convert.ToInt32(tb_id.Text);
            decimal valor = Convert.ToDecimal(tb_deposito.Text);
            


            string query = "insert into Pagamentos (Consulta_id,Forma, P_data, Valor_p) values (@co_id, @forma, @DATA, @valor_p)";
            if (tb_id.Text != null & tb_deposito.Text != null)
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn.Conectar());

                    cmd.Parameters.AddWithValue("valor_p", valor);
                    cmd.Parameters.AddWithValue("co_id", id);
                    cmd.Parameters.AddWithValue("forma", tb_modo.Text);
                    cmd.Parameters.AddWithValue("DATA", DateTime.Now);
                    
                    var registroAfetado = cmd.ExecuteNonQuery();
                    MessageBox.Show("Efetuado com sucesso");
                    tb_divida.Clear();
                    tb_nome.Clear();
                    tb_id.Clear();
                    tb_deposito.Clear();
                    Pagamentos_Load(sender, e);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
        }

        private void Pagamentos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = Application.OpenForms["Form1"] as Form1;
            if (frm != null)
            {
                frm.Show();
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

       

        private void grid_pagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid_pagamentos.Rows[e.RowIndex];
                tb_nome.Text = row.Cells["Nome"].Value.ToString();
                tb_divida.Text = row.Cells["Em_aberto"].Value.ToString();
                tb_id.Text = row.Cells["Consulta_id"].Value.ToString();
            }
        }
    }
    
}
        
    
