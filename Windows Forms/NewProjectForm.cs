using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unirest_net;
using System.Collections.ObjectModel;
using System.IO;

namespace GitLab
{
    public partial class NewProjectForm : Form
    {
        
        public GitLab.Project CreatedProject = null;
        public DirectoryInfo LocalProjectDirectory = null;
        
        Config thisConfig
        {
            get
            {
                if (configComboBox.SelectedItem as Config != null)
                    return configComboBox.SelectedItem as Config;
                else
                    return new Config();
            }
        }


        public NewProjectForm()
        {
            InitializeComponent();           
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            LoadConfigDropDown();
            loadControls();
            okButton.Enabled = false;
            projectNameTextBox.CausesValidation = true;
            projectNameTextBox.Validating += projectNameTextBox_Validating;
            projectNameTextBox.Validated += projectNameTextBox_Validated;
            
        }

        void loadControls()
        {
            LoadNamespaces();
            LoadVisibilityDropdown();
            folderTextBox.Text = thisConfig.DefaultProjectLocation + "\\" + projectNameTextBox.Text;
            this.LocalProjectDirectory = new DirectoryInfo(folderTextBox.Text);
        }

        void LoadConfigDropDown()
        {
            foreach (Config C in Config.GetAllConfigs())
            {
                configComboBox.Items.Add(C);
            }

            configComboBox.SelectedIndex = 0;
            configComboBox_SelectedIndexChanged(this, new EventArgs());
        }

        void projectNameTextBox_Validated(object sender, EventArgs e)
        {
            okButton.Enabled = true;
        }

        void projectNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (projectNameTextBox.Text.Contains(' '))
            {
                okButton.Enabled = false;
                e.Cancel = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LocalProjectDirectory = new DirectoryInfo(folderTextBox.Text);
            CreateProject();
            this.Close();
        }

        void CreateProject()
        {
            try
            {
                this.CreatedProject = GitLab.Project.Create(thisConfig, projectNameTextBox.Text, descriptionTextBox.Text, nameSpaceComboBox.SelectedItem as GitLab.Namespace, (GitLab.Project.VisibilityLevel)visibilityComboBox.SelectedItem);                
            }
            catch (Exception ex)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        void LoadNamespaces()
        {
            Collection<GitLab.Namespace> NameSpaces = GitLab.Namespace.List(thisConfig);
            nameSpaceComboBox.Items.Clear();

            foreach (GitLab.Namespace NS in NameSpaces)
            {
                nameSpaceComboBox.Items.Add(NS);

                if (NS.kind.ToUpperInvariant() == "USER")
                    nameSpaceComboBox.SelectedItem = NS;
            }
        }

        void LoadVisibilityDropdown()
        {
            visibilityComboBox.Items.Clear();
           foreach(GitLab.Project.VisibilityLevel Vis in Enum.GetValues(typeof(GitLab.Project.VisibilityLevel)))
           {
               visibilityComboBox.Items.Add(Vis);
           }

           visibilityComboBox.SelectedItem = GitLab.Project.VisibilityLevel.Private;
        }


        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            folderTextBox.Text = new DirectoryInfo(this.LocalProjectDirectory.FullName + "\\" + projectNameTextBox.Text).FullName;
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog D = new FolderBrowserDialog();
            D.ShowNewFolderButton = true;
            D.SelectedPath = this.LocalProjectDirectory.FullName;
            
            if (D.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderTextBox.Text = D.SelectedPath + "\\" + projectNameTextBox.Text;
                this.LocalProjectDirectory = new DirectoryInfo(folderTextBox.Text);
            }
        }

        private void configComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadControls();
        }
    }
}
