using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender
{   
    /// <summary>
    /// 自定义异常“IP不能为空”
    /// </summary>
    class IPEmptyException:Exception
    {
        public IPEmptyException() : base("IP不能为空") { }
    }
}
