using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace projectManagementApp.Forms
{
    public partial class PeopleForm : MaterialForm
    {
        private List<Employee> employees;

        public PeopleForm()
        {
            InitializeComponent();
            // Apply MaterialSkin design for a modern look
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Red200, TextShade.WHITE);

            // Load employees from JSON when the form is initialized
            employees = EmployeeManager.LoadEmployees();
            UpdateEmployeeList();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string position = txtPosition.Text;
            string vacation = txtVacation.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(position))
            {
                Employee newEmployee = new Employee(name, position);
                if (!string.IsNullOrEmpty(vacation))
                {
                    newEmployee.Status = "URLOP";
                }
                employees.Add(newEmployee);
                EmployeeManager.SaveEmployees(employees);
                UpdateEmployeeList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Name and Position fields cannot be empty.");
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedItem != null)
            {
                Employee employee = (Employee)lstEmployees.SelectedItem;
                employee.Name = txtName.Text;
                employee.Position = txtPosition.Text;
                if (!string.IsNullOrEmpty(txtVacation.Text))
                {
                    employee.Status = "URLOP";
                }
                else
                {
                    employee.Status = "BAZA";
                }
                EmployeeManager.SaveEmployees(employees);
                UpdateEmployeeList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedItem != null)
            {
                employees.Remove((Employee)lstEmployees.SelectedItem);
                EmployeeManager.SaveEmployees(employees);
                UpdateEmployeeList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an employee to remove.");
            }
        }

        private void UpdateEmployeeList()
        {
            lstEmployees.DataSource = null;
            lstEmployees.DataSource = employees;
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtPosition.Clear();
            txtVacation.Clear();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
            Status = "BAZA";
        }

        public override string ToString()
        {
            return $"{Name} - {Position} ({Status})";
        }
    }

    public static class EmployeeManager
    {
        private static readonly string employeeFile = "employees.json";

        public static void SaveEmployees(List<Employee> employees)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(employees, options);
            File.WriteAllText(employeeFile, jsonData);
        }

        public static List<Employee> LoadEmployees()
        {
            if (File.Exists(employeeFile))
            {
                string jsonData = File.ReadAllText(employeeFile);
                return JsonSerializer.Deserialize<List<Employee>>(jsonData);
            }
            return new List<Employee>();
        }
    }
}