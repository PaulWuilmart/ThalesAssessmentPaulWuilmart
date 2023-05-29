namespace ThalesAssessment
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.addUnsupervisedButton = new System.Windows.Forms.Button();
            this.addSupervisedButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.roleTextBox = new System.Windows.Forms.TextBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(561, 416);
            this.treeView1.TabIndex = 0;
            // 
            // addUnsupervisedButton
            // 
            this.addUnsupervisedButton.Location = new System.Drawing.Point(643, 132);
            this.addUnsupervisedButton.Name = "addUnsupervisedButton";
            this.addUnsupervisedButton.Size = new System.Drawing.Size(155, 23);
            this.addUnsupervisedButton.TabIndex = 1;
            this.addUnsupervisedButton.Text = "Add unsupervised person";
            this.addUnsupervisedButton.UseVisualStyleBackColor = true;
            this.addUnsupervisedButton.Click += new System.EventHandler(this.addUnsupervisedButton_Click);
            // 
            // addSupervisedButton
            // 
            this.addSupervisedButton.Location = new System.Drawing.Point(643, 102);
            this.addSupervisedButton.Name = "addSupervisedButton";
            this.addSupervisedButton.Size = new System.Drawing.Size(155, 24);
            this.addSupervisedButton.TabIndex = 2;
            this.addSupervisedButton.Text = "Add supervised person";
            this.addSupervisedButton.UseVisualStyleBackColor = true;
            this.addSupervisedButton.Click += new System.EventHandler(this.addSupervisedButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(579, 12);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(602, 175);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(643, 175);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // roleTextBox
            // 
            this.roleTextBox.Location = new System.Drawing.Point(643, 201);
            this.roleTextBox.Name = "roleTextBox";
            this.roleTextBox.Size = new System.Drawing.Size(100, 20);
            this.roleTextBox.TabIndex = 6;
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Location = new System.Drawing.Point(602, 204);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(29, 13);
            this.roleLabel.TabIndex = 7;
            this.roleLabel.Text = "Role";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(644, 74);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(155, 23);
            this.removeButton.TabIndex = 8;
            this.removeButton.Text = "Remove person";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(644, 45);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(154, 23);
            this.updateButton.TabIndex = 9;
            this.updateButton.Text = "Update Person";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.roleTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.addSupervisedButton);
            this.Controls.Add(this.addUnsupervisedButton);
            this.Controls.Add(this.treeView1);
            this.Name = "MainForm";
            this.Text = "Organization structure manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button addUnsupervisedButton;
        private System.Windows.Forms.Button addSupervisedButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox roleTextBox;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button updateButton;
    }
}

