using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections;

namespace IPGet
{
    /// <summary>
    /// 实例化对象后，使用ip字段获取ip
    /// </summary>
    public class IPRequire
    {
        public ArrayList ips = new ArrayList();
        

        public IPRequire()
        {
            IPHostEntry hostIP = Dns.GetHostEntry(Dns.GetHostName());   //运用DNS类获取IPHostEntry实例
            
            foreach (IPAddress item in hostIP.AddressList)  //运用IPHostEntry实例中的IPAddressList列表获取需要的本机IP
            {
                if(!item.ToString().Contains(":"))  //获取非IPv6地址
                ips.Add(item);
            }
        }

    }
}
