using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Restauracja_app
{
    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual decimal GetTotal(int quantity)
        {
            return Price * quantity;
        }
    }

    public class OrderItem : MenuItem
    {
        public int Quantity { get; set; }

        public OrderItem(string name, decimal price, int quantity)
            : base(name, price)
        {
            Quantity = quantity;
        }

        public override decimal GetTotal(int quantity)
        {
            return base.GetTotal(quantity);
        }

        public decimal LineTotal => Price * Quantity;
    }

    public class Order
    {
        private List<OrderItem> items = new List<OrderItem>();
        public IReadOnlyList<OrderItem> Items => items;

        public void AddItem(MenuItem item, int quantity)
        {
            var existing = items.FirstOrDefault(i => i.Name == item.Name);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                items.Add(new OrderItem(item.Name, item.Price, quantity));
            }
        }

        public void Clear() => items.Clear();

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < items.Count)
                items.RemoveAt(index);
        }

        public decimal GetTotal() => items.Sum(i => i.LineTotal);
    }

    public class Receipt
    {
        private readonly Order order;

        public Receipt(Order order)
        {
            this.order = order;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("====== PARAGON ======\n");

            foreach (var item in order.Items)
            {
                sb.AppendLine($"{item.Name} x{item.Quantity} = {item.LineTotal:0.00} PLN");
            }

            sb.AppendLine("\n----------------------");
            sb.AppendLine($"SUMA: {order.GetTotal():0.00} PLN");
            sb.AppendLine("======================");

            return sb.ToString();
        }
    }

    public partial class zamowienia : Form
    {
        private Order currentOrder = new Order();
        private pulpit _parentPulpit;
        private int _tableNumber; // ✅ dodane pole na numer stolika

        // ✅ zmieniony konstruktor - dodajemy numer stolika
        public zamowienia(pulpit parentPulpit, int tableNumber)
        {
            _parentPulpit = parentPulpit;
            _tableNumber = tableNumber;

            InitializeComponent();
            this.Text = $"Zamówienia - Stolik {_tableNumber}"; // ✅ ustawienie tytułu okna
            LoadMenuItems();
            UpdateOrderTotal();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            _parentPulpit.Show();
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
                    decimal price = decimal.Parse(row.Cells["Cena"].Value.ToString(), CultureInfo.InvariantCulture);

                    var menuItem = new MenuItem(itemName, price);
                    currentOrder.AddItem(menuItem, quantity);
                }
            }

            dgvLeft.Rows.Clear();
            foreach (var item in currentOrder.Items)
            {
                dgvLeft.Rows.Add(item.Name, item.Price, item.Quantity, "Usuń");
            }

            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                row.Cells["Ilość"].Value = 0;
            }

            UpdateOrderTotal();
        }

        private void BtnClearOrder_Click(object sender, EventArgs e)
        {
            currentOrder.Clear();
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
                currentOrder.RemoveAt(e.RowIndex);
                dgvLeft.Rows.RemoveAt(e.RowIndex);
                UpdateOrderTotal();
            }
        }

        private void BtnShowReceipt_Click(object sender, EventArgs e)
        {
            if (!currentOrder.Items.Any())
            {
                MessageBox.Show("Zamówienie jest puste.");
                return;
            }

            var receipt = new Receipt(currentOrder).Generate();

            var receiptForm = new Form
            {
                Text = $"Paragon - Stolik {_tableNumber}", // ✅ numer stolika w nagłówku
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
            lblTotalCost.Text = $"Suma: {currentOrder.GetTotal():0.00} PLN";
        }
    }
}