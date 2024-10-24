using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace projectManagementApp.Forms
{
    public partial class ContactsForm : MaterialForm
    {
        private List<string> contacts;

        public ContactsForm()
        {
            InitializeComponent();
            // Apply MaterialSkin design for a modern look
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Red200, TextShade.WHITE);

            // Load contacts from JSON when the form is initialized
            contacts = ContactsManager.LoadContacts();
            UpdateContactList();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (IsValidEmail(email))
            {
                if (!contacts.Contains(email))
                {
                    contacts.Add(email);
                    ContactsManager.SaveContacts(contacts);
                    UpdateContactList();
                    txtEmail.Clear();
                    MessageBox.Show("Contact added successfully.", "Success");
                }
                else
                {
                    MessageBox.Show("This email address already exists.", "Duplicate Entry");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email");
            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedItem != null)
            {
                string email = txtEmail.Text;
                if (IsValidEmail(email))
                {
                    int selectedIndex = lstContacts.SelectedIndex;
                    contacts[selectedIndex] = email;
                    ContactsManager.SaveContacts(contacts);
                    UpdateContactList();
                    txtEmail.Clear();
                    MessageBox.Show("Contact edited successfully.", "Success");
                }
                else
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email");
                }
            }
            else
            {
                MessageBox.Show("Please select a contact to edit.", "No Contact Selected");
            }
        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedItem != null)
            {
                contacts.Remove((string)lstContacts.SelectedItem);
                ContactsManager.SaveContacts(contacts);
                UpdateContactList();
                MessageBox.Show("Contact removed successfully.", "Success");
            }
            else
            {
                MessageBox.Show("Please select a contact to remove.", "No Contact Selected");
            }
        }

        private void UpdateContactList()
        {
            lstContacts.DataSource = null;
            lstContacts.DataSource = contacts;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    public static class ContactsManager
    {
        private static readonly string contactsFile = "contacts.json";

        public static void SaveContacts(List<string> contacts)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(contacts, options);
            File.WriteAllText(contactsFile, jsonData);
        }

        public static List<string> LoadContacts()
        {
            if (File.Exists(contactsFile))
            {
                string jsonData = File.ReadAllText(contactsFile);
                return JsonSerializer.Deserialize<List<string>>(jsonData);
            }
            return new List<string>();
        }
    }
}
