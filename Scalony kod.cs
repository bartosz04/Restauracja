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

    // LoginForm
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
                mainForm.FormClosed += (s, args) => this.Close(); // Zamknij login po zamknięciu MainForm
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

    // BasePanel
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

    // GroupCard i Enum
    public abstract class BaseGroupCard : Panel
    {
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public GroupStatus Status { get; set; }

        public BaseGroupCard(string groupName, int childrenCount, GroupStatus status)
        {
            GroupName = groupName;
            ChildrenCount = childrenCount;
            Status = status;
            Size = new Size(120, 100);
            Margin = new Padding(10);
            BackColor = GetCardColor();
            Region = Region.FromHrgn(BasePanel.CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
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
        public override void DisplayCardDetails() => Console.WriteLine($"{GroupName} is occupied with {ChildrenCount} children.");
    }

    public class ReservedGroupCard : BaseGroupCard
    {
        public ReservedGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Reserved) { }
        public override void DisplayCardDetails() => Console.WriteLine($"{GroupName} is reserved for {ChildrenCount} children.");
    }

    public enum GroupStatus { Available, Occupied, Reserved }

    // MainForm
    public class MainForm : Form
    {
        private BasePanel leftPanel;
        private BasePanel rightPanel;
        private Panel topSearchPanel;
        private TextBox tbStoliki;
        private Label lblMenu;
        private Label lblWybierzGrupe;
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

            topSearchPanel = new Panel { BackColor = Color.FromArgb(230, 249, 249), Size = new Size(leftPanel.Width - 40, 40), Location = new Point(20, 20) };
            leftPanel.Controls.Add(topSearchPanel);

            tbStoliki = new TextBox { Text = "Stoliki", ReadOnly = true, Size = new Size(280, 24) };
            topSearchPanel.Controls.Add(tbStoliki);

            lblMenu = new Label { Text = "Menu", Size = new Size(280, 24), Location = new Point(300, 0) };
            topSearchPanel.Controls.Add(lblMenu);

            lblWybierzGrupe = new Label
            {
                Text = "Wybierz grupę",
                Font = new Font("Inter", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 79, 255),
                Location = new Point(20, 70)
            };
            leftPanel.Controls.Add(lblWybierzGrupe);

            groupsFlowPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                WrapContents = true,
                Dock = DockStyle.Bottom,
                Padding = new Padding(10),
                Size = new Size(leftPanel.Width - 40, leftPanel.Height - 120),
                Location = new Point(20, 100)
            };
            leftPanel.Controls.Add(groupsFlowPanel);

            AddGroupCard(new AvailableGroupCard("Grupa 1", 15));
            AddGroupCard(new OccupiedGroupCard("Grupa 2", 20));
            AddGroupCard(new ReservedGroupCard("Grupa 3", 18));
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
