using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace IPGet
{
    public class IPListGenerate 
    {
        /// <summary>
        /// 获取两个IP端间的IP地址集合
        /// （前3段需相同）（只3适用于IPv4）
        /// </summary>
        /// <param name="IPStart">起始IP</param>
        /// <param name="IPEnd">结束IP</param>
        /// <returns></returns>
        public ArrayList IPListRequire(string IPStart, string IPEnd)
        {
            IPAddress tempContainerForTryPase;
            if (!(IPAddress.TryParse(IPStart, out tempContainerForTryPase) && IPAddress.TryParse(IPEnd, out tempContainerForTryPase))) throw new IPNotRightException();
            ArrayList IPContainer = new ArrayList();
            string[] IPStart_Deal = IPStart.Split('.');
            string[] IPEnd_Deal = IPEnd.Split('.');
            for (int i = int.Parse(IPStart_Deal[3]); i < int.Parse(IPEnd_Deal[3])+1; i++)
            {
                string IPString = IPStart_Deal[0] + "." + IPStart_Deal[1] + "." + IPStart_Deal[2] + "." + i;
                IPContainer.Add(IPAddress.Parse(IPString));
            }
            return IPContainer;
        }
    }
}
