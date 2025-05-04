using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restauracja_Stoly
{
    public partial class LoginForm : Form
    {
        private TextBox txtusername;
        private TextBox txtpassword;
        private Button buttonLogin;
        private Button buttonClear;
        private Button buttonExit;
        private Label labelUsername;
        private Label labelPassword;

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Panel logowania";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin123" && txtpassword.Text == "admin123")
            {
                MessageBox.Show("Zalogowano pomyslnie!");
                Form1 form1 = new Form1();
                form1.Show(); // Show Form1
                

            }
            else
            {
                MessageBox.Show("Bledne dane logowania");
                txtusername.Clear();
                txtpassword.Clear();
                txtusername.Focus();
            }
        }
    }
}