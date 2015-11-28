using System;
using System.IO;
using System.Windows.Forms;

namespace GitLab
{
    public partial class ConfigurationForm : Form
    {
        Config CurrentConfig
        {
            get
            {
                if( nameComboBox.SelectedItem != null)
                    return nameComboBox.SelectedItem as Config;
                else
                {
                    Config C = new Config();
                    C.Name = nameComboBox.Text;
                    return C;
                }
            }
            set
            {
                nameComboBox.SelectedItem = value;
            }
        }

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigureGitLabForm_Load(object sender, EventArgs e)
        {
            LoadConfigNameDropdown();
            LoadValues();
            
        }

        void LoadValues()
        {
            this.uriTextBox.Text = CurrentConfig.GitLabURI;
            this.apiKeyTextBox.Text = CurrentConfig.APIKey;
            this.defaultLocationTextBox.Text = CurrentConfig.DefaultProjectLocation;
            this.httpCheckBox.Checked = CurrentConfig.PreferHTTPPush;
        }

        void LoadConfigNameDropdown()
        {
            nameComboBox.Items.Clear();
            nameComboBox.Text = "";

            foreach (Config C in Config.GetAllConfigs())
            {
                nameComboBox.Items.Add(C);
            }
            
            Config CC = new Config();
            CC.Name = "New GitLab Server...";
            nameComboBox.Items.Add(CC);
            nameComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Config C = CurrentConfig;
            C.GitLabURI = this.uriTextBox.Text;
            C.APIKey = this.apiKeyTextBox.Text ;
            C.DefaultProjectLocation = new DirectoryInfo(this.defaultLocationTextBox.Text).FullName;
            C.PreferHTTPPush = httpCheckBox.Checked;
            C.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void defaultLocationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog D = new FolderBrowserDialog();
            D.ShowNewFolderButton = true;
            if (D.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Directory.Exists(D.SelectedPath))
                {
                    defaultLocationTextBox.Text = D.SelectedPath;
                }
            }
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValues();
        }
    }
}
