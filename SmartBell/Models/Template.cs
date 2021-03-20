using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public class Template
    {
        [Key]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<TemplateElement> TemplateElements { get; set; }

    }
}
