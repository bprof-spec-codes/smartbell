using System;

namespace Models
{
    public enum BellRingType
    {
        Start,End,Special
    }

    public class BellRing
    {
        public string Id { get; set; }

        public  DateTime BellRingTime { get; set; }

        public TimeSpan Interval { get; set; }

        public string AudioPath { get; set; }

        public BellRingType Type { get; set; }

    }
}
