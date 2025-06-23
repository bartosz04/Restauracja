namespace Restauracja_app
{
    public partial class pulpit : Form
    {
        private string userType;
     
        
        public pulpit(string? userType)
        {
            InitializeComponent();
            this.userType = userType;
        }
        
        private void BtnRejestrujStolik_Click(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                RegisterForm registerForm = new RegisterForm(); 
                registerForm.Show(); 
                
            }
            else
            {
                MessageBox.Show("Rejestracja użytkowników jest dostępna wyłącznie dla administratorów.",
                    "Odmowa dostępu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public pulpit()
        {
            this.userType = userType;
            InitializeComponent();
        }

        

        private void BtnStoliki_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1(userType);
            form1.ShowDialog();
        }

        private void BtnZamowienia_Click(object sender, EventArgs e)
        {
            this.Hide();
            var zamowienia = new zamowienia();
            zamowienia.Show();
        }

        private void BtnWyloguj_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wylogowywanie...");
            Application.Exit();
        }
    }
}
