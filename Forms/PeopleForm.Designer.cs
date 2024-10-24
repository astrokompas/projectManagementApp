namespace projectManagementApp.Forms
{
    partial class PeopleForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtPosition;
        private MaterialSkin.Controls.MaterialTextBox txtVacation;
        private MaterialSkin.Controls.MaterialButton btnAddEmployee;
        private MaterialSkin.Controls.MaterialButton btnEditEmployee;
        private MaterialSkin.Controls.MaterialButton btnRemoveEmployee;
        private System.Windows.Forms.ListBox lstEmployees;

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
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPosition = new MaterialSkin.Controls.MaterialTextBox();
            this.txtVacation = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAddEmployee = new MaterialSkin.Controls.MaterialButton();
            this.btnEditEmployee = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveEmployee = new MaterialSkin.Controls.MaterialButton();
            this.lstEmployees = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // txtName
            this.txtName.Hint = "Employee Name";
            this.txtName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Size = new System.Drawing.Size(200, 30);
            this.txtName.TabIndex = 0;

            // txtPosition
            this.txtPosition.Hint = "Position";
            this.txtPosition.Location = new System.Drawing.Point(20, 60);
            this.txtPosition.Size = new System.Drawing.Size(200, 30);
            this.txtPosition.TabIndex = 1;

            // txtVacation
            this.txtVacation.Hint = "Vacation Status (Leave blank if not on vacation)";
            this.txtVacation.Location = new System.Drawing.Point(20, 100);
            this.txtVacation.Size = new System.Drawing.Size(200, 30);
            this.txtVacation.TabIndex = 2;

            // btnAddEmployee
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.Location = new System.Drawing.Point(240, 20);
            this.btnAddEmployee.Size = new System.Drawing.Size(120, 36);
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);

            // btnEditEmployee
            this.btnEditEmployee.Text = "Edit Employee";
            this.btnEditEmployee.Location = new System.Drawing.Point(240, 60);
            this.btnEditEmployee.Size = new System.Drawing.Size(120, 36);
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);

            // btnRemoveEmployee
            this.btnRemoveEmployee.Text = "Remove Employee";
            this.btnRemoveEmployee.Location = new System.Drawing.Point(240, 100);
            this.btnRemoveEmployee.Size = new System.Drawing.Size(120, 36);
            this.btnRemoveEmployee.Click += new System.EventHandler(this.btnRemoveEmployee_Click);

            // lstEmployees
            this.lstEmployees.Location = new System.Drawing.Point(20, 150);
            this.lstEmployees.Size = new System.Drawing.Size(340, 150);
            this.lstEmployees.TabIndex = 6;

            // PeopleForm
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtVacation);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.btnRemoveEmployee);
            this.Controls.Add(this.lstEmployees);
            this.Text = "People Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}