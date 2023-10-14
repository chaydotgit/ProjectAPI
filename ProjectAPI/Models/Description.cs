using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class Description
    {
        public int DescriptionId { get; set; }
        public int? ProjectId { get; set; }
        public int? BulletOrder { get; set; }
        public string? Description1 { get; set; }

        public virtual Project? Project { get; set; }
    }
}
