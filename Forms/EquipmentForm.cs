using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace projectManagementApp.Forms
{
    public partial class EquipmentForm : MaterialForm
    {
        private List<Equipment> equipmentList;

        public EquipmentForm()
        {
            InitializeComponent();
            // Apply MaterialSkin design for a modern look
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Red200, TextShade.WHITE);

            // Load equipment from JSON when the form is initialized
            equipmentList = EquipmentManager.LoadEquipment();
            UpdateEquipmentList();
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            string name = txtEquipmentName.Text;
            string type = txtEquipmentType.Text;
            string serviceStatus = txtServiceStatus.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
            {
                Equipment newEquipment = new Equipment(name, type);
                if (!string.IsNullOrEmpty(serviceStatus))
                {
                    newEquipment.Status = "SERWIS";
                }
                equipmentList.Add(newEquipment);
                EquipmentManager.SaveEquipment(equipmentList);
                UpdateEquipmentList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Name and Type fields cannot be empty.");
            }
        }

        private void btnEditEquipment_Click(object sender, EventArgs e)
        {
            if (lstEquipment.SelectedItem != null)
            {
                Equipment equipment = (Equipment)lstEquipment.SelectedItem;
                equipment.Name = txtEquipmentName.Text;
                equipment.Type = txtEquipmentType.Text;
                if (!string.IsNullOrEmpty(txtServiceStatus.Text))
                {
                    equipment.Status = "SERWIS";
                }
                else
                {
                    equipment.Status = "BAZA";
                }
                EquipmentManager.SaveEquipment(equipmentList);
                UpdateEquipmentList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an equipment item to edit.");
            }
        }

        private void btnRemoveEquipment_Click(object sender, EventArgs e)
        {
            if (lstEquipment.SelectedItem != null)
            {
                equipmentList.Remove((Equipment)lstEquipment.SelectedItem);
                EquipmentManager.SaveEquipment(equipmentList);
                UpdateEquipmentList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an equipment item to remove.");
            }
        }

        private void UpdateEquipmentList()
        {
            lstEquipment.DataSource = null;
            lstEquipment.DataSource = equipmentList;
        }

        private void ClearInputFields()
        {
            txtEquipmentName.Clear();
            txtEquipmentType.Clear();
            txtServiceStatus.Clear();
        }
    }

    public class Equipment
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public Equipment(string name, string type)
        {
            Name = name;
            Type = type;
            Status = "BAZA";
        }

        public override string ToString()
        {
            return $"{Name} - {Type} ({Status})";
        }
    }

    public static class EquipmentManager
    {
        private static readonly string equipmentFile = "equipment.json";

        public static void SaveEquipment(List<Equipment> equipmentList)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(equipmentList, options);
            File.WriteAllText(equipmentFile, jsonData);
        }

        public static List<Equipment> LoadEquipment()
        {
            if (File.Exists(equipmentFile))
            {
                string jsonData = File.ReadAllText(equipmentFile);
                return JsonSerializer.Deserialize<List<Equipment>>(jsonData);
            }
            return new List<Equipment>();
        }
    }
}