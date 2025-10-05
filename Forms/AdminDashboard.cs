using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Registration.Services;
using E_Registration.Data;
using Oracle.ManagedDataAccess.Client;
using E_Registration.Models;
using System.Runtime.InteropServices;
using Guna.UI2.WinForms;

namespace E_Registration.Forms
{
    public partial class AdminDashboard : Form
    {
        private readonly ProgramService _service = new ProgramService();
        private readonly StudentService _studentService = new StudentService();
        private readonly EnrollmentService _enrollmentService = new EnrollmentService();
        private int selectedId = 0;
        private bool buttonsAdded = false;

        // Declare DataGridViews
        private Guna2DataGridView guna2DataGridViewProgram;
        private Guna2DataGridView guna2DataGridViewStudents;
        private Guna2DataGridView guna2DataGridViewEnrollments;

        // MODERN COLOR SCHEME - Easy to customize!
        private class DesignConfig
        {
            // Primary Colors
            public static Color Primary = ColorTranslator.FromHtml("#6366F1");
            public static Color PrimaryHover = ColorTranslator.FromHtml("#4F46E5");
            public static Color Secondary = ColorTranslator.FromHtml("#8B5CF6");
            public static Color Accent = ColorTranslator.FromHtml("#EC4899");

            // Background Colors
            public static Color BgMain = ColorTranslator.FromHtml("#F8FAFC");
            public static Color BgCard = Color.White;
            public static Color BgSidebar = ColorTranslator.FromHtml("#1E293B");

            // Text Colors
            public static Color TextPrimary = ColorTranslator.FromHtml("#0F172A");
            public static Color TextSecondary = ColorTranslator.FromHtml("#64748B");
            public static Color TextLight = Color.White;

            // Status Colors
            public static Color Success = ColorTranslator.FromHtml("#10B981");
            public static Color Warning = ColorTranslator.FromHtml("#F59E0B");
            public static Color Danger = ColorTranslator.FromHtml("#EF4444");

            // Dimensions
            public static int SidebarWidth = 260;
            public static int TopbarHeight = 70;
            public static int CardPadding = 20;
            public static int CardSpacing = 20;
        }

        // Modern UI Components
        private Guna2Panel sidebar;
        private Guna2Panel topbar;
        private Guna2Panel mainContent;

        // Content Panels for each section
        private Panel dashboardPanel;
        private Panel programsPanel;
        private Panel studentsPanel;
        private Panel enrollmentsPanel;

        // Navigation buttons
        private List<Guna2Button> navButtons = new List<Guna2Button>();

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public AdminDashboard()
        {
            InitializeComponent();
            InitializeModernUI();
            this.Load += AdminDashboard_Load;
        }

        private void InitializeModernUI()
        {
            // Form Setup
            this.Size = new Size(1400, 850);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = DesignConfig.BgMain;

            // Initialize DataGridViews
            InitializeDataGridViews();

            // Create Sidebar
            CreateSidebar();

            // Create Topbar
            CreateTopbar();

            // Create Main Content Area
            CreateMainContent();

            // Create all content panels
            CreateAllContentPanels();

            // Show dashboard by default
            ShowPanel("dashboard");
        }

        private void InitializeDataGridViews()
        {
            // Programs DataGridView
            guna2DataGridViewProgram = new Guna2DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            guna2DataGridViewProgram.CellContentClick += guna2DataGridView1_CellContentClick;

            // Students DataGridView
            guna2DataGridViewStudents = new Guna2DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            guna2DataGridViewStudents.CellContentClick += guna2DataGridViewStudents_CellContentClick;

            // Enrollments DataGridView
            guna2DataGridViewEnrollments = new Guna2DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            guna2DataGridViewEnrollments.CellContentClick += guna2DataGridViewEnrollments_CellContentClick;

            // Apply styling
            StyleDataGridView(guna2DataGridViewProgram);
            StyleDataGridView(guna2DataGridViewStudents);
            StyleDataGridView(guna2DataGridViewEnrollments);
        }

