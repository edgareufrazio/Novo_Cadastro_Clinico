using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Clinico
{
    public static class GerenciadorTema
    {
        // Controla se o tema atual é escuro (true) ou claro (false)
        // Por padrão usa o tema escuro moderno
        public static bool ModoEscuro { get; private set; } = true;

        // Evento que avisa todas as telas abertas que o tema mudou
        public static event Action OnTemaAlterado;

        // Alterna o estado do tema e dispara o aviso
        public static void AlternarTema()
        {
            ModoEscuro = !ModoEscuro;
            OnTemaAlterado?.Invoke();
        }

        // Método que aplica as cores em qualquer formulário e nos controles dentro dele
        public static void AplicarTema(Control container)
        {
            if (ModoEscuro)
            {
                // Cores do Tema Escuro
                container.BackColor = Color.FromArgb(30, 30, 30);
                container.ForeColor = Color.White;
            }
            else
            {
                // Cores do Tema Claro (Paleta moderna azul/cinza)
                container.BackColor = Color.FromArgb(245, 248, 250);
                container.ForeColor = Color.FromArgb(27, 45, 73);
            }

            // Passa por todos os componentes de dentro da tela (botões, labels, textboxes, etc.)
            foreach (Control filho in container.Controls)
            {
                AplicarTemaEmControle(filho);
            }
        }

        private static void AplicarTemaEmControle(Control ctrl)
        {
            if (ModoEscuro)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(45, 45, 48);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
                }
                else if (ctrl is TextBox || ctrl is MaskedTextBox || ctrl is ComboBox)
                {
                    ctrl.BackColor = Color.FromArgb(45, 45, 48);
                    ctrl.ForeColor = Color.White;
                }
                else if (ctrl is DataGridView dgv)
                {
                    EstilizarDataGridView(dgv);
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(30, 30, 30);
                    ctrl.ForeColor = Color.White;
                }
            }
            else
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                    btn.FlatStyle = FlatStyle.Standard;
                }
                else if (ctrl is TextBox || ctrl is MaskedTextBox || ctrl is ComboBox)
                {
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.Black;
                }
                else if (ctrl is DataGridView dgv)
                {
                    EstilizarDataGridView(dgv);
                }
                else
                {
                    ctrl.ForeColor = Color.Black;
                }
            }

            // Se o controle tiver elementos filhos (ex: Painéis, GroupBox), aplica neles também de forma recursiva
            if (ctrl.HasChildren)
            {
                foreach (Control subFilho in ctrl.Controls)
                {
                    AplicarTemaEmControle(subFilho);
                }
            }
        }

        // Aplica um estilo moderno e consistente em um DataGridView
        public static void EstilizarDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ModoEscuro ? Color.FromArgb(20, 40, 60) : Color.FromArgb(30, 78, 138);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = ModoEscuro ? Color.FromArgb(60, 90, 120) : Color.FromArgb(200, 220, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = ModoEscuro ? Color.FromArgb(45, 50, 60) : Color.FromArgb(245, 247, 250);
            dgv.GridColor = ModoEscuro ? Color.FromArgb(70, 80, 95) : Color.FromArgb(210, 220, 230);
        }
    }
}
