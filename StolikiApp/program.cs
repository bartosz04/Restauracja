using System;
using System.Drawing;
using System.Windows.Forms;

namespace StolikiApp
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }

    public class LoginForm : Form
    {
        private TextBox txtusername;
        private TextBox txtpassword;
        private Button buttonLogin;
        private Button buttonClear;
        private Button buttonExit;
        private Label labelUsername;
        private Label labelPassword;

        public LoginForm()
        {
            this.Text = "Panel logowania";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;

            labelUsername = new Label() { Text = "Użytkownik:", Left = 20, Top = 20, Width = 80 };
            txtusername = new TextBox() { Left = 110, Top = 20, Width = 200 };

            labelPassword = new Label() { Text = "Hasło:", Left = 20, Top = 60, Width = 80 };
            txtpassword = new TextBox() { Left = 110, Top = 60, Width = 200, PasswordChar = '●' };

            buttonLogin = new Button() { Text = "Zaloguj", Left = 20, Top = 100, Width = 90 };
            buttonLogin.Click += buttonLogin_Click;

            buttonClear = new Button() { Text = "Wyczyść", Left = 125, Top = 100, Width = 90 };
            buttonClear.Click += (s, e) => { txtusername.Clear(); txtpassword.Clear(); txtusername.Focus(); };

            buttonExit = new Button() { Text = "Wyjdź", Left = 220, Top = 100, Width = 90 };
            buttonExit.Click += (s, e) => Application.Exit();

            this.Controls.Add(labelUsername);
            this.Controls.Add(txtusername);
            this.Controls.Add(labelPassword);
            this.Controls.Add(txtpassword);
            this.Controls.Add(buttonLogin);
            this.Controls.Add(buttonClear);
            this.Controls.Add(buttonExit);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin123" && txtpassword.Text == "admin123")
            {
                MessageBox.Show("Zalogowano pomyślnie!");
                this.Hide();
                var mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Błędne dane logowania");
                txtusername.Clear();
                txtpassword.Clear();
                txtusername.Focus();
            }
        }
    }

    public abstract class BasePanel : Panel
    {
        public BasePanel()
        {
            this.BackColor = Color.FromArgb(215, 240, 240);
            this.BorderStyle = BorderStyle.None;
            this.SizeChanged += (s, e) =>
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            };
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }

    public abstract class BaseGroupCard : Panel
    {
        protected Label lblGroupName;
        protected Label lblGuestsCount;

        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public GroupStatus Status { get; set; }
        protected const int MaxGuests = 4; // Max guests per table

        public BaseGroupCard(string groupName, int childrenCount, GroupStatus status)
        {
            GroupName = groupName;
            ChildrenCount = childrenCount;
            Status = status;
            Size = new Size(140, 110);
            Margin = new Padding(15);
            BackColor = GetCardColor();
            Region = Region.FromHrgn(BasePanel.CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            Cursor = Cursors.Hand;

            lblGroupName = new Label
            {
                Text = GroupName,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                Padding = new Padding(5)
            };

            lblGuestsCount = new Label
            {
                Text = $"{ChildrenCount} gości",
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                Padding = new Padding(5)
            };

            Controls.Add(lblGroupName);
            Controls.Add(lblGuestsCount);

            this.Click += (s, e) => OnCardClick();
            lblGroupName.Click += (s, e) => OnCardClick();
            lblGuestsCount.Click += (s, e) => OnCardClick();
        }

        protected virtual void OnCardClick()
        {
            ShowAddGuestsDialog();
        }

        protected void ShowAddGuestsDialog()
        {
            using var dlg = new AddGuestsOptionsForm(ChildrenCount, MaxGuests);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int guestsToAdd = dlg.GuestsToAdd;
                int waiterNumber = dlg.WaiterNumber;

                if (ChildrenCount + guestsToAdd > MaxGuests)
                {
                    MessageBox.Show($"Nie można dodać {guestsToAdd} gości. Maksymalna liczba gości to {MaxGuests}.");
                    return;
                }

                ChildrenCount += guestsToAdd;
                UpdateGuestCount();

                MessageBox.Show($"Dodano {guestsToAdd} gości do {GroupName}. Kelner: {waiterNumber}. Łącznie: {ChildrenCount} gości.");
            }
        }

        protected void UpdateGuestCount()
        {
            lblGuestsCount.Text = $"{ChildrenCount} gości";
        }

        private Color GetCardColor() =>
            Status switch
            {
                GroupStatus.Occupied => Color.FromArgb(217, 217, 217),
                GroupStatus.Reserved => Color.FromArgb(255, 223, 120),
                _ => Color.White,
            };

        public abstract void DisplayCardDetails();
    }

    public class AvailableGroupCard : BaseGroupCard
    {
        public AvailableGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Available) { }

        public override void DisplayCardDetails() => Console.WriteLine($"{GroupName} is available with {ChildrenCount} children.");
    }

    public class OccupiedGroupCard : BaseGroupCard
    {
        public OccupiedGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Occupied) { }

        protected override void OnCardClick()
        {
            ShowAddGuestsDialog();
        }

        public override void DisplayCardDetails() => Console.WriteLine($"{GroupName} is occupied with {ChildrenCount} children.");
    }

    public class ReservedGroupCard : BaseGroupCard
    {
        public ReservedGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Reserved) { }

        protected override void OnCardClick()
        {
            ShowAddGuestsDialog();
        }

        public override void DisplayCardDetails() => Console.WriteLine($"{GroupName} is reserved for {ChildrenCount} children.");
    }

    public enum GroupStatus { Available, Occupied, Reserved }

    public class AddGuestsOptionsForm : Form
    {
        private NumericUpDown nudGuests;
        private NumericUpDown nudWaiter;
        private Button buttonAdd;
        private Button buttonCancel;
        private Label lblGuests;
        private Label lblWaiter;

        public int GuestsToAdd => (int)nudGuests.Value;
        public int WaiterNumber => (int)nudWaiter.Value;

        public AddGuestsOptionsForm(int currentGuests, int maxGuests)
        {
            Text = "Dodaj gości i przypisz kelnera";
            Size = new Size(320, 240);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            lblGuests = new Label() { Text = "Liczba gości do dodania (1-4):", Left = 15, Top = 20, Width = 200 };
            nudGuests = new NumericUpDown() { Left = 15, Top = 45, Width = 200, Minimum = 1, Maximum = Math.Max(1, maxGuests - currentGuests), Value = 1 };

            lblWaiter = new Label() { Text = "Numer kelnera (1-4):", Left = 15, Top = 75, Width = 200 };
            nudWaiter = new NumericUpDown() { Left = 15, Top = 100, Width = 200, Minimum = 1, Maximum = 4, Value = 1 };

            buttonAdd = new Button() { Text = "Dodaj", Left = 15, Top = 130, Width = 95 };
            buttonAdd.Click += (s, e) =>
            {
                if (nudGuests.Value < 1 || nudGuests.Value > maxGuests - currentGuests)
                {
                    MessageBox.Show("Nieprawidłowa liczba gości.");
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            };

            buttonCancel = new Button() { Text = "Anuluj", Left = 120, Top = 130, Width = 95 };
            buttonCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(lblGuests);
            Controls.Add(nudGuests);
            Controls.Add(lblWaiter);
            Controls.Add(nudWaiter);
            Controls.Add(buttonAdd);
            Controls.Add(buttonCancel);
        }
    }

    public class OrdersForm : Form
    {
        public OrdersForm()
        {
            Text = "Zamówienia";
            Size = new Size(600, 400);
            StartPosition = FormStartPosition.CenterScreen;
        }
    }

    public class MainForm : Form
    {
        private BasePanel leftPanel;
        private BasePanel rightPanel;
        private Panel topSearchPanel;
        private Label lblStoliki;
        private Button btnZamowienia;
        private Button btnWyloguj;
        
        private Label lblWybierzStolik;
        private FlowLayoutPanel groupsFlowPanel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Stoliki";
            BackColor = Color.FromArgb(215, 240, 240);
            ClientSize = new Size(1200, 700);
            MinimumSize = new Size(900, 600);
            Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point);
            StartPosition = FormStartPosition.CenterScreen;

            leftPanel = new LeftPanel { Size = new Size(820, 660), Location = new Point(20, 20) };
            Controls.Add(leftPanel);

            rightPanel = new RightPanel { Size = new Size(320, 660), Location = new Point(860, 20) };
            Controls.Add(rightPanel);

            topSearchPanel = new Panel { BackColor = Color.FromArgb(230, 249, 249), Size = new Size(leftPanel.Width - 40, 50), Location = new Point(20, 20), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            leftPanel.Controls.Add(topSearchPanel);

            lblStoliki = new Label()
            {
                Text = "Stoliki",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Inter", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                Size = new Size(180, 40),
                Location = new Point(10, 5)
            };
            topSearchPanel.Controls.Add(lblStoliki);

            btnZamowienia = new Button()
            {
                Text = "Zamówienia",
                Size = new Size(180, 40),
                Location = new Point(lblStoliki.Right + 10, 5),
                Font = new Font("Inter", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                TabStop = false
            };
            btnZamowienia.FlatAppearance.BorderSize = 0;
            btnZamowienia.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnZamowienia.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnZamowienia.Click += BtnZamowienia_Click;
            topSearchPanel.Controls.Add(btnZamowienia);

            btnWyloguj = new Button()
            {
                Text = "Wyloguj",
                Size = new Size(180, 40),
                Location = new Point(btnZamowienia.Right + 10, 5),
                Font = new Font("Inter", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                TabStop = false
            };
            btnWyloguj.FlatAppearance.BorderSize = 0;
            btnWyloguj.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnWyloguj.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btnWyloguj.Click += BtnWyloguj_Click;
            topSearchPanel.Controls.Add(btnWyloguj);

          

            lblWybierzStolik = new Label
            {
                Text = "Wybierz stolik",
                Font = new Font("Inter", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                Location = new Point(20, 130),
                AutoSize = true
            };
            leftPanel.Controls.Add(lblWybierzStolik);

            groupsFlowPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                WrapContents = true,
                Dock = DockStyle.Bottom,
                Padding = new Padding(10),
                Size = new Size(leftPanel.Width - 40, leftPanel.Height - 180),
                Location = new Point(20, 160),
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            leftPanel.Controls.Add(groupsFlowPanel);

            AddGroupCard(new AvailableGroupCard("Stolik - Okno", 0));
            AddGroupCard(new OccupiedGroupCard("Stolik - Schody", 0));
            AddGroupCard(new ReservedGroupCard("Stolik - Środek", 0));
            AddGroupCard(new AvailableGroupCard("Stolik - Środek", 0));
            AddGroupCard(new AvailableGroupCard("Stolik - Drzwi", 0));
        }

        private void BtnZamowienia_Click(object sender, EventArgs e)
        {
            var ordersForm = new OrdersForm();
            ordersForm.ShowDialog();
        }

        private void BtnWyloguj_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void AddGroupCard(BaseGroupCard groupCard)
        {
            groupCard.DisplayCardDetails();
            groupsFlowPanel.Controls.Add(groupCard);
        }
    }

    public class LeftPanel : BasePanel { }
    public class RightPanel : BasePanel { }
}
