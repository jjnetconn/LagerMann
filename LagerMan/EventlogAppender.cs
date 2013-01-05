using System;
using System.Diagnostics;
using System.Security;

namespace LagerMan
{
    class EventlogAppender
    {
        static string sSource  = "LagerMan";
        static string sLog = "Application";

        public static void logEvent_error_SQL(object e)
        {
            string sEvent;
            sEvent = e.ToString();

            if (!chkSourceExcists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
                
            EventLog.WriteEntry(sSource, sEvent,
                EventLogEntryType.Error, 110);
        }
        public static void logEvent(object e)
        {
            string sEvent;
            sEvent = e.ToString();

            if (!chkSourceExcists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, sEvent,
                EventLogEntryType.Error, 100);
        }

        public static void logEvent_Start(object e)
        {
            string sEvent;
            sEvent = e.ToString();

            if (!chkSourceExcists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, sEvent);
        }

        public static void logEvent_Exit(object e)
        {
            string sEvent;
            sEvent = e.ToString();

            if (!chkSourceExcists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, sEvent);
        }
        private static bool chkSourceExcists(string sSource)
        {
            bool sourceFound = false;
            try { 
                sourceFound = EventLog.SourceExists(sSource); 
            }
            catch (SecurityException) 
            { 
                sourceFound = false; 
            }

            return sourceFound;
        }
    }
}