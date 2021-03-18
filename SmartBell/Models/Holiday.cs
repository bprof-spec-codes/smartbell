using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public enum HolidayType
    {
        Manual,Break,Holiday
    }
    public class Holiday
    {
        [Key]
        public string Id { get; set; }

        public HolidayType Type { get; set; }

        public DateTime StartTime{ get; set; }

        public DateTime EndTime { get; set; }
    }
}
