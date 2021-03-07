using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Template
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<BellRing> TemplateElements { get; set; }
    }
}
