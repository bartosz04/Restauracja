using System.Drawing;
using System.Windows.Forms;

namespace Restauracja_app
{
    partial class zamowienia
    {
        private DataGridView dgvLeft;
        private DataGridView dgvMenu;
        private Button btnAddToOrder;
        private Button btnClearOrder;
        private Button BackButton;
        private Button btnShowReceipt;
        private Panel divider;
        private Panel rightPanel;
        private Panel leftPanel;
        private Label lblTotalCost;

        private void InitializeComponent()
        {
            this.Text = "Zamówienia";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.FromArgb(204, 255, 255);

            // LEFT PANEL
            leftPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 480,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(224, 255, 255)
            };

            dgvLeft = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 400,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            dgvLeft.Columns.Add("Danie", "Danie");
            dgvLeft.Columns.Add("Cena", "Cena (PLN)");
            dgvLeft.Columns.Add("Ilość", "Ilość");
            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Usuń",
                HeaderText = "Usuń",
                Text = "Usuń",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dgvLeft.Columns.Add(deleteColumn);
            dgvLeft.CellContentClick += DgvLeft_CellContentClick;

            lblTotalCost = new Label
            {
                Text = "Suma: 0.00 PLN",
                Dock = DockStyle.Bottom,
                Height = 30,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(5)
            };

            btnShowReceipt = new Button
            {
                Text = "Pokaż paragon",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnShowReceipt.Click += BtnShowReceipt_Click;

            leftPanel.Controls.Add(lblTotalCost);
            leftPanel.Controls.Add(btnShowReceipt);
            leftPanel.Controls.Add(dgvLeft);

            // SEPARATOR
            divider = new Panel
            {
                Width = 15,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(176, 224, 230)
            };

            // RIGHT PANEL
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
                Location = new Point(370, 10),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            BackButton.Click += BtnBack_Click;

            dgvMenu = new DataGridView
            {
                Location = new Point(10, 50),
                Size = new Size(470, 400),
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvMenu.Columns.Add("Danie", "Danie");
            dgvMenu.Columns.Add("Cena", "Cena (PLN)");

            var quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Ilość",
                HeaderText = "Ilość",
                Width = 50
            };
            dgvMenu.Columns.Add(quantityColumn);

            var plusButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Plus",
                HeaderText = "+",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            dgvMenu.Columns.Add(plusButtonColumn);

            var minusButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Minus",
                HeaderText = "-",
                Text = "-",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            dgvMenu.Columns.Add(minusButtonColumn);

            dgvMenu.CellContentClick += DgvMenu_CellContentClick;

            btnAddToOrder = new Button
            {
                Text = "Dodaj do zamówienia",
                Size = new Size(180, 40),
                Location = new Point(290, 460),
                BackColor = Color.FromArgb(122, 79, 255),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnAddToOrder.Click += BtnAddToOrder_Click;

            btnClearOrder = new Button
            {
                Text = "Wyczyść zamówienie",
                Size = new Size(180, 40),
                Location = new Point(290, 510),
                BackColor = Color.FromArgb(255, 79, 79),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnClearOrder.Click += BtnClearOrder_Click;

            rightPanel.Controls.Add(BackButton);
            rightPanel.Controls.Add(dgvMenu);
            rightPanel.Controls.Add(btnAddToOrder);
            rightPanel.Controls.Add(btnClearOrder);

            this.Controls.Add(rightPanel);
            this.Controls.Add(divider);
            this.Controls.Add(leftPanel);
        }
    }
}
