namespace Restauracja_app
{
    public partial class zamowienia : Form
    {
        private string connectionString = "Data Source=restauracja_db;";

        public zamowienia()
        {
            InitializeComponent();
            //LoadReservedTables();
            LoadMenuItems();

        }

        private void LoadReservedTables()
        {
            //    using (var conn = new SqliteConnection(connectionString))
            //    {
            //        conn.Open();
            //        string query = "SELECT groupName, childrenCount, status FROM stoliki WHERE status = 'reserved'";
            //        using (var cmd = new SqliteCommand(query, conn))
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                string groupName = reader["groupName"].ToString();
            //                int childrenCount = Convert.ToInt32(reader["childrenCount"]);
            //                string status = reader["status"].ToString();

            //                Panel card = CreateTableCard(groupName, childrenCount, status);
            //                panelReservedTables.Controls.Add(card);
            //            }
            //        }
            //    }
            //
        }


        private Panel CreateTableCard(string groupName, int childrenCount, string status)
        {
            Panel card = new Panel
            {
                Size = new Size(140, 110),
                Margin = new Padding(15),
                BackColor = GetCardColor(),
                Cursor = Cursors.Hand
            };

            Label lblGroupName = new Label
            {
                Text = groupName,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                Padding = new Padding(5)
            };

            Label lblGuestsCount = new Label
            {
                Text = $"{childrenCount} go�ci",
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                Padding = new Padding(5)
            };

            card.Controls.Add(lblGroupName);
            card.Controls.Add(lblGuestsCount);

            card.Click += (s, e) => ShowBill(groupName);

            return card;
        }
        private Color GetCardColor()
        {
            return Color.FromArgb(245, 245, 245);
        }

        private void ShowBill(string groupName)
        {
            // TODO: Za�aduj rachunek dla danego stolika i wy�wietl go w dgvMenu
        }

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            // TODO: Zapisz rachunek do bazy danych
        }

        private void LoadMenuItems()
        {
            // TODO: Pobierz dane z tabeli menu i wype�nij dgvMenu
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pulpit = new pulpit();
            pulpit.Show();
        }
    }
}