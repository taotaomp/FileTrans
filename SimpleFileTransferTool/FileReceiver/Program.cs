using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using IPGet;
using System.IO;
namespace FileReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse(new IPRequire().ips[0].ToString());    //这里调用了自定义的获取本地IP的类，来获取IP
            Console.WriteLine(ip);
            IPEndPoint ep = new IPEndPoint(ip, 13252);      //通过获取到的IP设置IPEndPoint对象
            TcpListener listener = new TcpListener(ep);     //通过IPEndPoint对象设置Tcp侦听器（监听指定本机IP的指定端口）
            listener.Start();   //开始监听
            Socket receiver = null;
            while (true)
            {
                if (listener.Pending())
                {
                    receiver = listener.AcceptSocket(); 
                    Console.WriteLine("con!");
                    byte[] buff = new byte[1024];
                    int count;
                    FileStream fileReceiver = null;
                    while ((count = receiver.Receive(buff))!=0)
                    {
                        string filename = System.Text.Encoding.UTF8.GetString(buff, 0, count);
                        if (filename.StartsWith("THEFILENAME"))
                        {
                            fileReceiver = new FileStream(@"C:\Users\ataoD\Desktop\" + filename.Substring(11), FileMode.Create);
                            Console.WriteLine("file Created");
                        }
                        else if (filename.StartsWith("THEFILEEND"))
                        {
                            fileReceiver.Close();
                            Console.WriteLine("data Completed");
                        }
                        else if (fileReceiver != null) 
                        {
                            fileReceiver.Write(buff, 0, count);
                            Console.WriteLine("data Received");
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                    }
                    receiver.Close();
                }
            }
            
        }
    }
}
