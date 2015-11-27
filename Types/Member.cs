using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitLab
{
    /// <summary>
    /// Descriptor class for members of Groups or Projects
    /// </summary>
    public class Member : GitLab.User
    {
        public AccessLevel access_level;

        public enum AccessLevel
        {
            GUEST = 10
                   , REPORTER = 20
                   , DEVELOPER = 30
                   , MASTER = 40
                   , OWNER = 50
        }
    }
}
