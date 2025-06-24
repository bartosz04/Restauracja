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

    // Updated: now fetches handler and seats, and passes them down
    private void UpdateTableStatuses()
    {
        string connectionString = $"Data Source={databaseFilePath};Version=3;";
        var tableInfos = new Dictionary<int, (string status, string handler, int seats)>();

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            // Updated query: fetch handler and seats too
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
                BorderStyle = BorderStyle.FixedSingle
            };
            label = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(label);
            flowPanel.Controls.Add(panel);
            tablePanels[tableNumber] = panel;
            panel.Tag = label;
        }
        else
        {
            panel = tablePanels[tableNumber];
            label = panel.Tag as Label;
        }

        
        label.Text = $"Table {tableNumber}\nStatus: {status}\nHandler: {handler}\nSeats: {seats}";
        panel.BackColor = isTaken ? Color.IndianRed : Color.LightGreen;
        label.ForeColor = Color.White;
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