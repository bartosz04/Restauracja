using System.Windows.Forms;

namespace Restauracja_app
{
    partial class RegisterForm :Form
    {
        
        private void InitializeComponent()
        {

            this.ClientSize = new System.Drawing.Size(600, 400); 
            
            this.MinimumSize = new System.Drawing.Size(500, 300);
    
            labelUsername = new Label() { Text = "Użytkownik:", Left = 20, Top = 20, Width = 120 };
            
            txtUsername = new TextBox() { Left = 150, Top = 20, Width = 200 };
    
            labelPassword = new Label() { Text = "Hasło:", Left = 20, Top = 60, Width = 120 };
            txtPassword = new TextBox() { Left = 150, Top = 60, Width = 200, PasswordChar = '●' };
    
            labelConfirmPassword = new Label() { Text = "Potwierdź hasło:", Left = 20, Top = 100, Width = 120 };
            txtConfirmPassword = new TextBox() { Left = 150, Top = 100, Width = 200, PasswordChar = '●' };
    
            buttonRegister = new Button() { Text = "Zarejestruj", Left = 20, Top = 150, Width = 110 };
            buttonClear = new Button() { Text = "Wyczyść", Left = 140, Top = 150, Width = 110 };
            buttonExit = new Button() { Text = "Wyjdź", Left = 260, Top = 150, Width = 110 };
    

            
            buttonRegister.Click += buttonRegister_Click;
            buttonClear.Click += (s, e) => {
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtUsername.Focus();
            };
            buttonExit.Click += buttonExit_Click;

            
            this.Controls.AddRange(new Control[] {
                labelUsername,
                txtUsername,
                labelPassword,
                txtPassword,
                labelConfirmPassword,
                txtConfirmPassword,
                buttonRegister,
                buttonClear,
                buttonExit
            });
        }

        private Label labelUsername;
        private TextBox txtUsername;
        private Label labelPassword;
        private TextBox txtPassword;
        private Label labelConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button buttonRegister;
        private Button buttonClear;
        private Button buttonExit;

        
    }
}
