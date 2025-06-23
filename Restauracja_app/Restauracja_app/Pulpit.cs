namespace Restauracja_app
{
    public partial class Pulpit : Form
    {
        private string userType;
        public Pulpit()
        {
            this.userType = userType;
            InitializeComponent();
        }

        private void BtnRejestrujStolik_Click(object sender, EventArgs e)
        {
            this.Hide();
            var rejestruj = new RegisterForm();
            rejestruj.Show();
        }

        private void BtnStoliki_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1(userType);
            form1.Show();
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
