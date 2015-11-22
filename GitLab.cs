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
    /// See https://gitlab.com/help/api/README.md for API Reference
    /// </summary>
    public partial class GitLab
    {
        public Config CurrentConfig = null;      

        public GitLab(Config _config)
        {
            CurrentConfig = _config;         
        }       
    }
}
