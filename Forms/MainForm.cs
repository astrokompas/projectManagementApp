using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace projectManagementApp.Forms
{
    public partial class MainForm : MaterialForm
    {
        private readonly IConfiguration _configuration;
        private readonly MaterialSkinManager _materialSkinManager;
        private const int HEADER_HEIGHT = 100;

        public MainForm(IConfiguration configuration)
        {
            _configuration = configuration;
            _materialSkinManager = MaterialSkinManager.Instance;
            InitializeComponent();
            InitializeMaterialDesign();
            InitializeEventHandlers();

            // Add resize handler
            this.Resize += (s, e) => UpdateControlPositions();

            // Force initial layout
            UpdateControlPositions();
        }

        private void InitializeMaterialDesign()
        {
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            _materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red600,  // Main color - consistent with button color
                Primary.Red700,  // Dark variant
                Primary.Red200,  // Light variant
                Accent.Red200,   // Accent
                TextShade.WHITE  // Text color
            );
        }

        private void InitializeEventHandlers()
        {
            this.Resize += MainForm_Resize;
            this.tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            this.btnExport.Click += async (s, e) => await HandleExportAsync();
            this.btnSend.Click += async (s, e) => await HandleSendAsync();
        }

        private async Task HandleExportAsync()
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FilterIndex = 1,
                    RestoreDirectory = true
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        await ExportDataToExcelAsync(saveFileDialog.FileName);
                        MessageBox.Show(
                            "Data exported successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("Export failed", ex);
            }
        }

        private async Task HandleSendAsync()
        {
            try
            {
                string tempFile = Path.Combine(Path.GetTempPath(), $"export_{Guid.NewGuid()}.xlsx");
                await ExportDataToExcelAsync(tempFile);
                await SendDataViaEmailAsync(tempFile);
                File.Delete(tempFile);  // Clean up temp file

                MessageBox.Show(
                    "Data sent successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                HandleError("Send failed", ex);
            }
        }

        private async Task ExportDataToExcelAsync(string filePath)
        {
            await Task.Run(() =>
            {
                using (var package = new ExcelPackage())
                {
                    // Export Employees
                    var employeeSheet = package.Workbook.Worksheets.Add("Employees");
                    var employees = EmployeeManager.LoadEmployees();
                    ExportToWorksheet(employeeSheet, employees, new (string, Func<object, string>)[]
                    {
                ("Name", e => ((Employee)e).Name),
                ("Position", e => ((Employee)e).Position),
                ("Status", e => ((Employee)e).Status)
                    });

                    // Export Equipment
                    var equipmentSheet = package.Workbook.Worksheets.Add("Equipment");
                    var equipment = EquipmentManager.LoadEquipment();
                    ExportToWorksheet(equipmentSheet, equipment, new (string, Func<object, string>)[]
                    {
                ("Name", e => ((Equipment)e).Name),
                ("Type", e => ((Equipment)e).Type),
                ("Status", e => ((Equipment)e).Status)
                    });

                    // Export Projects
                    var projectSheet = package.Workbook.Worksheets.Add("Projects");
                    var projects = ProjectManager.LoadProjects();
                    ExportToWorksheet(projectSheet, projects, new (string, Func<object, string>)[]
                    {
                ("Project Name", p => ((Project)p).Name),
                ("Assigned Employees", p => string.Join(", ", ((Project)p).AssignedEmployees.Select(e => e.Name))),
                ("Assigned Equipment", p => string.Join(", ", ((Project)p).AssignedEquipment.Select(e => e.Name)))
                    });

                    // Auto-fit columns in all sheets
                    foreach (var worksheet in package.Workbook.Worksheets)
                    {
                        worksheet.Cells.AutoFitColumns();
                    }

                    package.SaveAs(new FileInfo(filePath));
                }
            });
        }


        private void ExportToWorksheet<T>(ExcelWorksheet worksheet, IList<T> data, (string Header, Func<object, string> ValueSelector)[] columns)
        {
            // Write headers
            for (int i = 0; i < columns.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = columns[i].Header;
            }

            // Write data
            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < columns.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = columns[col].ValueSelector(data[row]);
                }
            }
        }

        private async Task SendDataViaEmailAsync(string filePath)
        {
            var contacts = ContactsManager.LoadContacts();
            if (!contacts.Any())
            {
                throw new InvalidOperationException("No contacts available to send the email.");
            }

            var emailConfig = _configuration.GetSection("Email");

            using (var mail = new MailMessage())
            {
                using (var smtp = new SmtpClient(emailConfig["Server"]))
                {
                    smtp.Port = emailConfig.GetValue<int>("Port");
                    smtp.Credentials = new NetworkCredential(
                        emailConfig["Username"],
                        emailConfig["Password"]
                    );
                    smtp.EnableSsl = true;

                    mail.From = new MailAddress(emailConfig["From"]);
                    foreach (var contact in contacts)
                    {
                        mail.To.Add(contact);
                    }

                    mail.Subject = "Company Data Export";
                    mail.Body = "Please find the attached exported data file.";
                    mail.Attachments.Add(new Attachment(filePath));

                    await smtp.SendMailAsync(mail);
                }
            }
        }

        private void HandleError(string operation, Exception ex)
        {
            MessageBox.Show(
                $"{operation}: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            // Log the error here if you have logging implemented
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _materialSkinManager?.RemoveFormToManage(this);
        }

        private void CenterControls()
        {
            this.SuspendLayout();

            // Center the logo at the top
            picCompanyLogo.Location = new Point(
                (ClientSize.Width - picCompanyLogo.Width) / 2,
                HEADER_HEIGHT
            );

            // Position the label below the logo
            lblMainPage.Location = new Point(
                (ClientSize.Width - lblMainPage.Width) / 2,
                picCompanyLogo.Bottom + PADDING
            );

            // Center the buttons horizontally and position them below the label
            int totalButtonWidth = btnExport.Width + PADDING + btnSend.Width;
            int startX = (ClientSize.Width - totalButtonWidth) / 2;

            btnExport.Location = new Point(
                startX,
                lblMainPage.Bottom + PADDING
            );

            btnSend.Location = new Point(
                btnExport.Right + PADDING,
                btnExport.Top
            );
            btnExport.BackColor = Color.Red;
            btnSend.BackColor = Color.Red;

            // Update tab control and selector widths
            tabControl.Width = ClientSize.Width;
            tabSelector.Width = ClientSize.Width;

            this.ResumeLayout(true);
        }

    }
}