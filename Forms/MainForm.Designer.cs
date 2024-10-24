using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace projectManagementApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialButton btnExport;
        private MaterialButton btnSend;
        private MaterialLabel lblMainPage;
        private MaterialTabSelector tabSelector;
        private MaterialTabControl tabControl;
        private PictureBox picCompanyLogo;
        private FlowLayoutPanel actionPanel;
        private Panel contentPanel;
        private Panel windowControlsPanel;
        private MaterialButton btnMinimize;
        private MaterialButton btnMaximize;
        private MaterialButton btnClose;
        private MaterialLabel lblTitle;

        // Constants for layout
        private const int PADDING = 20;
        private const int TEXT_PADDING_FROM_LOGO = 50;
        private const int BUTTON_PADDING_FROM_TEXT = 30;
        private const int LOGO_WIDTH = 400;
        private const int LOGO_HEIGHT = 100;
        private const int LOGO_PADDING_TOP = 30;
        private const int BUTTON_WIDTH = 150;
        private const int BUTTON_HEIGHT = 36;
        private const int TAB_HEIGHT = 50;
        private const int MIN_FORM_WIDTH = 800;
        private const int MIN_FORM_HEIGHT = 600;
        private const int WINDOW_CONTROL_HEIGHT = 25;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            InitializeControls();
            SetupMainForm();

            this.SuspendLayout();
            this.Controls.Clear();

            // Add controls in correct order (bottom to top)
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.tabControl);        // Add tab control directly
            this.Controls.Add(this.tabSelector);       // Add tab selector directly
            this.Controls.Add(this.windowControlsPanel);

            // Add main content to content panel
            this.contentPanel.Controls.Add(this.picCompanyLogo);
            this.contentPanel.Controls.Add(this.lblMainPage);
            this.contentPanel.Controls.Add(this.btnExport);
            this.contentPanel.Controls.Add(this.btnSend);

            // Ensure proper z-order
            this.windowControlsPanel.BringToFront();
            this.tabSelector.BringToFront();

            this.ResumeLayout(false);
            this.PerformLayout();

            UpdateControlPositions();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;


        private void InitializeWindowControls()
        {
            Color buttonColor = Color.FromArgb(229, 57, 53);  // Match the red theme

            // Create window control buttons
            btnMinimize = new MaterialButton
            {
                Text = "─",
                Size = new Size(45, WINDOW_CONTROL_HEIGHT),
                Type = MaterialButton.MaterialButtonType.Text,
                BackColor = buttonColor,
                ForeColor = Color.White,
                Margin = new Padding(0),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat
            };

            btnMaximize = new MaterialButton
            {
                Text = "□",
                Size = new Size(45, WINDOW_CONTROL_HEIGHT),
                Type = MaterialButton.MaterialButtonType.Text,
                BackColor = buttonColor,
                ForeColor = Color.White,
                Margin = new Padding(0),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat
            };

            btnClose = new MaterialButton
            {
                Text = "×",
                Size = new Size(45, WINDOW_CONTROL_HEIGHT),
                Type = MaterialButton.MaterialButtonType.Text,
                BackColor = buttonColor,
                ForeColor = Color.White,
                Margin = new Padding(0),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat
            };

            // Position window control buttons
            btnMinimize.Location = new Point(btnMaximize.Left - btnMinimize.Width, 0);
            btnMaximize.Location = new Point(btnClose.Left - btnMaximize.Width, 0);
            btnClose.Location = new Point(windowControlsPanel.Width - btnClose.Width, 0);

            // Add event handlers
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnMaximize.Click += (s, e) =>
            {
                this.WindowState = this.WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
            };
            btnClose.Click += (s, e) => this.Close();

            // Add controls to panel
            windowControlsPanel.Controls.Add(lblTitle);
            windowControlsPanel.Controls.Add(btnMinimize);
            windowControlsPanel.Controls.Add(btnMaximize);
            windowControlsPanel.Controls.Add(btnClose);

            // Enable dragging the form by the title bar
            windowControlsPanel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }


        private void InitializeControls()
        {
            // Window controls panel
            this.windowControlsPanel = new Panel
            {
                Height = WINDOW_CONTROL_HEIGHT,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(51, 51, 51), // Dark background to match the form
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // Title label
            lblTitle = new MaterialLabel
            {
                Text = "Project Management",
                ForeColor = Color.White,
                Location = new Point(10, 4),
                AutoSize = true
            };

            // Window control buttons
            btnMinimize = new MaterialButton
            {
                Text = "−",
                Size = new Size(45, WINDOW_CONTROL_HEIGHT),
                Type = MaterialButton.MaterialButtonType.Text,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Margin = new Padding(0),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnMaximize = new MaterialButton
            {
                Text = "☐",
                Size = new Size(45, WINDOW_CONTROL_HEIGHT),
                Type = MaterialButton.MaterialButtonType.Text,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Margin = new Padding(0),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnClose = new MaterialButton
            {
                Text = "✕",
                Size = new Size(45, WINDOW_CONTROL_HEIGHT),
                Type = MaterialButton.MaterialButtonType.Text,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Margin = new Padding(0),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Add hover effects
            foreach (var btn in new[] { btnMinimize, btnMaximize, btnClose })
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn == btnClose)
                        btn.BackColor = Color.FromArgb(232, 17, 35);
                    else
                        btn.BackColor = Color.FromArgb(75, 75, 75);
                };
                btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;
            }

            // Add controls to window panel in correct order
            windowControlsPanel.Controls.Add(btnClose);
            windowControlsPanel.Controls.Add(btnMaximize);
            windowControlsPanel.Controls.Add(btnMinimize);
            windowControlsPanel.Controls.Add(lblTitle);

            // Window dragging
            windowControlsPanel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

            // Initialize other controls
            InitializeTabControls();
            InitializeButtons();

            // Initialize content
            this.contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(51, 51, 51),
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            this.lblMainPage = new MaterialLabel
            {
                Text = "Export or Send Data from All Pages:",
                AutoSize = true,
                Depth = 0,
                MouseState = MaterialSkin.MouseState.HOVER,
                ForeColor = Color.White
            };

            this.picCompanyLogo = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(LOGO_WIDTH, LOGO_HEIGHT),
                ImageLocation = Path.Combine(Application.StartupPath, "Resources", "."),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };
        }

        private void AddWindowControlButtonEvents(MaterialButton btn)
        {
            Color defaultColor = Color.FromArgb(229, 57, 53);
            Color hoverColor = Color.FromArgb(209, 37, 33);  // Slightly darker red
            Color closeHoverColor = Color.FromArgb(232, 17, 35);  // Windows-style close button red

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = btn == btnClose ? closeHoverColor : hoverColor;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = defaultColor;
            };
        }

        private void InitializeTabControls()
        {
            this.tabControl = new MaterialTabControl
            {
                Depth = 0,
                MouseState = MaterialSkin.MouseState.HOVER,
                Multiline = true,
                Dock = DockStyle.Top,
                Height = TAB_HEIGHT,
                ItemSize = new Size(80, TAB_HEIGHT),
                Margin = new Padding(0),
                BackColor = Color.FromArgb(229, 57, 53)
            };

            this.tabSelector = new MaterialTabSelector
            {
                Depth = 0,
                MouseState = MaterialSkin.MouseState.HOVER,
                Dock = DockStyle.Top,
                Height = TAB_HEIGHT,
                Margin = new Padding(0),
                BackColor = Color.FromArgb(229, 57, 53)
            };

            // Add tab pages
            AddTabPages();

            // Link tab selector to tab control
            this.tabSelector.BaseTabControl = this.tabControl;
        }

        private void AddTabPages()
        {
            var tabPages = new[]
            {
                ("Main", "tabMain"),
                ("Schedule", "tabSchedule"),
                ("People", "tabPeople"),
                ("Equipment", "tabEquipment"),
                ("Base", "tabBase"),
                ("Contacts", "tabContacts")
            };

            foreach (var (text, name) in tabPages)
            {
                var tabPage = new TabPage(text)
                {
                    Name = name,
                    Padding = new Padding(PADDING)
                };
                this.tabControl.Controls.Add(tabPage);
            }
        }

        private void InitializeButtons()
        {
            Color buttonColor = Color.FromArgb(229, 57, 53);  // Consistent red color

            this.btnExport = new MaterialButton
            {
                Text = "Export Data",
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                AutoSize = false,
                BackColor = buttonColor,
                ForeColor = Color.White,
                Type = MaterialButton.MaterialButtonType.Contained,
                Visible = true,
                Anchor = AnchorStyles.None,
                UseAccentColor = false
            };

            this.btnSend = new MaterialButton
            {
                Text = "Send Data",
                Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT),
                AutoSize = false,
                BackColor = buttonColor,
                ForeColor = Color.White,
                Type = MaterialButton.MaterialButtonType.Contained,
                Visible = true,
                Anchor = AnchorStyles.None,
                UseAccentColor = false
            };
        }

        private void SetupMainForm()
        {
            this.MinimumSize = new Size(MIN_FORM_WIDTH, MIN_FORM_HEIGHT);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;  // Remove default window chrome
            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
        }

        private void ConfigureLayout()
        {
            // Configure content panel
            this.contentPanel.Controls.Clear();
            this.contentPanel.Controls.Add(this.picCompanyLogo);
            this.contentPanel.Controls.Add(this.lblMainPage);
            this.contentPanel.Controls.Add(this.btnExport);
            this.contentPanel.Controls.Add(this.btnSend);

            // Ensure controls are visible
            this.picCompanyLogo.BringToFront();
            this.lblMainPage.BringToFront();
            this.btnExport.BringToFront();
            this.btnSend.BringToFront();
        }

        private void AddControlsToForm()
        {
            this.SuspendLayout();

            // Clear existing controls
            this.Controls.Clear();

            // Add controls in the correct order (bottom to top)
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tabSelector);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BindEvents()
        {
            this.tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            this.SuspendLayout();

            // Ensure tab controls span full width
            this.tabControl.Width = this.ClientSize.Width;
            this.tabSelector.Width = this.ClientSize.Width;

            // Calculate starting position for content, accounting for window controls and tab selector
            int contentStart = windowControlsPanel.Height + tabSelector.Height;

            // Position logo
            this.picCompanyLogo.Location = new Point(
                (this.ClientSize.Width - this.picCompanyLogo.Width) / 2,
                contentStart + LOGO_PADDING_TOP
            );

            // Position label
            this.lblMainPage.Location = new Point(
                (this.ClientSize.Width - this.lblMainPage.Width) / 2,
                this.picCompanyLogo.Bottom + TEXT_PADDING_FROM_LOGO
            );

            // Position buttons
            int totalButtonWidth = btnExport.Width + PADDING + btnSend.Width;
            int startX = (this.ClientSize.Width - totalButtonWidth) / 2;
            int buttonY = this.lblMainPage.Bottom + BUTTON_PADDING_FROM_TEXT;

            btnExport.Location = new Point(startX, buttonY);
            btnSend.Location = new Point(startX + btnExport.Width + PADDING, buttonY);

            this.ResumeLayout(true);
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only show forms for non-main tabs
            if (tabControl.SelectedTab.Name != "tabMain")
            {
                Form newForm = null;

                switch (tabControl.SelectedTab.Name)
                {
                    case "tabSchedule":
                        newForm = new ScheduleForm();
                        break;
                    case "tabPeople":
                        newForm = new PeopleForm();
                        break;
                    case "tabEquipment":
                        newForm = new EquipmentForm();
                        break;
                    case "tabBase":
                        newForm = new BaseOverviewForm();
                        break;
                    case "tabContacts":
                        newForm = new ContactsForm();
                        break;
                }

                if (newForm != null)
                {
                    newForm.ShowDialog(this);
                    tabControl.SelectedTab = tabControl.TabPages["tabMain"];
                }
            }
            else
            {
                // Show main content
                this.contentPanel.Visible = true;
                this.contentPanel.BringToFront();
            }
        }
    }
}