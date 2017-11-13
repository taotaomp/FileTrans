﻿using System;
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
        /// （前3段需相同）
        /// </summary>
        /// <param name="IPStart">起始IP</param>
        /// <param name="IPEnd">结束IP</param>
        /// <returns></returns>
        public ArrayList IPListRequire(IPAddress IPStart,IPAddress IPEnd)
        {
            if (IPStart == null || IPEnd == null) throw new InvalidOperationException();
            ArrayList IPContainer = new ArrayList();
            string IPStart_S = IPStart.ToString();
            string IPEnd_S = IPEnd.ToString();
            string[] IPStart_Deal = IPStart_S.Split('.');
            string[] IPEnd_Deal = IPEnd_S.Split('.');
            for (int i = int.Parse(IPStart_Deal[3]); i < int.Parse(IPEnd_Deal[3])+1; i++)
            {
                string IPString = IPStart_Deal[0] + "." + IPStart_Deal[1] + "." + IPStart_Deal[2] + "." + i;
                IPContainer.Add(IPAddress.Parse(IPString));
            }
            return IPContainer;
        }
    }
}
