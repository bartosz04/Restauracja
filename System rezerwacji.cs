using System;
using System.Drawing;
using System.Windows.Forms;

namespace StolikiApp
{
    
    public abstract class BasePanel : Panel
    {
        public BasePanel()
        {
            this.BackColor = Color.FromArgb(215, 240, 240); 
            this.BorderStyle = BorderStyle.None;
            this.SizeChanged += (s, e) =>
            {
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            };
        }

        
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
    }

    
    public abstract class BaseGroupCard : Panel
    {
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public GroupStatus Status { get; set; }

        public BaseGroupCard(string groupName, int childrenCount, GroupStatus status)
        {
            this.GroupName = groupName;
            this.ChildrenCount = childrenCount;
            this.Status = status;
            this.Size = new Size(120, 100);
            this.Margin = new Padding(10);
            this.BackColor = GetCardColor();
            this.Region = System.Drawing.Region.FromHrgn(BasePanel.CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15));
        }

        private Color GetCardColor()
        {
            return Status switch
            {
                GroupStatus.Occupied => Color.FromArgb(217, 217, 217), 
                GroupStatus.Reserved => Color.FromArgb(255, 223, 120), 
                _ => Color.White, 
            };
        }

        public abstract void DisplayCardDetails();
    }

    public class AvailableGroupCard : BaseGroupCard
    {
        public AvailableGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Available) { }

        public override void DisplayCardDetails()
        {
            Console.WriteLine($"{GroupName} is available with {ChildrenCount} children.");
        }
    }

    public class OccupiedGroupCard : BaseGroupCard
    {
        public OccupiedGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Occupied) { }

        public override void DisplayCardDetails()
        {
            Console.WriteLine($"{GroupName} is occupied with {ChildrenCount} children.");
        }
    }

    public class ReservedGroupCard : BaseGroupCard
    {
        public ReservedGroupCard(string groupName, int childrenCount) : base(groupName, childrenCount, GroupStatus.Reserved) { }

        public override void DisplayCardDetails()
        {
            Console.WriteLine($"{GroupName} is reserved for {ChildrenCount} children.");
        }
    }

    public enum GroupStatus
    {
        Available,
        Occupied,
        Reserved
    }

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
            this.Text = "Stoliki";
            this.BackColor = Color.FromArgb(215, 240, 240); 
            this.ClientSize = new Size(1200, 700);
            this.MinimumSize = new Size(900, 600);
            this.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.StartPosition = FormStartPosition.CenterScreen;

            leftPanel = new LeftPanel
            {
                Size = new Size(820, 660),
                Location = new Point(20, 20)
            };
            this.Controls.Add(leftPanel);

            rightPanel = new RightPanel
            {
                Size = new Size(320, 660),
                Location = new Point(860, 20)
            };
            this.Controls.Add(rightPanel);

            topSearchPanel = new Panel
            {
                BackColor = Color.FromArgb(230, 249, 249), 
                Size = new Size(leftPanel.Width - 40, 40),
                Location = new Point(20, 20)
            };
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

    public class LeftPanel : BasePanel
    {
        public LeftPanel()
        {
            this.BackColor = Color.FromArgb(215, 240, 240); 
        }
    }

    public class RightPanel : BasePanel
    {
        public RightPanel()
        {
            this.BackColor = Color.FromArgb(215, 240, 240); 
        }
    }

    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    
}