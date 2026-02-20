using System;
using System.Windows.Forms;

namespace WinFormsBasic
{
    public class MainForm : Form
    {
        Button manageBtn = new() { Text = "Manage Subscription" };
        Button publishBtn = new() { Text = "Publish Notification", Enabled = false };
        Button exitBtn = new() { Text = "Exit" };

        NotificationService service = new();

        public MainForm()
        {
            Text = "Notification Manager";
            Controls.AddRange(new Control[] { manageBtn, publishBtn, exitBtn });

            manageBtn.Top = 20;
            publishBtn.Top = 20;
            exitBtn.Top = 20;

            manageBtn.Left = 20;
            publishBtn.Left = 160;
            exitBtn.Left = 340;

            manageBtn.Click += (s, e) =>
            {
                new SubscriptionForm(service, UpdatePublishButton).ShowDialog();
            };

            publishBtn.Click += (s, e) =>
            {
                new Program(service).ShowDialog();
            };

            exitBtn.Click += (s, e) => Close();
        }

        void UpdatePublishButton()
        {
            publishBtn.Enabled = service.HasSubscribers();
        }
    }
}