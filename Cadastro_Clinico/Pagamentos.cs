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
            string query = "SELECT Nome_c as Nome, SUM(Valor) as Total FROM Consultas as co, Clientes as cl WHERE co.Cliente_Id = cl.Cliente_Id GROUP BY Nome_c";
            //string query = "Select Nome_C as 'Nome do Cliente', SUM(Valor) as 'Total das Consultas', SUM(Valor_p) as 'Total pago', SUM(Valor - Valor_p) as 'Valor em aberto' from Consultas as co, Pago as pa, Clientes as cl where co.Cliente_id = pa.Cliente_id and co.Cliente_id = cl.Cliente_id group by Nome_C";
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

                                string query = "SELECT Nome_c as 'Nome do Cliente', SUM (Valor) as 'Total das Consultas', SUM(Valor_p) as 'Total pago', SUM(Valor - Valor_p) as 'Valor em aberto'  FROM Consultas as co, Clientes as cl, Pago as pa WHERE cl.Nome_c = @nome and co.Cliente_Id = cl.Cliente_Id and co.Cliente_Id = pa.Cliente_Id GROUP BY Nome_c";
                                SqlCommand cmd = new SqlCommand(query, conn.Conectar());

                                cmd.Parameters.AddWithValue("@nome", nome);
                                grid_pagamentos.DataSource = null;
                                grid_pagamentos.Rows.Clear();

                                DataTable dt = new DataTable();

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                da.Fill(dt);
                                grid_pagamentos.DataSource = dt;

                                string query2 = "SELECT Sum(valor), cl.Cliente_Id FROM Consultas as co, Clientes as cl WHERE cl.Nome_c = @nome and co.Cliente_Id = cl.Cliente_Id GROUP BY cl.Cliente_Id";
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
            string query = "SELECT Nome_c as Nome, SUM(Valor) as Total FROM Consultas as co, Clientes as cl WHERE co.Cliente_Id = cl.Cliente_Id GROUP BY Nome_c";
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

            string query = "insert into Pago (Valor_p, Cliente_id) values (@valor, @id)";
            if (tb_id.Text != null & tb_deposito.Text != null)
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn.Conectar());

                    cmd.Parameters.AddWithValue("valor", valor);
                    cmd.Parameters.AddWithValue("id", id);

                    var registroAfetado = cmd.ExecuteNonQuery();
                    MessageBox.Show("Efetuado com sucesso");
                    tb_divida.Clear();
                    tb_nome.Clear();
                    tb_id.Clear();
                    tb_deposito.Clear();

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
    }
}
        
    
