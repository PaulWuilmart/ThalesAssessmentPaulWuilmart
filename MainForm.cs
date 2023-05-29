using System;
using System.Windows.Forms;
using ThalesSolution;

namespace ThalesAssessment
{
    public partial class MainForm : Form
    {
        private WorkersManager workersManager;
        public MainForm(WorkersManager workersManager)
        {
            this.workersManager = workersManager;
            InitializeComponent();
            if (workersManager.workers.Count != 0) {
            
            }
        }

        private bool InputValid()
        {
            if (nameTextBox.Text == "" || roleTextBox.Text == "")
            {
                errorLabel.Text = "Please enter name and role.";
                return false;
            }

            if (workersManager.ContainsWorker(new Worker(nameTextBox.Text, roleTextBox.Text)))
            {
                errorLabel.Text = "Combination of name and role already exists.";
                return false;
            }
            // TODO Check if that name and role does not already exist.
            return true;
        }

        private void addUnsupervisedButton_Click(object sender, EventArgs e)
        {
            if (!InputValid()) return;

            Worker worker = new Worker(nameTextBox.Text, roleTextBox.Text);
            workersManager.AddWorker(worker);
            TreeNode node = new TreeNode(worker.ToString());
            treeView1.Nodes.Add(node);
            errorLabel.Text = "";
        }

        private void addSupervisedButton_Click(object sender, EventArgs e)
        {
            if (!InputValid()) return;

            if (treeView1.SelectedNode == null)
            {
                errorLabel.Text = "Select a person before pressing \"Add supervised person\"";
                return;
            }
            Worker worker = new Worker(nameTextBox.Text, roleTextBox.Text);
            Worker supervisor = Worker.FromString(treeView1.SelectedNode.Text);
            workersManager.AddSupervisedWorker(supervisor, worker);
            TreeNode node = new TreeNode(worker.ToString());
            treeView1.SelectedNode.Nodes.Add(node);
            errorLabel.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                errorLabel.Text = "Select a person before pressing \"Remove person\"";
                return;
            }
            workersManager.RemoveWorker(Worker.FromString(treeView1.SelectedNode.Text));
            treeView1.Nodes.Remove(treeView1.SelectedNode);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                errorLabel.Text = "Select a person before pressing \"Update person\"";
                return;
            }
            Worker worker = Worker.FromString(treeView1.SelectedNode.Text);

            Worker updatedWorker = workersManager.UpdateWorker(worker, nameTextBox.Text, roleTextBox.Text);
            treeView1.SelectedNode.Text = updatedWorker.ToString();
        }
    }
}
