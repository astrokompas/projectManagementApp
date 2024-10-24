namespace projectManagementApp.Forms
{
    partial class ContactsForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialButton btnAddContact;
        private MaterialSkin.Controls.MaterialButton btnEditContact;
        private MaterialSkin.Controls.MaterialButton btnRemoveContact;
        private System.Windows.Forms.ListBox lstContacts;
        private MaterialSkin.Controls.MaterialLabel lblContacts;

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
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.btnAddContact = new MaterialSkin.Controls.MaterialButton();
            this.btnEditContact = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveContact = new MaterialSkin.Controls.MaterialButton();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.lblContacts = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();

            // txtEmail
            this.txtEmail.Hint = "Enter Email Address";
            this.txtEmail.Location = new System.Drawing.Point(20, 80);
            this.txtEmail.Size = new System.Drawing.Size(300, 30);
            this.txtEmail.TabIndex = 0;

            // btnAddContact
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.Location = new System.Drawing.Point(340, 80);
            this.btnAddContact.Size = new System.Drawing.Size(120, 36);
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);

            // btnEditContact
            this.btnEditContact.Text = "Edit Contact";
            this.btnEditContact.Location = new System.Drawing.Point(340, 130);
            this.btnEditContact.Size = new System.Drawing.Size(120, 36);
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);

            // btnRemoveContact
            this.btnRemoveContact.Text = "Remove Contact";
            this.btnRemoveContact.Location = new System.Drawing.Point(340, 180);
            this.btnRemoveContact.Size = new System.Drawing.Size(120, 36);
            this.btnRemoveContact.Click += new System.EventHandler(this.btnRemoveContact_Click);

            // lstContacts
            this.lstContacts.Location = new System.Drawing.Point(20, 130);
            this.lstContacts.Size = new System.Drawing.Size(300, 200);

            // lblContacts
            this.lblContacts.Text = "Contacts:";
            this.lblContacts.Location = new System.Drawing.Point(20, 110);
            this.lblContacts.Size = new System.Drawing.Size(100, 20);

            // ContactsForm
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.btnEditContact);
            this.Controls.Add(this.btnRemoveContact);
            this.Controls.Add(this.lstContacts);
            this.Controls.Add(this.lblContacts);
            this.Text = "Contacts Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}