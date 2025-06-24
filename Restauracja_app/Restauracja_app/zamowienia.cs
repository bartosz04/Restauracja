using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restauracja_app
{
    public partial class zamowienia : Form
    {
        public zamowienia()
        {
            InitializeComponent();
            LoadMenuItems();
            UpdateOrderTotal();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pulpit = new pulpit();
            pulpit.Show();
        }

        private void LoadMenuItems()
        {
            dgvMenu.Rows.Clear();

            dgvMenu.Rows.Add("Rosół z makaronem", "15.00", 0);
            dgvMenu.Rows.Add("Kotlet schabowy", "30.00", 0);
            dgvMenu.Rows.Add("Sałatka Cezar", "25.00", 0);
            dgvMenu.Rows.Add("Pizza Margherita", "32.00", 0);
            dgvMenu.Rows.Add("Deser lodowy", "18.00", 0);
        }

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                int quantity = Convert.ToInt32(row.Cells["Ilość"].Value);
                if (quantity > 0)
                {
                    string itemName = row.Cells["Danie"].Value.ToString();
                    string priceText = row.Cells["Cena"].Value.ToString();
                    bool updated = false;

                    foreach (DataGridViewRow orderRow in dgvLeft.Rows)
                    {
                        if (orderRow.Cells["Danie"].Value.ToString() == itemName)
                        {
                            int existingQty = Convert.ToInt32(orderRow.Cells["Ilość"].Value);
                            orderRow.Cells["Ilość"].Value = existingQty + quantity;
                            updated = true;
                            break;
                        }
                    }

                    if (!updated)
                    {
                        dgvLeft.Rows.Add(itemName, priceText, quantity, "Usuń");
                    }
                }
            }

            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                row.Cells["Ilość"].Value = 0;
            }

            UpdateOrderTotal();
        }

        private void BtnClearOrder_Click(object sender, EventArgs e)
        {
            dgvLeft.Rows.Clear();
            UpdateOrderTotal();
        }

        private void DgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvMenu.Columns[e.ColumnIndex].Name == "Plus")
                {
                    int quantity = Convert.ToInt32(dgvMenu.Rows[e.RowIndex].Cells["Ilość"].Value);
                    quantity++;
                    dgvMenu.Rows[e.RowIndex].Cells["Ilość"].Value = quantity;
                }
                else if (dgvMenu.Columns[e.ColumnIndex].Name == "Minus")
                {
                    int quantity = Convert.ToInt32(dgvMenu.Rows[e.RowIndex].Cells["Ilość"].Value);
                    if (quantity > 0)
                        quantity--;
                    dgvMenu.Rows[e.RowIndex].Cells["Ilość"].Value = quantity;
                }
            }

            UpdateOrderTotal();
        }

        private void DgvLeft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLeft.Columns[e.ColumnIndex].Name == "Usuń")
            {
                dgvLeft.Rows.RemoveAt(e.RowIndex);
                UpdateOrderTotal();
            }
        }

        private void BtnShowReceipt_Click(object sender, EventArgs e)
        {
            if (dgvLeft.Rows.Count == 0)
            {
                MessageBox.Show("Zamówienie jest puste.");
                return;
            }

            string receipt = "====== PARAGON ======\n\n";
            decimal total = 0;

            foreach (DataGridViewRow row in dgvLeft.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["Danie"].Value?.ToString() ?? "";
                decimal price = decimal.TryParse(row.Cells["Cena"].Value?.ToString(), out var p) ? p : 0;
                int quantity = int.TryParse(row.Cells["Ilość"].Value?.ToString(), out var q) ? q : 0;

                decimal lineTotal = price * quantity;
                total += lineTotal;

                receipt += $"{name} x{quantity} = {lineTotal:0.00} PLN\n";
            }

            receipt += $"\n----------------------\nSUMA: {total:0.00} PLN\n";
            receipt += "======================";

            var receiptForm = new Form
            {
                Text = "Paragon",
                Size = new Size(400, 400),
                BackColor = Color.White
            };

            var receiptBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10),
                Text = receipt,
                ScrollBars = ScrollBars.Vertical
            };

            receiptForm.Controls.Add(receiptBox);
            receiptForm.ShowDialog();
        }

        private void UpdateOrderTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvLeft.Rows)
            {
                if (decimal.TryParse(row.Cells["Cena"].Value.ToString(), out decimal price) &&
                    int.TryParse(row.Cells["Ilość"].Value.ToString(), out int quantity))
                {
                    total += price * quantity;
                }
            }

            lblTotalCost.Text = $"Suma: {total:0.00} PLN";
        }
    }
}