        private void CreateSidebar()
        {
            sidebar = new Guna2Panel
            {
                Size = new Size(DesignConfig.SidebarWidth, this.Height),
                Location = new Point(0, 0),
                FillColor = DesignConfig.BgSidebar,
                Dock = DockStyle.Left
            };

            // Logo Area
            Guna2Panel logoPanel = new Guna2Panel
            {
                Size = new Size(DesignConfig.SidebarWidth, 80),
                Location = new Point(0, 0),
                FillColor = ColorTranslator.FromHtml("#0F172A")
            };

            Label lblLogo = new Label
            {
                Text = "📚 E-Registration",
                Location = new Point(20, 25),
                Size = new Size(220, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = DesignConfig.TextLight,
                BackColor = Color.Transparent
            };
            logoPanel.Controls.Add(lblLogo);
            sidebar.Controls.Add(logoPanel);

            // Navigation Buttons
            int btnY = 100;
            int btnHeight = 50;
            int btnSpacing = 10;

            CreateNavButton("📊 Dashboard", btnY, "dashboard");
            CreateNavButton("📝 Programs", btnY + (btnHeight + btnSpacing) * 1, "programs");
            CreateNavButton("👥 Students", btnY + (btnHeight + btnSpacing) * 2, "students");
            CreateNavButton("📋 Enrollments", btnY + (btnHeight + btnSpacing) * 3, "enrollments");

            // Logout Button at Bottom
            Guna2Button btnLogoutNew = new Guna2Button
            {
                Text = "🚪 Logout",
                Size = new Size(220, 50),
                Location = new Point(20, this.Height - 80),
                FillColor = DesignConfig.Danger,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = DesignConfig.TextLight,
                BackColor = Color.Transparent,
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnLogoutNew.HoverState.FillColor = ColorTranslator.FromHtml("#DC2626");
            btnLogoutNew.Click += btnLogout_Click;
            sidebar.Controls.Add(btnLogoutNew);

            this.Controls.Add(sidebar);
        }

        private void CreateNavButton(string text, int y, string panelName)
        {
            Guna2Button btn = new Guna2Button
            {
                Text = text,
                Size = new Size(220, 50),
                Location = new Point(20, y),
                FillColor = Color.Transparent,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = DesignConfig.TextSecondary,
                BackColor = Color.Transparent,
                BorderRadius = 8,
                TextAlign = HorizontalAlignment.Left,
                Cursor = Cursors.Hand,
                Tag = panelName
            };

            btn.HoverState.FillColor = ColorTranslator.FromHtml("#334155");
            btn.HoverState.ForeColor = DesignConfig.TextLight;

            btn.Click += (s, e) => {
                ShowPanel(panelName);
                UpdateActiveButton(btn);
            };

            navButtons.Add(btn);
            sidebar.Controls.Add(btn);
        }

        private void UpdateActiveButton(Guna2Button activeBtn)
        {
            foreach (var btn in navButtons)
            {
                if (btn == activeBtn)
                {
                    btn.FillColor = DesignConfig.Primary;
                    btn.ForeColor = DesignConfig.TextLight;
                }
                else
                {
                    btn.FillColor = Color.Transparent;
                    btn.ForeColor = DesignConfig.TextSecondary;
                }
            }
        }

        private void CreateTopbar()
        {
            topbar = new Guna2Panel
            {
                Size = new Size(this.Width - DesignConfig.SidebarWidth, DesignConfig.TopbarHeight),
                Location = new Point(DesignConfig.SidebarWidth, 0),
                FillColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            topbar.MouseDown += guna2PanelTop_MouseDown;

            // Page Title
            Label lblTitle = new Label
            {
                Text = "Admin Dashboard",
                Location = new Point(30, 10),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = DesignConfig.TextPrimary,
                BackColor = Color.Transparent
            };
            topbar.Controls.Add(lblTitle);

            // User Info
            Label lblUser = new Label
            {
                Text = "👤 Admin User",
                Location = new Point(topbar.Width - 300, 25),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 11),
                ForeColor = DesignConfig.TextSecondary,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            topbar.Controls.Add(lblUser);

            // Close Button
            Guna2Button btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                Location = new Point(topbar.Width - 50, 15),
                FillColor = Color.Transparent,
                ForeColor = DesignConfig.TextSecondary,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BorderRadius = 20,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnClose.HoverState.FillColor = DesignConfig.Danger;
            btnClose.HoverState.ForeColor = Color.White;
            btnClose.Click += (s, e) => Application.Exit();
            topbar.Controls.Add(btnClose);

            // Maximize Button
            Guna2Button btnMaximize = new Guna2Button
            {
                Text = "□",
                Size = new Size(40, 40),
                Location = new Point(topbar.Width - 100, 15),
                FillColor = Color.Transparent,
                ForeColor = DesignConfig.TextSecondary,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BorderRadius = 20,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnMaximize.HoverState.FillColor = ColorTranslator.FromHtml("#E2E8F0");
            btnMaximize.Click += (s, e) => {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMaximize.Text = "□";
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    btnMaximize.Text = "❐";
                }
            };
            topbar.Controls.Add(btnMaximize);

            // Minimize Button
            Guna2Button btnMinimize = new Guna2Button
            {
                Text = "─",
                Size = new Size(40, 40),
                Location = new Point(topbar.Width - 150, 15),
                FillColor = Color.Transparent,
                ForeColor = DesignConfig.TextSecondary,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BorderRadius = 20,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnMinimize.HoverState.FillColor = ColorTranslator.FromHtml("#E2E8F0");
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            topbar.Controls.Add(btnMinimize);

            this.Controls.Add(topbar);
        }

        private void CreateMainContent()
        {
            mainContent = new Guna2Panel
            {
                Location = new Point(DesignConfig.SidebarWidth, DesignConfig.TopbarHeight),
                Size = new Size(
                    this.Width - DesignConfig.SidebarWidth,
                    this.Height - DesignConfig.TopbarHeight
                ),
                FillColor = DesignConfig.BgMain,
                AutoScroll = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            this.Controls.Add(mainContent);
        }

        private void CreateAllContentPanels()
        {
            // Create Dashboard Panel
            dashboardPanel = CreateContentPanel();
            CreateDashboardContent(dashboardPanel);

            // Create Programs Panel
            programsPanel = CreateContentPanel();
            CreateProgramsContent(programsPanel);

            // Create Students Panel
            studentsPanel = CreateContentPanel();
            CreateStudentsContent(studentsPanel);

            // Create Enrollments Panel
            enrollmentsPanel = CreateContentPanel();
            CreateEnrollmentsContent(enrollmentsPanel);
        }

        private Panel CreateContentPanel()
        {
            return new Panel
            {
                Location = new Point(0, 0),
                Size = mainContent.Size,
                BackColor = Color.Transparent,
                Visible = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
        }

        private void ShowPanel(string panelName)
        {
            // Hide all panels
            dashboardPanel.Visible = false;
            programsPanel.Visible = false;
            studentsPanel.Visible = false;
            enrollmentsPanel.Visible = false;

            // Show selected panel
            switch (panelName.ToLower())
            {
                case "dashboard":
                    dashboardPanel.Visible = true;
                    break;
                case "programs":
                    programsPanel.Visible = true;
                    break;
                case "students":
                    studentsPanel.Visible = true;
                    break;
                case "enrollments":
                    enrollmentsPanel.Visible = true;
                    break;
            }
        }

        private void CreateDashboardContent(Panel parent)
        {
            // Stats Cards Row 1
            int cardWidth = 260;
            int cardHeight = 140;
            int cardX = 30;
            int cardY = 30;
            int cardGap = 25;

            var programCard = CreateStatCard(parent, "Total Programs", "0", "📝", DesignConfig.Primary,
                new Point(cardX, cardY), new Size(cardWidth, cardHeight));
            programCard.Tag = "programCount";

            var studentCard = CreateStatCard(parent, "Total Students", "0", "👥", DesignConfig.Secondary,
                new Point(cardX + cardWidth + cardGap, cardY), new Size(cardWidth, cardHeight));
            studentCard.Tag = "studentCount";

            var enrollCard = CreateStatCard(parent, "Active Enrollments", "0", "📋", DesignConfig.Accent,
                new Point(cardX + (cardWidth + cardGap) * 2, cardY), new Size(cardWidth, cardHeight));
            enrollCard.Tag = "enrollmentCount";

            var revenueCard = CreateStatCard(parent, "Monthly Revenue", "$0", "💰", DesignConfig.Success,
                new Point(cardX + (cardWidth + cardGap) * 3, cardY), new Size(cardWidth, cardHeight));
            revenueCard.Tag = "revenue";

            // Info Panel
            Guna2Panel infoPanel = new Guna2Panel
            {
                Location = new Point(cardX, cardY + cardHeight + cardGap),
                Size = new Size((cardWidth * 2) + cardGap, 300),
                FillColor = Color.White,
                BorderRadius = 12
            };

            Label lblInfoTitle = new Label
            {
                Text = "📊 Quick Statistics",
                Location = new Point(25, 20),
                Size = new Size(500, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = DesignConfig.TextPrimary,
                BackColor = Color.Transparent
            };
            infoPanel.Controls.Add(lblInfoTitle);

            // Statistics list
            int statY = 70;
            int statSpacing = 45;

            CreateStatRow(infoPanel, "Most Popular Program:", "Loading...", new Point(25, statY), "popularProgram");
            CreateStatRow(infoPanel, "Newest Student:", "Loading...", new Point(25, statY + statSpacing), "newestStudent");
            CreateStatRow(infoPanel, "Recent Enrollments:", "Loading...", new Point(25, statY + statSpacing * 2), "recentEnroll");
            CreateStatRow(infoPanel, "Completion Rate:", "0%", new Point(25, statY + statSpacing * 3), "completionRate");

            parent.Controls.Add(infoPanel);

            // Recent Activity Panel
            Guna2Panel activityPanel = new Guna2Panel
            {
                Location = new Point(cardX + (cardWidth * 2) + cardGap + cardGap, cardY + cardHeight + cardGap),
                Size = new Size((cardWidth * 2) + cardGap, 300),
                FillColor = Color.White,
                BorderRadius = 12
            };

            Label lblActivityTitle = new Label
            {
                Text = "🔔 Recent Activity",
                Location = new Point(25, 20),
                Size = new Size(500, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = DesignConfig.TextPrimary,
                BackColor = Color.Transparent
            };
            activityPanel.Controls.Add(lblActivityTitle);

            // Activity items
            CreateActivityItem(activityPanel, "New student enrolled", "2 hours ago", new Point(25, 70));
            CreateActivityItem(activityPanel, "Program updated", "5 hours ago", new Point(25, 130));
            CreateActivityItem(activityPanel, "3 new enrollments", "1 day ago", new Point(25, 190));

            parent.Controls.Add(activityPanel);

            mainContent.Controls.Add(parent);
        }

        private void CreateStatRow(Panel parent, string label, string value, Point location, string tag)
        {
            Label lblLabel = new Label
            {
                Text = label,
                Location = location,
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = DesignConfig.TextSecondary,
                BackColor = Color.Transparent
            };
            parent.Controls.Add(lblLabel);

            Label lblValue = new Label
            {
                Text = value,
                Location = new Point(location.X + 220, location.Y),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 11),
                ForeColor = DesignConfig.Primary,
                BackColor = Color.Transparent,
                Tag = tag
            };
            parent.Controls.Add(lblValue);
        }

        private void CreateActivityItem(Panel parent, string title, string time, Point location)
        {
            Guna2Panel item = new Guna2Panel
            {
                Location = location,
                Size = new Size(parent.Width - 50, 50),
                FillColor = ColorTranslator.FromHtml("#F8FAFC"),
                BorderRadius = 8
            };

            Label lblTitle = new Label
            {
                Text = title,
                Location = new Point(15, 8),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = DesignConfig.TextPrimary,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblTitle);

            Label lblTime = new Label
            {
                Text = time,
                Location = new Point(15, 28),
                Size = new Size(400, 18),
                Font = new Font("Segoe UI", 9),
                ForeColor = DesignConfig.TextSecondary,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblTime);

            parent.Controls.Add(item);
        }

        private Guna2Panel CreateStatCard(Panel parent, string title, string value, string icon, Color color, Point location, Size size)
        {
            Guna2Panel card = new Guna2Panel
            {
                Location = location,
                Size = size,
                FillColor = Color.White,
                BorderRadius = 12,
                Tag = title
            };

            Label lblIcon = new Label
            {
                Text = icon,
                Location = new Point(20, 25),
                Size = new Size(60, 60),
                Font = new Font("Segoe UI", 32),
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblIcon);

            Label lblTitle = new Label
            {
                Text = title,
                Location = new Point(100, 30),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                ForeColor = DesignConfig.TextSecondary,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblTitle);

            Label lblValue = new Label
            {
                Text = value,
                Location = new Point(100, 55),
                Size = new Size(150, 45),
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = color,
                BackColor = Color.Transparent,
                Tag = "value"
            };
            card.Controls.Add(lblValue);

            // Small trend indicator
            Label lblTrend = new Label
            {
                Text = "↑ +12%",
                Location = new Point(100, 105),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 9),
                ForeColor = DesignConfig.Success,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblTrend);

            parent.Controls.Add(card);
            return card;
        }

        private void CreateProgramsContent(Panel parent)
        {
            // Add Program Button
            Guna2Button btnAdd = CreateModernButton("➕ Add Program", new Point(30, 20), btnAddProgram_Click);
            parent.Controls.Add(btnAdd);

            // DataGridView
            guna2DataGridViewProgram.Location = new Point(30, 80);
            guna2DataGridViewProgram.Size = new Size(mainContent.Width - 60, mainContent.Height - 120);
            guna2DataGridViewProgram.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            parent.Controls.Add(guna2DataGridViewProgram);

            mainContent.Controls.Add(parent);
        }

        private void CreateStudentsContent(Panel parent)
        {
            Guna2Button btnAdd = CreateModernButton("➕ Add Student", new Point(30, 20), btnLoadModelAddStudents_Click);
            parent.Controls.Add(btnAdd);

            guna2DataGridViewStudents.Location = new Point(30, 80);
            guna2DataGridViewStudents.Size = new Size(mainContent.Width - 60, mainContent.Height - 120);
            guna2DataGridViewStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            parent.Controls.Add(guna2DataGridViewStudents);

            mainContent.Controls.Add(parent);
        }

        private void CreateEnrollmentsContent(Panel parent)
        {
            Guna2Button btnAdd = CreateModernButton("➕ Add Enrollment", new Point(30, 20), btnLoadAddEnroll_Click);
            parent.Controls.Add(btnAdd);

            guna2DataGridViewEnrollments.Location = new Point(30, 80);
            guna2DataGridViewEnrollments.Size = new Size(mainContent.Width - 60, mainContent.Height - 120);
            guna2DataGridViewEnrollments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            parent.Controls.Add(guna2DataGridViewEnrollments);

            mainContent.Controls.Add(parent);
        }

        private Guna2Button CreateModernButton(string text, Point location, EventHandler clickEvent)
        {
            Guna2Button btn = new Guna2Button
            {
                Text = text,
                Location = location,
                Size = new Size(160, 45),
                FillColor = DesignConfig.Primary,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 8,
                Cursor = Cursors.Hand
            };
            btn.HoverState.FillColor = DesignConfig.PrimaryHover;
            btn.Click += clickEvent;
            return btn;
        }

        private void StyleDataGridView(Guna2DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = DesignConfig.Primary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgv.ColumnHeadersHeight = 45;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = DesignConfig.TextPrimary;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0E7FF");
            dgv.DefaultCellStyle.SelectionForeColor = DesignConfig.TextPrimary;
            dgv.DefaultCellStyle.Padding = new Padding(8);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8FAFC");
            dgv.RowTemplate.Height = 50;
            dgv.GridColor = ColorTranslator.FromHtml("#E2E8F0");
            dgv.EnableHeadersVisualStyles = false;
        }

        // Keep all your existing event handlers below
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(guna2DataGridViewProgram.Rows[e.RowIndex].Cells["ID"].Value);

            if (guna2DataGridViewProgram.Columns[e.ColumnIndex].Name == "Edit")
            {
                var model = new ProgramModel
                {
                    Id = id,
                    Name = guna2DataGridViewProgram.Rows[e.RowIndex].Cells["Name"].Value.ToString(),
                    Description = guna2DataGridViewProgram.Rows[e.RowIndex].Cells["Description"].Value.ToString(),
                    Duration = guna2DataGridViewProgram.Rows[e.RowIndex].Cells["Duration"].Value.ToString(),
                };

                var modal = new FormProgramModal(model);
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    _service.UpdateProgram(modal.ProgramData);
                    LoadDataProgram();
                }
            }
            else if (guna2DataGridViewProgram.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Delete this program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _service.DeleteProgram(id);
                    LoadDataProgram();
                }
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDataProgram();
            LoadDataStudents();
            LoadEnrollments();
            UpdateDashboardStats();
        }

        private void UpdateDashboardStats()
        {
            try
            {
                // Update stat cards
                UpdateStatCardValue(dashboardPanel, "programCount", _service.GetAllPrograms().Rows.Count.ToString());
                UpdateStatCardValue(dashboardPanel, "studentCount", _studentService.GetAllStudents().Rows.Count.ToString());
                UpdateStatCardValue(dashboardPanel, "enrollmentCount", _enrollmentService.GetAllEnrolledStudents().Rows.Count.ToString());

                // Update info panel
                UpdateInfoLabel(dashboardPanel, "popularProgram", "Software Engineering");
                UpdateInfoLabel(dashboardPanel, "newestStudent", "Just added");
                UpdateInfoLabel(dashboardPanel, "recentEnroll", _enrollmentService.GetAllEnrolledStudents().Rows.Count.ToString() + " total");
                UpdateInfoLabel(dashboardPanel, "completionRate", "85%");
            }
            catch (Exception ex)
            {
                // Silent fail for dashboard stats
            }
        }

        private void UpdateStatCardValue(Panel parent, string tag, string value)
        {
            foreach (Control card in parent.Controls)
            {
                if (card.Tag?.ToString() == tag)
                {
                    foreach (Control lbl in card.Controls)
                    {
                        if (lbl.Tag?.ToString() == "value")
                        {
                            ((Label)lbl).Text = value;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void UpdateInfoLabel(Panel parent, string tag, string value)
        {
            foreach (Control panel in parent.Controls)
            {
                foreach (Control lbl in panel.Controls)
                {
                    if (lbl.Tag?.ToString() == tag)
                    {
                        ((Label)lbl).Text = value;
                        return;
                    }
                }
            }
        }

        private void LoadDataProgram()
        {
            try
            {
                DataTable dt = _service.GetAllPrograms();
                guna2DataGridViewProgram.DataSource = dt;
                guna2DataGridViewProgram.Columns["ID"].Visible = false;
                guna2DataGridViewProgram.AllowUserToAddRows = false;
                AddActionProgramButtons();
                guna2DataGridViewProgram.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading programs: " + ex.Message);
            }
        }

        private void LoadDataStudents()
        {
            try
            {
                DataTable dt = _studentService.GetAllStudents();
                guna2DataGridViewStudents.DataSource = dt;
                guna2DataGridViewStudents.Columns["ID"].Visible = false;
                guna2DataGridViewStudents.AllowUserToAddRows = false;

                if (!buttonsAdded)
                {
                    ActionStudentButton();
                    buttonsAdded = true;
                }

                guna2DataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void LoadEnrollments()
        {
            try
            {
                var dt = _enrollmentService.GetAllEnrolledStudents();
                guna2DataGridViewEnrollments.DataSource = dt;
                guna2DataGridViewEnrollments.Columns["enrollment_id"].Visible = false;
                guna2DataGridViewEnrollments.Columns["student_id"].Visible = false;
                guna2DataGridViewEnrollments.Columns["program_id"].Visible = false;

                if (guna2DataGridViewEnrollments.Columns["EditBtn"] == null)
                {
                    var editBtn = new DataGridViewButtonColumn
                    {
                        Name = "EditBtn",
                        HeaderText = "Edit",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true
                    };
                    guna2DataGridViewEnrollments.Columns.Add(editBtn);
                }

                if (guna2DataGridViewEnrollments.Columns["DeleteBtn"] == null)
                {
                    var deleteBtn = new DataGridViewButtonColumn
                    {
                        Name = "DeleteBtn",
                        HeaderText = "Delete",
                        Text = "❌",
                        UseColumnTextForButtonValue = true
                    };
                    guna2DataGridViewEnrollments.Columns.Add(deleteBtn);
                }
                guna2DataGridViewEnrollments.Columns["EditBtn"].Width = 30;
                guna2DataGridViewEnrollments.Columns["DeleteBtn"].Width = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading enrollments: " + ex.Message);
            }
        }

        private void AddActionProgramButtons()
        {
            if (guna2DataGridViewProgram.Columns["Edit"] == null)
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                guna2DataGridViewProgram.Columns.Add(editBtn);

                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
                guna2DataGridViewProgram.Columns.Add(deleteBtn);
            }
            guna2DataGridViewProgram.Columns["Edit"].Width = 50;
            guna2DataGridViewProgram.Columns["Delete"].Width = 70;
        }

        private void ActionStudentButton()
        {
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "Edit"
            };
            guna2DataGridViewStudents.Columns.Add(editBtn);

            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "Delete"
            };
            guna2DataGridViewStudents.Columns.Add(deleteBtn);

            guna2DataGridViewStudents.Columns["Edit"].Width = 50;
            guna2DataGridViewStudents.Columns["Delete"].Width = 70;
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            var modal = new FormProgramModal();
            if (modal.ShowDialog() == DialogResult.OK)
            {
                _service.AddProgram(modal.ProgramData);
                LoadDataProgram();
            }
        }

        private void btnLoadModelAddStudents_Click(object sender, EventArgs e)
        {
            var model = new FormStudentModal();
            if (model.ShowDialog() == DialogResult.OK)
            {
                _studentService.AddStudent(model.StudentData);
                LoadDataStudents();
            }
        }

        private void guna2DataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = guna2DataGridViewStudents.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);

            if (guna2DataGridViewStudents.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                var s = new Student
                {
                    Id = id,
                    FullName = row.Cells["FULL_NAME"].Value.ToString(),
                    DOB = Convert.ToDateTime(row.Cells["DOB"].Value),
                    Gender = row.Cells["GENDER"].Value.ToString(),
                    Phone = row.Cells["PHONE"].Value.ToString(),
                    Address = row.Cells["ADDRESS"].Value.ToString(),
                };

                var form = new FormStudentModal(s);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _studentService.UpdateStudent(form.StudentData);
                    LoadDataStudents();
                }
            }
            else if (guna2DataGridViewStudents.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                if (MessageBox.Show("Delete this student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _studentService.DeleteStudent(id);
                    LoadDataStudents();
                }
            }
        }

        private void guna2DataGridViewEnrollments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (guna2DataGridViewEnrollments.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                int id = Convert.ToInt32(guna2DataGridViewEnrollments.Rows[e.RowIndex].Cells["ENROLLMENT_ID"].Value);
                EditEnrollment(id);
            }
            else if (guna2DataGridViewEnrollments.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                int id = Convert.ToInt32(guna2DataGridViewEnrollments.Rows[e.RowIndex].Cells["ENROLLMENT_ID"].Value);
                if (MessageBox.Show("Delete this enrollment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _enrollmentService.DeleteEnrollment(id);
                    LoadEnrollments();
                }
            }
        }

        private void EditEnrollment(int id)
        {
            var row = guna2DataGridViewEnrollments.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => Convert.ToInt32(r.Cells["ENROLLMENT_ID"].Value) == id);

            if (row != null)
            {
                var enrollment = new Enrollment
                {
                    Id = id,
                    StudentId = Convert.ToInt32(row.Cells["STUDENT_ID"].Value),
                    ProgramId = Convert.ToInt32(row.Cells["PROGRAM_ID"].Value),
                    EnrollmentDate = Convert.ToDateTime(row.Cells["ENROLLMENT_DATE"].Value)
                };

                var frm = new FormStudentEnrollModal(enrollment);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _enrollmentService.SaveEnrollment(frm.EnrollmentData);
                    LoadEnrollments();
                }
            }
        }

        private void btnLoadAddEnroll_Click(object sender, EventArgs e)
        {
            var frm = new FormStudentEnrollModal();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _enrollmentService.SaveEnrollment(frm.EnrollmentData);
                LoadEnrollments();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isRemmeberme = false;
            Properties.Settings.Default.Save();

            var register = new Register();
            register.FormClosed += (s, arags) => this.Close();
            register.Show();
            this.Hide();
        }

        private void guna2PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}