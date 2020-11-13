using System.ServiceProcess;
using System.Timers;

namespace TestWindowsService
{
    public partial class Scheduler : ServiceBase
    {
        private Timer timer1 = null;
        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 30000; //Every 30 Secs
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer1_Tick);
            timer1.Enabled = true;
            Library.WriteErrorLog("Test window service started");
        }
        private void Timer1_Tick(object sender, ElapsedEventArgs e)
        {
            Library.WriteErrorLog("Timer ticked and som job has been done successfully");
        }
        protected override void OnStop()
        {
            timer1.Enabled = false;
            Library.WriteErrorLog("Test window service stoppped");

        }
    }
}
