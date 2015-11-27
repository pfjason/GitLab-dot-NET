using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitLab
{
    partial class GitLab
    {
        partial class Group
        {
            public class GroupMemberList: List<Member>
            {
                private Group _Parent = null;

                public Group Parent
                {
                    get { return _Parent; }
                }

                public GroupMemberList(Group _parent)
                {
                    _Parent = _parent;
                }

                /// <summary>
                /// Refreshes group members as long as Parent GitLab object is not null
                /// </summary>
                public void RefreshMembers()
                {
                    if (Parent != null)
                    {
                        this.Clear();

                        foreach (Member M in ListMembers(Parent.Parent.CurrentConfig, Parent))
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
                    GitLab.Group.AddMember(Parent.Parent.CurrentConfig, this.Parent, M, M.access_level);
                    RefreshMembers();

                }

                new public void Remove(Member M)
                {
                    GitLab.Group.DeleteMember(Parent.Parent.CurrentConfig, Parent, M);
                    RefreshMembers();
                }
            }
        }
    }
}
