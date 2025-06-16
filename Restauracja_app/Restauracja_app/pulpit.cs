namespace Restauracja_app
{
    public partial class pulpit : Form
    {
        private string userType;
        public pulpit()
        {
            this.userType = userType;
            InitializeComponent();
        }

        private void BtnRejestrujStolik_Click(object sender, EventArgs e)
        {
            this.Hide();
            var rejestruj = new RegisterForm();
            rejestruj.ShowDialog();
        }

        private void BtnStoliki_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1(userType);
            form1.ShowDialog();
        }

        private void BtnZam�wienia_Click(object sender, EventArgs e)
        {
            this.Hide();
            var zam�wienia = new zam�wienia();
            zam�wienia.Show();
        }

        private void BtnWyloguj_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wylogowywanie...");
            Application.Exit();
        }
    }
}
