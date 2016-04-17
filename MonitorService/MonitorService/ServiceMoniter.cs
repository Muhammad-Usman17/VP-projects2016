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
        private System.ServiceProcess.ServiceController _service;
        private String Name,sname;
        public ServiceMoniter()
        {
            InitializeComponent();
            _service = new System.ServiceProcess.ServiceController();
            
            ServiceName = _service.ServiceName;
            Name = ServiceName;

        }

        protected override void OnStart(string[] args)
        {
            sname=args[0];
            _service = new System.ServiceProcess.ServiceController(sname);
            tmr1 = new Timer();
            this.tmr1.Interval = 3000;
            this.tmr1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            tmr1.Enabled = true;
            logging.WriteErrorlog("test window service started");


        }

        protected override void OnStop()
        {
            tmr1.Enabled = true;
            logging.WriteErrorlog("test window service stoped");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            _service.Refresh();
            if (_service.Status == ServiceControllerStatus.Stopped)
            {

                logging.WriteErrorlog("your service is crashed ");
                _service.Start();
                _service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 1, 0));
                sendNotificarion("servicelog17@gmail.com", "muhammadusman1794@gmail.com");
            }
        }
        private void sendNotificarion(String appAdd, String adminAdd)
        {

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(appAdd, "bse123456");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(appAdd);
            mail.To.Add(adminAdd);
            mail.Subject = "service crashed";
            mail.Body = "service name:" + Name + "is Crashed at time" + DateTime.Now.ToString() + Environment.NewLine + "service name:" + Name + "is restarted at time" + DateTime.Now.ToString() + Environment.NewLine + "Message by Serlog";
            try
            {
                client.Send(mail);
                logging.WriteErrorlog("done");
            }
            catch (SmtpException e)
            {

                logging.WriteErrorlog(e.InnerException.Message);
            }
        }


    }
}
