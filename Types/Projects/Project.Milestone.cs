namespace GitLab
{
    public partial class GitLab
    {
        public partial class Project
        {
            public class Milestone
            {
                public int id, iid, project_id;
                public string title, description, due_date, state, updated_at, created_at;
            }
        }
    }
}
