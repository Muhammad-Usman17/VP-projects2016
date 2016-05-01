using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MonitorService
{
    public partial class ServiceMoniter : ServiceBase
    {
        Timer tmr1 = null;
        private List<System.ServiceProcess.ServiceController> service=new List<System.ServiceProcess.ServiceController>();
        private System.ServiceProcess.ServiceController s;
        private String email,Server,Systememail,Subject,Body, credential;
        private int size, serverport;

        public ServiceMoniter()
        {
            InitializeComponent();

            
            s = new System.ServiceProcess.ServiceController("Service1");
            service.Add(s);


        }

        protected override void OnStart(string[] args)
        {
            size = args.Length;
            Server = args[0];
            serverport = Int32.Parse(args[1]);
            Systememail = args[2];
            credential = args[3];
            email = args[4];
            Subject = args[5];
            Body = args[6];

            service.Remove(s);
            for (int i = 7; i < args.Length; i++)
            {

                service.Add(new ServiceController(args[i]));
           }
            tmr1 = new Timer();
            this.tmr1.Interval = 3000;
            this.tmr1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            tmr1.Enabled = true;
           


        }


        protected override void OnStop()
        {
            tmr1.Enabled = true;
            logging.Remove();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (ServiceController _service in service)
            {
                _service.Refresh();
                if (_service.Status == ServiceControllerStatus.Stopped)
                {

                    logging.WriteErrorlog("The" + _service.DisplayName + " is Crashed ");
                    _service.Start();
                    _service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 1, 0));
                    logging.WriteErrorlog("The" + _service.DisplayName + " is Restarted ");
                    sendNotificarion(Systememail,credential, email,_service.DisplayName,Server,serverport);
                }
            }
        }
        private void sendNotificarion(String appAdd, String password, String adminAdd, String Servicename,String Host,int port)
        {

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(appAdd,password );
            client.Port = port;
            client.Host = Host;
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(appAdd);
            mail.To.Add(adminAdd);
            mail.Subject = Subject;
            mail.Body =Body +Environment.NewLine+ "service name:" + Servicename + "    is Crashed at time    " + DateTime.Now.ToString() + Environment.NewLine + "  service name:" + Servicename + "   is restarted at time   " + DateTime.Now.ToString() + Environment.NewLine + "Message by Serlog";
            try
            {
                client.Send(mail);
                logging.WriteErrorlog("ErrorMessage is sent to Admin Email");
            }
            catch (SmtpException e)
            {

                logging.WriteErrorlog(e.InnerException.Message);
            }
        }


    }
}
