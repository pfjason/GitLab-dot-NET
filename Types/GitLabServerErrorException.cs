using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitLab
{
    public class GitLabServerErrorException : System.Exception
    {
        public GitLabServerErrorException(string Message): base(Message)
        {
            
        }
    }
}
