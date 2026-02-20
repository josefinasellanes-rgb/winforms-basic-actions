using System.Windows.Forms;

namespace WinFormsBasic;

public class PublishForm : Form
{
    public PublishForm(NotificationService service)
    {
        Text = "Publish Notification";

        var box = new TextBox { Width = 200 };
        var btn = new Button { Text = "Publish", Top = 40 };

        Controls.Add(box);
        Controls.Add(btn);

        btn.Click += (s, e) =>
        {
            service.Publish(box.Text);
            MessageBox.Show("Notification sent!");
        };
    }
}