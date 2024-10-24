namespace projectManagementApp.Forms
{
    partial class ScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtProjectName;
        private MaterialSkin.Controls.MaterialButton btnAddProject;
        private MaterialSkin.Controls.MaterialButton btnEditProject;
        private MaterialSkin.Controls.MaterialButton btnRemoveProject;
        private System.Windows.Forms.ListBox lstProjects;
        private System.Windows.Forms.ListBox lstAvailableEmployees;
        private System.Windows.Forms.ListBox lstAvailableEquipment;
        private MaterialSkin.Controls.MaterialButton btnAssignEmployee;
        private MaterialSkin.Controls.MaterialButton btnAssignEquipment;
        private MaterialSkin.Controls.MaterialLabel lblProjectName;
        private MaterialSkin.Controls.MaterialLabel lblAvailableEmployees;
        private MaterialSkin.Controls.MaterialLabel lblAvailableEquipment;
        private System.Windows.Forms.DateTimePicker dtpProjectDate;

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
            this.txtProjectName = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAddProject = new MaterialSkin.Controls.MaterialButton();
            this.btnEditProject = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveProject = new MaterialSkin.Controls.MaterialButton();
            this.lstProjects = new System.Windows.Forms.ListBox();
            this.lstAvailableEmployees = new System.Windows.Forms.ListBox();
            this.lstAvailableEquipment = new System.Windows.Forms.ListBox();
            this.btnAssignEmployee = new MaterialSkin.Controls.MaterialButton();
            this.btnAssignEquipment = new MaterialSkin.Controls.MaterialButton();
            this.lblProjectName = new MaterialSkin.Controls.MaterialLabel();
            this.lblAvailableEmployees = new MaterialSkin.Controls.MaterialLabel();
            this.lblAvailableEquipment = new MaterialSkin.Controls.MaterialLabel();
            this.dtpProjectDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();

            // txtProjectName
            this.txtProjectName.Hint = "Project Name";
            this.txtProjectName.Location = new System.Drawing.Point(20, 40);
            this.txtProjectName.Size = new System.Drawing.Size(200, 30);
            this.txtProjectName.TabIndex = 0;

            // dtpProjectDate
            this.dtpProjectDate.Location = new System.Drawing.Point(20, 80);
            this.dtpProjectDate.Size = new System.Drawing.Size(200, 30);
            this.dtpProjectDate.TabIndex = 1;

            // btnAddProject
            this.btnAddProject.Text = "Add Project";
            this.btnAddProject.Location = new System.Drawing.Point(240, 40);
            this.btnAddProject.Size = new System.Drawing.Size(120, 36);
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);

            // btnEditProject
            this.btnEditProject.Text = "Edit Project";
            this.btnEditProject.Location = new System.Drawing.Point(240, 80);
            this.btnEditProject.Size = new System.Drawing.Size(120, 36);
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);

            // btnRemoveProject
            this.btnRemoveProject.Text = "Remove Project";
            this.btnRemoveProject.Location = new System.Drawing.Point(240, 120);
            this.btnRemoveProject.Size = new System.Drawing.Size(120, 36);
            this.btnRemoveProject.Click += new System.EventHandler(this.btnRemoveProject_Click);

            // lstProjects
            this.lstProjects.Location = new System.Drawing.Point(20, 180);
            this.lstProjects.Size = new System.Drawing.Size(340, 150);
            this.lstProjects.TabIndex = 4;

            // lstAvailableEmployees
            this.lstAvailableEmployees.Location = new System.Drawing.Point(400, 40);
            this.lstAvailableEmployees.Size = new System.Drawing.Size(200, 150);
            this.lstAvailableEmployees.TabIndex = 5;

            // lstAvailableEquipment
            this.lstAvailableEquipment.Location = new System.Drawing.Point(400, 230);
            this.lstAvailableEquipment.Size = new System.Drawing.Size(200, 150);
            this.lstAvailableEquipment.TabIndex = 6;

            // btnAssignEmployee
            this.btnAssignEmployee.Text = "Assign Employee";
            this.btnAssignEmployee.Location = new System.Drawing.Point(620, 80);
            this.btnAssignEmployee.Size = new System.Drawing.Size(120, 36);
            this.btnAssignEmployee.Click += new System.EventHandler(this.btnAssignEmployee_Click);

            // btnAssignEquipment
            this.btnAssignEquipment.Text = "Assign Equipment";
            this.btnAssignEquipment.Location = new System.Drawing.Point(620, 270);
            this.btnAssignEquipment.Size = new System.Drawing.Size(120, 36);
            this.btnAssignEquipment.Click += new System.EventHandler(this.btnAssignEquipment_Click);

            // lblProjectName
            this.lblProjectName.Text = "Project Name:";
            this.lblProjectName.Location = new System.Drawing.Point(20, 20);
            this.lblProjectName.Size = new System.Drawing.Size(100, 19);
            this.lblProjectName.TabIndex = 9;

            // lblAvailableEmployees
            this.lblAvailableEmployees.Text = "Available Employees:";
            this.lblAvailableEmployees.Location = new System.Drawing.Point(400, 20);
            this.lblAvailableEmployees.Size = new System.Drawing.Size(150, 19);
            this.lblAvailableEmployees.TabIndex = 10;

            // lblAvailableEquipment
            this.lblAvailableEquipment.Text = "Available Equipment:";
            this.lblAvailableEquipment.Location = new System.Drawing.Point(400, 210);
            this.lblAvailableEquipment.Size = new System.Drawing.Size(150, 19);
            this.lblAvailableEquipment.TabIndex = 11;

            // ScheduleForm
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.dtpProjectDate);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.btnEditProject);
            this.Controls.Add(this.btnRemoveProject);
            this.Controls.Add(this.lstProjects);
            this.Controls.Add(this.lstAvailableEmployees);
            this.Controls.Add(this.lstAvailableEquipment);
            this.Controls.Add(this.btnAssignEmployee);
            this.Controls.Add(this.btnAssignEquipment);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.lblAvailableEmployees);
            this.Controls.Add(this.lblAvailableEquipment);
            this.Name = "ScheduleForm";
            this.Text = "Schedule Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}