using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public enum BellRingType
    {
        Start,End,Special
    }

    public class BellRing
    {
        [Key]
        public string Id { get; set; }

        public  DateTime BellRingTime { get; set; }

        public TimeSpan Interval { get; set; }

        [StringLength(255)]
        public string AudioPath { get; set; }

        public BellRingType Type { get; set; }

    }
}
