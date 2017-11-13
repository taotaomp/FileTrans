using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using IPGet;    //导入自定义类库，内含IP列表生成类、本地IP获取类
using System.Collections;

namespace FileSender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        IPAddress ip;   //Local IP container
        ArrayList IPList;   //connect IP container
        IPEndPoint ep;      //local IP and port container
        Socket[] scaner;    

        public void localIPInfoSet()    //设置本地IP信息
        {
            ip = new IPRequire().Ip;        //这里调用了自定义的获取本地IP的类，来获取IP
            ep = new IPEndPoint(ip, 13250);      //通过获取到的IP设置IPEndPoint对象
            //Socket scaner = new Socket(SocketType.Stream,ProtocolType.IP);

            
            //scaner.Connect();
            //foreach (IPAddress item in IPList)      //遍历ip地址集合，依次向集合中的ip申请连接
            //{
            //    IPEndPoint epe = new IPEndPoint(item, 13252);
            //    //scaner.Connect(epe);
            //}
            //MessageBox.Show(scaner.Connected.ToString());
            //byte[] buff = System.Text.UTF8Encoding.UTF8.GetBytes("fuck you!");
            //scaner.Send(buff);
        }


        private void MainForm_Load(object sender, EventArgs e)      //form load
        {
            localIPInfoSet();
            label_localIP.Text = "本机IP为：" + ip.ToString();
            label_searchWaiting.Hide();     //隐藏“检索中”标识
            
        }

        private void Button_searchIP_Click(object sender, EventArgs e)      //IP list set
        {
            label_searchWaiting.Show();     //显示“检索中”标识
            string IPStart = textBox_IPStart.Text;
            string IPEnd = textBox_IPEnd.Text;
            IPList = new IPListGenerate().IPListRequire(IPAddress.Parse(IPStart), IPAddress.Parse(IPEnd));    //这里调用了自定义的IP列表生成类，来获取规定范围内的IP

        }
    }
}
