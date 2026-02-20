using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsBasic;

public sealed class MainForm : Form
{
    private readonly TextBox _nameTextBox = new() { Dock = DockStyle.Fill };
    private readonly Label _resultLabel = new() { Dock = DockStyle.Fill, AutoSize = true };

    public MainForm()
    {
        Text = "WinForms básico";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(560, 260);
        AutoScaleMode = AutoScaleMode.Font;

        var titleLabel = new Label
        {
            Text = "Demo WinForms (compilado con GitHub Actions)",
            Dock = DockStyle.Fill,
            AutoSize = true,
            Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold)
        };

        var nameLabel = new Label
        {
            Text = "Nombre:",
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        var greetButton = new Button
        {
            Text = "Saludar",
            AutoSize = true
        };
        greetButton.Click += (_, _) => Greet();

        var closeButton = new Button
        {
            Text = "Cerrar",
            AutoSize = true
        };
        closeButton.Click += (_, _) => Close();

        _resultLabel.Text = "Escribe tu nombre y presiona Saludar.";
        _resultLabel.Padding = new Padding(0, 8, 0, 0);

        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            AutoSize = true,
            WrapContents = false
        };
        buttons.Controls.Add(greetButton);
        buttons.Controls.Add(closeButton);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16),
            ColumnCount = 2,
            RowCount = 4
        };

        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        layout.Controls.Add(titleLabel, 0, 0);
        layout.SetColumnSpan(titleLabel, 2);

        layout.Controls.Add(nameLabel, 0, 1);
        layout.Controls.Add(_nameTextBox, 1, 1);

        layout.Controls.Add(buttons, 1, 2);

        layout.Controls.Add(_resultLabel, 0, 3);
        layout.SetColumnSpan(_resultLabel, 2);

        Controls.Add(layout);

        AcceptButton = greetButton;
        Shown += (_, _) => _nameTextBox.Focus();
    }

    private void Greet()
    {
        var name = _nameTextBox.Text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show(this,
                "Por favor escribe tu nombre.",
                "Falta el nombre",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _nameTextBox.Focus();
            return;
        }

        _resultLabel.Text = $"Hola, {name}! 👋";
    }
}
