using System.Windows.Forms;

namespace StolikiApp
{
    partial class LoginForm
    {
        private void InitializeComponent()
        {
            labelUsername = new Label() { Text = "Użytkownik:", Left = 20, Top = 20, Width = 80 };
            txtusername = new TextBox() { Left = 110, Top = 20, Width = 200 };

            labelPassword = new Label() { Text = "Hasło:", Left = 20, Top = 60, Width = 80 };
            txtpassword = new TextBox() { Left = 110, Top = 60, Width = 200, PasswordChar = '●' };

            buttonLogin = new Button() { Text = "Zaloguj", Left = 20, Top = 100, Width = 90 };
            buttonLogin.Click += buttonLogin_Click;

            buttonClear = new Button() { Text = "Wyczyść", Left = 125, Top = 100, Width = 90 };
            buttonClear.Click += (s, e) => { txtusername.Clear(); txtpassword.Clear(); txtusername.Focus(); };

            buttonExit = new Button() { Text = "Wyjdź", Left = 220, Top = 100, Width = 90 };
            buttonExit.Click += (s, e) => Application.Exit();

            this.Controls.Add(labelUsername);
            this.Controls.Add(txtusername);
            this.Controls.Add(labelPassword);
            this.Controls.Add(txtpassword);
            this.Controls.Add(buttonLogin);
            this.Controls.Add(buttonClear);
            this.Controls.Add(buttonExit);
        }
    }
}