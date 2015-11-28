using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace GitLab
{
    /// <summary>
    /// Class for interfacing with a GitLab API via .NET
    /// See https://gitlab.com/help/api/README.md for API Reference
    /// </summary>
    public partial class GitLab
    {
        public Config CurrentConfig = null;

        public GitLab(Config _config)
        {
            CurrentConfig = _config;
            Refresh();   
        }

        /// <summary>
        /// Refreshes Everything for this GitLab object;
        /// </summary>
        public void Refresh()
        {
            RefreshProjects();
            RefreshGroups();
            RefreshUsers();
            RefreshCurrentUser();

        }        
    }
}
