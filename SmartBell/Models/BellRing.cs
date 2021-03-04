using System;

namespace Models
{
    public class BellRing
    {
        public string Id { get; set; }

        public  DateTime BellRingTime { get; set; }

        public TimeSpan Interval { get; set; }

        public string AudioPath { get; set; }

        public string TTSContent { get; set; }
    }
}
