using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Template
    {
        [Key]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<BellRing> BellRings { get; set; }

        public virtual ICollection<TemplateElement> TemplateElements { get; set; }

    }
}
