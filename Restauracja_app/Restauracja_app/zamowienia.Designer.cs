namespace Restauracja_app
{
    partial class zamowienia
    {
        private DataGridView dgvLeft;
        private DataGridView dgvMenu;
        private Button btnAddToOrder;
        private Button BackButton;
        private Panel divider;
        private Panel rightPanel;
        private Panel leftPanel;
        private void InitializeComponent()
        {
            this.Text = "Rachunki";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.FromArgb(204, 255, 255);

            // == LEWY PANEL ==
             leftPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 480,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(224, 255, 255)
            };

            dgvLeft = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            leftPanel.Controls.Add(dgvLeft);

            // == SEPARATOR ==
            divider = new Panel
            {
                Width = 15,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(176, 224, 230)
            };

            // == PRAWY PANEL ==
            rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(224, 255, 255)
            };

            BackButton = new Button
            {
                Text = "Wróć",
                Size = new Size(100, 30),
                Location = new Point(380, 10),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            BackButton.Click += BtnBack_Click;

            dgvMenu = new DataGridView
            {
                Location = new Point(10, 50),
                Size = new Size(470, 400),
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            btnAddToOrder = new Button
            {
                Text = "Dodaj do zamówienia",
                Size = new Size(180, 40),
                Location = new Point(300, 460),
                BackColor = Color.FromArgb(122, 79, 255),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnAddToOrder.Click += BtnAddToOrder_Click;

            rightPanel.Controls.Add(BackButton);
            rightPanel.Controls.Add(dgvMenu);
            rightPanel.Controls.Add(btnAddToOrder);

            this.Controls.Add(rightPanel);
            this.Controls.Add(divider);
            this.Controls.Add(leftPanel);
        }



    }
}
