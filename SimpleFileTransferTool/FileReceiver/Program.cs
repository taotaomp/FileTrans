using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using IPGet;
namespace FileReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = new IPRequire().Ip;              //这里调用了自定义的获取本地IP的类，来获取IP
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
                    byte[] buff = new byte[20];
                    receiver.Receive(buff);
                    string a = Encoding.UTF8.GetString(buff);
                    Console.WriteLine(a);
                }
            }
            
        }
    }
}
