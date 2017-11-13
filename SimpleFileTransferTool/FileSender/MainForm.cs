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
using System.IO;
using System.Threading;

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
        Socket[] scaner = new Socket [60];    //multiple Socket container
        FileStream[] filePicker = new FileStream [5];  //multiple File container
        byte[][] buff = new byte[5][];

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
            button_cancelConnect.Hide();    //隐藏“取消连接”按钮
            
        }

        private void Button_searchIP_Click(object sender, EventArgs e)      //IP list set
        {
            label_searchWaiting.Show();     //显示“检索中”标识
            try
            {
                string IPStart = textBox_IPStart.Text;
                string IPEnd = textBox_IPEnd.Text;
                if (IPStart == string.Empty || IPEnd == string.Empty) throw new IPEmptyException();
                IPList = new IPListGenerate().IPListRequire(IPAddress.Parse(IPStart), IPAddress.Parse(IPEnd));    //这里调用了自定义的IP列表生成类，来获取规定范围内的IP
                createSockets();
                button_cancelConnect.Show();    //显示“取消连接”按钮   
            }
            catch(IPEmptyException ipe)
            {
                MessageBox.Show(ipe.ToString());
            }
            finally
            {
                label_searchWaiting.Hide();     //隐藏“检索中”标识
            }
            
        }

        private void createSockets()    //create sockets for every ip that will be connected
        {
            try
            {
                int socketFlag = 0; //套接字数组索引
                foreach (IPAddress item in IPList)      //遍历IP容器，为每个IP创建socket套接字
                {
                    scaner[socketFlag] = new Socket(SocketType.Stream, ProtocolType.IP);
                    scaner[socketFlag].Connect(new IPEndPoint(item, 13252));    //use port13252
                    if (scaner[socketFlag].Connected == true)       //如果连接成功则将IP添加到已连接IP列表中
                    {
                        listBox_connectedIP.Items.Add(item);
                    }
                    socketFlag++;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void button_addFile_Click(object sender, EventArgs e)   //add file that will be sent
        {
            OpenFileDialog fileSelecter = new OpenFileDialog();
            fileSelecter.ShowDialog(this);
            string filePath = fileSelecter.FileName;
            listBox_addedFile.Items.Add(filePath);
        }

        private void button_Send_Click(object sender, EventArgs e)     //send data
        {
            fileSerialize();
            Thread t =null;
            foreach (Socket item in scaner)
            {
                t = new Thread(delegate () 
                {
                    item.Send(buff[0]);
                });
                t.Start();
            }
            t.Abort();
        }

        private void fileSerialize()
        {
            for (int i = 0; i < listBox_addedFile.Items.Count; i++)
            {
                filePicker[i] = new FileStream(listBox_addedFile.Items[i].ToString(), FileMode.Open);   //path,FileMode
                buff[i] = new byte[256];
                filePicker[i].Read(buff[i], 0, 255);
                filePicker[i].Close();
            }
        }
    }
}
