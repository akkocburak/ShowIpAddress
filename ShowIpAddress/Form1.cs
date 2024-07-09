using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ShowIpAddress
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        public Form1()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Icon = new Icon("C:\\Users\\burak\\source\\repos\\ShowIpAddress\\ShowIpAddress\\ýcon .ico");
            notifyIcon.Visible = true;
            notifyIcon.Text = "IP Adresinizi Göster"; 
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick; 
            notifyIcon.BalloonTipClosed += NotifyIcon_BalloonTipClosed; 

            this.Load += Form1_Load;
            this.Shown += Form1_Shown; // Form gösterildiðinde tetiklenecek
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide(); // Form gösterildiðinde hemen gizle
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
            this.ShowInTaskbar = false; 
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string ipAddress = GetLocalIPAddress();
            notifyIcon.BalloonTipTitle = "IP Adresiniz";
            notifyIcon.BalloonTipText = ipAddress;
            notifyIcon.ShowBalloonTip(3000); 
        }

        private void NotifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Uygulamayý kapatmak istiyor musunuz?", "Uygulamayý Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}