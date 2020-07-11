using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Runtime.InteropServices;


namespace SimpleService
{
    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    };


    public partial class SimpleService : ServiceBase
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        private EventLog eventLog;
        private int eventId = 1;

        public SimpleService(string[] args)
        {
            InitializeComponent();
            eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("SimpleServiceSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "SimpleServiceSource", "SimpleServiceLog");
            }
            eventLog.Source = "SimpleServiceSource";
            eventLog.Log = "SimpleServiceLog";

            eventLog.WriteEntry("[SIMPLESERVICE] Class Create", EventLogEntryType.Information, eventId++);
            if (args.Length > 0)
            {
                eventLog.WriteEntry("[SIMPLESERVICE] Class Create args: " + string.Join(",", args), EventLogEntryType.Information, eventId++);
            }
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog.WriteEntry("[SIMPLESERVICE] Tick", EventLogEntryType.Information, eventId++);
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("[SIMPLESERVICE] OnStart.");

            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("[SIMPLESERVICE] OnStop.");
            // Update the service state to Stop Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Update the service state to Stopped.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnContinue()
        {
            eventLog.WriteEntry("[SIMPLESERVICE] OnContinue.");
        }
    }
}
