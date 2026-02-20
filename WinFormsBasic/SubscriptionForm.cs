using System;
using System.Windows.Forms;

namespace WinFormsBasic
{
    public class SubscriptionForm : Form
    {
        NotificationService service;
        Action refresh;

        TextBox emailBox = new();
        TextBox phoneBox = new();

        public SubscriptionForm(NotificationService service, Action refresh)
        {
            this.service = service;
            this.refresh = refresh;

            Text = "Manage Subscription";

            var emailChk = new CheckBox { Text = "Email", Top = 20 };
            var phoneChk = new CheckBox { Text = "SMS", Top = 60 };

            emailBox.Top = 20; emailBox.Left = 100;
            phoneBox.Top = 60; phoneBox.Left = 100;

            var subBtn = new Button { Text = "Subscribe", Top = 100 };
            var unsubBtn = new Button { Text = "Unsubscribe", Top = 100, Left = 100 };

            Controls.AddRange(new Control[] {
                emailChk, phoneChk, emailBox, phoneBox, subBtn, unsubBtn
            });

            subBtn.Click += (s, e) =>
            {
                if (emailChk.Checked && !service.AddEmail(emailBox.Text))
                    MessageBox.Show("Invalid or duplicate email");

                if (phoneChk.Checked && !service.AddPhone(phoneBox.Text))
                    MessageBox.Show("Invalid or duplicate phone");

                refresh();
            };

            unsubBtn.Click += (s, e) =>
            {
                service.RemoveEmail(emailBox.Text);
                service.RemovePhone(phoneBox.Text);
                refresh();
            };
        }
    }
}