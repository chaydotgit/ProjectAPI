using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            Descriptions = new HashSet<Description>();
        }

        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string[]? Tech { get; set; }
        public string? RepoLink { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }
    }
}
