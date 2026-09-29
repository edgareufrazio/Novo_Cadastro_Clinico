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
        public static bool ModoEscuro { get; private set; } = false;

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
                // Cores do Tema Claro (Padrão)
                container.BackColor = SystemColors.Control;
                container.ForeColor = Color.Black;
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
                    dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
                    dgv.GridColor = Color.FromArgb(64, 64, 64);
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                    dgv.DefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
                    dgv.BackgroundColor = SystemColors.AppWorkspace;
                    dgv.GridColor = Color.LightGray;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
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
    }
}
