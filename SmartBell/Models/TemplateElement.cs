using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TemplateElement
    {
        [Key]
        public string Id { get; set; }

        public DateTime BellRingTime { get; set; }

        public TimeSpan Interval { get; set; }

        [StringLength(255)]
        public string AudioPath { get; set; }

        public BellRingType Type { get; set; }


        public string TemplateId { get; set; }

        [NotMapped]
        public virtual Template ParentTemplate { get; set; }

    }
}
