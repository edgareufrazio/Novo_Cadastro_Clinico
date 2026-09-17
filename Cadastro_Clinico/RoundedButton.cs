using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    private int borderRadius = 20;

    // Atualiza a borda automaticamente se você mudar o raio no painel de Propriedades
    public int BorderRadius
    {
        get => borderRadius;
        set
        {
            borderRadius = value;
            AtualizarFormato();
            Invalidate(); // Força o botão a se desenhar novamente
        }
    }

    public RoundedButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        UseVisualStyleBackColor = false;

        Resize += (s, e) => AtualizarFormato();
    }

    private void AtualizarFormato()
    {
        if (Width <= 0 || Height <= 0) return;

        GraphicsPath path = new GraphicsPath();
        int r = borderRadius;

        // Garante que o raio não seja maior que a altura do botão
        if (r > Height) r = Height;

        path.AddArc(0, 0, r, r, 180, 90);
        path.AddArc(Width - r, 0, r, r, 270, 90);
        path.AddArc(Width - r, Height - r, r, r, 0, 90);
        path.AddArc(0, Height - r, r, r, 90, 90);

        path.CloseFigure();

        Region = new Region(path);
    }

    // Aplica o SmoothingMode para suavizar as curvas na renderização
    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        base.OnPaint(pevent);
    }
}