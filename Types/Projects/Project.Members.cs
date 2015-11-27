using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitLab
{
    partial class GitLab
    {
        partial class Project
        {

            public class ProjectMemberList: List<Member>
            {
                private Project _Parent = null;

                public Project Parent
                {
                    get { return _Parent; }
                }

                public ProjectMemberList(Project _parent)
                {
                    _Parent = _parent;
                    RefreshMembers();
                }                

                /// <summary>
                /// Refreshes project members as long as Parent GitLab object is not null
                /// </summary>
                public void RefreshMembers()
                {
                    if (Parent != null)
                    {
                        this.Clear();

                        foreach ( Member M in ListMembers(Parent.Parent.CurrentConfig, Parent))
                        {
                            base.Add(M);
                        }
                    }
                    else
                    {
                        throw new GitLabStaticAccessException("Unable to retrieve members without Parent Configuration.");
                    }
                }

                new public void Add(Member M)
                {
                    GitLab.Project.AddMember(Parent.Parent.CurrentConfig, this.Parent, M, M.access_level);
                    RefreshMembers();
                    
                }

                new public void Remove(Member M)
                {
                    GitLab.Project.DeleteMember(Parent.Parent.CurrentConfig, Parent, M);
                    RefreshMembers();
                }
            }

            /// <summary>
            /// List of project members. Will always be null if Project retrieved via static methods.
            /// </summary>
            public ProjectMemberList Members
            {
                get
                {
                    if (_Members == null & Parent != null)
                        _Members = new ProjectMemberList(this);

                    return _Members;
                }
            }

            private ProjectMemberList _Members = null;

            
        }
    }
}
