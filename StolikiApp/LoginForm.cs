using System;
using System.Drawing;
using System.Windows.Forms;

namespace StolikiApp
{
	public class LoginForm : Form
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
				MessageBox.Show("Zalogowano pomyœlnie!");
				this.Hide();
				var mainForm = new MainForm();
				mainForm.FormClosed += (s, args) => this.Close();
				mainForm.Show();
			}
			else
			{
				MessageBox.Show("B³êdne dane logowania");
				txtusername.Clear();
				txtpassword.Clear();
				txtusername.Focus();
			}
		}
	}
}