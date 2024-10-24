namespace projectManagementApp.Forms
{
    partial class EquipmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtEquipmentName;
        private MaterialSkin.Controls.MaterialTextBox txtEquipmentType;
        private MaterialSkin.Controls.MaterialTextBox txtServiceStatus;
        private MaterialSkin.Controls.MaterialButton btnAddEquipment;
        private MaterialSkin.Controls.MaterialButton btnEditEquipment;
        private MaterialSkin.Controls.MaterialButton btnRemoveEquipment;
        private System.Windows.Forms.ListBox lstEquipment;

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
            this.txtEquipmentName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEquipmentType = new MaterialSkin.Controls.MaterialTextBox();
            this.txtServiceStatus = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAddEquipment = new MaterialSkin.Controls.MaterialButton();
            this.btnEditEquipment = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveEquipment = new MaterialSkin.Controls.MaterialButton();
            this.lstEquipment = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // txtEquipmentName
            this.txtEquipmentName.Hint = "Equipment Name";
            this.txtEquipmentName.Location = new System.Drawing.Point(20, 20);
            this.txtEquipmentName.Size = new System.Drawing.Size(200, 30);
            this.txtEquipmentName.TabIndex = 0;

            // txtEquipmentType
            this.txtEquipmentType.Hint = "Equipment Type";
            this.txtEquipmentType.Location = new System.Drawing.Point(20, 60);
            this.txtEquipmentType.Size = new System.Drawing.Size(200, 30);
            this.txtEquipmentType.TabIndex = 1;

            // txtServiceStatus
            this.txtServiceStatus.Hint = "Service Status (Leave blank if not in service)";
            this.txtServiceStatus.Location = new System.Drawing.Point(20, 100);
            this.txtServiceStatus.Size = new System.Drawing.Size(200, 30);
            this.txtServiceStatus.TabIndex = 2;

            // btnAddEquipment
            this.btnAddEquipment.Text = "Add Equipment";
            this.btnAddEquipment.Location = new System.Drawing.Point(240, 20);
            this.btnAddEquipment.Size = new System.Drawing.Size(120, 36);
            this.btnAddEquipment.Click += new System.EventHandler(this.btnAddEquipment_Click);

            // btnEditEquipment
            this.btnEditEquipment.Text = "Edit Equipment";
            this.btnEditEquipment.Location = new System.Drawing.Point(240, 60);
            this.btnEditEquipment.Size = new System.Drawing.Size(120, 36);
            this.btnEditEquipment.Click += new System.EventHandler(this.btnEditEquipment_Click);

            // btnRemoveEquipment
            this.btnRemoveEquipment.Text = "Remove Equipment";
            this.btnRemoveEquipment.Location = new System.Drawing.Point(240, 100);
            this.btnRemoveEquipment.Size = new System.Drawing.Size(120, 36);
            this.btnRemoveEquipment.Click += new System.EventHandler(this.btnRemoveEquipment_Click);

            // lstEquipment
            this.lstEquipment.Location = new System.Drawing.Point(20, 150);
            this.lstEquipment.Size = new System.Drawing.Size(340, 150);
            this.lstEquipment.TabIndex = 6;

            // EquipmentForm
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.txtEquipmentName);
            this.Controls.Add(this.txtEquipmentType);
            this.Controls.Add(this.txtServiceStatus);
            this.Controls.Add(this.btnAddEquipment);
            this.Controls.Add(this.btnEditEquipment);
            this.Controls.Add(this.btnRemoveEquipment);
            this.Controls.Add(this.lstEquipment);
            this.Text = "Equipment Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}