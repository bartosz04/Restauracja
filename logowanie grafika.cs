using System;
using System.Windows.Forms;

namespace Panel_Logowania1
{
    public class Form1 : Form
    {
        private TextBox txtusername;
        private TextBox txtpassword;
        private Button buttonLogin;
        private Button buttonClear;
        private Button buttonExit;
        private Label labelUsername;
        private Label labelPassword;

        public Form1()
        {
            this.Text = "Panel logowania";
            this.Size = new System.Drawing.Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;

            labelUsername = new Label()
            {
                Text = "Użytkownik:",
                Left = 20,
                Top = 20,
                Width = 80
            };

            txtusername = new TextBox()
            {
                Left = 110,
                Top = 20,
                Width = 200
            };

            labelPassword = new Label()
            {
                Text = "Hasło:",
                Left = 20,
                Top = 60,
                Width = 80
            };

            txtpassword = new TextBox()
            {
                Left = 110,
                Top = 60,
                Width = 200,
                PasswordChar = '●'
            };

            buttonLogin = new Button()
            {
                Text = "Zaloguj",
                Left = 20,
                Top = 100,
                Width = 90
            };
            buttonLogin.Click += buttonLogin_Click;

            buttonClear = new Button()
            {
                Text = "Wyczyść",
                Left = 125,
                Top = 100,
                Width = 90
            };
            buttonClear.Click += buttonClear_Click;

            buttonExit = new Button()
            {
                Text = "Wyjdź",
                Left = 220,
                Top = 100,
                Width = 90
            };
            buttonExit.Click += buttonExit_Click;

            this.Controls.Add(labelUsername);
            this.Controls.Add(txtusername);
            this.Controls.Add(labelPassword);
            this.Controls.Add(txtpassword);
            this.Controls.Add(buttonLogin);
            this.Controls.Add(buttonClear);
            this.Controls.Add(buttonExit);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin123" && txtpassword.Text == "admin123")
            {
                MessageBox.Show("Zalogowano pomyślnie!");
                // new Form2().Show(); // Odkomentuj jeśli masz Form2
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Błędne dane logowania");
                txtusername.Clear();
                txtpassword.Clear();
                txtusername.Focus();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}