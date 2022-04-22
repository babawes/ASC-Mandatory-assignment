using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC_Mandatory_assignment
{
    public class TracerCombatLog
    {
        private TraceSource tracer = new TraceSource("CombatTracer");

        public TracerCombatLog()
        {
            tracer.Switch = new SourceSwitch("Combat Log", "All");

            TraceListener consoleLog = new ConsoleTraceListener();
            tracer.Listeners.Add(consoleLog);

            TraceListener xmlLog = new XmlWriterTraceListener(new StreamWriter("CombatLog.xml"));
            tracer.Listeners.Add(xmlLog);
        }

    }
}
