using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.UI.VM
{
    /// <summary>
    /// View model for inserting lessons.
    /// </summary>
    public class LessonViewModel
    {
        /// <summary>
        /// Starting bellring of a lesson.
        /// </summary>
        public BellRing startBellRing { get; set; }
        /// <summary>
        /// Ending bellring of a lesson.
        /// </summary>
        public BellRing endBellring { get; set; }
        /// <summary>
        /// Starting output for the bellring of a lesson.
        /// </summary>
        public OutputPath startOutputpath { get; set; }
        /// <summary>
        /// Ending output for the bellring of a lesson.
        /// </summary>
        public OutputPath endOutputpath { get; set; }
    }
}
