using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class EventConnector
    {
        public static event EventHandler StudentUpdated;
        public static void OnStudentUpdated()
        {
            StudentUpdated?.Invoke(new object(), EventArgs.Empty);
        }


        public static event EventHandler RollUpdateEvent;
        public static void OnRollUpdateEvent() => RollUpdateEvent?.Invoke(new object(), EventArgs.Empty);
    }
}
