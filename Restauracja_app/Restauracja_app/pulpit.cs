using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Restauracja_app
{
    public partial class pulpit : Form
    {
        private string userType;
        private System.Windows.Forms.Timer timer;
        private string databaseFilePath = "restauracja_db.sqlite";
        private FlowLayoutPanel flowPanel;
        private Dictionary<int, Panel> tablePanels = new Dictionary<int, Panel>();

        public pulpit(string? userType)
        {
            InitializeComponent();
            InitializeDynamicUI();
            InitializeTimer();
            UpdateTableStatuses();
            this.userType = userType;
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeDynamicUI()
        {
            var spacer = new Panel
            {
                Height = 100,
                Dock = DockStyle.Top
            };
            this.Controls.Add(spacer);

            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true
            };
            this.Controls.Add(flowPanel);
            this.Controls.SetChildIndex(flowPanel, 1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTableStatuses();
        }

        private void UpdateTableStatuses()
        {
            string connectionString = $"Data Source={databaseFilePath};Version=3;";
            var tableInfos = new Dictionary<int, (string status, string handler, int seats)>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT table_number, status, handler, seats FROM tables";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tableNumber = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        string handler = reader.IsDBNull(2) ? "-" : reader.GetString(2);
                        int seats = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        tableInfos[tableNumber] = (status, handler, seats);
                    }
                }
            }

            foreach (var kvp in tableInfos)
            {
                AddOrUpdateTableBox(kvp.Key, kvp.Value.status, kvp.Value.handler, kvp.Value.seats);
            }

            var toRemove = new List<int>();
            foreach (var panel in tablePanels)
            {
                if (!tableInfos.ContainsKey(panel.Key))
                    toRemove.Add(panel.Key);
            }

            foreach (var key in toRemove)
            {
                var panel = tablePanels[key];
                flowPanel.Controls.Remove(panel);
                tablePanels.Remove(key);
            }
        }

        private void AddOrUpdateTableBox(int tableNumber, string status, string handler, int seats)
        {
            Panel panel;
            Label label;
            bool isTaken = status.Equals("reserved", StringComparison.OrdinalIgnoreCase);

            if (!tablePanels.ContainsKey(tableNumber))
            {
                panel = new Panel
                {
                    Width = 160,
                    Height = 110,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = isTaken ? Color.IndianRed : Color.LightGreen,
                    Cursor = Cursors.Hand,
                    Tag = tableNumber // save table number
                };

                label = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand
                };

                label.Click += Panel_Click;
                panel.Click += Panel_Click;

                panel.Controls.Add(label);
                flowPanel.Controls.Add(panel);
                tablePanels[tableNumber] = panel;

                panel.Tag = tableNumber;
                panel.Controls[0].Tag = tableNumber;
            }
            else
            {
                panel = tablePanels[tableNumber];
                label = panel.Controls[0] as Label;
            }

            label = panel.Controls[0] as Label;
            label.Text = $"Stolik {tableNumber}\nStatus: {status}\nObsługa: {handler}\nMiejsca: {seats}";
            panel.BackColor = isTaken ? Color.IndianRed : Color.LightGreen;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Control clicked = sender as Control;

            Panel panel = clicked as Panel ?? clicked.Parent as Panel;

            if (panel?.Tag is int tableNumber)
            {
                var zamowieniaForm = new zamowienia(this, tableNumber);
                this.Hide();
                zamowieniaForm.Show();
            }
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
            InitializeComponent();
        }

        private void BtnStoliki_Click(object sender, EventArgs e)
        {
            var form1 = new Form2();
            form1.ShowDialog();
        }

        private void BtnZamowienia_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnWyloguj_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Wylogowywanie...");
            
        }
    }
}