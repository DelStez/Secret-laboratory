using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelOfAccess
{
    public partial class AddClient : Form
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int destIp, int srcIP, byte[] macAddr, ref uint physicalAddrLen);

        public AddClient(List<string> temp)
        {
            InitializeComponent();
            DownloadLAN(temp);
        }
        public void DownloadLAN(List<string> temp)
        {
            foreach(string v in temp)
            {
                IPAddress dst = IPAddress.Parse(v);
                byte[] macAddr = new byte[6];
                uint macAddrLen = (uint)macAddr.Length;
                if (SendARP(BitConverter.ToInt32(dst.GetAddressBytes(), 0), 0, macAddr, ref macAddrLen) != 0)
                    throw new InvalidOperationException("SendARP failed");
                string[] str = new string[(int)macAddrLen];
                for (int i = 0; i < macAddrLen; i++)
                {
                    str[i] = macAddr[i].ToString("x2");
                }
                string mac = string.Join(":", str);

                dataGridView1.Rows.Add(v, mac);
            }
            
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            
        }
    }
}
