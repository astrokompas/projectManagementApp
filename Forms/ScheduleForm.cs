using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using projectManagementApp;
using MaterialSkin;
using MaterialSkin.Controls;

namespace projectManagementApp.Forms
{
    public partial class ScheduleForm : MaterialForm
    {
        private List<Project> projects;
        private List<Employee> employees;
        private List<Equipment> equipmentList;

        public ScheduleForm()
        {
            InitializeComponent();
            // Apply MaterialSkin design for a modern look
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red700, Primary.Red200, Accent.Red200, TextShade.WHITE);

            // Load data from EmployeeManager and EquipmentManager
            projects = ProjectManager.LoadProjects();
            employees = EmployeeManager.LoadEmployees();
            equipmentList = EquipmentManager.LoadEquipment();
            UpdateProjectList();
            UpdateAvailableEmployees();
            UpdateAvailableEquipment();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            DateTime projectDate = dtpProjectDate.Value;

            if (!string.IsNullOrEmpty(projectName))
            {
                Project newProject = new Project(projectName, projectDate);
                projects.Add(newProject);
                ProjectManager.SaveProjects(projects);
                UpdateProjectList();
            }
            else
            {
                MessageBox.Show("Project name cannot be empty.");
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (lstProjects.SelectedItem != null)
            {
                Project project = (Project)lstProjects.SelectedItem;
                project.Name = txtProjectName.Text;
                project.Date = dtpProjectDate.Value;
                ProjectManager.SaveProjects(projects);
                UpdateProjectList();
            }
        }

        private void btnRemoveProject_Click(object sender, EventArgs e)
        {
            if (lstProjects.SelectedItem != null)
            {
                projects.Remove((Project)lstProjects.SelectedItem);
                ProjectManager.SaveProjects(projects);
                UpdateProjectList();
            }
        }

        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            if (lstProjects.SelectedItem != null && lstAvailableEmployees.SelectedItem != null)
            {
                Project project = (Project)lstProjects.SelectedItem;
                Employee employee = (Employee)lstAvailableEmployees.SelectedItem;
                project.AssignedEmployees.Add(employee);
                employee.Status = "NA ROBOCIE";
                ProjectManager.SaveProjects(projects);
                EmployeeManager.SaveEmployees(employees);
                UpdateAvailableEmployees();
                UpdateProjectList();
            }
        }

        private void btnAssignEquipment_Click(object sender, EventArgs e)
        {
            if (lstProjects.SelectedItem != null && lstAvailableEquipment.SelectedItem != null)
            {
                Project project = (Project)lstProjects.SelectedItem;
                Equipment equipment = (Equipment)lstAvailableEquipment.SelectedItem;
                project.AssignedEquipment.Add(equipment);
                equipment.Status = "NA ROBOCIE";
                ProjectManager.SaveProjects(projects);
                EquipmentManager.SaveEquipment(equipmentList);
                UpdateAvailableEquipment();
                UpdateProjectList();
            }
        }

        private void UpdateProjectList()
        {
            lstProjects.DataSource = null;
            lstProjects.DataSource = projects;
        }

        private void UpdateAvailableEmployees()
        {
            lstAvailableEmployees.DataSource = null;
            lstAvailableEmployees.DataSource = employees.FindAll(emp => emp.Status == "BAZA");
        }

        private void UpdateAvailableEquipment()
        {
            lstAvailableEquipment.DataSource = null;
            lstAvailableEquipment.DataSource = equipmentList.FindAll(eq => eq.Status == "BAZA");
        }
    }

    public class Project
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Employee> AssignedEmployees { get; set; }
        public List<Equipment> AssignedEquipment { get; set; }

        public Project(string name, DateTime date)
        {
            Name = name;
            Date = date;
            AssignedEmployees = new List<Employee>();
            AssignedEquipment = new List<Equipment>();
        }

        public override string ToString()
        {
            return $"{Name} ({Date.ToShortDateString()}) - Employees: {AssignedEmployees.Count}, Equipment: {AssignedEquipment.Count}";
        }
    }

    public static class ProjectManager
    {
        private static readonly string projectFile = "projects.json";

        public static void SaveProjects(List<Project> projects)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(projects, options);
            File.WriteAllText(projectFile, jsonData);
        }

        public static List<Project> LoadProjects()
        {
            if (File.Exists(projectFile))
            {
                string jsonData = File.ReadAllText(projectFile);
                return JsonSerializer.Deserialize<List<Project>>(jsonData);
            }
            return new List<Project>();
        }
    }
}