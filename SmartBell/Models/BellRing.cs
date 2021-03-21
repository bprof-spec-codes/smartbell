﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// The role of a bellring 0=Start of a lesson 1=end of a lesson 2= special reason
    /// </summary>
    public enum BellRingType
    {
        /// <summary>Indicates the start of a lesson.</summary>
        Start,
        /// <summary>Indicates the end of a lesson.</summary>
        End,
        /// <summary>Indicates that it's not part of a regular bellringing.</summary>
        Special
    }

    /// <summary>BellRing is a sound done by the ouput device for a specific reason at a specific time range.</summary>
    public class BellRing
    {
        /// <summary>Unique Id used for database storage.</summary>
        [Key]
        public string Id { get; set; }
        /// <summary>The start time of outputing sound.</summary>
        public DateTime BellRingTime { get; set; }

        /// <summary>Read only parameter, interval of outputing sound.</summary>
        public TimeSpan Interval { get; set; }

        /// <summary>The interval of outputing sound in seconds for manual setup.</summary>
        public int IntervalSeconds { get; set; }

        /// <summary>
        /// The path the file or directory where the element or elements are specified.
        /// There are 3 possibilites [*].mp3 , [*].txt or [Directory]
        /// </summary>
        [StringLength(255)]
        public string AudioPath { get; set; }

        /// <summary>Specifies the reasoning of a bellring 0=Start of a lesson 1=end of a lesson 2= special reason</summary>
        public BellRingType Type { get; set; }

    }
}
