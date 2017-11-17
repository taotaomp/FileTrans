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
        Socket[] scaner = new Socket [60];    //multiple Socket container（用于存放套接字的数组，手动设定最多60个）
        int socketFlag = 0; //套接字数组索引(用于指示当前连接了多少个客户机)
        int fileHaveSentSize = 0;
        
        byte[] buff;

        public void localIPInfoSet()    //设置本地IP信息
        {
            ArrayList tempLocalIP = new IPRequire().ips; //这里调用了自定义的获取本地IP的类，来获取IP
            foreach (IPAddress item in tempLocalIP)
            {
                comboBox_IPs.Items.Add(item);
            }
            comboBox_IPs.Text = comboBox_IPs.Items[0].ToString();
            ip = IPAddress.Parse(comboBox_IPs.Text);
            ep = new IPEndPoint(ip, 13250);      //通过获取到的IP设置IPEndPoint对象
        }


        private void MainForm_Load(object sender, EventArgs e)      //form load
        {
            localIPInfoSet();
            label_searchWaiting.Hide();     //隐藏“检索中”标识
            button_cancelConnect.Hide();    //隐藏“取消连接”按钮
            comboBox_IPs.DropDownStyle = ComboBoxStyle.DropDownList;    //不可编辑下拉框
            textBox_IPStart.Text = ip.ToString().Split('.')[0] 
                + '.' + ip.ToString().Split('.')[1] 
                + '.' + ip.ToString().Split('.')[2] + '.';
            textBox_IPEnd.Text = textBox_IPStart.Text;

        }

        private void Button_searchIP_Click(object sender, EventArgs e)      //IP list set
        {
            label_searchWaiting.Show();     //显示“检索中”标识
            try
            {
                string IPStart = textBox_IPStart.Text;
                string IPEnd = textBox_IPEnd.Text;
                IPList = new IPListGenerate().IPListRequire(IPStart, IPEnd);    //这里调用了自定义的IP列表生成类，来获取规定范围内的IP
                createSockets();
                button_cancelConnect.Show();    //显示“取消连接”按钮   
            }
            catch(IPNotRightException ipe)
            {
                MessageBox.Show(ipe.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                foreach (IPAddress item in IPList)      //遍历IP容器，为每个IP创建socket套接字
                {
                    scaner[socketFlag] = new Socket(SocketType.Stream, ProtocolType.IP);
                    scaner[socketFlag].Connect(new IPEndPoint(item, 13252));    //use port13252
                    if (scaner[socketFlag].Connected == true)       //如果连接成功则将IP添加到已连接IP列表中
                    {
                        listBox_connectedIP.Items.Add(item);
                    }
                    socketFlag++;       //连接数量计数
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
            label_fileName.Text= fileSelecter.FileName;
            buff = new byte[1024];
            buff = System.Text.Encoding.UTF8.GetBytes("THEFILENAME" + fileSelecter.SafeFileName);   //给发送的数据加上文件名前缀
            byteSend();     //调用发送数据方法发送数据（这里发送的是文件名）
        }

        private void button_Send_Click(object sender, EventArgs e)     //send data
        {
            fileSerializeAndSend();
        }

        private void fileSerializeAndSend()
        {
            try
            {
                FileInfo f = new FileInfo(label_fileName.Text);     //获取文件信息
                progressBar.Maximum = (int)f.Length;
                fileHaveSentSize = 0;

                FileStream filePicker = new FileStream(label_fileName.Text, FileMode.Open);     // File container 
                buff = new byte[1024];
                int readCount;
                while ((readCount = filePicker.Read(buff, 0, 1024)) != 0) 
                {
                    byteSend();     //每读一次发送一次数据
                    fileHaveSentSize += readCount;
                    progressBar.Value = fileHaveSentSize;
                }

                //发送完成后处理
                buff = new byte[1024];
                buff = System.Text.Encoding.UTF8.GetBytes("THEFILEEND");   //发送数据结束标志
                byteSend();
                filePicker.Close();
                MessageBox.Show("文件发送完成");
                label_fileName.Text = string.Empty;     //文件名重置
                progressBar.Value = 0;      //进度条重置
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }

        private void byteSend()     //发送数据方法
        {
            for (int i = 0; i < socketFlag; i++)        //遍历所有套接字，发送获得的数据
            {
                scaner[i].Send(buff);
            }
        }

        private void button_cancelConnect_Click(object sender, EventArgs e)     //取消按钮
        {
            for (int i = 0; i < socketFlag; i++)
            {
                scaner[i].Close();
            }
            listBox_connectedIP.Items.Clear();
            socketFlag = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)        //关闭窗口时
        {
            for (int i = 0; i < socketFlag; i++)
            {
                scaner[i].Close();
            }
        }

        private void comboBox_IPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ip = IPAddress.Parse(comboBox_IPs.Text);
            ep = new IPEndPoint(ip, 13250);      //通过获取到的IP设置IPEndPoint对象
            textBox_IPStart.Text = ip.ToString().Split('.')[0]
                + '.' + ip.ToString().Split('.')[1]
                + '.' + ip.ToString().Split('.')[2] + '.';
            textBox_IPEnd.Text = textBox_IPStart.Text;
        }
    }
}
