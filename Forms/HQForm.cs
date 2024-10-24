using projectManagementApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace projectManagementApp.Forms
{
    public partial class BaseOverviewForm : MaterialForm
    {
        private List<Employee> employees;
        private List<Equipment> equipmentList;

        public BaseOverviewForm()
        {
            InitializeComponent();
            // Apply MaterialSkin design for a modern look
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Red200, TextShade.WHITE);

            // Load the data from EmployeeManager and EquipmentManager
            employees = EmployeeManager.LoadEmployees();
            equipmentList = EquipmentManager.LoadEquipment();
            DisplayBaseEmployees();
            DisplayBaseAndServiceEquipment();
        }

        private void DisplayBaseEmployees()
        {
            // Filter employees to show only those at BASE
            var baseEmployees = employees.Where(emp => emp.Status == "BAZA").ToList();
            lstBaseEmployees.DataSource = null;
            lstBaseEmployees.DataSource = baseEmployees;
        }

        private void DisplayBaseAndServiceEquipment()
        {
            // Filter equipment to show those at BASE or SERWIS
            var baseAndServiceEquipment = equipmentList
                .Where(equip => equip.Status == "BAZA" || equip.Status == "SERWIS")
                .ToList();
            lstBaseEquipment.DataSource = null;
            lstBaseEquipment.DataSource = baseAndServiceEquipment;
        }
    }
}