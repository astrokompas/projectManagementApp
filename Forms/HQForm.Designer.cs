namespace projectManagementApp.Forms
{
    partial class BaseOverviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstBaseEmployees;
        private System.Windows.Forms.ListBox lstBaseEquipment;
        private MaterialSkin.Controls.MaterialLabel lblEmployees;
        private MaterialSkin.Controls.MaterialLabel lblEquipment;

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
            this.lstBaseEmployees = new System.Windows.Forms.ListBox();
            this.lstBaseEquipment = new System.Windows.Forms.ListBox();
            this.lblEmployees = new MaterialSkin.Controls.MaterialLabel();
            this.lblEquipment = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();

            // lstBaseEmployees
            this.lstBaseEmployees.Location = new System.Drawing.Point(20, 60);
            this.lstBaseEmployees.Size = new System.Drawing.Size(300, 150);
            this.lstBaseEmployees.TabIndex = 0;

            // lstBaseEquipment
            this.lstBaseEquipment.Location = new System.Drawing.Point(20, 270);
            this.lstBaseEquipment.Size = new System.Drawing.Size(300, 150);
            this.lstBaseEquipment.TabIndex = 1;

            // lblEmployees
            this.lblEmployees.AutoSize = true;
            this.lblEmployees.Location = new System.Drawing.Point(20, 40);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(150, 19);
            this.lblEmployees.TabIndex = 2;
            this.lblEmployees.Text = "Employees at BASE:";

            // lblEquipment
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Location = new System.Drawing.Point(20, 250);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(200, 19);
            this.lblEquipment.TabIndex = 3;
            this.lblEquipment.Text = "Equipment at BASE or SERWIS:";

            // BaseOverviewForm
            this.ClientSize = new System.Drawing.Size(360, 450);
            this.Controls.Add(this.lstBaseEmployees);
            this.Controls.Add(this.lstBaseEquipment);
            this.Controls.Add(this.lblEmployees);
            this.Controls.Add(this.lblEquipment);
            this.Name = "BaseOverviewForm";
            this.Text = "Base Overview";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}