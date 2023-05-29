using System;
using System.Windows.Forms;
using ThalesSolution;

namespace ThalesAssessment
{
    public partial class MainForm : Form
    {
        private WorkersManager workersManager;
        private readonly OpenFileDialog fileChooserDialog;

        public MainForm()
        {
            this.workersManager = new WorkersManager();
            fileChooserDialog = new OpenFileDialog();
            fileChooserDialog.RestoreDirectory = true;
            InitializeComponent();
        }

        private void LoadWorkers()
        {
            treeView.Nodes.Clear();
            if (workersManager.UnsupervisedWorkers.Count > 0)
            {
                foreach (Worker parent in workersManager.UnsupervisedWorkers)
                {
                    CreateNodes(parent);
                }
            }
        }

        private void CreateNodes(Worker parent)
        {
            TreeNode parentNode = new TreeNode(parent.ToString());
            treeView.Nodes.Add(parentNode);
            CreateChildNodes(parentNode, parent);
        }

        private void CreateChildNodes(TreeNode parentNode, Worker parent)
        {
            foreach (Worker child in parent.Supervised)
            {
                TreeNode node = new TreeNode(child.ToString());
                parentNode.Nodes.Add(node);
                CreateChildNodes(node, child);
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

            return true;
        }

        private void addUnsupervisedButton_Click(object sender, EventArgs e)
        {
            if (!InputValid())
            {
                return;
            }

            Worker newWorker = new Worker(nameTextBox.Text, roleTextBox.Text);
            workersManager.AddUnsupervisedWorker(newWorker);
            treeView.Nodes.Add(new TreeNode(newWorker.ToString()));
            errorLabel.Text = "";
        }

        private void addSupervisedButton_Click(object sender, EventArgs e)
        {
            if (!InputValid())
            {
                return;
            }

            if (treeView.SelectedNode == null)
            {
                errorLabel.Text = "Select a person before pressing \"Add supervised person\"";
                return;
            }

            Worker newWorker = new Worker(nameTextBox.Text, roleTextBox.Text);
            Worker supervisor = Worker.FromString(treeView.SelectedNode.Text);
            workersManager.AddSupervisedWorker(supervisor, newWorker);
            treeView.SelectedNode.Nodes.Add(new TreeNode(newWorker.ToString()));
            errorLabel.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                errorLabel.Text = "Select a person before pressing \"Remove person\"";
                return;
            }

            workersManager.RemoveWorker(Worker.FromString(treeView.SelectedNode.Text));
            treeView.Nodes.Remove(treeView.SelectedNode);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                errorLabel.Text = "Select a person before pressing \"Update person\"";
                return;
            }

            Worker toUpdate = Worker.FromString(treeView.SelectedNode.Text);
            Worker updatedWorker = workersManager.UpdateWorker(toUpdate, nameTextBox.Text, roleTextBox.Text);
            treeView.SelectedNode.Text = updatedWorker.ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileChooserDialog.Title = "Choose a json file to load";
            fileChooserDialog.ShowDialog();
            if (fileChooserDialog.FileNames.Length > 0)
            {
                string file = fileChooserDialog.FileNames[0];
                workersManager = WorkersManager.FromJson(file);
                LoadWorkers();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileChooserDialog.Title = "Save as";
            fileChooserDialog.ShowDialog();
            if (fileChooserDialog.FileNames.Length > 0)
            {
                workersManager.SaveToJson(fileChooserDialog.FileNames[0]);
            }
        }
    }
}
