using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Template
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<DateTime> TemplateElements { get; set; }
    }
}
